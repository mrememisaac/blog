using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Application.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        private readonly UpdateCategoryCommandValidator validator;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, UpdateCategoryCommandValidator validator)
        {
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetById(request.Id);
            if (category == null) throw new NotFoundException(nameof(UpdateCategoryModel), request.Id);

            //validate
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);

            //update
            mapper.Map(request, category, typeof(UpdateCategoryCommand), typeof(Domain.Entities.Category));
            await categoryRepository.Update(category);
        }
    }
}
