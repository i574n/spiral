[CmdletBinding(PositionalBinding = $false)]
param(
    [Parameter(Mandatory)] [string[]] $File,
    [string] $Lib = (Join-Path $PSScriptRoot '../../../lib/spiral'),
    [string] $CoreRoot = (Join-Path $PSScriptRoot '../../..'),
    [string] $Compiler = (Join-Path $env:LOCALAPPDATA 'spiral-bin/bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll'),
    [string] $Dotnet = (Join-Path $env:LOCALAPPDATA 'spiral-bin/toolchains/dotnet/dotnet.exe'),
    [string] $CopyRoot,
    [int] $TimeoutSeconds = 600,
    [int] $Show = 3,
    [string] $RawOut,
    [Parameter(ValueFromRemainingArguments)] [string[]] $MoreFiles = @()
)
$ErrorActionPreference = 'Stop'
$File = @($File + $MoreFiles | ForEach-Object { $_ -split ',' } | ForEach-Object Trim | Where-Object { $_ })
$Lib =(Resolve-Path -LiteralPath $Lib).Path
$CoreRoot = (Resolve-Path -LiteralPath $CoreRoot).Path
if (-not (Test-Path -LiteralPath (Join-Path $CoreRoot 'deps/The-Spiral-Language/VS Code Plugin/core'))) { throw "-CoreRoot needs deps/The-Spiral-Language/VS Code Plugin/core under it: |core- resolves against the working directory (got $CoreRoot)" }
if (-not (Test-Path -LiteralPath (Join-Path $Lib 'package.spiproj'))) { throw "no package.spiproj in -Lib $Lib" }
if (-not $CopyRoot) {
    $key = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($Lib.ToLowerInvariant()))).Substring(0, 12)
    $CopyRoot = Join-Path $env:LOCALAPPDATA "spiral-bin/scratch/type-probe-$key"
}
if (-not [IO.Path]::IsPathFullyQualified($CopyRoot)) { throw "-CopyRoot must be a full path, got '$CopyRoot': robocopy /MIR prunes its target" }
$scratchRoots = @((Join-Path $env:LOCALAPPDATA 'spiral-bin/scratch'), (Join-Path ([IO.Path]::GetTempPath()) 'claude')) | ForEach-Object { [IO.Path]::GetFullPath($_).TrimEnd('\', '/') + [IO.Path]::DirectorySeparatorChar }
$copyRootFull = [IO.Path]::GetFullPath($CopyRoot).TrimEnd('\', '/') + [IO.Path]::DirectorySeparatorChar
if (-not ($scratchRoots | Where-Object { $copyRootFull.StartsWith($_, [StringComparison]::OrdinalIgnoreCase) -and $copyRootFull.Length -gt $_.Length })) { throw "-CopyRoot must sit under a scratch root ($($scratchRoots -join ', ')), got '$CopyRoot': robocopy /MIR prunes its target" }
$copy = Join-Path $CopyRoot 'lib/spiral'
if ([IO.Path]::GetFullPath($copy).TrimEnd('\', '/') -eq $Lib.TrimEnd('\', '/')) { throw 'the copy must not be the lib itself: the probe edits package.spiproj' }
robocopy $Lib $copy /MIR /XD target _build .cache node_modules build /XF *.fsx /NFL /NDL /NJH /NJS /NP | Out-Null
if ($LASTEXITCODE -ge 8) { throw "robocopy of $Lib failed with $LASTEXITCODE" }

$proj = Join-Path $copy 'package.spiproj'
$projText = [IO.File]::ReadAllText($proj).TrimEnd("`n")
function Get-ProbeName([string] $relative) { 'type_probe_' + ($relative -replace '\.spi$', '' -replace '[\\/]', '_' -replace "'", '_q') }
function Get-ModuleOpen([string] $relative) {
    $leaf = [IO.Path]::GetFileNameWithoutExtension($relative)
    if ($projText -match "(?m)^\s*$([regex]::Escape($leaf))-\s*$") { return $null }
    ':< ' + ($relative -replace '\.spi$', '' -replace '[\\/]', '.')
}

$results = foreach ($relative in $File) {
    $relative = $relative -replace '\\', '/'
    $source = Join-Path $copy $relative
    if (-not (Test-Path -LiteralPath $source)) { [pscustomobject]@{ File = $relative; Verdict = 'VOID'; Detail = "no $relative under -Lib: nothing to type"; Errors = @() }; continue }
    $lines = [IO.File]::ReadAllLines($source)
    Push-Location $CoreRoot
    try { $blocks = @(& $Dotnet $Compiler --test-blocks $source - 2>$null | Where-Object { $_ -match "`t" }) } finally { Pop-Location }
    $probeName = Get-ProbeName $relative
    $out = [Collections.Generic.List[string]]::new()
    $origin = [Collections.Generic.List[object]]::new()
    function Add-Line([string] $text, $from) { $out.Add($text); $origin.Add($from) }
    foreach ($open in @($lines | Where-Object { $_ -match '^:< ' })) { Add-Line $open $null }
    Add-Line ':< testing' $null
    Add-Line '' $null
    $typed = 0; $lifted = @(); $skipped = @()
    $definitions = @(for ($i = 0; $i -lt $lines.Count; $i++) { if ($lines[$i] -match '^:(?:=|==|!|\||~)\s+(?:\^\s+)?([A-Za-z_][\w'']*)') { [pscustomobject]@{ Name = $Matches[1]; Line = $i + 1 } } })
    function Get-Shadowed($block) {
        $words = @(foreach ($i in $block.Range) { [regex]::Matches($lines[$i], "[A-Za-z_][\w']*") | ForEach-Object Value }) | Sort-Object -Unique
        @($words | Where-Object { $w = $_; @($definitions | Where-Object { $_.Name -eq $w -and $_.Line -lt $block.Header }).Count -and @($definitions | Where-Object { $_.Name -eq $w -and $_.Line -gt $block.Header }).Count })
    }
    $parsed = foreach ($row in $blocks) {
        $name, $headerLine, $first, $last, $header = $row -split "`t"
        $directives = @(for ($i = [int]$headerLine - 2; $i -ge 0 -and $lines[$i] -match '^///[>-]'; $i--) { $lines[$i] })
        [pscustomobject]@{ Name = $name; Header = [int]$headerLine; Range = ([int]$first - 1)..([int]$last - 1); Static = $header -match '\sstatic\s*=\s*$'; NoTarget = [bool]($directives -match '^///>\s*_\s*$') }
    }
    foreach ($block in @($parsed | Where-Object Static)) {
        $lifted += "$($block.Name) ($($block.Range.Count) lines)"
        foreach ($i in $block.Range) { Add-Line ($lines[$i] -replace '^    ', '') @{ Line = $i + 1; Test = $block.Name; Static = $true } }
        Add-Line '' $null
    }
    $moduleOpen = Get-ModuleOpen $relative
    if ($moduleOpen) { Add-Line $moduleOpen $null; Add-Line '' $null }
    $shadowed = @{}
    foreach ($block in @($parsed | Where-Object { -not $_.Static })) {
        if ($block.NoTarget) { $skipped += $block.Name; continue }
        $typed++
        $names = @(Get-Shadowed $block)
        if ($names) { $shadowed[$block.Name] = $names }
        Add-Line ":= test_probe_$($block.Name) () =" @{ Line = $block.Header; Test = $block.Name; Static = $false }
        foreach ($i in $block.Range) { Add-Line $lines[$i] @{ Line = $i + 1; Test = $block.Name; Static = $false } }
        Add-Line '' $null
    }
    $controlLine = $out.Count + 1
    Add-Line ':= type_probe_control_must_fail () : i32 =' $null
    Add-Line '    "the probe typed nothing if this line passes"' $null
    Add-Line '' $null
    Add-Line ':= main () : i32 = 0i32' $null
    $probe = Join-Path $copy "$probeName.spi"
    [IO.File]::WriteAllText($probe, ($out -join "`n") + "`n")
    [IO.File]::WriteAllText($proj, $projText + "`n    $probeName`n")
    Push-Location $CoreRoot
    try { $text = @(& $Dotnet $Compiler fsharp $probe --timeout ($TimeoutSeconds * 1000) 2>&1 | ForEach-Object { "$_" }) } finally { Pop-Location }
    if ($RawOut) { [IO.File]::WriteAllLines("$RawOut.$probeName.txt", $text) }
    $errors = [Collections.Generic.List[object]]::new()
    $current = $null
    foreach ($line in $text) {
        if ($line -match '^(?<path>.+?\.spi):(?<l>\d+):(?<c>\d+): (?<code>E[A-Z]+-\S+): (?<msg>.*)$') {
            $current = [pscustomobject]@{ Path = $Matches.path -replace '\\', '/'; Line = [int]$Matches.l; Col = [int]$Matches.c; Code = $Matches.code; Message = $Matches.msg; Definition = '' }
            $errors.Add($current)
        } elseif ($current -and $line -match 'In the definition: (?<d>[^.]+)\.') { $current.Definition = $Matches.d; $current.Message += ' ' + ($line -replace '\s*In the definition: [^.]+\.\s*$', '').Trim() }
        elseif ($current -and $line.Trim()) { $current.Message += ' ' + $line.Trim() }
    }
    $probePath = $probe -replace '\\', '/'
    $control = @($errors | Where-Object { $_.Path -eq $probePath -and $_.Line -ge $controlLine })
    $real = @($errors | Where-Object { -not ($_.Path -eq $probePath -and $_.Line -ge $controlLine) } | ForEach-Object {
            if ($_.Path -eq $probePath -and $origin[$_.Line - 1]) {
                $from = $origin[$_.Line - 1]
                $kind = if ($from.Static) { 'static' } elseif ($shadowed.ContainsKey($from.Test)) { 'shadowed' } else { 'test' }
                [pscustomobject]@{ Where = "${relative}:$($from.Line):$($_.Col)"; Kind = "$kind $($from.Test)"; Code = $_.Code; Message = $_.Message }
            } else {
                $path = $_.Path -replace [regex]::Escape(($copy -replace '\\', '/') + '/'), ''
                [pscustomobject]@{ Where = "${path}:$($_.Line):$($_.Col)"; Kind = $(if ($_.Path -eq $probePath) { 'probe' } else { 'module' }); Code = $_.Code; Message = $_.Message }
            } })
    $staticErrors = @($real | Where-Object { $_.Kind -like 'static *' }).Count
    $counted = @($real | Where-Object { $_.Kind -notlike 'shadowed *' })
    $verdict = if (-not $control) { 'VOID' } elseif ($counted) { 'FAIL' } else { 'PASS' }
    $detail = if (-not $control) { "control error missing (exit $LASTEXITCODE): the probe did not type its definitions; first output line: $($text | Select-Object -First 1)" } else { '' }
    $shadowText = @($shadowed.Keys | Sort-Object | ForEach-Object { "$_ ($($shadowed[$_] -join ','); $(@($real | Where-Object Kind -eq "shadowed $_").Count) errors)" })
    [pscustomobject]@{ File = $relative; Verdict = $verdict; Typed = $typed; Lifted = $lifted; Skipped = $skipped; StaticErrors = $staticErrors; Errors = $counted; Shadowed = $shadowText; Detail = $detail }
}
foreach ($r in $results) {
    $liftedText = if ($r.Lifted) { "static lifted: $($r.Lifted -join ', ') with $($r.StaticErrors) errors" } else { 'static lifted: none' }
    $skippedText = if ($r.Skipped) { "; skipped ///> _: $($r.Skipped -join ', ')" } else { '' }
    "type-probe $($r.File): $($r.Verdict); tests typed $($r.Typed)$skippedText; $liftedText; errors $(@($r.Errors).Count) (test $(@($r.Errors | Where-Object { $_.Kind -like 'test *' }).Count), module $(@($r.Errors | Where-Object { $_.Kind -eq 'module' }).Count)); control $(if ($r.Verdict -eq 'VOID') { 'MISSING' } else { 'ok' })"
    if ($r.Detail) { "  $($r.Detail)" }
    if ($r.Shadowed) { "  shadowed (a name the module defines again below the test; the probe sees the later one, so leave these to the Cells gate): $($r.Shadowed -join '; ')" }
    $r.Errors | Select-Object -First $Show | ForEach-Object { "  $($_.Where) [$($_.Kind)] $($_.Code): $($_.Message)" }
}
$void = @($results | Where-Object Verdict -eq 'VOID').Count
$fail = @($results | Where-Object Verdict -eq 'FAIL').Count
"type-probe summary: modules $(@($results).Count), pass $(@($results | Where-Object Verdict -eq 'PASS').Count), fail $fail, void $void"
exit $(if ($void) { 2 } elseif ($fail) { 1 } else { 0 })
