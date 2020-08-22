using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace testNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Md5VsSha512>();
        }
        
        public class Md5VsSha512
        {
            private const int N = 10000;
            private readonly byte[] data;

            private readonly SHA512 sha512 = SHA512.Create();
            private readonly MD5 md5 = MD5.Create();

            public Md5VsSha512()
            {
                data = new byte[N];
                new Random(42).NextBytes(data);
            }

            [Benchmark]
            public byte[] Sha512() => sha512.ComputeHash(data);

            [Benchmark]
            public byte[] Md5() => md5.ComputeHash(data);
        }
    }
}