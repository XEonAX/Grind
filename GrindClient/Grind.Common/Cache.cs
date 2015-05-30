using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Data.SQLite;
using System.Data;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;

namespace Grind.Common
{
    public static class Cache
    {
        private static SQLiteConnection grindDBConnection;
        private static SQLiteDataReader grindDBDataReader;
        private static Hashtable reflectionProperties = new Hashtable();
        private static Hashtable reflectionDBTypeProperties = new Hashtable();

        public static List<TimeStamp> PeopleTS = new List<TimeStamp>();
        public static List<TimeStamp> TasksTS = new List<TimeStamp>();

        public static void SqliteHelperInit(string ConnectionString)
        {
            grindDBConnection = new SQLiteConnection(ConnectionString);
            grindDBConnection.Open();
        }

        #region Reflection
        /// <summary>
        /// Caches PropertyInfo of given Datatype to a HashTable for better performance.
        /// </summary>
        /// <param name="targetType">DataType who's PropertyInfo is to be Cached</param>
        private static void LoadProperties(Type targetType)
        {
            if (reflectionProperties[targetType.FullName] == null)
            {
                List<PropertyInfo> propertyList = new List<PropertyInfo>();
                PropertyInfo[] objectProperties = targetType.GetProperties(/*BindingFlags.Public*/);
                foreach (PropertyInfo currentProperty in objectProperties)
                {
                    if (reflectionDBTypeProperties[currentProperty.Name] == null)
                        reflectionDBTypeProperties.Add(currentProperty.Name,
                            DataTypetoDBType(currentProperty.PropertyType.ToString()));
                    //propertyList.Add(currentProperty);
                }
                reflectionProperties.Add(targetType.FullName, objectProperties.ToList<PropertyInfo>());
                //reflectionproperties[targetObject] = propertyList;
            }
        }
        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            Type datatype = typeof(T);
            LoadProperties(datatype);
            List<PropertyInfo> objectproperties = reflectionProperties[datatype.FullName] as List<PropertyInfo>;
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();

                foreach (PropertyInfo prop in objectproperties)
                {
                    if (prop.PropertyType.GetInterface(typeof(IList<>).FullName) == null && !object.Equals(dr[prop.Name], DBNull.Value))
                    {

                        if (prop.PropertyType.IsEnum)
                        {
                            prop.SetValue(obj, Enum.Parse(prop.PropertyType, dr[prop.Name].ToString(), true), null);
                        }
                        else if (prop.PropertyType == typeof(Int32))
                        {
                            prop.SetValue(obj, Convert.ToInt32(dr[prop.Name]), null);
                        }
                        else if (prop.PropertyType == typeof(DateTime))
                        {
                            prop.SetValue(obj, DateTime.SpecifyKind((DateTime)dr[prop.Name], DateTimeKind.Utc), null);
                        }
                        else
                            prop.SetValue(obj, dr[prop.Name], null);
                    }
                }

