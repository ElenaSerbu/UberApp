using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UberApp.Controllers
{
    public class PaymentController : Controller
    {
        private int amount = 100;
        private readonly string WebhookSecret = "whsec_OurSigningSecret";

        public IActionResult Index()
        {
            this.ViewBag.PaymentAmount = this.amount;
            return this.View();
        }

        [HttpPost]
        public IActionResult Processing(string stripeToken, string stripeEmail)
        {
            var Metadata = new Dictionary<string, string>();
            Metadata.Add("Trip1", "Work-Home");
            var options = new ChargeCreateOptions
            {
                Amount = amount,
                Currency = "USD",
                Description = "Paying 10 dollars",
                Source = stripeToken,
                ReceiptEmail = stripeEmail,
                Metadata = Metadata
            };
            var service = new ChargeService();
            var charge = service.Create(options);
            return this.View();
        }

        [HttpPost]
        public IActionResult ChargeChange()
        {
            var json = new StreamReader(this.HttpContext.Request.Body).ReadToEnd();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    this.Request.Headers["Stripe-Signature"], this.WebhookSecret, throwOnApiVersionMismatch: true);
                var charge = (Charge)stripeEvent.Data.Object;
                switch (charge.Status)
                {
                    case "succeeded":

                        break;
                    case "failed":
                        break;
                }
            }
            catch (Exception e)
            {
                return this.BadRequest();
            }
            return this.Ok();
        }
    }
}
