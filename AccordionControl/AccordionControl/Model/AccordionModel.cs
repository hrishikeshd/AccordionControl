using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AccordionControl.Model
{
    class AccordionModel : ViewModelBase
    {
        private string _headerName;

        public string HeaderName
        {
            get { return _headerName; }
            set { Set(ref _headerName, value); }
        }
        

        private string __totalCount;

        public string TotalCount
        {
            get { return __totalCount; }
            set { Set(ref __totalCount, value); }
        }

        private ImageSource _image;
            
        public ImageSource Image
        {
            get { return _image; }
            set { Set(ref _image, value); }
        }

        private ObservableCollection<ItemDetail> _details;

        public ObservableCollection<ItemDetail> Details
        {
            get { return _details; }
            set { Set(ref _details, value); }
        }
        
        
    }
}
