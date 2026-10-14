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
| 1 | | | |
| 2 | | | |
| 3 | | | |
| 4 | | | |

Phase 0 detail:
- spacing diff: user corpus 29 of 14,689; current lib 68 of 18,977; CLIs 0 of 841;
- literal kinds: 230 plain strings, 42 macros.

## Decision changes

- (none yet)
