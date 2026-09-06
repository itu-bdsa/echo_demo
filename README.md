# echo_demo Part 3

## Parameters

```bash
dotnet add    test/EchoLoop.Tests package coverlet.msbuild
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./coverage/
```

Coverage is printed as a table in the console and written to ./coverage/.
Runt the following: The build fails if line coverage is below 80%.

```bash
dotnet test /p:CollectCoverage=true /p:Threshold=80 /p:ThresholdType=line,branch,method /p:ThresholdStat=total
```

### Configuration

Add to `test/EchoLoop.Tests/EchoLoop.Tests.csproj` so the flags are saved for every run. The below should pass `dotnet test`, as the threshold is now at 40.

```xml
<PropertyGroup>
  <CollectCoverage>true</CollectCoverage>
  <CoverletOutputFormat>cobertura</CoverletOutputFormat>
  <CoverletOutput>./coverage/</CoverletOutput>
  <Threshold>40</Threshold>
  <ThresholdType>line</ThresholdType>
</PropertyGroup>
```
