namespace DoctorAppointmentMgt.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string PatientName { get; set; }
        public string PatientMobile { get; set; }
        
        public string DoctorName { get; set; }  
        public string Email{ get; set; }
        public int Fees{ get; set; }
        public string AppointmentDate{ get; set; }
        public string AppointmentTime{ get; set;}

    }
}
