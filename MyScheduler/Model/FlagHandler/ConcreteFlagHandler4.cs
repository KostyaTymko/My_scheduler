using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyScheduler.Model.FlagHandler
{
    class ConcreteFlagHandler4 : FlagHandler
    {
        public override void HandleRequest(int flag, ObservableCollection<MyTask> Tasks, MyTask selectedTask)
        {
            if (flag == 4)
            {
                MyTask t = new MyTask();
                t.Title = "New task";
                Tasks.Add(t);
                List<MyTask> l = new List<MyTask>();
                foreach (MyTask m in Tasks)
                {
                    l.Add(m);
                }
                l.Reverse();
                Tasks.Clear();
                for (int i = 0; i < l.Count; i++)
                {
                    Tasks.Add(l[i]);
                }
                XmlSerialDeSerial x = new XmlSerialDeSerial();
                x.SerializeObject(Tasks, "DbTasks");
                MessageBox.Show("Added");
                return;
            }
            else if (Successor != null)
                Successor.HandleRequest(flag, Tasks, selectedTask);
        }
    }
}
