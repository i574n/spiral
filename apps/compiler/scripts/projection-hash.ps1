param([switch]$IgnoreHeaders, [switch]$Seams, [string]$Base = 'HEAD', [string]$BaseFile)
. $PSScriptRoot/env.ps1
$dir = Join-Path ([IO.Path]::GetTempPath()) "spiral-projection-$PID"
try {
    foreach ($mode in 'single-flight', 'gpt5parallel', 'hopacsota') {
        $file = Get-SpiralCoreProjection $mode (Join-Path $dir "$mode.fs")
        $text = [IO.File]::ReadAllText($file)
        if ($IgnoreHeaders) { $text = [regex]::Replace($text, '(?m)^/// ## [^\n]*\n', '') }
        $hash = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($text))).ToLowerInvariant()
        '{0,-14} {1}  ({2:N0} lines)' -f $mode, $hash.Substring(0, 16), ($text.Split("`n").Count)
    }
    if ($Seams) {
        $source = Get-SpiralCoreSource 'single-flight'
        $root = git -C (Split-Path $source) rev-parse --show-toplevel
        $relative = git -C $root ls-files --full-name -- $source
        $baseSource = Join-Path $dir 'base-source.fs'
        if ($BaseFile) { Copy-Item -LiteralPath $BaseFile $baseSource; $Base = $BaseFile }
        else { [IO.File]::WriteAllText($baseSource, ((git -C $root show "${Base}:$relative") -join "`n")) }
        $before = Get-SpiralCoreProjection 'single-flight' (Join-Path $dir 'base-single-flight.fs') $baseSource
        $after = Join-Path $dir 'single-flight.fs'
        foreach ($projection in $before, $after) { [IO.File]::WriteAllText($projection, [regex]::Replace([IO.File]::ReadAllText($projection), '(?ms)^    /// ## PartEvalSeams\n.*?(?=^    /// ## )', '')) }
        $added = @(git diff --no-index -w -U0 -- $before $after | Where-Object { $_ -match '^\+(?!\+\+ )' } | ForEach-Object { $_.Substring(1) } | Where-Object { $_.Trim() -and -not $_.Trim().StartsWith('//') })
        $foreign = @($added | Where-Object { -not $_.Contains('PartEvalSeams.') -and $_.Trim() -notmatch '^\)+$' })
        "single-flight projection vs ${Base}: $($added.Count) added code lines, $($foreign.Count) that are not PartEvalSeams calls"
        foreach ($line in $foreign | Select-Object -First 20) { "  " + $line.Trim().Substring(0, [Math]::Min(140, $line.Trim().Length)) }
        if ($foreign.Count) { exit 1 }
    }
}
finally { Remove-Item -Recurse -Force $dir -ErrorAction SilentlyContinue }
