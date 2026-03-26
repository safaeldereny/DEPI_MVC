using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCGizaDay02.ViewModels
{
    public class DepartmentDisplayViewModel
    {
        public string DepartmentName { get; set; }
        public List<SelectListItem> StudentsOver25 { get; set; } = new();
        public string DepartmentState { get; set; }  // "Main" or "Branch"
    }
}