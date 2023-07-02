namespace Antheap_1_task_net_react.Data.Entities
{
    public class RepresentativeEntity
    {
        public int CompanyId { get; set; } 
        public virtual CompanyEntity? Company { get; set; }

        public int PersonId { get; set; }
        public virtual PersonEntity? Person { get; set; }    
    }
}
