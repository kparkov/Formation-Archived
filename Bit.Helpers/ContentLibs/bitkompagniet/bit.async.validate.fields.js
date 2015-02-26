jQuery(function ($) {

    var windowSecure = false;

    $.fn.extend({
        
        errorHighlight: function() {
            return this.each(function(index, item) {

                var $this = $(this);
                var $fields = $this.find('input,select,textarea');

                $this.on('start.async.submit', function (event) {

                    var $errorFields = $this.find('input,textarea,select').filter('.validation-error');

                    $errorFields.removeClass('validation-error');
                    $errorFields.attr('data-validation-message', null);

                    $errorFields.trigger('validation-error-cleared');

                    $this.trigger('validation-errors-cleared');
                });

                $this.on('error.async.submit', function (event, data) {

                    $.each(data.Errors, function(name, messages) {

                        var $field = $this.find('[name="' + name + '"]');

                        $field.addClass('validation-error');
                        $field.attr('data-validation-message', messages.join(', '));

                        $field.trigger('validation-error');
                    });

                    $this.trigger('validation-errors-initialized');
                });
            });
        },

        safetyOn: function() {
            return this.each(function(index, item) {

                var $form = $(this);

                $form.on('input.safety', 'input,select,textarea', function(event) {

                    if (windowSecure) return;

                    $form.addClass('form-confirm-exit');

                    window.onbeforeunload = function (e) {
                        var message = "Data er ændret, men ikke gemt.";

                        e = e || window.event;

                        // For IE and Firefox
                        if (e) {
                            e.returnValue = message;
                        }

                        // For Safari
                        return message;
                    }

                    windowSecure = true;

                });

                $form.on('success.async.submit', function() {

                    $form.removeClass('form-confirm-exit');

                    window.onbeforeunload = null;
                    windowSecure = false;
                });
            });
        }
    });

    $('[data-async-submit]').not('[data-no-highlight]').errorHighlight();
    $('[data-safety-form]').safetyOn();

});