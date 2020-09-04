# Issue.GridGain.CannotFindDiagnosticSourceDll

Reproduces GridGain server running on .NET Core 2.0 failing to execute a compute job depending on NuGet package 
`System.Diagnostics.DiagnosticSource/4.6.0`.

## How to Run
The solution is built with GridGain.NET 8.7.21 and the server assemblies are in directory `gridgain-dotnet-8.7.21`.

1. Build the solution. This will also copy server JARs and assemblies to the GridGain server directory:
```
dotnet build Issue.GridGain.CannotFindDiagnosticSourceDll.sln
```


2. Run GridGain server node:
```
cd gridgain-dotnet-8.7.21
dotnet Apache.Ignite.dll
```

3. Run compute job launcher:
```
dotnet run --no-build --project .\Issue.GridGain.CannotFindDiagnosticSourceDll.Client\Issue.GridGain.CannotFindDiagnosticSourceDll.Client.csproj
```

The compute job fails on the server saying it cannot find `System.Diagnostics.DiagnosticSource`:

```
[00:31:13,109][SEVERE][pub-#66][GridJobWorker] Failed to execute job [jobId=759c70b5471-ee68b5b9-8608-4678-905b-dc711770bb3b, ses=GridJobSessionImpl [ses=GridTaskSessionImpl [taskName=o.a.i.i.processors.platform.compute.PlatformBalancingSingleClosureTask, dep=LocalDeployment [super=GridDeployment [ts=1599255057964, depMode=SHARED, clsLdr=jdk.internal.loader.ClassLoaders$AppClassLoader@5b37e0d2, clsLdrId=c26970b5471-4241fa8f-2925-4faf-939a-d876694dc4ab, userVer=0, loc=true, sampleClsName=java.lang.String, pendingUndeploy=false, undeployed=false, usage=0]], taskClsName=o.a.i.i.processors.platform.compute.PlatformBalancingSingleClosureTask, sesId=659c70b5471-ee68b5b9-8608-4678-905b-dc711770bb3b, startTime=1599255072819, endTime=9223372036854775807, taskNodeId=ee68b5b9-8608-4678-905b-dc711770bb3b, clsLdr=jdk.internal.loader.ClassLoaders$AppClassLoader@5b37e0d2, closed=false, cpSpi=null, failSpi=null, loadSpi=null, usage=1, fullSup=false, internal=false, topPred=IsAllPredicate [], subjId=ee68b5b9-8608-4678-905b-dc711770bb3b, mapFut=IgniteFuture [orig=GridFutureAdapter [ignoreInterrupts=false, state=INIT, res=null, hash=652970844]], execName=null], jobId=759c70b5471-ee68b5b9-8608-4678-905b-dc711770bb3b]]
class org.apache.ignite.IgniteException: Native platform exception occurred.
	at org.apache.ignite.internal.util.IgniteUtils.convertException(IgniteUtils.java:1088)
	at org.apache.ignite.internal.processors.platform.compute.PlatformAbstractJob.execute(PlatformAbstractJob.java:82)
	at org.apache.ignite.internal.processors.job.GridJobWorker$2.call(GridJobWorker.java:570)
	at org.apache.ignite.internal.util.IgniteUtils.wrapThreadLoader(IgniteUtils.java:7104)
	at org.apache.ignite.internal.processors.job.GridJobWorker.execute0(GridJobWorker.java:564)
	at org.apache.ignite.internal.processors.job.GridJobWorker.body(GridJobWorker.java:491)
	at org.apache.ignite.internal.util.worker.GridWorker.run(GridWorker.java:119)
	at org.apache.ignite.internal.processors.job.GridJobProcessor.processJobExecuteRequest(GridJobProcessor.java:1344)
	at org.apache.ignite.internal.processors.job.GridJobProcessor$JobExecutionListener.onMessage(GridJobProcessor.java:2088)
	at org.apache.ignite.internal.managers.communication.GridIoManager.invokeListener(GridIoManager.java:1711)
	at org.apache.ignite.internal.managers.communication.GridIoManager.processRegularMessage0(GridIoManager.java:1331)
	at org.apache.ignite.internal.managers.communication.GridIoManager.access$4800(GridIoManager.java:153)
	at org.apache.ignite.internal.managers.communication.GridIoManager$8.execute(GridIoManager.java:1216)
	at org.apache.ignite.internal.managers.communication.TraceRunnable.run(TraceRunnable.java:54)
	at java.base/java.util.concurrent.ThreadPoolExecutor.runWorker(ThreadPoolExecutor.java:1128)
	at java.base/java.util.concurrent.ThreadPoolExecutor$Worker.run(ThreadPoolExecutor.java:628)
	at java.base/java.lang.Thread.run(Thread.java:834)
Caused by: PlatformNativeException [cause=System.IO.FileLoadException [idHash=136976151, hash=410676285, ClassName=System.IO.FileLoadException, Data=null, ExceptionMethod=null, FileLoad_FileName=System.Diagnostics.DiagnosticSource, Version=4.0.4.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51, FileLoad_FusionLog=, HelpURL=null, HResult=-2146232799, InnerException=System.IO.FileLoadException [idHash=693386082, hash=-1245934731, ClassName=System.IO.FileLoadException, Data=null, ExceptionMethod=null, FileLoad_FileName=null, FileLoad_FusionLog=null, HelpURL=null, HResult=-2146232799, InnerException=null, Message=Could not load file or assembly 'System.Diagnostics.DiagnosticSource, Version=4.0.4.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'., RemoteStackIndex=0, RemoteStackTraceString=null, Source=System.Private.CoreLib, StackTraceString=   at System.Runtime.Loader.AssemblyLoadContext.LoadFromPath(IntPtr ptrNativeAssemblyLoadContext, String ilPath, String niPath, ObjectHandleOnStack retAssembly)
   at System.Runtime.Loader.AssemblyLoadContext.LoadFromAssemblyPath(String assemblyPath)
   at System.Reflection.Assembly.LoadFrom(String assemblyFile)
   at System.Reflection.Assembly.LoadFromResolveHandler(Object sender, ResolveEventArgs args)
   at System.AppDomain.InvokeResolveEvent(ResolveEventHandler eventHandler, RuntimeAssembly assembly, String name), WatsonBuckets=null], Message=Could not load file or assembly 'System.Diagnostics.DiagnosticSource, Version=4.0.4.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. Could not find or load a specific file. (Exception from HRESULT: 0x80131621), RemoteStackIndex=0, RemoteStackTraceString=null, Source=Issue.GridGain.CannotFindDiagnosticSourceDll.Task, StackTraceString=   at Issue.GridGain.CannotFindDiagnosticSourceDll.Task.UseDiagnosticsSource.Invoke()
   at lambda_method(Closure , Object )
   at Apache.Ignite.Core.Impl.Compute.ComputeOutFuncWrapper.Invoke() in C:\Dev\github.com\gridgain\gridgain\modules\platforms\dotnet\Apache.Ignite.Core\Impl\Compute\ComputeOutFunc.cs:line 69
   at Apache.Ignite.Core.Impl.Compute.ComputeRunner.ExecuteJobAndWriteResults[T](IIgniteInternal ignite, PlatformMemoryStream stream, T job, Func`2 execFunc) in C:\Dev\github.com\gridgain\gridgain\modules\platforms\dotnet\Apache.Ignite.Core\Impl\Compute\ComputeRunner.cs:line 58, WatsonBuckets=null]]
	at org.apache.ignite.internal.processors.platform.PlatformContextImpl.createNativeException(PlatformContextImpl.java:558)
	at org.apache.ignite.internal.processors.platform.utils.PlatformUtils.readInvocationResult(PlatformUtils.java:851)
	at org.apache.ignite.internal.processors.platform.compute.PlatformClosureJob.execute0(PlatformClosureJob.java:83)
	at org.apache.ignite.internal.processors.platform.compute.PlatformAbstractJob.execute(PlatformAbstractJob.java:79)
	... 15 more
```