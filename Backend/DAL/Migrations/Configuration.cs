namespace DAL.Migrations
{
    using DAL.EF.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ASHMS_Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.ASHMS_Context context)
        {
            string[] Genders = { "Male", "Female" };
            string[] BloodGroups = { "A+", "A-","AB+","AB-","B-","B+","O-","O+" };
            List<User> users = new List<User>();

            for (int i=1;i<=10;i++)
            {
                users.Add(new User()
                {
                    Id = i,
                    Username = "patient"+i,
                    Password = "123",
                    Email = "patient" + i + "@gmail.com",
                    Role = "Patient"
                });
            }
            context.Users.AddOrUpdate(users.ToArray()); 

            List<Patient> patients = new List<Patient>();
            Random r = new Random();
            Random random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                patients.Add(new Patient()
                {
                    Id = i,
                    Name = "Patient"+i,
                    DateOfBirth = DateTime.Now,
                    RegisteredAt = DateTime.Now,
                    Gender = Genders[random.Next(0,2)],
                    UserId = i,
                    BloodGroup = BloodGroups[r.Next(0,BloodGroups.Length)],
                    Phone = "0177777777"
                    
                });
            }
            context.Patients.AddOrUpdate(patients.ToArray());

        }
    }
}
