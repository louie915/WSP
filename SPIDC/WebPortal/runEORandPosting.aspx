<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="runEORandPosting.aspx.vb" Inherits="SPIDC.runEORandPosting" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Run EOR and Posting Gcash Payment Method</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous"/>
     <link rel="preconnect" href="https://fonts.gstatic.com"/>
     <link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700&display=swap" rel="stylesheet"/>
    <style>
          /*Font Style*/
        body {
            font-family: 'Lato', sans-serif;
        }
        input {
           opacity: 0.5;
           color: #212529;
       }
        select{
            opacity: 0.5;
            color: #212529;
        }
        .cube {
              top: -100px;
              margin: 200px auto 0;
              width: 100px;
              height: 100Px;
              position: relative;
              transform-style: preserve-3d;
              animation: spin 3s infinite cubic-bezier(0.16, 0.61, 0.49, 0.91);
            }

            .face {
              position: absolute;
              width: 100%;
              height: 100%;
              background: rgb(2 1 1);
              border: 2px solid #fff;
              border-radius: 5px;
              box-shadow: 0 0 15px #fff;
            }

            .top {
              transform: rotateX(90deg) translateZ(50px);
              animation: shift-top 3s infinite ease-out;
            }

            .bottom {
              transform: rotateX(-90deg) translateZ(50px);
              animation: shift-bottom 3s infinite ease-out;
            }

            .right {
              transform: rotateY(90deg) translateZ(50px);
              animation: shift-right 3s infinite ease-out;
            }

            .left {
              transform: rotateY(-90deg) translateZ(50px);
              animation: shift-left 3s infinite ease-out;
            }

            .front {
              transform: translateZ(50px);
              animation: shift-front 3s infinite ease-out;
            }

            .back {
              transform: rotateY(-180deg) translateZ(50px);
              animation: shift-back 3s infinite ease-out;
            }

            @keyframes spin {
              33% {
                transform: rotateX(-36deg) rotateY(-405deg);
              }

              100% {
                transform: rotateX(-36deg) rotateY(-405deg);
              }
            }

            @keyframes shift-top {
              33% {
                transform: rotateX(90deg) translateZ(50px);
              }

              50% {
                transform: rotateX(90deg) translateZ(100px);
              }

              60% {
                transform: rotateX(90deg) translateZ(100px);
              }

              75% {
                transform: rotateX(90deg) translateZ(50px);
              }
            }

            @keyframes shift-bottom {
              33% {
                transform: rotateX(-90deg) translateZ(50px);
              }

              50% {
                transform: rotateX(-90deg) translateZ(100px);
              }

              60% {
                transform: rotateX(-90deg) translateZ(100px);
              }

              75% {
                transform: rotateX(-90deg) translateZ(50px);
              }
            }

            @keyframes shift-right {
              33% {
                transform: rotateY(90deg) translateZ(50px);
              }

              50% {
                transform: rotateY(90deg) translateZ(100px);
              }

              60% {
                transform: rotateY(90deg) translateZ(100px);
              }

              75% {
                transform: rotateY(90deg) translateZ(50px);
              }
            }

            @keyframes shift-left {
              33% {
                transform: rotateY(-90deg) translateZ(50px);
              }

              50% {
                transform: rotateY(-90deg) translateZ(100px);
              }

              60% {
                transform: rotateY(-90deg) translateZ(100px);
              }

              75% {
                transform: rotateY(-90deg) translateZ(50px);
              }
            }

            @keyframes shift-front {
              33% {
                transform: translateZ(50px);
              }

              50% {
                transform: translateZ(100px);
              }

              60% {
                transform: translateZ(100px);
              }

              75% {
                transform: translateZ(50px);
              }
            }

            @keyframes shift-back {
              33% {
                transform: rotateY(-180deg) translateZ(50px);
              }

              50% {
                transform: rotateY(-180deg) translateZ(100px);
              }

              60% {
                transform: rotateY(-180deg) translateZ(100px);
              }

              75% {
                transform: rotateY(-180deg) translateZ(50px);
              }
            }


            .box {
                      position: relative;
                      width: 280px;
                      height: 45px;
                      overflow: hidden;
                      border: none;
                      background-color: rgb(235 231 226);
                      font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                      border-top-left-radius: 20px;
                      cursor: pointer;
                      border-bottom-right-radius: 20px;
                     box-shadow: 0 0 10px rgb(0 0 0);
                    }

                    .box::before {
                      content: "";
                      position: absolute;
                      width: 15px;
                      height: 200px;
                      margin-top: -92px;
                     background: linear-gradient(#000000,#000000);
                      animation: amm 4s linear infinite;
                    }

                    @keyframes amm {
                      0% {
                        transform: rotate(0deg);
                      }

                      100% {
                        transform: rotate(360deg);
                      }
                    }

                    .text-button {
                      position: relative;
                      font-size: 1.2rem;
                      font-weight: bold;
                      z-index: 1;
                      padding: 7px;
                    }

                    .box::after {
                      content: "";
                      position: absolute;
                      inset: 4px;
                      background-color: rgb(192 192 192);
                      border-top-left-radius: 20px;
                      border-bottom-right-radius: 20px;
                    }

    </style>
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager runat="server"></asp:ScriptManager>
    
            
           <div class="d-flex justify-content-center p-5">
            <div>
                <!-- Your content that you want to center -->
                   <div class="container">
                            <div class="row">
                                <div class="col-md-12 d-flex justify-content-center align-items-center" style="height: 100vh;">
                                    <div class="p-5 mb-4  rounded-4 col-md-12">
                                        <!-- Your content goes here -->
                                        <h1 class="display-6 fw-bold mb-4">RUN EOR AND POSTING <span id="_fieldtitle">TITLE</span> </h1>

                                        
                                        <div class="row mb-3">
                                            <label for="_PaymentMethod" class="col-sm-4 col-form-label fw-bold">Payment Method</label>
                                            <div class="col-sm-8">
                                                <select class="form-select" aria-label="paymentmethod" id="_paymentmethod">
                                                    <option selected="selected">Select Payment Method</option>
                                                    <option value="PAYMAYA">PAYMAYA</option>
                                                    <option value="GCASH">GCASH</option>
                                                    <option value="LBP1">LBP1</option>
                                                    <option value="LBP2">LBP2</option>
                                                </select>
                                            </div>
                                        </div>

                                           

                                        <!-- paymaya-->
                                        <div id="_paymayafield">
                                            <div class="row mb-3">
                                                <label for="_GatewayStatusPaymaya" class="col-sm-4 col-form-label fw-bold">Gateway Status</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_GatewayStatusPaymaya" readonly="readonly" value="SUCCESS" runat="server" />
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <label for="_PaymentReferencePaymaya" class="col-sm-4 col-form-label fw-bold">Payment Reference</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_PaymentReferencePaymaya" runat="server" />
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <label for="_GatewayReferencePaymaya" class="col-sm-4 col-form-label fw-bold">Gateway Reference</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_GatewayReferencePaymaya" runat="server" />
                                                </div>
                                            </div>

                                           <%-- <button class="btn btn-dark fw-bold" type="button" id="_btnRunEORandPostingPaymaya" runat="server">RUN EOR AND POSTING</button>--%>
                                           <button class="box" type="button" id="_btnRunEORandPostingPaymaya" runat="server"><p class="text-button">START EOR AND POSTING</p></button>

                                        </div>
                                          <!-- gcash-->
                                        <div id="_gcashfield">


                                            <div class="row mb-3">
                                                <label for="_GatewayStatusGcash" class="col-sm-4 col-form-label fw-bold">Gateway Status</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_GatewayStatusGcash" readonly="readonly" value="SUCCESS" runat="server" />
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <label for="_PaymentReferenceGcash" class="col-sm-4 col-form-label fw-bold">Payment Reference</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_PaymentReferenceGcash" runat="server" />
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <label for="_GatewayReferenceGcash" class="col-sm-4 col-form-label fw-bold">Gateway Reference</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_GatewayReferenceGcash" runat="server" />
                                                </div>
                                            </div>

                                            <%--<button class="btn btn-dark fw-bold" type="button" id="_btnRunEORandPostingGcash" runat="server">RUN EOR AND POSTING</button>--%>
                                            <button class="box" type="button" id="_btnRunEORandPostingGcash" runat="server"><p class="text-button">START EOR AND POSTING</p></button>
                                        </div>
                                          <!-- lbp1-->
                                        <div id="_lbp1field">
                                            <div class="row mb-3">
                                                <label for="inputEmail3" class="col-sm-4 col-form-label fw-bold">Gateway Status</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_GatewayStatusLBP1" readonly="readonly" value="SUCCESS" runat="server" />
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <label for="inputEmail3" class="col-sm-4 col-form-label fw-bold">Payment Reference</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_PaymentReferenceLBP1" runat="server" />
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <label for="inputPassword3" class="col-sm-4 col-form-label fw-bold">Gateway Reference</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_GatewayReferenceLBP1" runat="server" />
                                                </div>
                                            </div>

                                           <%-- <button class="btn btn-dark" type="button" id="_btnRunEORandPostingLBP1" runat="server">RUN EOR AND POSTING</button>--%>
                                            <button class="box" type="button" id="_btnRunEORandPostingLBP1" runat="server"><p class="text-button">START EOR AND POSTING</p></button>
                                        </div>

                                         <!-- lbp2-->
                                        <div id="_lbp2field">

                                            <div class="row mb-3">
                                                <label for="inputEmail3" class="col-sm-4 col-form-label fw-bold">Gateway Status</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_GatewayStatusLBP2" readonly="readonly" value="SUCCESS" runat="server" />
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <label for="inputEmail3" class="col-sm-4 col-form-label fw-bold">Payment Reference</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_PaymentReferenceLBP2" runat="server" />
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <label for="inputPassword3" class="col-sm-4 col-form-label fw-bold">Gateway Reference</label>
                                                <div class="col-sm-8">
                                                    <input type="text" class="form-control" id="_GatewayReferenceLBP2" runat="server" />
                                                </div>
                                            </div>

                                           <%-- <button class="btn btn-dark" type="button" id="_btnRunEORandPostingLBP2" runat="server">RUN EOR AND POSTING</button>--%>
                                            <button class="box" type="button" id="_btnRunEORandPostingLBP2" runat="server"><p class="text-button">START EOR AND POSTING</p></button>
                                        </div>
                                        

                                    </div>
                                </div>
                            </div>
                        </div>

                    <!--Loader-->
                    <div class="modal bg-light" id="apploader" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered">
                            <div class="modal-body">
                              <div class="container row d-flex justify-content-center align-items-center">
                                   
                                   <div class="loader cube">
                                        <div class="face front"></div>
                                        <div class="face back"></div>
                                        <div class="face right"></div>
                                        <div class="face left"></div>
                                        <div class="face top"></div>
                                        <div class="face bottom"></div>
                                    </div>
                                  <div class="col-md-12">
                                      <h3 class="text-center fw-bold loader-title">Loading...</h3>
                                  </div>
                                   

                                </div>
                            </div>
                        </div>
                    </div>
                    <!--End Loader-->


                 <rsweb:ReportViewer ID="Report_EOR" runat="server" AsynRendering="true" SizeToReportContent = "true" KeepSessionAlive="false">
                 </rsweb:ReportViewer>

            </div>
        </div>


       

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
     <script>

         var loader = new bootstrap.Modal(document.getElementById('apploader'));
         document.onreadystatechange = function () {
             if (document.readyState !== "complete") {
                 loader.show();
             } else {
                 loader.hide();
                 mainPage()
                 gateWaySessionChecker();
             }
         };


         document.getElementById("_paymentmethod").addEventListener("change", function () {
             var selectedOption = this.value;
             if (selectedOption === "PAYMAYA") {
                 var body = document.body;
                 body.style.backgroundImage = 'url("https://scontent.fceb2-2.fna.fbcdn.net/v/t1.6435-9/35542983_901301470206700_9007371053432832_n.png?_nc_cat=104&ccb=1-7&_nc_sid=7a1959&_nc_eui2=AeEU3mQPo6U1EHmCOgyr0JC6oboZnStpIDmhuhmdK2kgOWhQEbVMtkKagFmLY7tNd3Z7ztSj0JAWxr2KgjhxzmJR&_nc_ohc=9AfhmhbHq_YAX-mNay-&_nc_ht=scontent.fceb2-2.fna&oh=00_AfCEnvBkwPrkPcB_rmGg16BTU0eSGUYnQaruQpqU3Eqn1w&oe=657259CA")';
                 body.style.backgroundSize = 'cover';
                 body.style.backgroundRepeat = 'no-repeat';
                 body.style.backgroundPosition = 'center center';
                 document.getElementById("_paymentmethod").style.display = "block";
                 document.getElementById("_fieldtitle").textContent = selectedOption.toUpperCase();
                 document.getElementById("_paymayafield").style.display = "block";
                 document.getElementById("_gcashfield").style.display = "none";
                 document.getElementById("_lbp1field").style.display = "none";
                 document.getElementById("_lbp2field").style.display = "none";

             } else if (selectedOption === "GCASH") {
                 var body = document.body;
                 body.style.backgroundImage = 'url("https://logos-download.com/wp-content/uploads/2020/06/GCash_Logo-700x618.png")';
                 body.style.backgroundSize = 'cover';
                 body.style.backgroundRepeat = 'no-repeat';
                 body.style.backgroundPosition = 'center center';
                 document.getElementById("_fieldtitle").textContent = selectedOption.toUpperCase();
                 document.getElementById("_paymayafield").style.display = "none";
                 document.getElementById("_gcashfield").style.display = "block";
                 document.getElementById("_lbp1field").style.display = "none";
                 document.getElementById("_lbp2field").style.display = "none";

             } else if (selectedOption === "LBP1") {
                 var body = document.body;
                 body.style.backgroundImage = 'url("https://www.akamai.com/site/en/images/logo/landbank-logo-2017.svg")';
                 body.style.backgroundSize = 'cover';
                 body.style.backgroundRepeat = 'no-repeat';
                 body.style.backgroundPosition = 'center center';
                 document.getElementById("_fieldtitle").textContent = "LANDBANK ePayment Portal".toUpperCase();
                 document.getElementById("_paymayafield").style.display = "none";
                 document.getElementById("_gcashfield").style.display = "none";
                 document.getElementById("_lbp1field").style.display = "block";
                 document.getElementById("_lbp2field").style.display = "none";

             } else if (selectedOption === "LBP2") {
                 var body = document.body;
                 body.style.backgroundImage = 'url("https://www.akamai.com/site/en/images/logo/landbank-logo-2017.svg")';
                 body.style.backgroundSize = 'cover';
                 body.style.backgroundRepeat = 'no-repeat';
                 body.style.backgroundPosition = 'center center';
                 document.getElementById("_fieldtitle").textContent = "LINK.BIZ PORTAL".toUpperCase();
                 document.getElementById("_paymayafield").style.display = "none";
                 document.getElementById("_gcashfield").style.display = "none";
                 document.getElementById("_lbp1field").style.display = "none";
                 document.getElementById("_lbp2field").style.display = "block";

             }
         });

         function mainPage() {
             var body = document.body;
             body.style.backgroundImage = 'url("")';
             body.style.backgroundSize = 'cover';
             body.style.backgroundRepeat = 'no-repeat';
             body.style.backgroundPosition = 'center center';
             document.getElementById("_fieldtitle").textContent = "";
             document.getElementById("_paymayafield").style.display = "none";
             document.getElementById("_gcashfield").style.display = "none";
             document.getElementById("_lbp1field").style.display = "none";
             document.getElementById("_lbp2field").style.display = "none";
         }


         function gateWaySessionChecker() {
             var _sessiongateWay = sessionStorage.getItem('_gateWay');
             if (_sessiongateWay === "") {
             } else {
                 if (_sessiongateWay === "PAYMAYA") {
                     var body = document.body;
                     body.style.backgroundImage = 'url("https://scontent.fceb2-2.fna.fbcdn.net/v/t1.6435-9/35542983_901301470206700_9007371053432832_n.png?_nc_cat=104&ccb=1-7&_nc_sid=7a1959&_nc_eui2=AeEU3mQPo6U1EHmCOgyr0JC6oboZnStpIDmhuhmdK2kgOWhQEbVMtkKagFmLY7tNd3Z7ztSj0JAWxr2KgjhxzmJR&_nc_ohc=9AfhmhbHq_YAX-mNay-&_nc_ht=scontent.fceb2-2.fna&oh=00_AfCEnvBkwPrkPcB_rmGg16BTU0eSGUYnQaruQpqU3Eqn1w&oe=657259CA")';
                     body.style.backgroundSize = 'cover';
                     body.style.backgroundRepeat = 'no-repeat';
                     body.style.backgroundPosition = 'center center';
                     document.getElementById("_paymentmethod").value = _sessiongateWay;
                     document.getElementById("_fieldtitle").textContent = _sessiongateWay.toUpperCase();
                     document.getElementById("_paymayafield").style.display = "block";
                     document.getElementById("_gcashfield").style.display = "none";
                     document.getElementById("_lbp1field").style.display = "none";
                     document.getElementById("_lbp2field").style.display = "none";

                 } else if (_sessiongateWay === "GCASH") {
                     var body = document.body;
                     body.style.backgroundImage = 'url("https://logos-download.com/wp-content/uploads/2020/06/GCash_Logo-700x618.png")';
                     body.style.backgroundSize = 'cover';
                     body.style.backgroundRepeat = 'no-repeat';
                     body.style.backgroundPosition = 'center center';

                     document.getElementById("_paymentmethod").value = _sessiongateWay;
                     document.getElementById("_fieldtitle").textContent = _sessiongateWay.toUpperCase();
                     document.getElementById("_paymayafield").style.display = "none";
                     document.getElementById("_gcashfield").style.display = "block";
                     document.getElementById("_lbp1field").style.display = "none";
                     document.getElementById("_lbp2field").style.display = "none";


                 } else if (_sessiongateWay === "LBP1") {
                     var body = document.body;
                     body.style.backgroundImage = 'url("https://www.akamai.com/site/en/images/logo/landbank-logo-2017.svg")';
                     body.style.backgroundSize = 'cover';
                     body.style.backgroundRepeat = 'no-repeat';
                     body.style.backgroundPosition = 'center center';
                     document.getElementById("_paymentmethod").value = _sessiongateWay;
                     document.getElementById("_fieldtitle").textContent = "LANDBANK ePayment Portal".toUpperCase();
                     document.getElementById("_paymayafield").style.display = "none";
                     document.getElementById("_gcashfield").style.display = "none";
                     document.getElementById("_lbp1field").style.display = "block";
                     document.getElementById("_lbp2field").style.display = "none";

                 } else if (_sessiongateWay === "LBP2") {
                     var body = document.body;
                     body.style.backgroundImage = 'url("https://www.akamai.com/site/en/images/logo/landbank-logo-2017.svg")';
                     body.style.backgroundSize = 'cover';
                     body.style.backgroundRepeat = 'no-repeat';
                     body.style.backgroundPosition = 'center center';
                     document.getElementById("_paymentmethod").value = _sessiongateWay;
                     document.getElementById("_fieldtitle").textContent = "LINK.BIZ PORTAL".toUpperCase();
                     document.getElementById("_paymayafield").style.display = "none";
                     document.getElementById("_gcashfield").style.display = "none";
                     document.getElementById("_lbp1field").style.display = "none";
                     document.getElementById("_lbp2field").style.display = "block";
                 }

             }
         }

     </script>   


    </form>
    </body>
</html>
