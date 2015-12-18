using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip104
{
    class Program
    {
        static void Main(string[] args)
        {
            Commander commander = new StartCommander();
            Drive(commander);
            commander = new StopCommander();
            Drive(commander);
        }

        static void Drive(Commander commander)
        {
            commander.Execute();
        }

    }

    abstract class Commander
    {
        public abstract void Execute();
    }

    class StartCommander : Commander
    {

        public override void Execute()
        {
            //启动
        }
    }

    class StopCommander : Commander
    {

        public override void Execute()
        {
            //停止
        }
    }

}