                list.Add(obj);
            }
            return list;
        }
        public static T DataReaderMapToObject<T>(IDataReader dr)
        {
            T obj = default(T);
            Type datatype = Activator.CreateInstance<T>().GetType();
            LoadProperties(datatype);
            List<PropertyInfo> objectproperties = reflectionProperties[datatype.FullName] as List<PropertyInfo>;
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();

                foreach (PropertyInfo prop in objectproperties)
                {
                    if (prop.PropertyType.GetInterface(typeof(IList<>).FullName) == null && !object.Equals(dr[prop.Name], DBNull.Value))
                    {

                        if (prop.PropertyType.IsEnum)
                        {
                            prop.SetValue(obj, Enum.Parse(prop.PropertyType, dr[prop.Name].ToString(), true), null);
                        }
                        else if (prop.PropertyType == typeof(Int32))
                        {
                            prop.SetValue(obj, Convert.ToInt32(dr[prop.Name]), null);
                        }
                        else if (prop.PropertyType == typeof(DateTime))
                        {
                            prop.SetValue(obj, DateTime.SpecifyKind((DateTime)dr[prop.Name], DateTimeKind.Utc), null);
                        }
                        else
                            prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                return obj;
            }
            return obj;
        }

        public static string Pluralize(this string s)
        {
            PluralizationService plural =
                PluralizationService.CreateService(
                    CultureInfo.GetCultureInfo("en-us"));
            return plural.Pluralize(s);
        }
        #endregion

        public static string CommaSeperatedColumnName<T>()
        {
            Type datatype = typeof(T);
            LoadProperties(datatype);
            List<PropertyInfo> objectproperties = reflectionProperties[datatype.FullName] as List<PropertyInfo>;
            string ColumnNames = "";
            foreach (PropertyInfo propInfo in objectproperties)
            {
                if (propInfo.PropertyType.GetInterface(typeof(IList<>).FullName) == null)
                    if (ColumnNames == "")
                        ColumnNames = propInfo.Name;
                    else
                        ColumnNames = ColumnNames + "," + propInfo.Name;
            }
            return ColumnNames;
        }
        public static string ParameterizedCommaSeparatedColumnName<T>()
        {
            Type datatype = typeof(T);
            LoadProperties(datatype);
            List<PropertyInfo> objectproperties = reflectionProperties[datatype.FullName] as List<PropertyInfo>;
            string ColumnNames = "";
            foreach (PropertyInfo propInfo in objectproperties)
            {
                if (propInfo.PropertyType.GetInterface(typeof(IList<>).FullName) == null)
                    if (ColumnNames == "")
                        ColumnNames = "@" + propInfo.Name;
                    else
                        ColumnNames = ColumnNames + ",@" + propInfo.Name;


            }
            return ColumnNames;
        }
        public static SQLiteParameterCollection AddParameterstoSqlCommand<T>(SQLiteParameterCollection Params)
        {
            Type datatype = typeof(T);
            LoadProperties(datatype);
            List<PropertyInfo> objectproperties = reflectionProperties[datatype.FullName] as List<PropertyInfo>;
            foreach (PropertyInfo propInfo in objectproperties)
            {
                Params.Add(new SQLiteParameter("@" + propInfo.Name, (DbType)reflectionDBTypeProperties[propInfo.Name]));
            }
            return Params;
        }

        public static SQLiteParameterCollection BuildParametersofSqlCommand<T>(SQLiteParameterCollection Params, T obj)
        {
            Type datatype = typeof(T);
            LoadProperties(datatype);
            List<PropertyInfo> objectproperties = reflectionProperties[datatype.FullName] as List<PropertyInfo>;
            foreach (PropertyInfo propInfo in objectproperties)
            {
                if (propInfo.PropertyType.GetInterface(typeof(IList<>).FullName) == null && !object.Equals(propInfo.GetValue(obj, null), null))
                {

                    if (propInfo.PropertyType.IsEnum)
                    {
                        Params["@" + propInfo.Name].Value = (int)propInfo.GetValue(obj, null);
                    }
                    //else if (propInfo.PropertyType == typeof(Int32))
                    //{
                    //    propInfo.SetValue(Params["@" + propInfo.Name].Value, propInfo.GetValue(obj, null), null);
                    //}
                    else
                        Params["@" + propInfo.Name].Value = propInfo.GetValue(obj, null);
                }
            }
            return Params;
        }


        public static List<string> ParameterListof<T>()
        {
            Type datatype = typeof(T);
            LoadProperties(datatype);
            List<PropertyInfo> objectproperties = reflectionProperties[datatype.FullName] as List<PropertyInfo>;
            List<string> Parameters = new List<string>();
            foreach (PropertyInfo propInfo in objectproperties)
            {
                Parameters.Add("@" + propInfo.Name);
            }
            return Parameters;
        }

        public static DbType DataTypetoDBType(string DataType)
        {
            switch (DataType)
            {
                case "byte": return DbType.Byte;
                case "sbyte": return DbType.SByte;
                case "short": return DbType.Int16;
                case "ushort": return DbType.UInt16;
                case "int": return DbType.Int32;
                case "uint": return DbType.UInt32;
                case "long": return DbType.Int64;
                case "ulong": return DbType.UInt64;
                case "float": return DbType.Single;
                case "double": return DbType.Double;
                case "decimal": return DbType.Decimal;
                case "bool": return DbType.Boolean;
                case "string": return DbType.String;
                case "char": return DbType.StringFixedLength;
                case "Guid": return DbType.Guid;
                case "DateTime": return DbType.DateTime;
                case "DateTimeOffset": return DbType.DateTimeOffset;
                case "byte[]": return DbType.Binary;
                case "byte?": return DbType.Byte;
                case "sbyte?": return DbType.SByte;
                case "short?": return DbType.Int16;
                case "ushort?": return DbType.UInt16;
                case "int?": return DbType.Int32;
                case "uint?": return DbType.UInt32;
                case "long?": return DbType.Int64;
                case "ulong?": return DbType.UInt64;
                case "float?": return DbType.Single;
                case "double?": return DbType.Double;
                case "decimal?": return DbType.Decimal;
                case "bool?": return DbType.Boolean;
                case "char?": return DbType.StringFixedLength;
                case "Guid?": return DbType.Guid;
                case "DateTime?": return DbType.DateTime;
                case "DateTimeOffset?": return DbType.DateTimeOffset;
                case "System.Data.Linq.Binary": return DbType.Binary;
                default: return DbType.Object;
            }
        }

        public static bool AddObjects<T>(IEnumerable<T> Objects)
        {
            string typeName = typeof(T).Name;
            using (SQLiteTransaction mytransaction = grindDBConnection.BeginTransaction())
            {
                using (SQLiteCommand mycommand = new SQLiteCommand(grindDBConnection))
                {
                    mycommand.CommandText = @"INSERT INTO [" + typeName.Pluralize().ToLower() + "] ("
                        + CommaSeperatedColumnName<T>()
                        + ") VALUES ("
                        + ParameterizedCommaSeparatedColumnName<T>()
                        + ")";

                    AddParameterstoSqlCommand<T>(mycommand.Parameters);
                    foreach (T obj in Objects)
                    {
                        BuildParametersofSqlCommand<T>(mycommand.Parameters, obj);
                        mycommand.ExecuteNonQuery();
                        if (typeName == "Person")
                            PeopleTS.Add((TimeStamp)(object)obj);
                        else
                            TasksTS.Add((TimeStamp)(object)obj);
                    }
                }
                mytransaction.Commit();
            }
            return false;
        }
        public static bool AddObject<T>(T Obj)
        {
            using (SQLiteTransaction mytransaction = grindDBConnection.BeginTransaction())
            {
                using (SQLiteCommand mycommand = new SQLiteCommand(grindDBConnection))
                {
                    mycommand.CommandText = @"INSERT INTO [" + typeof(T).Name.Pluralize().ToLower() + "] ("
                        + CommaSeperatedColumnName<T>()
                        + ") VALUES ("
                        + ParameterizedCommaSeparatedColumnName<T>()
                        + ")";
                    AddParameterstoSqlCommand<T>(mycommand.Parameters);
                    BuildParametersofSqlCommand<T>(mycommand.Parameters, Obj);
                    mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Only Specify Person or Task</typeparam>
        /// <param name="id">id of Object to retrieve</param>
        /// <returns>Person or task from Local DB by id</returns>
        public static T GetObject<T>(int id)
        {
            SQLiteCommand grindDBReadListcmd = new SQLiteCommand(grindDBConnection);
            grindDBReadListcmd.CommandText = @"SELECT * FROM [" + typeof(T).Name.Pluralize().ToLower() + "] where id =" + id.ToString();
            grindDBDataReader = grindDBReadListcmd.ExecuteReader();
            return DataReaderMapToObject<T>(grindDBDataReader);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Only Specify Person or Task</typeparam>
        /// <returns>Returns List of Person or Task from Local DB</returns>
        public static List<T> GetObjects<T>()
        {
            List<T> objs = default(List<T>);
            SQLiteCommand grindDBReadListcmd = new SQLiteCommand(grindDBConnection);
            string typeName = typeof(T).Name;
            grindDBReadListcmd.CommandText = @"SELECT * FROM [" + typeName.Pluralize().ToLower() + "]";
            grindDBDataReader = grindDBReadListcmd.ExecuteReader();
            objs = DataReaderMapToList<T>(grindDBDataReader);
            switch (typeName)
            {
                case "Person":
                    PeopleTS.Clear();
                    foreach (TimeStamp TS in (IEnumerable<TimeStamp>)objs)
                        PeopleTS.Add(TS.AsTimeStamp());
                    break;
                case "Task":
                    TasksTS.Clear();
                    foreach (TimeStamp TS in (IEnumerable<TimeStamp>)objs)
                        TasksTS.Add(TS.AsTimeStamp());
                    break;
                default:
                    objs = null;
                    break;
            }
            return objs;
        }

        /// <summary>
        /// Deletes Stale objects from cache. Requires new objects to br added explicitly.
        /// </summary>
        /// <typeparam name="T">Only Specify Person or Task</typeparam>
        /// <param name="latestTimestamps">List of Timestamps retrieved from server</param>
        /// <param name="CachedTimestampsList">List of timestamps cached. delete will be called on this also as well as local db</param>
        public static void DeleteOldObjects<T>(List<TimeStamp> latestTimestamps)
        {
            string typeName = typeof(T).Name;
            using (SQLiteTransaction mytransaction = grindDBConnection.BeginTransaction())
            {
                using (SQLiteCommand mycommand = new SQLiteCommand(grindDBConnection))
                {
                    mycommand.CommandText = @"DELETE FROM [" + typeName.Pluralize().ToLower() + "] WHERE [id] = @id";
                    mycommand.Parameters.Add("@id", DbType.Int32);
                    foreach (TimeStamp item in latestTimestamps)
                    {
                        List<TimeStamp> objectsById;
                        if (typeName == "Person")
                            objectsById = PeopleTS.FindAll(x => x.id == item.id);
                        else
                            objectsById = TasksTS.FindAll(x => x.id == item.id);

                        foreach (TimeStamp objectById in objectsById)
                            if (objectById.updated_at < item.updated_at)
                            {
                                mycommand.Parameters["@id"].Value = item.id;
                                mycommand.ExecuteNonQuery();
                                if (typeName == "Person")
                                    PeopleTS.Remove(objectById);
                                else
                                    TasksTS.Remove(objectById);
                            }
                    }
                }
                mytransaction.Commit();
            }
        }


        public static void DeleteObject<T>(int id)
        {
            string tablename = typeof(T).Name.Pluralize().ToLower();
            using (SQLiteTransaction mytransaction = grindDBConnection.BeginTransaction())
            {
                using (SQLiteCommand mycommand = new SQLiteCommand(grindDBConnection))
                {
                    mycommand.CommandText = @"DELETE FROM [" + tablename + "] WHERE [id] = @id";
                    mycommand.Parameters.Add("@id", DbType.Int32);
                    mycommand.Parameters["@id"].Value = id;
                    mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }
        }


    }
}
