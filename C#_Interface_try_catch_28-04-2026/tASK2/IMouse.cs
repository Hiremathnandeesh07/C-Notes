using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tASK2
{

    // creating interfaces for Imouse and IKeyboard
    public interface IMouse
    {
          void MoveMouse();
    }

    public interface IKeyboard
    {
        void PressKeys();
    }
}
