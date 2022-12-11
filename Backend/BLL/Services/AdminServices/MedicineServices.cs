using AutoMapper;
using BLL.DTO.AdminDTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.AdminServices
{
    public class MedicineServices
    {
        public static MedicineDTO Get(int id)
        {
            var data = DataAccessFactory.MedicineDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Medicine, MedicineDTO>();
            });
            var mapper = new Mapper(config);
            var Medicine = mapper.Map<MedicineDTO>(data);
            return Medicine;
        }

        public static List<MedicineDTO> Get()
        {
            var data = DataAccessFactory.MedicineDataAccess().Get();
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Medicine, MedicineDTO>();
            });
            var mapper = new Mapper(config);
            //changes to be done here
            var Medicines = mapper.Map<List<MedicineDTO>>(data);
            return Medicines;
        }

        public static MedicineDTO Add(MedicineDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Medicine, MedicineDTO>();
                c.CreateMap<MedicineDTO, Medicine>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Medicine>(obj);
            var data = DataAccessFactory.MedicineDataAccess().Add(newobj);
            return mapper.Map<MedicineDTO>(data);

        }

        public static bool Delete(int id)
        {
            var Medicine = DataAccessFactory.MedicineDataAccess().Get(id);


            return DataAccessFactory.MedicineDataAccess().Delete(Medicine.Id);

        }

        public static bool Update(MedicineDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Medicine, MedicineDTO>();
                c.CreateMap<MedicineDTO, Appointment>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Medicine>(obj);
            var data = DataAccessFactory.MedicineDataAccess().Update(newobj);
            return data;
        }
    }
}
