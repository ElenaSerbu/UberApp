namespace UberApp.Data
{
    public class Payment
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public double Reward { get; set; }
        public string PaymentTripId { get; set; }

        public PaymentTrip PaymentTrip { get; set; }
    }
}
