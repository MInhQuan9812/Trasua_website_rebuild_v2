using System.ComponentModel.DataAnnotations;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public class Area
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }=new List<Branch>();


    }
}
