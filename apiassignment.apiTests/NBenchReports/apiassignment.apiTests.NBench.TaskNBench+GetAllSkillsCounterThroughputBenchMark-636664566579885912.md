# apiassignment.apiTests.NBench.TaskNBench+GetAllSkillsCounterThroughputBenchMark
_06-07-2018 06:50:57_
### System Info
```ini
NBench=NBench, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
OS=Microsoft Windows NT 6.2.9200.0
ProcessorCount=3
CLR=4.0.30319.42000,IsMono=False,MaxGcGeneration=2
```

### NBench Settings
```ini
RunMode=Throughput, TestMode=Measurement
NumberOfIterations=10, MaximumRunTime=00:00:06
Concurrent=False
Tracing=False
```

## Data
-------------------

### Totals
|          Metric |           Units |             Max |         Average |             Min |          StdDev |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|[Counter] test parent get |      operations |            0.00 |            0.00 |            0.00 |            0.00 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|[Counter] test parent get |      operations |            0.00 |            0.00 |            0.00 |            0.00 |

### Raw Data
#### [Counter] test parent get
|           Run # |      operations |  operations / s | ns / operations |
|---------------- |---------------- |---------------- |---------------- |
|               1 |            0.00 |            0.00 |          100.00 |


```
NBench.NBenchException: Error occurred during $apiassignment.apiTests.NBench.TaskNBench+GetAllSkillsCounterThroughputBenchMark RUN. ---> System.ArgumentNullException: Value cannot be null.
Parameter name: request
   at System.Net.Http.HttpRequestMessageExtensions.CreateResponse[T](HttpRequestMessage request, HttpStatusCode statusCode, T value, HttpConfiguration configuration)
   at System.Net.Http.HttpRequestMessageExtensions.CreateResponse[T](HttpRequestMessage request, HttpStatusCode statusCode, T value)
   at apiassignment.api.Controllers.ParentController.Get() in C:\fsd\api-assignment\apiassignment\apiassignment.api\Controllers\ParentController.cs:line 32
   at apiassignment.apiTests.NBench.TaskNBench.GetAllSkillsCounterThroughputBenchMark(BenchmarkContext context) in C:\fsd\api-assignment\apiassignment\apiassignment.apiTests\NBench\TaskNBench.cs:line 32
   at NBench.Sdk.ReflectionBenchmarkInvoker.<>c__DisplayClass10_0.<InvokePerfSetup>b__0(BenchmarkContext ctx)
   at NBench.Sdk.Benchmark.WarmUp()
   --- End of inner exception stack trace ---
```

