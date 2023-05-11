# agilpay-testshop-webpay

This is an example project using C# simulating a page with a payment button to send user control to the WebPay module.

The steps performed by the example are as follows
1. Request (server-side) the JWT token for authentication, using the /api/paymenttoken endpoint and sending information about the order to be carried out.
2. Prepare the payment form that will be sent to the WebPay module including the JWT token as a hidden field

The objective of obtaining the JWT token from the server is to be able to validate the authenticity of the message, and prevent any payment data from being modified by the user before submitting the form. The WebPay server will validate that the JWT token information matches the fields sent for payment.
