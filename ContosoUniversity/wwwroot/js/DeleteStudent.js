function deletethis(Fid) {
    debugger;
    $.ajax({
        type: 'Post', //请求方式,可以为Get,Post,Put,Delete
        data: '{"Fid":"' + Fid + '" }', //发送的参数
        url: '/Student/DeleteStu', //请求的地址

        contentType: "application/json;charset=utf-8", //请求的数据类型以及编码
        dataType: 'json', //数据类型,
        success: function(jsonStr) { //请求成功执行的方法
            //var user = eval(jsonStr);
            //$("#phone").val(user.Phone);
            //刷新当前页面.
            window.location.reload(true);
        }
    });
}
