using System;

namespace UberApp.Models
{
    public class CarModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime RegisterTimestamp { get; set; }
        public bool IsActive { get; set; }
    }
}
