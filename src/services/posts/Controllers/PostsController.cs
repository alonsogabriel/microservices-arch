using AppCommon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostsApi.Application.Dto;
using PostsApi.Domain.Services;

namespace PostsApi.Controllers;

[ApiController]
[Route("posts")]
[Authorize]
public class PostsController(PostService postService) : ControllerBase
{
    private readonly PostService _postService = postService;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddPostRequest request, CancellationToken cancellationToken)
    {
        var post = await _postService.CreateAsync(this.UserGuid()!.Value, request.Description, cancellationToken);
        var response = PostResponse.From(post);

        return CreatedAtAction(nameof(Find), new { postId = post.Id }, response);
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> Find([FromRoute] Guid postId, CancellationToken cancellationToken)
    {
        var post = await _postService.FindAsync(postId, cancellationToken);

        return Ok(post);
    }

    [HttpPost("{postId}/likes")]
    public async Task<IActionResult> Like([FromRoute] Guid postId, CancellationToken cancellationToken)
    {
        _ = await _postService.LikeAsync(postId, this.UserGuid()!.Value, cancellationToken);

        return Ok();
    }
}