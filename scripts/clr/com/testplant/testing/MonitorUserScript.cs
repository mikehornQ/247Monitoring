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

        public int EndTransaction(string id)
        {
            //QM: this method replaces the built-in EndTransaction method
            //QM: first call the built-in method so that we record an accurate transaction time
            int retVal = base.EndTransaction(id);
            string ePPCounterName = @"";
            
            //QM: then update counters
            try
            {
                MonitorUser.QMCounters = Counters.NextValue();
            }
            catch
            {
                return retVal;
            }

            //QM: now update the ePP metrics
            for (int objZ = 0; objZ < MonitorUser.QMCounters.Count; objZ++)
            {
                switch (MonitorUser.QMCounters[objZ].Name)
                {
                    case @"Transaction Response Time": // the only functioning ePP metric for now
                        MonitorUser.QMCounters[objZ].CounterValue = retVal; // not used immediately but keep the counter up to date for later future use
                        ePPCounterName = id + @": " + MonitorUser.QMCounters[objZ].Name;
                        string metricString = String.Format(@"{0},{1},{2},{3},{4}", RemoteConnect.machineName, ePPCounterName, MonitorUser.QMCounters[objZ].Threshold, MonitorUser.QMCounters[objZ].Operator, retVal);
                        Logging.WriteMetric(metricString);
                        break;
                }                                           
            }

            //QM: and finally return the built-in method's return value
            return retVal;

        }
	}
}
