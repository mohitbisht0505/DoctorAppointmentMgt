using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentMgt.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Patient> patients { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        //public DbSet<Appointment> appointments { get; set; }    
        public DbSet<Speciality> specialities { get; set; }
        public DbSet<Book> books { get; set; }


        public string connectionString;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }



    }
}

