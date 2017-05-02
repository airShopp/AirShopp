 var code ; //在全局定义验证码    //产生验证码   function createCode(){        code = "";         var codeLength = 4;//验证码的长度        var checkCode = document.getElementById("code");         var random = new Array(0,1,2,3,4,5,6,7,8,9,'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R',        'S','T','U','V','W','X','Y','Z');//随机数        for(var i = 0; i < codeLength; i++) {//循环操作           var index = Math.floor(Math.random()*36);//取得随机数的索引（0~35）           code += random[index];//根据索引取得随机数加到code上       }       checkCode.value = code;//把code值赋给验证码   }   //校验验证码   function validate() {     var msg = "";     var username = $("#loginname").val();     var pwd = $("#nloginpwd").val();      if (username == "" && pwd == "") {         msg = "用户名和密码不能为空";     }      if (!msg && username == "") {         msg = "用户名不能为空";     }      if (!msg && pwd == "") {         msg = "密码不能为空"     }      if (msg) {         $(".msg-wrap").text(msg);     }     else {         var inputCode = document.getElementById("authcode").value.toUpperCase(); //取得输入的验证码并转化为大写                 if (inputCode.length <= 0) { //若输入的验证码长度为0               $(".msg-wrap").text("请输入验证码！"); //则弹出请输入验证码           }         else if (inputCode != code) { //若输入的验证码与产生的验证码不一致时               $(".msg-wrap").text("验证码输入错误！@_@"); //则弹出验证码输入错误               $("#code").val("");//清空文本框             createCode();//刷新验证码           }         else { //输入正确时               $("#form").submit();         }     } }  $(function () {
    var nameCookie = getcookie("UserName");
    var pwdCookie = getcookie("Password");
    if (nameCookie && pwdCookie) {
        $("#loginname").val(nameCookie);
        $("#nloginpwd").val(pwdCookie);
        $("#autologin").prop("checked",true);
    }
});
function getcookie(objname) {//Get specific name of Cookie's value.
    var arrstr = document.cookie.split("; ");
    for (var i = 0; i < arrstr.length; i++) {
        var temp = arrstr[i].split("=");
        if (temp[0] == objname) {
            return unescape(temp[1]);
        }
    }
}