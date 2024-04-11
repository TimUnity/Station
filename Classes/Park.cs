using System.Collections.Generic;

namespace Consola
{
    public class Park
    {
        public List<Path> Paths { get; set; }
        public string Name { get; set; }

        public Park(string name)
        {
            Name = name;
            Paths = new List<Path>();
        }

        public void AddPath(Path path)
        {
            Paths.Add(path);
        }
    }     
}
