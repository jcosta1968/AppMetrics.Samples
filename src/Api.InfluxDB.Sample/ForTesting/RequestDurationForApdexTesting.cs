using System;
using System.Collections.Generic;

namespace Api.InfluxDB.Sample.ForTesting
{
    public class RequestErrorForErrorTesting
    {
        private static readonly Random Rnd = new Random();
        private static readonly List<int> StatusCode = new List<int> {401, 404, 403, 500};

        public int NextStatusCode => StatusCode[Rnd.Next(0, 3)];
    }

    public class RequestDurationForApdexTesting
    {
        private const int MaxRequestDurationFactor = 1000;
        private const int MinRequestDuration = 25;
        private static readonly Random Rnd = new Random();

        public RequestDurationForApdexTesting(double apdexTSeconds)
        {
            SatisfiedMinMilliseconds = MinRequestDuration;
            SatisfiedMaxMilliseconds = (int)(apdexTSeconds * 1000);

            ToleratingMinMilliseconds = SatisfiedMaxMilliseconds + 1;
            ToleratingMaxMilliseconds = 4 * SatisfiedMaxMilliseconds;

            FrustratingMinMilliseconds = ToleratingMaxMilliseconds + 1;
            FrustratingMaxMilliseconds = ToleratingMaxMilliseconds + MaxRequestDurationFactor;
        }

        public int FrustratingMaxMilliseconds { get; }

        public int FrustratingMinMilliseconds { get; }

        public int NextFrustratingDuration => Rnd.Next(FrustratingMinMilliseconds, FrustratingMaxMilliseconds);

        public int NextSatisfiedDuration => Rnd.Next(SatisfiedMinMilliseconds, SatisfiedMaxMilliseconds);

        public int NextToleratingDuration => Rnd.Next(ToleratingMinMilliseconds, ToleratingMaxMilliseconds);

        public int SatisfiedMaxMilliseconds { get; }

        public int SatisfiedMinMilliseconds { get; }

        public int ToleratingMaxMilliseconds { get; }

        public int ToleratingMinMilliseconds { get; }
    }
}