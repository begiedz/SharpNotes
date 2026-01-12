namespace SharpNotes.Contracts;

public static class NoteContract
{
    public record CreateNoteRequest(string Title, string Content);
}
