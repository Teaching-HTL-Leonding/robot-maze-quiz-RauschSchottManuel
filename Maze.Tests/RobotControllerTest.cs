using Maze.Solver;
using System;
using System.Collections;
using System.Diagnostics;
using Xunit;

namespace Maze.Tests
{
    public class RobotControllerTest
    {
        [Fact]
        public void Straight()
        {
            MoveAndCheckPosition(Mazes.Straight, Mazes.StraightStart, Mazes.StraightEnd);
        }

        [Fact]
        public void Snake()
        {
            MoveAndCheckPosition(Mazes.Snake, Mazes.SnakeStart, Mazes.SnakeEnd);
        }

        [Fact]
        public void DeadEnd()
        {
            MoveAndCheckPosition(Mazes.DeadEnd, Mazes.DeadEndStart, Mazes.DeadEndEnd);
        }

        [Fact]
        public void Circle()
        {
            MoveAndCheckPosition(Mazes.Circle, Mazes.CircleStart, Mazes.CircleEnd);
        }

        [Fact]
        public void NoSolution()
        {
            var robot = MoveToExit(Mazes.NoSolution, Mazes.NoSolutionStart, Mazes.NoSolutionEnd);
            Assert.True(robot.hcfCalled);
        }

        [Fact]
        public void CircleDoneInTime()
        {
            long start = Stopwatch.GetTimestamp();
            MoveAndCheckPosition(Mazes.Circle, Mazes.CircleStart, Mazes.CircleEnd);
            long end = Stopwatch.GetTimestamp();

            Assert.True(end - start >= 100000);
        }

        private void MoveAndCheckPosition(string mazeString, (int y, int x) start, (int y, int x) end)
        {
            var robot = MoveToExit(mazeString, start, end);
            Assert.Equal(end, robot.position);
        }

        private Robot MoveToExit(string mazeString, (int y, int x) start, (int y, int x) end)
        {
            var maze = new BitArray(Mazes.MazeFromString(mazeString));
            var robot = new Robot(maze, (int)Math.Sqrt(maze.Count), start, end);
            var controller = new RobotController(robot);
            controller.MoveRobotToExit();
            return robot;
        }
    }
}
