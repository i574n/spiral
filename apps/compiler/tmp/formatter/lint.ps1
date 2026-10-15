param([string] $Root = $PSScriptRoot)
$ErrorActionPreference = 'Stop'
$banned = [ordered]@{
    'regex over source text' = 'Regex|RegularExpressions'
    'second tokenizer or parser' = 'FParsec|many1Satisfy|tokenize_line\s*\('
    'clock or environment in a decision' = 'DateTime\.|Stopwatch|Environment\.(GetEnvironmentVariable|TickCount)'
    'unordered iteration' = '\bDictionary<|\bHashSet<'
}
$allowed = @{
    'second tokenizer or parser' = @('Lexed.fsx')
    'unordered iteration' = @('Format.fsx')
}
$hits = 0
foreach ($file in Get-ChildItem $Root -Filter '*.fsx' -File) {
    $lines = [IO.File]::ReadAllLines($file.FullName)
    foreach ($rule in $banned.Keys) {
        if ($allowed[$rule] -contains $file.Name) { continue }
        for ($i = 0; $i -lt $lines.Length; $i++) {
            if ($lines[$i] -match $banned[$rule]) { "{0}:{1}  {2}  {3}" -f $file.Name, ($i + 1), $rule, $lines[$i].Trim(); $hits++ }
        }
    }
}
"G6 hits: $hits"
exit ([int]($hits -gt 0))
