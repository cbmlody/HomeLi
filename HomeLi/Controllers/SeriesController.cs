using HomeLi.Contracts;
using HomeLi.Entities.Extensions;
using HomeLi.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HomeLi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeriesController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;

        public SeriesController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllSeries()
        {
            try
            {
                var series = _repository.Series.GetAllSeries();

                _logger.LogInfo("Returned all series from database");

                return Ok(series);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllSeries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "SeriesById")]
        public IActionResult GetSeriesById(Guid id)
        {
            try
            {
                var series = _repository.Series.GetSeriesById(id);

                if (series.IsEmptyObject())
                {
                    _logger.LogError($"Series with id: {id}, has not been found in database");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned series with id: {id}");
                    return Ok(series);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in GetSeriesById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSeries([FromBody]Series series)
        {
            try
            {
                if (series.IsObjectNull())
                {
                    _logger.LogError("Series object sent from client is null.");
                    return BadRequest("Series object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid series object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Series.CreateSeries(series);

                return CreatedAtRoute("SeriesById", new { id = series.Id }, series);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSeries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeries(Guid id, [FromBody]Series series)
        {
            try
            {
                if (series.IsObjectNull())
                {
                    _logger.LogError("Series object sent from client is null.");
                    return BadRequest("Series object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid series object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbSeries = _repository.Series.GetSeriesById(id);

                if (dbSeries.IsEmptyObject())
                {
                    _logger.LogError($"Series with id: {id}, has not been found in database.");
                    return NotFound();
                }

                _repository.Series.UpdateSeries(dbSeries, series);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSeries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeries(Guid id)
        {
            try
            {
                var serie = _repository.Series.GetSeriesById(id);

                if (serie.IsEmptyObject())
                {
                    _logger.LogError($"Series with id: {id}, has not been found in database.");
                    return NotFound();
                }

                _repository.Series.DeleteSeries(serie);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSeries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}