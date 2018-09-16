using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Henry.MvvmBase
{
    public class ModelBase : INotifyPropertyChanged
    {
        private string name;
        private int id;

        public string Name { get => name; set { name = value; NotifyPropertyChanged("Name"); } }
        public int Id { get => id; set { id = value; NotifyPropertyChanged("Id"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // parameter causes the property name of the caller to be substituted as an argument.  
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
