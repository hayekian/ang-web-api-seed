﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SampleAngular.index" %>

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

      
        <div id="text-to-speech">
            Select voice: <select ng-model="VoiceId" ng-options="item.Name as (item.LanguageName + '('+ item.Name+')') for item in Voices">
                    <option value=""></option>
                </select>
            <p />
            Enter text to synthesize:
            <p />
            <textarea ng-model="Text" rows="10" cols="80">
	    </textarea>
<p />
            <button type="button" ng-click="Synthesize()">Synthesize</button>
            <p />
            {{Message}}
            <p />

            <audio  id="aud" controls />
            <p />

          

          
        </div>


      </div>

  
</body>
</html>
