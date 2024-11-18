using Api.Dtos.Input;
using Infra.Entities.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Security.Claims;
using Api.UtilApi;

namespace Api.Controllers
{
    [Authorize]
    [Route("v1/[controller]")]
    [ApiController]
    public class TypeExpenseController : ControllerBase
    {
        private readonly ITypeExpenseService _typeExpenseService;
        public TypeExpenseController(ITypeExpenseService typeExpenseService)
        {
            _typeExpenseService = typeExpenseService;
        }


        [Authorize]
        [HttpGet("Pagination")]
        public async Task<object> Pagination([FromQuery] SearchParams searchParams, CancellationToken cancellationToken)
        {
            return _typeExpenseService.GetPaginationAsync(cancellationToken,searchParams);
        }


        //[Authorize]
        //[HttpPost]
        //public async Task<object> Create(CancellationToken cancellationToken, TypeExpenseInputDTO typeExpenseInputDTO)
        //{

        //}

    }
}
