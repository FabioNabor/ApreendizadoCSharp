using WorksThedaily.WEB.Models;
using WorksThedaily.WEB.Utils;
using WorksTheDaily.API.View;

namespace WorksThedaily.WEB.Service
{
    public class TaskService : ITaskServices
    {
        private readonly HttpClient _httpClient;

        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TaskPO>> GetTasks()
        {
            var response = await _httpClient.GetAsync("https://localhost:7202/api/Task/ListTask");
            if (!response.IsSuccessStatusCode)
            {
                return new List<TaskPO>();
            }
            return await response.ReadContentAs<IEnumerable<TaskPO>>();
        }
    }
}
