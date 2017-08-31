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
        private int flag;
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
            flag = 0;
            ClickButtonCommand = new Command(arg => ClickButtonMethod());
            ClickSearchCommand = new Command(arg => ClickSearchMethod());
            ClickAddCommand = new Command(arg => ClickAddMethod());
            ClickEditCommand = new Command(arg => ClickEditMethod());
            ClickDeleteCommand = new Command(arg => ClickDeleteMethod());
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
        public ICommand ClickButtonCommand { get; set; }
        public ICommand ClickSearchCommand { get; set; }
        public ICommand ClickAddCommand { get; set; }
        public ICommand ClickEditCommand { get; set; }
        public ICommand ClickDeleteCommand { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Click method.
        /// </summary>
        private void ClickButtonMethod()
        {

            MessageBox.Show("button");
        }
        private void ClickSearchMethod()
        {
            MessageBox.Show("search");
            //button.Visibility = Visibility.Visible;
            //NAME = "Changed Name";
            //button1.Content = ;
        }
        private void ClickAddMethod()
        {
            MessageBox.Show("add");
        }
        private void ClickEditMethod()
        {
            MessageBox.Show("edit");
        }
        private void ClickDeleteMethod()
        {
            MessageBox.Show("add");
        }
        #endregion






    }
}
