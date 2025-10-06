using GYM.BO.Enums;
using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.ClassBookingService
{
    public class ClassBookingService : IClassBookingService
    {
        private readonly IUnitOfWorkService _uow;

        public ClassBookingService(IUnitOfWorkService uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<ClassBooking>> GetBookings(Guid scheduleId) =>
           await _uow.ClassBookingRepository.GetAllAsync(x => x.ClassScheduleId == scheduleId);

        public async Task<Guid> CreateBooking(ClassBooking booking)
        {
            booking.ClassBookingId = Guid.NewGuid();
            booking.BookedAt = DateTime.UtcNow;
            booking.StatusId = (int)BookingStatus.Booked;
            await _uow.ClassBookingRepository.InsertAsync(booking);
            _uow.Commit();
            return booking.ClassBookingId;
        }

        public async Task<bool> CancelBooking(Guid bookingId)
        {
            var entity = await _uow.ClassBookingRepository.GetAsync(x => x.ClassBookingId == bookingId, null, false);
            if (entity == null) return false;

            entity.StatusId = (int)BookingStatus.Cancelled;
            entity.CancelledAt = DateTime.UtcNow;
            _uow.Commit();
            return true;
        }
    }
}
