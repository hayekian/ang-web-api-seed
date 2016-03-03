<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SampleAngular.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-2.1.1.min.js"></script>
    <script src="js/Globals.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/angular-route.min.js"></script>
    <script src="js/angular-sanitize.min.js"></script>
   <script src="js/Controllers.js"></script>
       <script src="js/AngularApp.js"></script>
    <script src="js/HLib.js"></script>

</head>
<body ng-app="App">
   
    <div ng-controller="MainCtrl">

        {{ TEST }}

   Original:     <div ng-bind-html="Original" ></div>

<br />
  New:       <div ng-bind-html="NewObj" ></div>
 
        <br />
  Changes:       <div ng-bind-html="Changes" ></div>
        
           </div>


</body>
</html>
