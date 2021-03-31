using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Tables
{
   public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        
        //public int branchId { get; set; }
    }
}
