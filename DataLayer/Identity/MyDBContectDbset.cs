using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Identity
{
   public partial class MyDBContext
    {
         public virtual DbSet<Employee>Employees { get; set; }
    }
}
