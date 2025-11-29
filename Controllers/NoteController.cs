using Microsoft.AspNetCore.Mvc;
using Scribe.Api.Dto;
using Scribe.Api.Services;

namespace Scribe.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class NoteController : ControllerBase
    {

        private readonly INoteService _noteService;
        private readonly ILogger<NoteController> _logger;

        public NoteController(ILogger<NoteController> logger, INoteService noteService)
        {
            _logger = logger;
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IEnumerable<NoteDto>> GetAllNotesAsync()
        {
            var notes = await _noteService.GetAllNotesAsync();
            return notes;
        }

        [HttpPost]
        [Route("create-note")]
        public async Task<ActionResult<NoteDto>> CreateNoteAsync([FromBody] CreateNoteDto request)
        {
            // create a new note
            var noteDto = await _noteService.CreateNoteAsync(request);
            return CreatedAtAction(nameof(GetNote), new { id = noteDto.Id }, noteDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<NoteDto>> GetNote(int id)
        {
            try
            {
                var noteDto = await _noteService.GetNoteAsync(id);
                return Ok(noteDto);
            }
            catch (KeyNotFoundException)
            {
                // The service threw this because the note was null
                return NotFound(); // Returns HTTP 404
            }
        }
    }
}
