import sys
from collections import Counter
from pathlib import Path

source_root, output_root = Path(sys.argv[1]), Path(sys.argv[2])
kinds = Counter()
examples = {}
checked = 0
for source in sorted(source_root.rglob("*.spi")):
    output = output_root / source.relative_to(source_root)
    if not output.exists():
        continue
    authored = source.read_text(encoding="utf-8", errors="replace").replace("\r\n", "\n").split("\n")
    laid = set(line.strip() for line in output.read_text(encoding="utf-8", errors="replace").replace("\r\n", "\n").split("\n"))
    for number, line in enumerate(authored, 1):
        text = line.strip()
        if not text or len(line) > 120 or text.startswith("//"):
            continue
        checked += 1
        if text in laid:
            continue
        if text.startswith("(") or text.endswith(")") or "(join" in text:
            kind = "parentheses changed"
        elif text.startswith("then") or text.endswith("then"):
            kind = "then moved"
        elif text.endswith("\\") or "$'" in text or '$"' in text:
            kind = "macro continuation"
        else:
            kind = "other"
        kinds[kind] += 1
        examples.setdefault(kind, []).append(f"{source.relative_to(source_root)}:{number}: {text[:100]}")
print(f"fitting authored lines checked {checked}, not kept verbatim {sum(kinds.values())}")
for kind, count in kinds.most_common():
    print(f"  {count:5} {kind}")
    for example in examples[kind][:3]:
        print(f"        {example}")
