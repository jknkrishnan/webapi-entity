using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using apiassignment.api.Controllers;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Web.Http;

namespace apiassignment.apiTests.NBench
{
    class TaskNBench
    {
        private const string parentCounterName = "test parent get";
        private Counter parentCounter;
        private int key;

        private const int AcceptableMinAddThroughput = 100;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            parentCounter = context.GetCounter(parentCounterName);
            key = 0;
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 600000, TestMode = TestMode.Measurement)]
        [CounterMeasurement(parentCounterName)]
        [CounterThroughputAssertion(parentCounterName, MustBe.GreaterThan, AcceptableMinAddThroughput)]
        public void ParentGetBenchMark(BenchmarkContext context)
        {
            ParentController parent = new ParentController();
            parent.Request = new HttpRequestMessage();
            parent.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            parent.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage _http;
            _http = parent.Get();
            parentCounter.Increment();
        }
    }
}
