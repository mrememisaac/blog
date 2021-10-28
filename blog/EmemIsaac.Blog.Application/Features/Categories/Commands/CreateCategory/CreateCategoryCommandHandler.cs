using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        private readonly CreateCategoryCommandValidator createCategoryValidator;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CreateCategoryCommandValidator validator)
        {
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.createCategoryValidator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            Domain.Entities.Category category = categoryRepository.GetByName(request.Name);
            if (category != null) return new CreateCategoryCommandResponse(mapper.Map<CreateCategoryModel>(category));

            var validationResult = await createCategoryValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new CreateCategoryCommandResponse(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            var newCategory = mapper.Map<Domain.Entities.Category>(request);
            await categoryRepository.Add(newCategory);
            return new CreateCategoryCommandResponse(mapper.Map<CreateCategoryModel>(newCategory));
        }
    }
}
