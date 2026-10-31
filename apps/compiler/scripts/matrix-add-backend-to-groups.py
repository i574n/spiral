import re
import sys
from pathlib import Path

target = Path(__file__).resolve().parents[1] / "tmp" / "tests" / "matrix.psd1"
arguments = [argument for argument in sys.argv[1:] if argument != "--apply"]
if len(arguments) < 3:
    print("usage: add-backend-to-groups.py <Backend> <After> <sample> ... [--apply]")
    sys.exit(2)
backend, after, samples = arguments[0], arguments[1], [name if name.startswith("samples/") else f"samples/{name}" for name in arguments[2:]]
text = target.read_text(encoding="utf-8")
lines = text.split("\n")
start = next(i for i, line in enumerate(lines) if line == "    Backends = @{")
end = next(i for i in range(start + 1, len(lines)) if lines[i] == "    }")
key_pattern = re.compile(r"^        '([^']+)' = @\($")
sample_pattern = re.compile(r"^ {8,}'(samples/[^']+)'$")
groups = {}
order = []
current = None
for i in range(start + 1, end):
    key = key_pattern.match(lines[i])
    if key:
        current = key.group(1)
        groups[current] = []
        order.append(current)
        continue
    sample = sample_pattern.match(lines[i])
    if sample and current is not None:
        groups[current].append(sample.group(1))
moves = []
missing = []
for name in samples:
    owner = next((key for key in order if name in groups[key]), None)
    if owner is None:
        missing.append(name)
        continue
    parts = owner.split(",")
    if backend in parts:
        continue
    position = parts.index(after) + 1 if after in parts else len(parts)
    moves.append((name, owner, ",".join(parts[:position] + [backend] + parts[position:])))
if missing:
    print(f"not in the Backends table (default backends already include it or the name is wrong): {' '.join(missing)}")
    sys.exit(1)
summary = {}
for _, owner, new_key in moves:
    summary[(owner, new_key)] = summary.get((owner, new_key), 0) + 1
for (owner, new_key), count in summary.items():
    print(f"{count:4} {owner} -> {new_key}")
if "--apply" not in sys.argv:
    print(f"{len(moves)} samples to move (dry run, pass --apply to write)")
    sys.exit(0)
for name, owner, new_key in moves:
    groups[owner].remove(name)
    if new_key not in groups:
        groups[new_key] = []
        order.append(new_key)
    groups[new_key].append(name)
block = ["    Backends = @{"]
for key in order:
    if not groups[key]:
        continue
    block.append(f"        '{key}' = @(")
    block.extend(f"            '{name}'" for name in groups[key])
    block.append("        )")
block.append("    }")
original_block = "\n".join(lines[start:end + 1])
rebuilt_check = []
for i in range(start + 1, end):
    line = lines[i]
    if not (key_pattern.match(line) or sample_pattern.match(line) or line == "        )"):
        rebuilt_check.append(line)
if rebuilt_check:
    print(f"refusing: the Backends block has {len(rebuilt_check)} lines this script would drop, e.g. {rebuilt_check[0]!r}")
    sys.exit(1)
target.write_bytes(("\n".join(lines[:start] + block + lines[end + 1:])).encode("utf-8"))
print(f"moved {len(moves)} samples")
