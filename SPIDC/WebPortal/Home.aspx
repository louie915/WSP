<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="Home.aspx.vb" Inherits="SPIDC.Home"
   EnableEventValidation = false
     %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">



    <!-- First Photo Grid-->
    <div class="w3-row-padding">
        <div class="w3-quarter w3-container w3-margin-bottom card w3-hover-opacity m-2">
            <a href="#" runat="server" style="text-decoration: none" id="btnRPT">
                <center>
                        <img src="../CSS_JS_IMG/img/RPTAS.png" alt="RealProperty" style="height:100%; max-height: 40vh">
                </center>
                <div class="w3-container w3-white">
                    <p><b>Real Property</b></p>
                  
                </div>
            </a>
        </div>
        <div class="w3-quarter w3-container w3-margin-bottom card w3-hover-opacity  m-2">
            <a href="#" runat="server" style="text-decoration: none" id="btnBP">
                <center>
                        <img src="../CSS_JS_IMG/img/BPLTAS.png" alt="BusinessPermit" style="height: 100%; max-height: 40vh;filter: grayscale(100%);">
                </center>
                <div class="w3-container w3-white">
                    <p><b>Business Permit (Coming Soon...)</b></p>
                   </div>
            </a>
        </div>
    </div>

  <%--  <a href="#" runat="server" id="btnRPT" class="w3-container w3-card w3-half w3-white w3-round w3-margin">
        <br>
        <img src="../CSS_JS_IMG/img/RPTAS.png" alt="Avatar" class="w3-left w3-circle w3-margin-right" style="width: 60px">

        <h3>Real Property</h3>
        <br>
    </a>--%>

    <%-- <a href="#" runat="server" id="btnBP" class="w3-container w3-card w3-half w3-white w3-round w3-margin">
        <br>
        <img src="../CSS_JS_IMG/img/BPLTAS.png" alt="Avatar" class="w3-left w3-circle w3-margin-right" style="width: 60px">
        <h3>Business Permit</h3>
        <br>
    </a>--%>
</asp:Content>
