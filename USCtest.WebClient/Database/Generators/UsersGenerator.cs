using System;
using System.Collections.Generic;
using USCtest.BLL.Models;
using USCtest.DAL.Entities;

namespace USCtest.WebClient.Database.Generators
{
    public class UsersGenerator
    {
        public readonly string[] maleNames = new string[] { "Александро", "Борис", "Василий", "Игорь", "Даниил", "Сергей", "Евгений", "Алексей", "Геогрий", "Валентин" };
        public readonly string[] femaleNames = new string[] { "Анна", "Мария", "Станислава", "Елена" };
        public readonly string[] lastNames = new string[] { "Тестов", "Титов", "Потапов", "Джабаев", "Иванов" };

        public List<UserProfileModel> Generate(int count)
        {
            var users = new List<UserProfileModel>();
            for (int i = 1; i < count; i++)
            {
                string firstName;
                var rnd = new Random();

                var male = rnd.Next(1, 2) == 1;

                var lastName = lastNames[rnd.Next(0, lastNames.Length - 1)];
                if (male)
                {
                    firstName = maleNames[rnd.Next(0, maleNames.Length - 1)];
                }
                else
                {
                    lastName = lastName + "a";
                    firstName = femaleNames[rnd.Next(0, femaleNames.Length - 1)];
                }

                var item = new UserProfileModel()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PassportSeries = rnd.Next(1000, 9999).ToString(),
                    PassportNumber = rnd.Next(100000, 999999).ToString(),
                };

                users.Add(item);
            }

            return users;
        }
    }
}
