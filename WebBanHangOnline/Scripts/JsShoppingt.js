$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var tQuantity = $("#quantity_value").text();
        //console.log("số lượng " + tQuantity);
        if (tQuantity != '') {
            quantity = parseInt(tQuantity);
        }
        //alert(id + " " + quantity);
        $.ajax({
            url: "/shoppingcart/addtocart",
            type: "POST",
            data: { id: id, quantity: quantity },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.Count)
                    alert(rs.msg)

                }
            }
        });
    });

    $('body').on('click', '.btnDelete', function (e) {
         //e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm("Bạn có  xoá sản phẩm này không?");
        if (conf === true) {
            $.ajax({
                url: "/shoppingcart/Delete",
                type: "POST",
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.Count)
                        $('#trow_' + id).remove();
                        LoadData();
                    }
                }
            });
        }

    });
    $('body').on('click', '.btnUpdate', function (e) {
        var id = $(this).data('id');
        var quantity = $('#Quantity_'+id).val();
        Update(id, quantity);

    });
    $('body').on('click', '.btnDeleteAll', function (e) {
        //e.preventDefault();
        var conf = confirm("Bạn có muốn xoá tất cả sản phẩm này không?");
        if (conf === true) {
            $.ajax({
                url: "/shoppingcart/DeleteAll",
                type: "POST",
                success: function (rs) {
                    if (rs.Success) {
                        //$('#checkout_items').html(rs.Count)
                        LoadData();
                        alert("Bạn đã Xoá Tất cả sản phẩm trong giỏ hàng thành công!")
                       
                    }
                }
                
            });
        }

    });
});
function ShowCount() {
    $.ajax({
        url: "/shoppingcart/showcount",
        type: "GET",
        success: function (rs) {

             $('#checkout_items').html(rs.Count)
        }
    });
}
function LoadData() {
    $.ajax({
        url: "/shoppingcart/patial_view_cart",
        type: "GET",
        success: function (rs) {
            $('#load-data').html(rs)
        }
    });
}

function Update(id ,quantity) {
    $.ajax({
        url: "/shoppingcart/Update",
        type: "POST",
        data: { id: id, quantity: quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadData();
                alert("Cập Nhật Số Lượng Thành Công!")
            }
        }
    });
}