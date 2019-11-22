$(function () {
    $('.stars').on('click', 'label', function (e) {
        const clickedStar = e.currentTarget;
        const rating = $(clickedStar).data('rating');

        $('#Rating').val(rating);
    });
})