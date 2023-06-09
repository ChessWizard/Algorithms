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
            return result ? Ok(result) : BadRequest("Wrong Input!");
        }

        /// <summary>
        /// Make The Deadfish Swim -> https://www.codewars.com/kata/51e0007c1f9378fa810002a9/train/csharp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("makeTheDeadfishSwim")]
        public IActionResult MakeTheDeadfishSwim([FromBody]string data)
        {
            var result = _noviceLevel.MakeTheDeadfishSwim(data);
            return result.Any() ? Ok(result) : BadRequest("Wrong Input!");
        }


        [HttpPost("humanReadableTime")]
        public IActionResult HumanReadableTime([FromBody] int seconds)
        {
            var result = _noviceLevel.GetReadableTime(seconds);
            return !string.IsNullOrEmpty(result) ? Ok(result) : BadRequest("Wrong Input!");
        }

        /// <summary>
        /// Counting Duplicates -£ https://www.codewars.com/kata/54bf1c2cd5b56cc47f0007a1/train/csharp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("countingDuplicates")]
        public IActionResult CountingDuplicates([FromBody] string data)
        {
            var result = _noviceLevel.DuplicateCount(data);
            return result is 0 ? BadRequest("Sorry! All unique.") : Ok(result);
        }
        
        /// <summary>
        /// Unique In Order -> https://www.codewars.com/kata/54e6533c92449cc251001667/train/csharp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iterable"></param>
        /// <returns></returns>
        [HttpPost("uniqueInOrder")]
        public IActionResult UniqueInOrder([FromBody] string iterable)
        {
            var result = _noviceLevel.UniqueInOrder(iterable);
            return !result.Any() ? BadRequest("Wrong input!") : Ok(result);
        }

        /// <summary>
        /// First NonRepeating Letter -> https://www.codewars.com/kata/52bc74d4ac05d0945d00054e/train/csharp
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost("firstNonRepeatingLetter")]
        public IActionResult FirstNonRepeatingLetter(string s)
        {
            var result = _noviceLevel.FirstNonRepeatingLetter(s);
            return string.IsNullOrEmpty(result) ? BadRequest("Wrong input!") : Ok(result);
        }
    }
}
