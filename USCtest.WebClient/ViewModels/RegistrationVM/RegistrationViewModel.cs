using System;
using USCtest.BLL.Models;
using USCtest.WebClient.ViewModels.FlatVM;
using USCtest.WebClient.ViewModels.UserVM;

namespace USCtest.WebClient.ViewModels.RegistrationVM
{
    public class RegistrationViewModel
    {
        public int UserId { get; set; }
        public virtual UserViewModel User { get; set; }

        public int FlatId { get; set; }
        public virtual FlatViewModel Flat { get; set; }

        public DateTime RegistrationDate { get; set; }
        public DateTime? RemoveDate { get; set; }
    }
}
