using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Skor.Controls.Abstractions
{
    public interface IGradientButtonController: IButtonController
    {
        void SendLongClick();
    }
}
