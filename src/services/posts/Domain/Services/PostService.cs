using AppCommon.Exceptions;
using AppCommon.Repositories;
using PostsApi.Application.Dto;
using PostsApi.Application.Queries;
using PostsApi.Domain.Entities;
using PostsApi.Domain.Repositories;

namespace PostsApi.Domain.Services;

public class PostService(
    IPostRepository postRepository,
    IPostLikeRepository postLikeRepository,
    IPostQueries postQueries,
    IUnitOfWork unitOfWork
)
{
    private readonly IPostRepository _postRepository = postRepository;
    private readonly IPostLikeRepository _postLikeRepository = postLikeRepository;
    private readonly IPostQueries _postQueries = postQueries;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Post> CreateAsync(Guid authorId, string description, CancellationToken cancellationToken = default)
    {
        var post = new Post(authorId, description);
        await _postRepository.AddAsync(post, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return post;
    }

    public async Task<PostLike> LikeAsync(Guid postId, Guid userId, CancellationToken cancellationToken = default)
    {
        if (!await _postRepository.ExistsAsync(postId, cancellationToken))
        {
            throw new DomainException("Post not found.");
        }
        if (await _postLikeRepository.ExistsAsync(postId, userId, cancellationToken))
        {
            throw new DomainException("You already liked this post.");
        }
        var like = new PostLike(postId, userId);
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        await _postLikeRepository.AddAsync(like, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _postRepository.IncrementLikesAsync(postId, cancellationToken: cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);

        return like;
    }

    public async Task<PostResponse> FindAsync(Guid postId, CancellationToken cancellationToken = default)
    {
        return await _postQueries.FindAsync(postId, cancellationToken)
            ?? throw new NotFoundException("Post not found.");
    }
}