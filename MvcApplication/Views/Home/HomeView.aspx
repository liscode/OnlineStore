<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.Home>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Title Home View
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Content HomeView</h2> 
    
    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
       <img src="../../Css/Images/Flowers/flower.jpg" alt="flower">
      <div class="carousel-caption">
       זרי פרחים מיוחדים
      </div>
    </div>
    <div class="item">
      <img src="../../Css/Images/Bouquets/Bouquets3.png" alt="flower">
      <div class="carousel-caption">
        עציצים נבחרים
      </div>
    </div>
       <div class="item">
      <img src="../../Css/Images/Sweet/sweet.jpg" alt="flower">
      <div class="carousel-caption">
        זרים מתוקים
      </div>
    </div>
  </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
   </div>
</asp:Content>
