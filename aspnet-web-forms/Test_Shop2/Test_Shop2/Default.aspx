<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Test_Shop2._Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>Send POST Request using html IFRAME</title>
</head>
<body>
    <h2>Click the button to send your Order</h2>
    <form id="postDataForm">
        <button type="button" onclick="getTokenAndSubmit()">Pay your order</button>
    </form>
    <div id="frame-placeholder" style="width: 100%; overflow: hidden; border: none; display: none;">
        <h3>Payment iframe</h3>
        <iframe id="agilpay_frame" name="agilpay_frame" height="703" scrolling="no" style="width: 100%;border: 0;"></iframe>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script>
        function sendPostRequest(accessToken) {
            // Fields to be posted
            var fields = {
                'SiteID': 'API-001',
                'UserID': 'User-123456',
                'Names': 'John Smith',
                'Email': 'j.smith@gmail.com',
                'PhoneNumber': '8293244777',
                'Identification': '00520201129',
                "BodyBackground": "#f8f9fa",
                "PrimaryColor": "#007bff",
                "Tc": "true",
                "Ach": "false",
                "ShowPaymentOptions": "false",
                "NoHeader": "1",
                'ReturnURL': '<%=HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority)%>',  // <--- your site URL HERE
                'SuccessURL': '<%=HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority)%>/Success.aspx',  // <--- your site Receipt URL HERE
                'Detail': '{"Payments":[{"Items":[{"Description":"Service Invoice 122233","Quantity":"1","Amount":100,"Tax":0}],"MerchantKey":"TEST-001","Service":"ABC12345","MerchantName":"Test Store","Description":"Service Invoice 12233","Amount":123.55,"Tax":0,"Currency":"840"}]}',
                'token': accessToken
            };

            // Create a form
            var form = document.createElement('form');
            form.setAttribute('method', 'post');
            form.setAttribute('action', 'https://sandbox-webpay.agilpay.net/Payment');
            form.setAttribute('target', 'agilpay_frame');

            // Append fields to the form as hidden input elements
            for (var key in fields) {
                if (fields.hasOwnProperty(key)) {
                    var input = document.createElement('input');
                    input.setAttribute('type', 'hidden');
                    input.setAttribute('name', key);
                    input.setAttribute('value', fields[key]);
                    form.appendChild(input);
                }
            }

            var x = document.getElementById("frame-placeholder");
            x.style.display = "block";

            // Append the form to the document body and submit
            document.body.appendChild(form);
            form.submit();
        }

        // Simulate getting the JWT access token from the server in ASP.NET
        function getTokenAndSubmit() {
            // AJAX request to get access token from the server
            $.ajax({
                type: "POST",
                url: "Default.aspx/GetAccessToken",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var accessToken = response.d;
                    sendPostRequest(accessToken); // Call function to send POST request with obtained access token
                },
                error: function () {
                    alert('Error: Unable to get Access Token.');
                }
            });
        }
    </script>


</body>
</html>
