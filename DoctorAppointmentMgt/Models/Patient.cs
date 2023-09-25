namespace DoctorAppointmentMgt.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public long PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
