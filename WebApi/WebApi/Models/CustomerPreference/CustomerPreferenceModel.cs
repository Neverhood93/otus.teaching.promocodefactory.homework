
namespace WebApi.Models.CustomerPreference
{
    public class CustomerPreferenceModel
    {
        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }


        public Guid PreferenceId { get; set; }

        public string PreferenceName { get; set; }
    }
}
