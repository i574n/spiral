# apps/compiler

- `spiral_compiler.fs` holds both compiler cores: the single-flight evaluator with the F#, C, Rust and
  Delphi backends, and the gpt5parallel evaluator, as shared sections plus `#if SPIRAL_CORE_GPT5PARALLEL` section pairs
  (see `tmp/AGENTS.md`). Edit it directly; there is no notebook to export it from.
- `tmp/` holds everything around it: the portable host (`tmp/compiler/host`), the gpt5parallel core that is
  being brought to parity (its side of `spiral_compiler.fs`), the test matrix and fixtures.
  Start with `tmp/AGENTS.md`.

```powershell
pwsh scripts/build.ps1 -Mode single-flight            # builds this directory's spiral_compiler.fs
pwsh scripts/test.ps1 -Mode single-flight -Suite all -Native
pwsh scripts/build.ps1 -Mode gpt5parallel                    # the gpt5parallel lane
```

`build.ps1` in this directory packages `spiral_compiler.fs` with the polyglot builder into `dist/`.
