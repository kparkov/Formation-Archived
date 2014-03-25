using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormationGame.Controllers
{
    public class EsbentestController : FormationBaseController
    {
        public ActionResult MyNewAction(){
         

            var Dieposition1 = new Tools.Die();
            var Dieposition2 = new Tools.Die();

            AddToView(Dieposition1);
            AddToView(Dieposition2);
            
            return ShowObjects(); 
        
        }    
        //eksperimentet er her at få returneret to terningers Value på Dieposition 1 og 1- Det virker ikke, det lorrrt.

       
    }
}
