jQuery(function ($) {

    var initializers = {};

    var queue = [];
    var queueRunning = false;

    function processQueue(internal) {

        if (queueRunning && !internal) {
            return;
        }

        if (queue.length == 0) {
            queueRunning = false;
            return;
        }

        queueRunning = true;

        var thisRequest = queue.shift();

        var ajaxFunc = (thisRequest.method && thisRequest.method == 'get') ? $.get : $.post;

        ajaxFunc(thisRequest.url, thisRequest.parameters || null, function (data) {
            if (thisRequest.callback && $.isFunction(thisRequest.callback)) {
                thisRequest.callback(data);
            }
            processQueue(true);
        }, thisRequest.returnType || 'json');
    }

    $.extend({
        addBitTemplateInitializer: function (func, key) {
            if ($.isFunction(func)) {
                if (!key) {
                    key = 'default';
                }

                initializers[key] = func;
            }
        },

        setDefaultBitTemplateInitializer: function (func) {
            $.addTemplateInitializer(func, 'default');
        },

        enqueueAjaxRequest: function (url, parameters, callback, requestType, method) {
            queue.push({
                url: url,
                parameters: parameters || null,
                callback: callback || null,
                requestType: requestType || 'json',
                method: method || 'post'
            });

            processQueue(false);
        }
    });

    $.fn.extend({

        insertBitTemplateByUrl: function (url, parameters, callback, initializerName, position) {
            var $containingElement = $(this);

            $.post(url, parameters, function (data) {

                var $newMarkup = $(data);

                if (position == 'prepend') {
                    $newMarkup.prependTo($containingElement);
                } else {
                    $newMarkup.appendTo($containingElement);
                }

                var funcKey = initializerName || 'default';

                if (funcKey in initializers) {
                    initializers[funcKey]($newMarkup);
                }

                if ($.isFunction(callback)) {
                    callback();
                }

            }, 'html');
        }
    });
});