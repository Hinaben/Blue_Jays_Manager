<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Blue_Jays_Manager.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/BlueJaysStyle.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.1.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="min-height: 700px;">
            <!--Navigation-->
            <nav class="navbar navbar-default navbar-fixed-top" style="height: 10px;">
                <div class="container-fluid">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" runat="server" href="~/">
                            <img src="Images/torontologo.png" class="img-responsive" style="width: 50px;" /></a>
                        <%--  <a class="navbar-brand" runat="server" href="~/">
                       <img src="Images/torontologo.png" class="img-responsive" style="width:50px;" /> Blue Jays Manager </a>--%>
                    </div>
                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">

                            <li><a runat="server" href="http://toronto.bluejays.mlb.com/index.jsp?c_id=tor">About Team</a></li>
                            <li><a runat="server" href="~/Players.aspx">Players</a></li>
                            <li><a runat="server" href="~/Coaches.aspx">Coaches</a></li>

                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li><a runat="server" href="~/Register.aspx"><% if (Session["login"].ToString() == "loggedIn")
                                                                             {
                                                                                 Response.Write("<span class=\" glyphicon glyphicon-user\"></span>" + " " + Session["Name"]);
                                                                             }
                                                                             else
                                                                             {
                                                                                 Response.Write("Register");
                                                                             } %></a></li>



                            <li><a runat="server" href="~/Login.aspx"><% if (Session["login"].ToString() == "loggedIn")
                                                                          {
                                                                              Response.Write("<span class=\"glyphicon glyphicon-log-out\"></span> Sign Out");
                                                                          }
                                                                          else
                                                                          {
                                                                              Response.Write("<span class=\"glyphicon glyphicon-log-in\"></span> Log In");
                                                                          } %></a></li>
                        </ul>
                    </div>
                </div>
            </nav>

            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <span style="color: #EF2F24; margin-top: 150px; font-size: 250px; margin-right: auto; margin-left: auto" class="glyphicon glyphicon-alert text-center"></span>
                </div>
                <div class="col-md-4"></div>
            </div>



        </div>

        <div class="container-fluid text-center">
            <hr style="background-color: #232323; border: 1px solid #232323; border-radius: 5px" />
            <footer>
                <p>
                    <asp:HyperLink ID="HyperLink3" runat="server" href="http://toronto.bluejays.mlb.com/index.jsp?c_id=tor">About the Team</asp:HyperLink>
                    | 
                   <asp:HyperLink ID="HyperLink4" runat="server" href="Players.aspx">Player Roster</asp:HyperLink>
                    | 
                    <asp:HyperLink ID="HyperLink5" runat="server" href="Coaches.aspx">Coaches</asp:HyperLink>
                    | 
                    <asp:HyperLink ID="HyperLink6" runat="server" href="Register.aspx">Register</asp:HyperLink>
                    | 
                    <asp:HyperLink ID="HyperLink7" runat="server" href="Login.aspx">Login</asp:HyperLink>
                </p>
                <h6>Copyright &copy; <%: DateTime.Now.Year %> Toronto Blue Jays Manager
                    <br />
                    Developed by:
                    <asp:HyperLink ID="HyperLink1" runat="server" href="http://studentweb.cencol.ca/vpersad3/">Vinood Persad</asp:HyperLink>
                    |
                    <asp:HyperLink ID="HyperLink2" runat="server" href="http://studentweb.cencol.ca/kma45/">Kevin Ma</asp:HyperLink>

                </h6>

            </footer>
        </div>

    </form>
</body>
</html>
