jQuery(function($) {

    $.fn.extend({
        
        autoCorrect: function() {

            return this.each(function(index, item) {

                var $form = $(this);

                $form.on('blur', 'input,textarea,select', function(event) {

                    var $field = $(this);
                    var value = $field.val();

                    if ($field.is('[data-types~="decimal"]')) {

                        if (!value.match(/\d+/) && !value.match(/\d*[\.,]\d+/)) return;

                        value = value.replace(".", ",");

                        $field.val(value);
                    }

                    if ($field.is('[data-types~="currency"]')) {
                        
                        if (value.match(/^\d+$/)) value = value + ",00";

                        $field.val(value);

                    }

                });

            });

        }

    });

    $('[data-autocorrect]').autoCorrect();

});