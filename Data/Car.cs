using System;

namespace UberApp.Data
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime RegisterTimestamp { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
