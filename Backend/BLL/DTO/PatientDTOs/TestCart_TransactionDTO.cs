using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.PatientDTOs
{
    public class TestCart_TransactionDTO:TestTransactionDTO
    {
        public virtual List<TestCartDTO> TestCartDTOs { get; set; }
        public TestCart_TransactionDTO()
        {
            this.TestCartDTOs = new List<TestCartDTO>();
        }
    }
}
