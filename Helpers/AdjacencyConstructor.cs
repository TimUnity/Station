using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Helpers
{
    public class AdjacencyConstructor
    {
        public static Dictionary<int, List<int>> ConstructAdjacencyList(List<Path> paths) {
            var adjacencyList = new Dictionary<int, List<int>>();

            foreach (var path in paths) {
                foreach (var segment in path.Segments) {
                    var startPoint = segment.End;
                    var endPoint = segment.Start;

                    int startKey = PointToKeyConverter.PointToKey(startPoint);
                    int endKey = PointToKeyConverter.PointToKey(endPoint);

                    Console.WriteLine($"{startKey}:{endKey}");

                    // Добавление в список смежности
                    if (!adjacencyList.ContainsKey(startKey)) {
                        adjacencyList[startKey] = new List<int>();
                    }
                    adjacencyList[startKey].Add(endKey);

                    if (!adjacencyList.ContainsKey(endKey)) {
                        adjacencyList[endKey] = new List<int>();
                    }
                    adjacencyList[endKey].Add(startKey);
                }
            }
            return adjacencyList;
        }
    }
}
