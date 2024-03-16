using System;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Models
{
    public class CreateEmployeeModel
    {
        // TODO скрыть из POST запроса
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
