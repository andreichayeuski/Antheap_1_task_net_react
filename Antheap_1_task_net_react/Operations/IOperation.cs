namespace Antheap_1_task_net_react.Operations
{
    public interface IOperation<T> where T : class
    {
        Task<List<T>> GetAll();
    }
}
