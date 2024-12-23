using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletProject.Application.InputModels;
using WalletProject.Application.Services.Interfaces;

namespace WalletProject.API.Controllers;

[Route("api/wallets")]
[Authorize]
public class WalletsController : ControllerBase
{
    private readonly IWalletService _walletService;

    public WalletsController(IWalletService walletService)
    {
        _walletService = walletService;
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var wallet = await _walletService.GetByIdAsync(id);
        if (wallet == null)
        {
            return NotFound($"Usuário com ID {id} não encontrado.");
        }

        return Ok(wallet);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var wallets = await _walletService.GetAll();
        return Ok(wallets);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateWallet([FromBody] CreateWalletInputModel inputModel)
    {
        if (!ModelState.IsValid)
        {
            var messages = ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(messages);
        }

        await _walletService.CreateWallet(inputModel);

        return Ok();
    }
}