using System.ComponentModel.DataAnnotations;

namespace ITI.Models
{
    public class Department
    {
       
        public int Id { get; set; }

        public string Name { get; set; }
        public string? Manager_Name { get; set; }
      
    }
}
