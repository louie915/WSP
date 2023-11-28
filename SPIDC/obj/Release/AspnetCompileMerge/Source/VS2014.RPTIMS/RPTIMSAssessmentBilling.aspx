<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.IMC/IMC.Master" EnableEventValidation = "false"
    CodeBehind="RPTIMSAssessmentBilling.aspx.vb" Inherits="IMC.RPTIMSAssessmentBilling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .radio-toolbar {
  margin: 10px;
}

.radio-toolbar input[type="radio"] {
  opacity: 0;
  position: fixed;
  width: 0;
}

.radio-toolbar label {
    display: inline-block;
    background-color: #ddd;
    padding: 10px 20px;
    font-family: sans-serif, Arial;
    font-size: 16px;
    border: 2px solid #444;
    border-radius: 4px;
}

.radio-toolbar label:hover {
  background-color: gray;
}



.radio-toolbar input[type="radio"]:checked + label {
    background-color: white; 
    border-color: gray;
}

    </style>

   
      <!--==========================
      Assessment Billing Section
    ============================-->  
    <section id="contact">
        <br />  <br />  <br />
     
      <div class="container">
     
        <div class="section-header">
        
          <p>RPTIMS - Assessment Billing</p>
        </div>     
               
        <div class="form">          
            <div class="form-row">
             
              <div class="form-group col-md-2" >
                  <select id="cmbSearch" name="" class="form-control" >
                    <option value="" selected disabled>Search By</option>
                    <option value="PIN">PIN</option>
                    <option value="TDN">TDN</option>
                    <option value="OwnerNo">Owner No.</option>
                  </select>
                </div>
              <div class="form-group col-md-6">
                <input type="search" name="search" class="form-control" id="search" placeholder="Search..." />
                <div class="validation"></div>
              </div>
              <div class="form-group col-md-12">
                  <asp:UpdatePanel runat="server">
                      <ContentTemplate>
                          <div style="overflow-x:scroll">
                <asp:GridView ID="_oGridViewAssessmentBilling" CssClass="footable" runat="server" AutoGenerateColumns="false"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" allowpaging="true" pagesize="5"
                    OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged"  
                    ShowHeaderWhenEmpty="true" emptydatatext="No Records Found.">    
                <Columns>
                    <asp:BoundField DataField="OwnerNo" HeaderText="Owner No." />
                    <asp:BoundField DataField="Note" HeaderText="Note" />
                    <asp:BoundField DataField="FundType" HeaderText="Fund Type" />
                    <asp:BoundField DataField="TDN" HeaderText="TDN" />
                    <asp:BoundField DataField="TransCode" HeaderText="Trans Code" />
                    <asp:BoundField DataField="PIN" HeaderText="PIN" />
                    <asp:BoundField DataField="LastCoveredPaid" HeaderText="Last Covered Paid" />
                    <asp:BoundField DataField="LastAmountPaid" HeaderText="Last Amount Paid" />
                    <asp:BoundField DataField="LastOR" HeaderText="Last OR" />
                    <asp:BoundField DataField="LastSRS" HeaderText="Last SRS" />
                    <asp:BoundField DataField="LastORDate" HeaderText="Last OR Date" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                </Columns>
               
            </asp:GridView>
                              </div>
                          </ContentTemplate>
                  </asp:UpdatePanel>
            </div>   
             
            </div>
        </div>   <a href="#" data-toggle="modal" data-target="#SetQuarter" data-ticket-type="standard-access">Set Quarter</a>
         
     </div>
   
    </section>      
    <!-- #contact -->

      <!-- Modal Set Quarter Form -->
      <div id="SetQuarter" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Set Quarter and Year </h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
            <div class="card mb-5 mb-lg-0">
              <div class="card-body">  
                    <center>
              <div class="radio-toolbar">
                
     
                <input type="radio" id="1st" name="radioFruit" value="1st" checked>
                <label for="1st">1st Quarter</label>

                <input type="radio" id="2nd" name="radioFruit" value="2nd">
                <label for="2nd">2nd Quarter</label>
            
                <input type="radio" id="3rd" name="radioFruit" value="3nd">
                <label for="3rd">3rd Quarter</label> 

                <input type="radio" id="4th" name="radioFruit" value="4th">
                <label for="4th">4th Quarter</label> 

                    
            </div>
                  <div class="col-lg-9">
               <input type="text" name="name" class="form-control"placeholder="Enter Year" style="text-align:center" />
             </div>
                  </center>
              </div>
            </div>
          </div>

                  <div class="text-center">
                  <button type="submit" class="btn">Ok</button>
                </div>
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->
   
</asp:Content>
