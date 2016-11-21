<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Blue_Jays_Manager.PasswordReset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Password Reset</title>
    <link href="Content/BlueJaysStyle.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.1.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/BlueJaysStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="container" style="min-height:700px;">
             <div class="navbar navbar-inverse navbar-fixed-top">
                    <div class="container">
                        <div class="navbar-header">
                            <a class="navbar-brand" runat="server" href="~/">Toronto Blue Jays</a>
                        </div>
                    </div>
                </div>
             <h1  style="margin-top:70px" class="page-header"> <asp:Label ID="RsetPassword" runat="server"><span style="color:#134A8E">Admin Password Reset</span></asp:Label></h1>
             <asp:Label ID="confirmLabel" runat="server"></asp:Label>
             <div class="form-group row">
            <asp:Label runat="server" AssociatedControlID="NewPassword" CssClass="col-md-2 control-label">New Password</asp:Label>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="NewPassword"
                    CssClass="text-danger" ErrorMessage="New Password is required." />
                 <asp:RegularExpressionValidator ID="PasswordRegularExpressionValidator" CssClass="text-danger"  runat="server" Display="Dynamic" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,15}$" ControlToValidate="NewPassword" ErrorMessage="Password must be 8-15 characters long, one upper case, one lower case, and one number at least."></asp:RegularExpressionValidator>
            </div>
                 <div class="col-md-6"></div>
        </div>

        <div class="form-group row" style="margin-bottom:0">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm Password</asp:Label>
            <div class="col-md-4">
                <asp:TextBox runat="server" TextMode="Password" ID="ConfirmPassword" CssClass="form-control"/>
                 <asp:RequiredFieldValidator 
                     Display="Dynamic" runat ="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger"  ErrorMessage="Password is not confirmed." />
                 <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
        </div>
            <div class="col-md-6"></div>
        </div>
              <div class="form-group" style="margin-right: 5px; margin-top:8px;">
            <div class="col-md-2"></div>
            <div class="col-md-4">

                <asp:LinkButton ID="BtnnResetPassword" CssClass="btn btn-default" style="width: 115px; margin-bottom:10px;" BackColor="#134A8E" BorderColor="#134A8E" ForeColor="White" OnClick="BtnReset_Click" runat="server">Reset <span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
            </div>
            <div class="col-md-6"></div>   
        </div>
    </div>


       


    
    
    </form>
     <div class="container">
        <hr style="background-color:#232323; border: 1px solid #232323; border-radius:5px " />
                    <footer>
                        <p>&copy; <%: DateTime.Now.Year %> - Toronto Blue Jays Manager <span class="pull-right">Developers: Vinood Persad | Kevin Ma</span></p>

                    </footer>
         </div>
</body>
</html>
