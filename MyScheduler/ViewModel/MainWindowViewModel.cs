﻿using MyScheduler.Model;
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
        private ObservableCollection<MyTask> temp;

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
 
            flag = 1;
            this.ButtonContext.Message = "View";
            //MessageBox.Show(flag.ToString());
        }
        private void ClickSearchMethod()
        {
            flag = 2;
            this.ButtonContext.Message = "Search";
        }
        private void ClickEditMethod()
        {
            flag = 3;
            this.ButtonContext.Message = "Edit";
            //MessageBox.Show(flag.ToString());
        }
        private void ClickAddMethod()
        {
            flag = 4;
            //this.ButtonVisbility.Visibility = false;
            this.ButtonContext.Message = "Add";
            
            //if (selectedTask != null)
            //{
            //    selectedTask.Title = "";
            //}
            
            //MessageBox.Show(flag.ToString());

        }
        private void ClickDeleteMethod()
        {
            flag = 5;
            this.ButtonContext.Message = "Delete";
            //MessageBox.Show(flag.ToString());
        }


        private void ClickButtonMethod()//fasade
        {
            if (flag == 2)
            {
                MyTask t = new MyTask();
                t.Title = "1";
                tasks.Add(t);
                List<MyTask> l = new List<MyTask>();
                foreach(MyTask m in tasks)
                {
                    l.Add(m);
                }

                l.Reverse();

                tasks.Clear();
               for(int i = 0; i < l.Count; i++)
                {
                    tasks.Add(l[i]);
                }
        
            }
            //MessageBox.Show("button");
            if(flag==3 && selectedTask != null)
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
                //itemSet.Remove(item);
                Tasks.Remove(selectedTask);
                XmlSerialDeSerial x = new XmlSerialDeSerial();
                x.SerializeObject(Tasks, "DbTasks");
                MessageBox.Show("Deleted");
            }

        }
        #endregion
    }
}
