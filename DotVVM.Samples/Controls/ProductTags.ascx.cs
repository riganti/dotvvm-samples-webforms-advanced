using DotVVM.Samples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotVVM.Samples.Controls
{
    public partial class ProductTags : System.Web.UI.UserControl
    {
        public List<Tag> Tags { get; set; }
        public bool AllowEditing { get; set; }

        public override void DataBind()
        {
            TagRepeater.DataSource = Tags;
            TagRepeater.DataBind();

            if (AllowEditing)
            {
                AddTagPanel.Visible = true;
            }

            base.DataBind();
        }

        protected void AddTagButton_Click(object sender, EventArgs e)
        {
            var newTagName = NewTagTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(newTagName))
            {
                Tags.Add(new Tag
                {
                    Name = newTagName
                });

                DataBind();
            }
        }
    }
}