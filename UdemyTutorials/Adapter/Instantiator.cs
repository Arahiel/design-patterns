using System.Collections.Generic;

namespace Adapter
{
    public class Instantiator
    {
        private readonly IEnumerable<IUiWidget> _uiWidgets;

        public Instantiator(IEnumerable<IUiWidget> uiWidgets)
        {
            _uiWidgets = uiWidgets;
        }

        public void DrawAll()
        {
            foreach (var uiWidget in _uiWidgets)
            {
                uiWidget.DrawWidget();
            }
        }
    }
}