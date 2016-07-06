<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.SignUp>" %>

<%--<link href="/Css/StyleSheet.css" rel="stylesheet" />--%>
<%--<form class="contact_form" action="" method="post" name="contact_form">
</form>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Sign up !
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="jsContent" runat="server">
    <script src="/Scripts/signUp.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="signup">

        <h2>Sign up</h2>

        <form class="contact_form" autocomplete="off" id="contact_form" method="post" action="/Login/Submit">
            <p>
                <input id="fname" name="firstName" type="text" placeholder="Your First Name" required>
            </p>
            <p>
                <input id="lname" name="lastName" type="text" placeholder="Your Last Name" required>
            </p>
            <p>                
                <input id="cemail" type="email" name="email" placeholder="Your E-Mail" required>                                        
            </p>
            <p>
                <input id="pass" name="password" type="password" placeholder="Your Password" required>
            </p>
            <p>
                <input class="submit" type="submit" value="Add Me Now">
            </p>
        </form>
          
    </div>
</asp:Content>
