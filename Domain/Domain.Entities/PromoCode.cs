
namespace Domain.Entities
{
    public class PromoCode : BaseEntity
    {
        public string Code { get; set; }


        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }


        public Guid PreferenceId { get; set; }

        public virtual Preference Preference { get; set; }
    }
}