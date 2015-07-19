using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui
{
    public class NumericUpDownFix : System.Windows.Forms.NumericUpDown
    {
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            HandledMouseEventArgs hme = e as HandledMouseEventArgs;
            if (hme != null)
                hme.Handled = true;

            if (e.Delta > 0)
            {
                var newValue = this.Value + this.Increment;
                this.Value = Math.Min(newValue, this.Maximum);
            }
            else if (e.Delta < 0)
            {
                var newValue = this.Value - this.Increment;
                this.Value = Math.Max(newValue, this.Minimum);
            }
        }
    }
}
