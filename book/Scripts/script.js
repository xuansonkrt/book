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
});