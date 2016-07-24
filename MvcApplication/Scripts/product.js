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
    // Set Product type Json object to send to the server
    var objJson = { categoryName : strCat, subCategoryName: strSubCat, minRow: 1, maxRow: 3};
   
    //var data = [
    //            { Url: "\Images\FileWebSitePhotos\Flowers\flowerSpring.jpg", ProductName: "chai", Price: "94 nis", ID: "1" },
    //            { Url: "\Images\FileWebSitePhotos\\Flowers\flowerVelvet.jpg", ProductName: "velvet", Price: "104 nis", ID: "2" },
    //            { Url: "\Images\FileWebSitePhotos\Flowers\flowerAnise.jpg", ProductName: "Anise", Pri ce: "120 nis", ID: "3" }
    //];

    //jquery ajax call
    $.ajax({
        type: "POST",
        url: "/Product/SelectProduct",// Location of the service
        data: objJson, //Data sent to server
        dataType: "json", //Expected data format from server
        success: function(result) {
            //להגדיר מה קורה כאשר יש לי הצלחה!!!!!!!!!
            //אלו המוצריםוכעת צריך להציג אותם
            //להמיר את התשובה מסיטרינג גייסון לאובייקט גייסון
                 
                var listProducts = [];
                result.map(function (row) {
                    var newProduct = String.format(product, row.Url, row.ProductName, row.Price);
                    listProducts.push(newProduct);
                });

                var allProductsFinal = String.format(allProducts, listProducts[0], listProducts[1], listProducts[2]);
                $('#products').append(allProductsFinal);
            }        
    });

    $('.btnMoreItems').click(function () {
        objJson = { categoryName: strCat, subCategoryName: strSubCat, minRow: (minRow+3), maxRow: (maxRow+3) };

    });
           
});

String.format = function () {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }
    return s;
}