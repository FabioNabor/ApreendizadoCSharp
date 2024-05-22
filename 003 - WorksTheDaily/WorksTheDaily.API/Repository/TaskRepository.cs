using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorksTheDaily.API.Data;
using WorksTheDaily.API.Model;
using WorksTheDaily.API.Repository.Interface;
using WorksTheDaily.API.View;

namespace WorksTheDaily.API.Repository
{
    public class TaskRepository : ITask
    {

        private readonly ConnectDB _connectDB;
        private readonly IMapper _mapper;

        public TaskRepository(ConnectDB connectDB, IMapper mapper)
        {
            _connectDB = connectDB;
            _mapper = mapper;
        }

        public async Task<TaskPO> CreateTask(TaskPO task)
        {
            var bstk = new TaskModel(null, task.TaskName, task.type, task.Description, task.NivelPrioridade);
            _connectDB.Tasks.Add(bstk);
            await _connectDB.SaveChangesAsync();
            return task;
        }

        public async Task<bool> AddCommet(CommentPO commet)
        {
            var task = await _connectDB.Tasks.FirstOrDefaultAsync(x => x.id == commet.id);
            if (task != null)
            {
                var cmt = new CommentsModel(null, commet.id, commet.comment);
                _connectDB.Comments.Add(cmt);   
                await _connectDB.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<TaskFinal> OpenTask(int id)
        {
            var task = _connectDB.Tasks.FirstOrDefault(x => x.id == id);
            if (task != null)
            {
                List<CommentsModel> list = await _connectDB.Comments.Where(x => x.father == id).ToListAsync();
                TaskFinal taskend = new TaskFinal(id, task.TaskName, task.type, task.status, task.Description, task.NivelPrioridade,
                    task.DataCriacao, list);
                return taskend;
            }
            return new TaskFinal();
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _connectDB.Tasks.FirstOrDefaultAsync(x => x.id == id);   
            if (task != null)
            {
                _connectDB.Tasks.Remove(task);
                await _connectDB.SaveChangesAsync();    
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TaskPO>> ListTasks()
        {
            var result = await _connectDB.Tasks.ToListAsync();

            return _mapper.Map<IEnumerable<TaskPO>>(result);
        }

        public async Task<TaskModel> UpdateTask(TaskModel task)
        {
            var taskk = await _connectDB.Tasks.FirstOrDefaultAsync(x => x.id == task.id);
            if (taskk != null)
            {
                _connectDB.Tasks.Update(taskk);
                await _connectDB.SaveChangesAsync();
                return taskk;
            }
            return new TaskModel();
        }

    }
}
