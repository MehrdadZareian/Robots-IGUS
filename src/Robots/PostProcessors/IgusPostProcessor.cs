using System.Xml.Linq;
using Rhino.Geometry;
using static System.Math;
using static Rhino.RhinoMath;
using static Robots.Util;

namespace Robots;

class IgusPostProcessor : IPostProcessor
{
    public List<List<List<string>>> GetCode(RobotSystem system, Program program)
    {
        PostInstance instance = new((SystemIgus)system, program);
        return instance.Code;
    }

    class PostInstance
    {
        readonly SystemIgus _system;
        readonly Program _program;

        public List<List<List<string>>> Code { get; }

        public PostInstance(SystemIgus system, Program program)
        {

            _system = system;
            _program = program;
            var groupCode = new List<List<string>>
            {
                        Start(),
                        Body(),
                        end(),
                    };

            Code = [groupCode];

            // MultiFile warning
            if (program.MultiFileIndices.Count > 1)
                program.Warnings.Add("Multi-file input not supported on UR robots");


        }
     

        List<string> Start()
        {
            var codes = new List<string>();
            codes.Add("A");
            return codes;
        }

        List<string> Body()
        {
            var codes = new List<string>();
            codes.Add("B");
            return codes;
        }

        List<string> end()
        {
            var codes = new List<string>();
            codes.Add("C");
            return codes;
        }






    }
}
