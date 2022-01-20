using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class Student : Entity
    {
        public int SchoolId { get; set; }
        public School School { get; set; }
        public int SexId { get; set; }
        public Sex Sex { get; set; }
    }
}
