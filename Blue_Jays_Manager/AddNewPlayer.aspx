<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="AddNewPlayer.aspx.cs" Inherits="Blue_Jays_Manager.AddNewPlayer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="padding-bottom: 10px">

        <div class="col-md-4"></div>
        <div class="col-md-4 container registerView">

            <div id="addPlayerFormDiv" class="form-horizontal" style="margin-right: 30px;">
                <div class="page-header" style="margin-bottom: 5px">
                    <div class="row">
                        <h1 style="margin-top: 20px" class="pull-left"><span style="color:#134A8E">Add New Player <span style="color:#EF2F24" class="glyphicon glyphicon-plus-sign"></span></span></h1>
                    </div>
                </div>
                <asp:Label ID="PlayerExists" runat="server" ForeColor="red"></asp:Label>
                <br />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="PlayerNum" CssClass="col-md-4 control-label">Player Number</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="PlayerNum" CssClass="form-control" TextMode="Number" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PlayerNum"
                            CssClass="text-danger" ErrorMessage="The Player Number field is required." />
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
                    <asp:Label runat="server" AssociatedControlID="positionDropDownList" CssClass="col-md-4 control-label">Position</asp:Label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="positionDropDownList" runat="server">
                            <asp:ListItem Text="Infield" />
                            <asp:ListItem Text="Outfield" />
                            <asp:ListItem Text="Pitcher" />
                            <asp:ListItem Text="Designated Hitter" />
                            <asp:ListItem Text="Catcher" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="playerHeight" CssClass="col-md-4 control-label">Height (cm)</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="playerHeight" CssClass="form-control" TextMode="Number" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="playerHeight"
                            CssClass="text-danger" ErrorMessage="The Player Height field is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="playerWeight" CssClass="col-md-4 control-label">Weight (lbs)</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="playerWeight" CssClass="form-control" TextMode="Number" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="playerWeight"
                            CssClass="text-danger" ErrorMessage="The Player Weight field is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="dobMonthDropDownList" CssClass="col-md-4 control-label">Date of Birth</asp:Label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="dobMonthDropDownList" runat="server" OnSelectedIndexChanged="dobMonthDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        <asp:DropDownList ID="dobDayDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
                        <asp:DropDownList ID="dobYearDropDownList" runat="server" OnSelectedIndexChanged="dobYearDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="playerBattingHand" CssClass="col-md-4 control-label">Batting Hand</asp:Label>
                    <div class="col-md-8">
                        <asp:RadioButtonList ID="playerBattingHand" runat="server">
                            <asp:ListItem Text="Right" Value="R" />
                            <asp:ListItem Text="Left" Value="L" />
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="playerBattingHand"
                            CssClass="text-danger" ErrorMessage="The Player Batting Hand field is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="playerThrowingHand" CssClass="col-md-4 control-label">Throwing Hand</asp:Label>
                    <div class="col-md-8">
                        <asp:RadioButtonList runat="server" ID="playerThrowingHand">
                            <asp:ListItem Text="Right" Value="R" />
                            <asp:ListItem Text="Left" Value="L" />
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="playerThrowingHand"
                            CssClass="text-danger" ErrorMessage="The Player Throwing Hand field is required." />
                    </div>
                </div>

                <hr />
                <div class="form-group pull-right">
                    <div class="col-md-12">
                        <input id="Resetbtn" type="reset" class="btn btn-default" style="width: 90px" value="reset" />
                        <asp:LinkButton ID="AddPlayerButtoon" OnClick="AddPlayerButton_Click"  CssClass="btn btn-primary" BackColor="#134A8E" ForeColor="#ffffff" Style="width: 110px"  runat="server">Add Player <span  class='glyphicon glyphicon-chevron-right'></span></asp:LinkButton>

                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-2" style="margin-top: 40px; padding-left: 0px">
            <asp:Image ID="Image1" CssClass="img-responsive pull-right" Style="margin-right: 55px;" Height="200px" Width="200px" ImageUrl="~/Images/torontologo.png" runat="server" />
        </div>
        <div class="col-md-2"></div>
    </div>
</asp:Content>
