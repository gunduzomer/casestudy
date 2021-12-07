using CaseStudy.Model.Interface;
using System;
using System.Linq;

namespace CaseStudy.Model.Models
{
    public class Rover : IRover
    {
        public int x { get; set; }
        public int y { get; set; }
        public char direction { get; set; }

        public Rover(string coordinates = "0 0 N")
        {
            if (coordinates.Split(" ").Count() == 3)
            {
                if (coordinates.Split(" ")[0].Length == 1)
                    x = int.Parse(coordinates.Split(" ")[0]);
                else
                    throw new Exception("X Coordinate input is not in the correct format.");

                if (coordinates.Split(" ")[1].Length == 1)
                    y = int.Parse(coordinates.Split(" ")[1]);
                else
                    throw new Exception("Y Coordinate input is not in the correct format.");

                if (coordinates.Split(" ")[2].Length == 1)
                {
                    direction = coordinates.Split(" ")[2].FirstOrDefault();
                    if (direction != 'W' && direction != 'N' && direction != 'S' && direction != 'E')
                        throw new Exception("Direction input is not in the correct format.");
                }
                else
                    throw new Exception("Direction input is not in the correct format.");
            }
            else
                throw new Exception("Coordinate and direction input is not in the correct format.");
        }

        public void RotateLeft()
        {
            switch (direction)
            {
                case 'W':
                    direction = 'S';
                    break;
                case 'S':
                    direction = 'E';
                    break;
                case 'E':
                    direction = 'N';
                    break;
                case 'N':
                    direction = 'W';
                    break;
                default:
                    throw new Exception("Invalid direction");
            }
        }

        public void RotateRight()
        {
            switch (direction)
            {
                case 'W':
                    direction = 'N';
                    break;
                case 'N':
                    direction = 'E';
                    break;
                case 'E':
                    direction = 'S';
                    break;
                case 'S':
                    direction = 'W';
                    break;
                default:
                    throw new Exception("Invalid direction");
            }
        }

        public void MoveForward(Plateau plateau)
        {
            switch (direction)
            {
                case 'W':
                    x -= 1;
                    if (x < 0)
                        throw new IndexOutOfRangeException("Rover is out of bounds");
                    break;
                case 'N':
                    y += 1;
                    if (y > plateau.yLength)
                        throw new IndexOutOfRangeException("Rover is out of bounds");
                    break;
                case 'E':
                    x += 1;
                    if (x > plateau.xLength)
                        throw new IndexOutOfRangeException("Rover is out of bounds");
                    break;
                case 'S':
                    y -= 1;
                    if (y < 0)
                        throw new IndexOutOfRangeException("Rover is out of bounds");
                    break;
                default:
                    throw new Exception("Invalid direction");
            }
        }

        public void Operate(char command, Plateau plateau)
        {
            switch (command)
            {
                case 'L':
                    RotateLeft();
                    break;
                case 'R':
                    RotateRight();
                    break;
                case 'M':
                    MoveForward(plateau);
                    break;
                default:
                    throw new Exception("Invalid Operation.");
            }
        }

        public string Explore(string commands, Plateau plateau)
        {
            if (x > plateau.xLength || x < 0)
                return "Rovers initial x position is not in the boundaries";

            if (y > plateau.yLength || y < 0)
                return "Rovers initial y position is not in the boundaries";

            foreach (char command in commands)
                Operate(command, plateau);

            string finalPosition = String.Concat(x.ToString(), " ", y.ToString(), " ", direction);
            return finalPosition;
        }
    }
}
