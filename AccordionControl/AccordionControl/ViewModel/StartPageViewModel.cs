using AccordionControl.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionControl.ViewModel
{
    class StartPageViewModel:ViewModelBase
    {
        private AccordionModel _accordionList;

        public AccordionModel AccordionList
        {
            get { return _accordionList; }
            set { Set(ref _accordionList, value); }
        }

        public StartPageViewModel()
        {

            SetData();
        }

        private void SetData()
        {
            AccordionList  = new AccordionModel();
            AccordionList.HeaderName = "Accordion Data";
            AccordionList.TotalCount = "(2)";
            AccordionList.Details = new ObservableCollection<ItemDetail>();
            ItemDetail accordionItemDetails = new ItemDetail();
            accordionItemDetails.CellData = "Cell Header";
            accordionItemDetails.CellData2 = "some text in cell";
            AccordionList.Details.Add(accordionItemDetails);            
        }
    }
}
