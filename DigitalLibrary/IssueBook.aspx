<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="IssueBook.aspx.cs" Inherits="DigitalLibrary.IssueBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .parent {
  border: 2px solid black;
  margin: 1rem;
  padding: 2rem 2rem;
  text-align: center;
}
.child {
  display: inline-block;
  padding: 1rem 1rem;
  vertical-align: middle;
}
    </style>
    <div class="card text-center" style="width: 95%; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>Issue Book</b></h6>
        </div>
        <div class="card-body" style="background-color: rgb(145, 209, 208); overflow-y: scroll; overflow-x: hidden; height: 440px">

            <div style="margin-left: 298px;">
                <table style="margin-left: -130px">

                    <tr>
                        <td>SelectPublication<em style="color: Red">*</em> :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPublication" runat="server" class="form-control" DataValueField="PublicationId" DataTextField="PublicationName" AutoPostBack="True" OnSelectedIndexChanged="ddlPublication_SelectedIndexChanged"></asp:DropDownList>

                        </td>

                        <td style="margin-left: 50px;">&nbsp;&nbsp;&nbsp;&nbsp;SelectBook<em style="color: Red">*</em> :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBook" runat="server" class="form-control" Style="width: 140px;" DataValueField="BookId" DataTextField="BookName"></asp:DropDownList>

                        </td>
                        <td>
                            <asp:Button ID="btnViewbook" runat="server" Text="Select" OnClick="btnViewbook_Click" class="btn btn-primary btn-lg btn3d" Style="margin-left: 15px; margin-top: 18px; height: 44px;" />

                        </td>
                    </tr>

                    <tr>
                    </tr>



                </table>

            </div>
            <div class="container py-5" id="dvIssueBook" runat="server" visible="false">

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
                                        <p class="mb-0">Quantities</p>
                                    </div>
                                    <div class="col-sm-9">
                                        <p class="text-muted mb-0">
                                            <asp:Label ID="lblQuantities" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-3">
                                        <p class="mb-0">AvlQuantity</p>
                                    </div>
                                    <div class="col-sm-9">
                                        <p class="text-muted mb-0">
                                            <asp:Label ID="lblAvlQuantity" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-3">
                                        <p class="mb-0">RentQuantity</p>
                                    </div>
                                    <div class="col-sm-9">
                                        <p class="text-muted mb-0">
                                            <asp:Label ID="lblRentQuantity" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </div>

                            </div>

                        </div>

                    </div>
                </div>
                <div class="parent">
                    <h5>Select Student Detail For Issue Book</h5>
                    <hr />
                    <div class='child'>
                        <asp:Label ID="lblBranch" runat="server" Text="Select Branch"></asp:Label> : &nbsp;
                         <asp:DropDownList ID="ddlBranch" runat="server" class="form-control" DataValueField="BranchId" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="True" DataTextField="BranchName"></asp:DropDownList>
                    </div>
                    <div class="child">
                       <asp:Label ID="lblStudent" runat="server" Text="Select Student"></asp:Label> : &nbsp;
                         <asp:DropDownList ID="ddlStudent" runat="server" class="form-control" Style="width: 140px;" DataValueField="StudentId" DataTextField="StudentName"></asp:DropDownList>
                    </div>
                    <div class="child">
                        <asp:Label ID="lblDays" runat="server" Text="Days"></asp:Label> : &nbsp;
                         <asp:TextBox ID="txtDay" runat="server" placeholder="Days"></asp:TextBox>
                    </div>
                    <div class="child">
                        <asp:Button ID="btnBookIssue" runat="server" Text="Book Issue" OnClick="btnBookIssue_Click" class="btn btn-primary btn-lg btn3d" Style="margin-left: 15px; margin-top: 18px; height: 44px;" />
                    </div>
                    <div class="child">
                       <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>
                </div>

            </div>

        </div>
        <div class="card-footer text-muted" style="background-color: #0b3355;">
        </div>
    </div>
</asp:Content>
