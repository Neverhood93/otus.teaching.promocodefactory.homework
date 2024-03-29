using WebApi.Models.Customer;

namespace WebApi.Models.Preference
{
    public class PreferenceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        //public virtual List<CustomerModel> Customers { get; set; }
    }
}