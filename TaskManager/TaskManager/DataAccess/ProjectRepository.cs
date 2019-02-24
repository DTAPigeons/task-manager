using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess {
    class ProjectRepository {
        private TaskManagerEntities context;
        private DbSet<Project> entities;

        public ProjectRepository() {
            context = new TaskManagerEntities();
            entities = context.Set<Project>();
        }

        public List<Project> GetAll() {
            return entities.ToList();
        }

        public Project GetById(int id) {
            return entities.Where(entity => entity.ProjectId == id).FirstOrDefault();
        }

        ///<summary>
        ///<para>Gets a list of projects that meet the specified filters</para>
        ///<para>If you want to ignore a filter type pass null as it's value</para>
        ///</summary>
        public List<Project> GetAllWithFilters(DateTime? startDate=null, DateTime? endDate = null, int? userId = null, string projectName = null) {
            ParameterExpression parameter = Expression.Parameter(typeof(Project), "project");

            Expression startDateExpression = GetDateExpresion(startDate, "StartDate", parameter);
            Expression endDateExpression = GetDateExpresion(endDate, "EndDate", parameter);
            Expression employeeIdExpresion = Expression.Constant(true);
            Expression projectNameExpresion = GetStringExpresion(projectName, "Name", parameter);

            Expression firstResult = Expression.And(startDateExpression, endDateExpression);
            Expression secondResult = Expression.And(firstResult, employeeIdExpresion);
            Expression finalResult = Expression.And(secondResult, projectNameExpresion);

            return GetAllWithFilterExpresion(Expression.Lambda<Func<Project, bool>>(finalResult, parameter));
        }

        private Expression GetDateExpresion(DateTime? date, string propertyName, ParameterExpression parameter) {
            if (date == null) return Expression.Constant(true);

            Expression left = Expression.Property(parameter, typeof(Project).GetProperty(propertyName));
            Expression right = Expression.Constant(date);

            return Expression.Equal(left, right);
        }

        /*
        private Expression GetUserIdExpression(int? userId, ParameterExpression parameter) {
            if (userId == null) return Expression.Constant(true);

            ProjectLogRepository projectLogRep = new ProjectLogRepository();
            ParameterExpression logParam = Expression.Parameter(typeof(ProjectLog), "log");

            Expression projectParamProjectIdExpresion = Expression.Property(parameter, typeof(Project).GetProperty("ProjectId"));
            Expression logParamProjectIdExpresion = Expression.Property(logParam, typeof(ProjectLog).GetProperty("ProjectId"));
            Expression projectIdCompareExpresion = Expression.Equal(projectParamProjectIdExpresion, logParamProjectIdExpresion);

            Expression logUserIdExpresion = Expression.Property(parameter, typeof(ProjectLog).GetProperty("UserId"));
            Expression userIdExpresion = Expression.Constant(userId);
            Expression userIdCompareExpresion = Expression.Equal(logUserIdExpresion, userIdExpresion);

            Expression logQueryExpresion = Expression.Add(projectIdCompareExpresion, userIdCompareExpresion);

            List<ProjectLog> logs = 

        }
        */

        private Expression GetIntExpresion(int? number, string propertyName, ParameterExpression parameter) {
            if (number == null) return Expression.Constant(true);

            Expression left = Expression.Property(parameter, typeof(Project).GetProperty(propertyName));
            Expression right = Expression.Constant(number);

            return Expression.Equal(left, right);
        }

        private Expression GetStringExpresion(string property, string propertyName, ParameterExpression parameter) {
            if (property == null) return Expression.Constant(true);

            Expression propertyExpression = Expression.Property(parameter, typeof(Project).GetProperty(propertyName));
            Expression left = Expression.Call(propertyExpression, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
            Expression right = Expression.Constant(property.ToLower());

            return Expression.Call(left, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), right);

        }

        public List<Project> GetAllWithFilterExpresion(Expression<Func<Project, bool>> filter) {
            return entities.Where(filter).ToList();
        }

        public void Save(Project project) {
            if (project.ProjectId <= 0) {
                Insert(project);
            }
            else {
                Update(project);
            }

            context.SaveChanges();
        }

        public void Insert(Project project) {
            entities.Add(project);
        }

        public void Update(Project project) {
            context.Entry(project).State = EntityState.Modified;
        }

        public void Delete(Project project) {
            entities.Remove(project);
            context.SaveChanges();
        }
    }
}
