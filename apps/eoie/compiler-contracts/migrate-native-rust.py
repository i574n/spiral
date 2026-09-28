"""One-shot migration of eoie's Spiral sources from the C-to-Rust translator's markers to native constructs.

- `$"RustExport<Kind>(\"export\",\"function\")" : ()` -> `!!!!Export("export", ((fun ... => function ...) : signature))`
- `$"RustLibrary()"` and its `rust_library` helper -> removed (a program that exports is a library)
- the `rust_global` helper's `$"RustGlobal(@x)"` -> `!!!!Global(x)`
- `!\\(args, $'"code with $0"')` (Fable's emitRustExpr) -> `$'code with !arg' : <return type>`

Run from anywhere: python migrate-native-rust.py [--dry-run]
"""
import os
import re
import sys

ROOT = os.path.normpath(os.path.join(os.path.dirname(os.path.abspath(__file__)), ".."))
DRY = "--dry-run" in sys.argv

# Signatures of the translator's export families (compiler/host/PortableBackends.fs, rustExportSignature).
FAMILIES = {
    "I32": ("()", "{f} ()", "() -> i32"),
    "I32Binary": ("(first, second)", "{f} first second", "i32 * i32 -> i32"),
    "StringUnary": ("value", "{f} value", "string -> string"),
    "U64Unary": ("value", "{f} value", "string -> u64"),
    "StringTuple5Unary": ("value", "{f} value", "string -> string * string * string * string * string"),
    "U64String5": ("(a, b, c, d, e)", "{f} a b c d e", "string * string * string * string * string -> u64"),
}
EXPORT = re.compile(r'\$"RustExport(\w+)\(\\"(\w+)\\",\\"([\w.\']+)\\"\)"(\s*:\s*\(\))?')
# The helper, on one line or several: `inl rust_global (x : string) : () = [real typecase ... =>] $"RustGlobal(@x)" : ()`.
GLOBAL_HELPER = re.compile(r'inl (\w+) \(x : string\) : \(\) =[^\n]*(?:\n[ \t]+[^\n]*)*?\$"RustGlobal\(@x\)" : \(\)')
GLOBAL_INLINE = re.compile(r'real\s+typecase `\(!!!!LitToTypeLit\(("(?:[^"\\]|\\.)*")\)\) with ~x => \$"RustGlobal\(@x\)" : \(\)', re.S)
LIBRARY_LINE = re.compile(r'^[ \t]*(\$"RustLibrary\(\)"(\s*:\s*\(\))?|rust_library \(\)|inl rust_library \(\) : \(\) = \$"RustLibrary\(\)"(\s*:\s*\(\))?)[ \t]*\r?\n', re.M)
EMIT_DEF = re.compile(r"^inl \(~!\\\\?\) forall t u\. \(\(args : t\), \(code : string\)\) : u =\r?\n[ \t]+\$'Fable\.Core\.RustInterop\.emitRustExpr !args !code '\r?\n", re.M)
EMIT_CALL = re.compile(r"!\\\\?\((\([^()]*\)|[\w']+), \$'\"(.*)\"'\)")
RETURN_TYPE = re.compile(r"^(?:inl|let) .*\) : ([^=]+?) =\s*$")

counts = {"files": 0, "exports": 0, "library": 0, "globals": 0, "emit": 0}
problems = []


def rewrite_export(match):
    kind, name, function = match.group(1), match.group(2), match.group(3)
    if kind not in FAMILIES:
        problems.append(f"unknown export family {kind} ({name})")
        return match.group(0)
    pattern, body, signature = FAMILIES[kind]
    counts["exports"] += 1
    return f'!!!!Export("{name}", ((fun {pattern} => {body.format(f=function)}) : {signature}))'


def rewrite_emits(text, path):
    lines = text.split("\n")
    return_type = None
    for i, line in enumerate(lines):
        m = RETURN_TYPE.match(line.strip() and line)
        if m:
            return_type = m.group(1).strip()
        call = EMIT_CALL.search(line)
        if not call:
            continue
        args = call.group(1)
        names = [a.strip() for a in args.strip("()").split(",")] if args.startswith("(") else [args]
        code = call.group(2).replace('\\"', '"')
        code = re.sub(r"\$(\d+)", lambda n: "!" + names[int(n.group(1))], code)
        if return_type is None:
            problems.append(f"{path}:{i + 1}: no return type for an emitRustExpr call")
            continue
        # `!name'` would read the closing quote as part of the name (Spiral identifiers may end in primes).
        if re.search(r"![A-Za-z_]\w*$", code):
            code += " "
        lines[i] = line[:call.start()] + f"$'{code}' : {return_type}" + line[call.end():]
        counts["emit"] += 1
    return "\n".join(lines)


for directory, dirs, files in os.walk(ROOT):
    dirs[:] = [d for d in dirs if d not in ("target", ".git", "node_modules")]
    for file in files:
        if not file.endswith((".spi", ".spir")):
            continue
        path = os.path.join(directory, file)
        text = open(path, encoding="utf-8", newline="").read()
        new = EXPORT.sub(rewrite_export, text)
        new, n = GLOBAL_HELPER.subn(r"inl \1 (x : string) : () = !!!!Global(x)", new)
        counts["globals"] += n
        # A literal passed straight to the marker: `real typecase `(!!!!LitToTypeLit("...")) with ~x => $"RustGlobal(@x)" : ()`.
        new, n = GLOBAL_INLINE.subn(lambda m: f"!!!!Global({m.group(1)})", new)
        counts["globals"] += n
        new, n = LIBRARY_LINE.subn("", new)
        counts["library"] += n
        new, n = EMIT_DEF.subn("", new)
        new = rewrite_emits(new, os.path.relpath(path, ROOT)) if n or "emitRustExpr" in new or EMIT_CALL.search(new) else new
        code = "\n".join(line for line in new.split("\n") if not line.lstrip().startswith("//"))
        in_state = os.path.relpath(path, ROOT).split(os.sep)[0] == "state"
        for leftover in ("RustExport", "RustLibrary", "RustGlobal", "emitRustExpr"):
            if leftover in code and not in_state:
                problems.append(f"{os.path.relpath(path, ROOT)}: still contains {leftover}")
        if new != text:
            counts["files"] += 1
            if not DRY:
                open(path, "w", encoding="utf-8", newline="").write(new)

print(("dry run: " if DRY else "") + ", ".join(f"{k} {v}" for k, v in counts.items()))
for problem in problems:
    print("  !", problem)
