using Scribe.Api.Dto;
using Scribe.Api.Infrastructure.DatabaseContext;
using Scribe.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Scribe.Api.Services
{
    public class NoteService:INoteService
    {
        private readonly ScribeDbContext _context;

        public NoteService(ScribeDbContext context)
        {
            _context = context;
        }

        private static NoteDto MapToDto(Note note)
        {
            return new NoteDto
            (
                note.Id,
                note.Title,
                note.Content,
                note.CreatedAt
            );
        }

        public async Task<NoteDto> CreateNoteAsync(CreateNoteDto createDto) {
            var note = new Note
            {
                Title = createDto.Title,
                Content= createDto.Content,
                CreatedAt= DateTime.UtcNow,
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return new NoteDto(note.Id,note.Title,note.Content,note.CreatedAt);
        }

        public async Task<NoteDto> GetNoteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id) ?? throw new KeyNotFoundException($"Note with ID {id} not found.");
            var NoteDto = new NoteDto(note.Id, note.Title, note.Content,note.CreatedAt);
            return NoteDto;
        }

        public async Task<IEnumerable<NoteDto>> GetAllNotesAsync()
        {
            var entities = await _context.Notes
                // Order by newest first, consistent with frontend
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            // Map the entire collection to DTOs
            var result = entities.Select(MapToDto);

            return result;
        }


    }
}
