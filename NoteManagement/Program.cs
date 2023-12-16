using NoteManagement;

var storage = new InMemoryNoteStorage();
var noteManager = new NoteManager(storage);

// Subscribe to the NoteAdded event
noteManager.NoteAdded += NoteManager_NoteAdded;

// Add some notes
var note1 = new Note { Category = "Personal", Content = "Buy groceries" };
var note2 = new StickyNote { Category = "Work", Content = "Finish the report", Color = "Yellow" };

noteManager.Add(note1);
noteManager.Add(note2);

// Display the notes
DisplayNotes(storage);

// Remove a note
noteManager.Remove(note1);
// Display the notes
DisplayNotes(storage);
Console.ReadLine(); // Keep the console window open



// Event handler for the NoteAdded event
static void NoteManager_NoteAdded(object sender, NoteEventArgs e)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"New Note Added - Category: {e.Note.Category}, Content: {e.Note.Content}");
    Console.ForegroundColor = ConsoleColor.White;
}

static void DisplayNotes(InMemoryNoteStorage storage)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("All Notes:");
    Console.ForegroundColor = ConsoleColor.White;
    foreach (var loadedNote in storage.Load())
    {
        Console.Write($"Category - {loadedNote.Category}, Content - {loadedNote.Content}");
        if (loadedNote is StickyNote loadedStickyNote)
        {
            Console.Write($", Color - {loadedStickyNote.Color}");
        }
        Console.WriteLine();
    }
}