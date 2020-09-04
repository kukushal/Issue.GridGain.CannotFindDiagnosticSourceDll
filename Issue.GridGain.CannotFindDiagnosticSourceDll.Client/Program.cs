using Apache.Ignite.Core;
using Issue.GridGain.CannotFindDiagnosticSourceDll.Task;

namespace Issue.GridGain.CannotFindDiagnosticSourceDll.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ignite = Ignition.StartFromApplicationConfiguration())
            {
                ignite.GetCluster().ForServers().GetCompute().Call(new UseDiagnosticsSource());
            }
        }
    }
}
