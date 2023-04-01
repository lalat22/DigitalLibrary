<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="IssueReport.aspx.cs" Inherits="DigitalLibrary.IssueReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card text-center" style="width: 95%; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>Issue Book Report</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(145, 209, 208); overflow-y: scroll; overflow-x: hidden; height: 440px">
            <div style="margin-left: 298px;">
                <table style="margin-left: -130px">

                    <tr>
                        <td style="margin-left: 50px;">&nbsp;&nbsp;&nbsp;&nbsp;Select Branch<em style="color: Red">*</em> :
                        </td>
                        <td>
                            <%-- <asp:Label ID="lblBranch" runat="server" Text="Select Branch"></asp:Label> : &nbsp;--%>
                            <asp:DropDownList ID="ddlBranch" runat="server" class="form-control" DataValueField="BranchId" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="True" DataTextField="BranchName"></asp:DropDownList>

                        </td>

                        <td style="margin-left: 50px;">&nbsp;&nbsp;&nbsp;&nbsp;Select Student<em style="color: Red">*</em> :
                        </td>
                        <td>
                            <%--<asp:Label ID="lblStudent" runat="server" Text="Select Student"></asp:Label> : &nbsp;--%>
                            <asp:DropDownList ID="ddlStudent" runat="server" class="form-control" Style="width: 140px;" DataValueField="StudentId" DataTextField="StudentName"></asp:DropDownList>

                        </td>
                        <td>
                            <asp:Button ID="btnViewIssueReport" runat="server" Text="Select" OnClick="btnViewIssueReport_Click" class="btn btn-primary btn-lg btn3d" Style="margin-left: 15px; margin-top: 18px; height: 44px;" />

                        </td>
                    </tr>

                    <tr>
                    </tr>



                </table>

            </div>
            <%--gridvew--%>
            <div style="width: 568px; margin-left: 213px;">
                <asp:GridView ID="gvIssueReport" runat="server" class="table align-middle mb-0 bg-white" AlternatingRowStyle-BackColor="#99ccff" AutoGenerateColumns="False" CellPadding="6"  OnRowCommand="gvIssueReport_RowCommand"
                    OnRowEditing="gvIssueReport_RowEditing" OnRowDeleting="gvIssueReport_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Book Name">
                            <ItemTemplate>
                                <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="IssueDate">
                            <ItemTemplate>
                                <asp:Label ID="lblIssueDate" runat="server" Text='<%#Eval("IssueDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Days">
                            <ItemTemplate>
                                <asp:Label ID="lblDays" runat="server" Text='<%#Eval("Days") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>

                    <HeaderStyle BackColor="#298ca3" ForeColor="#ffffff" />
                    <RowStyle BackColor="#e7ceb6" />
                </asp:GridView>

            </div>

        </div>
        <div class="card-footer text-muted" style="background-color: #0b3355;">
        </div>
    </div>
</asp:Content>
