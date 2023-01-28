<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="BookReport.aspx.cs" Inherits="DigitalLibrary.BookReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card text-center" style="width: 95%; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>View Book</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(37, 150, 190);">

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
                                <div style="margin-left: 495px; margin-top: 41px;">
                                    <asp:GridView ID="gvBookRebort" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCommand="gvBookRebort_RowCommand"
                                        OnRowEditing="gvBookRebort_RowEditing" OnRowDeleting="gvBookRebort_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Book Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
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
                                                    <asp:LinkButton ID="lnkView" runat="server" CommandName="view" CommandArgument='<%#Eval("BookId") %>'> <span class="fa fa-pencil fa-fw"></span></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#Eval("BookId") %>'><span class="fa fa-trash-o"></span></asp:LinkButton>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                        <HeaderStyle BackColor="#663300" ForeColor="#ffffff" />
                                        <RowStyle BackColor="#e7ceb6" />
                                    </asp:GridView>

                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table class="tbl">
                        <tr>
                            <td class="tblhead">View Book Detail </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="style4">
                                    <tr>
                                        <td class="style5" colspan="2">Book Name :
                                            <asp:Label ID="lblbname" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style6">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style6" rowspan="2">
                                            <asp:Image ID="Image2" runat="server" Height="228px" Width="207px" />
                                        </td>
                                        <td class="style8" valign="top">
                                            <table class="style7">

                                                <tr>
                                                    <td class="style11" style="font-size: medium">Autor :</td>
                                                    <td>
                                                        <asp:Label ID="lblauthor" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="font-size: medium">Publication :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblpub" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="font-size: medium">Branch :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblbran" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="font-size: medium">Price :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblprice" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="font-size: medium">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="font-size: medium">Total Quantity :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblqnt" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="font-size: medium">Availabale Qnt :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblaqnt" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="font-size: medium">Rent Qnt :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrqnt" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="font-size: medium">Detail :</td>
                                                    <td>
                                                        <asp:Label ID="lbldetail" runat="server"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style9" valign="top">
                                            <asp:Button ID="btnBack" runat="server" CssClass="btn"
                                               OnClick="btnBack_Click" Text="Back" Width="80px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>


        </div>
        <div class="card-footer text-muted" style="background-color: #0b3355;">
           
        </div>
    </div>
</asp:Content>
