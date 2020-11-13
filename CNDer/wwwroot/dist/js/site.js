

document.addEventListener('DOMContentLoaded', function () {
  CarregarFuncaoDeConfirmarSubmit();
  CarregarMask();
});


function CarregarFuncaoDeConfirmarSubmit() {

  var elementos = document.querySelectorAll('.ConfirmarSubmit');
  for (var i = 0, len = elementos.length; i < len; i++) {
    elementos[i].onclick = function () {
      var check = confirm("Tem certeza que deseja continuar?");
      if (check == true) {
        return true;
      }
      else {
        return false;
      }
    };

  }
}


function CarregarMask() {
  var options = {
    onKeyPress: function (cpfcnpj, e, field, options) {
      var masks = ['000.000.000-000', '00.000.000/0000-00'];
      var mask = (cpfcnpj.length > 14) ? masks[1] : masks[0];
      $('.cpfcnpj').mask(mask, options);
    }
  };

  $('.cpfcnpj').mask('00.000.000/0000-00', options);

  $('.cep').mask('00.000-000');
  
  $('.phone').mask('(00) 0000-00000');
  
  $('.hora').mask('00:00:00', {placeholder: ''}, {clearIfNotMatch: true});
}
