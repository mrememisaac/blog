﻿using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentCommandResponse>
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;
        private readonly CreateCommentCommandValidator validator;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, CreateCommentCommandValidator validator)
        {
            this.commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment twin = await commentRepository.GetByContentAuthorAndArticle(request.Content, request.AuthorId, request.ArticleId);
            if (twin != null) 
                return new CreateCommentCommandResponse(mapper.Map<CreateCommentModel>(twin), "Comment already exists");

            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return new CreateCommentCommandResponse(validationResult);

            var newComment = mapper.Map<Domain.Entities.Comment>(request);
            await commentRepository.Add(newComment);
            return new CreateCommentCommandResponse(mapper.Map<CreateCommentModel>(newComment));
        }
    }
}
