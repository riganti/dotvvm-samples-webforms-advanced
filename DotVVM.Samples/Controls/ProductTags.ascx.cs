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
        public int ProductId { get; set; }

        public override void DataBind()
        {
            TagRepeater.DataSource = Tags;
            TagRepeater.DataBind();

            if (AllowEditing)
            {
                EditTagPanel.Visible = true;
            }

            base.DataBind();
        }
    }
}