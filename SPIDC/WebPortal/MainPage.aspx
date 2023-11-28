<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="MainPage.aspx.vb" Inherits="SPIDC.MainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form runat="server"> 
    <div class="row justify-content-center align-items-center card" >
                            <div class="col-xl-12 col-lg-12">
                                <div class=" mb-0 " style="background-color:white">                                                                        
                                    <div class=" row">


                                        <div class="form-row col-md-6 m-0 row ">
                                            <div class="col-lg-12 m-2">
                                                    <h6 class="m-0 font-weight-bold text-primary">Enroll Business:</h6>
                                                </div>
                                            <div class="form-group col-md-3">
                                                <div>

                                                    <label>
                                                        <span style="background-color: white;"><span style="margin: 0px 5px 5px 5px;">Enter Bin </span></span>
                                                    </label>
                                                    <input type="text" class="form-control" required="" autocomplete="off" placeholder="Enter BIN *">
                                                </div>
                                            </div>

                                            <div class="form-group col-md-3">
                                                <div>
                                                    <label>
                                                        <span style="background-color: white;"><span style="margin: 0px 5px 5px 5px;">Enter OR No.</span></span>
                                                    </label>
                                                    <input type="text" class="form-control" required="" autocomplete="off" placeholder="Enter OR No. *">
                                                </div>

                                            </div>
                                            <div class="form-group col-md-6">
                                                <button form="frmSignUp" name="btnEnroll" id="btnEnroll" type="submit" class="btn btn-primary btn-user btn-block col-sm-4 right">Enroll</button>
                                            </div>


                                            
                                        </div>
                                        
                                        <div class="form-row col-md-6 m-0 row">
                                            <div class="col-lg-12 m-2">
                                                    <h6 class="m-0 font-weight-bold text-primary">Enroll Property:</h6>
                                                </div>
                                            <div class="form-group col-md-3">
                                                <div>

                                                    <label>
                                                        <span style="background-color: white;"><span style="margin: 0px 5px 5px 5px;">Enter TDN </span></span>
                                                    </label>
                                                    <input type="text" class="form-control" required="" autocomplete="off" placeholder="Enter BIN *">
                                                </div>
                                            </div>

                                            <div class="form-group col-md-3">
                                                <div>
                                                    <label>
                                                        <span style="background-color: white;"><span style="margin: 0px 5px 5px 5px;">Enter OR No.</span></span>
                                                    </label>
                                                    <input type="text" class="form-control" required="" autocomplete="off" placeholder="Enter OR No. *">
                                                </div>

                                            </div>
                                            <div class="form-group col-md-6">
                                                <button form="frmSignUp" name="btnEnroll" id="btnEnroll" type="submit" class="btn btn-primary btn-user btn-block col-sm-4 right">Enroll</button>
                                            </div>


                                            
                                        </div>
                                        
                                    </div>
                                </div>
                                <div class="card shadow mb-4">
                                    <div class="card-header py-3">
                                        <h6 class="m-0 font-weight-bold text-primary">Business Permit Account</h6>
                                    </div>
                                    <div class="card-body">
                                        <div class="table-responsive">
                                            <div id="dataTable_wrapper" class="dataTables_wrapper dt-bootstrap4">
                                                <div class="row">
                                                    <div class="col-sm-12 col-md-6">
                                                        <div class="dataTables_length" id="dataTable_length">
                                                            <label>
                                                                Show
                                                        <select name="dataTable_length" aria-controls="dataTable" class="custom-select custom-select-sm form-control form-control-sm">
                                                            <option value="10">10</option>
                                                            <option value="25">25</option>
                                                            <option value="50">50</option>
                                                            <option value="100">100</option>
                                                        </select>
                                                                entries</label>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12 col-md-6">
                                                        <div id="dataTable_filter" class="dataTables_filter">
                                                            <label>Search:<input type="search" class="form-control form-control-sm" placeholder="" aria-controls="dataTable"></label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <table class="table table-striped table-bordered dataTable" id="dataTable" width="100%" cellspacing="0" role="grid" aria-describedby="dataTable_info" style="width: 100%;">
                                                            <thead>
                                                                <tr role="row">
                                                                    <th class="sorting_asc" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Bus. ID Number: activate to sort column descending" style="width: 500px; font-size: 15px">Bus. ID Number</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Bus. Owner/Manager: activate to sort column ascending" style="width: 500px; font-size: 15px">Bus. Owner/Manager</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Business Name: activate to sort column ascending" style="width: 500px; font-size: 15px">Business Name</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Bus Addres: activate to sort column ascending" style="width: 1000px; font-size: 15px">Bus Address</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Category: activate to sort column ascending" style="width: 68px; font-size: 15px">Category</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action1: activate to sort column ascending" style="width: 67px; font-size: 15px"></th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action2: activate to sort column ascending" style="width: 500px; font-size: 15px">Action</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action3: activate to sort column ascending" style="width: 67px; font-size: 15px"></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr role="row" class="odd">
                                                                    <td class="sorting_1">B-01902</td>
                                                                    <td>Archie Escober</td>
                                                                    <td>Chiechie's Shop</td>
                                                                    <td>Bagbaguin, Sta. Maria Bulacan</td>
                                                                    <td>Services</td>
                                                                    <td><a href="#">Information</a></td>
                                                                    <td><a href="#">Other Trans</a></td>
                                                                    <td><a href="#">Renew</a></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <!--div class="row"><div class="col-sm-12 col-md-5"><div class="dataTables_info" id="dataTable_info" role="status" aria-live="polite">Showing 1 to 10 of 57 entries</div></div><div class="col-sm-12 col-md-7">v</div></!--div></div-->
                                            </div>
                                        </div>
                                    </div>  
                                    
                                    <div class="card-header py-3">
                                        <h6 class="m-0 font-weight-bold text-primary">Real Property Account</h6>
                                    </div>
                                    <div class="card-body">
                                        <div class="table-responsive">
                                            <div id="dataTable_wrapper" class="dataTables_wrapper table dt-bootstrap4">
                                                <div class="row">
                                                    <div class="col-sm-12 col-md-6">
                                                        <div class="dataTables_length" id="dataTable_length">
                                                            <label>
                                                                Show
                                                        <select name="dataTable_length" aria-controls="dataTable" class="custom-select custom-select-sm form-control form-control-sm">
                                                            <option value="10">10</option>
                                                            <option value="25">25</option>
                                                            <option value="50">50</option>
                                                            <option value="100">100</option>
                                                        </select>
                                                                entries</label>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12 col-md-6">
                                                        <div id="dataTable_filter" class="dataTables_filter">
                                                            <label>Search:<input type="search" class="form-control form-control-sm" placeholder="" aria-controls="dataTable"></label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <table class="table table-striped table-bordered dataTable" id="dataTable" width="100%" cellspacing="0" role="grid" aria-describedby="dataTable_info" style="width: 100%;">
                                                            <thead>
                                                                <tr role="row">
                                                                    <th class="sorting_asc" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Tax. Dec. No: activate to sort column descending" style="width: 500px; font-size: 15px">Tax. Dec. No</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="PIN: activate to sort column ascending" style="width: 1200px; font-size: 15px">PIN</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Kind: activate to sort column ascending" style="width: 300px; font-size: 15px">Kind</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Declared Owner: activate to sort column ascending" style="width: 500px; font-size: 15px">Declared Owner</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Property Location: activate to sort column ascending" style="width: 1800px; font-size: 15px">Property Location</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action1: activate to sort column ascending" style="width: 67px; font-size: 15px"></th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action2: activate to sort column ascending" style="width: 500px; font-size: 15px">Action</th>
                                                                    <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action3: activate to sort column ascending" style="width: 67px; font-size: 15px"></th>
                                                                </tr>
                                                            </thead>
                                                            <%--<tfoot>
                                                        <tr>
                                                            <th class="sorting_asc" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Bus. ID Number: activate to sort column descending" style="width: 300px;">Bus. ID Number</th>
                                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Bus. Owner/Manager: activate to sort column ascending" style="width: 300px;">Bus. Owner/Manager</th>
                                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Business Name: activate to sort column ascending" style="width: 300px;">Business Name</th>
                                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Bus Addres: activate to sort column ascending" style="width: 1000px;">Bus Address</th>
                                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Category: activate to sort column ascending" style="width: 68px;">Category</th>
                                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action1: activate to sort column ascending" style="width: 67px;"></th>
                                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action2: activate to sort column ascending" style="width: 500px;">Action</th>
                                                            <th class="sorting" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action3: activate to sort column ascending" style="width: 67px;"></th>
                                                        </tr>
                                                    </tfoot>--%>
                                                            <tbody>
                                                                <tr role="row" class="odd">
                                                                    <td class="sorting_1">2008-12414</td>
                                                                    <td>193-01-002-01-102</td>
                                                                    <td>Land</td>
                                                                    <td>Archie Escober</td>
                                                                    <td>Bagbaguin, Sta Maria Bulacan</td>
                                                                    <td><a href="#">Information</a></td>
                                                                    <td><a href="#">Other Trans</a></td>
                                                                    <td><a href="#">Billing</a></td>
                                                                </tr>
                                                                <tr role="row" class="even">
                                                                    <td class="sorting_1">2010-01230</td>
                                                                    <td>193-07-048-01-509</td>
                                                                    <td>Land</td>
                                                                    <td>Veronica Astronomo</td>
                                                                    <td>Caypombo, Sta Maria Bulacan</td>
                                                                    <td><a href="#">Information</a></td>
                                                                    <td><a href="#">Other Trans</a></td>
                                                                    <td><a href="#">Billing</a></td>
                                                                </tr>

                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <!--div class="row"><div class="col-sm-12 col-md-5"><div class="dataTables_info" id="dataTable_info" role="status" aria-live="polite">Showing 1 to 10 of 57 entries</div></div><div class="col-sm-12 col-md-7">v</div></!--div></div-->
                                            </div>
                                        </div>
                                    </div>                                  
                                </div>                                
                            </div>                            
                        </div>
         </form>
</asp:Content>
