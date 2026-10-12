# Samples

One directory per fixture, each with `package.spiproj` and `main.spi` (top-down) or `main.spir`
(bottom-up). `scripts/test.ps1` discovers them by name:

| Pattern | Suite | Goldens |
|---|---|---|
| `frontier_<name>` | frontier | the smallest programs the Hopac core must finish first |
| `<name>` | examples | backend fixtures: `main.fsx`, `main.c`, `main.rs`, `main.pas` beside the source |
| `contract_<name>` | contracts | type-system contract cases, compiled to F# (negative cases must be rejected) |
| `mega_<name>` | mega (root), contracts (sub-packages) | the five megaprojects; `tests/harness.psd1` (`Mega`) lists their roots |

`core/` is the small portable `core-` package the fixtures share (`packages: core-`); the full standard
library (`packages: |core-`) is The-Spiral-Language's core, reached through the repo's `deps/polyglot`
link. Expected results live in the cache (`baseline/EXPECTED.tsv`).
C shims for native builds: `../tests/native-shims/`; per-fixture C flags: `../tests/harness.psd1` (`CFlags`). Never compile in place: the
compiler writes residuals beside its input, so the harness stages a copy in the cache.
