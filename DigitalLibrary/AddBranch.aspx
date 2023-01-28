<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="AddBranch.aspx.cs" Inherits="DigitalLibrary.AddBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card text-center" style="width: 95%; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>Add Branch</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(37, 150, 190);">

            <div class="form-row" style="margin-left: 500px;">
                <div class="form-group col-sm-3">
                    <%--<label for="inputEmail4">Add Branch</label>--%>
                    <h5>Branch Name  </h5>
                    <asp:TextBox ID="txtBranchName" runat="server" class="form-control" placeholder="Branch Name"></asp:TextBox>
                    <%--<input type="email" class="form-control" id="inputEmail4" placeholder="Branch Name">--%>
                </div>

            </div>
            <asp:Button ID="btnSave" runat="server" Text="Add Branch" OnClick="btnSave_Click" class="btn btn-primary" Style="margin-left: -5px; margin-top: 7px;" />
            <%--<button type="submit" class="btn btn-primary" style="margin-left: -5px; margin-top: 7px;">Add Branch</button>--%>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <div style="margin-left: 495px; margin-top: 41px;">
                <asp:GridView ID="gvBranch" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCommand="gvBranch_RowCommand"
                    OnRowEditing="gvBranch_RowEditing" OnRowDeleting="gvBranch_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Branch Name">
                            <ItemTemplate>
                                <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="edit" CommandArgument='<%#Eval("BranchId") %>'><span class="fa fa-pencil fa-fw"></asp:LinkButton>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#Eval("BranchId") %>'><span class="fa fa-trash-o"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <HeaderStyle BackColor="#663300" ForeColor="#ffffff" />
                    <RowStyle BackColor="#e7ceb6" />
                </asp:GridView>

            </div>


        </div>
        <div class="card-footer text-muted">
            2 days ago
        </div>
    </div>
</asp:Content>
