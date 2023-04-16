using DotVVM.Samples.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace DotVVM.Samples.Pages
{
    public partial class CustomerNotes : Page
    {
        public List<Note> Notes { get; private set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Error { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            ProductId = context.GetIntQuery("productId");
            CategoryId = context.GetIntQuery("categoryId");

            Notes = new List<Note>
            {
                new Note(){ CreateDate = DateTime.Now.AddDays(-1), UserName = "John", Text = "Hello"},
                new Note(){ CreateDate = DateTime.Now.AddDays(-2), UserName = "Anne", Text = "Hello there"},
                new Note(){ CreateDate = DateTime.Now.AddDays(-3), UserName = "James", Text = "This is a comment"},
            };
        }

        protected void SubmitButton_Click(object sender, EventArgs args)
        {
            if (string.IsNullOrEmpty(NoteTextField.Text))
            {
                Error = "Note cannot be empty.";
                return;
            }
        }

    }
}