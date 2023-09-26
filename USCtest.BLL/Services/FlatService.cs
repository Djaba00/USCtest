using AutoMapper;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using USCtest.BLL.Models;
using USCtest.BLL.Interfaces;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;

namespace USCtest.BLL.Services
{
    public class FlatService : IFlatService
    {
        IUnitOfWork db;
        IMapper mapper;

        public FlatService(IUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<FlatModel> GetFlatById(int id)
        {
            var flat = await db.Flats.GetAsync(id);

            if (flat != null)
            {
                return mapper.Map<FlatModel>(flat);
            }
            else
            {
                throw new Exception("Кваритра не найдена");
            }
        }

        public async Task<List<FlatModel>> GetFlatsByAddress(string address)
        {
            var allflats = await db.Flats.GetAllAsync();

            var findedFlats = allflats.Where(f => f.GetFullAddress().Contains(address));

            if (findedFlats != null)
            {
                var flatsDto = new List<FlatModel>();

                foreach (var flat in findedFlats)
                {
                    flatsDto.Add(mapper.Map<FlatModel>(flat));
                }

                return flatsDto;
            }
            else
            {
                throw new Exception("Квартиры не найдены");
            }
        }

        public async Task CreateFlat(FlatModel flatDTO)
        {
            if (flatDTO != null)
            {
                var flat = mapper.Map<Flat>(flatDTO);

                await db.Flats.CreateAsync(flat);
            }
            else
            {
                throw new Exception("Не корректный формат данных квартиры");
            }
        }

        public async Task UpdateFlat(FlatModel flatDTO)
        {
            if (flatDTO != null)
            {
                var flat = mapper.Map<Flat>(flatDTO);
                var currentFlat = await db.Flats.GetAsync(flat.Id);

                if (currentFlat != null)
                {
                    currentFlat.Street = flat.Street;
                    currentFlat.StreetNumber = flat.StreetNumber;
                    currentFlat.FlatNumber = flat.FlatNumber;
                    currentFlat.Building = flat.Building;
                    currentFlat.FlatNumber = flat.FlatNumber;

                    currentFlat.IsColdWatherDevice = flat.IsColdWatherDevice;
                    currentFlat.IsHotWatherDevice = flat.IsHotWatherDevice;
                    currentFlat.IsElectricPowerDevice = flat.IsElectricPowerDevice;

                    currentFlat.Users = flat.Users;
                    currentFlat.Taxes = flat.Taxes;

                    await db.Flats.UpdateAsync(currentFlat);
                }
                
            }
            else
            {
                throw new Exception("Не корректный формат данных квартиры");
            }
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }  
    }
}
