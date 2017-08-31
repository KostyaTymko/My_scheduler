using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduler.Model
{
    public class MyTask : INotifyPropertyChanged
    {
        public MyTask() { }
        private string title;
        private string body;
        private int priority;
        private DateTime date;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Body
        {
            get { return body; }
            set
            {
                body = value;
                OnPropertyChanged("Body");
            }
        }
        public int Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                OnPropertyChanged("Priority");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
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
