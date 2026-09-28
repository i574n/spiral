"""Generates one .fsproj that compiles a spiral-split output directory (or the monolith core) as a single
F# compilation, so graph-based checking can type-check independent files in parallel without the
per-project overhead of the gear build. Used by scripts/bench-split.ps1.

  python split_project.py parts    <split-out-dir> <lib-dir> <supervisor.dll> <project-dir> [--cap N] [--budget N] [--nograph]
  python split_project.py monolith <core.fs>       <lib-dir> <supervisor.dll> <project-dir> [--nograph]

`parts` orders the Part files topologically over the shard compile graph. With --cap N > 0, consecutive
parts are concatenated into larger files (several `module` blocks under one `namespace Polyglot`): a
shard joins the dependency group on its critical path when that group stays under N lines, every other
dependency lives in an older group, and the group's estimated finish stays within --budget lines.
"""
import argparse, csv, glob, heapq, os
from collections import defaultdict

parser = argparse.ArgumentParser()
parser.add_argument("kind", choices=["parts", "monolith"])
parser.add_argument("source")
parser.add_argument("lib")
parser.add_argument("supervisor")
parser.add_argument("project_dir")
parser.add_argument("--cap", type=int, default=0)
parser.add_argument("--budget", type=int, default=60000)
parser.add_argument("--nograph", action="store_true")
args = parser.parse_args()
os.makedirs(args.project_dir, exist_ok=True)


def topological_parts(out):
    rows = list(csv.DictReader(open(os.path.join(out, "parts.tsv"), encoding="utf-8"), delimiter="\t"))
    deps = {int(r["shard"]): {int(d) for d in (r["compile_dependencies"] or "").split(",") if d.strip()} for r in rows}
    lines = {int(r["shard"]): int(r["lines"]) for r in rows}
    users, indeg = defaultdict(list), {n: 0 for n in deps}
    for n, ds in deps.items():
        for d in ds:
            users[d].append(n)
            indeg[n] += 1
    ready = [n for n in deps if indeg[n] == 0]
    heapq.heapify(ready)
    order = []
    while ready:
        n = heapq.heappop(ready)
        order.append(n)
        for u in users[n]:
            indeg[u] -= 1
            if indeg[u] == 0:
                heapq.heappush(ready, u)
    assert len(order) == len(deps), "cycle in shard graph"
    return order, deps, lines


def group_parts(order, deps, lines, cap, budget):
    group_of, groups, size, start = {}, [], [], []
    finish = lambda g: start[g] + size[g]
    for n in order:
        dep_groups = {group_of[d] for d in deps[n]}
        target = max(dep_groups, key=finish, default=None) if cap > 0 else None
        others = [g for g in dep_groups if g != target]
        ready = max((finish(g) for g in others), default=0)
        if (target is not None and size[target] + lines[n] <= cap and all(g < target for g in others)
                and max(start[target], ready) + size[target] + lines[n] <= budget):
            start[target] = max(start[target], ready)
            group_of[n] = target
            groups[target].append(n)
            size[target] += lines[n]
        else:
            group_of[n] = len(groups)
            groups.append([n])
            size.append(lines[n])
            start.append(max((finish(g) for g in dep_groups), default=0))
    done = []
    for g, members in enumerate(groups):
        external = {group_of[d] for n in members for d in deps[n]} - {g}
        done.append(size[g] + max((done[d] for d in external), default=0))
    return groups, max(done), max(size)


if args.kind == "monolith":
    files = [os.path.abspath(args.source)]
    summary = f"monolith {files[0]}"
else:
    order, deps, lines = topological_parts(args.source)
    if args.cap > 0:
        groups, critical, largest = group_parts(order, deps, lines, args.cap, args.budget)
        files = []
        for index, members in enumerate(groups):
            path = os.path.join(args.project_dir, f"Group{index:04d}.fs")
            with open(path, "w", encoding="utf-8", newline="\n") as f:
                f.write("namespace Polyglot\n")
                for n in members:
                    text = open(os.path.join(args.source, f"Part{n:04d}.fs"), encoding="utf-8").read()
                    assert text.startswith("namespace Polyglot\n"), n
                    f.write(text[len("namespace Polyglot\n"):].rstrip("\n") + "\n")
            files.append(path)
        summary = f"{len(order)} parts -> {len(files)} files (cap {args.cap}, largest {largest} lines, critical path {critical} lines)"
    else:
        files = [os.path.join(os.path.abspath(args.source), f"Part{n:04d}.fs") for n in order]
        summary = f"{len(files)} part files"

graph = not args.nograph
flags = f"--times:{os.path.join(os.path.abspath(args.project_dir), 'times.csv')} --nooptimizationdata"
if graph:
    flags += " --test:GraphBasedChecking --test:ParallelOptimization --test:ParallelIlxGen"
refs = sorted(p for p in glob.glob(os.path.join(args.lib, "*.dll"))
              if os.path.basename(p) != "SpiralCompilerDependencies.dll") + [args.supervisor]
project = os.path.join(args.project_dir, "SplitBench.fsproj")
with open(project, "w", encoding="utf-8") as f:
    f.write('<Project Sdk="Microsoft.NET.Sdk">\n  <PropertyGroup>\n')
    f.write("    <TargetFramework>net11.0</TargetFramework>\n    <LangVersion>preview</LangVersion>\n")
    f.write("    <OutputType>Library</OutputType>\n    <AssemblyName>SpiralCompilerSplitBench</AssemblyName>\n")
    f.write("    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>\n    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>\n")
    f.write("    <DisableImplicitFSharpCoreReference>true</DisableImplicitFSharpCoreReference>\n")
    f.write(f"    <ParallelCompilation>{'true' if graph else 'false'}</ParallelCompilation>\n")
    f.write("    <DefineConstants>_LINUX</DefineConstants>\n    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>\n")
    f.write("    <NoWarn>$(NoWarn);FS0064;FS3370;FS0025;FS0049;FS1182;FS3560</NoWarn>\n")
    f.write(f"    <OtherFlags>{flags}</OtherFlags>\n  </PropertyGroup>\n  <ItemGroup>\n")
    for path in files:
        f.write(f'    <Compile Include="{path}" />\n')
    f.write("  </ItemGroup>\n  <ItemGroup>\n")
    for r in refs:
        name = os.path.splitext(os.path.basename(r))[0]
        f.write(f'    <Reference Include="{name}"><HintPath>{r}</HintPath></Reference>\n')
    f.write('  </ItemGroup>\n  <ItemGroup><FrameworkReference Include="Microsoft.AspNetCore.App" /></ItemGroup>\n</Project>\n')
print(f"{summary} -> {project}")
