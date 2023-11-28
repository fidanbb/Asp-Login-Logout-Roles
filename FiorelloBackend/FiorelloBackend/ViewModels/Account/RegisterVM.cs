using System;
using System.ComponentModel.DataAnnotations;

namespace FiorelloBackend.ViewModels.Account
{
	public class RegisterVM
	{
		[Required]
		public string FullName { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Passsword { get; set; }
		[Required]
        [DataType(DataType.Password),Compare(nameof(Passsword))]
        public string ConfirmPassword { get; set; }
	}
}

