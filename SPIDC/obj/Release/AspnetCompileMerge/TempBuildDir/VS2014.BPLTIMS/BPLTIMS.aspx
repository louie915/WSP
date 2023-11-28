<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.IMC/IMC.Master" CodeBehind="BPLTIMS.aspx.vb" Inherits="IMC.BPLTIMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <!--==========================
     BPLTIMS Section
    ============================-->
    <section id="BPLTIMS" class="wow fadeInUp">
        <br />   <br />   <br />
      <div class="container">

        <div class="section-header">
          <h2>BPLTIMS</h2>
            <p>Business Permit Licensing Tax Information Management System</p>
        </div>

        <div class="row justify-content-center">
          <div class="col-lg-9">
              <ul id="BPLTIMS-list">

                <li>
                  <a data-toggle="collapse" class="collapsed" href="#BPLTIMS1">Business Application <i class="fa fa-minus-circle"></i></a>
                  <div id="BPLTIMS1" class="collapse" data-parent="#BPLTIMS-list">
                     <ul>
                         <li><a href="#" data-toggle="modal" data-target="#NewBusReq" data-ticket-type="standard-access">New Business Application</a></li>
                         <li><a href="#">Re-new Business Application</a></li> 
                     </ul> 
                  </div>
                </li>

                    <li>
                  <a data-toggle="collapse" class="collapsed" href="#BPLTIMS2">Certification <i class="fa fa-minus-circle"></i></a>
                  <div id="BPLTIMS2" class="collapse" data-parent="#BPLTIMS-list">
                     <ul>
                         <li><a href="BPLTIMSCertification.aspx">Proceed to Certification</a></li> 
                     </ul> 
                  </div>
                </li>
      
                <li>
                  <a data-toggle="collapse" href="#BPLTIMS3" class="collapsed">Application Status<i class="fa fa-minus-circle"></i></a>
                  <div id="BPLTIMS3" class="collapse" data-parent="#BPLTIMS-list">
                   <ul>
                         <li><a href="#">New Business Application Status</a></li>
                         <li><a href="#">Re-new Business Application Status</a></li> 
                     </ul> 
                  </div>
                </li>
      
                <li>
                  <a data-toggle="collapse" href="#BPLTIMS4" class="collapsed">Assessment Billing <i class="fa fa-minus-circle"></i></a>
                  <div id="BPLTIMS4" class="collapse" data-parent="#BPLTIMS-list">
                     <ul>
                         <li><a href="#">Proceed to Assessment Billing </a></li>                    
                     </ul> 
                     
                  </div>
                </li>
      
                <li>
                  <a data-toggle="collapse" href="#BPLTIMS5" class="collapsed">Payment <i class="fa fa-minus-circle"></i></a>
                  <div id="BPLTIMS5" class="collapse" data-parent="#BPLTIMS-list">
                      <ul>
                         <li><a href="BPLTIMSPayment.aspx"> Proceed to Payment </a></li>                    
                     </ul> 
                    
                  </div>
                </li>
      
           
             
      
              </ul>
          </div>
        </div>

      </div>

    </section>

    
      <!-- Modal New Business Requirements Form -->
      <div id="NewBusReq" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">New Business Application</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
            <div class="card mb-5 mb-lg-0">
              <div class="card-body">  
                <h6 class="card-price text-center">Please Make sure you have the following requirements before you proceed</h6>
                <hr>
                <ul class="fa-ul">
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Valid IDs</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Valid IDs</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Valid IDs</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Valid IDs</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Valid IDs</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Valid IDs</li>
                </ul>
       
               
              </div>
            </div>
          </div>

                  <div class="text-center">
                  <button type="submit" class="btn">Proceed</button>
                </div>
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->

    <br />  <br />  <br />
</asp:Content>
