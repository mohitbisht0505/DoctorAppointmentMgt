namespace DoctorAppointmentMgt.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        
        public int Experience { get; set; }
        public int Fees { get; set; }
        //public SpecialityClass SpecialityId { get; }
        public string Speciality { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }



    }
}
