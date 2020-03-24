using System;
using Kemel.DAL.Repository;

namespace Kemel.BLL.Services
{
    public class BaseService
    {
        protected IRepository Repository;

        public BaseService(IRepository repository)
        {
            Repository = repository;
        }

        protected ExecuteResult Execute(Func<ExecuteResult> func, string errorDecription = "")
        {
            try
            {
                return func();
            }
            catch (Exception exp)
            {
                return ExecuteResult.Error(errorDecription + exp.Message);
            }
        }
    }
}
