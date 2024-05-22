using WorksThedaily.WEB.Models;
using WorksTheDaily.API.View;

namespace WorksThedaily.WEB.Service
{
    public interface ITaskServices
    {
        Task<IEnumerable<TaskPO>> GetTasks();
    }
}
