using System;
using System.ComponentModel.DataAnnotations;

namespace NguyenDuyenCuong114
{
    public class NDCStudent
    {
        [Key]
        public string NDCStudentID { get; set; }
        public string NDCStudentName { get; set; }
        public int Sdt { get; set; }
    }

}