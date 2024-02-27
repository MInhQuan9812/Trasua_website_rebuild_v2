using System.ComponentModel.DataAnnotations;
using trasua_web_mvc.Infracstructures.Contant;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Address { get; set; }

        [MaxLength(Contants.PhoneMaxLength)]
        public long PhoneNumber {  get; set; }

        public virtual Area Area { get; set; }
    }
}
