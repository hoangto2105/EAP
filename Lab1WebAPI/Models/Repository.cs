using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1WebAPI.Models
{
    public class Repository
    {
        public static List<Staff> staffs = new List<Staff>
        {
            new Staff{Id=1,Name="Viet Hoang", Department="Sale",Salary=1200},
            new Staff{Id=2,Name="Hao Hiep", Department="IT",Salary=1200},
            new Staff{Id=3,Name="Khanh Pham", Department="HR",Salary=1200}
        };
    }
}
