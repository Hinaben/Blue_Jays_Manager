<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Blue_Jays_Manager.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="padding-bottom: 10px">
        
        <div class="col-md-2"></div>
        <div class="col-md-6 container registerView">

    <div class="form-horizontal" style=" margin-right: 30px; ">
        <div class="page-header" style="margin-bottom:5px">
            <div class="row">
            <h1 style="margin-top:20px" class="pull-left"><span style="color:#134A8E">Register Coach User</span> &nbsp;&nbsp;&nbsp; <span style="color:#EF2F24" class="glyphicon glyphicon-hand-down"></span></h1> 
            </div>
        </div>
        <asp:Label ID="UserExists" runat="server"></asp:Label>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CoachId" CssClass="col-md-4 control-label">Coach Number</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="CoachId" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CoachId"
                    CssClass="text-danger" ErrorMessage="The Coach Number field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-4 control-label">First Name</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                    CssClass="text-danger" ErrorMessage="The First Name field is required." />
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-4 control-label">Last Name</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="LastName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                    CssClass="text-danger" ErrorMessage="The Last Name field is required." />
            </div>
             
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-4 control-label">Email</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
                <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server" CssClass="text-danger" ErrorMessage="Invalid email format." Display="Dynamic" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" ControlToValidate="Email" ></asp:RegularExpressionValidator>
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-4 control-label">User Name</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="The username field is required." />
            </div>
        </div>


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-4 control-label">Password</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
                <asp:RegularExpressionValidator ID="PasswordRegularExpressionValidator" CssClass="text-danger"  runat="server" Display="Dynamic" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,15}$" ControlToValidate="Password" ErrorMessage="Password must be 8-15 characters long, one upper case, one lower case, and one number at least."></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-4 control-label">Confirm password</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>

        <hr />
        <div class="form-group pull-right">
            <div class="col-md-12">
                <input id="Resetbtn" type="reset" class="btn btn-default" style=" width: 90px;" />
                  <asp:LinkButton ID="LinkBtnRegister"   OnClick="BtnRegister_Click" style="width: 90px" CssClass="btn btn-default" runat="server" BackColor="#134A8E" BorderColor="#134A8E" BorderStyle="Solid" ForeColor="White">Register <span class='glyphicon glyphicon-check'></span></asp:LinkButton>
               
            </div>
        </div>
    </div>
     </div>

        <div class="col-md-2" style="margin-top:40px; padding-left:0px">
        </div>
        <div class="col-md-2"></div>
    </div>
</asp:Content>
