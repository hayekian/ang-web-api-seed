<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleAngular.Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="js/jquery-2.1.1.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
   
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
        <div class="container">

            <!-- Static navbar -->
            <nav class="navbar navbar-default" role="navigation">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                           
                        </button>
                        Simple Angular/Web API template App
                    </div>
               
                    <!--/.nav-collapse -->
                </div>
                <!--/.container-fluid -->
            </nav>

          

              <div>



         <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
            <h2>
                Welcome <asp:Label runat="server" ID="lblName" />
            </h2>
            <br />

        
            <div class="MainMessage" >
            <asp:Label runat="server" ID="lblMainMessage" />
            </div>
            <br />
          

        </LoggedInTemplate>
        <AnonymousTemplate>
            <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" PasswordRecoveryText="Click here to recover your password."
                PasswordRecoveryUrl="~/recoverpassword.aspx" VisibleWhenLoggedIn="False" OnLoginError="Login1_LoginError"
                OnLoggedIn="Login1_LoggedIn" FailureTextStyle-HorizontalAlign="Left">
                <LayoutTemplate>

                  
                    <table cellpadding="2" style="border-collapse: collapse;">
                        <tr>

                            <th align="center" colspan="2">
                          
                            </th>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                            </td>

                            <td>
                                <asp:TextBox ID="UserName" runat="server" Width="150px" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="150px" Text="ilikebass"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="color: Red;">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <br />
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="ctl00$Login1" />
                            </td>
                        </tr>
                       
                    </table>

                    <%--  <p>
                            This site is tested to properly function with browsers Internet Explorer 11 or higher and Google Chrome. If you experience any irregularities please access the site with any of the aforementioned browsers.

                        </p>--%>
                </LayoutTemplate>
                <FailureTextStyle HorizontalAlign="Left" />
            </asp:Login>
            <br />
          
        </AnonymousTemplate>
    </asp:LoginView>


    </div>
          

        </div>








    
     
  

   


    </div>
    </form>
</body>
</html>
