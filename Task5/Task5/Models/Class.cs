using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Models
{
    public class Class
    {
        public int Id { get; set; }
        public byte Number { get; set; }
        public string Letter { get; set; }
        public virtual List<Student> Students { get; set; } = new List<Student>();
        public virtual List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
