using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBase
{
    /// <summary>
    /// 创建Database实例的工厂类.
    /// </summary>
    public class DatabaseFactory
    {
        private static Database instance;

        private static readonly object _object = new object();

        private DatabaseFactory()
        {
        }
        /// <summary>
        /// 创建类实例.
        /// </summary>
        /// <returns></returns>
        public static Database CreateDatabase()
        {
            if (instance == null)
            {
                lock (_object)
                {
                    if (instance == null)
                    {
                        instance = new Database("DefaultConnection");
                    }
                }
            }

            return instance;
        }
    }
}

