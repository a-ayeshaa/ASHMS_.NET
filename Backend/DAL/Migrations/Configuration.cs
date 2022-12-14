namespace DAL.Migrations
{
    using DAL.EF.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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
            ////USER TABLE SEED [PATIENT]
            //string[] Genders = { "Male", "Female" };
            //string[] BloodGroups = { "A+", "A-", "AB+", "AB-", "B-", "B+", "O-", "O+" };
            //List<User> users = new List<User>();

            //for (int i = 1; i <= 10; i++)
            //{
            //    users.Add(new User()
            //    {
            //        Id = i,
            //        Username = "patient" + i,
            //        Password = "123",
            //        Email = "patient" + i + "@gmail.com",
            //        Role = "Patient"
            //    });
            //}
            //context.Users.AddOrUpdate(users.ToArray());

            ////PATIENT TABLE SEED
            //List<Patient> patients = new List<Patient>();
            //Random r = new Random();
            //Random random = new Random();
            //for (int i = 1; i <= 10; i++)
            //{
            //    patients.Add(new Patient()
            //    {
            //        Id = i,
            //        Name = "Patient" + i,
            //        DateOfBirth = DateTime.Now,
            //        RegisteredAt = DateTime.Now,
            //        Gender = Genders[random.Next(0, 2)],
            //        UserId = i,
            //        BloodGroup = BloodGroups[r.Next(0, BloodGroups.Length)],
            //        Phone = "0177777777"

            //    });
            //}
            //context.Patients.AddOrUpdate(patients.ToArray());

            //// USER TABLE SEED [DOCTOR]
            //for (int i = 11; i <= 20; i++)
            //{
            //    users.Add(new User()
            //    {
            //        Id = i,
            //        Username = "doctor" + i,
            //        Password = "222",
            //        Email = "doctor" + i + "@hospital.org",
            //        Role = "Doctor"
            //    });
            //}
            //context.Users.AddOrUpdate(users.ToArray());

            //// DOCTOR TABLE SEED
            //string[] specializations =
            //{
            //    "Medicine", "Orthopedics",
            //    "Oncology", "Radiology",
            //    "Diabetology", "ENT", "Dermatology",
            //    "Pediatrics", "Surgery"
            //};
            //string[] degrees = { "MBBS", "MD", "FCPS", "DTCD" };
            //string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            //List<Doctor> doctors = new List<Doctor>();
            //Random drandom = new Random();
            //Random drnd = new Random();
            //Random random1 = new Random();
            //Random random2 = new Random();
            //for (int i = 11; i <= 20; i++)
            //{
            //    doctors.Add(new Doctor()
            //    {
            //        UserId = i,
            //        Name = "Doctor" + i,
            //        Specialization = specializations[drandom.Next(0, specializations.Length)],
            //        Degree = degrees[drnd.Next(0, degrees.Length)],
            //        Appointment_Fees = random1.Next(500, 3000),
            //        VisitingDays = days[random1.Next(0, days.Length)] + "," + days[random2.Next(0, days.Length)] + "," + days[drandom.Next(0, days.Length)] + "," + days[drnd.Next(0, days.Length)],
            //        Net_Earnings = random2.Next(10000, 500000)
            //    });
            //}
            //context.Doctors.AddOrUpdate(doctors.ToArray());

            ////TEST SEED TABLE

            //List<Test> tests = new List<Test>();
            //Random price = new Random();
            //for (int i = 1; i <= 20; i++)
            //{
            //    tests.Add(new Test()
            //    {
            //        Id = i,
            //        Name = "Test" + i,
            //        Price = price.Next(1000, 2000)
            //    });
            //}
            //context.Tests.AddOrUpdate(tests.ToArray());

            ////TESTCART SEED TABLE

            //List<TestCart> testcart = new List<TestCart>();
            //Random p = new Random();
            //for (int i = 1; i <= 20; i++)
            //{
            //    testcart.Add(new TestCart()
            //    {
            //        Id = i,
            //        Test_Id = p.Next(1, 21),
            //        Patient_Id = p.Next(1, 11)
            //    });
            //}
            //context.TestCarts.AddOrUpdate(testcart.ToArray());

            //Appointment Seed Table
            //List<Appointment> appointments = new List<Appointment>();
            //Random doc = new Random();
            //Random pat = new Random();
            //string[] astatuses = { "Waiting", "In Session", "Complete" };
            //for (int i = 0; i < 20; i++)
            //{
            //    appointments.Add(new Appointment()
            //    {
            //        Doctor_Id = doc.Next(1, 11),
            //        Patient_Id = pat.Next(1, 11),
            //        startedAt = DateTime.Now,
            //        endedAt = DateTime.Now,
            //        status = astatuses[doc.Next(0, 3)],
            //        revisit_count = 0
            //    });
            //}
            //context.Appointments.AddOrUpdate(appointments.ToArray());


            //prescription Seed Table
            //List<Prescription> prescriptions = new List<Prescription>();
            //Random docc = new Random();
            //Random pat = new Random();
            //string[] astatuses = { "Waiting", "In Session", "Complete" };
            //for (int i = 0; i < 20; i++)
            //{
            //    prescriptions.Add(new Prescription()
            //    {
            //        Id = i,
            //        Appointment_Id = docc.Next(21, 41),
            //        On_evaluation = Guid.NewGuid().ToString().Substring(0, 6)

            //    });
            //}
            //context.Prescriptions.AddOrUpdate(prescriptions.ToArray());

            ////medicine
            //List<Medicine> med = new List<Medicine>();

            //Random pat = new Random();
            //string[] astatuses = { "Waiting", "In Session", "Complete" };
            //for (int i = 0; i < 100; i++)
            //{
            //    Random docc = new Random();
            //    med.Add(new Medicine()
            //    {
            //        Id = i,
            //        Name = "Napa"+i,
            //        Chemical_Name = "Paracetamol"+i

            //    });
            //}
            //context.Medicines.AddOrUpdate(med.ToArray());

            //medpres Seed Table
            //List<MedicinePrescription> medprescriptions = new List<MedicinePrescription>();

            //Random pat = new Random();
            //string[] astatuses = { "Waiting", "In Session", "Complete" };

            //Random docc = new Random();
            //for (int i = 1; i < 20; i++)
            //{
            //    medprescriptions.Add(new MedicinePrescription()
            //    {
            //        Id = i,
            //        Medicine_Id = docc.Next(1, 101),
            //        Prescription_Id = docc.Next(2,22),
            //        Doze = "1 + 0 + 1"

            //    });
            //}
            //context.MedicinePrescriptions.AddOrUpdate(medprescriptions.ToArray());

            ////Account Seed Table
            //List<Account> accounts = new List<Account>();
            //Random acc = new Random();
            //for (int i = 0; i < 20; i++)
            //{
            //    accounts.Add(new Account()
            //    {
            //        Id = acc.Next(1, 11),
            //        Revenue = acc.Next(101, 111),
            //        Date = DateTime.Now,
            //        Transaction_type = "test"
            //    });
            //}
            //context.Accounts.AddOrUpdate(accounts.ToArray());

        }

    }
}