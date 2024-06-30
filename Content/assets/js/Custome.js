$("#badgeItemCount").html(getCookie('CartItemCountValue'));
$(document).on('click', '#btnAddToCart', function (event) {
    alert('hi');
    $('.spinner').css('display', 'block');
    let productID = $(this).attr('leadIdAttr');
    if (productID == null || productID == undefined) {
        return false;
    }
    var DataItem = { LeadId: productID };
    $.ajax({
        type: 'POST',
        url: "/home/AddCartItem/",
        contentType: 'application/json; charset=utf-8',
        async: true,
        dataType: "html",
        data: JSON.stringify(DataItem),
        processData: false,
        success: function (data) {
            var datame = JSON.parse(data);
            if (datame == -1) {
                $('.spinner').css('display', 'none');
                swal({
                    title: "Warning",
                    text: "This lead already added in Cart",
                    timer: 2000,
                    showConfirmButton: true
                });
            }
            else if (datame >= 1) {
                setCookie('CartItemCountValue', datame, 15);
                $("#badgeItemCount").html(datame);
                $('.spinner').css('display', 'none');
            }
        }
    });
});

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}