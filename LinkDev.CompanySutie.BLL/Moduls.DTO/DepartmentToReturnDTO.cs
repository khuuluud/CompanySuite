﻿using LinkDev.CompanySuite.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanySutie.BLL.Moduls.DTO
{
    public class DepartmentToReturnDTO
    {

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateOnly CreationDate { get; set; }

        public int Id { get; set; }

 


        //public int CreatedBy { get; set; }

        //public DateTime CreatedOn { get; set; }

        //public int LastModifiedBy { get; set; }

        //public DateTime LastModifiedOn { get; set; }
    }
}
