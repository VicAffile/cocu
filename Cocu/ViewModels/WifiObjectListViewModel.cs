using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using Cocu.Commands;
using Cocu.Services;

namespace Cocu.ViewModels
{
    class WifiObjectListViewModel
    {
        private string _title;

        private WifiScannerService _wifiScannerService;

        private readonly static string _titleString = "Liste des objets connectés à";

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public WifiObjectListViewModel(WifiScannerService wifiScannerService)
        {
            _wifiScannerService = wifiScannerService;
            string currentWifiName = _wifiScannerService.GetCurrentWifiName();
            _title = String.Concat(_titleString, " ", currentWifiName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
