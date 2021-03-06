﻿using Dapper.Linq.Core.Configuration;
using System;

namespace Dapper.Linq.Core.Sessions
{
    public class StaticConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IDapperConfiguration _dapperConfiguration;

        public StaticConnectionStringProvider(IDapperConfiguration dapperConfiguration)
        {
            _dapperConfiguration = dapperConfiguration;
        }

        public string ConnectionString(string connectionStringName)
        {
            if (!_dapperConfiguration.AllConnectionStrings.ContainsKey(connectionStringName))
                throw new NullReferenceException(string.Format("Connection string '{0}' not found", connectionStringName));

            return _dapperConfiguration.AllConnectionStrings[connectionStringName];
        }
    }

}
