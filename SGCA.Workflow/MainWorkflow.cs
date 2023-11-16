using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCA.Workflow
{
    public static class MainWorkflow
    {
        public static void Start() 
        {
            ReadGCodeFileWorkflow.Start();
            AbstractGCodeWorkflow.Start();

        
        }
    }
}
