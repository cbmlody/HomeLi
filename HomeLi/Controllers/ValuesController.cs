using HomeLi.Contracts;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace HomeLi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repoWrapper;

        public ValuesController(IRepositoryWrapper repoWrapper, ILoggerManager logger)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is info message from our values controller.");
            _logger.LogDebug("Here is debug message from our values controller.");
            _logger.LogWarn("Here is warn message from our values controller.");
            _logger.LogError("Here is error message from our values controller.");

            var authors = _repoWrapper.Author.FindAll();
            var books = _repoWrapper.Book.FindAll();
            var serie = _repoWrapper.Serie.FindAll();

            return new string[] { "value1", "value2" };
        }
    }
}