using System;
using System.Collections.Generic;
using USCtest.BLL.Models;
using USCtest.DAL.Entities;

namespace USCtest.WebClient.Database.Generators
{
    public static class RegistrationsGenerator
    {
        public static void Generate(this FlatModel flatModel, List<UserProfileModel> users)
        {
            var rnd = new Random();

            var iterations = rnd.Next(1, 3);

            for (int i = 0; i < iterations; i++)
            {
                var item = new RegistrationModel()
                {
                    User = users[rnd.Next(0, users.Count)],
                    Flat = flatModel,
                    RegistrationDate = DateTime.Now.AddDays(-rnd.Next((DateTime.Now - DateTime.Now.AddYears(-50)).Days, (DateTime.Now - DateTime.Now.AddYears(-100)).Days)),
                    RemoveDate = DateTime.Now.AddDays(-rnd.Next(1, (DateTime.Now - DateTime.Now.AddYears(-50)).Days)),
                };

                flatModel.Registrations.Add(item);
            }
        }
    }
}
