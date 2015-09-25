using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models
{
	public class Page
	{
		public int PageCount { get; set; }
		public int PageSize { get; set; }
		public int PageNumber { get; set; }
		public int TotalNumberOfItems { get; set; }
	}
}
