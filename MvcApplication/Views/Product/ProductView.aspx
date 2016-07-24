<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Products
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="jsContent" runat="server">   
    <%--<script src="https://fb.me/react-15.2.1.js"></script>
    <script src="https://fb.me/react-dom-15.2.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/babel-core/5.8.34/browser.min.js"></script>
    <script type="text/babel" src="/Scripts/product_react.js"></script>--%>
    <script src="/Scripts/product.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="products">
    </div>

    <%-- Remove if using react --%>
    <div class="moredetails">
        <a href="#" class="btnMoreItems" role="button">More items</a>
    </div>    
    <%-- Remove if using react --%>
    <div id="cat" hidden><%= Model.Cat %></div>
    <div id="subcat" hidden><%= Model.SubCat %></div>
                       

</asp:Content>


