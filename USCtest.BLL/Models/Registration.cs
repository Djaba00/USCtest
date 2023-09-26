using System;
namespace USCtest.BLL.Models
{
	public class Registration
	{
		public UserModel User { get; set; }
		public FlatModel Flat { get; set; }
		public DateTime RegisatrateDate { get; set; }
		public DateTime? RemovedDate { get; set; }
	}
}

