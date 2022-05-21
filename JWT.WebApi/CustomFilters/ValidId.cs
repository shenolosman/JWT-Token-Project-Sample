using JWT.Business.Interfaces;
using JWT.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JWT.WebApi.CustomFilters
{
    public class ValidId<T> : IActionFilter where T : class, ITable, new()
    {
        private readonly IGenericService<T> _genericService;

        public ValidId(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var key = context.ActionArguments.Where(x => x.Key == "id").FirstOrDefault();
            var checkedId = (int)key.Value;

            var entity = _genericService.GetById(checkedId).Result;
            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"{checkedId} not found!");
            }
        }
    }
}
