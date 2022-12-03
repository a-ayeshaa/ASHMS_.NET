using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ASHMS_Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<TestCart> TestCarts { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Test_Transaction> Test_Transactions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
