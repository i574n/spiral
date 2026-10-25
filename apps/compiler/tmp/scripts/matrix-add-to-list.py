import sys
from pathlib import Path

target = Path(__file__).resolve().parents[1] / "tests" / "matrix.psd1"
arguments = [argument for argument in sys.argv[1:] if argument != "--apply"]
if len(arguments) < 2:
    print("usage: add-to-list.py <List> <sample> ... [--apply]")
    sys.exit(2)
list_name, samples = arguments[0], [name if name.startswith("samples/") else f"samples/{name}" for name in arguments[1:]]
anchor = f"\n    {list_name} = @(\n"
text = target.read_text(encoding="utf-8")
if text.count(anchor) != 1:
    print(f"{list_name} list anchor matches {text.count(anchor)} times, expected 1")
    sys.exit(1)
start = text.index(anchor) + len(anchor)
end = text.index("\n    )", start)
listed = {line.strip().strip("'") for line in text[start:end].splitlines()}
missing = [name for name in samples if name not in listed]
absent = [name for name in missing if not (target.parents[1] / name / "main.spi").exists()]
if absent:
    print(f"no such sample: {' '.join(absent)}")
    sys.exit(1)
if not missing:
    print(f"{list_name}: already listed")
    sys.exit(0)
if "--apply" not in sys.argv:
    print(f"{list_name}: {len(missing)} samples to add (dry run, pass --apply to write)")
    sys.exit(0)
target.write_bytes((text[:end] + "".join(f"\n        '{name}'" for name in missing) + text[end:]).encode("utf-8"))
print(f"{list_name}: added {len(missing)} samples")
