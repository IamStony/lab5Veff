﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models
{
	class Envelope
	{
		public List<CourseInstanceDTO> courses { get; set; }
		public Page page { get; set; }
	}
}
