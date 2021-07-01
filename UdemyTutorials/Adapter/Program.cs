using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Adapter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cb = new ContainerBuilder();
            cb.Register(x => new Rectangle(1,2,10,10));
            cb.Register(x => new Rectangle(2, 4, 20, 50));
            cb.Register(x => new Circle(3, 6, 100));
            cb.RegisterAdapter<Circle, IUiWidget>(circle => new CircleToUiWidgetAdapter(circle));
            cb.RegisterAdapter<Rectangle, IUiWidget>(rectangle => new RectangleToUiWidgetAdapter(rectangle));
            cb.RegisterType<Instantiator>();

            using (var c = cb.Build())
            {
                var instantiator = c.Resolve<Instantiator>();
                instantiator.DrawAll();
            }

            Console.Read();
        }
    }
}
