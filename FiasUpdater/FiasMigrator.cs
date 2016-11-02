using System;
using System.ServiceModel;
using FiasUpdater.Enginering;

namespace FiasUpdater
{
    //Следующая прога, Переливает delta базу ФИАС из xml'я в TSQL
    //Реализованна на технологии WCF по транспортному протоколу TCP

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class FiasMigrator : IRealisation
    {
        public FiasMigrator()
        {
            EventLoger.configEventlog();
        }

        public void ActulisDateRUN(string dir)
        {
            BusinesLogic.dirName = dir;
            var logik = new BusinesLogic();
            logik.moveDate();
            logik = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
