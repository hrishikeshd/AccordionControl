using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AccordionControl.Helper
{
    public partial class AccordionHeaderTemplate : ViewUserControl
    {
        public AccordionHeaderTemplate()
        {
            InitializeComponent();
            CellHeight = 50;        
            IsExpanderClicked = true;
            CellDisplayMemberBinding = "Details";          
            CellTemplate = new AccordionCellTemplate();
            IsExpanderClicked = true;
            Expand();

            //CheckDetail();
            //Expand();
        }

        private void CheckDetail()
        {
            Task.Run(async () =>
            {
                while (BindingContext == null)
                    await Task.Delay(200);
                IList records = null;
                while (records == null)
                {
                    var fields = BindingContext.GetType().GetRuntimeFields();
                    foreach (FieldInfo field in fields.ToList())
                    {
                        //<Name>k__BackingField
                        var checkFieldName = "<" + CellDisplayMemberBinding + ">k__BackingField";
                        if (field.Name.Contains(checkFieldName))
                        {
                            records = field.GetValue(mainGrid.BindingContext) as IList;
                        }
                    }
                    await Task.Delay(200);
                }
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => Expand());
            });
        }

        private ViewCell _cellTemplate;

        public ViewCell CellTemplate
        {
            get { return _cellTemplate; }
            set { _cellTemplate = value; }
        }

        private string _cellDisplayMemberBinding;

        public string CellDisplayMemberBinding
        {
            get { return _cellDisplayMemberBinding; }
            set { _cellDisplayMemberBinding = value; }
        }

        private bool _isExpanderClicked;

        public bool IsExpanderClicked
        {
            get { return _isExpanderClicked; }
            set
            {
                _isExpanderClicked = value;
            }
        }

        private int _cellHeight;

        public int CellHeight
        {
            get { return _cellHeight; }
            set { _cellHeight = value; }
        }

        private void TemplateBindingContextChanged(object sender, EventArgs e)
        {
            var viewCell = sender as AccordionHeaderTemplate;
            if (viewCell == null) return;
        }

        private void ExpanderImageClicked(object sender, EventArgs e)
        {
            if (sender == null)
                return;

            if (IsExpanderClicked)
            {
                expanderImage.Source = "CollapseIcon.png";
                Expand();
                IsExpanderClicked = false;
            }
            else
            {
                expanderImage.Source = "ExpandIcon.png";
                parentStack.Children.RemoveAt(parentStack.Children.Count - 1);
                IsExpanderClicked = true;
            }
        }

        /// <summary>
        /// Button removed image inserted
        /// Tap Event of a image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpanderClicked(object sender, EventArgs e)
        {
        }

        private void Expand()
        {           
            expanderImage.Source = "CollapseIcon.png";
            IsExpanderClicked = false;
            CellTemplate = new AccordionCellTemplate();
            var listview = new ListView();
            listview.BackgroundColor = Color.Transparent;
            listview.HasUnevenRows = true;
            listview.ChildAdded += Added;
            listview.SetBinding(ListView.ItemsSourceProperty, "Details");

            listview.ItemTemplate = new DataTemplate(CellTemplate.GetType());
            Grid grid = new Grid();
            var firstColumn = new ColumnDefinition() { Width = 31 };
            var secondColumn = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            grid.ColumnDefinitions.Add(firstColumn);
            grid.ColumnDefinitions.Add(secondColumn);
            Grid.SetColumn(listview, 1);
            grid.Children.Add(listview);

            parentStack.Children.Add(grid);
        }



        private void Added(object sender, ElementEventArgs e)
        {
            var listView = sender as ViewCell;
        }

    }
}
