<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="DigitalLibrary.AddBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card text-center" style="width: 1201px; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>Add New Book</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(37, 150, 190);">
            <div style="margin-left: 373px;">
                <table>
                    <tr>
                        <td>Book Name : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtBookName" runat="server" class="form-control" placeholder="Book Name"></asp:TextBox>
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
                        <td>Author : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtAuthor" runat="server" class="form-control" placeholder="Author"></asp:TextBox>
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
                        <td>Price : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtPrice" runat="server" class="form-control" placeholder="Price"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Quantity : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtQuantity" runat="server" class="form-control" placeholder="Quantity"></asp:TextBox>
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
                <asp:Button ID="btnAddBook" runat="server" Text="Add Book" OnClick="btnAddBook_Click" class="btn btn-primary" Style="margin-left: -5px; margin-top: 7px;" />
                <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>



        </div>





        <div class="card-footer text-muted" style="background-color: #0b3355;">
        </div>
    </div>
</asp:Content>
