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

        private Visibility _showButton;
        public Visibility ShowButton
        {
            get { return _showButton; }
        }
        //Visibility="{Binding ButtonVisibility.Visibility, UpdateSourceTrigger=PropertyChanged}" 
        //Visibility="{Binding Visibility}"

        //private int flag;
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
            set { buttonVisibility = value; }
        }
        public MainViewModel()
        {
            //_showButton = Visibility.Collapsed;
            //ButtonVisbility.Visibility = Visibility.Hidden;

            buttonContext = new ButtonContext();
            buttonVisibility = new ButtonVisibility();
            buttonVisibility.Visibility = Visibility.Hidden;
            //flag = 0;
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
            
            this.ButtonVisbility.Visibility = Visibility.Hidden;
            //_showButton = Visibility.Hidden;
            this.ButtonContext.Message = "Search";
            //MessageBox.Show("search");
        }
        private void ClickAddMethod()
        {
            //_showButton = Visibility.Visible;
            this.ButtonVisbility.Visibility = Visibility.Visible;
            this.ButtonContext.Message = "Add";
            //MessageBox.Show("add");
        }
        private void ClickEditMethod()
        {
            this.ButtonContext.Message = "Edit";
            //MessageBox.Show("edit");
        }
        private void ClickDeleteMethod()
        {
            this.ButtonContext.Message = "Delete";
            //MessageBox.Show("delete");
        }
        #endregion






    }
}
