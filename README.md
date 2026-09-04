# echo_demo Part 4
## install the stryker tool
```
dotnet new tool-manifest
dotnet tool install dotnet-stryker
```

## Run stryker
```
cd test/EchoLoop.Tests
dotnet tool run dotnet-stryker
```

## Check results
There should be a report file in `StrykerOutput/<timestamp>/reports/mutation-report.html` or similar