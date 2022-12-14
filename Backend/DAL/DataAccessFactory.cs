using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos.AdminRepo;
using DAL.Repos.DoctorRepo;
using DAL.Repos.PatientRepo;
using DAL.Repos.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        
        public static IRepo<User, int, User> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Doctor, int, Doctor> DoctorDataAccess()
        {
            return new DoctorRepo();
        }
        public static IRepo<Patient, int, Patient> PatientDataAccess()
        {
            return new PatientRepo();
        }
        public static IRepo<TestTransaction, int, TestTransaction> TestTransactionDataAccess()
        {
            return new TestTransactionRepo();
        }
        public static IRepo<Transaction, int, Transaction> TransactionDataAccess()
        {
            return new TransactionRepo();
        }
        public static IRepo<TestCart, int, TestCart> TestCartDataAccess()
        {
            return new TestCartRepo();
        }
        public static IRepo<Appointment, int, Appointment> AppointmentDataAccess()
        {
            return new AppointmentRepo();
        }

        public static IRepo<Prescription, int, Prescription> PrescriptionDataAccess()
        {
            return new PrescriptionRepo();
        }

        public static IRepo<Account, int, Account> AccountDataAccess()
        {
            return new AccountRepo();
        }

        public static IRepo<Medicine, int, Medicine> MedicineDataAccess()
        {
            return new MedicineRepo();
        }

        public static IRepo<Test, int, Test> TestDataAccess()
        {
            return new TestRepo();
        }

        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
        public static IRepo<MedicinePrescription, int, MedicinePrescription> MedicinePrescriptionDataAccess()
        {
            return new MedicinePrescriptionRepo();
        }

        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }
    }
}
