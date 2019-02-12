using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.Linq.Core.Mapper;
using Dapper.Linq.Core.Predicates;
using Dapper.Linq.Core.Sql;
using Dapper.Linq.Mapper;
using Dapper.Linq.Sql;

namespace Dapper.Linq.Predicates
{
    public abstract class BasePredicate : IBasePredicate
    {
        public abstract string GetSql(ISqlGenerator sqlGenerator, IDictionary<string, object> parameters);
        public string PropertyName { get; set; }

        protected virtual string GetColumnName(Type entityType, ISqlGenerator sqlGenerator, string propertyName)
        {
            IClassMapper map = sqlGenerator.Configuration.GetMap(entityType);
            if (map == null)
            {
                throw new NullReferenceException(string.Format("Map was not found for {0}", entityType));
            }

            IPropertyMap propertyMap = map.Properties.SingleOrDefault(p => p.Name == propertyName);
            if (propertyMap == null)
            {
                throw new NullReferenceException(string.Format("{0} was not found for {1}", propertyName, entityType));
            }

            return sqlGenerator.GetColumnName(map, propertyMap, false);
        }
    }
}