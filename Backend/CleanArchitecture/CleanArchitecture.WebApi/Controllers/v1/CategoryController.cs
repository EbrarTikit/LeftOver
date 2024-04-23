using CleanArchitecture.Core.Features.Categories.Commands.CreateCategory;
using CleanArchitecture.Core.Features.Categories.Queries.GetAllCategories;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoryController : BaseApiController
    {

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllCategoriesViewModel>>))]
        public async Task<PagedResponse<IEnumerable<GetAllCategoriesViewModel>>> Get([FromQuery] GetAllCategoriesParameter filter)
        {
            return await Mediator.Send(new GetAllCategoriesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber });
        }
    }
}
