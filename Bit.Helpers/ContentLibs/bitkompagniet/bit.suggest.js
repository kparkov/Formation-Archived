jQuery(function($) {

    $.fn.extend({
        
        suggestInput: function() {

            return this.each(function() {

                var $this = $(this);

                if (!$this.is('input[type="text"][data-url]')) return;

                var config = {
                    url: $this.attr('data-url')
                };

                var $suggestionsBox = $('<div class="suggestions-box"></div>').css({
                    'display': 'none',
                    'position': 'absolute',
                    'top': $this.offset().top + $this.outerHeight(),
                    'left': $this.offset().left,
                    'min-width': $this.outerWidth()
                }).hide().appendTo('body');

                function addsuggest(index, item) {
                    var pos = item.toLowerCase().indexOf($this.val().toLowerCase());

                    if (pos >= 0) {
                        item = item.substring(0, pos) + '<strong>' + item.substr(pos, $this.val().length) + '</strong>' + item.substring(pos + $this.val().length);
                    }

                    $('<div class="suggestions-item">' + item + '</div>').appendTo($suggestionsBox);
                }

                function getSuggestions() {

                    var query = $this.val();

                    $.get(config.url, { query: query }, function (data) {
                        $suggestionsBox.empty();

                        if (data && data.result && data.result.length > 0) {
                            $.each(data.result, addsuggest);
                            $suggestionsBox.show();
                            $suggestionsBox.find('.suggestions-item').first().addClass('highlighted');
                        } else {
                            $suggestionsBox.hide();
                        }

                    }, 'json');

                }

                $this.on('input', function(event) {

                    getSuggestions();

                });

                $this.on('keydown', function(event) {

                    if ($suggestionsBox.is(':hidden')) return;

                    var $items = $suggestionsBox.find('.suggestions-item');
                    var $current = $items.filter('.highlighted');
                    var $next = $([]);

                    if (event.which == 40) {
                        event.preventDefault();
                        $next = $current.next();
                        if ($next.length == 0) $next = $items.first();
                        $items.removeClass('highlighted');
                        $next.addClass('highlighted');
                    }

                    if (event.which == 38) {
                        event.preventDefault();
                        $next = $current.prev($items);
                        if ($next.length == 0) $next = $items.last();
                        $items.removeClass('highlighted');
                        $next.addClass('highlighted');
                    }

                    if (event.which == 13) {
                        event.preventDefault();
                        $this.val($current.text());
                        $suggestionsBox.hide();
                    }

                });

                $suggestionsBox.on('click', '.suggestions-item', function(event) {
                    event.preventDefault();
                    event.stopPropagation();
                    
                    $this.val($(this).text());
                    $suggestionsBox.hide();
                });

                $suggestionsBox.on('mouseenter', '.suggestions-item', function(event) {
                    event.preventDefault();
                    event.stopPropagation();
                    $suggestionsBox.find('.suggestions-item').removeClass('highlighted');
                    $(this).addClass('highlighted');
                });

                $('body').on('click', function(event) {

                    if ($(this).is($this)) return;
                    $suggestionsBox.hide();

                });

                $('body').on('focus', 'select,textarea,input', function(event) {
                    
                    if ($(this).is($this)) return;
                    $suggestionsBox.hide();

                });

            });

        }

    });

    $('[data-suggest-input]').suggestInput();


})