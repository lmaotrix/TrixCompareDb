using TrixCompareDb.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using TrixCompareDb.Models;

namespace TrixCompareDb.Services
{
    public class CompareTables
    {
        public List<CompareRow> Compare(
            List<Dictionary<string, object>> source,
            List<Dictionary<string, object>> target)
        {
            var result = new List<CompareRow>();

            var key = "Id";

            var sourceDict = source
                .Where(d => d.ContainsKey(key) && d[key] != null)
                .ToDictionary(x => x[key].ToString());
            var targetDict = target
                .Where(d => d.ContainsKey(key) && d[key] != null)
                .ToDictionary(x => x[key].ToString());

            var allKeys = sourceDict.Keys.Union(targetDict.Keys);

            foreach (var k in allKeys)
            {
                sourceDict.TryGetValue(k, out var s);
                targetDict.TryGetValue(k, out var t);

                if (s == null)
                {
                    result.Add(new CompareRow { Source = null, Target = t, Status = "MissingSource" });
                }
                else if (t == null)
                {
                    result.Add(new CompareRow { Source = s, Target = null, Status = "MissingTarget" });
                }
                else
                {
                    bool equal = AreDictionariesEqual(s, t);

                    result.Add(new CompareRow
                    {
                        Source = s,
                        Target = t,
                        Status = equal ? "Equal" : "Different"
                    });
                }
            }

            return result;
        }

        private bool AreDictionariesEqual(Dictionary<string, object> a, Dictionary<string, object> b)
        {
            if (a == null || b == null) return a == b;
            if (a.Count != b.Count) return false;

            foreach (var kv in a)
            {
                if (!b.TryGetValue(kv.Key, out var bv)) return false;
                var av = kv.Value;
                if (av is DBNull) av = null;
                if (bv is DBNull) bv = null;
                if (av == null && bv == null) continue;
                if (av == null || bv == null) return false;
                if (!av.Equals(bv)) return false;
            }

            return true;
        }
    }
}
