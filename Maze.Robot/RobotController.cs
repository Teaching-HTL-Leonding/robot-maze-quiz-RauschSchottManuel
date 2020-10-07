using Maze.Library;
using System;

namespace Maze.Solver
{
    /// <summary>
    /// Moves a robot from its current position towards the exit of the maze
    /// </summary>
    public class RobotController
    {
        private readonly IRobot robot;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotController"/> class
        /// </summary>
        /// <param name="robot">Robot that is controlled</param>
        public RobotController(IRobot robot)
        {
            // Store robot for later use
            this.robot = robot;
        }

        /// <summary>
        /// Moves the robot to the exit
        /// </summary>
        /// <remarks>
        /// This function uses methods of the robot that was passed into this class'
        /// constructor. It has to move the robot until the robot's event
        /// <see cref="IRobot.ReachedExit"/> is fired. If the algorithm finds out that
        /// the exit is not reachable, it has to call <see cref="IRobot.HaltAndCatchFire"/>
        /// and exit.
        /// </remarks>
        public void MoveRobotToExit()
        {
            // Here you have to add your code

            // Trivial sample algorithm that can just move right


            /*while (!reachedEnd)
            {
                robot.Move(Direction.Right);
            }*/

            robot.ReachedExit += (_, __) => reachedEnd = true;

            //PerformMovement(null);

            CalculatePath();


        }

        public void CalculatePath()
        {
            Random rnd = new Random();
            int moves = 0;
            while (!reachedEnd)
            {
                robot.TryMove((Direction)rnd.Next(0, 4));

                moves++;
                if (moves == 10000000)
                {
                    robot.HaltAndCatchFire();
                    break;
                }
            }
        }

        bool reachedEnd = false;

        public void PerformMovement(Direction? directionWhereICameFrom)
        {
            if (reachedEnd) return;

            robot.TryMove(Direction.Right);
            PerformMovement(Direction.Right);


            /*if (robot.TryMove(Direction.Up) && directionWhereICameFrom != Direction.Down)
            {
                PerformMovement(Direction.Down);
            }
            else if (robot.TryMove(Direction.Right) && directionWhereICameFrom != Direction.Left)
            {
                PerformMovement(Direction.Left);
            }
            else if (robot.TryMove(Direction.Down) && directionWhereICameFrom != Direction.Up)
            {
                PerformMovement(Direction.Up);
            }
            else if (robot.TryMove(Direction.Left) && directionWhereICameFrom != Direction.Right)
            {
                PerformMovement(Direction.Right);
            }
            else
            {
                if (directionWhereICameFrom != null)
                {
                    return;
                    //robot.TryMove((Direction)directionWhereICameFrom!);
                }
                else
                {
                    robot.HaltAndCatchFire();
                    return;
                }
            }*/
        }
    }
}
