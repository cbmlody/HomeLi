using HomeLi.Contracts;
using HomeLi.Contracts.Repositories;
using HomeLi.Controllers;
using HomeLi.Entities.ExtendedModels;
using HomeLi.Entities.Models;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using Moq;
using Xunit;
using Xunit.Abstractions;

namespace HomeLi.Tests.Repositories
{
    public class AuthorControllerTests : IDisposable
    {
        private bool disposed = false;

        private Mock<ILoggerManager> _logger;
        private Mock<IRepositoryWrapper> _wrapper;
        private Mock<IAuthorRepository> _repository;
        private readonly ITestOutputHelper _output;

        public AuthorControllerTests(ITestOutputHelper output)
        {
            _logger = new Mock<ILoggerManager>();
            _wrapper = new Mock<IRepositoryWrapper>();
            _repository = new Mock<IAuthorRepository>();
            _output = output;
        }

        ~AuthorControllerTests()
        {
            this.Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _logger = null;
                    _wrapper = null;
                    _repository = null;
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void GetAllAuthors_OnEmptyCollection_ReturnsEmptyCollection()
        {
            // Arrange
            _repository.Setup(x => x.GetAllAuthors())
                .Returns(new List<Author>());
            _wrapper.Setup(x => x.Author)
                .Returns(_repository.Object);

            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            var result = controller.GetAllAuthors();
            var contentResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
            var authors = Assert.IsType<List<Author>>(contentResult.Value);
            Assert.Empty(authors);
        }

        [Fact]
        public void GetAllAuthors_OnNonEmptyCollection_CollectionWithTheSameNumberOfElements()
        {
            // Arrange
            _repository.Setup(x => x.GetAllAuthors())
                .Returns(new List<Author>() { new Author() { Id = Guid.NewGuid() } });
            _wrapper.Setup(x => x.Author)
                .Returns(_repository.Object);

            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            var result = controller.GetAllAuthors();
            var contentResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
            var authors = Assert.IsType<List<Author>>(contentResult.Value);
            Assert.NotEmpty(authors);
        }

        [Fact]
        public void GetAllAuthors_RepositoryMethodNotImplemented_InternalErrorStatusCode()
        {
            // Arrange
            _repository.Setup(x => x.GetAllAuthors())
                .Throws(new NotImplementedException());
            _wrapper.Setup(x => x.Author)
                .Returns(_repository.Object);

            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            var result = controller.GetAllAuthors();
            var contentResult = result as ObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(500, contentResult.StatusCode);
            _output.WriteLine(contentResult.Value.ToString());
        }

        [Fact]
        public void GetAuthorById_AuthorsCollectionIsEmpty_NotFoundStatusCode()
        {
            // Arrange
            var testId = Guid.Parse("db42afbb-bc02-4c7f-b61f-2bf5d5a3d9d1");

            _repository.Setup(x => x.GetAuthorById(testId))
                .Returns(new Author() { Id = Guid.Empty });
            _wrapper.Setup(x => x.Author)
                .Returns(_repository.Object);

            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            var result = controller.GetAuthorById(testId);
            var contentResult = result as StatusCodeResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(404, contentResult.StatusCode);
        }

        [Fact]
        public void GetAuthorById_AuthorCollectionIsNotEmpty_OkStatus()
        {
            // Arrange
            var testId = Guid.Parse("db42afbb-bc02-4c7f-b61f-2bf5d5a3d9d1");

            _repository.Setup(x => x.GetAuthorById(testId))
                .Returns(new Author() { Id = testId });
            _wrapper.Setup(x => x.Author)
                .Returns(_repository.Object);

            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            var result = controller.GetAuthorById(testId);
            var contentResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
            var author = Assert.IsType<Author>(contentResult.Value);
            Assert.Equal(author.Id, testId);
        }

        [Fact]
        public void GetAuthorById_RepositoryMethodNotImplemented_InternalErrorStatusCode()
        {
            // Arrange
            var testId = Guid.Parse("db42afbb-bc02-4c7f-b61f-2bf5d5a3d9d1");
            _repository.Setup(x => x.GetAuthorById(testId))
                .Throws(new NotImplementedException());
            _wrapper.Setup(x => x.Author)
                .Returns(_repository.Object);

            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            var result = controller.GetAuthorById(testId);
            var contentResult = result as ObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(500, contentResult.StatusCode);
            _output.WriteLine(contentResult.Value.ToString());
        }

        [Fact]
        public void GetAuthorWithDetails_AuthorCollectionIsEmpty_NotFoundStatusCode()
        {
            // Arrange
            var testId = Guid.Parse("db42afbb-bc02-4c7f-b61f-2bf5d5a3d9d1");
            _repository.Setup(x => x.GetAuthorWithDetails(testId))
                .Returns(new AuthorExtended() { Id = Guid.Empty });
            _wrapper.Setup(x => x.Author)
                .Returns(_repository.Object);

            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            var result = controller.GetAuthorWithDetails(testId);
            var contentResult = result as StatusCodeResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(404, contentResult.StatusCode);
        }

        [Fact]
        public void GetAuthorWithDetails_AuthorCollectionNotEmpty_AuthorExtended()
        {
            var testId = Guid.Parse("db42afbb-bc02-4c7f-b61f-2bf5d5a3d9d1");
            _repository.Setup(x => x.GetAuthorWithDetails(testId))
                .Returns(new AuthorExtended() { Id = testId });
            _wrapper.Setup(x => x.Author)
                .Returns(_repository.Object);

            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            var result = controller.GetAuthorWithDetails(testId);
            var contentResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
            var author = Assert.IsType<AuthorExtended>(contentResult.Value);
            Assert.Equal(author.Id, testId);
        }

        [Fact]
        public void GetAuthorWithDetails_RepositoryMethodNotImplemented_InternalErrorStatusCode()
        {
            // Arrange
            var testId = Guid.Parse("db42afbb-bc02-4c7f-b61f-2bf5d5a3d9d1");
            _repository.Setup(x => x.GetAuthorWithDetails(testId))
                .Throws(new NotImplementedException());
            _wrapper.Setup(x => x.Author)
                .Returns(_repository.Object);

            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            var result = controller.GetAuthorWithDetails(testId);
            var contentResult = result as ObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(500, contentResult.StatusCode);
            _output.WriteLine(contentResult.Value.ToString());
        }

        [Fact]
        public void CreateAuthor_NullObject_BadRequestStatusCode()
        {
            // Arrange
            Author testAuthor = null;
            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            var result = controller.CreateAuthor(testAuthor);
            var contentResult = result as BadRequestObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(400, contentResult.StatusCode);
            _output.WriteLine(contentResult.Value.ToString());
        }

        [Fact]
        public void CreateAuthor_InvalidAuthor_BadRequestStatusCode()
        {
            // Arrange
            var testAuthor = new Author() { Id = Guid.NewGuid(), FirstName = "123" };
            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            // mimic validation here
            var validationContext = new ValidationContext(testAuthor);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(testAuthor, validationContext, validationResults);

            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }
            var result = controller.CreateAuthor(testAuthor);
            var contentResult = result as ObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(400, contentResult.StatusCode);
            _output.WriteLine(contentResult.Value.ToString());
        }

