using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyScheduler.Model.FlagHandler
{
    class ConcreteFlagHandler3 : FlagHandler
    {
        public override void HandleRequest(int flag, ObservableCollection<MyTask> Tasks, MyTask selectedTask)
        {
            if (flag == 3 && selectedTask != null)
            {
                XmlSerialDeSerial x = new XmlSerialDeSerial();
                x.SerializeObject(Tasks, "DbTasks");
                MessageBox.Show("Saved");
                return;
            }
            else if (Successor != null)
                Successor.HandleRequest(flag, Tasks, selectedTask);
        }
    }
}
