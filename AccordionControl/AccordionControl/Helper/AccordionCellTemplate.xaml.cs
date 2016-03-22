using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AccordionControl.Helper
{
    public partial class AccordionCellTemplate : ViewCellUserControl
    {        
       public AccordionCellTemplate()
            : base(Swipe)
        {
            InitializeComponent();
            this.View.BackgroundColor = Color.Transparent;
            BindingContextChanged += TemplateBindingContextChanged;
        }

        private static void Swipe(object sender, EventArgs e)
        {
        }

        private void TemplateBindingContextChanged(object sender, EventArgs e)
        {
            var con = BindingContext;
            var viewCell = sender as AccordionCellTemplate;
            if (viewCell == null) return;
            viewCell.Height += 60;
            viewCell.View.BackgroundColor = Color.Black;
        }
    }
}
