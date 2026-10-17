# Spiral formatter plan

Written 2026-10-14 02:25. Backlog item: SPIRAL-FORMATTER. This file is the contract, in the hopacsota PLAN.md shape. A
change to a decision goes into "Decision changes" at the bottom, with the measurement that justified it, in the same
change as the code. A decision that changes without such an entry is drift. Revert it.

The user's constraints (2026-10-13 23:48):
- it probably lives inside the compiler, to reuse its tokenizer and parser;
- the style is the user's own, as written in lib/spiral and the CLIs;
- its main goal is hardening the 120-character line limit.

## Facts (measured 2026-10-14 by lane 3, read only)

Source: `style-rules.md`, with its analyzer, metrics and corpus extraction in the job scratch folder
(`tmp/formatter`).

**User corpus.** `polyglot@bb856d13` (2025-01-12), the last state before `lib/spiral` moved to this repo: 86
`.spi`/`.spir` files, 14,683 non-blank lines (lib/spiral, lib/math and the CLIs under `apps/spiral/temp`,
`apps/chat`, `apps/scheduler`).
- Git authorship cannot separate the user from agents: every commit uses the user's identities and has no
  co-author trailer.
- So the split is by date: the user corpus predates the first `AGENTS.md` (2026-09-27) by 20 months.
- It is confirmed by current lib lines blamed before 2025-09 (8,784 non-blank) and by the pre-2025-09 lines of
  `apps/spiral/spiral.spi` and `apps/wasm/spiral_wasm.spi` (841).

**The rules the user follows** (conforming / violating, user corpus):

| Rule | Count |
|---|---|
| Binary operators spaced | 9,832 / 0 |
| Type annotation colon spaced | 4,265 / 0 |
| Indent step +4 | 3,871 / 7 |
| Multi-line body at +4 | 1,739 / 0 |
| Pipeline stages aligned with the head | 1,027 / 1 |
| `match` arms at the column of `match` | 141 / 0 |
| Multi-line records (`{` ends the line, fields at +4, no `;`, `}` back at the opening column) | 224 / 0 |
| Bare lambdas | 1,168 vs 117 parenthesized |
| Then-first `if` (`if c` / `then a` / `else b`) | 107 vs 31 then-at-end |
| One blank line between top-level definitions | 1,923 of 2,105 |

The user's template for a long definition head is name, then parameters at +4, then `: type`, then `=` alone: 44
heads use it.

**Lines over 120 in the user corpus: 334.**
- 18 are comments.
- 316 are code. Of these, 272 hold one literal longer than the room left on the line:
  - 230 plain `"..."` strings, mostly `global "#if FABLE_COMPILER ..."` preludes;
  - 42 macros (`$'...'`, `$"..."`).
- 44 can be fixed by moving line breaks.

**The user breaks well under 120**: 353 of 498 multi-line pipelines and 24 of 44 template heads would fit on one line.

**A pass that only fixes spacing would change:**

| Corpus | Lines changed |
|---|---|
| User corpus | 29 of 14,689 (22 trailing whitespace, 3 `f()`, 1 each: `f(x)`, comma, `[`, constraint `{}`) |
| Current lib/spiral (77 files, all blame dates) | 68 of 18,977 (22 `f(x)`, mostly `!!!!Op(a,b)`) |
| Pre-2025-09 lines of the two CLIs | 0 of 841 |

**Agent-era code differs** (eoie `src`):
- 1,312 of 16,238 lines are over 120;
- 1,795 one-line `if c then x`;
- 418 parenthesized lambdas against 10 bare;
- 2,310 `f(x)`;
- no broken pipelines.

## Decisions

- **F1. Inside the compiler.**
  - The formatter is a section of `spiral_compiler.fs`, shared by both cores. It reads the token stream of the
    `Tokenize` section (`tokenize_line`, lexical state threaded per line) and the ranges the `BlockParsing` section
    produces.
  - There is no second lexer or parser.
  - It is exposed as a host subcommand (`format <file|dir> [--check]`), an eoie verb and a Zed format command.
  - The formatter section is not upstream-mapped, so it may grow freely; the upstream-sync rule does not apply to it.
- **F2. The style is measured, not invented.** Each rule cites its counts in the user corpus (the Facts above and
  `style-rules.md` rules 1-30). A rule with no single habit in the user corpus ("mixed": `;[ ]` spacing, trailing
  operator breaks in the old CLIs, blank lines inside bodies) is left as written, never normalized.
- **F3. Indentation is syntax.** The parser is column based, so the formatter never changes the indentation of a line
  it does not break. A broken line's continuation uses +4 or the aligned column of the user's template.
- **F4. Spacing rules apply everywhere.** These are rules 1 and 4-11:
  - no tabs, no trailing whitespace;
  - one space around binary operators;
  - `x : t`;
  - `, ` and `; `;
  - `f (x)` and `f ()`;
  - `{ a }` and `[ a ]`;
  - tight constraint braces `{int; number}`.

  They act on tokens: literal text, macro text and comments are never touched.
- **F5. Breaking is deterministic, outermost first.**
  - A line over 120 is broken by the first rule below whose syntax node does not fit, and every produced line is
    checked again.
  - A node that fits is never broken. Each template is one the user wrote (`style-rules.md` §4):
    1. definition head;
    2. binding body;
    3. pipeline;
    4. application;
    5. last-argument lambda;
    6. match arm;
    7. `if`;
    8. record;
    9. list / `;[ ]`;
    10. operator chain, with the operator leading and aligned with the head;
    11. union case;
    12. literal;
    13. comment.
- **F6. Semantics are preserved by construction and checked by the residual.**
  - The output must tokenize to the same token sequence, ignoring whitespace and line breaks, as the input.
  - Every formatted file must compile to the same residual hash as before (G3).
- **F7. Untouched regions.** These are never rewritten:
  - comment text;
  - `/// #`, `/// ##`, `/// ###` notebook headers;
  - `///>` target lines;
  - the text inside `$'...'`, `$"..."`, `"..."`, `"""..."""`, `@"..."` and char literals;
  - the inside of `(* *)` comments.

  Test blocks are formatted like any other code.
- **F8. Both editions.** Edition-3 symbol tokens are kept as written. The formatter never converts between editions;
  that is `spiral convert` (SPIRAL3-EDITIONS).
- **F9. A pure function.** `format(text, edition)` reads no clock, no environment and no file other than its input.
  Output is LF, ending with exactly one newline.
- **F10. The allowlist is explicit and keyed by content.**
  - A line that may stay over 120 is listed in `tmp/lanes/formatter/allowlist.tsv` as `file`, `kind` (`literal` /
    `comment`) and the sha256 of the literal's or comment's text.
  - The key is content, not a line number, so reformatting cannot invalidate it.
  - The allowlist only shrinks; adding an entry is a decision change.

## Banned in formatter code (gate G6)

- Any regex or string scan over Spiral source text: use the tokenizer's tokens.
- A second tokenizer or parser.
- Writing inside literal, macro or comment text.
- Joining lines that the author broke (unless Q2 is decided otherwise).
- Changing the indentation of a line that is not being broken.
- CR or tab in the output.
- `Dictionary`/`HashSet` iteration order, a clock or the environment in any decision.
- Silent fallbacks: a line that cannot be made to fit is an error or an allowlist entry, never left alone without
  a report.

## Decisions taken by the user (2026-10-14 06:39)

- **Q1. Literals over the limit:** add a core string concat operator folded at compile time, and let the
  formatter split plain strings with it; add a macro line continuation in both editions. Until both land, the
  literal lines are allowlisted (F10), and the allowlist must end empty.
- **Q2/Q3. Normalize.** The formatter joins lines that fit and re-breaks deterministically: one canonical
  layout, not the author's breaks. This overrides the recommendation to keep breaks. Consequences: G2 changes
  from "the user corpus formats to itself" to "the user corpus formats to the canonical layout with identical
  residual hashes", and the canonical layout must be built from the user's own multi-line templates
  (style-rules.md), not invented. Operators the formatter breaks go leading, aligned with the head.
- **Q4. A guard too long for one line** is laid out as an aligned pipeline: break after when, one stage per
  line at +4, => on its own line:

  ```
      | array when
          array
          |> (fun x => a x : _ int _)
          |> am.forall' ((=) (array |> (fun x => a x : _ int _) |> am'.index 0))
          => ()
  ```
- **Q5. Comments:** lines inside a /// ``` fence are verbatim output and exempt from the limit; ordinary
  comments over 120 are rewrapped at word boundaries with the same prefix.
- **Q6. ;[ ] arrays:** spaced everywhere (;[ 0; 2; 4 ]), empty stays ;[].
- **Q7. Placement:** a compiler section now, reusing the real tokenizer and block parser, exposed as
  SpiralCompiler format [--check], an eoie verb, Zed format-on-save and Kino; ported to the self-hosted
  Spiral compiler with it.
## Priority and first targets (user, 2026-10-14 06:47)

The formatter comes before further eoie work: "we need the formatter before to pass through eoie shitty oneline
codebase, also through agile. these files without linebreaks don't show in fork properly". Long single lines turn a
diff into one changed line that the Fork client truncates behind "load more".

| Target | Lines | Over 120 | Over 1,000 | Longest |
|---|---|---|---|---|
| eoie `.spi`/`.spir` (545 files) | 23,579 | 3,188 | 160 | 30,285 (`eoie_bundle_zip/archive_terminal.spi`) |
| backlog `state/agile.spi` (525 KB) | 463 | 324 | 136 | 17,188 (task titles) |

- **eoie:** the first corpus the normalize pass runs over after the user corpus gate (G2). Its one-line functions
  are the main input of the layout engine; `rust_global` and macro text are literals (Q1: concat operator and
  macro continuation, allowlisted until both land).
