// Script Created on Filtered trace created on Fri Jun 19 10:50:15 2015 
// Script Generator Version 6.0.0.169

using System;
using System.Collections.Generic;
using System.Text;

using Facilita.Native;
using Facilita.Web;
using Facilita.Fc.Runtime;

using AVirtualUserScript = com.testplant.testing.MonitorUserScript;

namespace com.testplant.testing
{
	public class demo:AVirtualUserScript
	{
		// Generated variables
		IpEndPoint qualitest = null;  // a parameterized web server address
		IpEndPoint qualitestgroup = null;  // a parameterized web server address
		IpEndPoint qualitest_disqus = null;  // a parameterized web server address
		Protocol protocol1 = null;  // a parameterized protocol
		// End of generated variables

		// Your global variables

		// End of your global variables

		public override void Pre()
		{
			//do not remove following line
			base.Pre();
			
			// The following INITIALISATION is executed once only.
			// START INITIALISATION CODE
			WebBrowser.DefaultUserAgent = GetString("User-Agent","Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko");
			WebBrowser.SetDefaultHeader("Accept-Language", "en-GB");
			WebBrowser.DefaultFollowRedirects = true;
			WebBrowser.DefaultRetrieveSubRequests = true;
			WebBrowser.HostFilteringMode = HostFilteringMode.WHITELIST;
			// The following char encodings were found:-  ISO-8859-1 utf-8

			// END INITIALISATION CODE


			// put any code that needs to execute at the start of the test here
		}

		public override void Script()
		{
			// This 'script' method is the main method executed by the runtime engine.

			qualitest = new IpEndPoint(GetString("qualitestHost", "www.qualitest.co.uk"), GetInt("qualitestPort", 80));
			qualitestgroup = new IpEndPoint(GetString("qualitestgroupHost", "www.qualitestgroup.com"), GetInt("qualitestgroupPort", 80));
			qualitest_disqus = new IpEndPoint(GetString("qualitest_disqusHost", "qualitest.disqus.com"), GetInt("qualitest_disqusPort", 80));

			protocol1 = GetProtocol("protocol1", "http");

			// Only requests to the hosts below will be included in the test
			WebBrowser.IncludeHost(GetString("qualitestgroupHost", "www.qualitestgroup.com"));
			WebBrowser.IncludeHost(GetString("qualitestHost", "www.qualitest.co.uk"));
			WebBrowser.IncludeHost(GetString("qualitest_disqusHost", "qualitest.disqus.com"));

			Action1_Start();
			Action2_aboutus();
		}

        
		int Action1_Start()
		{

			StartTransaction("Start");

			// ====================================================================================================================================
			// Request: 10, GET, http://www.qualitest.co.uk/, response code=301 Moved Permanently, WARNING: redirection target not found, overlapping top-level requests:[], other overlapping requests:[]
			// Rule: Promote Content-Type: text/html sub-requests
			// ====================================================================================================================================
			WebBrowser.SaveCookie(qualitestgroup.Host, "_ga=GA1.2.888569700.1434013792");
			WebBrowser.SaveCookie(qualitestgroup.Host, "s_fid=474C37540AA3F738-3496B73ED96122BE");
			Url url10 = new Url(protocol1, qualitest, "/");
			Request request10 = WebBrowser.CreateRequest(HttpMethod.GET, url10, 10);
			request10.SetHeader("Dnt", "1");
			// References to the following page resources could not be found within the contents of the received web page.
			// This can occur because resources are fetched as a result of style sheets or the browser executing script code e.g. JavaScript.
			request10.AddSubRequest(protocol1, qualitestgroup, "/wp-content/themes/custom-theme/core/fonts/aller_rg-webfont.eot"); //  Request: 15, 0 Unknown
			request10.AddSubRequest(protocol1, qualitestgroup, "/wp-content/themes/custom-theme/core/fonts/aller_ltit-webfont.eot"); //  Request: 16, 0 Unknown
			request10.AddSubRequest(protocol1, qualitestgroup, "/wp-content/themes/custom-theme/core/fonts/aller_it-webfont.eot"); //  Request: 17, 0 Unknown
			request10.AddSubRequest(protocol1, qualitestgroup, "/wp-content/themes/custom-theme/core/fonts/aller_lt-webfont.eot"); //  Request: 18, 304 Not Modified
			request10.AddSubRequest(protocol1, qualitestgroup, "/wp-content/themes/custom-theme/core/fonts/aller_bdit-webfont.eot"); //  Request: 19, 304 Not Modified
			request10.AddSubRequest(protocol1, qualitestgroup, "/wp-content/themes/custom-theme/core/fonts/aller_bd-webfont.eot"); //  Request: 20, 304 Not Modified
			request10.AddSubRequest(protocol1, qualitest_disqus, "/count.js"); //  Request: 21, 302 Found
			Response response10 = request10.Send();
			// Rule: Verify that the result code matches what was recorded
			response10.VerifyResult(HttpStatus.MOVED_PERMANENTLY, ActionType.ACT_WARNING);

			EndTransaction("Start");

			Pause(15821);

			return 1;
		}
		
