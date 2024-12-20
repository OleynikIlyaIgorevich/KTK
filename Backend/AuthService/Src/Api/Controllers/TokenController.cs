﻿namespace Api.Controllers;

public class TokenController
    : BaseController
{

    [HttpPost]
    public async Task<IActionResult> SignInAsync(
        TokenRequest request, CancellationToken cancellationToken = default)
    {
        
        return Ok();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshAsync()
    {
        return Ok();
    }

    [HttpPost("revoke")]
    public async Task<IActionResult> RevokeAsync()
    {
        return Ok();
    }
}