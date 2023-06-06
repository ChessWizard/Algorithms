using Algorithms.LeetCode.API.DataManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.LeetCode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EasyController : ControllerBase
    {
        private readonly IEasyLevel _easyLevel;
        public EasyController(IEasyLevel easyLevel)
        {
            _easyLevel = easyLevel ?? throw new ArgumentNullException(nameof(easyLevel));
        }

        /// <summary>
        /// Roman to Int -> https://leetcode.com/problems/roman-to-integer/post-solution/?submissionId=964453571
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost("romanToInt")]
        public IActionResult RomanToInt(string word)
        {
            var result = _easyLevel.RomanToInt(word);
            return result > 0 ? Ok(result) : BadRequest("Wrong input!");
        }

        /// <summary>
        /// Two Sum -> https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        [HttpPost("twoSum")]
        public IActionResult TwoSum(int[] nums, int target)
        {
            var result = _easyLevel.TwoSum(nums, target);
            return result is null ? BadRequest("Wrong input!") : Ok(result);
        }
    }
}
