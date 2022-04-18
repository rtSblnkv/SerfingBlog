"use strict"

document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('form');
    form.addEventListener('submit', formSend);
    async function formSend(e) {
        e.preventDefault();
        if (formValidate(form) === 0) {
            form.reset();
            document.location="main.html";
        }
    }
    function formValidate(form) {
        let error = 0;
        let formReq = document.querySelectorAll('._req');
        let span = document.querySelectorAll('.span');
        for (let index = 0; index < formReq.length; index++) {
            const input = formReq[index];
            input.classList.remove('_error');
            if (input.value === '') {
                input.classList.add('_error');
                error++;
                span[index].innerHTML = "Обязательное поле является пустым"
            }
            else if (input.classList.contains('_email')) {
                if (emailTest(input)) {
                    input.classList.add('_error');
                    error++;
                    span[index].innerHTML = "Неверный формат почтового адреса"
                }
                else {
                    input.classList.add('_correctly');
                    span[index].innerHTML = '';
                }
            }
            else if (input.classList.contains('_number')) {
                if (phoneNumberTest(input)) {
                    input.classList.add('_error');
                    error++;
                    span[index].innerHTML = "Неверный формат номера телефона"
                }
                else {
                    input.classList.add('_correctly');
                    span[index].innerHTML = '';
                }
            }
            else if (input.classList.contains('_address')) {
                if (adresssTest(input)) {
                    input.classList.add('_error');
                    error++;
                    span[index].innerHTML = "Неверный формат адреса. Недопустимо использование латинских букв"
                }
                else {
                    input.classList.add('_correctly');
                    span[index].innerHTML = '';
                }
            }
            else {
                input.classList.add('_correctly');
                span[index].innerHTML = '';
            }
        }
        return error;
    }
    function emailTest(input) {
        return !/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/.test(input.value);
    }
    function phoneNumberTest(input) {
        return !/^(\+7|7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$/.test(input.value);
    }
    function adresssTest(input) {
        return !/^[*-,.а-яА-ЯёЁ0-9\s]+$/.test(input.value);
    }
});