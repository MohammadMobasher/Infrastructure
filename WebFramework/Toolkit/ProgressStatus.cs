using System.Collections.Generic;

namespace WebFramework.Toolkit
{
    public class ProgressStatus
    {
        public bool IsComplete { get; set; } = false;
        public int TotalSteps { get; set; }
        public int CompletedSteps { get; set; }
        public int ProgressPercentage { get; set; }
    }
}