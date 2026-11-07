param([string] $Source = (Join-Path $PSScriptRoot '..\..\spiral_compiler.fs'))
$ErrorActionPreference = 'Stop'
$banned = [ordered]@{
    'regex over source text' = 'Regex|RegularExpressions'
    'second tokenizer or parser' = 'FParsec|many1Satisfy|tokenize_line\s*\('
    'clock or environment in a decision' = 'DateTime\.|Stopwatch|Environment\.(GetEnvironmentVariable|TickCount)'
    'unordered iteration' = '\bDictionary<|\bHashSet<'
}
$allowed = @{
    'second tokenizer or parser' = @('FormatterLexed')
    'unordered iteration' = @('FormatterFormat')
}
$lines = [IO.File]::ReadAllText((Resolve-Path $Source)).Split("`n")
$start = [Array]::IndexOf($lines, '    /// ## Formatter')
if ($start -lt 0) { throw "no formatter section in $Source" }
$hits = 0
$module = ''
for ($i = $start + 1; $i -lt $lines.Length; $i++) {
    $line = $lines[$i]
    if ($line.StartsWith('#if ') -or $line.StartsWith('    /// ## ')) { break }
    if ($line -match '^    module (Formatter\w+) =') { $module = $Matches[1]; continue }
    foreach ($rule in $banned.Keys) {
        if ($allowed[$rule] -contains $module) { continue }
        if ($line -match $banned[$rule]) { "{0}:{1}  {2}  {3}" -f $module, ($i + 1), $rule, $line.Trim(); $hits++ }
    }
}
"G6 hits: $hits"
exit ([int]($hits -gt 0))
