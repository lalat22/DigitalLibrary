<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="AddPublication.aspx.cs" Inherits="DigitalLibrary.AddPublication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card text-center" style="width: 1201px; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>Add Publication</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(145, 209, 208);">

            <div class="form-row" style="margin-left: 500px;">
                <div class="form-group col-sm-3">

                    <h5>Publication Name<em style="color: Red">*</em>  </h5>
                    <asp:TextBox ID="txtPublicationName" runat="server" class="form-control" placeholder="Publication Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPublication" runat="server"
                        ControlToValidate="txtPublicationName" ErrorMessage="Publication Name is required." ForeColor="Red"
                        SetFocusOnError="True" ValidationGroup="submit"></asp:RequiredFieldValidator>
                </div>

            </div>

            <div>
                <asp:Button ID="btnSave" data-bs-toggle="modal" class="btn btn-primary btn-lg btn3d" runat="server" Text="Add" OnClick="btnSave_Click" ValidationGroup="submit" Style="margin-left: -5px; margin-top: 7px;" />
                <asp:Button ID="btnCancle" runat="server" Text="Cancle" OnClick="btnCancle_Click" class="btn btn-danger btn-lg btn3d" Style="margin-left: 17px; margin-top: 7px;" />
            </div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <div style="width: 568px; margin-left: 288px;">
                <asp:GridView ID="gvPublication" runat="server" class="table align-middle mb-0 bg-white" AlternatingRowStyle-BackColor="#99ccff" AutoGenerateColumns="False" CellPadding="6" OnRowCommand="gvPublication_RowCommand"
                    OnRowEditing="gvPublication_RowEditing" OnRowDeleting="gvPublication_RowDeleting" OnPageIndexChanging="gvPublication_PageIndexChanging" AllowPaging="true" PageSize="5" PagerStyle-CssClass="paging">
                    <Columns>
                        <asp:TemplateField HeaderText="Publication Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPublication" runat="server" Text='<%#Eval("PublicationName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="edit" CommandArgument='<%#Eval("PublicationId") %>'> <span class="fa fa-pencil fa-fw"></span></asp:LinkButton>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#Eval("PublicationId") %>'><span class="fa fa-trash-o"></span></asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <HeaderStyle BackColor="#298ca3" ForeColor="#ffffff" />
                    <RowStyle BackColor="#e7ceb6" />

                    <PagerStyle HorizontalAlign="Center" />
                    <PagerTemplate>
                        <ul class="pagination">
                            <asp:Repeater ID="Pager" ItemType="System.Int32" SelectMethod="GetPages" runat="server">
                                <ItemTemplate>
                                    <li class='<%#((int)Item == this.gvPublication.PageIndex+1)? "active" : "" %>'>
                                        <asp:LinkButton CommandName="Page" ID="lnkPaging" CommandArgument="<%# Item %>"
                                            Text="<%# Item %>" runat="server" OnClick="lnkPaging_Click" />
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </PagerTemplate>


                </asp:GridView>

            </div>



        </div>
        <!-- Modal HTML -->
        <div id="myModal" class="modal fade" style="margin-left: 105px; margin-top: 168px;">
            <div class="modal-dialog modal-confirm">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="icon-box">
                            <i class="material-icons">&#xE876;</i>
                        </div>
                        <h4 class="modal-title w-100">Awesome!</h4>
                    </div>
                    <div class="modal-body">

                        <p class="text-center" id="pContent"><%=successMsg%></p>
                    </div>
                    <div class="modal-footer">
                        <%--<button class="btn btn-success btn-block" data-dismiss="modal">OK</button>
                        <button class="btn btn-success btn-block" onclick="closepopup">OK</button>--%>
                        <asp:Button ID="btnClose" class="btn btn-success btn-block" runat="server" Text="Ok" OnClientClick="closepopup" />
                    </div>
                </div>
            </div>
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
        function showmodel() {

            $("#myModal").modal('show');
        }
        function closepopup() {
            $("#myModal").modal('hide');
        }

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
