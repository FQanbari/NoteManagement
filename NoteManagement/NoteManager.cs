namespace NoteManagement;

public class NoteManager
{
    private readonly INoteStorage _storage;
    private readonly List<Note> _notes = new List<Note>();

    public event EventHandler<NoteEventArgs> NoteAdded;

    public NoteManager(INoteStorage storage)
    {
        _storage = storage ?? throw new ArgumentNullException(nameof(storage));
    }

    public void Add(Note note)
    {
        if (note == null)
        {
            throw new ArgumentNullException(nameof(note));
        }

        _notes.Add(note);
        _storage.Save(_notes);
        OnNoteAdded(new NoteEventArgs(note));
    }

    public void Remove(Note note)
    {

        _notes.Remove(note);
        _storage.Save(_notes);
    }

    protected virtual void OnNoteAdded(NoteEventArgs e)
    {
        // Check if there are subscribers to the event
        NoteAdded?.Invoke(this, e);
    }
}
public class NoteEventArgs : EventArgs
{
    public Note Note { get; }

    public NoteEventArgs(Note note)
    {
        Note = note ?? throw new ArgumentNullException(nameof(note));
    }
}