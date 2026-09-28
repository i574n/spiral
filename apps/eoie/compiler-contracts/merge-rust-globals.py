"""One-shot: merge runs of line-per-call `rust_global "..."` into one `\\n`-joined global per run.

Globals are deduplicated by text, so emitting Rust one line per global drops repeated lines (a second
`) -> Result<..., String> {`, blank lines). One global per block keeps the block intact. The block stays a
single-line literal, like eoie's other Rust blocks: `\"\"\"` strings are tracked by a process-wide tokenizer
flag and break when their content has column-0 lines (the parser splits top-level statements there).

Run from anywhere: python merge-rust-globals.py [--dry-run]
"""
import os
import re
import sys

ROOT = os.path.normpath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", "src"))
DRY = "--dry-run" in sys.argv
LINE = re.compile(r'^([ \t]+)(rust_global(?:_transport)?) "((?:[^"\\]|\\.)*)"[ \t]*$')
ESCAPES = {"n": "\n", "r": "\r", "t": "\t", "b": "\b"}


def unescape(text):
    return re.sub(r"\\(.)", lambda m: ESCAPES.get(m.group(1), m.group(1)), text)


counts = {"files": 0, "runs": 0, "lines": 0}
for directory, dirs, files in os.walk(ROOT):
    dirs[:] = [d for d in dirs if d not in ("target", ".git")]
    for file in files:
        if not file.endswith(".spi"):
            continue
        path = os.path.join(directory, file)
        text = open(path, encoding="utf-8", newline="").read()
        lines = text.split("\n")
        out, i = [], 0
        while i < len(lines):
            # A global that already holds a newline is a whole block; only single-line fragments are merged.
            # Imports and inner attributes stay separate: their deduplication across packages is wanted.
            def fragment(line):
                n = LINE.match(line)
                if not n:
                    return None
                content = unescape(n.group(3))
                if "\n" in content or content.lstrip().startswith(("use ", "pub use ", "#!", "extern crate ")):
                    return None
                return n
            m = fragment(lines[i])
            j = i
            if m:
                while j < len(lines):
                    n = fragment(lines[j])
                    if not n or n.group(1) != m.group(1) or n.group(2) != m.group(2):
                        break
                    j += 1
            if j - i < 2:
                out.append(lines[i])
                i += 1
                continue
            # The fragments are already escaped Spiral string bodies.
            body = "\\n".join(LINE.match(x).group(3) for x in lines[i:j])
            out.append(f'{m.group(1)}{m.group(2)} "{body}"')
            counts["runs"] += 1
            counts["lines"] += j - i
            i = j
        new = "\n".join(out)
        if new != text:
            counts["files"] += 1
            if not DRY:
                open(path, "w", encoding="utf-8", newline="").write(new)

print(("dry run: " if DRY else "") + ", ".join(f"{k} {v}" for k, v in counts.items()))