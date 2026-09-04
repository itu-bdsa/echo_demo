# Stage 0 — Project setup

Goal: a console app in `src/`, ready for a test project.

## 1. Scaffold

```bash
mkdir echoloop && cd echoloop
git init
dotnet new gitignore

dotnet new console -n EchoLoop -f net8.0
```

`-f net8.0` pins the target framework; without it you get whatever the SDK defaults to.

## 2. Move into src/

```bash
mkdir src
git mv EchoLoop src/
```

`src` must exist first, otherwise `mv` renames instead of moving.

## 3. Add a solution

```bash
dotnet new sln -n EchoLoop
dotnet sln add src/EchoLoop/EchoLoop.csproj
```

A `.sln` is just a list of projects. Not required to build, but it lets
`dotnet build` / `dotnet test` operate on the whole group from the root.

## 4. Drop in the code

Copy `Program.cs` and `Repeater.cs` from this folder into `src/EchoLoop/`,
overwriting the generated `Program.cs`.

```bash
cp 00-start/Program.cs 00-start/Repeater.cs src/EchoLoop/
```

No csproj edit needed — the SDK compiles every `.cs` under the project
directory by glob.

## 5. Run

```bash
dotnet build
dotnet run --project src/EchoLoop -- "ping" 3
dotnet run --project src/EchoLoop -- "ping" abc   # exit code 1
```

## Layout

```
echoloop/
├── EchoLoop.sln
└── src/EchoLoop/
    ├── EchoLoop.csproj
    ├── Program.cs
    └── Repeater.cs
```

## Why this code

Two public methods, both pure — values in, values out. No console, no clock,
no files. `Program.cs` holds the I/O and has nothing left worth testing.

`ParseArgs` has a small decision tree that will matter later:

| Input | Result |
|---|---|
| `[]` or 3+ args | `ArgumentException` |
| `["hi"]` | `("hi", 1)` |
| `["hi", "3"]` | `("hi", 3)` |
| `["hi", "abc"]` | `ArgumentException` |
| `["hi", "-3"]` | `ArgumentException` |

Next: `01-xunit/README.md`
