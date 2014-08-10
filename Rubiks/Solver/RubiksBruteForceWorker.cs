using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeSimulator.Rubiks.Solver
{
    partial class RubiksBruteForcer
    {
        private class BruteForceWorker : BackgroundWorker
        {
            private RubiksCube _cube;

            protected override void OnDoWork(DoWorkEventArgs e)
            {
                base.OnDoWork(e);
                var p = (RubiksBruteForcerParams)e.Argument;
                _cube = p.Cube;
                BruteForce();
            }

            private static CubeMove GetMoveAtIndex(int move)
            {
                switch (move)
                {
                    case 0: return new CubeMove(CubeSide.Back, Rotation.Cw);
                    case 1: return new CubeMove(CubeSide.Back, Rotation.Ccw);
                    case 2: return new CubeMove(CubeSide.Down, Rotation.Cw);
                    case 3: return new CubeMove(CubeSide.Down, Rotation.Ccw);
                    case 4: return new CubeMove(CubeSide.Front, Rotation.Cw);
                    case 5: return new CubeMove(CubeSide.Front, Rotation.Ccw);
                    case 6: return new CubeMove(CubeSide.Left, Rotation.Cw);
                    case 7: return new CubeMove(CubeSide.Left, Rotation.Ccw);
                    case 8: return new CubeMove(CubeSide.Right, Rotation.Cw);
                    case 9: return new CubeMove(CubeSide.Right, Rotation.Ccw);
                    case 10: return new CubeMove(CubeSide.Up, Rotation.Cw);
                    case 11: return new CubeMove(CubeSide.Up, Rotation.Ccw);
                    default: return new CubeMove(CubeSide.Back, Rotation.Cw);
                }
            }

            private void BruteForce()
            { 
                
            }
        }
    }
}
