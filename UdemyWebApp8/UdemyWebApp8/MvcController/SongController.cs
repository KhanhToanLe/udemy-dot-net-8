using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UdemyWebApp8.CustomBinder;
using UdemyWebApp8.Model.Entity;

namespace UdemyWebApp8.MvcController
{
    [Route("song1")]
    public class SongController : TestController
    {
        [HttpPost("register")]
        public IActionResult Index([FromBody]Song song)
        {
            if (song.ListOfHasTag != null && song.ListOfHasTag.Count != 0) {
                List<string> hashTag = song.ListOfHasTag;
            }
            else
            {
                return BadRequest("test");
            }

            return new ContentResult();
        }

        [HttpGet("")]
        public IActionResult GetSong([ModelBinder(typeof(ListOfIntegerCustomBinder))] List<int> ids)
        {
            Console.WriteLine(ids);
            return Ok(ids);
        }

        [HttpGet("authorization")]
        public IActionResult GetAuthorization([FromHeader(Name="Authorization")] string authorToken)
        {
            authorToken.Log();
            return Ok();
        }

        
    }
}
    