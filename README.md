TestCallContext
===============

Dabbling with the [CallContext](http://msdn.microsoft.com/en-us/library/system.runtime.remoting.messaging.callcontext.aspx) 
in .NET

The MvcApplication1 sample demonstrates ASP.NET's thread agility for 
async operations, which causes CallContext's stored data to be cleared.

This behavior is why CallContext is unsuitable for storing data for a request.
