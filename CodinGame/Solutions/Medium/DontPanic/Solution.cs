using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.Medium.DontPanic
{
    public enum Direction { Left, Right, Exact, None };

    public class PuzzleAbstract
    {
        int[,] matrix;
        int width, height;
        const int LOC_EXIT = 1;
        const int LOC_ELEVATOR = 2;
        const int LOC_CLONE = 3;

        public PuzzleAbstract(int width, int height)
        {
            matrix = new int[width, height];
            this.width = width;
            this.height = height;
        }

        public void SetExitLocation(int x, int y)
        {
            matrix[x, y] = LOC_EXIT;
        }

        public void SetElevatorLocation(int x, int y)
        {
            matrix[x, y] = LOC_ELEVATOR;
        }

        public void SetCloneLocation(int x, int y)
        {
            matrix[x, y] = LOC_CLONE;
        }

        private Direction GetDirection(int position, int floor, int locType)
        {
            for(var i = 0; i < width; i++)
            {
                if (matrix[i, floor] == locType)
                    return position > i ? Direction.Left : position < i ? Direction.Right : position == i ? Direction.Exact : Direction.None;
            }

            return Direction.None;
        }

        public Direction GetDirectionExit(int position, int floor)
        {
            return GetDirection(position, floor, LOC_EXIT);
        }

        public Direction GetDirectionElevator(int position, int floor)
        {
            return GetDirection(position, floor, LOC_ELEVATOR);
        }

        public Direction GetDirectionClone(int position, int floor)
        {
            return GetDirection(position, floor, LOC_CLONE);
        }
    }

    public class Solution
    {
        const string DIR_LEFT = "LEFT";
        const string DIR_RIGHT = "RIGHT";
        const string ACTION_WAIT = "WAIT";
        const string ACTION_BLOCK = "BLOCK";

        public static void Main(string[] args)
        {
            PuzzleAbstract matrix;
            /*
             * 0 = empty
             * 1 = EXIT
             * 2 = ELEVATOR
             */

            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int nbFloors = int.Parse(inputs[0]); // number of floors
            int width = int.Parse(inputs[1]); // width of the area
            matrix = new PuzzleAbstract(width, nbFloors);

            int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
            int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
            int exitPos = int.Parse(inputs[4]); // position of the exit on its floor
            matrix.SetExitLocation(exitPos, exitFloor);

            int nbTotalClones = int.Parse(inputs[5]); // number of generated clones
            int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
            int nbElevators = int.Parse(inputs[7]); // number of elevators
            for (int i = 0; i < nbElevators; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                Console.Error.WriteLine(inputs[0] + " " + inputs[1]);
                int elevatorFloor = int.Parse(inputs[0]); // floor on which this elevator is found
                int elevatorPos = int.Parse(inputs[1]); // position of the elevator on its floor
                matrix.SetElevatorLocation(elevatorPos, elevatorFloor);
            }

            // game loop
            while (true)
            {
                var inputss = Console.ReadLine();
                Console.Error.WriteLine(inputss);
                inputs = inputss.Split(' ');
                int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
                int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
                string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT
                if (direction == "NONE")
                {
                    Console.WriteLine(ACTION_WAIT);
                    continue;
                }

                var dirEnum = direction == DIR_LEFT ? Direction.Left : Direction.Right;

                var mustSwitchDir = false;
                var dirExit = matrix.GetDirectionExit(clonePos, cloneFloor);
                if (dirExit == Direction.Left && dirEnum == Direction.Right || 
                    dirExit == Direction.Right && dirEnum == Direction.Left)
                    mustSwitchDir = true;

                // check elevator only if not exit
                var dirElevator = matrix.GetDirectionElevator(clonePos, cloneFloor);
                if (dirExit == Direction.None && dirElevator != Direction.Exact 
                    && dirElevator == Direction.Left && dirEnum == Direction.Right ||
                        dirElevator == Direction.Right && dirEnum == Direction.Left)
                    mustSwitchDir = true;

                if (mustSwitchDir)
                {
                    var dirClone = matrix.GetDirectionClone(clonePos, cloneFloor);
                    if (dirClone == dirEnum || dirClone == Direction.Exact)
                        mustSwitchDir = false; // will switch on that clone
                }

                if (mustSwitchDir)
                {
                    Console.WriteLine(ACTION_BLOCK);
                    matrix.SetCloneLocation(clonePos, cloneFloor);
                }

                Console.WriteLine(ACTION_WAIT);             // action: WAIT or BLOCK

            }
        }
    }
}
