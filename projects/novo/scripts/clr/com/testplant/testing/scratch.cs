// Script Generator Version - NOT generated (script specification)

using System;
using System.Collections.Generic;
using System.Text;

using Facilita.Native;
using Facilita.Web;
using Facilita.Fc.Runtime;

using AVirtualUserScript = com.testplant.testing.MonitorUserScript;

namespace com.testplant.testing
{
	public class scratch:AVirtualUserScript
	{

        IpEndPoint unilever = null;  // a parameterized web server address
        Protocol protocol1 = null;  // a parameterized protocol

		public override void Pre()
		{
			//do not remove following line
			base.Pre();
			
			// put any code that needs to execute at the start of the test here
            WebBrowser.DefaultUserAgent = GetString("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko");
            WebBrowser.SetDefaultHeader("Accept-Language", "en-GB");
            WebBrowser.DefaultFollowRedirects = true;
            WebBrowser.DefaultRetrieveSubRequests = true;
            WebBrowser.HostFilteringMode = HostFilteringMode.WHITELIST;
		}

		public override void Script()
		{
			// TODO Place your script variables here.
                        
            // Place your iterated script code here.
            StartTransaction("one");
            WriteMessage("hello one");
            QMEndTransaction("one");

            unilever = new IpEndPoint(GetString("unileverHost", "www.unilever.com"), GetInt("unileverPort", 80));

            protocol1 = GetProtocol("protocol1", "http");

            // Only requests to the hosts below will be included in the test
            WebBrowser.IncludeHost(GetString("unileverHost", "www.unilever.com"));

            Action1_010_homepage();
    
		}

        int Action1_010_homepage()
        {

            StartTransaction("010_homepage");

            // ====================================================================================================================================
            // Request: 22, GET, http://www.unilever.com/, response code=200 OK, overlapping top-level requests:[], other overlapping requests:[]
            // Rule: Promote Content-Type: text/html sub-requests
            // ====================================================================================================================================
            // Page Title: Unilever global company website | Unilever Global | Unilever global company website
            Url url22 = new Url(protocol1, unilever, "/");
            Request request22 = WebBrowser.CreateRequest(HttpMethod.GET, url22, 22);
            request22.SetHeader("Dnt", "1");
            // Ignore these URL's when making subrequests. Either they do not appear in the recording, or they are fetched in a later request.
            request22.IgnoreSubRequest(protocol1, unilever, "/Content/Images/favicon.ico");
            request22.IgnoreSubRequest(protocol1, unilever, "/Content/Styles/old-ie.css");
            request22.IgnoreSubRequest(protocol1, unilever, "/Content/Scripts/vendor/respond.min.js");
            request22.IgnoreSubRequest(protocol1, unilever, "/Content/Scripts/combined.legacy.min.js");
            request22.IgnoreSubRequest(protocol1, unilever, "/Content/Styles/old-ie-blessed1.css");
            // References to the following page resources could not be found within the contents of the received web page.
            // This can occur because resources are fetched as a result of style sheets or the browser executing script code e.g. JavaScript.
            request22.AddSubRequest(protocol1, unilever, "/Content/Styles/app.css"); //  Request: 23, 200 OK
            request22.AddSubRequest(protocol1, unilever, "/Content/fonts/unilever-iconfont.eot"); //  Request: 39, 200 OK
            request22.AddSubRequest(protocol1, unilever, "/Content/Scripts/combined.min.js"); //  Request: 40, 200 OK
            request22.AddSubRequest(protocol1, unilever, "/Content/fonts/unileverillustrativebeta-webfont.eot"); //  Request: 41, 200 OK
            request22.AddSubRequest(protocol1, unilever, "/Content/fonts/DINWebPro-Light.woff"); //  Request: 42, 200 OK
            request22.AddSubRequest(protocol1, unilever, "/Content/images/curve.png"); //  Request: 43, 200 OK
            request22.AddSubRequest(protocol1, unilever, "/Content/fonts/DINWebPro-Bold.woff"); //  Request: 44, 200 OK
            request22.AddSubRequest(protocol1, unilever, "/Content/images/hr.png"); //  Request: 45, 200 OK
            request22.AddSubRequest(protocol1, unilever, "/Content/images/hr_down.png"); //  Request: 46, 200 OK
            request22.AddSubRequest(protocol1, unilever, "/Images/bg1_tcm244-409210.jpg"); //  Request: 48, 200 OK
            request22.AddSubRequest(protocol1, unilever, "/Images/Homepage-example-seven_tcm244-425273.jpg"); //  Request: 49, 200 OK
            Response response22 = request22.Send();
            // Rule: Verify that the page title matches what was recorded
            response22.VerifyTitle("Unilever global company website | Unilever Global | Unilever global company website", ActionType.ACT_WARNING);
            // Rule: Verify that the result code matches what was recorded
            response22.VerifyResult(HttpStatus.OK, ActionType.ACT_WARNING);

            QMEndTransaction("010_homepage");

            return 1;
        }

        
	}
}
