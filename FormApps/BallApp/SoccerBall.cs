using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    internal class SoccerBall : Obj {

        public SoccerBall(double xp, double yp)
            : base(xp, yp,@"Picture\soccer_ball.png"){

            MoveX = 10; // Xの移動量
            MoveY = 10; // Yの移動量
        }

        public override bool Move() {
            if (PosX > 750 || PosX < 0) {
                MoveX = -MoveX;
            }

            if (PosY > 500 || PosY < 0) {
                MoveY = -MoveY;
            }
            PosX += MoveX;
            PosY += MoveY;

            return true;
        }
    }
}
