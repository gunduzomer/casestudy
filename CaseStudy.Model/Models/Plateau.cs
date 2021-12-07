using CaseStudy.Model.Abstracts;
using System;

namespace CaseStudy.Model.Models
{
    public class Plateau : IPlateau
    {
        public int xLength { get; set; }
        public int yLength { get; set; }
        public Plateau(int _xLength = 5, int _yLength = 5)
        {
            if (_xLength > 0)
                xLength = _xLength;
            else
                throw new Exception("X coordinate length must be greater than 0");
            
            if (_yLength > 0)
                yLength = _yLength;
            else
                throw new Exception("Y coordinate length must be greater than 0");
        }
    }
}
