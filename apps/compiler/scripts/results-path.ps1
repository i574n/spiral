function Resolve-Results([string] $run) {
    if (Test-Path $run -PathType Leaf) { return $run }
    if (Test-Path $run -PathType Container) {
        $direct = Join-Path $run 'results.tsv'
        if (Test-Path $direct) { return $direct }
        $nested = Get-ChildItem $run -Recurse -Filter results.tsv | Where-Object { $_.Directory.Name -like 'single-flight-*' } | Select-Object -First 1
        if ($nested) { return $nested.FullName }
    }
    Join-Path $env:LOCALAPPDATA "spiral-bin\runs\$run\results.tsv"
}
