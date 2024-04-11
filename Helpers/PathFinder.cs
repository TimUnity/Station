using System;
using System.Collections.Generic;

namespace Consola.Helpers
{
    public class PathFinder
    {
        public static void FindShortestPath(Dictionary<int, List<int>> graph, int startNode, int endNode) {
            var shortestPaths = new Dictionary<int, (int, int)>();
            var unvisitedNodes = new SortedSet<(int, int)> { (0, startNode) };

            while (unvisitedNodes.Count > 0) {
                var currentNode = unvisitedNodes.Min.Item2;
                unvisitedNodes.Remove(unvisitedNodes.Min);

                foreach (var neighbor in graph[currentNode]) {
                    var weight = 1;
                    var newWeight =
                        shortestPaths.ContainsKey(currentNode) ?
                        shortestPaths[currentNode].Item2 + weight :
                        weight;

                    if (
                        !shortestPaths.ContainsKey(neighbor) || newWeight < shortestPaths[neighbor].Item2) {
                        shortestPaths[neighbor] = (currentNode, newWeight);
                        unvisitedNodes.Add((newWeight, neighbor));
                    }
                }
            }

            var path = new List<int>();
            var current = endNode;

            while (current != startNode) {
                path.Add(current);
                current = shortestPaths[current].Item1;
            }

            path.Add(startNode);
            path.Reverse();

            Console.WriteLine("Shortest path:");

            foreach (var node in path) {
                Console.WriteLine(
                    $"{PointToKeyConverter.KeyToPoint(node).X}." +
                    $"{PointToKeyConverter.KeyToPoint(node).Y}");
            }

            Console.WriteLine();
        }

        public static void DepthSearch(
            Dictionary<int, List<int>> graph, int currentNode, int endNode,
            HashSet<int> visitedNodes, Stack<int> path) {
            visitedNodes.Add(currentNode);
            path.Push(currentNode);

            if (currentNode == endNode) {
                return; // Конечный узел
            }

            foreach (var neighbor in graph[currentNode]) {
                if (!visitedNodes.Contains(neighbor)) {
                    DepthSearch(graph, neighbor, endNode, visitedNodes, path);
                }
            }

            if (path.Peek() == currentNode) {
                path.Pop(); // Возврат, если путь к конечному узлу не найден
            }
        }
    }
}
