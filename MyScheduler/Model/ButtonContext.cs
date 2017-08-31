using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduler.Model
{
    public class ButtonContext : INotifyPropertyChanged
    {
        private string message;
    
        public string Message
       { 
            get{ return message; }
            set
            { 
               message = value; 
               this.OnPropertyChanged("Message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        } 
    }

}
