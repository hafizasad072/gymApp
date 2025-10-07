using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.BO.Enums
{
    public enum BookingStatus
    {
        Booked = 1,
        Cancelled = 2,
        Attended = 3,
        NoShow = 4
    }
    public enum SubscriptionStatuses
    {
        Active = 1,
        Expired = 2,
        Cancelled = 3,
        Suspended = 4
    }

    public enum InvoiceStatuses
    {
        Issued = 1,
        Paid = 2,
        Overdue = 3,
        Cancelled = 4
    }
}
