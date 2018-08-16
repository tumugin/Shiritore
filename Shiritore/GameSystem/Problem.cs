using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritore.GameSystem
{
    public class Problem
    {
        public string ProblemText { get; set; }
        public bool IsCorrect { get; set; } = false;
        public bool IsBonus { get; set; } = false;
    }
}
