using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class Trainer
    {
        [Key]
        public Guid TrainerId { get; set; }
        public Guid UserId { get; set; }
        public Guid GymId { get; set; }
    }

}
