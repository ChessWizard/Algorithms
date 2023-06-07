using Algorithms.Codewars.API.DataManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.Codewars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoviceController : ControllerBase
    {
        private readonly INoviceLevel _noviceLevel;
        public NoviceController(INoviceLevel noviceLevel)
        {
            _noviceLevel = noviceLevel ?? throw new ArgumentNullException(nameof(noviceLevel));
        }

        /// <summary>
        /// Is Valid IP -> https://www.codewars.com/kata/515decfd9dcfc23bb6000006/train/csharp
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        [HttpPost("isValidIP")]
        public IActionResult IsValidIP([FromBody]string ip)
        {
            var result = _noviceLevel.IsValidIP(ip);
            return Ok(result);
        }
    }
}
