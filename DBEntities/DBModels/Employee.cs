using System;
using System.Collections.Generic;

namespace DBEntities.DBModels;

public partial class Employee
{
    public int Empid { get; set; }

    public string Emptz { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? Zip { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public int? Position { get; set; }

    public DateOnly? DateHire { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? ManagerId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<EmployeeSalaryTbl> EmployeeSalaryTbls { get; set; } = new List<EmployeeSalaryTbl>();
}
