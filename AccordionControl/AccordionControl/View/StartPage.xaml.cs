using AccordionControl.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AccordionControl.View
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            this.BindingContext = new StartPageViewModel();
            NavigationPage.SetHasNavigationBar(this, true);
        }
    }
}
