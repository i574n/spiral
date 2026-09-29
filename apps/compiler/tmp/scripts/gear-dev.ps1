<#
.SYNOPSIS
Fast type-check loop for a compiler core: split it into gear projects and rebuild only what an edit touched.

.DESCRIPTION
1. `spiral-split gears` emits the core into <cache>/gear-dev/<mode>/emit (~40 s for the hopac core).
2. Files whose content changed are copied into <cache>/gear-dev/<mode>/build; unchanged files keep their
   timestamps, so MSBuild sees them as up to date. The build directory has its own Directory.Build.props
   with fixed output paths and reference assemblies.
3. The first run (or -Full) builds everything through GearRoot. Later runs build only gears with a changed
   part or project, in dependency order and without walking project references. When a gear's IL surface
   changes, its dependents are rebuilt too. More than 8 gears to rebuild stops the run unless -Force.
4. A copy of compiler/host is built against the gears: a runnable compiler for SPIRAL_COMPILER_DLL.

See lanes/splitter/README.md.

.EXAMPLE
pwsh scripts/gear-dev.ps1               # hopac core
pwsh scripts/gear-dev.ps1 -Full         # rebuild every gear
pwsh scripts/gear-dev.ps1 -Force        # rebuild however many gears the edit dirtied
#>
param(
    [ValidateSet('hopac', 'single-flight')][string]$Mode = 'hopac',
    [switch]$Full,
    [switch]$Force,
    # Parallel MSBuild nodes for full builds. Each runs its own F# compiler (the peval gear alone takes
    # several GB), so this stays low; raise it on machines with plenty of memory.
    [int]$MaxNodes = 2
)
. $PSScriptRoot/env.ps1

$dotnet = Resolve-SpiralDotnet
$cache = Get-SpiralCacheDir
# The splitter reads one core: this mode's side of the merged file's section pairs.
$core = Get-SpiralCoreProjection $Mode (Join-Path $cache "gear-dev/$Mode/core.fs")
$splitter = Join-Path $cache ('splitter-target/release/spiral-split' + $(if ($IsWindows) { '.exe' } else { '' }))
$overlay = Join-Path $cache "bin/$Mode/SpiralCompilerRuntimeCompat/Release/net11.0"
if (-not (Test-Path $splitter)) { throw "missing $splitter (run scripts/build-splitter.ps1)" }
if (-not (Test-Path (Join-Path $overlay 'Supervisor.dll'))) { throw "missing Supervisor.dll in $overlay (run scripts/build.ps1 -Mode $Mode)" }
$env:SPIRAL_ASSEMBLY_ROOT = Get-SpiralLibDir
$root = Join-Path $cache "gear-dev/$Mode"
$emit = Join-Path $root 'emit'
$build = Join-Path $root 'build'
New-Item -ItemType Directory -Force $build | Out-Null
$clock = [Diagnostics.Stopwatch]::StartNew()

# ---- 1. emit
# The previous emission's anchors keep its gears and part/gear numbers (splitter README, "Stable gears"), so
# adding a declaration rebuilds the gears around it instead of renumbering every later part. -Full re-plans
# from scratch (contiguous numbering, fresh packing).
$anchors = Join-Path $root 'anchors.tsv'
if ($Full) { Remove-Item -LiteralPath $anchors -ErrorAction SilentlyContinue }
if (Test-Path -LiteralPath $anchors) { $env:SPIRAL_GEAR_ANCHORS = $anchors } else { Remove-Item Env:SPIRAL_GEAR_ANCHORS -ErrorAction SilentlyContinue }
& $splitter gears $core $emit --threads ([Environment]::ProcessorCount) --assembly-overlay-root $overlay | Select-Object -Last 1 | Out-Host
if ($LASTEXITCODE -ne 0) { throw 'spiral-split gears failed' }
$emitSeconds = [int]$clock.Elapsed.TotalSeconds

