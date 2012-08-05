// -----------------------------------------------------------------------
// <copyright file="NHibernateSessionManager.cs" company="The Advisory Board Company">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace SportsStore.Domain.NhibernateSessionFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NHibernate;
    using NHibernate.Cfg;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class StaticSessionManager
    {
        public static readonly ISessionFactory SessionFactory;

        /// <summary>
        /// private static constructor
        /// </summary>
        static StaticSessionManager()
        {
            try
            {
                Configuration cfg = new Configuration();

                if (SessionFactory != null)
                {
                    throw new Exception("trying to init SessionFactory twice!");
                }

                SessionFactory = cfg.Configure().BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new ApplicationException("NHibernate initialization failed", ex);
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
