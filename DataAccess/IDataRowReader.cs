using System;

namespace DataAccess
{
    public interface IDataRowReader
    {
        bool Read();
        bool HasRows();
        byte GetByte(string name);
        DateTimeOffset GetDateTimeOffset(string name);
        DateTime GetDateTime(string name);
        int GetInt32(string name);
        double GetDouble(string name);
        string GetString(string name);
        T GetValue<T>(string name);
    }
}