using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UnknownNamedSkillException : Exception
{
    public UnknownNamedSkillException(string message) : base(message) { }
}