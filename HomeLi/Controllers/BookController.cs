using HomeLi.Contracts;
using HomeLi.Entities.Extensions;
using HomeLi.Entities.Models;

using Microsoft.AspNetCore.Mvc;

using System;

namespace HomeLi.Controllers
{
    [Route("api/book")]
    public class BookController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;

        public BookController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _repository.Book.GetAllBooks();

                _logger.LogInfo($"Returned all books from database.");

                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllBooks action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "BookById")]
        public IActionResult GetBookById(Guid id)
        {
            try
            {
                var book = _repository.Book.GetBookById(id);

                if (book.IsEmptyObject())
                {
                    _logger.LogError($"Book with id: {id}, has not been found in database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned book with id: {id}");
                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wring iside GetBookById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody]Book book)
        {
            try
            {
                if (book.IsObjectNull())
                {
                    _logger.LogError("Book object sent from clinet is null.");
                    return BadRequest("Book object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid book object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Book.CreateBook(book);

                return CreatedAtRoute("BookById", new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong insisde CreateBook action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, [FromBody]Book book)
        {
            try
            {
                if (book.IsObjectNull())
                {
                    _logger.LogError("Book object sent from client is null.");
                    return BadRequest("Book object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid book objet sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbBook = _repository.Book.GetBookById(id);

                if (dbBook.IsEmptyObject())
                {
                    _logger.LogError($"Book with id: {id}, has not been found in datatbase.");
                    return NotFound();
                }

                _repository.Book.UpdateBook(dbBook, book);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong insisde UpdateBook action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            try
            {
                var book = _repository.Book.GetBookById(id);

                if (book.IsEmptyObject())
                {
                    _logger.LogError($"Book with id: {id}, has not been found in database.");
                    return NotFound();
                }

                _repository.Book.DeleteBook(book);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteBranch action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}