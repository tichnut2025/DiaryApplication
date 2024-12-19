using System;
using System.Collections.Generic;

namespace DBEntities.DBModels;

public partial class EmployeeSalaryTbl
{
    public int EmpId { get; set; }

    public DateOnly PeriodDate { get; set; }

    public int? Payrate { get; set; }

    public double Salary { get; set; }

    public int? Bonus { get; set; }

    public virtual Employee Emp { get; set; } = null!;
}
