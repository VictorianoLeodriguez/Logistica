$(document).on('click', 'tbody tr td', function () {
    var id = $(this).data('id');
    if (id) {
        window.location.href = '/CadUser/Cadastro/' + id;
    }
});

$(document).on('click', '#btn', function () {
    var senha = $('#Selecionar').val();


})
