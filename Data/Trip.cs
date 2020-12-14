using System;

namespace UberApp.Data
{
    public class Trip
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        //public int RatingScore { get; set; }
        //public int PaymentTripId { get; set; }
        //public int PaymentId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
