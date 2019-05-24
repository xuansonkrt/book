var state= {
    lst: [],
    total:0
};
function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
}
function setTable() {
    $('#table-body').empty();
    state.total = 0;
    for (var i = 0; i < state.lst.length; i++) {
        state.total += state.lst[i].Price * state.lst[i].Amount;
        $('#table-body').append(
            "<tr> " +
            "<td>"+(i+1)+"</td>" +
            "<td>" + state.lst[i].Name + "</td>" +
            "<td>" + state.lst[i].Amount + "</td>" +
            "<td style='text-align:right'>" + formatNumber(state.lst[i].Price) + "đ</td>" +
            "<td style='text-align:right'>" + formatNumber(state.lst[i].Price * state.lst[i].Amount) + "đ</td>" +
            "</tr>"
            );
        $('#totalPrice').text(formatNumber(state.total) + 'đ');
    }
}


$(document).ready(function () {
    $('#btnThem').on('click', function() {
        $('#table-body').empty();
        $('#table-body').append("<tr><td colspan='5'></td></tr>");
        $('#bookid').val("");
        $('#book').val("");
        $('#amount').val("");
        $('#price').val("");
        $('#totalPrice').text("0đ");
    })
    $('.btnDetails').on('click',
        function() {
            var id = $(this).data("id");
            $.ajax({
                    url: "/WareHouse/GetDetail",
                    type: 'POST',
                    data: {
                       id:id
                    },
                    dataType: 'json',
                    //  contentType: false,
                    //  processData: false,
                    success: function (data) {
                        console.log('data return: ', data);
                        if (data.ret >= 0) {
                            console.log('lst: ', data.lst);
                            state.lst = data.lst;
                            setTable();
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
        });
    $('#btnGhiNhan').on('click',
        function() {
            var lst = state.lst;
            console.log('data sent: ', lst);
            console.log('state sent: ', state.total);
            $.ajax({
                    url: "/WareHouse/Add",
                    type: 'POST',
                    data: {
                        lst: lst,
                        totalPrice: state.total
                    },
                    dataType: 'json',
                    //  contentType: false,
                    //  processData: false,
                    success: function (data) {
                        console.log('data return: ', data);
                        if (data.ret >= 0) {
                            swal({
                                title: 'Thành công',
                                text: 'Nhập thành công',
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
        });
    $('#book').autocomplete({
        open: function () {
            setTimeout(function () {
                $('.ui-autocomplete').css('z-index', 99999999999999);
            },
                0);
        },
        select: function (event, ui) {
            console.log("select: ", ui);    
            $('#bookid').val(ui.item.id);
            //                $('#NAME').val(ui.item.name);
            //                $("#CLASSNAME").text(ui.item.idview);
            //                $("#CLASS").text(ui.item.idview);
            //                $("#COURSECODE").text(ui.item.id);
            //  $('#lbl').text(ui.item.label);
        },
        source: function (request, response) {
            //                console.log("call: " + request.term);
            //  $('#lbl').text('');
            // $("#STAFFCODE").val('');
            var data = {
                keyword: $('#book').val()

            };
            request = $.ajax({
                url: "/Book/GetAllSearch",
                timeout: 6000,
                data: data,
                dataType: "json",
                type: "POST",
                //   contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    console.log("result: ", data);
                    response($.map(data.lst,
                        function (item) {
                            return {
                                label: item.Name, //+ "-" + item.NAME,
                                name: item.Name,
                                id: item.ID,
                              }
                        }));
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //alert(textStatus);
                    if (textStatus === 'timeout') {
                        request.abort();
                        alert('Không tìm thấy sách');

                    }
                }
            });
        },
        minLength: 1
    });

    $('#btnNhap').on('click',
        function() {
            var obj = {};
            obj.ID = $('#bookid').val();
            obj.Name = $('#book').val();
            obj.Amount = $('#amount').val();
            obj.Price = $('#price').val();
            if (obj.ID == "" || obj.Name == "" || obj.Amount == "" | obj.Price == "")
                return;
            else {
                state.lst.push(obj);
                setTable();
            }
        });
});