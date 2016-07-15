<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ProductView
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="jsContent" runat="server">    
    <script src="https://fb.me/react-15.2.1.js"></script>
    <script src="https://fb.me/react-dom-15.2.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/babel-core/5.8.34/browser.min.js"></script>
    <script type="text/babel" src="/Scripts/product.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>&nbsp;ProductView</h2>

    <div id="products" class="rowPro">
       <%-- <div class="productleft">
            <div class="product">
                <div class="image">
                    <img src="\Images\FileWebSitePhotos\Flowers\flowerChai.jpg" class="imagepro" alt="flower">
                </div>
                <div class="nameProduct">
                    <div class="left">
                        <b>Chai</b>
                    </div>
                    <div class="right">
                        <b>94 NIS</b>
                    </div>
                </div>
                <div class="btnmoredetails">
                    <a href="#" class="btn btn-primary btnmoredetails" role="button">more details</a>
                </div>
               </div>
            </div>
          <div class="productmiddle">
            <div class="product">
                <div class="image">
                    <img src="\Images\FileWebSitePhotos\Flowers\flowerVelvet.jpg" class="imagepro" alt="flower">
                </div>
                <div class="nameProduct">
                    <div class="left">
                        <b>Velvet</b>
                    </div>
                    <div class="right">
                        <b>104 NIS</b>
                    </div>
                </div>
                <div class="btnmoredetails">
                    <a href="#" class="btn btn-primary btnmoredetails" role="button">more details</a>
                </div>
               </div>
            </div>
          <div class="productright">
            <div class="product">
                <div class="image">
                    <img src="\Images\FileWebSitePhotos\Flowers\flowerAnise.jpg" class="imagepro" alt="flower">
                </div>
                <div class="nameProduct">
                    <div class="left">
                        <b>Anise</b>
                    </div>
                    <div class="right">
                        <b>120 NIS</b>
                    </div>
                </div>
                <div class="btnmoredetails">
                    <a href="#" class="btn btn-primary btnmoredetails" role="button">more details</a>
                </div>
               </div>
            </div>--%>
        </div>
    

</asp:Content>


