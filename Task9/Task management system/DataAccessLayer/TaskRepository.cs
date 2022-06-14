using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_management_system.Context;

namespace Task_management_system.DataAccessLayer
{
    public class TaskRepository : RepositoryBase<Models.Task>, ITaskRepository
    {
        public TaskRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public void CreateTask(Models.Task task) => Create(task);

        public void DeleteTask(Models.Task task) => Delete(task);

        public IEnumerable<Models.Task> GetAllTasks() => 
            FindAll().OrderBy(x => x.Id).ToList();

        public Models.Task GetTaskById(int taskId) =>
            FindByCondition(t => t.Id.Equals(taskId))
            .SingleOrDefault();

        public void UpdateTask(Models.Task task) => Update(task);
    }
}
