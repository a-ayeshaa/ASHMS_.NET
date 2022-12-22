using BLL.DTO.PatientDTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientServices
{
    public class Patient_TestCartServices
    {
        public static List<TestCart> GetwithPatient(int patient_id)
        {
            var data = DataAccessFactory.TestCartDataAccess().Get().FindAll(i => i.Patient_Id == patient_id);
            return data;
        }

        //gets testcart as list in tests for specific patient
        public static List<TestCart_TestDTO> GetwithPatientandTest(int patient_id)
        {
            var result = new List<TestCart_TestDTO>();
            var data = GetwithPatient(patient_id);
            foreach(var testcart in data)
            {
                var test = TestCart_TestServices.GetwithTest(testcart.Test_Id);
                test.TestCartDTOs.Add(TestCartServices.Get(testcart.Id));
                result.Add(test);
            }
            return result;
        }

        public static List<Test_TestCartDTO> GetwithPatientTest(int patient_id)
        {
            var result = new List<Test_TestCartDTO>();
            var data = GetwithPatient(patient_id);
            foreach (var testcart in data)
            {
                if (testcart.Test_Transaction_Id == null)
                {
                    var test = TestCart_TestServices.GetwithTestDetail(testcart.Id);
                    result.Add(test);
                }
            }
            return result;
        }

        public static float GetTotal(int patient_id)
        {
            var result = GetwithPatientandTest(patient_id);
            float total = 0.00f;
            foreach(var price in result)
            {
                total+=price.Price;
            }    
            return total;
        }
    }
}
