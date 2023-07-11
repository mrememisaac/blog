using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategoriesWithArticles
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesWithArticlesQuery, List<GetCategoriesWithArticlesQueryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoriesWithArticlesQueryResponse>> Handle(GetCategoriesWithArticlesQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Category> categories = (await _categoryRepository.GetCategoriesWithArticles()).OrderBy(x => x.Name).ToList();
            return _mapper.Map<List<GetCategoriesWithArticlesQueryResponse>>(categories);
        }
    }
}
