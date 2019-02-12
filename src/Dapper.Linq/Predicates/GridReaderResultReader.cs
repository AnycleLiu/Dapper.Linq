﻿using Dapper.Linq.Core.Predicates;
using System.Collections.Generic;

namespace Dapper.Linq.Predicates
{
    public class GridReaderResultReader : IMultipleResultReader
    {
        private readonly SqlMapper.GridReader _reader;

        public GridReaderResultReader(SqlMapper.GridReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<T> Read<T>()
        {
            return _reader.Read<T>();
        }
    }
}