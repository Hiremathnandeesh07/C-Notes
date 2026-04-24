using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nandeesh_H_OOPS_24_04_2026
{
    // create school and hostel and implement single inheritance
     class Task5SingleInheritanceSchool
    {
        public string name;
        public int stdId;

        public Task5SingleInheritanceSchool(string name,int stdId)
        {
            this.name = name;
            this.stdId = stdId;
        }

    }
    class Hostel : Task5SingleInheritanceSchool
    {
        public int hostelId;
        public Hostel(string name,int stdId,int hostelId) : base(name,stdId)
        {
            this.hostelId = hostelId;
        }

    }
}
