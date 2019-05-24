function updateAcc() {

    var data = {
        ID: $('#accountId').val(),
        Name: $('#name').val(),
        UserName: $('#username').val(),
        Email: $('#email').val(),
        Telephone: $('#phonenumber').val(),
        Address: $('#address').val(),
        Avatar: $('#image2').val(),
        DateOfBirth: $('#dateofbirth').val(),
        Gender: $("input[name='gender']:checked").val() == 'male' ? 1 : 0
    }
    console.log('data: ', data);
    $.ajax({
        url: "/Account/Update",
        type: 'POST',
        data: data,
        dataType: 'json',
        //  contentType: false,
        //  processData: false,
        success: function (data) {
            console.log('data return: ', data);
            if (data.ret >= 0) {
                swal({
                    title: 'Thành công',
                    text: 'Cập nhật tài khoản thành công',
                    type: 'success',
                    timer: 1500
                }).then(function () {
                    window.location.reload();
                });
            } else {
                swal({
                    title: 'Thất bại',
                    text: 'Lỗi ghi dữ liệu',
                    type: 'error',
                    timer: 1500
                });
            }
        }.bind(this)
    })
        .done(function () {
            console.log("xong roi");
            //$(this).addClass("done");
        });
};
function convertDate(date) {
    var today = new Date(date);
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    var today = dd + '/' + mm + '/' + yyyy;
    return today;
}
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
    $('.date').datetimepicker({
        format: 'DD/MM/YYYY',
        keepInvalid: true
    });
    //$("#SoLuong").spinner({
    //    min: 1,
    //    max: 100,
    //    step: 1
    //});
    $("#input-image2").change(function (e) {
        readURL2(this);
    });
    $("#uploadImage2").on('click',
        function() {
            $('#input-image2').trigger('click');
        });
    $('#btnUpdate').on('click',
        function() {
            var data = new FormData();
            var files = $("#input-image2")[0].files[0];
            if (files != null ) {
                data.append('file', $("#input-image2")[0].files[0]);
                console.log('data: ', data);
                $.ajax({
                        url: "/Upload/UploadFile2",
                        type: "POST",
                        //   data: JSON.stringify(data),
                        data: data,
                        contentType: false,
                        processData: false,
                        success: function(data) {
                            console.log(data.sussess);
                            if (data.sussess >= 0) {
                                $("#image2").val(data.filename);
                                updateAcc();
                            }
                        }.bind(this)
                    })
                    .done(function() {
                        console.log("xong roi");
                        //$(this).addClass("done");
                    });
            } else {
                updateAcc();
            }
        });
    $('.detailsAcc').on('click',
        function() {
            var accountId = $(this).data("id");
            var data = {
                accountId: accountId
            };
            
            console.log('data sent: ', data);
            var postData = JSON.stringify(data);
            console.log('postData: ', postData);

            $.ajax({
                url: "/Account/GetAccount",
                    type: 'POST',
                    data: {
                        accountId: accountId
                    },
                    dataType: 'json',
                    //  contentType: false,
                    //  processData: false,
                    success: function (data) {
                        console.log('data return: ', data);
                        if (data.ret >= 0) {
                            
                            console.log('data ok: ', data.obj);
                            console.log('data ok: ', data.obj["Name"]);
                            $('#accountId').val(data.obj.ID);
                            $('#name').val(data.obj.Name);
                            $('#username').val(data.obj.UserName);
                            $('#email').val(data.obj.Email);
                            $('#address').val(data.obj.Address);
                            $('#phonenumber').val(data.obj.Telephone);
                            $('#image2').val(data.obj.Avatar);
                            $('#dateofbirth').val(convertDate(data.obj.DateOfBirth));
                            $('#img-avatar').attr('src', data.obj.Avatar);
                            if (data.obj.Gender == 1) {
                                $("input[name=gender][value=male]").prop('checked', true);
                            } else
                                $("input[name=gender][value=female]").prop('checked', true);
                        } else {
                            
                        }
                    }.bind(this)
                })
                .done(function () {
                    console.log("xong roi");
                    //$(this).addClass("done");
                });
        });

    $('#btnSignUp').on("click", function () {
        if ($("#username").val() == "") {
            swal({
                title: 'Thất bại',
                text: 'Chưa điền tên tài khoản',
                type: 'error',
                timer: 1500
            }).then(function () {
                $("#username").focus();
                return;
            });
        } else
            if ($("#email").val() == "") {
                swal({
                    title: 'Thất bại',
                    text: 'Chưa điền email',
                    type: 'error',
                    timer: 1500
                }).then(function () {
                    $("#email").focus();
                    return;
                });
            } else
                if ($("#password").val() == "") {
                    swal({
                        title: 'Thất bại',
                        text: 'Chưa điền mật khẩu',
                        type: 'error',
                        timer: 1500
                    }).then(function () {
                        $("#password").focus();
                        return;
                    });
                } else
                    if ($("#passwordconfirm").val() == "") {
                        swal({
                            title: 'Thất bại',
                            text: 'Chưa nhập lại mật khẩu',
                            type: 'error',
                            timer: 1500
                        }).then(function () {
                            $("#passwordconfirm").focus();
                            return;
                        });
                    } else
                        if ($("#passwordconfirm").val() != $("#password").val()) {
                            swal({
                                title: 'Thất bại',
                                text: 'Mật khẩu không trùng nhau',
                                type: 'error',
                                timer: 1500
                            }).then(function () {
                                $("#password").focus();
                                return;
                            });
                        } else {
                            $.ajax({
                                url: "/Account/Register",
                                dataType: 'json',
                                data: {
                                    username: $('#username').val(),
                                    email: $('#email').val(),
                                    password: $('#password').val()
                                },
                                method: 'post',
                                success: (data) => {
                                    console.log('data: ', data);
                                    if (data.ret > 0) {
                                        window.location.href = '/Account/Login'
                                    } else {
                                        if (data.ret = -100) {
                                            swal({
                                                title: 'Thất bại',
                                                text: 'Tên tài khoản không khả dụng',
                                                type: 'error',
                                                timer: 1500
                                            }).then(function() {
                                                $('#username').focus();
                                                return;
                                            });

                                        } else {
                                            swal({
                                                title: 'Thất bại',
                                                text: 'Lỗi ghi dữ liệu',
                                                type: 'error',
                                                timer: 1500
                                            }).then(function () {
                                                return;
                                            });
                                        }
                                    }
                                },
                                error: (xhr, status, err) => {
                                    console.log(err.toString());
                                }
                            });
                        }


    });
    $('.delAcc').on('click',
        function() {
            var accountId = $(this).data("id");
            swal({
                title: 'Xóa tài khoản?',
                text: "Bạn sẽ không có khả năng khôi phục!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Xóa',
                cancelButtonText: 'Hủy'
            }).then(function (result) {
                if (result.value) {
                    $.ajax({
                            url: "/Account/Delete",
                            type: 'POST',
                            data: {
                                accountId: accountId
                            },
                            dataType: 'json',
                            //  contentType: false,
                            //  processData: false,
                            success: function (data) {
                                console.log('data return: ', data);
                                if (data.ret >= 0) {
                                    // location.reload();
                                    swal({
                                            title: 'Thành công',
                                            text: 'Cập nhật thành công',
                                            type: 'success',
                                            timer: 1500
                                        }).then(function () {
                                            window.location.reload();
                                        });
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
                }
            });
        });
    

    $('.changeRole').on('change',
        function() {
            var accountId = $(this).data("id");
            var roleId = $(this).val();
            var data = {};
            data.accountId = accountId;
            data.roleId = roleId;
            console.log('data: ', data);
            $.ajax({
                    url: "/Account/ChangeRole",
                    type: 'POST',
                    data: data,
                    dataType: 'json',
                    //  contentType: false,
                    //  processData: false,
                    success: function (data) {
                        console.log('data return: ', data);
                        if (data.ret >= 0) {
                            // location.reload();
                            swal({
                                    title: 'Thành công',
                                    text: 'Cập nhật thành công',
                                    type: 'success',
                                    timer: 1500
                                }

                                //).then(function () {
                                //    window.location.reload();}
                            );
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
    function readURL2(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#img-avatar').attr('src', e.target.result);
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

    $('#uploadImage').on('click',
        function() {
            $("#input-image").trigger('click');
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
                        swal({
                                title: 'Thành công',
                                text: 'Thêm vào giỏ hàng thành công',
                                type: 'success',
                                timer: 1500
                            }

                        ).then(function () {
                            window.location.reload();
                        });
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

        if (data.Name == "") {
            swal({
                title: 'Thất bại',
                text: 'Chưa nhập tên người nhận',
                type: 'error',
                timer: 1500
            });
            $('#name').focus();
            return;
        }
        if (data.Email == "") {
            swal({
                title: 'Thất bại',
                text: 'Chưa nhập email',
                type: 'error',
                timer: 1500
            });
            $('#email').focus();
            return;
        }
        if (data.Telephone == "") {
            swal({
                title: 'Thất bại',
                text: 'Chưa nhập số điện thoại',
                type: 'error',
                timer: 1500
            });
            $('#phone').trigger("focus");
            return;
        }
        if (data.Address == "") {
            swal({
                title: 'Thất bại',
                text: 'Chưa nhập địa chỉ',
                type: 'error',
                timer: 1500
            });
            $('#email').focus();
            return;
        }

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
                            swal({
                                    title: 'Thành công',
                                    text: 'Cập nhật thành công',
                                    type: 'success',
                                    timer: 1500
                                }

                            //).then(function () {
                            //    window.location.reload();}
                            );
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