using System;

namespace UberApp.Data
{
    public class PaymentTrip
    {
        public int Id { get; set; }
        public double PaidPrice { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string TripId { get; set; }

        public Trip Trip { get; set; }

    }
}
