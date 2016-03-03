<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MappingTest.aspx.cs" Inherits="SampleAngular.MappingTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/styles.css" rel="stylesheet" />

    <script src="js/jquery-2.1.1.min.js"></script>
      <script type="text/javascript" src="//www.google.com/jsapi"></script>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?key=AIzaSyAHtQ3Rdk72QCaXaZrt5h-1_YKLPscJ7cE&sensor=false&v=3&libraries=geometry,drawing"></script>

    <script src="js/Mapping.js"></script>
    <script>

        $(document).ready(function () {
            initMap();

            AddPin(-80.124663, 25.804071, "jorge's house", "desc");



        });

       

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="map_canvas" style="width:700px; height: 700px; float: left"></div>
    </div>
    </form>
</body>
</html>
