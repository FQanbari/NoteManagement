using NoteManagement;


public class InMemoryNoteStorage : INoteStorage
{
    private readonly List<Note> _notes = new List<Note>();

    public void Save(List<Note> notes)
    {
        _notes.Clear();
        _notes.AddRange(notes);
    }

    public List<Note> Load()
    {
        return new List<Note>(_notes);
    }
}