using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.Models;
using USCtest.DAL.Entities;

namespace USCtest.WebClient.Database.Generators
{
    public class FlatsGenerator
    {
        public readonly string[] streets = new string[] { "Ленина", "Крала Маркса", "Орехоый Бульвар", "Красная Пресня", "Редищева", "Хохрякова", "Мамина Сибиряка", "Тверская", "Кирова", "Остоженка" };

        public List<FlatModel> Generate(int count)
        {
            var flats = new List<FlatModel>();
            for (int i = 0; i < count; i++)
            {
                var rnd = new Random();

                var street = streets[rnd.Next(0, streets.Length - 1)];
                var strNumb = rnd.Next(1, 30);
                var flatNumb = rnd.Next(1, 120);

                var item = new FlatModel()
                {
                    Street = street,
                    StreetNumber = strNumb,
                    FlatNumber = flatNumb,
                    IsColdWaterDevice = Convert.ToBoolean(rnd.Next(0, 1)),
                    IsElectricPowerDevice = Convert.ToBoolean(rnd.Next(0, 1)),
                    IsHotWaterDevice = Convert.ToBoolean(rnd.Next(0, 1)),
                };

                flats.Add(item);
            }

            return flats;
        }
    }
}
