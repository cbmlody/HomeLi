using HomeLi.Contracts;
using HomeLi.Entities.Extensions;
using HomeLi.Entities.Models;

using Microsoft.AspNetCore.Mvc;

using System;

namespace HomeLi.Controllers
{
    [Route("api/serie")]
    public class SerieController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;

        public SerieController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllSeries()
        {
            try
            {
                var series = _repository.Serie.GetAllSeries();

                _logger.LogInfo("Returned all series from database");

                return Ok(series);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went worng insisde GetAllSeries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "SerieById")]
        public IActionResult GetSerieById(Guid id)
        {
            try
            {
                var serie = _repository.Serie.GetSerieById(id);

                if (serie.IsEmptyObject())
                {
                    _logger.LogError($"Serie with id: {id}, has not been found in database");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned serie with id: {id}");
                    return Ok(serie);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in GetSerieById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSerie([FromBody]Serie serie)
        {
            try
            {
                if (serie.IsObjectNull())
                {
                    _logger.LogError("Serie object sent from client is null.");
                    return BadRequest("Serie object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid serie object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Serie.CreateSerie(serie);

                return CreatedAtRoute("SerieById", new { id = serie.Id }, serie);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSerie action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSerie(Guid id, [FromBody]Serie serie)
        {
            try
            {
                if (serie.IsObjectNull())
                {
                    _logger.LogError("Serie object sent from client is null.");
                    return BadRequest("Serie object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid serie object sent from clinet.");
                    return BadRequest("Invalid model object");
                }

                var dbSerie = _repository.Serie.GetSerieById(id);

                if (dbSerie.IsEmptyObject())
                {
                    _logger.LogError($"Serie with id: {id}, has not been foud in database.");
                    return NotFound();
                }

                _repository.Serie.UpdateSerie(dbSerie, serie);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSerie action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSerie(Guid id)
        {
            try
            {
                var serie = _repository.Serie.GetSerieById(id);

                if (serie.IsEmptyObject())
                {
                    _logger.LogError($"Serie with id: {id}, has not been found in database.");
                    return NotFound();
                }

                _repository.Serie.DeleteSerie(serie);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSerie action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}