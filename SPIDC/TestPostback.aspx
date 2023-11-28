<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TestPostback.aspx.vb" Inherits="SPIDC.TestPostback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>


  
 
   
    <input type="file" name="fileInput" id="fileInput"/>
    <br />
    <input type="text" name="txtID" id="txtID" placeholder="cbp_transaction_no" />
    <br /> <br />
     <input type="button" value="submit" onclick="do_submit(fileInput.files[0],txtID.value)" />


    <script>
        function do_submit(img, txtID) {          
            var data = new FormData();
            data.append("data", "{\n\"company_information\": {\n\"verified_company_name\": \"ABC Business\",\n\"cbp_transaction_no\": \"" + txtID + "\",\n\"company_registration_no\": \"2021060006483-01\",\n\"tradename\": \"Trade name 1\",\n\"statement\": \"doing business under the name/s and style/s of\",\n\"type_of_business\": \"retailer\",\n},\n\"authorized_representative\": {\n\"first_name\": \"Juan\",\n\"middle_name\": \"Santos\",\n\"last_name\": \"dela Cruz\",\n\"suffix\": \"Jr\",\n\"sex\": \"Male\",\n\"birthday\": \"\",\n\"nationality\": \"Filipino\",\n\"tin_number\": \"112-312-311-000\",\n\"position\": \"President\",\n\"role\": \"\",\n\"address\": {\n\"zip_code\": \"1008\",\n\"region\": \"NCR\",\n\"province\": \"Second District\",\n\"town\": \"District 2\",\n\"municipality\": \"City of Pasig\",\n\"barangay\": \"Bagong Ilog\",\n\"subdivision\": \"Brentville Internationaasl\",\n\"street_name\": \"Frontier Street\",\n\"bldg_no\": \"Building # 12\",\n\"bldg_name\": \"Sunrise Tower\",\n\"house_no\": \"Lot 11\"\n },\n\"contact_numbers\": {\n\"email_address\": \"sample@email.com\",\n\"alternate_email_address\": \"alternate@email.com\",\n\"mobile_no\": \"9171234567\",\n\"landline\": \"89200101\",\n\"local\": \"1004\"\n },\n\"foreign_address\": {\n\"country\": \"Japan\",\n\"address\": \"Tokyo, Japan\"\n },\n\"foreign_contact_numbers\": {\n\"country_code\": \"\",\n\"telephone_number\": \"\"\n }\n},\n\"business_details\": {\n\"company_type\": \"Non-stock Corporation\",\n\"company_sub_type\": \"Corporation Sole\",\n\"company_classification\": \"ALL FILIPINO\",\n\"economic_zone\": \"\",\n\"economic_zone_location\": \"\",\n\"enterprise_type\": \"\",\n\"tin_number\": \"\",\n\"capital_structure\": {\n\"authorized_capital_stock\": \"1000000\",\n\"with_par_value_per_share\": \"500000\",\n\"without_par_value_per_share\": \"500000\",\n\"with_and_without_par_value_per_share\": \"500000\",\n\"subscribed_capital_stock\": \"500000\",\n\"paid_up_capital_stock\": \"500000\",\n\"total_contribution\": \"500000\",\n\"industry_classification_division\": \"Manufacturing\",\n\"industry_classification_group\": \"Casting of Metals\",\n\"primary_purpose\": \"Seller of Mask\",\n\"secondary_purpose\": \"Seller of Mask and other goods\",\n\"business_activities\": \"Import/Export/Service/Manufacturing\"\n },\n\"principal_office_address\": {\n\"zip_code\": \"1101\",\n\"region_code\": \"NCR\",\n\"province_code\": \"137400000\",\n\"city_code\": \"137404000\",\n\"region\": \"NCR\",\n\"province\": \"Second District\",\n\"town\": \"Test Town\",\n\"municipality\": \"Quezon City\",\n\"barangay\": \"UP Campus\",\n\"subdivision\": \"Brentville Subdivision\",\n\"street_name\": \"Frontier St\",\n\"bldg_no\": \"Building # 3\",\n\"bldg_name\": \"Test Building\",\n\"house_no\": \"Lot 2\",\n\"landline\": \"89200101\",\n\"local\": \"1004\",\n\"mobile_no\": \"9157894561\",\n\"email_address\": \"sample@email.com\"\n }\n},\n\"scope_type\": {\n\"territorial_region\": \"\",\n\"territorial_city\": \"\",\n\"territorial_barangay\": \"\",\n\"dominant_name\": \"\",\n\"date_of_birth\": \"\",\n\"business_name_number\": \"\"\n}\n}\n");
            data.append("ECertFile", img, "[PROXY]");

            var xhr = new XMLHttpRequest();
            xhr.withCredentials = true;
            xhr.addEventListener("readystatechange", function () {
                if (this.readyState === 4) {
                    alert(this.responseText);
                
                }
            });

            xhr.open("POST", "https://online.caloocancity.gov.ph/API/api/CBP_Data");
            xhr.setRequestHeader("Authorization", "Basic c3BpZGN3ZWJhcGk6c3BpZGN3ZWJhcGlwYXNzd29yZA==");
            xhr.send(data);
        }

    </script>

</body>
</html>
