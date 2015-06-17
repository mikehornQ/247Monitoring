// Script Generator Version $[GENVERSION]

using System;
using System.Collections.Generic;
using System.Text;

using Facilita.Native;
using Facilita.Web;
using Facilita.Fc.Runtime;

using AVirtualUserScript = $[USERSCRIPTCLASS];

namespace $[PACKAGE]
{
	public class $[SCRIPTNAME]:AVirtualUserScript
	{
		$[INSTANCEVARIABLES]

		public override void Pre()
		{
			//do not remove following line
			base.Pre();
			$[PRESCRIPT]

			// put any code that needs to execute at the start of the test here
		}

		public override void Script()
		{
			$[SCRIPT]
		}

        $[INSTANCEMETHODS]
	}
}
