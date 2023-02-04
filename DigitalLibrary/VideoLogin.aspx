<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoLogin.aspx.cs" Inherits="DigitalLibrary.VideoLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    

     <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%">
            <video autoplay loop muted plays-inline class="back-video" style="width: 100%;position:absolute;right:0;bottom:0;z-index:-1">
                <source src="Video/Library Environment.mp4" type="video/mp4" />

                
            </video>
            <div>
                <h1>Hii, Good AfterNoon</h1>
            </div>

        </div>
    </form>
</body>
</html>
