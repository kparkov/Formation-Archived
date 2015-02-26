jQuery(function ($) {

    var setupExpander = function($element) {
        
        var $this = $element;
        if ($this.hasClass('activated')) return;

        $this.addClass('activated');

        var $title = $this.find('[data-expander-title]');
        var $content = $this.find('[data-expander-content]');

        $('<i></i>').css('margin-right', '1em').addClass('fa fa-minus-circle').addClass('active-icon').prependTo($title.find('.expander-title')).show();
        $('<i></i>').css('margin-right', '1em').addClass('fa fa-plus-circle').addClass('inactive-icon').prependTo($title.find('.expander-title')).hide();

        $title.css('cursor', 'pointer');

        $this.on('click', '[data-expander-title]', function () { $this.expander('toggle'); });

        if ($this.attr('data-expander-default-hidden').toLowerCase() === "true") {
            $this.expander('collapse');
        } else {
            $this.expander('expand');
        }

    }

    $.fn.extend({
        
        expander: function(action) {
            return this.each(function() {

                var $this = $(this);
                var $title = $this.find('[data-expander-title]');
                var $content = $this.find('[data-expander-content]');
                var $activeIcon = $title.find('i.active-icon');
                var $inactiveIcon = $title.find('i.inactive-icon');

                if (!action) setupExpander($this);

                if (action == 'toggle') {
                    action = ($this.hasClass('expanded')) ? 'collapse' : 'expand';
                }

                if (action == 'expand') {
                    $this.addClass('expanded');
                    $content.show();
                    $activeIcon.show();
                    $inactiveIcon.hide();
                }

                if (action == 'collapse') {
                    $this.removeClass('expanded');
                    $content.hide();
                    $activeIcon.hide();
                    $inactiveIcon.show();
                }

            });
        }

    });

    $('[data-expander]').expander();


});