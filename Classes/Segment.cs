namespace Consola
{
    public class Segment
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Segment(Point start, Point end)
        {
            Start = start;
            End = end;
        }
    }
}
