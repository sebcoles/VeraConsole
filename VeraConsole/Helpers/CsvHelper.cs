using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VeraConsole.Helpers
{
    public class CsvHelper
    {
        public string ToCsv<T>(IEnumerable<T> objectlist)
        {
            Type t = typeof(T);
            PropertyInfo[] fields = t.GetProperties();
            string header = string.Join(",", fields.Select(f => $"\"{f.Name}\"").ToArray());
            var csvdata = new StringBuilder();
            csvdata.AppendLine(header);

            foreach (var o in objectlist)
                csvdata.AppendLine(ToCsvFields(fields, o));

            return csvdata.ToString();
        }

        public string ToCsvFields(PropertyInfo[] fields, object o) => 
            string.Join(",", fields.Select(x => $"\"{x.GetValue(o)}\"").ToArray());
    }
}
