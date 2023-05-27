using System.Data;
using System.Reflection;

namespace ListDataTableConverter.Extensions
{
    public static class DataTableExtensions
    {
        #region Datatable to List
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (dr[column.ColumnName] != DBNull.Value)
                        {
                            //Convert.ChangeType(dr[column.ColumnName], pro.PropertyType);
                            Type type = pro.PropertyType;

                            // Get the value from the datatable cell
                            object? value = GetValue(dr[column.ColumnName], type);


                            pro.SetValue(obj, value, null);
                        }
                        else
                            pro.SetValue(obj, null, null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
        static object? GetValue(object ob, Type targetType)
        {
            if (targetType == null)
            {
                return null;
            }
            else if (targetType == typeof(String))
            {
                return ob + "";
            }
            else if (targetType == typeof(int))
            {
                int.TryParse(ob + "", out int i);
                return i;
            }
            else if (targetType == typeof(short))
            {
                short.TryParse(ob + "", out short i);
                return i;
            }
            else if (targetType == typeof(long))
            {
                long.TryParse(ob + "", out long i);
                return i;
            }
            else if (targetType == typeof(ushort))
            {
                ushort.TryParse(ob + "", out ushort i);
                return i;
            }
            else if (targetType == typeof(uint))
            {
                uint.TryParse(ob + "", out uint i);
                return i;
            }
            else if (targetType == typeof(ulong))
            {
                ulong.TryParse(ob + "", out ulong i);
                return i;
            }
            else if (targetType == typeof(double?) || targetType == typeof(double))
            {
                double.TryParse(ob + "", out double i);
                return i;
            }
            else if (targetType == typeof(DateTime))
            {
                // do the parsing here...
            }
            else if (targetType == typeof(bool))
            {
                // do the parsing here...
            }
            else if (targetType == typeof(decimal))
            {
                // do the parsing here...
            }
            else if (targetType == typeof(float))
            {
                // do the parsing here...
            }
            else if (targetType == typeof(byte))
            {
                // do the parsing here...
            }
            else if (targetType == typeof(sbyte))
            {
                // do the parsing here...
            }
            else
            {
                return null;
            }

            return ob;
        }
        #endregion
    }
}
