﻿using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<GetCategoryModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryModel>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = (await _categoryRepository.ListAll()).OrderBy(x => x.Name);
            return _mapper.Map<List<GetCategoryModel>>(categories);
        }
    }
}
