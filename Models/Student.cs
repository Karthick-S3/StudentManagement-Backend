using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string fullname {  get; set; }

        public int age { get; set; }
        public string gender { get; set; }
        public string phonenumber {  get; set; }

        public string emailaddress {  get; set; }

        public char grade { get; set; }

        public int absence { get; set; }

        public string tuitionfee { get; set; }

        public string department {  get; set; }

        public int semester {  get; set; }

        public string parent_name {  get; set; }
        public string parent_contact {  get; set; }

        public string username { get; set; }

        public string password { get; set; }

        
    }
}
