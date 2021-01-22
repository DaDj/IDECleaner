using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDECleaner
{
    public class MapperIDE
    {
        public int ModelId { get; }
        public string ModelName { get; set; }
        public string Texture { get; }

        public MapperIDE(string modelName)
        {
            ModelName = modelName;
        }

        public MapperIDE(string[] data)
        {
            ModelId = Int32.Parse(data[0]);
            ModelName = data[1].Trim();
            Texture = data[2].Trim();
        }

        public static List<MapperIDE> ParseMultipleIdes(List<string> data)
        {
            return data
                .Select(line => line.TrimStart().Split(','))
                .Where(ide => ide.Length > 2 && !ide.First().StartsWith("#"))
                .Select(ide => new MapperIDE(ide))
                .ToList();
        }
    }
}
