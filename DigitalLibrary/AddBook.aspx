<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="DigitalLibrary.AddBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card text-center" style="width: 1201px; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>Add New Book</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(145, 209, 208);">
            <div style="margin-left: 373px;">
                <table>
                    <tr>
                        <td>Book Name<em id="mandatory" style="color: Red">*</em> : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtBookName" runat="server" class="form-control" placeholder="Book Name"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvBookName" runat="server"
                                ControlToValidate="txtBookName" ErrorMessage="Book name is required." ForeColor="Red"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Details : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtDetails" runat="server" class="form-control" placeholder="Details"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Author<em style="color: Red">*</em> : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtAuthor" runat="server" class="form-control" placeholder="Author"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvAuthor" runat="server"
                                ControlToValidate="txtAuthor" ErrorMessage="Author is required." ForeColor="Red"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Publication : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPublication" runat="server" class="form-control" DataValueField="PublicationId" DataTextField="PublicationName"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Branch : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBranch" runat="server" class="form-control" DataValueField="BranchId" DataTextField="BranchName"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Price<em style="color: Red">*</em> : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtPrice" runat="server" class="form-control" placeholder="Price"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPrice" runat="server"
                                ControlToValidate="txtAuthor" ErrorMessage="Price is required." ForeColor="Red"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Quantity<em style="color: Red">*</em> : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtQuantity" runat="server" class="form-control" placeholder="Quantity"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvQuantity" runat="server"
                                ControlToValidate="txtQuantity" ErrorMessage="Quantity is required." ForeColor="Red"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Book Photo : 
                        </td>
                        <td>
                            <asp:FileUpload ID="fuBook" runat="server" class="form-control" />
                        </td>
                    </tr>

                </table>

            </div>
            <div>
                <asp:Button ID="btnAddBook" runat="server" Text="Add Book" OnClick="btnAddBook_Click" class="btn btn-primary btn-lg btn3d" Style="margin-left: -5px; margin-top: 18px;" />
                <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>



        </div>


          <!-- Modal HTML -->
        <div id="myModal" class="modal fade" style="margin-left: 105px;margin-top: 168px;">
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


        
     </script>
</asp:Content>
