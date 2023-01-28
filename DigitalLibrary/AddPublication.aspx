<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="AddPublication.aspx.cs" Inherits="DigitalLibrary.AddPublication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card text-center" style="width: 95%; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>Add Publication</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(37, 150, 190);">

            <div class="form-row" style="margin-left: 500px;">
                <div class="form-group col-sm-3">
                 
                    <h5>Publication Name  </h5>
                    <asp:TextBox ID="txtPublicationName" runat="server" class="form-control" placeholder="Publication Name"></asp:TextBox>
                  
                </div>

            </div>
            
                    <asp:Button ID="btnSave" runat="server" Text="Add Publication" OnClick="btnSave_Click" class="btn btn-primary" Style="margin-left: -5px; margin-top: 7px;" />
               
            <br />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <div style="margin-left: 495px; margin-top: 41px;">
                <asp:GridView ID="gvPublication" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCommand="gvPublication_RowCommand"
                    OnRowEditing="gvPublication_RowEditing" OnRowDeleting="gvPublication_RowDeleting">
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
