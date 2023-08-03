using System.ComponentModel.DataAnnotations;

namespace ConsumeApi.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
    }
}
