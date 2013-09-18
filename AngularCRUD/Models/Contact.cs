using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularCRUD.Models
{
	public class Contact
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public int? ContactGroupID { get; set; }
	}
}