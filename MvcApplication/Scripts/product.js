$(function () {

    var image = '<div class="image"><img src="{0}" class="imagepro" alt="flower" /></div>';
    var name = '<div class="namepro"><b>{1}</b></div>';
    var price = '<div class="pricepro"><b>{2}</b></div>';
    var productNamePrice = '<div class="namePriceProduct">' + name + price + '</div>';
    var btnMoreDetails = '<div class="btnmoredetails"><a href="#" class="btn btn-primary btnmoredetails" role="button">more details</a></div>';
    var product = '<div class="product">' + image + productNamePrice + btnMoreDetails + '</div>';


    var allProducts = '<div><div class="productLeft">{0}</div><div class="productMiddle">{1}</div><div class="productRight">{2}</div></div>';

    // Gets cat&subCat from hidden input
    var strCat = document.getElementById("cat").innerHTML;
    var strSubCat = document.getElementById("subcat").innerHTML;
    var minRowVar = 1;
    var maxRowVar = 3;
    AddItems();

    function AddItems() {
        // Set Product type Json object to send to the server
        var objJson = { categoryName: strCat, subCategoryName: strSubCat, minRow: minRowVar, maxRow: maxRowVar };

        //jquery ajax call
        $.ajax({
            type: "POST",//post/get
            url: "/Product/SelectProduct",// Location of the service
            data: objJson, //Data sent to server
            dataType: "json", //Expected data format from server
            success: function (result) {
                //להמיר את התשובה מסיטרינג גייסון לאובייקט גייסון           
                var listProducts = [];
                result.map(function (row) {
                    var newProduct = String.format(product, row.Url, row.ProductName, row.Price);
                    listProducts.push(newProduct);
                });

                if (listProducts[0] == undefined)
                {
                    listProducts[0] = '';
                    $('.btnMoreItems').remove();
                }

                if (listProducts[1] == undefined) {
                    listProducts[1] = '';
                    $('.btnMoreItems').remove();
                }

                if (listProducts[2] == undefined) {
                    listProducts[2] = '';
                    $('.btnMoreItems').remove();
                }
                var allProductsFinal = String.format(allProducts, listProducts[0], listProducts[1], listProducts[2]);
                $('#products').append(allProductsFinal);
                minRowVar = minRowVar + 3;
                maxRowVar = maxRowVar + 3;
            }
        });
    }

    $('.btnMoreItems').click(function () {
        AddItems();
        return false;
    });


    String.format = function () {
        var s = arguments[0];
        for (var i = 0; i < arguments.length - 1; i++) {
            var reg = new RegExp("\\{" + i + "\\}", "gm");
            s = s.replace(reg, arguments[i + 1]);
        }
        return s;
    }
});