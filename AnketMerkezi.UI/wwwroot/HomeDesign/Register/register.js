
//jQuery time
var current_fs, next_fs, previous_fs; //fieldsets
var left, opacity, scale; //fieldset properties which we will animate
var animating; //flag to prevent quick multi-click glitches

function nextForm(id) {
    if (animating) return false;
    animating = true;

    current_fs = $("#btnContinue" + id).parent();
    next_fs = $("#btnContinue" + id).parent().next();

    //activate next step on progressbar using the index of next_fs
    $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

    //show the next fieldset
    next_fs.show();
    //hide the current fieldset with style
    current_fs.animate({ opacity: 0 }, {
        step: function (now, mx) {
            //as the opacity of current_fs reduces to 0 - stored in "now"
            //1. scale current_fs down to 80%
            scale = 1 - (1 - now) * 0.2;
            //2. bring next_fs from the right(50%)
            left = (now * 50) + "%";
            //3. increase opacity of next_fs to 1 as it moves in
            opacity = 1 - now;
            current_fs.css({
                'transform': 'scale(' + scale + ')',
                'position': 'absolute'
            });
            next_fs.css({ 'left': left, 'opacity': opacity });
        },
        duration: 800,
        complete: function () {
            current_fs.hide();
            animating = false;
        },
        //this comes from the custom easing plugin
        easing: 'easeInOutBack'
    });
}

$(".previous").click(function () {
    if (animating) return false;
    animating = true;

    current_fs = $(this).parent();
    previous_fs = $(this).parent().prev();

    //de-activate current step on progressbar
    $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

    //show the previous fieldset
    previous_fs.show();
    //hide the current fieldset with style
    current_fs.animate({ opacity: 0 }, {
        step: function (now, mx) {
            //as the opacity of current_fs reduces to 0 - stored in "now"
            //1. scale previous_fs from 80% to 100%
            scale = 0.8 + (1 - now) * 0.2;
            //2. take current_fs to the right(50%) - from 0%
            left = ((1 - now) * 50) + "%";
            //3. increase opacity of previous_fs to 1 as it moves in
            opacity = 1 - now;
            current_fs.css({ 'left': left });
            previous_fs.css({ 'transform': 'scale(' + scale + ')', 'opacity': opacity });
        },
        duration: 800,
        complete: function () {
            current_fs.hide();
            animating = false;
        },
        //this comes from the custom easing plugin
        easing: 'easeInOutBack'
    });
});

$(".submit").click(function () {
    return false;
})

function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

$("#btnContinue1").click(() => {
    let username = $("#txtUsername").val(),
        pas = $("#txtPassword").val(),
        pass = $("#txtPasswordd").val();

    if (username != "" && username.length <= 25 && username.length > 5 && pas != "" && pas.length <= 25 && pas.length > 5 && pass != "" && pass.length > 5 && pass.length <= 25 && pas == pass) {

        $.ajax({
            url: "/User/UsernameControl?username=" + username,
            method: "GET",
            success: (res) => {
                if (res == 0) {
                    $("#txtPassword").attr("style", "");
                    $("#txtPasswordd").attr("style", "");
                    $("#txtUsername").attr("style", "");
                    $("#firstFormMsgArea").html("");
                    nextForm(1);
                } else if (res == 1)
                    $("#firstFormMsgArea").html("<label style='color:red;'>Bu kullanıcı adına sahip bir kullanıcı mevcuttur.</label>");
            }
        });

    } else {

        if (username == "" || !(username.length <= 25) || username.length < 5)
            $("#txtUsername").attr("style", "border:3px red groove");
         else
            $("#txtUsername").attr("style", "");

        if (pas == "" || !(pas.length <= 25) || pas.length < 5)
            $("#txtPassword").attr("style", "border:3px red groove");
        else
            $("#txtPassword").attr("style", "");

        if (pass == "" || !(pass.length <= 25) || pass.length < 5)
            $("#txtPasswordd").attr("style", "border:3px red groove");
        else
            $("#txtPasswordd").attr("style", "");

        if (pas.length > 5 && pas.length > 5 && (pas != pass)) {
            $("#txtPasswordd").attr("style", "border:3px red groove;color:red;");
            $("#txtPassword").attr("style", "border:3px red groove;color:red;");
        } else if (pas != "" && (pas.length <= 25) && pas.length > 5 && pass != "" && (pass.length <= 25) && pass.length > 5) {
            $("#txtPassword").attr("style", "");
            $("#txtPasswordd").attr("style", "");
        }
    }
});

