<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Blue_Jays_Manager.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
    <!--Header-->
    <header class="container-fluid" style="margin-top: 50px;">
        <div class="row">
            <asp:Image ID="coverPhoto" runat="server" ImageUrl="~/Images/banner.jpg" Width="100%" CssClass="img-responsive" />
        </div>
    </header>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <div class="col-md-5">
            <br />
            <hr />
        </div>
        <div class="col-md-2">
            <h1 class="text-center" style="vertical-align: middle; font-family: 'AlexBrush-Regular'; font-size: 6vmin;">Features:
            </h1>
        </div>
        <div class="col-md-5">
            <br />
            <hr />
        </div>

    </div>

    <div class="row">
        <div class="col-md-4 homepageDiv">
            <h2 style="font-family: 'Raleway-Black'">Regular Users:</h2>

            <asp:HyperLink ID="HyperLink1" runat="server" href="Players.aspx">
            <div class="btn btn-primary btn-block" style="white-space: normal;">
                <h3 style="font-family: 'AlexBrush-Regular'; font-size: 5vmin;">Player Roster <i class="glyphicon glyphicon-search"></i><i class="glyphicon glyphicon-sunglasses"></i></h3>
                <p>View and search for players who are currently active on the team.</p>
            </div>
            </asp:HyperLink>
            <br />
            <br />

            <asp:HyperLink ID="HyperLink2" runat="server" href="Coaches.aspx">
            <div class="btn btn-primary btn-block" style="white-space: normal;">
                <h3 style="font-family: 'AlexBrush-Regular'; font-size: 5vmin;">Coach Roster <i class="glyphicon glyphicon-sunglasses"></i></h3>
                <p>View currently active coaches and look up their information.</p>
            </div>
            </asp:HyperLink>
            <br />
            <br />

            <asp:HyperLink ID="HyperLink3" runat="server" href="Players.aspx">
            <div class="btn btn-primary btn-block" style="white-space: normal;">
                <h3 style="font-family: 'AlexBrush-Regular'; font-size: 5vmin;">Player Details <i class="glyphicon glyphicon-user"></i></h3>
                <p>Learn more about our team members! See individual player statistics and biographies.</p>
            </div>
            </asp:HyperLink>
            <br />
            <br />

        </div>

        <div class="col-md-4 homepageDiv">
            <h2 style="font-family: 'Raleway-Black'">Coaches:</h2>

            <asp:HyperLink ID="HyperLink4" runat="server" href="Login.aspx">
            <div class="btn btn-primary btn-block" style="white-space: normal;">
                <h3 style="font-family: 'AlexBrush-Regular'; font-size: 5vmin;">Add New Players <i class="glyphicon glyphicon-plus"></i></h3>
                <p>Add new players to the team.</p>
            </div>
            </asp:HyperLink>
            <br />
            <br />

            <asp:HyperLink ID="HyperLink5" runat="server" href="Login.aspx">
            <div class="btn btn-primary btn-block" style="white-space: normal;">
                <h3 style="font-family: 'AlexBrush-Regular'; font-size: 5vmin;">Update Existing Players <i class="glyphicon glyphicon-edit"></i></h3>
                <p>Modify information for players already on the team.</p>
            </div>
            </asp:HyperLink>
            <br />
            <br />

            <asp:HyperLink ID="HyperLink6" runat="server" href="Login.aspx">
            <div class="btn btn-primary btn-block" style="white-space: normal;">
                <h3 style="font-family: 'AlexBrush-Regular'; font-size: 5vmin;">Remove Players <i class="glyphicon glyphicon-remove"></i></h3>
                <p>Remove inactive players from the team.</p>
            </div>
            </asp:HyperLink>
            <br />
            <br />

        </div>

        <div class="col-md-4 homepageDiv">
            <h2 style="font-family: 'Raleway-Black'">Managers:</h2>

            <asp:HyperLink ID="HyperLink7" runat="server" href="Login.aspx">
            <div class="btn btn-primary btn-block" style="white-space: normal;">
                <h3 style="font-family: 'AlexBrush-Regular'; font-size: 5vmin;">Add New Coaches <i class="glyphicon glyphicon-plus"></i></h3>
                <p>Add new coaches to the team.</p>
            </div>
            </asp:HyperLink>
            <br />
            <br />

            <asp:HyperLink ID="HyperLink8" runat="server" href="Login.aspx">
            <div class="btn btn-primary btn-block" style="white-space: normal;">
                <h3 style="font-family: 'AlexBrush-Regular'; font-size: 5vmin;">Update Existing Coaches <i class="glyphicon glyphicon-edit"></i></h3>
                <p>Modify information for coaches already on the team.</p>
            </div>
            </asp:HyperLink>
            <br />
            <br />

            <asp:HyperLink ID="HyperLink9" runat="server" href="Login.aspx">
            <div class="btn btn-primary btn-block" style="white-space: normal;">
                <h3 style="font-family: 'AlexBrush-Regular'; font-size: 5vmin;">Remove Coaches <i class="glyphicon glyphicon-remove"></i></h3>
                <p>Remove inactive coaches from the team.</p>
            </div>
            </asp:HyperLink>
            <br />
            <br />

        </div>

    </div>

    <br />
    <br />

</asp:Content>
