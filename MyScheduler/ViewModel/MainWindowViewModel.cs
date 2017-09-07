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
// <RadioButton GroupName="Change" Content="View" IsChecked="True" Command="{Binding ClickViewCommand}"  />
namespace MyScheduler.ViewModel
{
    class MainViewModel
    {
        Shedules_Singleton s;
        private int flag;
        private string searchString;
        private MyTask selectedTask;
        private ButtonContext buttonContext;
        private List<MyTask> temp;

        public ObservableCollection<MyTask> tasks;
        public ObservableCollection<MyTask> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged("Tasks");
            }
        }
        public MyTask SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }

        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value;
                OnPropertyChanged("SearchString");
            }
        }

        public ButtonContext ButtonContext
        {
            get { return buttonContext; }
            set { buttonContext = value; }
        }

        public MainViewModel()
        {
            buttonContext = new ButtonContext();
            ClickButtonCommand = new Command(arg => ClickButtonMethod());
            ClickSearchCommand = new Command(arg => ClickSearchMethod());
            ClickTitleCommand = new Command(arg => ClickTitleMethod());
            ClickContentCommand = new Command(arg => ClickContentMethod());
            ClickPriorityCommand = new Command(arg => ClickPriorityMethod());
            ClickDateCommand = new Command(arg => ClickDateMethod());
            ClickAddCommand = new Command(arg => ClickAddMethod());
            ClickEditCommand = new Command(arg => ClickEditMethod());
            ClickDeleteCommand = new Command(arg => ClickDeleteMethod());
            s = Shedules_Singleton.getInstance("DbTasks");
            Tasks = s.Tasks;
            ClickEditMethod();            
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
              
        public ICommand ClickAddCommand { get; set; }
        public ICommand ClickEditCommand { get; set; }
        public ICommand ClickDeleteCommand { get; set; }

        public ICommand ClickSearchCommand { get; set; }
        public ICommand ClickTitleCommand { get; set; }
        public ICommand ClickContentCommand { get; set; }
        public ICommand ClickPriorityCommand { get; set; }
        public ICommand ClickDateCommand { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Click method.
        /// </summary>
        private void ClickTitleMethod()
        {
            MessageBox.Show("title");
        }
        private void ClickContentMethod()
        {
            MessageBox.Show("content");
        }
        private void ClickPriorityMethod()
        {
            MessageBox.Show("priority");
        }
        private void ClickDateMethod()
        {
            MessageBox.Show("date");
        }
        private void ClickSearchMethod()
        {
            flag = 2;
            this.ButtonContext.Message = "Search";            
        }
        private void ClickEditMethod()
        {
            if (temp != null)
            {
                //tasks.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    tasks.Add(temp[i]);
                }
            }
            temp = null;
            flag = 3;
            this.ButtonContext.Message = "Save";
        }
        private void ClickAddMethod()
        {
            if (temp != null)
            {
                //tasks.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    tasks.Add(temp[i]);
                }
            }
            temp = null;
            flag = 4;
            this.ButtonContext.Message = "Add";
        }
        private void ClickDeleteMethod()
        {
            if (temp != null)
            {
                //tasks.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    tasks.Add(temp[i]);
                }
            }
            temp = null;
            flag = 5;
            this.ButtonContext.Message = "Delete";
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        private void ClickButtonMethod()//fasade
        {

            if (flag == 2)
            {
                if (temp == null)
                {

                    temp = new List<MyTask>();
                    List<MyTask> l = new List<MyTask>();
                    if (searchString != null)
                    {
                        //MessageBox.Show(searchString);
                        foreach (MyTask m in tasks)
                        {
                            //temp.Add(m);
                            if (/*m.Body.Contains(selectedTask.Body) ||*/ m.Title.Contains(searchString) == true /*|| m.Priority == selectedTask.Priority || m.Date == selectedTask.Date*/)
                            {
                                l.Add(m);
                            }
                            else
                            {
                                temp.Add(m);
                            }
                        }
                        tasks.Clear();
                        for (int i = 0; i < l.Count; i++)
                        {
                            tasks.Add(l[i]);
                        }
                        SearchString = "1111111111111111111";
                        //Tasks.Clear();
                    }
                }
            }

            if (flag==3 && selectedTask != null)
            {
                XmlSerialDeSerial x = new XmlSerialDeSerial();
                x.SerializeObject(Tasks, "DbTasks");
                MessageBox.Show("Saved");
            }

            if (flag == 4 )
            {
                MyTask t = new MyTask();
                t.Title = "New task";
                tasks.Add(t);
                List<MyTask> l = new List<MyTask>();
                foreach (MyTask m in tasks)
                {
                    l.Add(m);
                }
                l.Reverse();
                tasks.Clear();
                for (int i = 0; i < l.Count; i++)
                {
                    tasks.Add(l[i]);
                }
                XmlSerialDeSerial x = new XmlSerialDeSerial();
                x.SerializeObject(Tasks, "DbTasks");
                MessageBox.Show("Added");
            }

            if (flag == 5 && selectedTask != null)
            {
                Tasks.Remove(selectedTask);
                XmlSerialDeSerial x = new XmlSerialDeSerial();
                x.SerializeObject(Tasks, "DbTasks");
                MessageBox.Show("Deleted");
            }

        }
        #endregion
    }
}
