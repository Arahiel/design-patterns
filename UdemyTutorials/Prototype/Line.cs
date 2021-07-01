using System.IO;
using System.Xml.Serialization;

namespace Prototype
{
    public class Line
    {
        public Point Start, End;

        public Line()
        {
            
        }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Line DeepCopy()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(Line));
                s.Serialize(ms, this);
                ms.Position = 0;
                return (Line) s.Deserialize(ms);
            }
        }

        public override string ToString()
        {
            return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}";
        }
    }
}
