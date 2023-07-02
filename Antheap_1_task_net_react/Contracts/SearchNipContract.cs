using Antheap_1_task_net_react.Data.Entities;

namespace Antheap_1_task_net_react.Contracts
{
    public class SearchNipContract
    {
        public SearchNipContractResult Result { get; set; }
    }

    public class SearchNipContractResult
    {
        public CompanyEntity Subject { get; set; }

        public string RequestDateTime { get; set; }

        public string RequestId { get; set; }
    }
}
