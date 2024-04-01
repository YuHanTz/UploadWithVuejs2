using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace UploadWithVuejs.Controllers
{
    
    public class FileController : ApiController
    {

        [HttpPost]
        [Route("api/upload")]
        public IHttpActionResult Upload()
        {
            var httpRequest = HttpContext.Current.Request;
            if(httpRequest.Files.Count > 0)
            {
                var postedFile = httpRequest.Files[0];
                var filePath = HttpContext.Current.Server.MapPath("~/uploads/" + postedFile.FileName);

                postedFile.SaveAs(filePath);
                return Ok(new { Message = "檔案上傳成功" });
            }

            return BadRequest("檔案上傳失敗");
        }


    }
}