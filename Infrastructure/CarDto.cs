using System;

namespace UberApp.Infrastructure
{
    public class CarDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime RegisterTimestamp { get; set; }
        public bool IsActive { get; set; }
    }
}
