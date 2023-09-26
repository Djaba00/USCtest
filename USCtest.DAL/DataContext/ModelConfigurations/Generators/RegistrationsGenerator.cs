using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.DAL.Entities;

namespace USCtest.DAL.DataContext.ModelConfigurations.Generators
{
    public class RegistrationsGenerator
    {
        public List<Registration> Generate(int count)
        {
            var flats = new List<Registration>();
            for (int i = 1; i < count; i++)
            {
                var rnd = new Random();

                var item = new Registration()
                {
                    UserId = rnd.Next(1, count).ToString(),
                    FlatId = rnd.Next(1, count),
                    RegistrationDate = DateTime.Now.AddDays(-rnd.Next((DateTime.Now - DateTime.Now.AddYears(-50)).Days, (DateTime.Now - DateTime.Now.AddYears(-100)).Days)),
                    RemoveDate = DateTime.Now.AddDays(-rnd.Next(1, (DateTime.Now - DateTime.Now.AddYears(-50)).Days)),
                };

                flats.Add(item);
            }

            return flats;
        }
    }
}
