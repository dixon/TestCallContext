TestCallContext
===============

Dabbling with [CallContext](http://msdn.microsoft.com/en-us/library/system.runtime.remoting.messaging.callcontext.aspx) 
in .NET

The MvcApplication1 sample demonstrates ASP.NET's thread agility for async operations, 
which causes CallContext's stored data to be cleared. This behavior is why CallContext 
is unsuitable for storing a request's data.

Start debugging and watch the output window as requests are executed; log output shows the issue.



See also:

 - http://stackoverflow.com/questions/657735/how-is-asp-net-multithreaded/657748#657748
 - http://stackoverflow.com/questions/273301/callcontext-vs-threadstatic
