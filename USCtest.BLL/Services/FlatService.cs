using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<FlatModel>> GetAllFlatsAsync()
        {
            var flats = await db.Flats.GetAllAsync();

            if (flats != null)
            {
                var flatModels = new List<FlatModel>();

                foreach (var flat in flats)
                {
                    flatModels.Add(mapper.Map<FlatModel>(flat));
                }

                return flatModels;
            }

            return null;
        }

        public async Task<FlatModel> GetFlatByIdAsync(int id)
        {
            var flat = await db.Flats.GetByIdAsync(id);

            if (flat != null)
            {
                return mapper.Map<FlatModel>(flat);
            }
            else
            {
                throw new Exception("Кваритра не найдена");
            }
        }

        public async Task<List<FlatModel>> GetFlatsByAddressAsync(string address)
        {
            var flats = await db.Flats.GetByAddress(address);

            if (flats != null)
            {
                var flatModel = new List<FlatModel>();

                foreach (var flat in flats)
                {
                    flatModel.Add(mapper.Map<FlatModel>(flat));
                }

                return flatModel;
            }
            else
            {
                throw new Exception("Квартиры не найдены");
            }
        }

        public async Task<FlatModel> GetFlatByAddressAsync(string address)
        {
            var flats = await GetFlatsByAddressAsync(address);

            var flat = flats.FirstOrDefault();

            if (flats != null)
            {
                var flatModel = mapper.Map<FlatModel>(flat);

                return flatModel;
            }
            else
            {
                throw new Exception("Квартира не найдена");
            }
        }

        public async Task AddRegistration(FlatModel flatModel, RegistrationModel registrationModel)
        {
            if (registrationModel.RegistrationDate != DateTime.MinValue && registrationModel != null)
            {

                flatModel.Registrations.Add(registrationModel);

                var flat = mapper.Map<Flat>(flatModel);

                await db.Flats.UpdateAsync(flat);
            }
            else
            {
                throw new Exception("Некорректный формат времени");
            }
        }

        public async Task UpdateRegistration(int flatId, RegistrationModel registrationModel)
        {
            throw new NotImplementedException();
        }

        public async Task CreateFlatAsync(FlatModel flatModel)
        {
            if (flatModel != null)
            {
                var flat = mapper.Map<Flat>(flatModel);

                await db.Flats.CreateAsync(flat);
            }
            else
            {
                throw new Exception("Не корректный формат данных квартиры");
            }
        }

        public async Task UpdateFlatAsync(FlatModel flatModel)
        {
            if (flatModel != null)
            {
                var flat = mapper.Map<Flat>(flatModel);
                var currentFlat = await db.Flats.GetByIdAsync(flat.Id);

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

                    //currentFlat.Users = flat.Users;
                    currentFlat.Taxes = flat.Taxes;

                    await db.Flats.UpdateAsync(currentFlat);
                } 
            }
            else
            {
                throw new Exception("Не корректный формат данных квартиры");
            }
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
