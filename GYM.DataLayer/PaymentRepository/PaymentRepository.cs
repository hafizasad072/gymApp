using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;

namespace GYM.DataLayer.PaymentRepository
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(GymDbContext context) : base(context)
        {
        }
    }
}
