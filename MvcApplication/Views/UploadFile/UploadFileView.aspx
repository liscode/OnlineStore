<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.UploadFile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Upload File
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="jsContent" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/dropzone/4.3.0/min/dropzone.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/dropzone/4.3.0/min/dropzone.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/list.js/1.2.0/list.min.js"></script>
    <script src="http://listjs.com/no-cdn/list.js"></script>
    <script src="/Scripts/uploadFile.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Upload File</h2>

    <div class="jumbotron">
        <div id="files" class="files-list">

            <input class="search" placeholder="Search" />
            <button class="sort" data-sort="name">Sort by name</button>
            <button class="sort" data-sort="size">Sort by size</button>
           
            <table class="firstlist">
                <tr>
                    <th class="name">Name</th>
                    <th class="size">Size</th>
                </tr>
                <tbody class="list">                   
                     <%foreach (var file in Model.Files){%>
                        <tr>
                            <td class="name"><%=file.Name %> </td>
                            <td class="size"><%=file.Size %></td>
                        </tr>
                    <%  } %>
                </tbody>
            </table>
            
        </div>
        <%-- ניגש לשם הקונטרולר/שם הפונקציה --%>
        <form class="dropzone" id="dropzoneForm" enctype="multipart/form-data" method="post" action="/UploadFile/Upload">
            <p>Please Upload File:</p>
            <div class="fallback">
                <input type="file" name="file" multiple />
                <input type="submit" value="Upload" />    
            </div>
        </form>
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">The upload is not support</h4>
                            </div>
                            <div class="modal-body">
                                <p>Please close and try again layter.</p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
    </div>
</asp:Content>



