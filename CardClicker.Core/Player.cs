using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    public class Player
    {
        public int Pin { get; private set; }

        public void SetPin(int pin)
        {
            Pin = pin;
        }
    }
}