		int Action2_aboutus()
		{

			StartTransaction("aboutus");

			// ====================================================================================================================================
			// Request: 65, GET, http://www.qualitestgroup.com/about-us/company-overview/, response code=200 OK, overlapping top-level requests:[], other overlapping requests:[67, 69, 70, 71]
			// Rule: Promote Content-Type: text/html sub-requests
			// ====================================================================================================================================
			WebBrowser.SaveCookie(qualitestgroup.Host, "_dc_gtm_UA-2374516-2=1");
			WebBrowser.SaveCookie(qualitestgroup.Host, "s_cc=true");
			WebBrowser.SaveCookie(qualitestgroup.Host, "s_sq=%5B%5BB%5D%5D");
			// Page Title: Quality Assurance & Software Testing Company | QualiTest
			// Cookie(s) sent from client:
			// s_fid=474C37540AA3F738-3496B73ED96122BE
			//  _ga=GA1.2.888569700.1434013792
			//  _dc_gtm_UA-2374516-2=1
			//  s_cc=true
			//  s_sq=%5B%5BB%5D%5D
			Url url65 = new Url(protocol1, qualitestgroup, "/about-us/company-overview/");
			Request request65 = WebBrowser.CreateRequest(HttpMethod.GET, url65, 65);
			request65.SetReferer(new Url(protocol1, qualitestgroup, "/"));
			request65.SetHeader("Dnt", "1");
			// Ignore these URL's when making subrequests. Either they do not appear in the recording, or they are fetched in a later request.
			request65.IgnoreSubRequest(protocol1, qualitestgroup, "/favicon.ico");
			request65.IgnoreSubRequest(protocol1, qualitestgroup, "/assets/MultiPlan_logo.png");
			// References to the following page resources could not be found within the contents of the received web page.
			// This can occur because resources are fetched as a result of style sheets or the browser executing script code e.g. JavaScript.
			request65.AddSubRequest(protocol1, qualitestgroup, "/wp-content/themes/custom-theme/core/fonts/aller_it-webfont.eot"); //  Request: 75, 304 Not Modified
			request65.AddSubRequest(protocol1, qualitestgroup, "/wp-content/themes/custom-theme/core/fonts/aller_ltit-webfont.eot"); //  Request: 78, 304 Not Modified
			request65.AddSubRequest(protocol1, qualitestgroup, "/wp-content/themes/custom-theme/core/fonts/aller_rg-webfont.eot"); //  Request: 80, 304 Not Modified
			Response response65 = request65.Send();
			// Rule: Verify that the page title matches what was recorded
			response65.VerifyTitle("Quality Assurance &amp; Software Testing Company | QualiTest", ActionType.ACT_WARNING);
			// Rule: Verify that the result code matches what was recorded
			response65.VerifyResult(HttpStatus.OK, ActionType.ACT_WARNING);

			EndTransaction("aboutus");

			return 1;
		}
		
	}
}
