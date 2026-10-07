param(
  [Parameter(Mandatory = $true)][string]$Dotnet,
  [Parameter(Mandatory = $true)][string]$Dll,
  [Parameter(Mandatory = $true)][string]$Socket,
  [Parameter(Mandatory = $true)][string]$WorkDir,
  [Parameter(Mandatory = $true)][string]$BridgeFile
)

$ErrorActionPreference = "Stop"
$utf8 = New-Object System.Text.UTF8Encoding $false

function Remove-SocketFile([string]$path) {
  foreach ($item in @($path, "$path.pid", "$path.bridge")) {
    if (Test-Path -LiteralPath $item) {
      cmd /c "del /f /q `"$item`"" | Out-Null
    }
  }
}

function Wait-Compiler([System.Diagnostics.Process]$proc, [string]$pidFile) {
  $deadline = (Get-Date).AddSeconds(30)
  while (-not (Test-Path -LiteralPath $pidFile)) {
    if ($proc.HasExited) {
      throw "compiler exited $($proc.ExitCode)"
    }
    if ((Get-Date) -gt $deadline) {
      throw "compiler socket was not ready"
    }
    Start-Sleep -Milliseconds 50
  }
}

function Invoke-Compiler([string]$backend, [string]$source, [string]$target, [string]$socket, [int]$compilerPid) {
  $endpoint = [System.Net.Sockets.UnixDomainSocketEndPoint]::new($socket)
  $unix = [System.Net.Sockets.Socket]::new(
    [System.Net.Sockets.AddressFamily]::Unix,
    [System.Net.Sockets.SocketType]::Stream,
    [System.Net.Sockets.ProtocolType]::Unspecified
  )
  $unix.ReceiveTimeout = 0
  $unix.SendTimeout = 30000
  try {
    $unix.Connect($endpoint)
    $stream = New-Object System.Net.Sockets.NetworkStream($unix, $true)
    $writer = New-Object System.IO.StreamWriter($stream, $utf8, 4096, $true)
    $reader = New-Object System.IO.StreamReader($stream, $utf8, $false, 4096, $true)
    $writer.NewLine = "`n"
    $writer.AutoFlush = $true
    $writer.WriteLine("compile`t$backend`t$source`t$target")
    $response = $reader.ReadLine()
    if ($null -eq $response) {
      return "spiral-session`terror`t$compilerPid`tcompiler closed the socket"
    }
    return $response
  } catch {
    return "spiral-session`terror`t$compilerPid`tbridge $($_.Exception.Message)"
  } finally {
    try { $unix.Dispose() } catch {}
  }
}

Remove-SocketFile $Socket
New-Item -ItemType Directory -Force -Path (Split-Path -Parent $Socket) | Out-Null
# Debug trace of every request/response, opt-in: SPIRAL_KINO_BRIDGE_TRACE=1 writes `<socket>.trace` (started fresh by
# each bridge; the daemon quotes it when the bridge closes). Off by default, so the file never grows unattended.
$trace = if ($env:SPIRAL_KINO_BRIDGE_TRACE -in @('1', 'true')) { "$Socket.trace" } else { $null }
if (Test-Path -LiteralPath "$Socket.trace") { Remove-Item -LiteralPath "$Socket.trace" -Force }
function Note([string]$msg) {
  if ($trace) { Add-Content -LiteralPath $trace -Value "$(Get-Date -Format o) $msg" }
}

$start = New-Object System.Diagnostics.ProcessStartInfo
$start.FileName = $Dotnet
$start.Arguments = "`"$Dll`" --server `"$Socket`" unused"
$start.WorkingDirectory = $WorkDir
$start.UseShellExecute = $false
$start.CreateNoWindow = $true
$start.RedirectStandardOutput = $true
$start.RedirectStandardError = $true
$compiler = [System.Diagnostics.Process]::Start($start)
$outFile = [System.IO.File]::Create("$Socket.out")
$errFile = [System.IO.File]::Create("$Socket.err")
$null = $compiler.StandardOutput.BaseStream.CopyToAsync($outFile)
$null = $compiler.StandardError.BaseStream.CopyToAsync($errFile)
Note "compiler=$($compiler.Id)"

$listener = $null
try {
  Wait-Compiler $compiler "$Socket.pid"
  $listener = [System.Net.Sockets.TcpListener]::new([System.Net.IPAddress]::Loopback, 0)
  $listener.Start()
  $bridgePort = ([System.Net.IPEndPoint]$listener.LocalEndpoint).Port
  [System.IO.File]::WriteAllText($BridgeFile, "$bridgePort", $utf8)
  Note "bridge=$bridgePort"
  [Console]::Error.WriteLine("spiral-kino-bridge port=$bridgePort compiler=$($compiler.Id)")

  # The bridge lives only as long as its daemon (the process that started it) and its compiler: a blocking accept left
  # orphaned bridges, each holding a multi-GB compiler server, after their daemon died (seven on 2026-10-07).
  $parent = (Get-Process -Id $PID).Parent
  :serve while ($true) {
    $client = $null
    while ($null -eq $client) {
      if ($listener.Pending()) { $client = $listener.AcceptTcpClient() }
      elseif ($compiler.HasExited) { Note "compiler exited"; break serve }
      elseif ($null -eq $parent -or $parent.HasExited) { Note "daemon exited"; break serve }
      else { Start-Sleep -Milliseconds 200 }
    }
    $client.NoDelay = $true
    try {
      $net = $client.GetStream()
      $reader = New-Object System.IO.StreamReader($net, $utf8, $false, 8192, $true)
      $writer = New-Object System.IO.StreamWriter($net, $utf8, 8192, $true)
      $writer.NewLine = "`n"
      $writer.AutoFlush = $true
      $line = $reader.ReadLine()
      Note "request=$line"
      if ($null -eq $line) { continue }
      if ($line -eq "quit") {
        $writer.WriteLine("spiral-session`tquit`t$($compiler.Id)")
        break serve
      }
      $parts = $line.Split("`t")
      if ($parts.Length -lt 4 -or $parts[0] -ne "compile") {
        $writer.WriteLine("spiral-session`terror`t$($compiler.Id)`tinvalid bridge request")
      } else {
        $response = Invoke-Compiler $parts[1] $parts[2] $parts[3] $Socket $compiler.Id
        Note "response=$response"
        $writer.WriteLine($response)
      }
    } catch {
      Note "client-error=$($_.Exception.Message)"
    } finally {
      $client.Close()
    }
  }
} finally {
  try { if ($listener) { $listener.Stop() } } catch {}
  try {
    if (-not $compiler.HasExited) {
      taskkill /T /F /PID $compiler.Id | Out-Null
    }
  } catch {}
  Remove-SocketFile $Socket
}
