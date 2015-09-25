using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models
{
	class Page
	{
		int PageCount { get; set; }
		int PageSize { get; set; }
		int PageNumber { get; set; }
		int TotalNumberOfItems { get; set; }
	}
}
