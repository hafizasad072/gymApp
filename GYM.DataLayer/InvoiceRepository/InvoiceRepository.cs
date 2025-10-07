using GYM.DataLayer.GymRepository;
using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.DataLayer.InvoiceRepository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(GymDbContext context) : base(context)
        {
        }
    }
}
