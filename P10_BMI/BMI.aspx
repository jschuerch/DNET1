<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMI.aspx.cs" Inherits="P10_BMI.BMI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BMI Rechner</title>
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
            <h1>BMI Rechner</h1>
            <form id="form1" runat="server" defaultbutton="Button1">
                <div style="min-height: 439px">
                    <table style="">
                        <tr>
                            <td></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="error-message" Display="Dynamic"
                                    ControlToValidate="gewicht" ErrorMessage="Sie müssen ein Gewicht in kg hier eintragen"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" MinimumValue="1" MaximumValue="1000" 
                                    CssClass="error-message" Display="Dynamic" Type="Double"
                                    ControlToValidate="gewicht" ErrorMessage="Das Gewicht muss zwischen 1 und 1000 kg liegen"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Gewicht in kg: </td>
                            <td>
                                <asp:TextBox ID="gewicht" Runat="server" style="margin-top: 0px;" CssClass="auto-style2"/>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="error-message" Display="Dynamic"
                                    ControlToValidate="groesse" ErrorMessage="Sie müssen eine Grösse in kg hier eintragen"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator2" runat="server" MinimumValue="1" MaximumValue="300" 
                                    CssClass="error-message" Display="Dynamic" Type="Double"
                                    ControlToValidate="groesse" ErrorMessage="Die Grösse muss zwischen 1 und 300 cm liegen"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Grösse in cm: </td>
                            <td>
                                <asp:TextBox ID="groesse" Runat="server" style="margin-top: 0px;" CssClass="auto-style2"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7"></td>
                            <td class="auto-style6">
                                <asp:Button ID="Reset" runat="server" CssClass="auto-style5" Text="Reset" OnClick="Reset_Click" />
                                <asp:Button ID="Button1" runat="server" CssClass="auto-style5" Text="Berechnen" OnClick="Button1_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <p>
                                    <asp:Label ID="calculatedBMI" runat="server" Text="" CssClass="result-label"></asp:Label><br />
                                    <asp:Label ID="result" runat="server" Text="" CssClass="result-label"></asp:Label>
                                </p>
                            </td>
                        </tr>
                    </table>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
