using EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle;
using EmemIsaac.Blog.Application.Features.Articles.Commands.DeleteArticle;
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
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ArticlesController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all", Name = nameof(GetAllArticles))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ListArticlesQuery>>> GetAllArticles()
        {
            var articles = await mediator.Send(new ListArticlesQuery());
            return Ok(articles);
        }

        [HttpGet("GetArticleByUrl", Name = nameof(GetArticleByUrl))]
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

        [HttpGet("GetArticleById", Name = nameof(GetArticleById))]
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

        [HttpPost("CreateArticle", Name = nameof(CreateArticle))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateArticleCommandResponse>> CreateArticle(CreateArticleCommand command)
        {
            var response = await mediator.Send(command);
            return CreatedAtAction(nameof(GetArticleById), response);
        }

        [HttpPost("UpdateArticle", Name = nameof(UpdateArticle))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateArticleCommandResponse>> UpdateArticle(CreateArticleCommand command)
        {
            var response = await mediator.Send(command);
            return response;
        }

        [HttpDelete("DeleteArticle",Name = nameof(DeleteArticle))]
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