        [Fact]
        public void CreateAuthor_ValidAuthor_CreatesAuthorAndReturnsCreatedStatusCode()
        {
            // Arrange
            var testId = Guid.Parse("db42afbb-bc02-4c7f-b61f-2bf5d5a3d9d1");
            var testAuthor = new Author() {Id = testId, FirstName = "Author", LastName = "AuthorLastName"};
            _repository.Setup(x => x.CreateAuthor(testAuthor));
            _wrapper.Setup(x => x.Author).Returns(_repository.Object);
            var controller = new AuthorController(_logger.Object, _wrapper.Object);

            // Act
            var result = controller.CreateAuthor(testAuthor);
            var contentResult = result as ObjectResult;

            // Asset
            Assert.NotNull(contentResult);
            Assert.Equal(201, contentResult.StatusCode);
            Assert.IsType<Author>(contentResult.Value);
            var contentValueAuthor = contentResult.Value as Author;
            Assert.Equal(contentValueAuthor.Id, testId);
        }

        [Fact]
        public void CreateAuthor_RepositoryMethodNotImplemented_InternalServerErrorStatusCode()
        {
            // Arrange
            var testAuthor = new Author();
            _repository.Setup(x => x.CreateAuthor(testAuthor)).Throws(new NotImplementedException());
            _wrapper.Setup(x => x.Author).Returns(_repository.Object);

            var controller = new AuthorController(_logger.Object, _wrapper.Object);
            
            // Act
            var result = controller.CreateAuthor(testAuthor);
            var contentResult = result as ObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(500, contentResult.StatusCode);
        }
    }
}
