using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Samples.Model;

namespace DotVVM.Samples.Migrated.Pages.CustomerNotes
{
    public class CustomerNotesViewModel : SiteViewModel
    {
        [FromQuery("productId")]
        public int ProductId { get; set; }
        [FromQuery("categoryId")]
        public int CategoryId { get; set; }
        public List<Note> Notes { get; set; }

        [Bind(Direction.ServerToClient)]
        public string Error { get; set; }

        public string NoteText { get; set; } = "";

        public override Task Load()
        {
            Notes = new List<Note>
            {
                new Note(){ CreateDate = DateTime.Now.AddDays(-1), UserName = "John", Text = "Hello"},
                new Note(){ CreateDate = DateTime.Now.AddDays(-2), UserName = "Anne", Text = "Hello there"},
                new Note(){ CreateDate = DateTime.Now.AddDays(-3), UserName = "James", Text = "This is a comment"},
            };
            return base.Load();
        }

        public void Submit()
        {
            if (string.IsNullOrEmpty(NoteText))
            {
                Error = "Note cannot be empty.";
                return;
            }
        }
    }
}

