using EmemIsaac.Blog.Application.Features.Categories.Commands.CreateCategory;
using EmemIsaac.Blog.Application.Features.Categories.Commands.DeleteCategory;
using EmemIsaac.Blog.Application.Features.Categories.Commands.UpdateCategory;
using EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategories;
using EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategoriesWithArticles;
using EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all", Name = nameof(GetAllCategories))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Application.Features.Categories.Queries.GetCategories.GetCategoryModel>>> GetAllCategories() 
        {
            var categories = await mediator.Send(new GetCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("allwitharticles", Name = nameof(GetCategoriesWithArticles))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesWithArticles()
        {
            var categories = await mediator.Send(new GetCategoriesWithArticlesQuery());
            return Ok(categories);
        }

        [HttpGet("getcategory", Name = nameof(GetCategory))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Application.Features.Categories.Queries.GetCategories.GetCategoryModel>> GetCategory(GetCategoryQuery getCategoryQuery)
        {
            var category = await mediator.Send(getCategoryQuery);
            return Ok(category);
        }

        [HttpPost("createcategory", Name =nameof(CreateCategory))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateCategoryCommandResponse>> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await mediator.Send(createCategoryCommand);
            return Ok(response);
        }

        [HttpPut("updatecategory", Name =nameof(UpdateCategory))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            await mediator.Send(updateCategoryCommand);
            return NoContent();
        }

        [HttpDelete("delete", Name =nameof(DeleteCategory))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var deleteCommand = new DeleteCategoryCommand { CategoryId = id };
            await mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
