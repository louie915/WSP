<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.IMC/IMC.Master" CodeBehind="RPTIMS.aspx.vb" Inherits="SPIDC.RPTIMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!--==========================
     RPTIMS Section
    ============================-->
    <section id="RPTIMS" class="wow fadeInUp">
        <br />   <br />   <br />
      <div class="container">

        <div class="section-header">
          <h2>RPTIMS</h2>
            <p>Real Property Tax Information Management System</p>
        </div>

        <div class="row justify-content-center">
          <div class="col-lg-9">
              <ul id="RPTIMS-list">     
                  
                     <li>
                  <a data-toggle="collapse" class="collapsed" href="#RPTIMS1">Certificate Application <i class="fa fa-minus-circle"></i></a>
                  <div id="RPTIMS1" class="collapse" data-parent="#RPTIMS-list">
                     <ul>
                         <li><a href="RPTIMSCertification.aspx">Proceed to Certification</a></li> 
                     </ul> 
                  </div>
                </li> 
      
                <li>
                  <a data-toggle="collapse" href="#RPTIMS2" class="collapsed">Assessment Billing <i class="fa fa-minus-circle"></i></a>
                  <div id="RPTIMS2" class="collapse" data-parent="#RPTIMS-list">
                     <ul>
                         <li><a href="RPTIMSAssessmentBilling.aspx">Proceed to Assessment Billing </a></li>                    
                     </ul> 
                     
                  </div>
                </li>
      
                <li>
                  <a data-toggle="collapse" href="#RPTIMS3" class="collapsed">Payment <i class="fa fa-minus-circle"></i></a>
                  <div id="RPTIMS3" class="collapse" data-parent="#RPTIMS-list">
                      <ul>
                         <li><a href="#"> Proceed to Payment </a></li>                    
                     </ul> 
                    
                  </div>
                </li>
      
              </ul>
          </div>
        </div>

      </div>

    </section>

     <br />  <br />  <br />
      <br />  <br />  <br />
    <br />  <br />  <br />
</asp:Content>
