namespace RubiksCubeSimulator.Rubiks.Solver
{
    class RubiksBruteForcerParams
    {
        public int MaxMoves { get; private set; }

        public RubiksCube Cube { get; private set; }

        public RubiksBruteForcerParams(RubiksCube cube, int maxMoves)
        {
            Cube = cube;
            MaxMoves = maxMoves;
        }
    }
}
