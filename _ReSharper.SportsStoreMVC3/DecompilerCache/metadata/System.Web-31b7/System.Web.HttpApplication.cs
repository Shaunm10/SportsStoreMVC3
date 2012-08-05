// Type: System.Web.HttpApplication
// Assembly: System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Web.dll

using System;
using System.ComponentModel;
using System.Runtime;
using System.Security.Principal;
using System.Web.SessionState;

namespace System.Web
{
    [ToolboxItem(false)]
    public class HttpApplication : IHttpAsyncHandler, IHttpHandler, IComponent, IDisposable
    {
        public HttpApplication();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HttpContext Context { get; }

        protected EventHandlerList Events { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HttpRequest Request { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public HttpResponse Response { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HttpSessionState Session { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public HttpApplicationState Application { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public HttpServerUtility Server { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IPrincipal User { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HttpModuleCollection Modules { get; }

        #region IComponent Members

        public virtual void Dispose();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ISite Site { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        set; }

        public event EventHandler Disposed;

        #endregion

        #region IHttpAsyncHandler Members

        IAsyncResult IHttpAsyncHandler.BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData);
        void IHttpAsyncHandler.EndProcessRequest(IAsyncResult result);
        void IHttpHandler.ProcessRequest(HttpContext context);
        bool IHttpHandler.IsReusable { get; }

        #endregion

        public void CompleteRequest();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnBeginRequestAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnBeginRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnAuthenticateRequestAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnAuthenticateRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                  object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnPostAuthenticateRequestAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnPostAuthenticateRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                      object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnAuthorizeRequestAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnAuthorizeRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnPostAuthorizeRequestAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnPostAuthorizeRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                   object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnResolveRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnResolveRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                  object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnPostResolveRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnPostResolveRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                      object state);

        public void AddOnMapRequestHandlerAsync(BeginEventHandler bh, EndEventHandler eh);
        public void AddOnMapRequestHandlerAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnPostMapRequestHandlerAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnPostMapRequestHandlerAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                    object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnAcquireRequestStateAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnAcquireRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                  object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnPostAcquireRequestStateAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnPostAcquireRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                      object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnPreRequestHandlerExecuteAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnPreRequestHandlerExecuteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                       object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnPostRequestHandlerExecuteAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnPostRequestHandlerExecuteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                        object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnReleaseRequestStateAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnReleaseRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                  object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnPostReleaseRequestStateAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnPostReleaseRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                      object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnUpdateRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnUpdateRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                 object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnPostUpdateRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnPostUpdateRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler,
                                                     object state);

        public void AddOnLogRequestAsync(BeginEventHandler bh, EndEventHandler eh);
        public void AddOnLogRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        public void AddOnPostLogRequestAsync(BeginEventHandler bh, EndEventHandler eh);
        public void AddOnPostLogRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void AddOnEndRequestAsync(BeginEventHandler bh, EndEventHandler eh);

        public void AddOnEndRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        public virtual void Init();
        public virtual string GetVaryByCustomString(HttpContext context, string custom);
        public virtual string GetOutputCacheProviderName(HttpContext context);
        public event EventHandler BeginRequest;
        public event EventHandler AuthenticateRequest;
        public event EventHandler PostAuthenticateRequest;
        public event EventHandler AuthorizeRequest;
        public event EventHandler PostAuthorizeRequest;
        public event EventHandler ResolveRequestCache;
        public event EventHandler PostResolveRequestCache;
        public event EventHandler MapRequestHandler;
        public event EventHandler PostMapRequestHandler;
        public event EventHandler AcquireRequestState;
        public event EventHandler PostAcquireRequestState;
        public event EventHandler PreRequestHandlerExecute;
        public event EventHandler PostRequestHandlerExecute;
        public event EventHandler ReleaseRequestState;
        public event EventHandler PostReleaseRequestState;
        public event EventHandler UpdateRequestCache;
        public event EventHandler PostUpdateRequestCache;
        public event EventHandler LogRequest;
        public event EventHandler PostLogRequest;
        public event EventHandler EndRequest;
        public event EventHandler Error;
        public event EventHandler PreSendRequestHeaders;
        public event EventHandler PreSendRequestContent;
    }
}
