import re
import sys
from pathlib import Path

paren_join_line = re.compile(r"^\s*\(join\b.*\)\s*$")
bare_open = re.compile(r"^\s*\($")
join_head = re.compile(r"^\s*join\b")
leading_then = re.compile(r"^\s*then\b")
trailing_then = re.compile(r"\bthen\s*$")


def code_lines(text):
    inside_macro = False
    for number, line in enumerate(text.replace("\r\n", "\n").split("\n"), 1):
        stripped = line.strip()
        quotes = line.count("'") if "$'" in line or inside_macro else 0
        if not inside_macro and stripped and not stripped.startswith("//"):
            yield number, line
        if quotes % 2:
            inside_macro = not inside_macro


def probe(path):
    lines = list(code_lines(path.read_text(encoding="utf-8", errors="replace")))
    parens = [(n, l) for n, l in lines if paren_join_line.match(l)]
    parens += [(n, l) for (n, l), (_, following) in zip(lines, lines[1:]) if bare_open.match(l) and join_head.match(following)]
    off_grid = [(n, l) for n, l in lines if (len(l) - len(l.lstrip(" "))) % 4]
    leads = sum(1 for _, l in lines if leading_then.match(l))
    trails = sum(1 for _, l in lines if trailing_then.search(l) and not l.lstrip().startswith("|"))
    return parens, off_grid, leads, trails


failed = False
for name in sys.argv[1:]:
    path = Path(name)
    parens, off_grid, leads, trails = probe(path)
    print(f"{path.name}: (join heads {len(parens)}, off-grid lines {len(off_grid)}, then leading {leads} trailing {trails}")
    for number, line in (parens + off_grid)[:12]:
        print(f"    {number}: {line.rstrip()[:110]}")
    failed = failed or bool(parens or off_grid)
sys.exit(1 if failed else 0)
