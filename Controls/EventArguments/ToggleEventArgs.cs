using System;
using System.Collections.Generic;
using System.Text;

namespace Skor.Controls.EventArguments
{
    public class ToggleEventArgs:System.EventArgs
    {
        public bool NewValue { get; private set; }
        public bool OldValue { get; private set; }
        public ToggleEventArgs(bool newValue, bool oldValue)
        {
            this.NewValue = newValue;
            this.OldValue = oldValue;
        }
    }
}
