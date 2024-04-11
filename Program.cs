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

            // Секции
            var sectionA = new Point(0, 0);
            var sectionB = new Point(1, 1);
            var sectionC = new Point(2, 3);
            var sectionD = new Point(3, 2);
            var sectionE = new Point(4, 3);
            var sectionF = new Point(5, 6);
            var sectionG = new Point(6, 7);

            // Пути
            var pathAB = new Path("Path A");
            pathAB.AddSegment(new Segment(sectionA, sectionB));

            var pathBC = new Path("Path B");
            pathBC.AddSegment(new Segment(sectionB, sectionC));

            var pathCD = new Path("Path C");
            pathCD.AddSegment(new Segment(sectionC, sectionD));

            var pathEF = new Path("Path E");
            pathEF.AddSegment(new Segment(sectionD, sectionF));

            var pathFG = new Path("Path F");
            pathFG.AddSegment(new Segment(sectionF, sectionG));

            // Парк
            var parkOne = new Park("Central Park");
            parkOne.AddPath(pathAB);
            parkOne.AddPath(pathBC);
            parkOne.AddPath(pathCD);
            parkOne.AddPath(pathEF);
            parkOne.AddPath(pathFG);

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
