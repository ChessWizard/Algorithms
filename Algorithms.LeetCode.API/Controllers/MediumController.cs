using Algorithms.LeetCode.API.DataManager;
using Algorithms.LeetCode.API.DataManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.LeetCode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediumController : ControllerBase
    {
        private readonly IMediumLevel _mediumLevel;
        public MediumController(IMediumLevel mediumLevel)
        {
            _mediumLevel = mediumLevel ?? throw new ArgumentNullException(nameof(mediumLevel));
        }

        /// <summary>
        /// LengthOfLongestSubstring -> https://leetcode.com/problems/longest-substring-without-repeating-characters/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost("longestSubstring")]
        public IActionResult LengthOfLongestSubstring(string s)
        {
            var result = _mediumLevel.LengthOfLongestSubstring(s);
            return Ok(result);
        }
    }
}
