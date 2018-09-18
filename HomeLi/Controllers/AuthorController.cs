using HomeLi.Contracts;
using HomeLi.Entities.Extensions;
using HomeLi.Entities.Models;

using Microsoft.AspNetCore.Mvc;

using System;

namespace HomeLi.Controllers
{
    [Route("api/author")]
    public class AuthorController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;

        public AuthorController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            try
            {
                var authors = _repository.Author.GetAllAuthors();

                _logger.LogInfo($"Returned all authors from database");

                return Ok(authors);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllAuthors action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "AuthorById")]
        public IActionResult GetAuthorById(Guid id)
        {
            try
            {
                var author = _repository.Author.GetAuthorById(id);

                if (author.IsEmptyObject())
                {
                    _logger.LogError($"Author with id: {id}, has not been found in database");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned author with id: {id}");
                    return Ok(author);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong insisde GetAuthorById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/books")]
        public IActionResult GetAuthorWithDetails(Guid id)
        {
            try
            {
                var author = _repository.Author.GetAuthorWithDetails(id);

                if (author.Id.Equals(Guid.Empty))
                {
                    _logger.LogError($"Author with id: {id}, has not been found in database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned author with details for id: {id}");
                    return Ok(author);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAuthorWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody]Author author)
        {
            try
            {
                if (author.IsObjectNull())
                {
                    _logger.LogError("Author object sent from client is null.");
                    return BadRequest("Author object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid author object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Author.CreateAuthor(author);

                return CreatedAtRoute("AuthorById", new { id = author.Id }, author);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAuthor action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(Guid id, [FromBody]Author author)
        {
            try
            {
                if (author.IsObjectNull())
                {
                    _logger.LogError("Author object sent from client is null.");
                    return BadRequest("Author object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid author object sent from clinet.");
                    return BadRequest("Invalid model object");
                }

                var dbAuthor = _repository.Author.GetAuthorById(id);

                if (dbAuthor.IsEmptyObject())
                {
                    _logger.LogError($"Author with id: {id}, has not been foud in database.");
                    return NotFound();
                }

                _repository.Author.UpdateAuthor(dbAuthor, author);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateAuthor action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            try
            {
                var author = _repository.Author.GetAuthorById(id);

                if (author.IsEmptyObject())
                {
                    _logger.LogError($"Author with id: {id}, has not been found in database.");
                    return NotFound();
                }
                // if books.byAuthor any log error related books to this author

                _repository.Author.DeleteAuthor(author);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteAuthor action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}