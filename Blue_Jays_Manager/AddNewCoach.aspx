<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="AddNewCoach.aspx.cs" Inherits="Blue_Jays_Manager.AddNewCoach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="padding-bottom: 10px">
        
        <div class="col-md-4"></div>
        <div class="col-md-4 container registerView">

    <div id="addCoachFormDiv" class="form-horizontal" style=" margin-right: 30px; ">
        <div class="page-header" style="margin-bottom:5px">
            <div class="row">
            <h1 style="margin-top:20px" class="pull-left"><span style="color:#134A8E">Add New Coach</span>  <span style="color:#EF2F24" class="glyphicon glyphicon-plus-sign"></span></h1> 
            </div>
        </div>
        <asp:Label ID="CoachExists" runat="server" ForeColor="red"></asp:Label>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CoachNum" CssClass="col-md-4 control-label">Coach Number</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="CoachNum" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CoachNum"
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
            <asp:Label runat="server" AssociatedControlID="pos" CssClass="col-md-4 control-label">Position</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="pos" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="pos"
                    CssClass="text-danger" ErrorMessage="The Position field is required." />
            </div>
        </div>

        <hr />
        <div class="form-group pull-right">
            <div class="col-md-12">
                <input id="Resetbtn" type="reset" class="btn btn-default" style="width: 90px"  value="reset" />
                 <asp:LinkButton ID="AddCoachButtoon" OnClick="AddCoachButton_Click"  CssClass="btn btn-primary" BackColor="#134A8E" ForeColor="#ffffff" Style="width: 110px"  runat="server">Add Player <span  class='glyphicon glyphicon-chevron-right'></span></asp:LinkButton>
               
            </div>
        </div>
    </div>
     </div>

        <div class="col-md-2" style="margin-top:40px; padding-left:0px">
            <asp:Image ID="Image1" CssClass="img-responsive pull-right" style="margin-right:55px;" Height="200px" Width="200px" ImageURL="~/Images/torontologo.png" runat ="server" />
        </div>
        <div class="col-md-2"></div>
    </div>
</asp:Content>
