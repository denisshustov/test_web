using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.service
{
    public class PathResolver : IPathResolver
    {
        public List<Data> GetHangUpData(List<Data> data)
        {
            Dictionary<string, Data> result = new Dictionary<string, Data>();
            var sortedData = data.OrderBy(d => d.Index).ToList();
            var sortedDataHash = new Dictionary<string, Data>(data.ToDictionary(k =>  k.Index));
          
            foreach (var item in sortedData)
            {
                if (item.Index.Length > 1)
                {
                    var spl = item.Index.Split(".").ToList();
                    spl.RemoveAt(spl.Count() - 1);
                    var currentParent = string.Join(".", spl);
                    var isFndItem = sortedDataHash.ContainsKey(currentParent);
                    if (!isFndItem)
                    {
                        result.Add(item.Index, item);
                    }
                    else
                    {
                        if (result.ContainsKey(currentParent))
                        {
                            result.Add(item.Index, item);
                        }
                    }
                }

            }
            return result.Values.ToList();
        }


    }
}
