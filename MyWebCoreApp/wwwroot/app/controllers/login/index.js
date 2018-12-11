﻿var loginController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {
        $('#frmLogin').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                userName: {
                    required: true
                },
                password: {
                    required: true
                }
            }
        });

        $('#btnLogin').on('click', function (e) {
            e.preventDefault();
            if ($('#frmLogin').valid()) {
          
                var user = $('#txtUserName').val();
                var password = $('#txtPassword').val();
                login(user, password);
            }
        });

    }

    var login = function (user, pass) {
        $.ajax({
            type: 'POST',
            data: {
                UserName: user,
                Password: pass
            },
            dateType: 'json',
            url: "/admin/login/authen",
            success: function (res) {
                if (res.Success) {
                    window.location.href = "/Admin/Home/index";
                }
                else {
                    dkteam.notify('Thông tin đăng nhập không đúng', 'error');
                }
            }
        });
    }
}