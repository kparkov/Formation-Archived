jQuery(function($) {

    var $flashMessages = null;

    var messages = {
        success: 'Data er gemt.',
        failure: 'Handlingen lykkedes ikke.',
        error: 'Der er fejl i formularen. Data er ikke gemt. Tjek felter markeret med rødt.'
    };

    $.fn.extend({
        
        slideFadeIn: function(callback) {

            return this.each(function() {

                var $this = $(this);

                var formerPosition = $this.css('position');

                $this.css({ 'position': 'relative', 'opacity': 0, 'top': -40 }).show();

                $this.animate({ 'opacity': 1 }, 300).animate({ 'top': 0 }, 500, function() {
                    $this.css('position', formerPosition);

                    if (callback) callback();

                }).dequeue();
            });

        },

        slideFadeOut: function(callback) {
            
            return this.each(function () {

                var $this = $(this);

                var formerPosition = $this.css('position');

                $this.css({ 'position': 'relative' });

                $this.animate({ 'opacity': 0 }, 300).animate({ 'top': 40 }, 600, function() {

                    $this.css('position', formerPosition);

                    if (callback) callback();

                }).dequeue();
            });

        }

    });

    $.extend({
        
        enableFlashMessages: function() {

            $flashMessages = $('<div class="flash-messages"></div>')
                .css({
                    'position': 'fixed',
                    'width': '500px',
                    'top': '20px',
                    'right': '50px',
                    'z-index': '100'
                })
                .appendTo('body');
        },

        flashMessage: function(message) {
            return $('<div class="flash-message" style="cursor: pointer">' + message + '</div>');
        },

        successFlash: function(message, millis) {
            var $flash = $.flashMessage(message);
            $flash.addClass("alert-box success");
            $flash.attr('data-alert', "");

            $.flash($flash, millis || 3000);
        },

        errorFlash: function (message, millis) {
            var $flash = $.flashMessage(message);
            $flash.addClass("alert-box alert");
            $flash.attr('data-alert', "");

            $.flash($flash, millis || 20000);
        },

        warningFlash: function(message, millis) {

            var $flash = $.flashMessage(message);
            $flash.addClass("alert-box warning");
            $flash.attr('data-alert', '');

            $.flash($flash, millis || 20000);

        },

        failureFlash: function(message, millis) {

            $.errorFlash(message, millis);

        },

        infoFlash: function (message, millis) {

            var $flash = $.flashMessage(message);
            $flash.addClass("alert-box info");
            $flash.attr('data-alert', '');

            $.flash($flash, millis || 3000);

        },

        flash: function ($flashMessage, time) {

            $flashMessages.find('.flash-message').trigger('die');

            var timer = null;

            $flashMessage.hide().prependTo($flashMessages);

            $flashMessage.on('die', function() {
                clearTimeout(timer);
                $flashMessage.remove();
            });

            $flashMessage.on('retire', function() {
                clearTimeout(timer);

                $flashMessage.slideFadeOut(function () {
                    $flashMessage.remove();
                });
            });

            $flashMessage.on('click', function() {
                $flashMessage.trigger('retire');
            });

            $flashMessage.slideFadeIn(function() {
                timer = setTimeout(function() {
                    $flashMessage.trigger('retire');
                }, time);
            });
        },

        setStandardMessages: function(newmessages) {
            messages = newmessages;
        }

    });

    $.enableFlashMessages();

    $.fn.extend({
        
        asyncFlashForm: function() {
            return this.each(function() {

                var $form = $(this);
                if ($form.is('[data-async-no-flash]')) return;

                $form.on('start.async.submit', function (event, data) {

                    $.infoFlash('Opdaterer...');

                });

                $form.on('end.async.submit', function(event, data) {

                    var key = data.Status.toLowerCase();
                    var func = $[key + 'Flash'];
                    var message = data.FeedbackMessage || messages[key];

                    func(message);

                });

                $form.on('requestfail.async.submit', function(event, errorinfo) {

                    $.errorFlash('Der skete en fejl under opdatering. Ændringer er måske ikke gemt. Forsøg at gemme igen. Serveren svarede med fejlkode ' + errorinfo.xhr.status + ' (' + errorinfo.xhr.statusText + ').');

                });

            });
        }

    });

    $('[data-async-submit]').asyncFlashForm();

})