using System;
using System.Collections.Generic;
using System.Text;

using Facilita.Native;
using Facilita.Web;
using Facilita.Fc.Runtime;

using AVirtualUserScript = Facilita.Web.WebBrowserScript;

using QualiTest.Monitoring;

namespace com.testplant.testing
{
	public abstract class MonitorUserScript:AVirtualUserScript
	{
                
		public new MonitorUser VU
		{
			get {return (MonitorUser)(((Facilita.Web.WebBrowserScript)this).VU);}
		}

		public override void Pre()
		{
			//do not remove following line
			base.Pre();
			

			// put any code that needs to execute at the start of the test here
		}

        public int QMEndTransaction(string id)
        {
            //QM: this method replaces the built-in EndTransaction method
            //QM: first call the built-in method so that we record an accurate transaction time
            int retVal = base.EndTransaction(id);
            
            int objZ; 
            QMCounter ictr; 
            int CounterValue;

            MonitorUser.QMCounters = Counters.NextValue();

            for (objZ = 0; objZ < MonitorUser.QMCounters.Count; objZ++)
            {
                ictr = MonitorUser.QMCounters[objZ];
                CounterValue = Convert.ToInt32(ictr.CounterValue);                                
                RecordMetric("QM:" + ictr.MachineName + "." + ictr.Name, CounterValue);
                //QM: this is a horrible kludge to indicate the end of a metric in the event log but it works
                //TODO: fix up the regex in start_test.py and remove this next line
                WriteMessage("/QM " + ictr.MachineName + "." + ictr.Name.ToString() + CounterValue.ToString());
            }

            //QM: Now return the  built-in method's return value
            return retVal;

        }
	}
}
