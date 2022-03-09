using System;
using System.Collections.Generic;
using System.Text;

namespace CohortManagement.Core
{
    public class TraineeNotFoundException : Exception
    {
        public TraineeNotFoundException(long traineeID): base($"No trainee found for ID : "+traineeID)
        {

        }
    }
}
