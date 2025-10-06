using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.ClassBookingService
{
    public interface IClassBookingService
    {
        Task<IEnumerable<ClassBooking>> GetBookings(Guid scheduleId);
        Task<Guid> CreateBooking(ClassBooking booking);
        Task<bool> CancelBooking(Guid bookingId);
    }
}
