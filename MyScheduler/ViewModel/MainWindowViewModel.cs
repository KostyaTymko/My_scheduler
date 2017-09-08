using MyScheduler.Model;
using MyScheduler.Model.FlagHandler;
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
        Shedules_Singleton s;
        private int flag;
        private int searchFlag;
        private string searchString;
        private MyTask selectedTask;
        private ButtonContext buttonContext;
        public List<MyTask> temp;

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
            ClickTitleMethod();
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
            searchFlag = 1;
            //MessageBox.Show("title");
        }
        private void ClickContentMethod()
        {
            searchFlag = 2;
            //MessageBox.Show("content");
        }
        private void ClickPriorityMethod()
        {
            searchFlag = 3;
            //MessageBox.Show("priority");
        }
        private void ClickDateMethod()
        {
            searchFlag = 4;
            //MessageBox.Show("date");
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

            FlagHandler h3 = new ConcreteFlagHandler3();
            FlagHandler h4 = new ConcreteFlagHandler4();
            FlagHandler h5 = new ConcreteFlagHandler5();

            h3.Successor = h4;
            h4.Successor = h5;
            h3.HandleRequest(flag,Tasks,selectedTask);
            //h1.HandleRequest(flag);

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
                            
                            if (searchFlag == 1)
                            {
                                if ( m.Title.Contains(searchString) == true /* m.Date == selectedTask.Date*/)
                                {
                                    l.Add(m);
                                }
                                else
                                {
                                    temp.Add(m);
                                }
                            }
                            if (searchFlag == 2)
                            {
                                if (m.Body.Contains(searchString) )
                                {
                                    l.Add(m);
                                }
                                else
                                {
                                    temp.Add(m);
                                }
                            }
                            if (searchFlag == 3)
                            {
                                if (m.Priority== Int32.Parse(searchString))
                                {
                                    l.Add(m);
                                }
                                else
                                {
                                    temp.Add(m);
                                }
                            }
                            if (searchFlag == 4 )
                            {
                                string dateTime = searchString;
                                DateTime dt = Convert.ToDateTime(dateTime);

                                if (m.Date !=null && m.Date.Year == dt.Year && m.Date.Month == dt.Date.Month && m.Date.Day == dt.Day)
                                {
                                    l.Add(m);
                                }
                                else
                                {
                                    temp.Add(m);
                                }
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
        }
        #endregion
    }
}
