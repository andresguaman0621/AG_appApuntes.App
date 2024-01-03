using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AG_appApuntes.Models;


namespace AG_appApuntes.ViewModelsAG
{
    internal class NotesViewModelAG : IQueryAttributable
    {
        public ObservableCollection<ViewModelsAG.NoteViewModelAG> AllNotes { get; }
        public ICommand NewCommand { get; }
        public ICommand SelectNoteCommand { get; }

        public NotesViewModelAG()
        {
            AllNotes = new ObservableCollection<ViewModelsAG.NoteViewModelAG>(Models.Note.LoadAll().Select(n => new NoteViewModelAG(n)));
            NewCommand = new AsyncRelayCommand(NewNoteAsync);
            SelectNoteCommand = new AsyncRelayCommand<ViewModelsAG.NoteViewModelAG>(SelectNoteAsync);
        }

        private async Task NewNoteAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.AG_NotePage));
        }

        private async Task SelectNoteAsync(ViewModelsAG.NoteViewModelAG note)
        {
            if (note != null)
                await Shell.Current.GoToAsync($"{nameof(Views.AG_NotePage)}?load={note.Identifier}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string noteId = query["deleted"].ToString();
                NoteViewModelAG matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note exists, delete it
                if (matchedNote != null)
                    AllNotes.Remove(matchedNote);
            }
            else if (query.ContainsKey("saved"))
            {
                string noteId = query["saved"].ToString();
                NoteViewModelAG matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note is found, update it
                if (matchedNote != null)
                {
                    matchedNote.Reload();
                    AllNotes.Move(AllNotes.IndexOf(matchedNote), 0);
                }
                // If note isn't found, it's new; add it.
                else
                    AllNotes.Insert(0, new NoteViewModelAG(Models.Note.Load(noteId)));
            }
        }
    }
}
