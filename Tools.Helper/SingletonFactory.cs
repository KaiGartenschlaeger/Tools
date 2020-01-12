using System;
using System.Collections.Generic;

namespace Tools.Helper
{
    /// <summary>
    /// Dient zur Verwaltung von Instanzen anhand des Singleton Patterns.
    /// </summary>
    public static class SingletonFactory
    {
        #region Fields

        private static Dictionary<string, object> m_instances = new Dictionary<string, object>();
        private static object m_instancesLock = new object();

        #endregion

        #region Methods

        /// <summary>
        /// Liefert eine Instanz vom Typ TInstance zurück.
        /// Falls noch keine Instanz erstellt wurde, wird automatisch eine neue erzeugt.
        /// </summary>
        public static TInstance GetInstance<TInstance>()
            where TInstance : class, new()
        {
            Type type = typeof(TInstance);
            string key = type.FullName;

            TInstance result;
            lock (m_instancesLock)
            {
                if (m_instances.ContainsKey(key))
                {
                    result = m_instances[key] as TInstance;
                }
                else
                {
                    result = new TInstance();
                    m_instances.Add(key, result);
                }
            }

            return result;
        }

        /// <summary>
        /// Entfernt die angegebene Instanz.
        /// </summary>
        public static bool RemoveInstance<TInstance>()
        {
            Type type = typeof(TInstance);

            lock (m_instancesLock)
            {
                return m_instances.Remove(type.FullName);
            }
        }

        /// <summary>
        /// Entfernt alle hinzugefügten Instanzen.
        /// </summary>
        public static void ClearInstances()
        {
            lock (m_instancesLock)
            {
                m_instances.Clear();
            }
        }

        #endregion
    }
}
