namespace Antheap_1_task_net_react.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Pesel { get; set; }

        public string Nip { get; set; }

        public IList<CompanyViewModel> Representatives { get; set; }
    }
}
