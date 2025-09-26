using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM.DataLayer.Repository;
using GYM.EF.Models;

namespace GYM.DataLayer.AttendanceRepository
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
    }
}
