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

## How to run (lane A tooling, 2026-10-14)

- Code: `apps/compiler/tmp/formatter/` (`Lexed`, `Parsed`, `Spacing`, `Check`, `Convert`, `Flatten`, `Layout`,
  `Format` .fsx over the compiled core in `dll/`, refreshed by `sync-core.ps1` from the installed compiler).
- `dotnet fsi --quiet Format.fsx format [--split-literals] [--list out.txt] [--out dir] corpus.tsv` (also `check`,
  `space`, `convert`, `flatten`); a corpus TSV row is `corpus<TAB>edition<TAB>path<TAB>relative path`. The listing
  names every kept-verbatim block with its reason, every created overflow, and G1/G7.2/parse/comment failures.
- `lint.ps1` is G6. G3 (compile before/after, compare residual hashes) is a lane script in the job scratch
  (`lane-a/g3.ps1`); it runs single-module samples next to a copy of the samples' `core` package.

## Open threads (lane A, end of 2026-10-14)

- Re-run the full corpora with the 20:22 code (the G1 fixes were verified on the 5 failing files and a 43-file subset
  only).
- Install `patches/string-concat-typed.ps1` (next pack); until then `--split-literals` output is safe only where a
  split string's type is fixed by context. G3 with splitting on the typed candidate: identical residuals.
- Remaining parse-guard blocks: `test ... static` bodies that do not parse as an `inl` body even unformatted (lib
  physics/parsing/runtime), `}` at column 0 closing a type record (eoie `path_tag_contract`, the original fails too).
- Remaining eoie lines over 120 (15 in 482 files at 19:35 code): string arguments of `!!!!Global ("...")` (the
  intrinsic's single string argument is not split yet, longest 14,398 columns), macros holding `{ ... }` Rust blocks,
  a few long patterns, records and dotted names.
- G3 compiles to C; most of the samples that fail on both sides fail only because their `main` does not return
  i32 for the C backend, so a second pass with `-Backend Fsharp` would cover them.
- G3 so far on single-module samples only (80 without splitting, 120 with); multi-module samples and lib programs
  need the package layout copied next to them.
- Macros whose pieces would start with a space, or whose split changes the parse, stay on one line (4 lines in
  lib `file_system.spi`, 2 in the user corpus).
- Phase 4 (host subcommand, eoie verb, Zed) not started; the agile writer needs eoie's line-based agile reader
  replaced first (`EOIE-AGILE-FORMATTED-WRITER`).