param([switch]$IgnoreHeaders)
. $PSScriptRoot/env.ps1
$dir = Join-Path ([IO.Path]::GetTempPath()) "spiral-projection-$PID"
try {
    foreach ($mode in 'single-flight', 'hopac') {
        $file = Get-SpiralCoreProjection $mode (Join-Path $dir "$mode.fs")
        $text = [IO.File]::ReadAllText($file)
        if ($IgnoreHeaders) { $text = [regex]::Replace($text, '(?m)^/// ## [^\n]*\n', '') }
        $hash = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($text))).ToLowerInvariant()
        '{0,-14} {1}  ({2:N0} lines)' -f $mode, $hash.Substring(0, 16), ($text.Split("`n").Count)
    }
}
finally { Remove-Item -Recurse -Force $dir -ErrorAction SilentlyContinue }
