namespace Antheap_1_task_net_react.Data.Entities
{
    public class PersonEntity : BaseEntity
    {
        public string? CompanyName { get; set; }

        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? Pesel { get; set; }

        public string? Nip { get; set; }

        public virtual IList<RepresentativeEntity>? Representatives { get; set; }
    }
}