$("#btnContinue2").click(() => {
    let email = $("#txtEmail").val(),
        name = $("#txtName").val(),
        surname = $("#txtSurname").val(),
        phoneNumber = $("#txtPhoneNumber").val();

    if (email != "" && isEmail(email) && name != "" && surname != "" && phoneNumber != "") {

        $.ajax({
            url: "/User/EmailControl?email=" + email,
            method: "GET",
            success: (res) => {
                if (res == 0) {
                    $("#txtEmail").attr("style", "");
                    $("#txtName").attr("style", "");
                    $("#txtSurname").attr("style", "");
                    $("#txtPhoneNumber").attr("style", "");
                    $("#secondFormMsgArea").html("");
                    nextForm(2);
                } else if (res == 1)
                    $("#secondFormMsgArea").html("<label style='color:red;'>Bu email adresine sahip bir kullanıcı mevcuttur.</label>");
            }
        });

    } else {

        if (email == null || !isEmail(email))
            $("#txtEmail").attr("style", "border:3px red groove");
        else
            $("#txtEmail").attr("style", "");

        if (name == "")
            $("#txtName").attr("style", "border:3px red groove");
        else
            $("#txtName").attr("style", "");

        if (surname == "")
            $("#txtSurname").attr("style", "border:3px red groove");
        else
            $("#txtSurname").attr("style", "");

        if (phoneNumber == "")
            $("#txtPhoneNumber").attr("style", "border:3px red groove");
        else
            $("#txtPhoneNumber").attr("style", "");

    }
});

$("#btnSubmit").click(() => {

    let accType = $("input[name='accountType']:checked").val();

    if (accType != null) {

        let username = $("#txtUsername").val(),
            password = $("#txtPassword").val(),
            email = $("#txtEmail").val(),
            name = $("#txtName").val(),
            surname = $("#txtSurname").val(),
            phoneNumber = $("#txtPhoneNumber").val(),
            token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: "/User/Register",
            method: "POST",
            data: {
                __RequestVerificationToken: token, 
                Username: username,
                Password: password,
                Email: email,
                Name: name,
                Surname: surname,
                PhoneNumber: phoneNumber,
                AccountType: accType
            },
            success: (res) => {
                if (res == 1) {
                    swal({
                        title: "Başarılı",
                        text: "Başarılı bir şekilde kayıt oldunuz. 3 saniye sonra giriş sayfasına yönlendirileceksiniz.",
                        type: "success",
                        confirmButtonClass: "btn-info",
                        confirmButtonText: "Giriş Yap",
                        closeOnConfirm: false
                    });
                    setTimeout(() => {
                        goSignInPage();
                    }, 3000);                   
                } else if (res == 0) {
                    swal({
                        title: "Hata!",
                        text: "Kayıt olurken bir sorun oluştu. 3 saniye sonra tekrar kayıt işlemine başlayacaksınız.",
                        type: "error",
                        confirmButtonClass: "btn-info",
                        confirmButtonText: "Yeniden Dene",
                    });
                    setTimeout(() => {
                        location.reload();
                    }, 3000);  
                }
            }
        });

    } else {
        $("div.accountTypeDiv").attr("style","height:300px;width:80%;border:3px red groove;");
    }

});