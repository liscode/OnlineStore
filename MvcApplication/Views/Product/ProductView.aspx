<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ProductView
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="jsContent" runat="server">
    <script src="/Scripts/product.js"></script>
    <%--Add react.js script--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>ProductView</h2>

 <div class="row">
  <div class="col-sm-6 col-md-4">
    <div class="thumbnail">
      <img src="../../Css/Images/flower.png" alt="flower">
      <div class="caption">
        <h3>Thumbnail label</h3>
        <p>...</p>
        <p><a href="#" class="btn btn-primary" role="button">See in full page</a> <a href="#" class="btn btn-default" role="button">Add To Bag</a></p>
      </div>
    </div>
  </div>
 </div>

</asp:Content>


