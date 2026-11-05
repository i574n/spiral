# apps/compiler

- `spiral_compiler.fs` is the compiler core: the single-flight evaluator with every backend, plus the hopacsota
  parallel layer in `#if SPIRAL_CORE_HOPACSOTA` blocks (see `tmp/AGENTS.md`). Edit it directly; there is no
  notebook to export it from.
- `tmp/` holds everything around it: the portable host (`tmp/compiler/host`), the test matrix and fixtures.
  Start with `tmp/AGENTS.md`.

```powershell
pwsh scripts/build.ps1 -Mode single-flight            # builds this directory's spiral_compiler.fs
pwsh scripts/test.ps1 -Mode single-flight -Suite all -Native
pwsh scripts/build.ps1 -Mode hopacsota                       # single-flight plus the parallel layer
```
