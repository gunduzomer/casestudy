using CaseStudy.Model.Models;
using System;
using Xunit;

namespace CaseStudy.Test
{
    public class CaseStudyTest
    {
        [Fact]
        public void RotateNorthToWest()
        {
            Rover rover = new Rover("1 2 N");
            rover.RotateLeft();
            Assert.Equal('W', rover.direction);
        }

        [Fact]
        public void RotateWestToSouth()
        {
            Rover rover = new Rover("1 2 W");
            rover.RotateLeft();
            Assert.Equal('S', rover.direction);
        }

        [Fact]
        public void RotateSouthToEast()
        {
            Rover rover = new Rover("1 2 S");
            rover.RotateLeft();
            Assert.Equal('E', rover.direction);
        }

        [Fact]
        public void RotateEastToNorth()
        {
            Rover rover = new Rover("1 2 E");
            rover.RotateLeft();
            Assert.Equal('N', rover.direction);
        }

        [Fact]
        public void RotateNorthToEast()
        {
            Rover rover = new Rover("1 2 N");
            rover.RotateRight();
            Assert.Equal('E', rover.direction);
        }

        [Fact]
        public void RotateEastToSouth()
        {
            Rover rover = new Rover("1 2 E");
            rover.RotateRight();
            Assert.Equal('S', rover.direction);
        }

        [Fact]
        public void RotateSouthToWest()
        {
            Rover rover = new Rover("1 2 S");
            rover.RotateRight();
            Assert.Equal('W', rover.direction);
        }

        [Fact]
        public void RotateWestToNorth()
        {
            Rover rover = new Rover("1 2 W");
            rover.RotateRight();
            Assert.Equal('N', rover.direction);
        }

        [Fact]
        public void MoveYAxis()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("1 2 N");
            rover.MoveForward(plateau);
            Assert.Equal(3, rover.y);
            Assert.Equal(1, rover.x);
            Assert.Equal('N', rover.direction);
        }

        [Fact]
        public void MoveXAxis()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("1 2 E");
            rover.MoveForward(plateau);
            Assert.Equal(2, rover.y);
            Assert.Equal(2, rover.x);
            Assert.Equal('E', rover.direction);
        }

        [Fact]
        public void OperateRotation()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("1 2 N");
            rover.Operate('L', plateau);
            Assert.Equal('W', rover.direction);
            Assert.Equal(1, rover.x);
            Assert.Equal(2, rover.y);
        }

        [Fact]
        public void OperateMove()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("1 2 N");
            rover.Operate('M', plateau);
            Assert.Equal('N', rover.direction);
            Assert.Equal(1, rover.x);
            Assert.Equal(3, rover.y);
        }

        [Fact]
        public void ExploreCase1()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("1 2 N");
            string result1 = rover.Explore("LMLMLMLMM", plateau);
            Assert.Equal("1 3 N", result1);
        }

        [Fact]
        public void ExploreCase2()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("3 3 E");
            string result1 = rover.Explore("MMRMMRMRRM", plateau);
            Assert.Equal("5 1 E", result1);
        }

        [Fact]
        public void RoverNotInPlateauXAxis()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("6 3 E");
            string result1 = rover.Explore("MMRMMRMRRM", plateau);
            Assert.Equal("Rovers initial x position is not in the boundaries", result1);
        }

        [Fact]
        public void RoverNotInPlateauYAxis()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("3 6 E");
            string result1 = rover.Explore("MMRMMRMRRM", plateau);
            Assert.Equal("Rovers initial y position is not in the boundaries", result1);
        }

        [Fact]
        public void InvalidOperateCommand()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("3 1 E");
            Assert.Throws<Exception>(() => rover.Operate('A', plateau));
        }

        [Fact]
        public void InvalidExploreCommand()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("3 1 E");
            Assert.Throws<Exception>(() => rover.Explore("QMMRMMRMRRM", plateau));
        }

        [Fact]
        public void XAxisOutOfBoundariesMin()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("0 1 W");
            Assert.Throws<IndexOutOfRangeException>(() => rover.Explore("MM", plateau));
        }

        [Fact]
        public void XAxisOutOfBoundariesMax()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("5 1 E");
            Assert.Throws<IndexOutOfRangeException>(() => rover.Explore("MM", plateau));
        }

        [Fact]
        public void YAxisOutOfBoundariesMin()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("1 0 S");
            Assert.Throws<IndexOutOfRangeException>(() => rover.Explore("MM", plateau));
        }

        [Fact]
        public void YAxisOutOfBoundariesMax()
        {
            Plateau plateau = new Plateau();
            Rover rover = new Rover("1 5 N");
            Assert.Throws<IndexOutOfRangeException>(() => rover.Explore("MM", plateau));
        }

        [Fact]
        public void InvalidInitialRoverXCoordinateFormat()
        {
            Assert.Throws<Exception>(() => new Rover("11 5 1"));
        }

        [Fact]
        public void InvalidInitialRoverYCoordinateFormat()
        {
            Assert.Throws<Exception>(() => new Rover("1 51 1"));
        }

        [Fact]
        public void InvalidInitialRoverDirectionFormat()
        {
            Assert.Throws<Exception>(() => new Rover("1 1 WW"));
        }

        [Fact]
        public void InvalidInitialRoverDirectionFormatChar()
        {
            Assert.Throws<Exception>(() => new Rover("1 1 1"));
        }

        [Fact]
        public void InvalidInitialRoverCoordinateDirectionFormat()
        {
            Assert.Throws<Exception>(() => new Rover("1 5W"));
        }

        [Fact]
        public void PlateauXLengthLessOrEqualsZero()
        {
            Assert.Throws<Exception>(() => new Plateau(0, 5));
        }

        [Fact]
        public void PlateauYLengthLessOrEqualsZero()
        {
            Assert.Throws<Exception>(() => new Plateau(5, 0));
        }

        [Fact]
        public void RoverInvalidXAxis()
        {
            Assert.Throws<FormatException>(() => new Rover("W 1 W"));
        }

        [Fact]
        public void RoverInvalidYAxis()
        {
            Assert.Throws<FormatException>(() => new Rover("1 W W"));
        }
    }
}
