using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos
{
    internal class EventHandlers
    {
        public static event EventHandler<FlowLayoutPanel> ReceivedFlowLayoutPanel;
        public static void UpdatedPanel(FlowLayoutPanel LayoutPanel)
        {
            ReceivedFlowLayoutPanel.Invoke(null, LayoutPanel);
        }


    }
}
