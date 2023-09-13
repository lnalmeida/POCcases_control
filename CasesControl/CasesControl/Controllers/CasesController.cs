using CasesControl.Entities;
using CasesControl.Repository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CasesControl.Controllers;

[ApiController]
[Route("/[controller]")]
public class CasesController: ControllerBase
{
    private readonly ILogger<CasesController> _logger;
    private readonly CaseRepository _caseRepository;
    private static IHttpContextAccessor? _httpContextAccessor;

    public CasesController(
        ILogger<CasesController> logger, 
        CaseRepository caseRepository, 
        IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _caseRepository = caseRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    private static string? GetServerAddress()
    {
        var serverAddress = _httpContextAccessor?.HttpContext?.Request.Host.ToString();
        return serverAddress;
    }
    
    [HttpPost("add")]
    public ActionResult AddCase(Case newCase)
    {
        try
        {
            _caseRepository.AddCase(newCase);
            Console.ForegroundColor = ConsoleColor.Green;
            _logger.LogInformation($"[{DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss")}] - POST em {GetServerAddress()}/Cases/add");
            Console.ResetColor();
            return Ok("Case Added successfully");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _logger.LogError(ex, "Erro ao processar inclusão de registro");
            Console.ResetColor();
            return null!;
        }
    }
    
    [HttpGet("all")]
    public IActionResult GetAllCase()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Green;
            _logger.LogInformation($"[{DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss")}] - GET em {GetServerAddress()}/Cases/all");
            Console.ResetColor();
            return Ok(_caseRepository.GetAllCases());
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _logger.LogError(ex, "Ocorreu um erro na busca dos registros");
            Console.ResetColor();
            return null!;
        }
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Case>> GetCasesByFilter([FromQuery] string field, [FromQuery] string value)
    {
        try
        {
            FilterDefinition<Case> filter = Builders<Case>.Filter.Eq(field, value);

            List<Case> cases = _caseRepository.GetCasesByFilter(filter);
            Console.ForegroundColor = ConsoleColor.Green;
            _logger.LogInformation($"[{DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss")}] - GET em {GetServerAddress()}/Cases/search");
            Console.ResetColor();
            return Ok(cases);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _logger.LogError(ex, "Erro ao realizar consulta com o filtro determinado");
            Console.ResetColor();
            return null!;
        }
    }
}