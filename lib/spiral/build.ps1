param(
    $fast,
    $sequential,
    $ScriptDir = $PSScriptRoot
)
Set-Location $ScriptDir
$ErrorActionPreference = "Stop"
. ../../deps/polyglot/scripts/core.ps1


$spiralPath = "../../../spiral/workspace/target/release/spiral$(_exe)"

if (!$fast) {
    {
        . ../../apps/spiral/dist/Supervisor$(_exe) `
            --exit-on-error `
            $(!$sequential ? @("--parallel") : @()) `
            --execute-command "$spiralPath dib --path $ScriptDir/physics.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/parsing.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/sm'.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/rust/rust.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/rust/testing.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/rust/near.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/rust/near_workspaces.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/testing.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/guid.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/async.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/runtime.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/trace.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/am'.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/crypto.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/common.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/resultm.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/console.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/base.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/date_time.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/math.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/mapm.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/optionm'.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/listm'.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/reflection.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/iter.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/wasm.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/leptos/leptos.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/lustre.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/util.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/platform.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/stream.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/threading.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/benchmark.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/seq.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/env.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/python.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/typescript.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/file_system.dib --retries 3" `
            --execute-command "$spiralPath dib --path $ScriptDir/networking.dib --retries 3" `
    } | Invoke-Block -Location (GetFullPath "../../deps/polyglot/lib/fsharp")
}

{ . $spiralPath dib-export testing.dib spi async.dib spi runtime.dib spi trace.dib spi threading.dib spi networking.dib spi crypto.dib spi common.dib spi base.dib spi resultm.dib spi iter.dib spi env.dib spi parsing.dib spi console.dib spi date_time.dib spi file_system.dib spi guid.dib spi math.dib spi mapm.dib spi "optionm'.dib" spi "am'.dib" spi "sm'.dib" spi "sm'.dib" spir "listm'.dib" spi reflection.dib spi python.dib spi typescript.dib spi benchmark.dib spi stream.dib spi seq.dib spi util.dib spi platform.dib spi rust/rust.dib spi rust/testing.dib spi rust/near.dib spi rust/near_workspaces.dib spi physics.dib spi leptos/leptos.dib spi lustre.dib spi wasm.dib spi } | Invoke-Block

if (!$fast) {
    { pwsh near/wallet/build.ps1 } | Invoke-Block
}

if ($env:CI) {
    Remove-Item ../../deps/polyglot/target/spiral/spiral/target -Recurse -Force -ErrorAction Ignore
}
