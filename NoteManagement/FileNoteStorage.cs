using NoteManagement;

public class FileNoteStorage : INoteStorage
{
    private List<Note> _notes = new List<Note>();

    public void Save(List<Note> notes)
    {
        _notes.AddRange(notes);
    }

    public List<Note> Load()
    {
        return _notes;
    }
}