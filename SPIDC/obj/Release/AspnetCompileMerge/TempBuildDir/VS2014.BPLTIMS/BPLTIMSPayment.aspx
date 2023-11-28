<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.IMC/IMC.Master" CodeBehind="BPLTIMSPayment.aspx.vb" Inherits="IMC.BPLTIMSPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <br />    <br />    <br /> <br /> <br />
     <section id="speakers-details" >

   
      <div class="container">
        <div class="section-header">
          <h2>Online Payment</h2>
          <p>BPLTIMS - Payment</p>
        </div>

        <div class="row">
        <div class="col-lg-8">
            <div class="card mb-5 mb-lg-0">
              <div class="card-body">

                  Select Business Account
                  <hr />
                    <asp:UpdatePanel runat="server">
                      <ContentTemplate>
                <asp:GridView ID="GridView1" CssClass="footable" runat="server" AutoGenerateColumns="false"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                    OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged">           
                <Columns>
                    <asp:BoundField ItemStyle-Width="30%" DataField="BusinessAccountNo" HeaderText="Business Account No." />
                    <asp:BoundField DataField="CommercialName" HeaderText="Commercial Name" />
                   
                </Columns>
            </asp:GridView>
                          </ContentTemplate>
                  </asp:UpdatePanel>

                  </div>

                  <div class="card-body">

                  Transaction Details
                      <hr />
                      Business Account Number: <br />
                      Transaction Number: <br />
                      Transaction Date: <br />
                      Amount: <br />
  
                       <div class="text-center">
                  <button type="button" class="btn" data-toggle="modal" data-target="#buy-ticket-modal" data-ticket-type="pro-access">Print Billing Statement</button>
                </div>
                  </div>
                </div>
            
          
          </div>


            <div class="col-lg-4">
            <div class="card mb-5 mb-lg-0">           
             <div class="card-body">
                <h6 class="card-price text-center">Delivery Details</h6>
                <hr>
                 Pick up or Delivery
                 <br />
                 Courier 1<br />
                 Courier 2<br />
                 Courier 3<br />
                  <br /><br />        
           
              </div>
            </div>

                 <div class="card mb-5 mb-lg-0">           
             <div class="card-body">
                <h6 class="card-price text-center">Select Payment Channel</h6>
                <hr>
                DBP - Internet Payment Gateway <br />
                Land Bank - ePayment Portal <br />
                PayMaya<br />
                Gcash
                  <br /><br />
        
                <div class="text-center">
                  <button type="button" class="btn" data-toggle="modal" data-target="#buy-ticket-modal" data-ticket-type="pro-access">Pay Now</button>
                </div>
              </div>
            </div>


          </div>
          
        </div>
      </div>

    </section>

</asp:Content>
