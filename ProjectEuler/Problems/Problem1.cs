using ProofOfConcept.Math;

namespace ProjectEuler.Problems
{
    public static class Problem1
    {
        /// <summary>
        /// Returns sum of all multiples of a and b to n (exclusive).
        /// a,b > 0 & a >= b
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="n">Max value limit.</param>
        /// <returns>Sum of all multiples of a and b to max value limit n.</returns>
        public static long GetSum(long a, long b, long n)
        {
            var sum = 0L;
            if (b % a == 0) for (var i = a; i < n; i += a) sum += i;
            else
            {
                var lcm = GetLCM(a, b);
                var max = ((n / a) / b) + 1;
                var step = lcm / b;
                var end = 0L;
                var start = 0L;
                for (var i = a; i < n; i += a) sum += i;
                for (var i = 1; i < max; i++)
                {
                    start = end + b;
                    end = b * i * step;
                    for (var j = start; j < end; j += b) sum += j;
                }
                for (var i = end + 5; i < n; i += b) sum += i;
            }
            return sum;
        }

        public static long SimpleTest(long a, long b, long max)
        {
            var sum = 0L;
            for (var i = a; i < max; i += a) sum += i;
            for (var j = b; j < max; j += b) if (j % a != 0) sum += j;
            return sum;
        }

        public static long GetSumSn(long a, long b, long n)
        {
            n--;
            var c = GetLCM(a, b);
            var eleA = n / a;
            var eleB = n / b;
            var eleC = n / c;
            var sumA = GetSn(a, eleA);
            var sumB = GetSn(b, eleB);
            var sumC = GetSn(c, eleC);
            return sumA + sumB - sumC;
        }

        private static long GetGCD(long a, long b)
        {
            while (b != 0)
            {
                var tmp = b;
                b = a % b;
                a = tmp;
            }
            return a;
        }

        private static long GetLCM(long a, long b)
        {
            return (a / GetGCD(a, b)) * b;
        }

        private static long GetSn(long firstElement, long amountOfElements)
        {
            return ((firstElement + (amountOfElements * firstElement)) * amountOfElements) / 2;
        }
    }
}