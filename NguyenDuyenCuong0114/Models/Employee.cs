using System.ComponentModel.DataAnnotations;

namespace NguyenDuyenCuong0114
{
    public class Employee
    {
        [Key]
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
    }
}