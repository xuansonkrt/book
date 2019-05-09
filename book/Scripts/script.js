
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

var delete_cookie = function (name) {
    document.cookie = name + '=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
};

function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

$(document).ready(function () {
    //$("#SoLuong").spinner({
    //    min: 1,
    //    max: 100,
    //    step: 1
    //});


    $("#SoLuong").on("change", function () {
        var amount = $("#SoLuong").val();
        if (amount <= 0) {
            $("#SoLuong").val(1);
        }
    });


    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('.user-avatar').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    }


    $("#input-avatar").change(function (e) {
        // readURL(this);
        console.log("adfadfe: ", e);
        var data = new FormData();
        var files = e.target.files;
        console.log("Get file");
        for (var x = 0; x < files.length; x++) {
            data.append("file" + x, files[x]);
            console.log('Have file');
        }
        $.ajax({
            url: "/Upload/UploadFile2",
            type: "POST",
            data: data,
            contentType: false,
            processData: false,
            success: function (data) {
                console.log(data.sussess);
                if (data.sussess >= 0) {
                    console.log(data);
                    $("#avatar").val(data.filename);
                    //  $('.user-avatar').css({ content: src(data.filename) });
                     $('.user-avatar').attr('src',data.filename );
                    //  alert($("#avatar").val());
                   // $('.user-avatar').attr('src', e.target.result);
                }
            }.bind(this)
        })
            .done(function () {
                console.log("xong roi");
                //$(this).addClass("done");
            });
    });

    //$("#myForm").submit(function (e) {
    //    alert("submit");
    //  //  e.preventDefault();
    //    //var formData = new FormData();
    //    //formData.append('file', $("#input-avatar")[0].files[0]);
    //    //$.ajax({
    //    //    url: "/Upload/UploadFile",
    //    //    data: formData,
    //    //    method: 'POST',
    //    //    success: function (data) {
    //    //        console.log(data);
    //    //        alert("ahihi");
    //    //        $("#myForm")[0].submit();
    //    //    },
    //    //    error: function (xhr, status, err) {
    //    //        console.log(err.toString());
    //    //    }
    //    //})
    //});

    $('input[name=gender]').change(function () {
        $('#gender').val($('input[name=gender]:checked').val());
    });

    $("#input-image").change(function (e) {
        // readURL(this);

        $('.book-image').attr('src', e.target.result);

        var data = new FormData();
        var files = e.target.files;
        console.log("Get file");
        for (var x = 0; x < files.length; x++) {
            data.append("file" + x, files[x]);
            console.log('Have file');
        }
        console.log('data: ',data);
        $.ajax({
                url: "/Upload/UploadFile2",
                type: "POST",
             //   data: JSON.stringify(data),
                data: data,
                contentType: false,
                processData: false,
                success: function (data) {
                    console.log(data.sussess);
                    if (data.sussess >= 0) {
                        console.log(data);
                        $("#image").val(data.filename);
                        $('.book-image').attr('src', data.filename);
                    }
                }.bind(this)
            })
            .done(function () {
                console.log("xong roi");
                //$(this).addClass("done");
            });
    });
    $("#btnAdd").on('click',function () {
        // readURL(this);

        var id = $(this).data("id");
        var amount = $('#SoLuong').val();
        var data = {
            id : id,
            amount : amount
        };
        
        console.log("data: ", data);
        $.ajax({
                url: "/ShoppingCart/Add2",
                type: 'POST',
                data: data,
                dataType: 'json',
              //  contentType: false,
              //  processData: false,
                success: function (data) {
                    console.log(data.ret);
                    if (data.ret >= 0) {
                        location.reload();
                    }
                }.bind(this)
            })
            .done(function () {
                console.log("xong roi");
                //$(this).addClass("done");
            });
    });
    $("#checkOut").on('click', function () {
        // readURL(this);

       
        
        var data = {
            Name: $('#name').val(),
            Email: $('#email').val(),
            Telephone: $('#phone').val(),
            Address: $('#address').val(),
        };

        console.log("data: ", data);
        $.ajax({
                url: "/Cart/Checkout2",
                type: 'POST',
                data: data,
                dataType: 'json',
                //  contentType: false,
                //  processData: false,
                success: function (data) {
                    console.log(data.ret);
                    if (data.ret >= 0) {
                        swal({
                                 title: 'Thành công',
                                 text: 'Thanh toán thành công',
                                 type:'success' ,
                                 timer:1500
                             }
                        
                         ).then(function() {
                             window.location.href="/";
                         });
                    } else {
                        swal({
                                title: 'Thất bại',
                                text: 'Thanh toán không thành công',
                                type: 'error'
                              //  timer: 1500
                            }

                        )
                    }
                }.bind(this)
            })
            .done(function () {
                console.log("xong roi");
                //$(this).addClass("done");
            });
    });

    $('.changeSoLuong').on('change',
        function() {
            var id = $(this).data('id');
            var amount = $(this).val();
            var data=
            {
                id: id,
                 amount: amount
            };
            console.log("data: ", data);
            $.ajax({
                    url: "/ShoppingCart/ChangeAmount",
                    type: 'POST',
                    data: data,
                    dataType: 'json',
                    //  contentType: false,
                    //  processData: false,
                    success: function (data) {
                        console.log(data.ret);
                        if (data.ret >= 0) {
                            location.reload();
                        } else {
                            swal({
                                    title: 'Thất bại',
                                    text: 'Xử lý không thành công',
                                    type: 'error'
                                    //  timer: 1500
                                }

                            )
                        }
                    }.bind(this)
                })
                .done(function () {
                    console.log("xong roi");
                    //$(this).addClass("done");
                });
        });

    $('.changeStatus').on('change',
        function () {
            var id = $(this).data('id');
            var status = $(this).val();
            //alert( id+' : '+status);
            var data =
            {
                ID: id,
                ID_InvoiceStatus: status
            };
            console.log("data: ", data);
            $.ajax({
                    url: "/Invoice/ChangeStatus",
                    type: 'POST',
                    data: data,
                    dataType: 'json',
                    //  contentType: false,
                    //  processData: false,
                    success: function (data) {
                        console.log(data.ret);
                        if (data.ret >= 0) {
                           // location.reload();
                        } else {
                            swal({
                                    title: 'Thất bại',
                                    text: 'Xử lý không thành công',
                                    type: 'error'
                                    //  timer: 1500
                                }

                            )
                        }
                    }.bind(this)
                })
                .done(function () {
                    console.log("xong roi");
                    //$(this).addClass("done");
                });
        });
});