﻿using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class StudentRepository : RepositoryBase<Student>
	{
		public StudentRepository(ITDepartContext dBContext) : base(dBContext)
		{
		}
	}
}
