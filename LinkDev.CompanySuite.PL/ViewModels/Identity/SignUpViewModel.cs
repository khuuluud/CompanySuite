using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinkDev.CompanyBase.PL.ViewModels.Identity
{
	public class SignUpViewModel
	{
		
		public string FirstName { get; set; } = null!;

	
		public string LastName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;
		
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password doesn't match")]
		public string ConfirmPassword { get; set; } = null!;
		public bool IsAgree { get; set; }


    }
}
