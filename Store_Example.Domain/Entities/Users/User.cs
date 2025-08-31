using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Domain.Entities.Users
{
	public class User
	{
        public int Id { get; set; }

        [MaxLength(100)]
		public string FullName { get; set; }

		[MaxLength(50)]
		public string Email{ get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }


		public ICollection<UserInRole> UserInRoles { get; set; }
	}
}
