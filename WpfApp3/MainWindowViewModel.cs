using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Input;

namespace WpfApp3
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {

        int _red, _green, _blue, _alpha;
        public int CurrentRed
        {
            get
            {
                return _red;
            }
            set
            {
                _red = value;
                RaisePropertyChanged(nameof(CurrentRed));
            }
        }
        public int CurrentGreen
        {
            get
            {
                return _green;
            }
            set
            {
                _green = value;
                RaisePropertyChanged(nameof(CurrentGreen));
            }
        }
        public int CurrentBlue
        {
            get 
            {
                return _blue;
            }
            set
            {
                _blue = value;
                RaisePropertyChanged(nameof(CurrentBlue));
            }
        }
        public int CurrentAlpha
        {
            get
            {
                return _alpha;
            }
            set
            {
                _alpha = value;
                RaisePropertyChanged(nameof(CurrentAlpha));
            }
        }

        public MainWindowViewModel() {
            CurrentRed = 0;
            CurrentGreen = 0;
            CurrentBlue = 0;
            CurrentAlpha = 0;
        }

        private ObservableCollection<Color> _colors = new ObservableCollection<Color>();
        public ObservableCollection<Color> Colors
        {
            get
            {
                return _colors;
            }
            set
            {
                _colors = value;
                RaisePropertyChanged(nameof(Colors));
            }
        }

        private DelegateCommand _AddColorCommand;
        public ICommand AddColor
        {
            get
            {
                if(_AddColorCommand == null)
                {
                    _AddColorCommand = new DelegateCommand(Add, CanAdd);
                }
                return _AddColorCommand;
            }
        }
        private void Add(object parameter)
        {
            _colors.Add(Color.FromArgb((byte)CurrentAlpha, (byte)CurrentRed, (byte)CurrentGreen, (byte)CurrentBlue));
            CurrentAlpha = 0;
            CurrentBlue = 0;
            CurrentGreen = 0;
            CurrentRed = 0;
        }

        private bool CanAdd(object parameter)
        {  
            return true;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
