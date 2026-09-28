<#
.SYNOPSIS
Fast type-check loop for a compiler core: split it into gear projects and rebuild only what an edit touched.

.DESCRIPTION
1. `spiral-split gears` emits the core into <cache>/gear-dev/<mode>/emit (~40 s for the hopac core).
2. Files whose content changed are copied into <cache>/gear-dev/<mode>/build; unchanged files keep their
   timestamps, so MSBuild sees them as up to date. The build directory has its own Directory.Build.props
   with fixed output paths and reference assemblies.
3. The first run (or -Full) builds everything through GearRoot. Later runs build only gears with a changed
   part or project, in dependency order and without walking project references. When a gear's reference
   assembly changes (its public surface), its dependents are rebuilt too.

The result is the compile verdict (errors with Part file positions); the gear assemblies are not yet a
runnable compiler (see lanes/splitter/README.md).

.EXAMPLE
pwsh scripts/gear-dev.ps1               # hopac core
pwsh scripts/gear-dev.ps1 -Full         # rebuild every gear
#>
param(
    [ValidateSet('hopac', 'single-flight')][string]$Mode = 'hopac',
    [switch]$Full
)
. $PSScriptRoot/env.ps1

$dotnet = Resolve-SpiralDotnet
$cache = Get-SpiralCacheDir
$core = Get-SpiralCoreSource $Mode
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
& $splitter gears $core $emit --threads ([Environment]::ProcessorCount) --assembly-overlay-root $overlay | Select-Object -Last 1 | Out-Host
if ($LASTEXITCODE -ne 0) { throw 'spiral-split gears failed' }
$emitSeconds = [int]$clock.Elapsed.TotalSeconds

# ---- 2. sync changed sources and projects
$changed = [Collections.Generic.HashSet[string]]::new()
$emitted = Get-ChildItem $emit -File | Where-Object { $_.Extension -in '.fs', '.fsproj' }
foreach ($file in $emitted) {
    $target = Join-Path $build $file.Name
    if (-not (Test-Path $target) -or (Get-FileHash $file.FullName).Hash -ne (Get-FileHash $target).Hash) {
        Copy-Item -LiteralPath $file.FullName -Destination $target -Force
        [void]$changed.Add($file.Name)
    }
}
$names = [Collections.Generic.HashSet[string]]::new([string[]]@($emitted.Name))
foreach ($stale in Get-ChildItem $build -File | Where-Object { $_.Extension -in '.fs', '.fsproj' -and -not $names.Contains($_.Name) }) {
    Remove-Item -LiteralPath $stale.FullName
    [void]$changed.Add($stale.Name)
}
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
foreach ($project in Get-ChildItem $build -Filter 'Gear[0-9]*.fsproj' | Sort-Object Name) {
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

# ---- 4. build
$firstBuild = -not (Test-Path (Join-Path $outputs 'bin'))
$built = 0
$errors = @()
if ($Full -or $firstBuild) {
    $log = & $dotnet build (Join-Path $build 'GearRoot.fsproj') -m -nologo -v:q 2>&1
    $errors = @($log | Select-String ': error ' | ForEach-Object { $_.Line -replace ' \[.*$', '' } | Sort-Object -Unique)
    $built = $gears.Count
} elseif ($dirty.Count) {
    if (@($changed | Where-Object { $_ -like '*.fsproj' }).Count) {
        & $dotnet restore (Join-Path $build 'GearRoot.fsproj') -nologo -v:q | Out-Null
    }
    foreach ($name in $order) {
        if (-not $dirty.Contains($name)) { continue }
        $ref = Get-ChildItem (Join-Path $outputs "bin/$name") -Recurse -Filter '*.dll' -ErrorAction SilentlyContinue | Where-Object { $_.Directory.Name -eq 'ref' } | Select-Object -First 1
        $before = if ($ref) { (Get-FileHash $ref.FullName).Hash } else { '' }
        $log = & $dotnet build (Join-Path $build "$name.fsproj") -nologo -v:q --no-restore -p:BuildProjectReferences=false 2>&1
        $built++
        $errors += @($log | Select-String ': error ' | ForEach-Object { $_.Line -replace ' \[.*$', '' } | Sort-Object -Unique)
        if ($errors.Count) { break }
        $ref = Get-ChildItem (Join-Path $outputs "bin/$name") -Recurse -Filter '*.dll' -ErrorAction SilentlyContinue | Where-Object { $_.Directory.Name -eq 'ref' } | Select-Object -First 1
        $after = if ($ref) { (Get-FileHash $ref.FullName).Hash } else { '' }
        if ($after -ne $before) { foreach ($dependent in @($dependents[$name])) { if ($dependent) { [void]$dirty.Add($dependent) } } }
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
$partOpens = (Get-ChildItem $build -Filter 'Part[0-9]*.fs' | Sort-Object Name | ForEach-Object { "open spiral_compiler_$($_.BaseName)" }) -join "`n"
$hostSources = 'PortableUnionNormalizer.fs', 'TuplePrune.fs', 'PortableBackends.fs', 'Program.fs'
foreach ($name in $hostSources) {
    $text = Get-Content (Join-Path $BundleRoot "compiler/host/$name") -Raw
    $text = [regex]::Replace($text, '(?m)^open spiral_compiler\r?$', $partOpens)
    $target = Join-Path $hostDir $name
    if (-not (Test-Path $target) -or (Get-Content $target -Raw) -ne $text) { Set-Content -LiteralPath $target -Value $text -NoNewline }
}
$define = if ($Mode -eq 'hopac') { 'SPIRAL_CORE_HOPAC' } else { 'SPIRAL_CORE_SINGLE_FLIGHT' }
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
  </PropertyGroup>
  <ItemGroup>
$(($hostSources | ForEach-Object { "    <Compile Include=`"$_`" />" }) -join "`n")
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="$((Join-Path $build 'GearRoot.fsproj'))" />
    <Reference Include="Supervisor"><HintPath>$((Join-Path $overlay 'Supervisor.dll'))</HintPath></Reference>
  </ItemGroup>
  <Import Project="$((Join-Path $BundleRoot 'compiler/lib/Packages.props'))" />
</Project>
"@
$hostProject = Join-Path $hostDir 'SpiralCompilerGearHost.fsproj'
if (-not (Test-Path $hostProject) -or (Get-Content $hostProject -Raw) -ne $project) { Set-Content -LiteralPath $hostProject -Value $project -NoNewline }
$hostClock = [Diagnostics.Stopwatch]::StartNew()
$log = & $dotnet build $hostProject -nologo -v:q -p:BuildProjectReferences=false 2>&1
$hostErrors = @($log | Select-String ': error ' | ForEach-Object { $_.Line -replace ' \[.*$', '' } | Sort-Object -Unique)
$hostErrors | Select-Object -First 20 | ForEach-Object { Write-Host "   $_" -ForegroundColor Red }
$dll = Get-ChildItem (Join-Path $hostDir '.out/bin') -Recurse -Filter 'SpiralCompiler.dll' -ErrorAction SilentlyContinue | Select-Object -First 1
Write-Host ("== host: {0} errors, {1} s{2}" -f $hostErrors.Count, [int]$hostClock.Elapsed.TotalSeconds, $(if ($dll) { " -> $($dll.FullName)" } else { '' }))
if ($hostErrors.Count -or -not $dll) { exit 1 }
Write-Host "run the tests with it: `$env:SPIRAL_COMPILER_DLL = '$($dll.FullName)'; pwsh scripts/test.ps1 -Mode $Mode ..."
Write-Host ("== total {0} s" -f [int]$clock.Elapsed.TotalSeconds)
