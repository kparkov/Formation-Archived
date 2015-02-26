jQuery(function($) {

    $.fn.extend({

        asyncSubmit: function() {

            return this.each(function (index, item) {

                var $form = $(this);
                var $spinner = $form.find('[data-async-spinner]');
                var $submitButtons = $form.find('input[type="submit"]');
                var $fields = $form.find('input,textarea,select');

                if ($form.hasClass('is-submitting')) return;

                $form.addClass('is-submitting');
                $form.trigger('start.async.submit');

                var serialized = $form.serialize();
                var url = $form.attr('action');
                var method = $form.attr('method').toUpperCase();

                if (!$form.is('[data-async-keep-enabled]')) $submitButtons.add($fields).prop('disabled', true);
                $spinner.fadeIn(100);

                var unusualRequestTime = 10000;

                var unusualTimer = setTimeout(function() {

                    $form.trigger('unusual-request-time');

                }, unusualRequestTime);

                $.ajax({

                    type: method,
                    url: url,
                    data: serialized,
                    timeout: 100000,
                    dataType: 'json'

                }).done(function (data) {

                    if (data && data.Status) {
                        $form.trigger('end.async.submit', data);
                        $form.trigger(data.Status.toLowerCase() + '.async.submit', data);
                    }

                }).fail(function(xhr, textStatus, errorThrown) {
                    
                    $form.trigger('requestfail.async.submit', {xhr: xhr, status: textStatus, error: errorThrown});

                }).always(function () {

                    clearTimeout(unusualTimer);
                    $spinner.stop().fadeOut(100);
                    if (!$form.is('[data-async-keep-enabled]')) $submitButtons.add($fields).prop('disabled', false);
                    $form.removeClass('is-submitting');

                    $form.trigger('done.async.submit');
                });

            });

        },

        asyncSubmitSetup: function (options) {

            var defaults = { manual: false };

            var settings = $.extend({}, defaults, options || {});

            return this.each(function (index, item) {

                var $form = $(this);
                var $spinner = $form.find('[data-async-spinner]');

                $spinner.hide();

                if (!settings.manual) {

                    $form.on('submit', function (event) {
                        event.preventDefault();
                        $form.asyncSubmit();
                    });

                }
            });
        }
    });

    $('form[data-async-submit]').asyncSubmitSetup();

});