"""Sync apps/compiler/spiral_compiler.fs with the fork of The Spiral Language (upstream's file layout).

    python upstream.py status <fork> [ref]                  per section: lines that differ from the fork's file
    python upstream.py import <fork> <old-ref> <new-ref>     carry the fork's edits old->new into the sections
    python upstream.py export <fork> <base-ref> <out-dir>    write the fork's files with the sections' edits

<fork> is a clone of the fork (polyglot/deps/The-Spiral-Language); refs are git refs in it. A section
`/// ## Name` maps to `The Spiral Language 2/Name.fs` (`SignalRSupervisor` to `Supervisor.fs`); sections
without a file are i574n additions and are skipped. Only single-flight's text is read or written: shared
sections, and the `#else` side of `#if SPIRAL_CORE_HOPAC` pairs (a pair's hopac side is reported, not
touched).

Edits are carried as normalized-line patches, like a 3-way merge: lines are compared stripped, ignoring
blank lines, the compaction's `/// ###` headings and `#!import` lines and the files' `module` headers, so
the section's indentation and headings survive. An edit whose lines the target changed on its own is a
conflict: reported, not applied.
"""
import difflib
import os
import re
import subprocess
import sys

CORE = os.path.normpath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", "..", "spiral_compiler.fs"))
DIRECTORY = "The Spiral Language 2"
FILE_OF = {"SignalRSupervisor": "Supervisor.fs"}
HEADER = re.compile(r"^\s*/// ## (.+?)\s*$")
INDENT = "    "


def skipped(line):
    s = line.strip().lstrip("\ufeff")
    return (not s or s.startswith(("/// ### ", "/// ## ", "// #!import"))
            or (line.lstrip("\ufeff").startswith("module ") and not s.endswith("=")))


def normalized(lines):
    return [(line.strip(), index) for index, line in enumerate(lines) if not skipped(line)]


def git(fork, *args):
    result = subprocess.run(["git", "-C", fork, *args], capture_output=True)
    return result.stdout.decode("utf-8", "replace") if result.returncode == 0 else None


def fork_text(fork, ref, name):
    return git(fork, "show", f"{ref}:{DIRECTORY}/{FILE_OF.get(name, name + '.fs')}")


def fork_file(fork, ref, name):
    text = fork_text(fork, ref, name)
    return None if text is None else text.replace("\r\n", "\n").split("\n")


def sections(lines):
    """name -> (start, end) of single-flight's text in the merged file (header line included)."""
    result, state, start, name = {}, None, None, None
    def close(end):
        if name is not None and start is not None:
            result[name] = (start, end)
    for index, line in enumerate(lines):
        if line == "#if SPIRAL_CORE_HOPAC":
            close(index); name = start = None; state = "hopac"; continue
        if state and line == "#else":
            state = "single"; continue
        if state and line == "#endif":
            close(index); name = start = None; state = None; continue
        if state == "hopac":
            continue
        match = HEADER.match(line)
        if match:
            close(index)
            name, start = match.group(1), index
    close(len(lines))
    return result


def transfer(old, new, target, reindent):
    """Apply the edit old->new to target (which equals old up to formatting). Returns (lines, conflicts)."""
    o, n, t = normalized(old), normalized(new), normalized(target)
    to_target = {}
    for block in difflib.SequenceMatcher(None, [k for k, _ in o], [k for k, _ in t], autojunk=False).get_matching_blocks():
        for offset in range(block.size):
            to_target[block.a + offset] = block.b + offset
    edits, conflicts = [], []
    for tag, i1, i2, j1, j2 in difflib.SequenceMatcher(None, [k for k, _ in o], [k for k, _ in n], autojunk=False).get_opcodes():
        if tag == "equal":
            continue
        replacement = [reindent(line) for line in new[n[j1][1]:n[j2 - 1][1] + 1]] if j2 > j1 else []
        replacement = [line for line in replacement if not line.strip().startswith(("/// ### ", "/// ## ", "// #!import"))]
        if i2 > i1:
            mapped = [to_target.get(i) for i in range(i1, i2)]
            if None in mapped or mapped != list(range(mapped[0], mapped[0] + len(mapped))):
                conflicts.append(f"lines changed on both sides near: {o[i1][0][:80]}")
                continue
            edits.append((t[mapped[0]][1], t[mapped[-1]][1] + 1, replacement))
        else:
            if i1 > 0 and (i1 - 1) in to_target:
                at = t[to_target[i1 - 1]][1] + 1
            elif i1 < len(o) and i1 in to_target:
                at = t[to_target[i1]][1]
            elif not o:
                at = len(target)
            else:
                conflicts.append(f"insertion point changed on both sides near: {n[j1][0][:80]}")
                continue
            edits.append((at, at, replacement))
    result = list(target)
    for start, end, replacement in sorted(edits, key=lambda edit: edit[0], reverse=True):
        result[start:end] = replacement
    return result, conflicts


