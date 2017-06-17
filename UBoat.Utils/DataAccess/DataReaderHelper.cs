using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess
{
    public class DataReaderHelper : IDisposable
    {
        private Dictionary<string, int> m_OrdinalCache;
        private bool m_OwnsDataReader;

        public DbDataReader DataReader { get; private set; }

        public DataReaderHelper(DbDataReader reader) 
            : this(reader, true) 
        { }
        public DataReaderHelper(DbDataReader reader, bool ownsDataReader)
        {
            m_OrdinalCache = new Dictionary<string, int>();
            this.DataReader = reader;
            m_OwnsDataReader = ownsDataReader;
        }

        public bool NextResult()
        {
            m_OrdinalCache.Clear();
            return DataReader.NextResult();
        }

        public bool Read()
        {
            return DataReader.Read();
        }

        public bool GetBoolean(string name)
        {
            return DataReader.GetBoolean(zGetOrdinal(name));
        }
        public bool? GetNullableBoolean(string name)
        {
            return zGetNullableValueAccessor<bool?>(name, o => DataReader.GetBoolean(o));
        }

        public byte GetByte(string name)
        {
            return DataReader.GetByte(zGetOrdinal(name));
        }
        public byte? GetNullableByte(string name)
        {
            return zGetNullableValueAccessor<byte?>(name, o => DataReader.GetByte(o));
        }

        public long GetBytes(string name, long fieldOffset, byte[] buffer, int bufferOffset, int length)
        {
            return DataReader.GetBytes(zGetOrdinal(name), fieldOffset, buffer, bufferOffset, length);
        }
        public long GetNullableBytes(string name, long fieldOffset, byte[] buffer, int bufferOffset, int length)
        {
            return zGetNullableValueAccessor<long>(name, o => DataReader.GetBytes(o, fieldOffset, buffer, bufferOffset, length));
        }

        public char GetChar(string name)
        {
            return DataReader.GetChar(zGetOrdinal(name));
        }
        public char? GetNullableChar(string name)
        {
            return zGetNullableValueAccessor<char?>(name, o => DataReader.GetChar(o));
        }

        public long GetChars(string name, long fieldOffset, char[] buffer, int bufferOffset, int length)
        {
            return DataReader.GetChars(zGetOrdinal(name), fieldOffset, buffer, bufferOffset, length);
        }
        public long GetNullableChars(string name, long fieldOffset, char[] buffer, int bufferOffset, int length)
        {
            return zGetNullableValueAccessor<long>(name, o => DataReader.GetChars(o, fieldOffset, buffer, bufferOffset, length));
        }

        public string GetDataTypeName(string name)
        {
            return DataReader.GetDataTypeName(zGetOrdinal(name));
        }

        public DateTime GetDateTime(string name)
        {
            return DataReader.GetDateTime(zGetOrdinal(name));
        }
        public DateTime? GetNullableDateTime(string name)
        {
            return zGetNullableValueAccessor<DateTime?>(name, o => DataReader.GetDateTime(o));
        }

        public decimal GetDecimal(string name)
        {
            return DataReader.GetDecimal(zGetOrdinal(name));
        }
        public decimal? GetNullableDecimal(string name)
        {
            return zGetNullableValueAccessor<decimal?>(name, o => DataReader.GetDecimal(o));
        }

        public double GetDouble(string name)
        {
            return DataReader.GetDouble(zGetOrdinal(name));
        }
        public double? GetNullableDouble(string name)
        {
            return zGetNullableValueAccessor<double?>(name, o => DataReader.GetDouble(o));
        }

        public Type GetFieldType(string name)
        {
            return DataReader.GetFieldType(zGetOrdinal(name));
        }

        public T GetFieldValue<T>(string name)
        {
            return DataReader.GetFieldValue<T>(zGetOrdinal(name));
        }
        public T GetNullableFieldValue<T>(string name)
        {
            return zGetNullableValueAccessor<T>(name, o => DataReader.GetFieldValue<T>(o));
        }

        public float GetFloat(string name)
        {
            return DataReader.GetFloat(zGetOrdinal(name));
        }
        public float? GetNullableFloat(string name)
        {
            return zGetNullableValueAccessor<float?>(name, o => DataReader.GetFloat(o));
        }

        public Guid GetGuid(string name)
        {
            return DataReader.GetGuid(zGetOrdinal(name));
        }
        public Guid? GetNullableGuid(string name)
        {
            return zGetNullableValueAccessor<Guid?>(name, o => DataReader.GetGuid(o));
        }

        public short GetInt16(string name)
        {
            return DataReader.GetInt16(zGetOrdinal(name));
        }
        public short? GetNullableInt16(string name)
        {
            return zGetNullableValueAccessor<short?>(name, o => DataReader.GetInt16(o));
        }

        public int GetInt32(string name)
        {
            return DataReader.GetInt32(zGetOrdinal(name));
        }
        public int? GetNullableInt32(string name)
        {
            return zGetNullableValueAccessor<int?>(name, o => DataReader.GetInt32(o));
        }

        public long GetInt64(string name)
        {
            return DataReader.GetInt64(zGetOrdinal(name));
        }
        public long? GetNullableInt64(string name)
        {
            return zGetNullableValueAccessor<long?>(name, o => DataReader.GetInt64(o));
        }

        public string GetString(string name)
        {
            return DataReader.GetString(zGetOrdinal(name));
        }
        public string GetNullableString(string name)
        {
            return zGetNullableValueAccessor<string>(name, o => DataReader.GetString(o));
        }

        public object GetValue(string name)
        {
            return DataReader.GetValue(zGetOrdinal(name));
        }
        public object GetNullableValue(string name)
        {
            return zGetNullableValueAccessor<object>(name, o => DataReader.GetValue(o));
        }

        public bool IsDBNull(string name)
        {
            return DataReader.IsDBNull(zGetOrdinal(name));
        }

        public object this[string name]
        {
            get { return DataReader[zGetOrdinal(name)]; }
        }

        public void Dispose()
        {
            this.m_OrdinalCache.Clear();
            this.m_OrdinalCache = null;
            if (m_OwnsDataReader)
            {
                this.DataReader.Dispose();
            }
            this.DataReader = null;
        }

        private int zGetOrdinal(string name)
        {
            int ordinal;
            if (!m_OrdinalCache.TryGetValue(name, out ordinal))
            {
                ordinal = DataReader.GetOrdinal(name);
                m_OrdinalCache.Add(name, ordinal);
            }
            return ordinal;
        }

        private T zGetNullableValueAccessor<T>(string name, Func<int, T> valueAccessor)
        {
            int ordinal = zGetOrdinal(name);
            if (!DataReader.IsDBNull(ordinal))
            {
                return valueAccessor(ordinal);
            }
            return default(T);
        }
    }
}
