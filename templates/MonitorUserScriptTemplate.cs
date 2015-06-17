using System;
using System.Collections.Generic;
using System.Text;

using Facilita.Native;
using Facilita.Web;
using Facilita.Fc.Runtime;

using AVirtualUserScript = $[BASEUSERSCRIPTCLASS];

namespace $[PACKAGE]
{
	public abstract class $[SCRIPTNAME]:AVirtualUserScript
	{
		public new $[VUCLASSNAME] VU
		{
			get {return ($[VUCLASSNAME])((($[BASEUSERSCRIPTCLASS])this).VU);}
		}

		public override void Pre()
		{
			//do not remove following line
			base.Pre();
			$[PRESCRIPT]

			// put any code that needs to execute at the start of the test here
		}
	}
}
