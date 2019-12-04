<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMIResult.aspx.cs" Inherits="P11_BMI_2.BMIResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BMI Rechner - Resultat</title>
    <link href="https://fonts.googleapis.com/css?family=Nunito&display=swap" rel="stylesheet">
    <style type="text/css">
        html, body
        {
            height: 100%;
        }
        body {
            font-family: 'Nunito', sans-serif;
            margin: 0;
            padding: 0;
            background: #e8f7fa;
        }
        body > div {
            padding: 0 20px;
            height: 100%;
        }
        body > div > div {
            min-height: 100%;
            background: white;
            max-width: 1000px; 
            margin: 0 auto;
            padding: 20px 40px;
            box-sizing: border-box;
        }
        body > div h1:first-child {
            padding-top: 0px;
            margin-top: 0px;
        }
        p {
            padding: 0;
            margin: 0 0 20px 0;
        }
        #Text1 {
            z-index: 1;
            left: 3px;
            top: 0px;
            position: absolute;
            height: 18px;
            width: 183px;
        }
        .auto-style1 {
            width: 170px;
        }
        .auto-style2 {
            position: relative;
            left: 0px;
            top: 0px;
            width: 360px;
            padding: 10px 5px;
        }
        .auto-style4 {
            width: 252px;
            height: 31px;
        }
        .auto-style5 {
            width: 100px;
            height: 31px;
        }
        .auto-style6 {
            text-align: right;
        }
        .auto-style7 {
        }
        .result-label {

        }
        input[type="submit"] {
            margin: 20px 0 20px 0;
        }
        .error-message {
            color: red;
            display: block;
        }
    </style>
</head>
<body>
    <div>
        <div>
            <h1>BMI Rechner - Resultat</h1>
            <div>
                <p>
                    Ihr BMI beträgt: <b><asp:Label ID="calculatedBMI" runat="server" Text="" CssClass="result-label"></asp:Label></b> 
                    (Grösse: <asp:Label ID="groesse2" runat="server" Text="" CssClass="result-label"></asp:Label> cm, 
                    Gewicht: <asp:Label ID="gewicht2" runat="server" Text="" CssClass="result-label"></asp:Label> kg)<br /><br />
                    <em>Diagnose: <asp:Label ID="result" runat="server" Text="" CssClass="result-label"></asp:Label></em>
                </p>
            </div>
        </div>
    </div>
</body>
</html>
