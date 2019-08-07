using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ex1_20190806.Models
{
    public class MemberViewModel
    {
        internal SqlConnection conn;

        [MaxLength(4,ErrorMessage ="超過長度")]
        [Required (ErrorMessage ="姓名必填")]
        [Display(Name="姓名")]
        public string Name { get; set; }
        [Display(Name= "電話")]
        public string Phone { get; set; }
        [Display(Name = "電郵")]
        public string Email { get; set; }

        public List<string> Car { get; set; }

        
        
    }
    
}