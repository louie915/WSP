<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.IMC/IMC.Master" CodeBehind="RPTIMSCertification.aspx.vb" Inherits="SPIDC.RPTIMSCertification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <script type="text/javascript">
         function getSelectedRPT(sBus) {
             document.getElementById('<%=txtSelectedRPT.ClientID%>').value = sBus.value;
             var BusName = document.getElementById('<%=cmbRPTAccount.ClientID%>');
             document.getElementById('<%=txtSelectedRPTName.ClientID%>').value = BusName.options[BusName.selectedIndex].text;
         }

         function getSelectedCertificate(sCer) {
             document.getElementById('<%=txtSelectedCertificate.ClientID%>').value = sCer.value;
            var CertName = document.getElementById('<%=cmbCertifications.ClientID%>');
            document.getElementById('<%=txtSelectedCertificateName.ClientID%>').value = CertName.options[CertName.selectedIndex].text;
        }
    </script>
    
 <!--==========================
     Certification Section
    ============================-->
    <section id="Certification" class="wow fadeInUp">
        <br />   <br />   <br />
      <div class="container">

        <div class="section-header">
          <h2>Certification</h2>
            <p>Real Property Certifications</p>
        </div>
          <center>             
               <asp:UpdatePanel runat="server">
    <ContentTemplate>
    

                   <asp:GridView ID="_oGridViewRequestStatus" CssClass="footable" runat="server" AutoGenerateColumns="false"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" allowpaging="true" pagesize="5"
                    OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged"  
                    ShowHeaderWhenEmpty="true" emptydatatext="No Records Found.">    

                    <Columns>
                    <asp:TemplateField HeaderText="Business Account No.">
                        <ItemTemplate>
                        <asp:Label ID="_oLabelBusinessAccountNo" runat="server" Text='<%# Eval("BusinessAccountNo")%>' />
                        </ItemTemplate>                                                                      
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Business Name">
                        <ItemTemplate>
                        <asp:Label ID="_oLabelBusinessName" runat="server" Text='<%# Eval("BusinessName")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Certificate Name">
                        <ItemTemplate>
                        <asp:Label ID="_oLabelCertificateName" runat="server" Text='<%# Eval("CertificateName")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="Request Date">
                        <ItemTemplate>
                        <asp:Label ID="_oLabelRequestDate" runat="server" Text='<%# Eval("RequestDate")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="Request Status">
                        <ItemTemplate>
                        <asp:Label ID="_oLabelRequestStatus" runat="server" Text='<%# Eval("RequestStatus")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
          </asp:GridView>

                     </ContentTemplate>    
    </asp:UpdatePanel>

          </center>
          <br />
 <center>
          <div class="col-lg-7">
            <div class="card mb-1 mb-lg-5">
              <div class="card-body">
                <h5 class="card-title text-muted text-uppercase text-center">Request Certificate</h5>                
                <hr>
                  <form action="" method="post">
  
                                  
            <div class="form-row">

              
                   <div class="form-group col-md-6">            
                  <select required runat="server" id="cmbRPTAccount" name="cmbRPTAccount" class="form-control" onchange="getSelectedRPT(this)" >   
                    <option value="" disabled selected>Select Business</option>                                
                  </select>

                </div> 
                
                   <div class="form-group col-md-6">            
                  <select required runat="server" id="cmbCertifications" name="cmbCertifications" class="form-control" onchange="getSelectedCertificate(this)" >   
                    <option value="" disabled selected>Select Certificate Type</option>                                  
                  </select>
                </div>
             </div>                                                                       
       
                <div class="text-center">         
                  <button type="button" class="btn" data-toggle="modal" data-target="#Request" data-ticket-type="standard-access">Request</button>
                 
                     </div>
 </form>

              </div>
            </div>
          </div>
     
     </center>
        </div>

         <!-- Modal Request Form -->
      <div id="Request" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Request Summary</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>

            <div class="modal-body">
               <form action="" method="post">
                <div class="form-group">                               
                     Business Account No.  <br />
                  <input  runat="server" class="form-control" readonly="true" id="txtSelectedRPT" ClientIDMode="Static"/>
                </div>
                    <div class="form-group">                               
                     Business Name        <br />
                   <input  runat="server" class="form-control" readonly="true" id="txtSelectedRPTName" ClientIDMode="Static"/>    
                </div>
                    <div class="form-group" style="display:none;">                               
                   Certificate Code     <br />
                 <input runat="server" class="form-control" readonly="true" id="txtSelectedCertificate" ClientIDMode="Static"/>
                </div>
                      <div class="form-group">                               
                   Selected Certificate     <br />
                   <input runat="server" class="form-control" readonly="true" id="txtSelectedCertificateName" ClientIDMode="Static"/>    
                </div>
                
               <div class="text-center">
                  <button type="submit" class="btn">Confirm</button>
                </div>
               </form>
            </div>



    
    </section>

  
   
</asp:Content>
