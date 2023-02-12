<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="DigitalLibrary.AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card text-center" style="width: 95%; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>Add Student Details</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(145, 209, 208);">
            <div style="margin-left: 298px;">
                <table>
                    <tr>
                        <td>Student Name<em id="mandatory" style="color: Red">*</em> : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtStudentName" runat="server"  class="form-control" placeholder="Student Name"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvStudentName" runat="server" ValidationGroup="Save"
                                ControlToValidate="txtStudentName" ErrorMessage="Student name is required." ForeColor="Red"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>BranchName<em style="color: Red">*</em> :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBranch" runat="server" class="form-control" DataValueField="BranchId" DataTextField="BranchName"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Gender<em style="color: Red">*</em> :
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblGender" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblGender_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                <asp:ListItem Value="Male" Text="&nbsp;&nbsp;Male"></asp:ListItem>
                                <asp:ListItem Value="Female" Text="&nbsp;&nbsp;Female"></asp:ListItem>

                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>DOB<em style="color: Red">*</em> :
                        </td>
                        <td>

                            <asp:TextBox ID="txtDOB" runat="server" ReadOnly="true" CssClass="form-control pull-right datePicker" placeholder="dd-MM-yyyy"></asp:TextBox>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkDate" runat="server" OnClick="lnkDate_Click" Style="margin-left: -149px;" ValidationGroup="link"><span class="fa fa-calendar" style="font-size:30px;"></span></asp:LinkButton>
                            <div class="overlay" style="position: absolute; top: 191px; z-index: 10;">
                                <asp:Calendar ID="Calendar1" runat="server"
                                    OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Mobile<em style="color: Red">*</em> : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Mobile"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ValidationGroup="Save"
                                ControlToValidate="txtMobile" ErrorMessage="Mobile is required." ForeColor="Red"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Address<em style="color: Red">*</em> : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ValidationGroup="Save"
                                ControlToValidate="txtAddress" ErrorMessage="Address is required." ForeColor="Red"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>PinCode<em style="color: Red">*</em> : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtPinCode" runat="server" class="form-control" placeholder="PinCode"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ValidationGroup="Save"
                                ControlToValidate="txtPinCode" ErrorMessage="Pin code is required." ForeColor="Red"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Photo : 
                        </td>
                        <td>
                            <asp:FileUpload ID="fuStudent" runat="server" class="form-control" />
                        </td>
                    </tr>
                    <tr>
                        <td>Email<em style="color: Red">*</em> : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ValidationGroup="Save"
                                ControlToValidate="txtEmail" ErrorMessage="Email is required." ForeColor="Red"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>


                </table>

            </div>
            <div>
                <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" ValidationGroup="Save" OnClick="btnAddStudent_Click" class="btn btn-primary btn-lg btn3d" Style="margin-left: 152px; margin-top: 18px;" />
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
