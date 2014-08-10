using System;

namespace RubiksCubeSimulator.Rubiks
{
    /// <summary>
    /// Specifies the rotation direction
    /// </summary>
    public enum Rotation
    {
        /// <summary>
        /// Clockwise
        /// </summary>
        Cw,
        /// <summary>
        /// Counter-clockwise
        /// </summary>
        Ccw
    }

    /// <summary>
    /// Specifies the sides of a cube
    /// </summary>
    public enum CubeSide
    {
        None,
        /// <summary>
        /// The front of the cube
        /// </summary>
        Front,
        /// <summary>
        /// The back of the cube
        /// </summary>
        Back,
        /// <summary>
        /// The right of the cube
        /// </summary>
        Right,
        /// <summary>
        /// The left of the cube
        /// </summary>
        Left,
        /// <summary>
        /// The top of the cube
        /// </summary>
        Up,
        /// <summary>
        /// The bottom of the cube
        /// </summary>
        Down
    }

    /// <summary>
    /// Specifies a defect with a cube color configuration
    /// </summary>
    [Flags]
    public enum ColorDefectType
    {
        None = 0,
        /// <summary>
        /// There are too many instances of one color
        /// </summary>
        TooMany = 1,
        /// <summary>
        /// There are too many distinct colors (7+)
        /// </summary>
        TooManyDistinct = 2
    }

    /// <summary>
    /// Specifies a simple move algorithm
    /// </summary>
    public enum Algorithm
    {
        /// <summary>
        /// Left CW
        /// </summary>
        L,
        /// <summary>
        /// Left CCW
        /// </summary>
        Li,
        /// <summary>
        /// Right CW
        /// </summary>
        R,
        /// <summary>
        /// Right CCW
        /// </summary>
        Ri,
        /// <summary>
        /// Down CW
        /// </summary>
        D,
        /// <summary>
        /// Down CCw
        /// </summary>
        Di,
        /// <summary>
        /// Up CW
        /// </summary>
        U,
        /// <summary>
        /// Up CCW
        /// </summary>
        Ui,
        /// <summary>
        /// Front CW
        /// </summary>
        F,
        /// <summary>
        /// Front CCW
        /// </summary>
        Fi, 
        /// <summary>
        /// Back CW
        /// </summary>
        B,
        /// <summary>
        /// Back CCW
        /// </summary>
        Bi
    }
}
