$(document).on('click', '.expandable-panel div.panel-heading', function (e) {
            var $this = $(this);
            if (!$this.parent().parent('.expandable-panel').hasClass('collapsed')) {
                $this.parent('.panel').find('.panel-body').slideUp();
                $this.parent().parent('.expandable-panel').addClass('collapsed');
            } else {
                $this.parent('.panel').find('.panel-body').slideDown();
                $this.parent().parent('.expandable-panel').removeClass('collapsed');
            }
        });