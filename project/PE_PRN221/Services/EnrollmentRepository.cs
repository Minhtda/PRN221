using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class EnrollmentRepository : RepositoryBase<Enrollment>
	{
		public EnrollmentRepository(ITDepartContext dBContext) : base(dBContext)
		{
		}
	}
}
