using CaseStudy.Model.Models;

namespace CaseStudy.Model.Interface
{
    public interface IRover
    {
        int x { get; set; }
        int y { get; set; }
        char direction { get; set; }
        void RotateLeft();
        void RotateRight();
        void MoveForward(Plateau plateau);
        void Operate(char command, Plateau plateau);
        string Explore(string commands, Plateau plateau);
    }
}