def indent(line):
    return INDENT + line if line.strip() else line


def dedent(line):
    return line[len(INDENT):] if line.startswith(INDENT) else line.lstrip() if not line.strip() else line


def load_core():
    with open(CORE, encoding="utf-8", newline="") as file:
        text = file.read()
    return text.split("\n")


def status(fork, ref):
    lines = load_core()
    total = 0
    for name, (start, end) in sections(lines).items():
        upstream = fork_file(fork, ref, name)
        if upstream is None:
            continue
        a, b = [k for k, _ in normalized(lines[start:end])], [k for k, _ in normalized(upstream)]
        same = sum(block.size for block in difflib.SequenceMatcher(None, a, b, autojunk=False).get_matching_blocks())
        total += len(a) - same + len(b) - same
        print(f"{name:26} section-only {len(a) - same:5}  fork-only {len(b) - same:5}")
    print(f"total differing lines: {total}")


def import_(fork, old_ref, new_ref):
    lines = load_core()
    changed = git(fork, "diff", "--name-only", old_ref, new_ref, "--", DIRECTORY) or ""
    changed = {os.path.basename(path) for path in changed.split("\n") if path.endswith(".fs")}
    spans = sections(lines)
    pairs = {name for name in spans if any(lines[i] == "#else" for i in range(max(0, spans[name][0] - 1), spans[name][0]))}
    edits = []
    for name, (start, end) in spans.items():
        if FILE_OF.get(name, name + ".fs") not in changed:
            continue
        old, new = fork_file(fork, old_ref, name), fork_file(fork, new_ref, name)
        if old is None or new is None:
            print(f"{name}: file added or removed upstream; carry it by hand")
            continue
        result, conflicts = transfer(old, new, lines[start:end], indent)
        for conflict in conflicts:
            print(f"{name}: CONFLICT {conflict}")
        note = " (a pair: hopac's side not updated)" if name in pairs else ""
        print(f"{name}: {len(conflicts)} conflicts{note}")
        edits.append((start, end, result))
    for start, end, result in sorted(edits, reverse=True):
        lines[start:end] = result
    with open(CORE, "w", encoding="utf-8", newline="") as file:
        file.write("\n".join(lines))


def export(fork, base_ref, out_dir):
    lines = load_core()
    for name, (start, end) in sections(lines).items():
        base = fork_file(fork, base_ref, name)
        if base is None:
            continue
        section = [dedent(line) for line in lines[start:end]]
        result, conflicts = transfer(base, section, base, lambda line: line)
        for conflict in conflicts:
            print(f"{name}: CONFLICT {conflict}")
        path = os.path.join(out_dir, DIRECTORY, FILE_OF.get(name, name + ".fs"))
        os.makedirs(os.path.dirname(path), exist_ok=True)
        newline = "\r\n" if "\r\n" in (fork_text(fork, base_ref, name) or "") else "\n"
        with open(path, "w", encoding="utf-8", newline="") as file:
            file.write(newline.join(result))
    print(f"wrote the fork's files with the sections' edits under {out_dir}")


def main():
    args = sys.argv[1:]
    if len(args) in (2, 3) and args[0] == "status":
        status(args[1], args[2] if len(args) == 3 else "HEAD")
    elif len(args) == 4 and args[0] == "import":
        import_(args[1], args[2], args[3])
    elif len(args) == 4 and args[0] == "export":
        export(args[1], args[2], args[3])
    else:
        raise SystemExit(__doc__)


if __name__ == "__main__":
    main()
