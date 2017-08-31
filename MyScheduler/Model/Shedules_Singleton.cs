using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduler.Model
{
    class Shedules_Singleton
    {
        private static Shedules_Singleton instance;
        public ObservableCollection<MyTask> Tasks { get; private set; }

        protected Shedules_Singleton(string fileName)
        {
            XmlSerialDeSerial x = new XmlSerialDeSerial();
            Tasks = x.DeSerializeObject<ObservableCollection<MyTask>>(fileName);
        }

        public static Shedules_Singleton getInstance(string fileName)
        {
            if (instance == null)
                instance = new Shedules_Singleton(fileName);
            return instance;
        }
    }
}
