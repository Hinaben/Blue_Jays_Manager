<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Blue_Jays_Manager.User" %>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
    <!--Header-->
    <header class="container-fluid" style="margin-top: 50px;">
        <div class="row">
            <div class="jumbotron" style="background-color: #134A8E; color: #fff; border-radius: 0px; margin-bottom: 0;">
                <h1>Account Details &nbsp;<span style="color: #EF2F24" class="glyphicon glyphicon-compressed"></span></h1>
            </div>
        </div>
    </header>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="background-color: #fff; padding-left: 0; padding-right: 0">


        <div>
            <h1>
                <asp:Label runat="server" ID="LblName" CssClass="page-header"></asp:Label>&nbsp;&nbsp;<span class=" glyphicon glyphicon-user"></span></h1>
        </div>

        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Role:"></asp:Label>
            </div>
            <div class="col-md-11">
                <asp:Label ID="LblRole" runat="server"></asp:Label>
            </div>
        </div>


        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Email:"></asp:Label>
            </div>
            <div class="col-md-11">
                <asp:Label ID="LblEmail" runat="server"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class=" col-md-1">
                <asp:Label ID="LblPassword" runat="server" Font-Bold="true" Text="Password:"></asp:Label>
            </div>
            <div class="col-md-11">

                <asp:LinkButton ID="LinkBtnPasswordChange" OnClick="LinkBtnPasswordChange_Click" runat="server" CausesValidation="False">[Change]</asp:LinkButton>

                <div id="panel" style="margin-top: 15px;">
                    <asp:Panel runat="server" ID="PasswordPanel" Style="padding-left: 0; border: 1px solid #134A8E" CssClass="panel panel-default col-md-7">

                        <div class="form-horizontal" style="margin-top: 10px; padding-bottom: 20px;">
                            <div class=" form-group" style="margin-bottom: 0">
                                <asp:Label runat="server" CssClass="col-md-4 control-label" Text="Current Password:"></asp:Label>
                                <div class="col-md-8 ">
                                    <asp:TextBox CssClass="form-control" ID="currentPass" TextMode="Password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Current password is required" ControlToValidate="currentPass" CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group" style="margin-bottom: 10">
                                <asp:Label runat="server" CssClass="col-md-4 control-label" Text="New Password:"></asp:Label>
                                <div class="col-md-8 ">
                                    <asp:TextBox CssClass="form-control" ID="newPass" TextMode="Password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="New password is required" ControlToValidate="newPass" CssClass="text-danger"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="PasswordRegularExpressionValidator" CssClass="text-danger" runat="server" Display="Dynamic" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,15}$" ControlToValidate="newPass" ErrorMessage="Password: 8-15 characters long, one upper case, one lower case, and one number at least."></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group" style="margin-bottom: 10px">
                                <asp:Label runat="server" CssClass=" col-md-4 control-label" Text="Confirm Password:"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox CssClass="form-control" TextMode="Password" ID="confirmPass" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="Current password is required" ControlToValidate="confirmPass" CssClass="text-danger"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator runat="server" ControlToCompare="newPass" ControlToValidate="confirmPass" Display="Dynamic" CssClass="text-danger" ErrorMessage="Confirmed password is invalid"></asp:CompareValidator>
                                </div>
                            </div>

                            <div class="form-group" style="margin-bottom: 0px">
                                <div class="col-md-4"></div>
                                <div class="col-md-8">
                                    <asp:Button runat="server" Style="background-color: #134A8E; color: #fff; border: 1px solid #134A8E" CssClass="btn btn-info" ID="BtnChangePassword" Text="Submit" OnClick="BtnChangePassword_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>

            </div>

            <div class="row">
                <asp:Label ID="LblConfirm" CssClass="col-md-12" runat="server"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