- **agile.spi is generated** by eoie's agile writer, so formatting it once is not enough: the writer must emit
  formatted text (it calls the formatter, or emits the canonical layout itself), and long titles and notes are
  string literals that only Q1's concat operator (or a multi-line string form) can split. `eoie agile notes
  from-title` already moves title tails into note rows; each note row must also fit the limit.
- Gate added: after the formatter's first release, `agile.spi` and every eoie source have 0 lines over 120 outside
  the allowlist, and every eoie package compiles to the same Rust (residual hash) as before formatting.
## Single-line form and generated files (decided 2026-10-14 06:51)

The user asked whether agile.spi should stay one record per line, like JSONL, to battle-test Spiral's ability to
write programs on one line, or be emitted formatted. Decided (main thread, under the standing rule to make
technical calls, with the reason): the two goals get two artifacts.
- **agile.spi is emitted formatted.** One record per line keeps diffs short only while records are short; a
  17,188-character title is still one line the Fork client truncates. eoie's agile writer emits the canonical
  layout (multi-line records, notes as their own rows), so an edit changes the few lines it touches.
- **The single-line battle test is a formatter gate over the whole corpus (G7)**, both editions: for every program
  `p` in the user corpus, lib, CLIs, eoie (545 files) and every sample:
  1. `flatten(p)` parses (every construct has a single-line spelling);
  2. `format(flatten(p)) == format(p)` (layout is a function of the AST, not of the input's breaks);
  3. `p`, `flatten(p)` and `format(p)` compile to the same residual hash.
  Every failure is a construct with no single-line spelling, or one that parses differently on one line, or an
  edition-3 symbol that collides once newlines are gone: each becomes a syntax fix (both editions, upstream-safe)
  or a documented exception in the gate's allowlist.
- `flatten` ships as `SpiralCompiler format --flatten`: the corpus gate uses it, and it gives JSONL-style one-line
  records to any tool that wants them, without making them the stored form.
## Phases and gates

A phase starts only when the previous phase's gate numbers are in the scoreboard.

### Phase 0: measurement (done)

- The style rules with counts, the line-length distribution, the constructs over 120 and the spacing diff counts
  (Facts above).
- Gate: the numbers are in the scoreboard.

### Phase 1: the spacing pass and the check mode

- F4 on tokens.
- `format --check` reports every line over 120 with its construct (head, binding, pipeline, application, arm,
  `if`, record, literal, comment).

**Gate 1:**
- G1 on every corpus;
- G2: the user corpus formats to itself except the 29 listed spacing lines;
- G3 on all samples and lib/spiral;
- G6.

### Phase 2: the break strategy

- F5 steps 1-11 and 13.

**Gate 2:**
- G1, G3, G6;
- G2: the user corpus changes only on lines that were over 120;
- G4: 0 lines over 120 in lib/spiral, the CLIs and samples, except allowlisted literal and comment lines;
- G5.

### Phase 3: literals (after Q1)

- F5 step 12, split as the user decides in Q1.

**Gate 3:**
- G4 with the literal entries removed from the allowlist (only comments left, or none);
- G3 unchanged.

### Phase 4: front ends and the lint

Design (lane A, 2026-10-14 22:10), one implementation behind every front end, so Gate 4's byte identity holds by
construction and is checked by hashing:
- **Core section.** The eight `.fsx` files move unchanged in shape into one shared section of `spiral_compiler.fs`
  after `BlockParsing` (`/// ## Formatter`, no `#if` pair: it calls only shared functions, `tokenize_line`,
  `wdiff_tokenizer_all`, `parse_block`). Entry point `formatText : Edition -> Unit' -> FormatOptions -> string ->
  FormatResult` (text, kept-verbatim blocks, over-120 lines with their construct, guard failures). The reflection-based
  shape comparison stays as is (it already runs on both cores' `RawExpr`). Moving it is a patch in the same anchored
  form as the others, and the `.fsx` files become a thin `#load` of the compiled section for corpus runs.
- **Host subcommand.** `SpiralCompiler format <file|dir>... [--check] [--flatten] [--split-literals] [--stdin
  --path <p>]`, dispatched in `Program.fs` next to `build-file`. The edition comes from the nearest
  `package.spiproj` (`edition: 2|3`, installed in pack-1e), the unit from the extension (`.spi` top-down, `.spir`
  bottom-up). `--check` prints `file:line:col: over-120 <construct>` and exits 1 when a file would change; `--stdin`
  reads the buffer and writes the result to stdout (editors), with `--path` naming the file for edition lookup.
  `--split-literals` becomes the default once string-concat-typed is installed (pack-1f).
- **eoie verb.** `eoie format <path> [--check]` runs the host subcommand (eoie-first: one call, no plan file); the
  agile writer calls the same entry through the host after EOIE-AGILE-FORMATTED-WRITER's block reader lands.
- **Zed.** The `spiral-zed` language server advertises `documentFormattingProvider` and answers
  `textDocument/formatting` with one whole-document edit from `SpiralCompiler format --stdin --path <uri path>`;
  format-on-save is the user's Zed setting. Kino calls the same subcommand.
- **Gate 4 check.** For every corpus file: the host's output, `eoie format`'s and the language server's edit applied
  to the file have the same sha256 as the `.fsx` corpus run's output.
- **CI lint.** `SpiralCompiler format --check` over lib, the CLIs and samples as a report step that never fails the
  build until the user says so.

- The host subcommand, the eoie verb and Zed format-on-save.
- A CI lint report: lines over 120 per repo, never failing the build until the user says so.

**Gate 4:**
- Zed, eoie and the CLI produce byte-identical output on every corpus file;
- the lint runs in CI.

## Gates every phase runs

| Gate | Check | Pass |
|---|---|---|
| G1 idempotence | format every file twice | the second run changes 0 bytes |
| G2 user corpus | format the polyglot snapshot and the current pre-2025-09 lines | diff = exactly the listed lines |
| G3 residual | compile every formatted sample and lib program, before and after | identical residual hashes |
| G4 limit | `format --check` over lib/spiral, the CLIs, samples | 0 lines over 120 outside `allowlist.tsv` |
| G5 determinism | format the corpus twice, in two processes | byte-identical outputs |
| G6 banned | a lint over the formatter section | 0 hits of the banned list |

## Process rules

1. A phase starts only when the previous gate's numbers are in the scoreboard.
2. A style rule that is not in `style-rules.md` with counts is not a rule. Measure it first.
3. A failing G2 line gets a minimal reproduction in the formatter's own fixture folder (`tmp/lanes/formatter/cases`)
   before the fix.
4. A decision change is written before its code, in "Decision changes" below.
5. Backlog progress is gate numbers, never prose.

## Scoreboard

| Phase | Gate | Date | Numbers |
|---|---|---|---|
| 0 | measure | 2026-10-14 01:27 | 30 rules; 334 user lines over 120 (272 literal, 18 comment, 44 layout) |
| 1 (partial) | G1, F6, parse | 2026-10-14 08:16 | spacing pass over 1,895 files: G1 idempotent 1,895/1,895; token drift 0; every changed file (user 12, lib 13, apps 8, eoie 316, samples 447) parses to the same blocks; G3 residual not run yet |
| G7 (flatten) | G7.1 parse | 2026-10-14 09:33 | `format --flatten` over 1,895 files: user 86/86 files parse to the same blocks (2,216 blocks flattened, 24 refused: 20 multi-line `"""`/`(* *)`, 4 comments holding `*)`), lib 73/77, apps 14/14, samples 1,192/1,216, eoie 481/482, agile 1/1 (first flatten version; the user-corpus fixes after it are not re-measured on the other corpora yet) |
| normalize (user) | G1, parse, G7.2 | 2026-10-14 10:30 | `format` = spacing(layout(flatten p)) over the user corpus: idempotent 86/86, same blocks 86/86, format(flatten p) = format p 86/86; 11,118 non-blank lines out (14,683 in), 8,905 of them (80.1%) appear verbatim in the input; 416 lines over 120 (input 334; 272 are unbreakable literals) |
| normalize v2 (user) | G1, parse, G7.2, G3 | 2026-10-14 11:07 | idempotent 86/86, same blocks 86/86; 13,338 non-blank lines out, 11,508 (86.3%) verbatim from the input; 354 over 120 (272 literals); blocks with inner `//` comments are kept as written (no comment-placement rule yet), so G7.2 is 61/86 and every one of the 25 differences sits in such a block; G3 (C residual, flat vs original, 04:35 core): 3 of 3 compiling samples identical (qualified_union_case_pattern, gleam_match_narrowed, native_closure_union_rec) |
| normalize v3 (user) | + comments, test blocks, created overflow | 2026-10-14 11:19 | idempotent 86/86; same blocks incl. test bodies 86/86; comment words equal 86/86; 13,587 non-blank lines out, 11,831 verbatim (87.1%, includes 95 verbatim comment blocks of 2,164 lines); over 120: 334 out = 334 in; layout lines over 120: 40 in, 46 out, 37 of them created by the layout (open: application heads, `run_target (function ...) : t`, nested `exists (...)`) |
| normalize (all corpora) | G1, parse, comments, over 120 | 2026-10-14 13:16 | run started 12:29 (before the latest rules), no literal splitting: eoie 482 files: same blocks 482/482, comments 482/482, idempotent 480/482, over 120 1,366 -> 785 (layout lines 1,027 -> 444, the rest literals: 419 strings, 204 rust_global, 79 macros), 3 blocks kept by the guard; lib 77: same 77/77, idempotent 75/77, over 120 194 -> 172 (layout 76 -> 52), 7 guarded; apps 14: same 14/14, over 120 63 -> 24; samples 1,216: same 1,215/1,216, idempotent 1,194/1,216, layout over 120 3,323 -> 2,326, 15 guarded; agile.spi: same, layout over 120 76 -> 0, 438 string literals left |
| normalize v4 (user) | G1, parse, comments, G7.2, guard | 2026-10-14 15:36 | after the unit fix, comment placement, flatten closer fixes; with `--split-literals` on the candidate core (`^^` + macro continuation): idempotent 86/86, same blocks 86/86, comment words 86/86, G7.2 82/86; kept verbatim: 3 comment blocks (89 lines) + 3 parse-guard blocks; lines over 120: 334 in, 36 out (7 created by the layout); 11,223 of 14,627 non-blank lines appear verbatim in the input (76.7%). Current core without splitting: over 120 315 out, same G1/parse/comments |
| normalize v4 (eoie, agile) | G1, parse, comments, G7.2, guard | 2026-10-14 16:18 | code of 15:36, `--split-literals`, candidate core: eoie 482 files: same blocks 482/482, comment words 482/482, idempotent 479/482 (fixed after: layout measured widths before the spacing pass widened them; re-formatting the 3 files is now idempotent), G7.2 474/482, 13 parse-guard blocks (originals that do not parse, e.g. a `}` at column 0 closing a type record); lines over 120: 3,188 in, 89 out (44 created by the layout). Agile `state/agile.spi`: same blocks, over 120: 324 -> 4; 4 parse-guard blocks were a false alarm (the guard looked for `error (` inside literal text; it now checks the shape prefix) |
| normalize v5 (user) | G1, parse, comments, G7.2 | 2026-10-14 17:00 | `--split-literals`, candidate core: idempotent 86/86, same blocks 86/86, comment words 86/86, G7.2 83/86; kept verbatim: 4 comment blocks (122 lines), 1 parse-guard block; lines over 120: 334 in, 32 out (1 created by the layout); 11,764 of 14,905 non-blank lines appear verbatim in the input (78.9%) |
| G3 | residual | 2026-10-14 16:40 | 80 changed single-module samples (smallest first, negatives excluded), formatted with the current core and compiled before/after with the installed compiler: 67 compile on both sides with identical residual hashes, 13 fail identically on both sides, 0 differ |
| G5 | determinism | 2026-10-14 18:17 | the user corpus formatted twice in two processes (same code, `--split-literals`): 86 files, 0 byte differences |
| normalize v7 (user) | G1, parse, comments, G7.2 | 2026-10-14 18:01 | code of 17:45: idempotent 86/86, same blocks 86/86, comment words 86/86, G7.2 83/86; kept verbatim: 4 comment blocks (122 lines; 3 of them in `rust/util.spi`, laid out since by the 18:05 flatten fix) + 1 parse-guard block; over 120: 334 in, 32 out (1 created) |
| normalize v7 (lib, apps) | G1, parse, comments, G7.2, guard | 2026-10-14 18:25 | code of 17:45, `--split-literals`: lib 77 files: idempotent 77/77, same blocks 77/77, comment words 77/77, G7.2 69/77 (37/77 at 16:18, fixed by parsing a test body on its header line), 7 parse-guard blocks (4 are `test ... static` bodies that do not parse as an `inl` body even in the original); over 120: 76 layout lines in, 41 out (5 created). apps 14 files: 14/14 parse, comments, G1; G7.2 13/14; over 120: 61 layout lines in, 2 out |
| G3 (v8) | residual | 2026-10-14 19:45 | code of 19:35, current core, no splitting: the 120 smallest changed single-module samples compiled before/after with the installed pack-1e compiler (C backend): 106 compile on both sides with identical residual hashes, 14 fail identically on both sides (most: `main` does not return i32 for C), 0 differ |
| normalize v7 (samples, partial) | over 120 | 2026-10-14 18:28 | code of 17:45, installed core, no splitting; run stopped at 863 of 1,216 sample files to free the machine: lines over 120 in those files 3,548 -> 1,705 (strings and macros not split); the listing was not written, so parse/G1 numbers for samples are only those of the G3 subsets |
| normalize v8 (user) | G1, parse, comments, G7.2, guard | 2026-10-14 19:51 | code of 19:35, `--split-literals`, installed pack-1e core: same blocks 86/86, comment words 86/86, G7.2 86/86, idempotent 85/86 (`rust/rust.spi`), 0 blocks kept verbatim (0 comment, 0 parse-guard); lines over 120: 334 in, 21 out (0 created by the layout; the rest are macros and `///` lines in fences); 11,670 of 14,870 non-blank lines appear verbatim in the input (78.5%) |
| normalize v8 (lib, apps) | G1, parse, comments, G7.2, guard | 2026-10-14 20:01 | code of 19:35, `--split-literals`, installed pack-1e core: lib 77 files: same blocks 77/77, comment words 77/77, G7.2 74/77, idempotent 75/77 (`parsing.spi`, `rust/testing.spi`: open), 1 parse-guard block (a `test` body); over 120: 76 layout lines in, 5 out, 18 over-120 lines left in all (from 41). apps 14 files: same blocks 14/14, comments 14/14, idempotent 14/14, G7.2 13/14, 1 parse-guard block; over 120: 1 |
| normalize v8 (eoie, agile) | G1, parse, comments, G7.2, guard, over 120 | 2026-10-14 20:14 | code of 19:35, `--split-literals`, installed pack-1e core: eoie 482 files: same blocks 482/482, comment words 482/482, G7.2 480/482, idempotent 480/482 (`eoie_process/boundary_probe.spi`, `state_receipt_codec_model/lexical_probe.spi`), 5 parse-guard blocks in 2 files whose originals do not parse; lines over 120: 1,367 in, 15 out (5 created by the layout; the rest `!!!!Global` string arguments and Rust-block macros). Agile `state/agile.spi`: same blocks, 0 guard blocks, 0 lines over 120 (756 non-blank lines in, 11,883 out) |
| G1 follow-up | idempotence | 2026-10-14 20:22 | after two fixes (a split string argument only when it does not fit unsplit; a parenthesized operator operand opens `op (` / body / `)`): the 5 files that failed G1 at 19:35 code (user `rust/rust.spi`, lib `parsing.spi`, `rust/testing.spi`, eoie `boundary_probe.spi`, `lexical_probe.spi`) are idempotent; a 43-file regression subset (user lib, leptos, rust) has same blocks, comment words, G7.2 and G1 on every file, 0 blocks kept verbatim, 0 created overflows. Full corpora not re-run with this code |
| normalize v9 (user) | G1, parse, comments, G7.2, guard | 2026-10-14 23:28 | code of 23:10, `--split-literals`, installed pack-1e core: idempotent 86/86 (85/86 at v8), same blocks 86/86, comment words 86/86, G7.2 86/86, 0 blocks kept verbatim; lines over 120: 334 in, 21 out (0 created; macros and `///` lines in fences); 11,675 of 14,858 non-blank lines appear verbatim in the input (78.6%) |
| normalize v9 (lib, apps) | G1, parse, comments, G7.2, guard | 2026-10-15 00:05 | code of 23:32, `--split-literals`, pack-1e formatter core: lib 77 files: idempotent 77/77 (75 at v8), same blocks 77/77, comment words 77/77, G7.2 75/77 (`parsing.spi`, `physics.spi`: `test ... static` bodies whose original does not parse as a body, kept as written in `format p` but flat in `format (flatten p)`), 0 parse-guard blocks (1 at v8); lines over 120: 12 out (0 created; `///` lines in fences, comments that are one long word). apps 14 files: 14/14 on every check, 0 guard blocks (1 at v8), 0 lines over 120 (1 at v8) |
| normalize v9 (eoie, agile) | G1, parse, comments, G7.2, guard, over 120 | 2026-10-15 00:58 | code of 23:32, `--split-literals`, pack-1e formatter core: eoie 482 files: idempotent 482/482 (480 at v8), same blocks 482/482, comment words 482/482, G7.2 480/482 (the 2 files whose originals do not parse), 5 parse-guard blocks in those 2 files; lines over 120: 1 out (15 at v8), created by the layout in `process_observation_probe/main.spi` (a tuple arm pattern component; fixed at 01:00: a component too wide opens its tuple, `Ctor (` / items at +8 / `)`, same parse, 0 over 120). Agile `state/agile.spi`: same blocks, G1, G7.2, 0 guard blocks, 0 lines over 120 (808 non-blank lines in, 12,508 out) |
| normalize v9 (samples) | G1, parse, comments, G7.2, guard, over 120 | 2026-10-15 02:20 | code of 01:00, `--split-literals`, pack-1e formatter core, 1,216 files: idempotent 1,216/1,216, comment words 1,216/1,216, same blocks 1,215/1,216 (`multiline_triple_string`: the refused-block bug, fixed 02:30), G7.2 1,205/1,216, 11 parse-guard blocks (mostly mega samples whose blocks fail to parse unformatted, plus 2 negative parse fixtures), 2 comment blocks kept; lines over 120: 3,323 layout lines in, 1,263 out, 917 of them created by the layout (mega samples: 614 applications, 205 type aliases and union payloads, 57 arms, 38 heads; the type rule of 02:30 addresses the second group) |
| normalize v10 (user) | G1, parse, comments, G7.2, guard | 2026-10-15 03:34 | code of 03:20 (refused-block fix, type rules), `--split-literals`, formatter synced to installed pack-1g: idempotent 86/86, same blocks 86/86, comment words 86/86, G7.2 86/86, 0 blocks kept verbatim; lines over 120: 22 out, 10 outside ``` fences, 0 created by the layout (one more than v9 because refused blocks are now byte-for-byte) |
| G3 samples (v9) | residual | 2026-10-15 03:50 | the v9 samples output (01:00 code, split literals), every sample package with a `main` whose own or dependency files changed (862 candidates), smallest first until the 03:50 deadline, compiled before/after on the 1f+macro-arg Debug core (`lane-a/g3v2.ps1`, C first, F# when C rejects the original): 336 checked, 303 compile on both sides (C 291, F# 12; 148 with more than one module or a package dependency), 33 fail identically on both sides, 0 differ |
| G3 eoie (v9 + delta) | same Rust | 2026-10-15 05:09 | eoie `src` only (not `state/`): the v9 eoie output (00:16 sources) plus the 5 files lane B edited at 04:08-04:09 re-formatted on the 03:20 code, overlaid on a copy of `src`, every package with a `main` whose own or dependency files changed (131), compiled to Rust before/after on installed pack-1g: 131/131 identical residuals, 0 differ (`eoie_dev` included: the 04:35 difference was the stale overlay of `eoie_dev_model`, now 4653A11AB434 on both sides). The split `!!!!Global (` single-parenthesis form on pack-1g: the 5 packages that hold or depend on it, 5/5 identical |
| normalize v10 (lib, apps) | G1, parse, comments, G7.2, guard, over 120 | 2026-10-15 05:49 | code of 03:20, `--split-literals`, formatter on pack-1g: lib 77 files: idempotent 77/77, same blocks 77/77, comment words 77/77, G7.2 75/77 (the two `test ... static` files), 0 kept blocks, 0 created overflows, 12 lines over 120, all inside ``` fences (0 outside: G4 met for lib); apps 14 files: every check 14/14, 0 kept, 0 lines over 120 |
| G3 lib programs (v10) | residual | 2026-10-15 05:56 | the v10 lib/apps output (03:20 code) on installed pack-1g: `apps/spiral` Rust D621BAD2EC4A, `apps/wasm` Rust 9F266606DAF6, `apps/kino/spi` Gleam 11497F47B36A, identical before/after |
| G3 mega (final code) | residual | 2026-10-15 06:05 | `mega_zeta_structural_laboratory` (03:20 code) F# 0248B46785F2 identical; `mega_spiral_proves_spiral_relative_consistency` failed after formatting with the type rules (parse check passed), identical (AC512ADE1E50) after reverting them |
| G3 lib programs | residual | 2026-10-15 00:09 | the 85 v9-formatted lib/apps files (split literals) overlaid on a copy of `lib` and `apps/{spiral,wasm,kino/spi}`, compiled before/after on the pack-1f-preview Debug core (`lane-a/g3apps.ps1`): `apps/spiral` Rust D621BAD2EC4A, `apps/wasm` Rust 9F266606DAF6, `apps/kino/spi` Gleam 11497F47B36A, identical on both sides, 0 differ |
| G3 eoie (first slice) | same Rust | 2026-10-14 23:10 | the 13 eoie files with open issues formatted at 23:00 code, every eoie package with a `main` that depends on them (dependency closure over `package.spiproj`) compiled to Rust before/after on the pack-1f-preview Debug core (`lane-a/cache-1f`): 7/7 identical residuals, 0 differ |
| G3 repro | `!!!!Global` split | 2026-10-14 22:16 | installed pack-1e: `!!!!Global ((` / `^^` pieces / `))` = joined literal (residual 9FA5DD1AE125); candidate core with SPIRAL-MACRO-ARG-EXPRESSIONS: single parentheses and bare operator arguments give the same residual |
| G3 (type rules, fixed guard) | residual | 2026-10-15 09:07 | 07:32 code (type layout behind the KeyValuePair-fixed guard), installed compiler: the 4 mega mains formatted (`lane-a/g3-mega4b.txt`): `mega_spiral_proves_spiral_relative_consistency` F# AC512ADE1E50, `mega_zeta_structural_laboratory` 0248B46785F2, `mega_lean_cic_bottom_up_kernel` 59A47BC0ACF1, `mega_omniledger_erp_kernel` BAF5716659C6, 4/4 identical (the first is the 06:05 failure); `g3-c3`: `array_heap_heap_pair` C, `contract_higher_rank_hot_swap` F# identical, `contract_cross_backend_probe` fails identically on both sides |
| normalize (mega mains) | over 120 | 2026-10-15 08:25 | 07:32 code, 4 mega mains: layout lines over 120 620 in, 161 out (95 created; v9: 517 created in these files), parse 4/4, G1 4/4, the same 5 parse-guard blocks as v9 (originals that fail), G7.2 1/4 (3 files with blocks whose originals do not parse) |
| normalize v12 (samples) | G1, parse, comments, G7.2, guard, over 120 | 2026-10-15 12:23 | code of 11:46, `--split-literals`, pack-1g formatter core (`lane-a/format-v12-samples.txt`), 1,216 files: parse 1,216/1,216, G1 1,216/1,216, comments 1,216/1,216, G7.2 1,210/1,216 (the 6 files with blocks whose originals do not parse or are kept), 5 parse-guard blocks (4 negative fixtures whose originals fail, 1 omniledger block with `= join` ending its head, a flatten gap), 1 comment block kept; layout lines over 120: 3,323 in, 38 out (v9: 1,263; v11: 71), 12 created (v9: 917); 41 lines over 120 outside fences: 32 `identifier`, 3 opaque (macro continuation inside an escaped string), 6 layout lines left (fixed 12:23-12:35, not yet re-measured on the full corpus) |
| normalize v12 (lib, apps, user) | G1, parse, comments, G7.2, guard, over 120 | 2026-10-15 12:42 | code of 11:46 (user: the 12:35 code): lib 77: parse 77/77, G1 77/77, comments 77/77, G7.2 75/77 (the two `test ... static` files), 0 guard blocks, 0 created, 0 lines over 120 outside fences (G4 met); apps 14: every check 14/14, 0 over 120; user 86: parse 86/86, G1 86/86, G7.2 86/86, 0 guard blocks, 0 created, 10 over 120 outside fences (macros, as v10) |
| normalize v12 (eoie, agile) | G1, parse, comments, guard, over 120 | 2026-10-15 13:08 | code as of 12:35: eoie 482: parse 482/482, G1 482/482, comments 482/482, G7.2 480/482, 5 parse-guard blocks (the 2 files whose originals do not parse), 0 created, 1 line over 120 (an opaque Rust macro line); agile.spi: parse, G1, G7.2, 1 line over 120 (a split string piece holding Hangul, sized by characters; pieces are sized by display width since 13:15) |
| normalize v14 (samples, lib, apps), G4 | G1, parse, comments, guard, G4 | 2026-10-15 17:20 | code as of 15:33 (last edit before the v14 launches; v14 ran 16:05-17:20) (`lane-a/format-v14-samples.txt`, `format-v14-libapps.txt`): samples 1,216: parse 1,216/1,216, G1 1,216/1,216, comments 1,216/1,216, G7.2 1,211/1,216, 4 parse-guard blocks (all originals that do not parse: 3 negative parse fixtures and `negative_quantified_no_closed_false_inhabited_empty_match`), layout lines over 120 3,323 in / 31 out; lib 77 and apps 14: parse, G1, comments pass, 0 lines over 120 outside fences. **G4 met (superseded by the 18:58 row, which audits the identifier rows)**: 34 lines over 120 outside fences in lib, the CLIs and samples, all in `allowlist.tsv` (27 keys: 30 `identifier` lines, 3 `opaque` macro-continuation lines inside an escaped string, 1 `unparsable` line of a block whose original does not parse); 0 layout lines outside it |
| normalize v14 (user, eoie, agile) | G1, parse, comments, guard, over 120 | 2026-10-15 18:08 | code as of 15:33 (last edit before the v14 launches; v14 ran 16:05-17:20): user 86: parse 86/86, G1 86/86, comments 86/86, G7.2 86/86, 0 guard blocks, 0 created, 10 over 120 outside fences (macros); eoie 482: parse 482/482, G1 482/482, comments 482/482, G7.2 480/482, 5 parse-guard blocks (originals that do not parse), 0 created, 1 opaque macro line over 120; its output is byte-identical to v12's, so the v12 eoie G3 (131/131) covers it; agile.spi: parse, G1, G7.2, 0 lines over 120 |
| G4 (final, 18:58) | limit | 2026-10-15 18:58 | v14 samples with `mega_zeta_structural_laboratory/main.spi` and the two zeta/lean negatives replaced by the v15 run (code as of 18:49: `identifier` tightened, two layout fixes), lib/apps v14 (`lane-a/format-final-g4.txt`): 32 lines over 120 outside fences in lib, the CLIs and samples, all in `allowlist.tsv` (25 keys): 28 `identifier`, 3 `opaque`, 1 `unparsable`; 0 layout lines outside it. **Caveat:** 12 of the 28 identifier lines are created by the canonical layout (the authors' nesting kept them under 120; the formatter nests arm bodies and opened patterns deeper), so they are unbreakable only at the depth the formatter chose; next step: a nesting-budget rule (arm body at +4 after an opened pattern) to remove them. G4 scope is lib 77 + apps 14 + samples 1,216; the user snapshot's 10 macro lines are outside it |
| normalize v16 (samples, lib, apps), G4 final | G1, parse, comments, G4 | 2026-10-15 20:00 | code as of 18:49 over the full corpora (`lane-a/format-v16-samples.txt`, `format-v16-libapps.txt`): samples 1,216: parse, G1, comments 1,216/1,216, G7.2 1,211/1,216, 4 parse-guard blocks (originals that do not parse), layout lines over 120 3,323 in / 29 out, 12 created; lib 77, apps 14: parse, G1, comments pass, 0 over 120 outside fences. G4: 32 lines over 120 outside fences, all in `allowlist.tsv` (25 keys): 28 `identifier`, 3 `opaque`, 1 `unparsable`, 0 layout lines; the caveat of the 18:58 row stands (12 identifier lines are layout-created). v16 differs from v14 in 6 sample files: the 4 `array_*heap*` samples, G3 4/4 identical (C 6E7AC6D454DA, 627AAFF08E8C, 2A081A5E324D, 2DCB5B570AA9), and zeta and its negative, equal to v15 (G3 above). eoie was not re-run on the 18:49 code |
| G3 (v15 delta) | residual | 2026-10-15 19:00 | `mega_zeta_structural_laboratory/main.spi` at 18:49 code overlaid alone: F# 0248B46785F2, identical (the changed lean file is a negative sample, which G3 excludes) |
| G3 lib programs (v14) | residual | 2026-10-15 18:20 | the 85 v14-formatted lib/apps files overlaid on copies of `lib` and `apps/{spiral,wasm,kino/spi}`, installed compiler (`lane-a/g3-v14-apps.txt`): `apps/spiral` Rust D621BAD2EC4A, `apps/wasm` Rust 9F266606DAF6, `apps/kino/spi` Gleam 11497F47B36A, identical before/after |
| G3 samples (v14 delta) | residual | 2026-10-15 17:31 | the 4 sample files whose v14 output differs from v12 (`array_mut_heap_heap_pair`, the lean, omniledger and spiral-proves mega mains) overlaid alone on the originals: 4/4 identical (C 2DCB5B570AA9; F# 59A47BC0ACF1, BAF5716659C6, AC512ADE1E50), so the full v12 G3 plus this delta covers the v14 output |
| G3 samples (v12, full) | residual | 2026-10-15 15:47 | the v12 samples output (11:46 code, split literals), every sample package with a `main` whose own or dependency files changed, negatives excluded: 863 packages in three resumed passes (`lane-a/g3-v12-samples.txt.part1`, `-b`, `-c`; a package whose `.spi` changed after 11:46 is skipped; 863 distinct packages were checked, v9 had 862 candidates), compiled before/after on the installed compiler, C first, F# when C rejects the original: 863/863 same, 0 differ; 684 compile on both sides (C 485, F# 199; 228 with more than one module or a package dependency), 179 fail identically on both sides. First full-corpus G3 (v9 reached 336 of 862) |
| G3 eoie (v12) | same Rust | 2026-10-15 13:37 | the v12 eoie output overlaid on a copy of eoie `src`, every package with a `main` whose own or dependency files changed (131, 121 multi-module), compiled to Rust before/after on the installed compiler (`lane-a/g3-v12-eoie.txt`): 131/131 identical residuals, 0 differ |
| 2 | | | |
| 3 (prototype) | literal split, parse modulo folding | 2026-10-14 12:56 | `format --split-literals` (user corpus): plain strings that do not fit are split at word boundaries into `"..."` pieces joined by the Q1 operator `^^`, pieces aligned, `f (` / pieces / `)` for an argument; the parse check folds `^^` chains back into one literal; idempotent 86/86, same blocks 86/86, comments 86/86; over 120: 334 -> 81 (60 macro lines waiting for the macro continuation, 13 pasted-output comments inside ``` fences, which Q5 exempts, 6 layout, 2 strings in nested positions). Needs the compiler half: `lane-a/patches/string-concat-operator.ps1` |
| 4 | | | |

Phase 0 detail:
- spacing diff: user corpus 29 of 14,689; current lib 68 of 18,977; CLIs 0 of 841;
- literal kinds: 230 plain strings, 42 macros.

Phase 1 detail (`tmp/formatter`, an .fsx over the compiled `SpiralCompilerCore.dll`, 04:35 core):
- `check` over 120, by construct (same 334 user lines as the analyzer: 230 string + 42 macro literals, 18 comment,
  44 layout = application 11, head 16, pipeline 6, binding 5, arm 2, opaque 4):

  | Corpus | Files | Lines | Over 120 | Literal | Comment | Layout |
  |---|---|---|---|---|---|---|
  | user (polyglot@bb856d13) | 86 | 17,457 | 334 | 272 | 18 | 44 |
  | lib (spiral/lib, tracked) | 77 | 21,869 | 194 | 106 | 12 | 76 |
  | apps (no tibia, no samples) | 14 | 3,967 | 63 | 11 | 1 | 51 |
  | samples | 1,216 | 81,558 | 3,829 | 505 | 1 | 3,323 |
  | eoie src (tracked) | 482 | 19,493 | 1,366 | 340 | 0 | 1,026 |
  | backlog agile.spi | 1 | 501 | 362 | 288 | 0 | 74 |

- spacing pass, lines changed: user 69 of 17,457 (58 brackets: the 57 tight `;[`
  arrays Q6 spaces plus 1 `[`; 4 `f()`/`f(x)`; 1 comma; 6 whitespace-only lines), lib 59, apps 30, samples 2,844,
  eoie 2,159 (2,137 `f(x)`, 1,605 commas), agile 0.
- Kept by the guard (re-tokenized line differs): 16 user `///` lines with trailing spaces, because `//` with nothing
  after it is a tokenizer error ("whitespace" expected after the slashes); a candidate tokenizer fix.
- Edition conversion (`Convert.fsx`, the real token stream): user corpus 86 files to edition 3, 5,567 lines, 86/86 parse
  to the same blocks, 81 byte round trips; the 5 others need `!-;` to lex as `!-` `;` (patch proposed under
  SPIRAL3-EDITIONS).

## Decision changes

- 2026-10-14 (lane A), G2 target: "the user corpus formats to itself except the 29 listed lines" predates Q6. The
  measured spacing diff is 69 lines: 57 tight `;[ ]` arrays become spaced (Q6), the analyzer's other 29 split into
  6 whitespace-only lines, 4 application spaces, 1 comma, 1 `[`, 1 constraint brace that is a record pattern after
  a closed `forall ... .` (an analyzer false positive, not changed), and 16 `///` lines whose trailing space the
  tokenizer needs (kept). The G2 expectation for the spacing phase is these 69 lines.
- 2026-10-14 (lane A), F1 placement for development: the user decided (07:29) to develop without compiler rebuilds.
  The formatter is an .fsx over the compiled core (`tmp/formatter`, `sync-core.ps1` copies the DLLs next to it), so it
  calls the real `tokenize_line`, `wdiff_tokenizer_all` and `parse_block`, and moves into a compiler section unchanged
  in shape. Writing it in Spiral would reach those F# functions only through macros, the eoie pattern the user wants
  avoided.
- 2026-10-14 (lane A), G7 flatten spelling: one line per top-level block (a JSONL-style record), leading comment lines
  kept above it, inner `//` comments turned into `(* *)`. Layout becomes explicit: a statement followed by another is
  joined with `in`, expression statements with `.` (the sequence operator, both sides parenthesized), record fields
  with `;`, an indented body after `=`, `=>`, `then`, `else`, `join` or `real` is parenthesized, and an open scope
  (`fun`, `function`, `match`, `if`, `real`, `join`) that a later aligned operator line closes is parenthesized up to
  that line. Parentheses are AST-neutral, so the check is "same blocks, positions erased".
- 2026-10-14 (lane A), normalize = layout(flatten(p)): the canonical layout is computed from the flat form, so
  G7.2 (`format(flatten p) = format p`) holds by construction once flatten is idempotent on flat input; measured 86/86
  on the user corpus.
- 2026-10-14 (lane A), first canonical layout (`Layout.fsx`, normalize = layout(flatten p), then the spacing pass),
  each rule from style-rules.md: top-level body on the next line at +4 (rule 13); statements one per line, a local
  binding on one line when it fits and has no block body (rule 13); `match` arms at the match column, `function` arms
  at +4, arm body below at +4 when it does not fit (rules 15, 16, 27), `| pat => fun x =>` kept on the arm line when
  the lambda's body is a block; then-first `if` (rules 22-24); a long head as name/forall, parameters packed at +4,
  `: type` at +4, `=` alone at +4 (rule 25); a long application puts each argument on its own line at +4, bare
  lambdas, and a single trailing lambda stays on the head line with its body at +4 (rules 20, 21, 26); pipeline stages
  aligned with the head when the chain does not fit (rule 14); a record argument that does not fit as `f {` / one
  field per line at +4 without `;` / `}` (rule 19); parentheses that flatten added are dropped where the layout
  delimits the construct (they are AST-neutral). Not yet: operator chains other than pipelines (rule 28), `when`
  guards (Q4), comment rewrap (Q5), literal splitting (Q1), joined pipelines the user broke on purpose.
- 2026-10-14 (lane A), G7.2 exception, recorded rather than explained away: a top-level block whose body holds `//`
  comment lines or trailing comments is emitted as written (only the spacing pass touches it), because there is no
  comment-placement rule yet and normalizing it dropped comments (found by reading a diff, now gated: every run
  compares the comment words of input and output, 86/86 equal on the user corpus). Such blocks are not normalized, so
  `format(flatten p) = format p` cannot hold for them: user corpus 95 blocks, 2,164 lines (G7.2 61/86 files, all 25
  differences inside those blocks). The 87.1% "verbatim from the input" figure includes these 2,164 lines; without
  them about 85% of normalized lines match the user's own text. Gate for the next step: a comment-placement rule
  (a comment line attaches to the statement below it at the same column) that turns these blocks back on.
- 2026-10-14 (lane A), test blocks are verified too: `compareParses` used to skip them (the parser returns `Error []`
  for `test` blocks); each test body is now parsed under a synthetic `inl test_block_body () =` head before and
  after formatting.
- 2026-10-14 (lane A), the 120 limit is counted in East Asian display columns (`Lexed.displayWidth`: wide CJK, Hangul,
  fullwidth and emoji count 2, non-spacing marks 0), as MULTILINGUAL-PRESENTATION recommends; it changes 0 verdicts in
  today's corpus (302 non-ASCII lines, none crosses 120 only by width).
- 2026-10-14 (lane A), Q1 operator: `^^`, built into the parser as `StaticStringConcat` (two literals fold into one
  literal at compile time, other strings concatenate at run time), so it needs no library and is in scope everywhere.
  Census with the real tokenizer over 1,895 files: `^^` is used 0 times (`++` 261, `+++` 20 are taken). Precedence
  comes from `^` (45, right). Edition 3 is unaffected: `^` alone is the `rec` symbol, `^^` is not in the table.
- 2026-10-14 (lane A), comment placement, first rule: a `//` line inside a body attaches to the statement below it
  and is emitted at that statement's column; a blank line inside a body is kept (rule 30). Blocks whose comments sit
  anywhere else (end of a code line, between arms, inside records) stay as written. User corpus: verbatim blocks
  95 -> 40 (2,164 -> 1,564 lines), comment words still equal in 86/86 files.
- 2026-10-14 (lane A), per-block parse guard: every normalized block is parsed again and must give the same block shape
  as the input block (test bodies included, `^^` chains folded); otherwise the block is emitted as written and counted
  (`verbatim-parse-guard-blocks`). A block whose input does not parse is never normalized, because two different
  broken texts can produce the same error shape.
- 2026-10-14 (lane A), layout rules added after the first cut: operator chains other than pipelines break before the
  lowest-precedence operator, aligned with the head (rule 28); a long `when` guard as an aligned pipeline with `=>` on
  its own line (Q4); comments over 120 rewrapped at word boundaries with the same prefix, ``` fences exempt (Q5); union
  cases one per line, a long case as `| Case :: forall ... .` / pair components / `->` parts at +4 (rule 18); type
  records `type t =` / `{` / fields / `}`; `nominal x =` / `` `( `` / body / `)`; `test` blocks as a head with the
  body at +4; pipelines of three or more stages always broken (measured: 3+ stages are multi-line 103 vs 42 one-line
  in the user corpus, 1-2 stages one-line 1,087 vs 308).
- 2026-10-14 (lane A), F6 check: token sequence equality alone does not prove an equal parse (application and
  operators compare columns). Every changed file is also parsed block by block before and after and compared with
  positions erased (`Parsed.fsx`).
- 2026-10-14 (lane A), file unit fixed: `.spi` is top-down and `.spir` bottom-up (compiler: `if is_top_down then ".spi"
  else ".spir"`). The formatter had them swapped, so every list literal in a `.spi` block parsed as
  `ListLiteralsNotAllowedInBottomUp` and the guard kept those blocks verbatim. All parse numbers before this fix compare
  error shapes for such blocks; they are re-measured below.
- 2026-10-14 (lane A), macro continuation (Q1 patch `macro-continuation.ps1`): with `--split-literals` and a core that
  continues a macro line ending in `\`, the formatter first joins continued macro lines (the compiler's own rule: next
  line's text after its indentation), formats, then re-splits macros over 120 at spaces, never inside `!(...)`
  interpolations. The feature is detected from the loaded core, so the current core never sees a split macro. Opaque
  lines now carry their cause (comment, string, macro, lex error); comment words count only comment and lex-error lines.
- 2026-10-14 (lane A), comment placement measured on the laid output, not on tallies kept while trying layouts (those
  counted comments of discarded attempts). A block is kept verbatim when a comment would be lost or end up inline.
  Comments now kept in place: on `|` arm separators (own line before the arm), before pipeline stages and operator
  chain operands, before application arguments, after `=>` / inside unwrapped parentheses (any body holding a comment
  opens a block), trailing comment lines of a block (kept after it), and a single trailing remark before `in` (stays at
  the end of its statement's last line). Every kept block is listed (`kept-verbatim` with its reason).
- 2026-10-14 (lane A), flatten fixes: a head's trailing closer lines are moved out only while the head's round paren is
  still open after its inner lines (`svg ([` ... `] ++ props) fun () =>` no longer steals the inner `]`); a lambda
  body absorbs closer lines that balance brackets it opened. `!!!!Op (a, b)` that does not fit breaks its tuple one
  component per line; `=` in an expression splits like a comparison.
- 2026-10-14 (lane A), widths: inline text pads non-empty `[ ]` and spaced `{ }` the way the spacing pass does, so a
  line measured as fitting is not widened past 120 afterwards. Layout rules added for the remaining created overflows: a
  tuple argument breaks one component per line when the application does not fit (also after unary heads such as
  `!\\(` and operator sections `(~!\\) `t `u (...)`), a trailing unary list argument (`log Debug ;[`) opens a block,
  a long `match` scrutinee goes between `match` and `with`, a long parenthesized expression opens `(` / body / `)`,
  type-argument applications (`` f `t (fun ...) ``) take the argument layout, and a pipeline head ending in a lambda
  keeps its parentheses or puts the lambda body in a block (a bare one-line lambda would swallow the next `|>`).
- 2026-10-14 (lane A), style rules measured on the user corpus and adopted: `f [` / items / `] fun () =>` / body for a
  list followed by a trailing lambda (37 of 37 such lines in the user corpus; never `f [ ... ] fun () =>` on one line,
  even with one item); records holding a lambda field are always a block (36 of 36 that would fit; 0 one-line); type
  records with two or more fields are a block (`type t =` / `{` / fields / `}`); a record update opens `{ base with`
  on the first line; a lambda whose body is a record puts `{` on the lambda line; a trailing `function` argument
  stays on the head line (`run_target function` / arms at +4) and an annotation after it goes on its own line; `inl x
  =` then `fun ... =>` on the next line stays (16 of 19). The layout re-spaces the input first, so widths it measures
  are the widths the spacing pass produces.
- 2026-10-14 (lane A), guard and flatten fixes from the lib run: macro splitting now happens inside the per-block
  parse guard (a split that changes the parse is dropped, the block keeps unsplit lines); `and inl` / `and let` blocks
  get the statement layout behind `and`; only round-paren closer lines move after a head's body (a `}` closing a
  record inside a lambda stayed inside); `base with` on its own line inside `{` keeps item separators; `test` heads
  find `=` even when the test name is a quantifier keyword (`test forall =`); test bodies are parsed top-down only
  (the bottom-up fallback was a leftover of the swapped unit mapping and hid real errors).
- 2026-10-14 (lane A), G3 finding: a formatted test program failed type inference on the installed compiler. The
  cause was not the layout (the split `=` line parses to the same tree) but the untyped `^^` result on both sides
  of `=` (next entry). Parse equality proves layout rules only together with a core that types what the formatter
  emits; G3 (compile before/after, compare residuals) is the gate that proves it end to end.
- 2026-10-14 (lane A), Q1 typing: the installed `^^` is untyped in top-down inference (a RawOp), so two `^^` results
  compared with `=` hit ETY-ValueRestriction. `patches/string-concat-typed.ps1` annotates the result as `string`; it
  is on main's list for the next pack (the tree stays at the reviewed pack-1e tonight). Until it is
  installed, `--split-literals` output is not used for G3 claims. The parse comparison folds `^^` chains (also
  under that `string` annotation) back to one literal.
- 2026-10-14 (lane A), more layout fixes from idempotence runs: a lambda whose body needs a block is never put on
  one line (even inside parentheses that fit), a non-last pipeline stage keeps the parentheses of its trailing
  lambda when it stays on one line, comments before a closing `)` stay inside the block form, and a `test` whose
  body is on its header line is parsed with that body (it used to count as an empty test, failing G7.2 for every
  `test x static = open testing` header in lib).
- 2026-10-14 (lane A), 18:30-18:55 (runs paused for lane B): nested `match` arms after a `=>` line at the same
  column as its body are absorbed into that body (they were flattened into the outer `function`); `.`-sequences
  inside match arms no longer split the whole match into statements; or-pattern alternatives (`| a | b => ...`) stay
  on one arm line when they fit; comments before `then` / `elif` / `else` stay on their own lines; split string
  literals that are an argument or an operator operand get parentheses (`f "a" ^^ "b"` would apply `^^` to `f "a"`).
  The parse comparison treats `a . b . c` sequences as one list (RawSeq nesting is associative), so laying an
  inline `a . b` out as two statements is not reported as a different parse.
- 2026-10-14 (lane A), 18:55-19:05: a type lambda line (`forall k. =>` with a block body) is wrapped like a `fun`
  lambda when it is an argument followed by more arguments (it swallowed the next argument); value literals with a
  suffix (`0i32`, `365u64`) count as arguments, so long applications holding them break per argument. The guard blocks
  of `real_util.spir` and lib `rust/testing.spi`, `spiral.spi` and `leptos/ui/*` now lay out with the same parse.
  Measured, kept as is: user function heads are one line when they fit (1,189 one-line vs 28 multi-line that would fit).
  Top-level `instance` definitions stay on one line when they fit and consecutive one-line instances keep no blank line
  between them (user corpus: 54 one-line vs 2 split; top-level `inl` keeps the body on the next line, 571 vs 89). Macro
  splitting picks the longest macro on an over-long line and sizes the first piece after the text before the macro
  (`leptos.log $'...'` lines of 122-128 columns now split). Packed lines (long annotations, parameters) never break
  between glued tokens such as `model.plan`.
- 2026-10-14 (lane A), 19:30: a return annotation too long for one line opens its last parenthesized type
  argument (`: r t (` / inner / `)`), recursively; `threading.spi` now fits with the same parse.
  A head parameter whose pattern ends in a tuple too wide for one line opens the tuple (`(ctor (` / items / `))`).
- 2026-10-14 (lane A), measured, kept: a statement `if` stays three lines (`if c` / `then a` / `else b`) even
  when it would fit on one (user corpus: 13 three-line that would fit vs 3 one-line).
- 2026-10-14 21:50 (lane A), rules for the last created overflows in eoie (5 lines in 4 files at 19:35 code):
  - packed lines (heads, annotations, union-case payloads) pack whole glued words, so `a.b.c` moves to the next line
    as one word instead of overflowing after its first token: a fix of the 19:05 "never break between glued tokens"
    decision, not a new style;
  - an application whose words are all plain names, values or dotted names and that does not fit puts the callee on
    the first line and each argument on its own line at +4: rule 26 (a long application, one argument per line)
    applied to arguments the earlier code counted as part of the head;
  - no user habit (0 of 0 in the user corpus): a union case whose record payload does not fit opens `{` / one field
    per line at +8 without `;` / `} ->` at +4, borrowed from the type-record template (224/0 multi-line records);
  - no user habit (0 multi-line arm patterns in the user corpus, 3 arm lines over 120, all guards or bodies): a tuple
    arm pattern that does not fit puts one component per line, `| first,` then the others at +4, and `=>` with the
    body at +4, the Q4 guard template applied to the pattern;
  - an intrinsic whose single argument is a string that does not fit (`!!!!Global ("...")`, the longest eoie lines)
    splits it like any string argument (Q1): `!!!!Global ((` / pieces at +4 / `))`. The extra parentheses are needed
    because the installed core parses a `!!!!` argument with `application`, so a bare `"a" ^^ "b"` is a parse
    error there (SPIRAL-MACRO-ARG-EXPRESSIONS); a core that accepts operator arguments (detected by parsing
    `!!!!Add(1i32 + 2i32, 3i32)` with the loaded core) gets single parentheses.
  On the 13 eoie files with open issues (19:35 listing): parse 13/13, G1 13/13, created overflows 5 -> 0, lines
  over 120 0. G3 for these shapes is pending (`repro/global_*` and the eoie Rust gate).
- 2026-10-14 22:40 (lane A), from the lib/apps listing at 19:35 code (4 created overflows in `convert.spi`, `sm'.spi`,
  1 in `apps/spiral/spiral.spi`, its G1 failure and parse-guard block):
  - `real <expr>` that does not fit puts `real` alone and the expression at +4 (user corpus: `real` alone 46 times, 0
    inline `real` bodies over 120), so `real typecase t with ...` lays its arms out;
  - a tuple whose last component holds a keyword (`"RUSTFLAGS", if fast then ... else ...`) breaks at the commas
    before the keyword, one component per line (rule 26/tuples); the components after it are one item;
  - a lambda that is the last operand of an operator chain (`>>. x |>> fun s => ...`, `|>>` is not a pipe) is laid
    as a bare lambda after the operator with its body at +4, also when flatten wrapped it in parentheses: the first
    pass laid `fun () =>` at +8 and the second wrapped the operand as `|>> (` / ... / `)`, which was the G1 failure;
  - flatten joins a `when` guard written on its own line under its arm (`| Some x` / `when c =>`) onto the arm line
    before splitting regions (user corpus: 24 guards on the arm line, 0 on their own line). Before, the guard line set
    the region's column and the next binding's pipeline lines closed the binding early.
  - an operator line at the arm column after `function`/`match` arms (`|> resultm.get` under `| _ =>`) continues the
    expression around `function`, not the last arm (the parser ends the arms at a non-`|` token and the outer chain
    takes it); flatten now writes `(function | ... )` and appends the operator after it. `apps/spiral/spiral.spi`
    `let rec run` lays out with the same parse (guard blocks there 1 -> 0, G1 and G7.2 pass).
  - macro splitting: a piece that would start with spaces gives them to the end of the previous piece (the
    continuation keeps text before `\`), and pieces are sized one column smaller to leave room for that; a gap before a
    macro token is a cut point. `runtime.spi`'s 2,264-column Rust macro now splits into 25 lines of at most 119.
  - a split string that is the first operand of an operator chain binding tighter than `^^` (45; `++#` is 60) is
    parenthesized, `(` / pieces / `)`, because `"a" ^^ "b" ++# x` parses as `"a" ^^ ("b" ++# x)`: same string, other
    tree, so the guard kept the block (lib `runtime.spi` `test tests`, now laid out with the same parse).
  - 01:00: a tuple arm pattern component that is still too wide on its own line opens its trailing tuple,
    `Ctor (` / one item per line at +8 / `)` at +4 (the head-parameter template of 19:30 applied to patterns);
    eoie `process_observation_probe/main.spi`, the last created overflow in eoie, now fits with the same parse.
  - 02:30, bug found by the samples run (`multiline_triple_string`: parse differs): a block that flatten refuses
    (it holds a multi-line `"""` string or `(* *)` comment) was emitted with its blank lines removed, which changed
    the string's text (`"""top\n\nlevel"""` lost a newline) and dropped blank lines inside multi-line comments; the
    comment-word check could not see it, and the file-level parse check caught it only for the string. Refused blocks
    are now emitted exactly as written (no blank-line filter, no comment rewrap, no blank-line merging); both
    `multiline_triple_string` files format to themselves. Every scoreboard row before this fix includes the bug for
    refused blocks (user corpus: 24 refused blocks at 09:33).
  - 02:30: long `type x = ...` / `nominal x = ...` bodies and union-case payloads share one type layout: break at
    top-level `->`, then at `*` (one part per line, the operator ending the line, as the union-case rule of 13:00),
    else pack words and open a last parenthesized argument (`(` / inner at +4 / `)`), the 19:30 annotation rule.
  - 02:45: when packing still leaves a line too wide, a type is laid out one argument per line at +4 (the callee, or
    `: head` in an annotation, on the first line), and an argument that is a parenthesized type too wide for its line
    opens `(` / inner at +8 / `)`. Annotations keep packing and never break at `->`/`*` (a first try that split
    annotations put `:` alone on a line and the guard kept 30 blocks; reverted to the rule above). On the two largest
    mega samples: created overflows 320 -> 86, parse 2/2, guard blocks 1 (unchanged, the original fails).
  - 03:20: the tuple arm pattern rule looks for any top-level comma; it used the comma-before-keyword test, and `_`
    is a keyword token, so `| A _, B _, C _ =>` was never broken (mega samples: created overflows 86 -> 66).
  - 06:05 decision change, reverted: the 02:30 type rule (type aliases and union payloads broken at `->`/`*`, a
    parenthesized payload opened) and the 02:45 per-word type fallback. G3 on the final code found
    `mega_spiral_proves_spiral_relative_consistency` failing type inference after formatting (`exists a b c.`
    payloads split at `*` lost variables from the quantifier's scope: `ETY-UnboundVariable: right_usage`; with
    quantified types kept packed, a union definition was still lost: `Unbound variable:
    exact_linear_indexed_reduction`) while the per-block parse comparison reported the same parse. The parse check has
    a blind spot at the type level, so type layout changes need G3 before they land. With the revert the file compiles
    to the original's F# residual (AC512ADE1E50). Kept: the refused-block fix and the any-comma arm rule (both in that
    G3 run). Type aliases and union payloads are packed as before 02:30.  The 43-file regression subset (user lib, leptos, rust) at 06:12 on the final 06:05 code (same at 03:20 and 03:00): parse, comment words, G7.2 and
  G1 43/43, 0 created overflows, 0 kept verbatim, 6 lines over 120 outside ``` fences. Earlier run (01:12, 01:00 code):
  parse, comment words, G7.2 and G1 43/43,
  0 created overflows, 0 kept verbatim.

- 2026-10-15 07:32 (lane A), the type-level blind spot of the parse check, found and fixed: `shapeOf` (`Parsed.fsx`)
  printed every `KeyValuePair` as `?KeyValuePair`2`, and the parser keeps union cases and record types in F# `Map`s,
  so the body of every `union` and every type record was never compared. The 06:05 G3 failure reproduces: the failing
  `mega_spiral_proves_spiral_relative_consistency` union block compared equal before the fix and differs after it (the
  formatted payload parsed as `(exists ... . a) b c * ...`, a type application of the `exists`, because the packed
  continuation sat at the column of its own application: `apply` takes a later line as an argument only when it starts
  right of the line the application began on). `shapeOf` now prints a pair's key and value; no `?` marker is left in
  the shapes of that block. Every earlier "same blocks" number skipped union and type-record bodies.
- 2026-10-15 07:32 (lane A), type layout again, behind the fixed guard (so a wrong type layout keeps its block as
  written instead of compiling differently), each from the mega samples' own multi-line types:
  - `type x =` / body at +4 and union-case payloads share `layoutType`: break at top-level `->`, then `*` (operator
    ending the line); a quantifier `exists a b.` / `forall a.` on its own line with the body at +4; a parenthesized
    type `(` / inner at +4 / `)`, or `(exists a b.` / parts at +4 / last part `)` (the authors' template, 80+ such
    payloads in the mega samples); an application puts the callee first and packs plain-word arguments at +4 (author
    lines 3689-3690), one argument per line when an argument is a group.
  - a head parameter `(name : long type)` opens `(name :` / type at +8 with `)` closing the last line; a too-long
    `name forall a b.` first head line and a too-long `union x a b =` head pack at +4.
  - an application whose single argument is a parenthesized group that does not fit glues `(` to the callee line
    (`Ctor (` / inner at +4 / `)`, the authors' nested-constructor template); a call whose last argument is a tuple
    (`f !!!!ArrayCreate (` / items / `)`) opens it the same way.
  - 08:40, from the 4 mega mains (07:32 code: layout over 120 620 in, 161 out, 95 created; v9 had 517 created
    there; parse 4/4, G1 4/4, the same 5 parse-guard blocks as v9, all originals that fail): an arm whose pattern is a
    constructor with a tuple payload opens it (`| Ctor (` / items at +8 / `)` at +4 / `=>`), the 01:00 tuple-pattern
    template one level down; a head annotation whose packed lines still overflow and that has no top-level `->`/`*`
    or quantifier takes `layoutType` with `:` kept on the callee line (the 02:45 attempt put `:` alone); a
    too-long `exists`/`forall` variable list and a too-long `type`/`nominal` head pack at +4; plain-word type
    arguments next to group arguments pack into runs; a tuple item that fits only without its comma is laid one
    column narrower.
- 2026-10-15 11:46 (lane A), from the v11 samples run (09:38 code; listing `lane-a/format-v11-samples.txt`: parse
  1,216/1,216, layout lines over 120 3,323 in, 71 out, 27 created (v9: 1,263 out, 917 created), G1 1,214/1,216,
  11 parse-guard blocks):
  - root causes of guard blocks, each fixed: a lambda, `match`, `function`, `typecase` or `if` that is a tuple item
    other than the last keeps its parentheses (laid bare it swallowed the following items:
    `fun symbols => ..., finite_alphabet_cardinality descriptor`); a head annotation whose packed lines would break
    an application at the column it started on (packing past a `*`) is laid by `layoutType` (`: part *` / parts at the
    same column, arguments at +4), so `:` stays on the first type line;
  - G1 fixes: an application whose single argument is a parenthesized group that does not fit always opens it on the
    callee line (`f (` / inner / `)`), decided on the whole application rather than on the argument at its own
    indentation (the second pass saw the argument fit one column further left); a parenthesized pure application
    that is an operand of an operator chain loses its parentheses (`(f a b) && g` = `f a b && g`; flatten adds them
    back on the second pass otherwise);
  - layout: a union case with a vanilla `:` payload breaks after `:` like `::`; tuple patterns open recursively
    (`Ctor (` / `Ctor (` / items) and the `_`-first tuple bug of 03:20 is fixed in the component rule too; a too-long
    `join a b +. ...` puts `join` alone with the expression at +4 (breaking the chain under `join` changed the parse
    and the guard kept the block); a type record that does not fit is `{` / `field :` / type at +8 / `}`; a
    type-in-term `` `(...) `` that does not fit is `` `( `` / type at +4 / `)`; a trailing `//` remark before a `.`
    statement separator or a closing `)` stays at the end of its statement, and goes on its own line above the
    statement when the line would pass 120.
  - F10 decision change: allowlist kind `identifier`, for a line holding one identifier at least 40 columns wide that
    ends past column 116 (the zeta mega sample's 100-130 column names at their nesting depth): no break can fit such a
    line, since indentation is syntax and identifiers are not split. Keyed by the identifier's text.
  Regression subset at 11:46 code (43 user/lib/leptos/rust files + 17 sample files that failed at v11): parse 60/60,
  comments 60/60, G1 60/60, G7.2 59/60 (the negative sample whose original does not parse), 0 created overflows outside
  `identifier` lines.
- 2026-10-15 18:49 (lane A), F10 `identifier` tightened after an audit of its 30 v14 rows: the identifier must be the
  first token of its line (after an optional `|` or `(`) and end past column 118. Two rows failed the audit and were
  layout bugs, both fixed: a callee followed by plain-word arguments that do not fit with it now puts the arguments on
  their own lines (the lean negative sample), and a tuple argument opens on the callee line only when `callee (`
  fits (zeta 6316, 121 columns).
- 2026-10-15 15:33 (lane A), F10 decision change: allowlist kind `unparsable`, for a line inside a block whose
  original does not parse (the guard never lays such a block out, since two broken texts can give the same error
  shape); today 1 line, the head of `negative_quantified_no_closed_false_inhabited_empty_match`. Also fixed in the
  same pass: a `= join` that ends a definition head absorbs the block below it in flatten (the omniledger block the
  guard kept since v9; all 600 omniledger blocks now lay out with the same parse), split string pieces are sized by
  display width (a Hangul piece in agile.spi reached 124), and an annotation laid by `layoutType` is measured with
  its `: ` prefix.
- 2026-10-15 08:40 (lane A), F10 tooling: `format --list` writes `file<TAB>allow<TAB>kind<TAB>sha256<TAB>width` for
  every over-120 line outside ``` fences whose construct is a literal, a comment or opaque text (the key is the
  literal's own text for literals, the trimmed line otherwise); `allowlist.tsv` is built from those rows only.
  Layout constructs are never allowlisted.

## How to run (Phase 4, 2026-10-16)

- Code: the `/// ## Formatter` section of `apps/compiler/spiral_compiler.fs`, shared by both cores, just before the
  `GraphIdentity` pair: modules `FormatterLexed`, `FormatterParsed`, `FormatterSpacing`, `FormatterCheck`,
  `FormatterConvert`, `FormatterFlatten`, `FormatterLayout`, `FormatterFormat` (the eight lane A `.fsx` files, moved
  by the same anchored-patch method as the other packs) and `FormatterCli`.
- Files: `SpiralCompiler format <file|dir>... [--check] [--no-split-literals]` formats in place, splitting long
  literals by default (the configuration every scoreboard row above was measured with). `--check` changes nothing,
  prints `would change: <file>` and `<file>:<line>:121: over-120 (<n> columns)` (display width), and exits 1 when a
  file would change. `--stdin --path <p>` formats the buffer on stdin to stdout as UTF-8, with the edition taken from
  the `package.spiproj` nearest to `<p>`. A directory is searched for `.spi`/`.spir`, skipping `target`,
  `node_modules`, `deps`, `bin`, `obj`, `_build` and `.git`. Both modes run on a 1 GB-stack thread: a flattened
  block can be one line of tens of thousands of lexemes (`samples/typecheck_long_let_body`), and layout recurses per
  sibling.
- Corpus: `pwsh tmp/formatter/format.ps1 format [--split-literals] [--list out.txt] [--out dir] corpus.tsv` runs the
  installed host's `format-corpus` (also `check`, `space`, `convert`, `flatten`); `corpus.ps1 -Out corpus.tsv` builds
  the corpus TSV (`corpus<TAB>edition<TAB>path<TAB>relative path`). The listing names every kept-verbatim block with
  its reason, every created overflow, and G1/G7.2/parse/comment failures.
- Zed: `spiral-zed` answers `textDocument/formatting` with one whole-document edit from `format --stdin`;
  `spiral-zed --dotnet <dotnet> --compiler <dll> --format <file>` prints the file with that edit applied.
- `lint.ps1` is G6 over the section (exceptions by module). `report.ps1` is the CI lint: the nightly compiler job runs
  `format --check` over `lib` and `apps` (not `apps/tibia`) and writes `runs/format-check.txt`; it never fails the
  build. G3 is still the job-scratch lane script.

## Open threads (main thread, 2026-10-16 18:35)

- Phase 4 landed as pack-1z (installed in both modes 2026-10-16 17:22/17:29): the core section, the host `format`
  and `format-corpus` subcommands, the Zed `textDocument/formatting` answer, `lint.ps1` over the section, and
  `report.ps1` in the nightly compiler job. The eight `.fsx` files and `sync-core.ps1` are now redundant
  (`format.ps1` calls the installed host); they stay in the tree until the user removes them.
- Gate 4, front ends: the `.fsx` corpus run and the installed host's `format-corpus format` over the same corpus
  (apps 15, eoie 492, lib 77, samples 1,226) wrote byte-identical files (1,810/1,810 sha256), identical listings and
  identical tallies (68 lines): parse-same and comments-same 1,810/1,810, no G1 failure, G7.2 1,801/1,810, created
  overflows 12 (samples). The host's `--stdin` output, its in-place write and the Zed helper's edit applied to the
  file were byte-identical on 4 files (lib `convert`, `sm'`, `frontier_fib`, a non-ASCII buffer), and over the
  whole corpus the Zed helper's edit applied to each file equals the host's `--stdin` output on 1,810/1,810 files
  (2026-10-16 20:43, 3,912 s). Not met yet: the `eoie format` verb (eoie's CLI layer is `rust_global` text, so the verb is
  a granular-Spiral eoie task), Zed verified inside Zed, and a first CI run of the report.
- `report.ps1` run locally on the installed host (2026-10-16 19:12, default `--split-literals`): 726 s,
  1,222 files would change, 44 lines over 120 after formatting (lib 12, the same fenced lines as v10; apps 32).
- `format.ps1` and `report.ps1` set `DOTNET_GCgen0size=0x10000000` (256 MB gen0, as `test.ps1`) unless it is set:
  the lib corpus (`format-corpus format`, 77 files, machine otherwise idle) took 451 s with the default budget and 408 s
  with 256 MB, outputs byte-identical. The first round (574 / 445 s) overlapped another job and is not counted.
- Found by Gate 4: `samples/typecheck_long_let_body` (2,000 chained lets) crashed every earlier corpus run.
  `shapeOf` threw at its 4,000 depth guard, and behind it `Layout.nodesOf` overflowed the stack on the 16k-lexeme
  flattened line. `shapeOf` is now an explicit work stack with no limit (old and new shape hashes identical on the
  1,302 lib and samples files the old code handled), and both entry points run on a 1 GB-stack thread. Layout's two
  core feature probes were removed: inside the core they were eager top-level values, run at every compile's module
  initialization, and constant true since packs 1e and 1g.
## Open threads (lane A, 2026-10-15 18:10, updated 20:00)

- Final code is 18:49 (v16: samples, lib, apps). eoie and user were last run on the 15:33 code (eoie output
  byte-identical to v12; the 43-file user/lib regression subset passes on 18:49 code). Next: the nesting-budget rule
  for the 12 layout-created identifier lines, then Phase 4.

- Gate 2 numbers at the 15:33 code: G1 and parse on every corpus (user 86, lib 77, apps 14, samples 1,216, eoie 482,
  agile), G3 on every sample package (863, plus the v14 delta) and every eoie package with a `main` (131), G4 met
  with `allowlist.tsv` (27 keys), G6 lint 0 hits (18:15), G5 on the user corpus (two processes, 15:33 code): 86 files,
  0 byte differences (18:35).
- G7.2 differences left are blocks whose original does not parse (lib `test ... static` bodies, eoie negatives,
  sample negative fixtures).
- Phase 4 (compiler section, host `format` subcommand, eoie verb, Zed) is still design only.

## Open threads (lane A, 2026-10-15 03:10, superseded above)

- Final code is 06:05 (03:20 code minus the reverted type rules). Full-corpus numbers on near-final code exist for
  user (v10) and lib/apps (v10, both run with the since-reverted type rules; the v10 lib/apps output still compiles apps/spiral,
  apps/wasm and apps/kino/spi to identical residuals on pack-1g, 05:56); beyond those, numbers exist only for the 43-file regression subset and the two
  largest mega samples; user, lib/apps, eoie and samples were last run on the 23:10-01:00 code (scoreboard v9). The
  02:30 refused-block fix changes output only for blocks flatten refuses (they are now byte-for-byte as written).
- Samples: 917 created overflows at 01:00 code, mostly mega samples (long applications with nested parenthesized
  arguments, arm patterns, heads); the 02:30-02:45 type rules cut the two largest files from 320 to 66 but were reverted at 06:05
  (G3 failure the parse check missed); type layout changes need a type-level G3 before they land.
- G7.2 differences left are blocks whose original does not parse (`test ... static` bodies in lib, eoie
  `path_tag_contract` and the negative fixture, mega samples): `format p` keeps them as written and
  `format (flatten p)` keeps the flat line. Excluding such blocks from G7.2 is a measurement decision not taken.
- G4 needs `allowlist.tsv` (F10): the lines over 120 left outside ``` fences are macros the splitter cannot cut
  (refused blocks with `#if` macro lines, macros whose cut would land inside a string), and comments that are one word.
- Phase 4 is designed (section above), not built: the formatter section in `spiral_compiler.fs`, the host
  `format` subcommand, `eoie format`, the Zed `textDocument/formatting` answer.
- The agile writer still waits for eoie's block reader (EOIE-AGILE-FORMATTED-WRITER, lane B's verbs); the formatter
  side is ready (agile.spi: same parse, G1, 0 lines over 120).