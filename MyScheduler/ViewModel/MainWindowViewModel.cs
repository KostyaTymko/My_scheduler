using MyScheduler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyScheduler.ViewModel
{
    class MainViewModel
    {
        private MyTask selectedTask;
        public ObservableCollection<MyTask> Tasks { get; set; }

        public MyTask SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }
        public MainViewModel()
        {
            ClickCommand = new Command(arg => ClickMethod());
            Shedules_Singleton s = Shedules_Singleton.getInstance("DbTasks");
            Tasks = s.Tasks;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }



        #region Commands
        /// <summary>
        /// Get or set ClickCommand.
        /// </summary>
        public ICommand ClickCommand { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Click method.
        /// </summary>
        private void ClickMethod()
        {
            MessageBox.Show("This is click command.");
        }
        #endregion
    }
}
