using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.DAL.Entities;

namespace USCtest.DAL.DataContext.ModelConfigurations.Generators
{
    public class FlatsGenerator
    {
        public readonly string[] streets = new string[] { "Ленина", "Крала Маркса", "Орехоый Бульвар", "Красная Пресня", "Редищева", "Хохрякова", "Мамина Сибиряка", "Тверская", "Кирова", "Остоженка" };

        public List<Flat> Generate(int count)
        {
            var flats = new List<Flat>();
            for (int i = 1; i < count; i++)
            {
                var rnd = new Random();

                var street = streets[rnd.Next(0, streets.Length - 1)];
                var strNumb = rnd.Next(1, 30);
                var flatNumb = rnd.Next(1, 120);

                var item = new Flat()
                {
                    Id = i,
                    Street = street,
                    StreetNumber = strNumb,
                    FlatNumber = flatNumb,
                    IsColdWatherDevice = Convert.ToBoolean(rnd.Next(0, 1)),
                    IsElectricPowerDevice = Convert.ToBoolean(rnd.Next(0, 1)),
                    IsHotWatherDevice = Convert.ToBoolean(rnd.Next(0, 1)),
                };

                flats.Add(item);
            }

            return flats;
        }
    }
}
