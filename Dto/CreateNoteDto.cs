using System.ComponentModel.DataAnnotations;

namespace Scribe.Api.Dto
{
    public record CreateNoteDto(
    [Required]
    string Title,
    [Required]
    string Content
);
}
