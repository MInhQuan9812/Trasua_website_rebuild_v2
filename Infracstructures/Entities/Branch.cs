using System.ComponentModel.DataAnnotations;
using trasua_web_mvc.Infracstructures.Contant;

namespace trasua_web_mvc.Infracstructures.Entities
{

    public interface BranchPrototype
    {
        BranchPrototype Clone();
    }
    public class Branch: BranchPrototype
    {
        [Key]
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Address { get; set; }

        [MaxLength(Contants.PhoneMaxLength)]
        public long PhoneNumber {  get; set; }

        public virtual Area Area { get; set; }


        public BranchPrototype Clone()
        {
            Branch branch = new Branch()
            {
                Address = Address,
                AreaId = AreaId,
            };
            return branch;
        }
    }
}
