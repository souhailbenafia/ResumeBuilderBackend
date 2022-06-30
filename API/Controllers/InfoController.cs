using Application.DTOs.Info;
using Application.Features.Info.Request.Commands;
using Application.Features.Info.Request.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InfoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("getbyuser")]
        public async Task<ActionResult<List<InfoDto>>> Get(string id)
        {
            var certifications = await _mediator.Send(new GetInfoListRequest { Id = id });
            return Ok(certifications);
        }

        // GET: api/<UserDetailsController>
        [HttpGet("get")]
        public async Task<ActionResult<InfoDto>> GetUserDetails(int id)
        {
            var certification = await _mediator.Send(new GetInfoDetailRequest() { Id = id });
            return Ok(certification);
        }

        // Post: api/<CreateUserDetailsController>
        [HttpPost("add")]
        public async Task<ActionResult<BaseCommandResponse>> createCertification(InfoDto certificationDto)
        {
            var command = new CreateInfoCommand { infoDto = certificationDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteInfoCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("edit")]
        public async Task<ActionResult> Put([FromBody] InfoDto certificationDto)
        {
            var command = new UpdateInfoCommand{ infoDto = certificationDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        [HttpGet("getPhotos/{path}"), DisableRequestSizeLimit]
        public IActionResult GetPhotos(string path)
        {
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                var pathToRead = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var photo = Directory.EnumerateFiles(pathToRead)
                    .Where(IsAPhotoFile)
                    .Select(fullPath => Path.Combine(folderName, Path.GetFileName(fullPath)))
                    .FirstOrDefault(x => x.Equals(path,StringComparison.OrdinalIgnoreCase ));
                return Ok(new { photo });
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
        }
        private bool IsAPhotoFile(string fileName)
        {
            return fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase);
        }
    }
}
