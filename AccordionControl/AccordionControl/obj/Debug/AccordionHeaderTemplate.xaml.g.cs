//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccordionControl.Helper {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class AccordionHeaderTemplate : global::AccordionControl.Helper.ViewUserControl {
        
        private StackLayout parentStack;
        
        private Grid mainGrid;
        
        private Grid expanderGrid;
        
        private Image expanderImage;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(AccordionHeaderTemplate));
            parentStack = this.FindByName<StackLayout>("parentStack");
            mainGrid = this.FindByName<Grid>("mainGrid");
            expanderGrid = this.FindByName<Grid>("expanderGrid");
            expanderImage = this.FindByName<Image>("expanderImage");
        }
    }
}
