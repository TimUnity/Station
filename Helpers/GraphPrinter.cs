using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Helpers
{
    public class GraphPrinter
    {
        public static void GraphPrintOut(Dictionary<int, List<int>> graph) 
        {
            Console.WriteLine();
            Console.WriteLine("Nodes:");
            int maxNeighbors = graph.Values.Max(list => list.Count);

            // заголовок
            Console.Write("Node\t");

            for (int i = 0; i < maxNeighbors; i++) 
            {
                Console.Write($"Neighbor {i + 1}\t");
            }

            Console.WriteLine();

            // узел и его соседи
            foreach (var node in graph.Keys.OrderBy(x => x)) 
            {
                Console.Write($"{node}\t");
                var neighbors = graph[node].OrderBy(x => x).ToList();

                for (int i = 0; i < maxNeighbors; i++) 
                {
                    if (i < neighbors.Count) 
                    {
                        Console.Write($"{neighbors[i]}\t");
                    }
                    else 
                    {
                        Console.Write("\t"); // Пустая ячейка для узлов с меньшим количеством соседей.
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
