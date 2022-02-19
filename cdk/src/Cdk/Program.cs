using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cdk
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new ClimateControlStack(app, "ClimateControl", new StackProps
            {
                Env = new Amazon.CDK.Environment
                {
                    Account = "596516611115",
                    Region = "ap-southeast-2",
                }
            });
            app.Synth();
        }
    }
}
