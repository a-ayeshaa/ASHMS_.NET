using BLL.DTO.AdminDTOs;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.PatientDTOs
{
    public class TestCart_TestDTO:TestDTO
    {
        public virtual List<TestCartDTO> TestCartDTOs { get; set; }
        public TestCart_TestDTO()
        {
            TestCartDTOs = new List<TestCartDTO>();
        }
    }
}
