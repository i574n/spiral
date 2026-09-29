# apps/compiler

- `spiral_compiler.fs` holds both compiler cores: the single-flight evaluator with the F#, C, Rust and
  Delphi backends, and the Hopac evaluator, as shared sections plus `#if SPIRAL_CORE_HOPAC` section pairs
  (see `tmp/AGENTS.md`). Edit it directly; there is no notebook to export it from.
- `tmp/` holds everything around it: the portable host (`tmp/compiler/host`), the Hopac core that is
  being brought to parity (its side of `spiral_compiler.fs`), the test harness and fixtures, and the splitter.
  Start with `tmp/AGENTS.md`.

```powershell
pwsh tmp/scripts/build.ps1 -Mode single-flight            # builds this directory's spiral_compiler.fs
pwsh tmp/scripts/test.ps1 -Mode single-flight -Suite all -Native
pwsh tmp/scripts/build.ps1 -Mode hopac                    # the Hopac lane
```

`build.ps1` in this directory packages `spiral_compiler.fs` with the polyglot builder into `dist/`.
