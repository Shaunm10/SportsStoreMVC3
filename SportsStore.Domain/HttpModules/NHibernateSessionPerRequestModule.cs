// -----------------------------------------------------------------------
// <copyright file="NHibernateSessionPerRequestModule.cs" company="The Advisory Board Company">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace SportsStore.Domain.HttpModules
{
    using System;
    using System.Web;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NHibernate;
    using NHibernate.Context;

    using SportsStore.Domain.NhibernateSessionFactories;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class NHibernateSessionPerRequestModule : IHttpModule
    {
        #region Implementation of IHttpModule

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application </param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Application_BeginRequest);
            context.EndRequest += new EventHandler(Application_EndRequest);
        }

       
        void Application_BeginRequest(object sender, EventArgs e)
        {
            ISession session = StaticSessionManager.OpenSession();
            session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }
        
        void Application_EndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(StaticSessionManager.SessionFactory);

            if (session != null)
            {
                try
                {
                    session.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    session.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    session.Close();
                }
            }
        }


        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
           
        }

        #endregion
    }
}
