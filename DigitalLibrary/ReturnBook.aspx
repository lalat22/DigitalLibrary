<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="ReturnBook.aspx.cs" Inherits="DigitalLibrary.ReturnBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card text-center" style="width: 95%; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>Return Book</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(145, 209, 208); overflow-y: scroll; overflow-x: hidden; height: 440px">
            <div style="margin-left: 298px;">
                <table style="margin-left: -130px">

                    <tr>
                       
                        <td style="margin-left: 50px;">&nbsp;&nbsp;&nbsp;&nbsp;Select Student<em style="color: Red">*</em> :
                        </td>
                        <td>
                            <%--<asp:Label ID="lblStudent" runat="server" Text="Select Student"></asp:Label> : &nbsp;--%>
                            <asp:DropDownList ID="ddlStudent" runat="server" class="form-control" Style="width: 140px;" DataValueField="StudentId" DataTextField="StudentName"></asp:DropDownList>

                        </td>

                        <td style="margin-left: 50px;">&nbsp;&nbsp;&nbsp;&nbsp;SelectBook<em style="color: Red">*</em> :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBook" runat="server" class="form-control" Style="width: 140px;" DataValueField="BookId" DataTextField="BookName"></asp:DropDownList>

                        </td>

                      
                    </tr>

                    <tr>
                         <td>
                            <asp:Button ID="btnViewbook" runat="server" Text="Select" OnClick="btnViewbook_Click" class="btn btn-primary btn-lg btn3d" Style="margin-left: 15px; margin-top: 18px; height: 44px;" />

                        </td>
                    </tr>



                </table>

            </div>
        </div>
        <div class="card-footer text-muted" style="background-color: #0b3355;">
        </div>
    </div>
</asp:Content>
