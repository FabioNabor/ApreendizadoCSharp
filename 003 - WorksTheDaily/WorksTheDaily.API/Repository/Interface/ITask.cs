using WorksTheDaily.API.Model;
using WorksTheDaily.API.View;

namespace WorksTheDaily.API.Repository.Interface
{
    public interface ITask
    {
        Task<TaskPO> CreateTask(TaskPO task);
        Task<TaskFinal> OpenTask(int id);
        Task<TaskModel> UpdateTask(TaskModel task);
        Task<bool> AddCommet(CommentPO commet);
        Task<bool> DeleteTask(int id);
        Task<IEnumerable<TaskPO>> ListTasks();
    }
}
