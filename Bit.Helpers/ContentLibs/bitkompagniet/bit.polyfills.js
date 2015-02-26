jQuery(function($) {
    
    if (!window.console) {
        window.console = {};
    }

    if (!$.isFunction(window.console.log)) {
        window.console.log = function(msg) {
            // > /dev/null
        }
    }
});