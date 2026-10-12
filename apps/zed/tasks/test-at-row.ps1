param([Parameter(Mandatory)] [string] $File, [int] $Row = 0, [switch] $DryRun)
$ErrorActionPreference = 'Stop'
$lines = [IO.File]::ReadAllLines($File)
$runner = Join-Path $PSScriptRoot '../../kino/spi/run_notebook.ps1'
$output = Join-Path ([IO.Path]::GetTempPath()) ("spiral-zed-" + [IO.Path]::GetFileNameWithoutExtension($File) + ".ipynb")
$selected = @()
if ($Row -gt 0) {
    for ($i = [Math]::Min($Row, $lines.Count) - 1; $i -ge 0; $i--) {
        if ($lines[$i] -match '^test ([^\s=]+)') { $selected = @('--test', $Matches[1]); break }
        if ($lines[$i] -match '^\S' -and $lines[$i] -notmatch '^///') { break }
    }
    if (-not $selected) { Write-Host "no test block encloses row $Row of $File; running every test in the file" }
}
if ($DryRun) { "run_notebook --path $File --output-path $output $($selected -join ' ')"; exit 0 }
& pwsh -NoProfile -File $runner --path $File --output-path $output @selected
exit $LASTEXITCODE
