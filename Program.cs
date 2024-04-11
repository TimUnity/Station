using Consola.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Consola
{

    internal class Program
    {
        private static void Main()
        {
            #region Hardcoded data   

            var paths = new List<Path>
            {
                new Path("Path A")
                {
                    Segments = new List<Segment>
                    {
                        new Segment(new Point(0, 0), new Point(1, 1))
                    }
                },
                new Path("Path B")
                {
                    Segments = new List<Segment>
                    {
                        new Segment(new Point(1, 1), new Point(2, 3))
                    }
                },
                new Path("Path C")
                {
                    Segments = new List<Segment>
                    {
                        new Segment(new Point(2, 3), new Point(3, 2))
                    }
                },
                new Path("Path D")
                {
                    Segments = new List<Segment>
                    {
                        new Segment(new Point(3, 2), new Point(5, 6))
                    }
                },
                new Path("Path E")
                {
                    Segments = new List<Segment>
                    {
                        new Segment(new Point(5, 6), new Point(6, 7))
                    }
                }
            };

            // Парк
            var parkOne = new Park("Central Park");
            parkOne.SetPathList(paths);

            #endregion     
            
            var adjacencyList = AdjacencyConstructor.ConstructAdjacencyList(parkOne.Paths);
            GraphPrinter.GraphPrintOut(adjacencyList);

            // Узлы, для поиска кратчайшего пути
            int startNode = PointToKeyConverter.PointToKey(new Point(0, 0));
            int endNode = PointToKeyConverter.PointToKey(new Point(6, 7));

            // Вывод найденного кратчайшего пути
            PathFinder.FindShortestPath(adjacencyList, startNode, endNode);  

            // Заливка парка
            FillPatk(adjacencyList, startNode, endNode);

            Console.ReadLine();
        }

        private static void FillPatk(Dictionary<int, List<int>> graph, int startNode, int endNode)
        {
            var visitedNodes = new HashSet<int>();
            var path = new Stack<int>();

            PathFinder.DepthSearch(graph, startNode, endNode, visitedNodes, path);

            Console.WriteLine("Fill Park:");

            foreach (var node in path.ToList()) {
                Console.WriteLine(
                    $"{PointToKeyConverter.KeyToPoint(node).X}." +
                    $"{PointToKeyConverter.KeyToPoint(node).Y}");
            }
        }
    }
}
