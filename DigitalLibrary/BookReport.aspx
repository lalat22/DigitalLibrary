<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="BookReport.aspx.cs" Inherits="DigitalLibrary.BookReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card text-center" style="width: 95%; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>View Book</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(145, 209, 208);">

            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table class="tbl">
                        <tr>
                            <td class="tblhead">
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--gridvew--%>
                                <div style="width: 568px; margin-left: 213px;">
                                    <asp:GridView ID="gvBookRebort" runat="server" class="table align-middle mb-0 bg-white" AlternatingRowStyle-BackColor="#99ccff" AutoGenerateColumns="False" CellPadding="6" OnRowCommand="gvBookRebort_RowCommand"
                                        OnRowEditing="gvBookRebort_RowEditing" OnRowDeleting="gvBookRebort_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Book Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price") %>'></asp:Label>--%>
                                                    <asp:Label ID="lblPrice" runat="server" Text='<%#String.Format("{0:C}", Eval("Price")) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantities">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuantities" runat="server" Text='<%#Eval("Quantities") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="AvlQuantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAvlQuantity" runat="server" Text='<%#Eval("AvlQuantity") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RentQuantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRentQuantity" runat="server" Text='<%#Eval("RentQuantity") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Actions">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkView" runat="server" CommandName="view" CommandArgument='<%#Eval("BookId") %>'> <span class="fa fa-eye"></span></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#Eval("BookId") %>'><span class="fa fa-trash-o"></span></asp:LinkButton>

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
                                        <div class="card-body text-center" style="margin-top: 23px;">
                                            <%-- <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp" alt="avatar"
                                                class="rounded-circle img-fluid" style="width: 150px;">--%>
                                            <asp:Image ID="Image2" runat="server" class="img-thumbnail" Style="width: 150px;" />
                                            <h5 class="my-3">
                                                <asp:Label ID="lblProfileBook" runat="server"></asp:Label></h5>
                                            <p class="text-muted mb-1">
                                                <asp:Label ID="lblProfileAuthor" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <div class="card mb-4">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">Book Name</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lblbname" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">Author</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lblauthor" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">Publication</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lblpub" runat="server"></asp:Label>
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
                                                        <asp:Label ID="lblbran" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">Price</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lblprice" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <p class="mb-0">Details</p>
                                                </div>
                                                <div class="col-sm-9">
                                                    <p class="text-muted mb-0">
                                                        <asp:Label ID="lbldetail" runat="server"></asp:Label>
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
        <div class="card-footer text-muted" style="background-color: #0b3355;">
        </div>
    </div>
</asp:Content>
