# Dot-source from the EOIE compiler contracts. Loads the Spiral compiler's shared script environment
# (scripts/env.ps1: Resolve-SpiralDotnet, Get-SpiralCompilerDll, Get-SpiralCacheDir, $BundleRoot).
# The compiler lives at apps/compiler/tmp; EOIE_SPIRAL_BUNDLE points elsewhere when set.
$compilerRoot = if ($env:EOIE_SPIRAL_BUNDLE) { $env:EOIE_SPIRAL_BUNDLE } else { Join-Path $PSScriptRoot '../../compiler/tmp' }
$compilerRoot = (Resolve-Path -LiteralPath $compilerRoot).Path
. (Join-Path $compilerRoot 'scripts/env.ps1')
