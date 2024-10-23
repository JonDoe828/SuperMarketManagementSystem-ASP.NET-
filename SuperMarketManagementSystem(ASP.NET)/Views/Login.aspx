<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SuperMarketManagementSystem_ASP.NET_.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../Assets/Lib/css/bootstrap.min.css" />
</head>
<body>
    <div class="container-fluid">
        <div class="row mt-5 mb-5">

        </div>

        <div class="row">
            <div class="col-md-4">

            </div>

            <div class="col-md-4">
                <form id="form1" runat="server">
                    <div class="d-flex justify-content-center">
                        <img src="../Assets/Images/icons8-supermarket-100.png" alt="Supermarket Logo" />
                    </div>
                 
                    <div class="mt-3">
                        <label for="" class="form-label">  Username  </label> 
                        <input type="text" placeholder="" autocomplete="off" name="name" value="" class="form-control" id="UnameTb"/>
                    </div>
                    <div class="mt-3">
                        <label for="" class="form-label">  Password  </label> 
                        <input type="password" placeholder="" autocomplete="off" name="name" value="" class="form-control" id="PasswordTb"/>
                    </div>
                    <div class="mt-3 d-grid">
                        <asp:Button Text="Log In" runat="server" class="btn-success btn" ID="LoginBtn"/>
                    </div>
                    
                </form>
            </div>

            <div class="col-md-4">
            </div>
            

        </div>
    </div>
  
</body>
</html>
