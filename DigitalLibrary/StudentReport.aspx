<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="StudentReport.aspx.cs" Inherits="DigitalLibrary.StudentReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card text-center" style="width: 95%; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>Student Report</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(145, 209, 208);">
                <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table class="tbl">
                        <tr>
                            <td class="tblhead">
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--gridvew--%>
                                <div style="width: 568px; margin-left: 213px;">
                                    <asp:GridView ID="gvStudentReport" runat="server" class="table align-middle mb-0 bg-white" AlternatingRowStyle-BackColor="#99ccff" AutoGenerateColumns="False" CellPadding="6" OnRowCommand="gvStudentReport_RowCommand"
                                        OnRowEditing="gvStudentReport_RowEditing" OnRowDeleting="gvStudentReport_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Branch">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Actions">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkView" runat="server" CommandName="view" CommandArgument='<%#Eval("StudentId") %>'> <span class="fa fa-eye"></span></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#Eval("StudentId") %>'><span class="fa fa-trash-o"></span></asp:LinkButton>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                        <HeaderStyle BackColor="#298ca3" ForeColor="#ffffff" />
                                        <RowStyle BackColor="#e7ceb6" />
                                    </asp:GridView>
                                    

                                </div>
                              <asp:Label ID="lblDelete" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <section style="background-color: #eee;">
                        <div class="container py-5">


                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="card mb-4">
                                        <div class="card-body text-center" style="margin-top: 0px;height:191px; background-image: url('../Images/Frame.jfif');" >
                                            <%-- <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp" alt="avatar"
                                                class="rounded-circle img-fluid" style="width: 150px;">--%>
                                            <asp:Image ID="Image2" runat="server" class="img-thumbnail" Style="width: 189px;" />
                                            <h5 class="my-3">
                                                <asp:Label ID="lblProfileBook" runat="server"></asp:Label></h5>
                                            <p class="text-muted mb-1">
                                                <asp:Label ID="lblProfileAuthor" runat="server"></asp:Label></p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <div class="card mb-4">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">Student Name</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lblbStudentName" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">Mobile</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lblphn" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                            <hr>
                                             <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">Address</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">PinCode</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lblPinCode" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">Branch</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lblBranch" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                            <hr>
                                           
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">Birth Date</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                            <hr />
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">Email</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div>
                                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Images/undo.png" Width="30px" Height="30px" ToolTip="Back" OnClick="btnBack_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </asp:View>
            </asp:MultiView>

        </div>
         <!----Delete modal starts here--->
        <div id="DeleteModal" class="modal fade" role='dialog'>
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" onclick="closeDeletepopup()" aria-hidden="true">&times;</button>
                        <%--<h4 class="modal-title">Delete </h4>--%>
                    </div>
                    <div class="modal-body">
                        <p>Do You Really Want to Delete This ?</p>

                    </div>
                    <div class="modal-footer">
                        <%--<button type="button" class="btn btn-secondary" onclick="closeDeletepopup()">Cancel</button>--%>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancle" class="btn btn-secondary" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" OnClick="btnDelete_Click" />
                    </div>

                </div>
            </div>
        </div>
        <!-- Delete Modal ends here--->

        <%--Error Popup--%>
        <div class="popup" id="error" style="display: none;">
            <div class="popup-content">
                <div class="modal-header">
                    <button type="button" class="close" onclick="closeErrorpopup()" aria-hidden="true">&times;</button>
                    <%--<h4 class="modal-title">Delete </h4>--%>
                </div>
                <div class="imgbox">
                    <img src="../Images/cancel.png" alt="" class="img">
                </div>
                <div class="title">
                    <h3>Sorry :(</h3>
                </div>
                <p class="para">Something went wrong. Please try again!</p>
            </div>
        </div>
        <div class="card-footer text-muted" style="background-color: #0b3355;">
        </div>
    </div>

     <script type="text/javascript">
       

        function showDeletepopup() {

            $("#DeleteModal").modal('show');
        }
        function closeDeletepopup() {
            $("#DeleteModal").modal('hide');
        }
        function showErrorpopup() {

            var x = document.getElementById("error");
            if (x.style.display === "none") {
                x.style.display = "block";
            } else {
                x.style.display = "none";
            }
        }
        function closeErrorpopup() {

            var x = document.getElementById("error");
            if (x.style.display === "none") {
                x.style.display = "block";
            } else {
                x.style.display = "none";
            }
        }
     </script>
</asp:Content>
