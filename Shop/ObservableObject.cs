using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class ObservableObject : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        protected void Set<T>(ref T field, T value, [CallerMemberName] string prop = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
