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
        private ButtonContext buttonContext;
        private ButtonVisibility buttonVisibility;
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

        public ButtonContext ButtonContext
        {
            get { return buttonContext; }
            set { buttonContext = value; }
        }

        public ButtonVisibility ButtonVisbility
        {
            get { return buttonVisibility; }
            set
            {
                buttonVisibility = value;
                OnPropertyChanged("Visibility");
            }
        }
        public MainViewModel()
        {
            buttonContext = new ButtonContext();
            //buttonVisibility = new ButtonVisibility();
            //buttonVisibility.Visibility = false;

            ClickViewCommand = new Command(arg => ClickViewMethod());
            ClickButtonCommand = new Command(arg => ClickButtonMethod());
            ClickSearchCommand = new Command(arg => ClickSearchMethod());
            ClickAddCommand = new Command(arg => ClickAddMethod());
            ClickEditCommand = new Command(arg => ClickEditMethod());
            ClickDeleteCommand = new Command(arg => ClickDeleteMethod());
            Shedules_Singleton s = Shedules_Singleton.getInstance("DbTasks");
            Tasks = s.Tasks;
            ClickViewMethod();
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
        public ICommand ClickViewCommand { get; set; }
        public ICommand ClickSearchCommand { get; set; }
        public ICommand ClickAddCommand { get; set; }
        public ICommand ClickEditCommand { get; set; }
        public ICommand ClickDeleteCommand { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Click method.
        /// </summary>
        private void ClickViewMethod()
        {
            this.ButtonContext.Message = "View";
            //MessageBox.Show("search");
        }
        private void ClickSearchMethod()
        {
            this.ButtonContext.Message = "Search";
            //MessageBox.Show("search");
        }
        private void ClickEditMethod()
        {
            this.ButtonContext.Message = "Edit";
            if (selectedTask != null)
            {
                MessageBox.Show(selectedTask.Title.ToString());
            } 
            //MessageBox.Show("edit");
        }
        private void ClickAddMethod()
        {
            //this.ButtonVisbility.Visibility = false;
            this.ButtonContext.Message = "Add";
            //MessageBox.Show("add");
            
        }
        private void ClickDeleteMethod()
        {
            this.ButtonContext.Message = "Delete";
            //MessageBox.Show("delete");
        }
        private void ClickButtonMethod()
        {
            MessageBox.Show("button");
        }
        #endregion
    }
}
