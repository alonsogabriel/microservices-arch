using AppCommon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostsApi.Application.Dto;
using PostsApi.Domain.Services;

namespace PostsApi.Controllers;

[ApiController]
[Route("posts")]
[Authorize]
public class PostsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddPost(
        [FromBody] AddPostRequest request,
        [FromServices] PostService postService,
        CancellationToken cancellationToken)
    {
        var post = await postService.CreateAsync(this.UserGuid()!.Value, request.Description, cancellationToken);
        var response = PostResponse.From(post);

        return CreatedAtAction(nameof(Find), new { postId = post.Id }, response);
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> Find([FromRoute] Guid postId, CancellationToken cancellationToken)
    {
        return Ok(new { postId });
    }
}