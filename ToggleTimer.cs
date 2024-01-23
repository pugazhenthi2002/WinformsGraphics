using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDraft
{
    class ToggleTimer : Timer
    {
        public delegate void ToggleButtonMovementHandler(object sender, int movement);
        public event ToggleButtonMovementHandler ToggleButtonMoved;
        private int stepMovement;

        public void Start(int X)
        {
            stepMovement = X;
            base.Start();
        }

        protected override void OnTick(EventArgs e)
        {
            ToggleButtonMoved?.Invoke(this, stepMovement);
        }
    }
}
