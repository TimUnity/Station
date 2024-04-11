using System.Collections.Generic;

namespace Consola
{
    public class Path
    {
        public List<Segment> Segments { get; set; }
        public string Name { get; set; }

        public Path(string name)
        {
            Name = name;
            Segments = new List<Segment>();
        }

        public void AddSegment(Segment segment)
        {
            Segments.Add(segment);
        }
    }
}
