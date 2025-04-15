using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApiMD.Models
{
    [Table("tblEmployee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Column("EmpName", Order = 1)]
        [HttpBindRequired]
        [StringLength(50, MinimumLength = 3)]
        public string EmployeeName { get; set; }
        [HttpBindRequired]
        public Gender Gender { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; } = DateTime.Today;
		[HttpBindRequired]
		public decimal  Salary { get; set; }
        public bool Active { get; set; } = true;

		public List<Experience> Experiences { get; set; } = new List<Experience>();


    }
	[Table("tblExperince")]
	public class Experience
	{
        [Key]

        public int ExpId { get; set; }
        [ForeignKey("Employee")]

        public int EmpId { get; set; }

        public string Company { get; set; }
        public string Designation { get; set; }
		public string ServicePeriod { get; set; }

		public Employee Employee { get; set; }

    }

	public enum Gender
    {
        Male, Female
    }


    public class EmpDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmpDb():base("EmployeeDatabase")
        {
            
        }

    }
}