using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using tcc.api.Models;
using tcc.api.Repositories.Interfaces;

namespace tcc.api.Controllers;

[Route("/api")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly IDbRepository<EntityModel> _entity;
    private readonly IDbRepository<NamedEntityModel> _namedEntity;
    private readonly ILogger<DataController> _logger;

    public DataController(ILogger<DataController> logger, IDbRepository<EntityModel> entity, IDbRepository<NamedEntityModel> namedEntity)
    {
        _logger = logger;
        _entity = entity;
        _namedEntity = namedEntity;
    }

    [HttpGet("entidades")]
    public async Task<ActionResult<List<EntityModel>>> GetAllEntities()
    {
        var result = await _entity.GetItems();
        if(result.Any())
        {
            return Ok(result);
        } 
        else 
        {
            return NotFound("Empty");
        }
    }    

    [HttpGet]
    public async Task<ActionResult<List<NamedEntityModel>>> GetAllNamedEntities()
    {
        var result = await _namedEntity.GetItems();
        if(!result.Any())
        {
            return NotFound("Empty");
        }
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<NamedEntityModel> InsertNamedEntities([FromBody] NamedEntityModel namedEntity)
    {
        var result = _namedEntity.Insert(namedEntity);
        return Created("Successfully created", result);
    }

    [HttpGet("bula")]
    public async Task<ActionResult<List<string>>> GetBula()
    {
        var bula = LerBula();
        var namedEntities = await _namedEntity.GetItems();

        var result = bula.Except(namedEntities.Select(p => p.Nome)).ToList();

        return Ok(result);
    }

    [HttpGet("reset")]
    public ActionResult<string> ResetDB()
    {
        var result = _namedEntity.ResetDB();
        return Ok();
    }

    private static List<string> LerBula()
    {
        var result = new List<string>();
        string? line;
        try
        {
            StreamReader sr = new StreamReader("Bula\\bula.txt");
            line = sr.ReadLine()!;
            while (line != null)
            {
                result.Add(line);
                line = sr.ReadLine()!;
            }
            sr.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        return result;
    }
}
