using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccordionControl.Model
{
    class ItemDetail:ViewModelBase
    {
        public ItemDetail()
        {
            
        }

        private string _cellData;

        public string CellData
        {
            get { return _cellData; }
            set { Set(ref _cellData, value); }
        }

        private string _cellData2;

        public string CellData2
        {
            get { return _cellData2; }
            set { Set(ref _cellData2, value); }
        }
        
    }
}
