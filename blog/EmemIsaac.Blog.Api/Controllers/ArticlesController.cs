using EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle;
using EmemIsaac.Blog.Application.Features.Articles.Commands.DeleteArticle;
using EmemIsaac.Blog.Application.Features.Articles.Commands.UpdateArticle;
using EmemIsaac.Blog.Application.Features.Articles.Queries;
using EmemIsaac.Blog.Application.Features.Articles.Queries.GetArticleById;
using EmemIsaac.Blog.Application.Features.Articles.Queries.GetArticleByUrl;
using EmemIsaac.Blog.Application.Features.Articles.Queries.ListArticles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ArticlesController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = nameof(GetAllArticles))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ListArticlesQueryResponse>>> GetAllArticles()
        {
            var articles = await mediator.Send(new ListArticlesQuery());
            return Ok(articles);
        }

        [HttpGet("{url}", Name = nameof(GetArticleByUrl))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetArticleQueryResponse>> GetArticleByUrl(string url)
        {
            var article = await mediator.Send(new GetArticleByUrlQuery { Url =  url });
            if(article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpGet("{id:guid}", Name = nameof(GetArticleById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetArticleQueryResponse>> GetArticleById(Guid id)
        {
            var article = await mediator.Send(new GetArticleByIdQuery { Id = id });
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost(Name = nameof(CreateArticle))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateArticleCommandResponse>> CreateArticle(CreateArticleCommand command)
        {
            var response = await mediator.Send(command);
            var routeValues = new
            {
                id = response.Id
            };
            return CreatedAtRoute(nameof(GetArticleById), routeValues, response);
        }

        [HttpPut(Name = nameof(UpdateArticle))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateArticleCommandResponse>> UpdateArticle(UpdateArticleCommand command)
        {
            var response = await mediator.Send(command);
            return response;
        }

        [HttpDelete(Name = nameof(DeleteArticle))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteArticle(Guid id)
        {
            var response = await mediator.Send(new DeleteArticleCommand { ArticleId = id });
            return NoContent();
        }
    }
}
