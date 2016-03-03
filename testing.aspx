﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testing.aspx.cs" Inherits="SampleAngular.testing" %>

<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <title>QUnit basic example</title>
  <link rel="stylesheet" href="css/qunit-1.15.0.css">
</head>
<body>
  <div id="qunit"></div>
  <div id="qunit-fixture"></div>
  <script src="js/qunit-1.15.0.js"></script>
  <script>
      QUnit.test("a basic test example", function (assert) {
          var value = "hello";
          assert.equal(value, "hello", "We expect value to be hello");
      });
  </script>
</body>
</html>