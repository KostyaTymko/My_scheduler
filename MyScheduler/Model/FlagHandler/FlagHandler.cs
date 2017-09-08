using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduler.Model.FlagHandler
{
    abstract class FlagHandler
    {
        public FlagHandler Successor { get; set; }
        public abstract void HandleRequest(int flag, ObservableCollection<MyTask> Tasks, MyTask selectedTask);
    }
}
