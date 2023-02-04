<%@ Page Title="" Language="C#" MasterPageFile="~/DigitalLibrary.Master" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="DigitalLibrary.Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="card text-center" style="width: 95%; margin-left: -75px;">
        <div class="card-header" style="background-color: #0b3355;">

            <h6 style="color: ghostwhite;"><b>Welcome to Digital Library System</b></h6>
        </div>
        <div class="card-body" style="background-color: #f66f00;">
            <%--<img src="../Images/GroupLibrary.png" style="width:100%;height:500px;" />--%>
             <video autoplay loop muted plays-inline class="back-video" style="width:100%;height:500px;">
                    <source src="Video/Library Environment.mp4" type="video/mp4" />
               </video>

            
        </div>
        <div class="card-footer text-muted" style="background-color: #0b3355;">
        </div>
    </div>

</asp:Content>
