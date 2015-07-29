using System;
using System.Collections.Generic;
using System.Text;

using Facilita.Native;
using Facilita.Web;
using Facilita.Fc.Runtime;

using AVirtualUser = Facilita.Web.WebBrowserVirtualUser;

using QualiTest.Monitoring;

namespace com.testplant.testing
{
	public class MonitorUser:AVirtualUser
	{
        //QM: QualitestMonitoring collections
        public static List<QMCounter> QMCounters = new List<QMCounter>();
       

		public MonitorUser()
		{
			// Do not call any methods of VirtualUser from here
			// Put any code that needs to execute at the start of the test in the pre() method
		}

		protected override void Pre()
		{
			//do not remove following line
			base.Pre();
			
			//Put any code that needs to execute at the start of the test here
            
            WriteMessage("Loading QualitestMonitoring...");            
            try
            {
                //QM: Set log and data paths so they are returned by the Injector
                WriteMessage("Setting log path to: " + RunPath);
                WriteMessage("Setting data path to: " + FilesDataPath);

                string logPath = String.Format(@"{0}", RunPath);
                bool logSet = Logging.SetLogDir(logPath);
                string dataPath = String.Format(@"{0}\data", FilesDataPath);
                bool dataSet = Counters.SetDataDir(dataPath);
                //QM: Gather a list of performance counters for each machine
                QMCounters = Counters.CreateCounterList();
                WriteMessage("...QualitestMonitoring loaded");
            }
            catch
            {
                WriteMessage("...QualitestMonitoring failed to load. Check log file");
            }                       
		}

		protected override void Post()
		{
			// put any code that needs to execute at the end of the test here

			
			//do not remove following line
			base.Post();
		}

        public override void PrepareRequest(Request request)
        {
            // Put any code that needs to execute before each HTTP request here
        }

        public override void ProcessResponse(Response response)
        {
            // Put any code that needs to execute after each HTTP request here
        }
		
		protected override bool OnError(string id, string info)
        {
			// This method is called whenever an error occurs
			// Returning false from this method will suppress the error in question
            return true;
        }

        protected override bool OnWarn(string id, string info)
        {
			// This method is called whenever a warning occurs
			// Returning false from this method will suppress the warning in question
            return true;
        }

        protected override bool OnException(Exception e)
        {
			// This method is called whenever an unhandled exception is thrown by one of your scripts
			// Returning false from this method will cause the exception to be ignored
            return true;
        }

        
	}
}

