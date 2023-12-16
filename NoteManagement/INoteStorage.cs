namespace NoteManagement;

public interface INoteStorage
{
    void Save(List<Note> note);
    List<Note> Load();
}
