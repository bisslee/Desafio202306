using AutoMapper;
using CashFlow.Api.Models;
using CashFlow.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BalanceController : ControllerBase
{
    protected APIResponse _response;
    private readonly IBalanceService _service;
    private readonly IMapper _mapper;

    public BalanceController(IBalanceService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
        _response = new();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]        
    public async Task<ActionResult<APIResponse>> GetBalance()
    {
        try
        {
            var balance = await _service.GetBalanceAsync();
            _response.Result = _mapper.Map<BalanceViewModel>(balance);
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.ErrorMessages.Add(ex.Message);

        }
        return _response;
    }
}
