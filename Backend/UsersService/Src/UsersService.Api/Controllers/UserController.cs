namespace UsersService.Api.Controllers;

public class UserController
    : BaseController
{

    private readonly IUserService _userService;

    public UserController(
        IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedAsync(
        int pageNumber, int pageSize,
        string sortBy,
        string searchTerms,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _userService.GetPaginatedAsync(pageNumber, pageSize, sortBy, searchTerms, cancellationToken));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _userService.GetByIdAsync(id, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        CreateUserRequest request, 
        CancellationToken cancellationToken = default)
    {
        return Ok(await _userService.CreateAsync(request, cancellationToken));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(
        int id, UpdateUserRequest request, 
        CancellationToken cancellationToken = default)
    {
        return Ok(await _userService.UpdateAsync(id, request, cancellationToken));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return Ok(await _userService.DeleteAsync(id, cancellationToken));
    }
}