using Apache.Ignite.Core.Compute;
using System;
using System.Diagnostics;

namespace Issue.GridGain.CannotFindDiagnosticSourceDll.Task
{
    public sealed class UseDiagnosticsSource : IComputeFunc<int>
    {
        public int Invoke()
        {
            DiagnosticListener.AllListeners.Subscribe(new DiagnosticObserver());

            return 0;
        }

        private sealed class DiagnosticObserver : IObserver<DiagnosticListener>
        {
            void IObserver<DiagnosticListener>.OnNext(DiagnosticListener diagnosticListener)
            {
                Console.WriteLine(diagnosticListener.Name);
            }

            void IObserver<DiagnosticListener>.OnError(Exception error) { }

            void IObserver<DiagnosticListener>.OnCompleted() { }
        }
    }
}
