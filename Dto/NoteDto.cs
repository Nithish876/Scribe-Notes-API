
namespace Scribe.Api.Dto
{
    public record NoteDto(
    int Id,
    string Title,
    string Content,
    DateTime CreatedAt
);
}
