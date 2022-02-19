using Amazon.CDK;
using Constructs;

namespace Cdk
{
    public class ClimateControlStack : Stack
    {
        internal ClimateControlStack(
            Construct scope, 
            string id, 
            IStackProps props = null
        ) : base(scope, id, props)
        {
            new Amazon.CDK.AWS.Lambda.Function(this, "Function", new Amazon.CDK.AWS.Lambda.FunctionProps {
                Code = Amazon.CDK.AWS.Lambda.Code.FromAsset("../target/x86_64-unknown-linux-gnu/release/bootstrap.zip"),
                // Because the handler is bundled with the runtime, this value does not matter
                Handler = "<placeholder>",  
                // Runtime is included in asset, runs under Amazon Linux 2
                Runtime = Amazon.CDK.AWS.Lambda.Runtime.PROVIDED_AL2,
            });
        }
    }
}
