﻿using DAL.EF.Models;
using DAL.Interfaces;
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
        //PATIENT DATA ACCESS-->AYESHA
        public static IRepo<Patient, int, Patient> PatientDataAccess()
        {
            return new PatientRepo();
        }
        public static IRepo<Test_Transaction, int, Test_Transaction> Test_TransactionDataAccess()
        {
            return new Test_TransactionRepo();
        }
        public static IRepo<TestCart, int, TestCart> TestCartDataAccess()
        {
            return new TestCartRepo();
        }
    }
}
