<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Blue_Jays_Manager.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="margin-top:150px">
        
        <div class="col-md-4"></div>
            <div class="col-md-4">

            <div class="form-horizontal loginForm" style="margin-left:15px; margin-right:30px">
               <div class="page-header" style="margin-bottom:5px">
                    <div class="row">
                        <h1 style="margin-top:20px" class="pull-left"><span style="color:#134A8E">Jays Login</span> &nbsp;&nbsp;&nbsp; <span style="color:#EF2F24" class="glyphicon glyphicon-log-in"></span></h1> 
                    </div>
             </div>
                   <asp:Label ID="InvalidLabel" runat="server"></asp:Label>
                <br />
             <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-4 control-label">User Name</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="The User Name is required." />
            </div>
        </div>

        <div class="form-group" style="margin-bottom:0">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-4 control-label">Password</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password" />
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="Password is required." /><br />
                <asp:LinkButton ID="PasswordLinkBtn" runat="server" CausesValidation="False" OnClick="PasswordLinkBtn_Click">Forget Password</asp:LinkButton> | <asp:LinkButton ID="UsernameLinkBtn" runat="server" CausesValidation="False" OnClick="UsernameLinkBtn_Click">Username</asp:LinkButton>
               
            </div>
        </div>
        <div class="form-group " style="padding-bottom:30px; margin-bottom:0">
            <div class="col-md-4"></div>
            <asp:CheckBox ID="checkboxRemeber" style="padding-left:0; margin-right:0" runat="server" Text="Remember me" CssClass="col-md-8 checkbox"/>          
        </div>
                <hr  style="margin-bottom:0"/>
        <div class="form-group pull-right" style="margin-right: 5px;">
            <div class="col-md-offset-2 col-md-10">
                <asp:LinkButton ID="LinkButton1"  OnClick="BtnLogin_Click" style="width: 90px; margin-bottom:10px;" CssClass="btn btn-default" runat="server" BackColor="#134A8E" BorderColor="#134A8E" BorderStyle="Solid" ForeColor="White">Login <span class='glyphicon glyphicon-log-in'></span></asp:LinkButton>
            </div>
        </div>
      </div>
        

                </div>
         <div class="col-md-2" style="padding-left:0px">
        </div>
        <div class="col-md-2"></div>
       
        </div>
        
    
</asp:Content>
