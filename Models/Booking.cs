
namespace SparkClean.Models
{
    public class Booking
    {
        public int BookingID { get; set; }

        public int CustomerID { get; set; }

        public int? CleanerID { get; set; }

        public int ServiceID { get; set; }

        public DateTime BookingDate { get; set; }

        public TimeSpan BookingTime { get; set; }

        public string Status { get; set; }
    }
}
