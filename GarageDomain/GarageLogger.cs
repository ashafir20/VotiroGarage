using System;
using VotiroGarage;

namespace GarageDomain
{
    public class GarageLogger : IGarageLog
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
