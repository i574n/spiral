#!/usr/bin/env bash
set -u
CASES=${1:?cases folder, e.g. tests/nht/cases or tests/nht/law}
DLL=${2:?path to SpiralCompiler.dll}
LIB=${3:?path to spiral/lib}
DN=${SPIRAL_DOTNET:-dotnet}
W=$(mktemp -d); trap 'rm -rf "${W:?}"' EXIT
printf 'case\tstage\trc\tfirst_error\n'
for f in "$CASES"/*.spi; do
  c=$(basename "$f" .spi); d=$W/$c; mkdir -p "$d"; cp "$f" "$d/main.spi"
  printf 'packageDir: %s\npackages:\n    |core-\n    spiral-\nmodules:\n    main\n' "$LIB" > "$d/package.spiproj"
  cd "$d"
  timeout 300 nice -n 10 "$DN" "$DLL" --check "$d/main.spi" > "$d/check.log" 2>&1; rc=$?
  printf '%s\tinfer(--check)\t%s\t%s\n' "$c" "$rc" "$(grep -v -e '^Package typecheck rejected' -e '^checked package' "$d/check.log" | sed "s#$W/##g" | paste -s -d '\001' - | sed 's#\x01# ¦ #g' | cut -c1-400)"
  timeout 300 nice -n 10 "$DN" "$DLL" --backend Rust "$d/main.spi" "$d/out.rs" > "$d/build.log" 2>&1; rc=$?
  printf '%s\tparteval(--backend Rust)\t%s\t%s\n' "$c" "$rc" "$(grep -m1 -E 'E[A-Z]+[0-9]+|error|Error|exception' "$d/build.log" | sed "s#$W/##g" | cut -c1-220)"
  if [ -f "$d/out.rs" ]; then
    printf '%s\tresidue\t-\tout.rs %s lines, clone=%s Rc::new=%s PhantomData=%s\n' "$c" "$(wc -l < "$d/out.rs")" "$(grep -c '\.clone()' "$d/out.rs")" "$(grep -c 'Rc::new' "$d/out.rs")" "$(grep -c PhantomData "$d/out.rs")"
    if [ -n "${RESIDUE_TEXT:-}" ]; then
      printf '%s\tresidue_text\t-\t%s\n' "$c" "$(grep -c -F "$RESIDUE_TEXT" "$d/out.rs")"
    fi
  fi
done
