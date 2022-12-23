using AutoMapper;
using BLL.DTO.PatientDTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientServices
{
    public class TestTransactionServices
    {
        public static TestTransactionDTO Get(int id)
        {
            var data = DataAccessFactory.TestTransactionDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestTransaction, TestTransactionDTO>();
            });
            var mapper = new Mapper(config);
            var TestTransaction = mapper.Map<TestTransactionDTO>(data);
            return TestTransaction;
        }

        public static List<TestTransactionDTO> Get()
        {
            var data = DataAccessFactory.TestTransactionDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestTransaction, TestTransactionDTO>();
            });
            var mapper = new Mapper(config);
            var TestTransactions = mapper.Map<List<TestTransactionDTO>>(data);
            return TestTransactions;
        }

        public static TestTransactionDTO Add(int patient_id)
        {
            var obj = new TestTransactionDTO();
            var total = 0.00f;
            var testcarts = TestCartServices.Get();
            var testcart=(from t in testcarts
                          where t.Patient_Id == patient_id && t.Test_Transaction_Id==null 
                          select t).ToList();
            if (testcart.Count == 0)
            {
                return null;
            }
            foreach (var t in testcart)
            {
                var val = TestCart_TestServices.GetwithTest(t.Test_Id);
                total += val.Price;
            }

            obj.Total = total;
            obj.Status = "Pending";
            obj.Date = DateTime.Now;
            obj.Reference = "Self";
            obj.Report_Delivered = "False";
            obj.Patient_Id = patient_id;
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestTransaction, TestTransactionDTO>();
                c.CreateMap<TestTransactionDTO, TestTransaction>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<TestTransaction>(obj);
            var data = DataAccessFactory.TestTransactionDataAccess().Add(newobj);
            foreach(var t in testcart)
            {
                t.Test_Transaction_Id = newobj.Id;
                TestCartServices.Update(t);
            }
            var testTransaction = mapper.Map<TestTransactionDTO>(data);
            return testTransaction;

        }

        public static bool Delete(int id)
        {
            var carts = TestCartServices.Get();
            var list = (from c in carts
                        where c.Test_Transaction_Id == id
                        select c).ToList();
            foreach (var l in list)
            {
                TestCartServices.Delete(l.Id);
            }
            return DataAccessFactory.TestTransactionDataAccess().Delete(id);
        }

        public static bool Update(TestTransactionDTO obj)
        {
            var item = Get(obj.Id);
            obj.Total = item.Total;
            obj.Date = item.Date;
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestTransaction, TestTransactionDTO>();
                c.CreateMap<TestTransactionDTO, TestTransaction>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<TestTransaction>(obj);
            var data = DataAccessFactory.TestTransactionDataAccess().Update(newobj);
            return data;
        }

        //
        public static List<TestTransactionDTO> GetwithPatient(int patient_id)
        {
            var all = DataAccessFactory.TestTransactionDataAccess().Get();
            var patientdata = all.FindAll(i=>i.Patient_Id.Equals(patient_id));
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TestTransaction, TestTransactionDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TestTransactionDTO>>(patientdata);

        }
    }
}
