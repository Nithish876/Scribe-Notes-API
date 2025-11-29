using Scribe.Api.Dto;

namespace Scribe.Api.Services
{
    public interface INoteService
    {
        Task<NoteDto> CreateNoteAsync(CreateNoteDto createDto);
        // Add other methods here: GetNoteAsync, UpdateNoteAsync, DeleteNoteAsync
        Task<NoteDto> GetNoteAsync(int id);
        Task<IEnumerable<NoteDto>> GetAllNotesAsync();
    }
}
