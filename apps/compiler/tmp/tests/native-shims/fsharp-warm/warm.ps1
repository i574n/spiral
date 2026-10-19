param(
    [Parameter(Mandatory)] [string] $Dotnet,
    [Parameter(Mandatory)] [string[]] $Scripts,
    [int] $TimeoutSec = 60,
    [Parameter(Mandatory)] [string] $Work
)
$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force $Work | Out-Null
$endMarker = 'SPIRAL_WARM_END'
$doneMarker = 'SPIRAL_WARM_DONE'

function Start-Session {
    $psi = [Diagnostics.ProcessStartInfo]::new($Dotnet, 'fsi --quiet')
    $psi.RedirectStandardInput = $true
    $psi.RedirectStandardOutput = $true
    $psi.RedirectStandardError = $true
    $psi.UseShellExecute = $false
    $session = [Diagnostics.Process]::Start($psi)
    [pscustomobject]@{ Process = $session; Pending = $null; ErrPending = $null }
}

function Read-SessionLine($state, [datetime] $deadline) {
    if (-not $state.Pending) { $state.Pending = $state.Process.StandardOutput.ReadLineAsync() }
    $left = [Math]::Max(0, [int]($deadline - (Get-Date)).TotalMilliseconds)
    if (-not $state.Pending.Wait($left)) { return [pscustomobject]@{ Kind = 'timeout' } }
    $line = $state.Pending.Result
    $state.Pending = $null
    if ($null -eq $line) { return [pscustomobject]@{ Kind = 'eof' } }
    [pscustomobject]@{ Kind = 'line'; Text = $line }
}

function Get-Errors($state, [int] $settleMs) {
    $lines = [Collections.Generic.List[string]]::new()
    while ($true) {
        if (-not $state.ErrPending) { $state.ErrPending = $state.Process.StandardError.ReadLineAsync() }
        if (-not $state.ErrPending.Wait($settleMs)) { break }
        $line = $state.ErrPending.Result
        $state.ErrPending = $null
        if ($null -eq $line) { break }
        $lines.Add($line)
    }
    $lines -join "`n"
}

$state = Start-Session
$index = 0
foreach ($script in $Scripts) {
    $index++
    $copy = Join-Path $Work ("row{0:D5}.fsx" -f $index)
    [IO.File]::WriteAllText($copy, [IO.File]::ReadAllText($script).TrimEnd() + "`n|> fun x -> printfn `"%s`" (`"`\n$endMarker `" + string (match box x with :? int32 as code -> code | _ -> 0))`n")
    $null = Get-Errors $state 0
    $watch = [Diagnostics.Stopwatch]::StartNew()
    $state.Process.StandardInput.WriteLine("#load @`"$copy`";;")
    $state.Process.StandardInput.WriteLine("printfn `"$doneMarker`";;")
    $state.Process.StandardInput.Flush()
    $deadline = (Get-Date).AddSeconds($TimeoutSec)
    $stdout = [Text.StringBuilder]::new()
    $exit = $null
    $status = $null
    while (-not $status) {
        $read = Read-SessionLine $state $deadline
        switch ($read.Kind) {
            'timeout' { $status = 'timeout' }
            'eof' { $state.Process.WaitForExit(5000) | Out-Null; $exit = $state.Process.ExitCode; $status = 'exited' }
            'line' {
                if ($read.Text -eq $doneMarker) { $status = 'done' }
                elseif ($read.Text.StartsWith("$endMarker ")) { $exit = [int]$read.Text.Substring($endMarker.Length + 1) }
                else { [void]$stdout.AppendLine($read.Text) }
            }
        }
    }
    if ($status -eq 'done' -and $null -eq $exit) { $exit = 1 }
    $errors = Get-Errors $state 100
    $fsiError = [regex]::Match("$errors`n$($stdout.ToString())", 'error FS\d+:[^\r\n]{0,240}')
    $output = ($stdout.ToString() -replace "`r`n", "`n").TrimEnd()
    [pscustomobject]@{
        Script = $script
        Status = if ($status -eq 'timeout') { 'timeout' } elseif ($fsiError.Success) { 'build-fail' } else { 'ran' }
        Exit = if ($status -eq 'timeout') { 'timeout' } elseif ($fsiError.Success) { '' } else { [string]$exit }
        Stdout = if ($fsiError.Success) { '' } else { $output }
        Detail = if ($fsiError.Success) { $fsiError.Value } else { '' }
        Ms = [int]$watch.Elapsed.TotalMilliseconds
    }
    if ($status -in 'timeout', 'exited') {
        try { if (-not $state.Process.HasExited) { $state.Process.Kill($true) } } catch { }
        $state = Start-Session
    }
}
try { $state.Process.StandardInput.WriteLine('#quit;;'); $state.Process.StandardInput.Close(); $state.Process.WaitForExit(5000) | Out-Null } catch { }
Remove-Item -LiteralPath $Work -Recurse -Force -ErrorAction Ignore