# ---- 2. sync changed sources and projects
$changed = [Collections.Generic.HashSet[string]]::new()
$emitted = Get-ChildItem $emit -File | Where-Object { $_.Extension -in '.fs', '.fsproj' }
$copies = @($emitted | Where-Object {
    $target = Join-Path $build $_.Name
    -not (Test-Path $target) -or (Get-FileHash $_.FullName).Hash -ne (Get-FileHash $target).Hash
})
foreach ($file in $copies) { [void]$changed.Add($file.Name) }
$names = [Collections.Generic.HashSet[string]]::new([string[]]@($emitted.Name))
$stale = @(Get-ChildItem $build -File | Where-Object { $_.Extension -in '.fs', '.fsproj' -and -not $names.Contains($_.Name) })
foreach ($file in $stale) { [void]$changed.Add($file.Name) }
# An edit that renumbers parts or reshapes gears costs about a full build. Say so before syncing anything,
# so an aborted run leaves the build directory as it was and the next run sees the same changes.
if (-not $Full -and -not $Force -and (Test-Path (Join-Path $build '.out/full-build.ok'))) {
    $projects = @(Get-ChildItem $emit -Filter 'Gear*.fsproj' | Where-Object BaseName -ne 'GearRoot')
    $wouldRebuild = @($projects | Where-Object {
        $changed.Contains($_.Name) -or @([regex]::Matches((Get-Content $_.FullName -Raw), '<Compile Include="([^"]+)"') | Where-Object { $changed.Contains($_.Groups[1].Value) }).Count
    }).Count
    if ($wouldRebuild -gt 8) {
        Write-Host ("== {0} of {1} gears would rebuild (the edit renumbered parts or reshaped gears): about {2} min at -MaxNodes {3}; the monolith (scripts/build.ps1 -Mode {4}) takes ~4 min. Nothing synced; rerun with -Force to rebuild the gears anyway." -f $wouldRebuild, $projects.Count, [Math]::Ceiling($wouldRebuild * 7 / 60), $MaxNodes, $Mode) -ForegroundColor Yellow
        exit 2
    }
}
foreach ($file in $copies) { Copy-Item -LiteralPath $file.FullName -Destination (Join-Path $build $file.Name) -Force }
foreach ($file in $stale) { Remove-Item -LiteralPath $file.FullName }
# build/ now holds this emission's numbering; the next emission anchors to it.
Copy-Item -LiteralPath (Join-Path $emit 'anchors.tsv') -Destination $anchors -Force
if ($changed.Count -and $changed.Count -le 10) { Write-Host "   changed: $(@($changed) -join ', ')" }
$outputs = (Join-Path $build '.out').Replace('\', '/')
$props = @"
<Project>
  <PropertyGroup>
    <BaseOutputPath>$outputs/bin/`$(MSBuildProjectName)/</BaseOutputPath>
    <BaseIntermediateOutputPath>$outputs/obj/`$(MSBuildProjectName)/</BaseIntermediateOutputPath>
    <Optimize>false</Optimize>
    <DebugSymbols>false</DebugSymbols>
    <DebugType>None</DebugType>
    <Deterministic>true</Deterministic>
    <ProduceReferenceAssembly>true</ProduceReferenceAssembly>
  </PropertyGroup>
</Project>
"@
$propsPath = Join-Path $build 'Directory.Build.props'
if (-not (Test-Path $propsPath) -or (Get-Content $propsPath -Raw) -ne $props) { Set-Content -LiteralPath $propsPath -Value $props -NoNewline; $Full = $true }

# ---- 3. which gears changed, in dependency order
$gears = [ordered]@{}
foreach ($project in Get-ChildItem $build -Filter 'Gear*.fsproj' | Where-Object BaseName -ne 'GearRoot' | Sort-Object Name) {
    $text = Get-Content $project.FullName -Raw
    $gears[$project.BaseName] = [pscustomobject]@{
        Parts = @([regex]::Matches($text, '<Compile Include="([^"]+)"') | ForEach-Object { $_.Groups[1].Value })
        Deps = @([regex]::Matches($text, '<ProjectReference Include="([^"]+)\.fsproj"') | ForEach-Object { $_.Groups[1].Value })
    }
}
$dirty = [Collections.Generic.HashSet[string]]::new()
foreach ($name in $gears.Keys) {
    if ($changed.Contains("$name.fsproj") -or @($gears[$name].Parts | Where-Object { $changed.Contains($_) }).Count) { [void]$dirty.Add($name) }
}
# A compile killed mid-write (e.g. for low memory) leaves an empty assembly in obj/ that MSBuild then
# trusts as up to date; drop it so the gear really recompiles.
foreach ($name in $gears.Keys) {
    $assembly = Get-Item -LiteralPath "$outputs/bin/$name/Debug/net11.0/SpiralCompiler$name.dll" -ErrorAction SilentlyContinue
    if ($assembly -and $assembly.Length) { continue }
    Get-ChildItem (Join-Path $outputs "obj/$name") -Recurse -Filter '*.dll' -ErrorAction SilentlyContinue | Where-Object Length -eq 0 | Remove-Item -Force
    [void]$dirty.Add($name)
}
$order = [Collections.Generic.List[string]]::new()
$visited = [Collections.Generic.HashSet[string]]::new()
function Visit([string]$name) {
    if (-not $visited.Add($name)) { return }
    foreach ($dep in $gears[$name].Deps) { if ($gears.Contains($dep)) { Visit $dep } }
    $order.Add($name)
}
foreach ($name in $gears.Keys) { Visit $name }
$dependents = @{}
foreach ($name in $gears.Keys) { foreach ($dep in $gears[$name].Deps) { if (-not $dependents[$dep]) { $dependents[$dep] = @() }; $dependents[$dep] += $name } }

# F# reference assemblies are not stable across body-only edits: a changed string literal rewrites most
# of the file (metadata heaps shift, the MVID follows the whole compilation). What dependents and the host
# bind to is the IL surface, so that is what gets compared: type, method, field and property names,
# attributes and signature blobs, without bodies, heap offsets, MVID or F#'s range-bearing resources.
if (-not ('SpiralGearSurface' -as [type])) {
    Add-Type -TypeDefinition @'
using System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
public static class SpiralGearSurface {
    // One line per type and per member; members name their type, so a member moving between types is a
    // removal plus an addition, not an addition alone.
    public static string Describe(string path) {
        if (!File.Exists(path)) return "";
        using var stream = File.OpenRead(path);
        using var pe = new PEReader(stream);
        var md = pe.GetMetadataReader();
        var text = new StringBuilder();
        void Blob(BlobHandle handle) => text.Append(Convert.ToHexString(md.GetBlobBytes(handle))).Append(';');
        foreach (var typeHandle in md.TypeDefinitions) {
            var type = md.GetTypeDefinition(typeHandle);
            var name = md.GetString(type.Namespace) + "." + md.GetString(type.Name);
            text.Append("T ").Append(name).Append(' ').Append((int)type.Attributes).Append('\n');
            foreach (var h in type.GetMethods()) { var m = md.GetMethodDefinition(h); text.Append("M ").Append(name).Append("::").Append(md.GetString(m.Name)).Append(' ').Append((int)m.Attributes).Append(' '); Blob(m.Signature); text.Append('\n'); }
            foreach (var h in type.GetFields()) { var f = md.GetFieldDefinition(h); text.Append("F ").Append(name).Append("::").Append(md.GetString(f.Name)).Append(' ').Append((int)f.Attributes).Append(' '); Blob(f.Signature); text.Append('\n'); }
            foreach (var h in type.GetProperties()) { var p = md.GetPropertyDefinition(h); text.Append("P ").Append(name).Append("::").Append(md.GetString(p.Name)).Append(' '); Blob(p.Signature); text.Append('\n'); }
        }
        foreach (var h in md.TypeReferences) { var r = md.GetTypeReference(h); text.Append("R ").Append(md.GetString(r.Namespace)).Append('.').Append(md.GetString(r.Name)).Append('\n'); }
        foreach (var h in md.AssemblyReferences) { var a = md.GetAssemblyReference(h); text.Append("A ").Append(md.GetString(a.Name)).Append('\n'); }
        return text.ToString();
    }
    // Names of the types ("T:ns.Name") and members ("N:name") whose lines `before` has and `after` lacks
    // (removed or altered). Lost type and assembly references are not the dependents' concern.
    public static string[] LostNames(string before, string after) {
        var now = new System.Collections.Generic.HashSet<string>(after.Split('\n'));
        var names = new System.Collections.Generic.HashSet<string>();
        foreach (var line in before.Split('\n')) {
            if (line.Length < 3 || now.Contains(line)) continue;
            var rest = line.Substring(2);
            var space = rest.IndexOf(' ');
            var id = space < 0 ? rest : rest.Substring(0, space);
            if (line[0] == 'T') names.Add("T:" + id);
            else if (line[0] == 'M' || line[0] == 'F' || line[0] == 'P') names.Add("N:" + id.Substring(id.IndexOf("::") + 2));
        }
        return System.Linq.Enumerable.ToArray(names);
    }
    // Whether an assembly references any of `names`: a type reference by full name, or a member reference
    // (method, field; property accessors are methods) by name. By name only, so a collision rebuilds more,
    // never less: every use of another assembly's type or member compiles to such a reference.
    public static bool References(string path, string[] names) {
        if (names.Length == 0) return false;
        if (!File.Exists(path)) return true;
        var wanted = new System.Collections.Generic.HashSet<string>(names);
        using var stream = File.OpenRead(path);
        using var pe = new PEReader(stream);
        var md = pe.GetMetadataReader();
        foreach (var h in md.TypeReferences) { var r = md.GetTypeReference(h); if (wanted.Contains("T:" + md.GetString(r.Namespace) + "." + md.GetString(r.Name))) return true; }
        foreach (var h in md.MemberReferences) { var m = md.GetMemberReference(h); if (wanted.Contains("N:" + md.GetString(m.Name))) return true; }
        return false;
    }
}
'@
}
# Each gear's reference assembly is copied to surface/ only when its IL surface changes; the host compiles
# against those copies, so a body-only edit leaves it up to date. Update-Surface says how it changed:
# 'same', 'grew' (members only added: dependents built against the old surface still bind to everything
# they use, so they do not rebuild; a new declaration used to rebuild every dependent of its gear, 75 of
# 138 gears for one `let`) or 'changed' with the names it lost (removed or altered types and members):
# then only the dependents whose assembly references one of those names rebuild.
$surfaceDir = Join-Path $outputs 'surface'
New-Item -ItemType Directory -Force $surfaceDir | Out-Null
function Update-Surface([string]$name) {
    $ref = "$outputs/obj/$name/Debug/net11.0/ref/SpiralCompiler$name.dll"
    $surfacePath = Join-Path $surfaceDir "$name.surface"
    $copy = Join-Path $surfaceDir "SpiralCompiler$name.dll"
    # Surfaces recorded before descriptions were kept: describe the stored copy instead.
    $old = if (Test-Path -LiteralPath $surfacePath) { [IO.File]::ReadAllText($surfacePath) } else { [SpiralGearSurface]::Describe($copy) }
    $new = [SpiralGearSurface]::Describe($ref)
    if (-not $new -or $new -eq $old) { return [pscustomobject]@{ Kind = 'same'; Lost = @() } }
    Copy-Item -LiteralPath $ref -Destination (Join-Path $surfaceDir "SpiralCompiler$name.dll") -Force
    [IO.File]::WriteAllText($surfacePath, $new)
    if (-not $old) { return [pscustomobject]@{ Kind = 'changed'; Lost = $null } }
    $lost = [SpiralGearSurface]::LostNames($old, $new)
    [pscustomobject]@{ Kind = $(if ($lost.Count) { 'changed' } else { 'grew' }); Lost = $lost }
}

# ---- 4. build
# Written only after a successful full build, so an interrupted one is redone rather than trusted.
$stamp = Join-Path $build '.out/full-build.ok'
$firstBuild = -not (Test-Path $stamp)
$built = 0
$errors = @()
# Gears are built one at a time below; past a handful, MSBuild's own graph build (parallel, skipping
# up-to-date gears) wins. A declaration added or removed renumbers every later part, dirtying most gears.
$wide = $dirty.Count -gt 8
if ($Full -or $firstBuild -or $wide) {
    $log = & $dotnet build (Join-Path $build 'GearRoot.fsproj') "-m:$MaxNodes" -nologo -v:q 2>&1
    $errors = @($log | Select-String ': error ' | ForEach-Object { $_.Line -replace ' \[.*$', '' } | Sort-Object -Unique)
    $built = if ($wide -and -not ($Full -or $firstBuild)) { $dirty.Count } else { $gears.Count }
    # A graph build that stopped part way leaves gears whose sources are synced but never compiled; without
    # the stamp the next run goes through MSBuild's graph build again, which rebuilds exactly those.
    if ($LASTEXITCODE -eq 0 -and -not $errors.Count) { Set-Content -LiteralPath $stamp -Value (Get-Date -Format s) }
    else { Remove-Item -LiteralPath $stamp -ErrorAction SilentlyContinue }
} elseif ($dirty.Count -or $changed.Contains('GearRoot.fs') -or $changed.Contains('GearRoot.fsproj')) {
    if (@($changed | Where-Object { $_ -like '*.fsproj' }).Count) {
        & $dotnet restore (Join-Path $build 'GearRoot.fsproj') -nologo -v:q | Out-Null
    }
    foreach ($name in $order) {
        if (-not $dirty.Contains($name)) { continue }
        $log = & $dotnet build (Join-Path $build "$name.fsproj") -nologo -v:q --no-restore -p:BuildProjectReferences=false 2>&1
        $built++
        $errors += @($log | Select-String ': error ' | ForEach-Object { $_.Line -replace ' \[.*$', '' } | Sort-Object -Unique)
        if ($errors.Count) { break }
        # Dependents only need rebuilding when the IL surface lost or changed something they reference.
        $surface = Update-Surface $name
        if ($surface.Kind -eq 'changed') {
            foreach ($dependent in @($dependents[$name])) {
                if (-not $dependent) { continue }
                $assembly = "$outputs/bin/$dependent/Debug/net11.0/SpiralCompiler$dependent.dll"
                if ($null -eq $surface.Lost -or [SpiralGearSurface]::References($assembly, $surface.Lost)) { [void]$dirty.Add($dependent) }
            }
        }
    }
    # GearRoot is not a gear, but GearRoot.initialize names the parts holding module-level `do`s.
    if (-not $errors.Count -and ($changed.Contains('GearRoot.fs') -or $changed.Contains('GearRoot.fsproj'))) {
        $log = & $dotnet build (Join-Path $build 'GearRoot.fsproj') -nologo -v:q --no-restore -p:BuildProjectReferences=false 2>&1
        $errors += @($log | Select-String ': error ' | ForEach-Object { $_.Line -replace ' \[.*$', '' } | Sort-Object -Unique)
    }
}
if (-not $errors.Count) {
    # MSBuild graph builds do not say which gears they recompiled; refresh every surface after one.
    foreach ($name in @($gears.Keys) + 'GearRoot') {
        if ($Full -or $firstBuild -or $wide -or $name -eq 'GearRoot' -or -not (Test-Path -LiteralPath (Join-Path $surfaceDir "SpiralCompiler$name.dll"))) {
            [void](Update-Surface $name)
        }
    }
}
$errors | Select-Object -First 30 | ForEach-Object { Write-Host "   $_" -ForegroundColor Red }
Write-Host ("== {0}: emit {1} s, {2} changed files, {3}/{4} gears built, {5} errors, {6} s" -f $Mode, $emitSeconds, $changed.Count, $built, $gears.Count, $errors.Count, [int]$clock.Elapsed.TotalSeconds)
if ($errors.Count) { exit 1 }

# ---- 5. a runnable compiler: the host, bound to the gear assemblies instead of SpiralCompilerCore
# The host opens `spiral_compiler`; the split core defines the same names across spiral_compiler_PartNNNN
# modules, so the copied host opens every part in source order (later parts shadow earlier ones, as later
# definitions do in the monolith).
$hostDir = Join-Path $root 'host'
New-Item -ItemType Directory -Force $hostDir | Out-Null
# Part numbers are stable across emissions, not ordered: anchors.tsv lists the declarations in source order.
$partOrder = [Collections.Generic.List[string]]::new()
$seenParts = [Collections.Generic.HashSet[string]]::new()
foreach ($line in [IO.File]::ReadLines($anchors) | Select-Object -Skip 1) {
    $cells = $line.Split("`t")   # declaration keys never hold tabs; they may hold quotes, so no Import-Csv
    $part = 'Part{0:D4}' -f [int]$cells[$cells.Length - 2]
    if ($seenParts.Add($part)) { $partOrder.Add($part) }
}
$unanchored = @(Get-ChildItem $build -Filter 'Part*.fs' | Where-Object { $_.BaseName -match '^Part\d+$' -and -not $seenParts.Contains($_.BaseName) } | Sort-Object { [int]$_.BaseName.Substring(4) })
if ($unanchored.Count) { Write-Host "   warning: $($unanchored.Count) parts not in anchors.tsv; opened last" -ForegroundColor Yellow; $unanchored | ForEach-Object { $partOrder.Add($_.BaseName) } }
$partOpens = ($partOrder | ForEach-Object { "open spiral_compiler_$_" }) -join "`n"
# The split also dissolves nested modules (`HopacExtensions.forceConcurrency` now lives at the top of some
# part); the splitter's qualified-rewrites map says where, and the host copy gets the same rewrite.
$rewrites = @{}
Import-Csv (Join-Path $emit 'qualified-rewrites.tsv') -Delimiter "`t" | ForEach-Object { $rewrites[$_.source_symbol] = $_.generated_symbol }
$qualify = [Text.RegularExpressions.MatchEvaluator]{
    param($match)
    $parts = $match.Value.Split('.')
    for ($n = $parts.Length; $n -ge 2; $n--) {
        $key = $parts[0..($n - 1)] -join '.'
        if ($rewrites.ContainsKey($key)) {
            $rest = if ($n -lt $parts.Length) { '.' + ($parts[$n..($parts.Length - 1)] -join '.') } else { '' }
            return $rewrites[$key] + $rest
        }
    }
    $match.Value
}
$hostSources = 'Program.fs'
foreach ($name in $hostSources) {
    $text = Get-Content (Join-Path $BundleRoot "compiler/host/$name") -Raw
    $text = [regex]::Replace($text, "(?<![\w.'])[A-Za-z_][\w']*(?:\.[A-Za-z_][\w']*)+", $qualify)
    $text = [regex]::Replace($text, '(?m)^open spiral_compiler\r?$', $partOpens)
    if ($name -eq 'Program.fs') {
        # The monolith runs its module-level `do`s the first time the host touches the core, right after
        # Hopac is configured; split, they only run when GearRoot.initialize reads their parts.
        $initialized = [regex]::new('(?m)^([ \t]*)configureHopacFromEnvironment \(\)(\r?)$').Replace($text, "`$1configureHopacFromEnvironment ()`$2`n`$1GearRoot.initialize ()`$2", 1)
        if ($initialized -eq $text) { throw 'gear-dev: no configureHopacFromEnvironment () call in Program.fs to initialize the gears after' }
        $text = $initialized
    }
    $target = Join-Path $hostDir $name
    if (-not (Test-Path $target) -or (Get-Content $target -Raw) -ne $text) { Set-Content -LiteralPath $target -Value $text -NoNewline }
}
$define = if ($Mode -eq 'hopac') { 'SPIRAL_CORE_HOPAC' } else { 'SPIRAL_CORE_SINGLE_FLIGHT' }
# The host compiles against the surface/ copies of the gears' reference assemblies, and the implementation
# assemblies are copied next to it after the build. A ProjectReference to GearRoot would instead feed the
# implementation assemblies (new on every edit) to the compile and have MSBuild evaluate every gear.
$assemblies = @($gears.Keys) + 'GearRoot'
$gearReferences = ($assemblies | ForEach-Object {
    "    <Reference Include=`"SpiralCompiler$_`"><HintPath>$outputs/surface/SpiralCompiler$_.dll</HintPath><Private>false</Private></Reference>"
}) -join "`n"
$hostOut = (Join-Path $hostDir '.out').Replace('\', '/')
$project = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net11.0</TargetFramework>
    <LangVersion>preview</LangVersion>
    <OutputType>Exe</OutputType>
    <AssemblyName>SpiralCompiler</AssemblyName>
    <RootNamespace>Polyglot</RootNamespace>
    <RollForward>Major</RollForward>
    <ServerGarbageCollection>true</ServerGarbageCollection>
    <ConcurrentGarbageCollection>true</ConcurrentGarbageCollection>
    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
    <NoWarn>`$(NoWarn);FS0064;FS3370;FS0025;FS0049;FS1182;FS3560</NoWarn>
    <DefineConstants>`$(DefineConstants);$define</DefineConstants>
    <BaseOutputPath>$hostOut/bin/</BaseOutputPath>
    <BaseIntermediateOutputPath>$hostOut/obj/</BaseIntermediateOutputPath>
    <!-- Without deps.json every assembly in the output folder is loadable, including the gears copied below. -->
    <GenerateDependencyFile>false</GenerateDependencyFile>
  </PropertyGroup>
  <ItemGroup>
$(($hostSources | ForEach-Object { "    <Compile Include=`"$_`" />" }) -join "`n")
  </ItemGroup>
  <ItemGroup>
$gearReferences
    <Reference Include="Supervisor"><HintPath>$((Join-Path $overlay 'Supervisor.dll'))</HintPath></Reference>
  </ItemGroup>
  <Import Project="$((Join-Path $BundleRoot 'compiler/lib/Packages.props'))" />
</Project>
"@
$hostProject = Join-Path $hostDir 'SpiralCompilerGearHost.fsproj'
if (-not (Test-Path $hostProject) -or (Get-Content $hostProject -Raw) -ne $project) { Set-Content -LiteralPath $hostProject -Value $project -NoNewline }
$hostClock = [Diagnostics.Stopwatch]::StartNew()
$log = & $dotnet build $hostProject -nologo -v:q 2>&1
$hostErrors = @($log | Select-String ': error ' | ForEach-Object { $_.Line -replace ' \[.*$', '' } | Sort-Object -Unique)
$hostErrors | Select-Object -First 20 | ForEach-Object { Write-Host "   $_" -ForegroundColor Red }
$dll = Get-ChildItem (Join-Path $hostDir '.out/bin') -Recurse -Filter 'SpiralCompiler.dll' -ErrorAction SilentlyContinue | Select-Object -First 1
if ($dll) {
    # Only each gear's own output: dependents hold copies that go stale when built with BuildProjectReferences=false.
    $own = foreach ($name in $assemblies) { Get-Item -LiteralPath "$outputs/bin/$name/Debug/net11.0/SpiralCompiler$name.dll" -ErrorAction SilentlyContinue }
    foreach ($gearDll in $own) {
        $target = Join-Path $dll.DirectoryName $gearDll.Name
        if (-not (Test-Path $target) -or (Get-Item $target).LastWriteTimeUtc -ne $gearDll.LastWriteTimeUtc) { Copy-Item -LiteralPath $gearDll.FullName -Destination $target -Force }
    }
    Remove-Item -LiteralPath ([IO.Path]::ChangeExtension($dll.FullName, '.deps.json')) -ErrorAction SilentlyContinue
}
Write-Host ("== host: {0} errors, {1} s{2}" -f $hostErrors.Count, [int]$hostClock.Elapsed.TotalSeconds, $(if ($dll) { " -> $($dll.FullName)" } else { '' }))
if ($hostErrors.Count -or -not $dll) { exit 1 }
Write-Host "run the tests with it: `$env:SPIRAL_COMPILER_DLL = '$($dll.FullName)'; pwsh scripts/test.ps1 -Mode $Mode ..."
Write-Host ("== total {0} s" -f [int]$clock.Elapsed.TotalSeconds)
