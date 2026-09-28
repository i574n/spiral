use std::borrow::Cow;
use std::collections::BTreeSet;
use std::fmt::{Display, Formatter};
use std::marker::PhantomData;
use std::path::PathBuf;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Raw;
#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Scanned;
#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Linked;

#[derive(Clone, Copy, Debug, Eq, PartialEq, Ord, PartialOrd)]
pub struct DeclarationId(pub usize);

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub struct LineSpan {
    pub start: usize,
    pub end: usize,
}

impl LineSpan {
    #[must_use]
    pub fn line_count(self) -> usize {
        self.end.saturating_sub(self.start)
    }
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum CompilerProfile {
    PreHopac,
    Hopac,
    PortableFork,
    Unknown,
}

impl Display for CompilerProfile {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        formatter.write_str(match self {
            Self::PreHopac => "pre-hopac",
            Self::Hopac => "hopac",
            Self::PortableFork => "portable-fork",
            Self::Unknown => "unknown",
        })
    }
}

#[must_use]
pub fn ambient_type_target(line: &str) -> Option<&str> {
    line.trim().strip_prefix("open type ")
}

#[must_use]
pub fn rewrite_ambient_type_open<'a, F>(
    line: &'a str,
    provider: F,
    dependencies: &BTreeSet<usize>,
) -> Cow<'a, str>
where
    F: FnOnce(&str) -> Option<usize>,
{
    let Some(target) = ambient_type_target(line) else {
        return Cow::Borrowed(line);
    };
    let symbol = target.rsplit('.').next().unwrap_or(target);
    if target.contains('.') && provider(symbol).is_some_and(|id| dependencies.contains(&id)) {
        let indent = &line[..line.len() - line.trim_start().len()];
        Cow::Owned(format!("{indent}open type {symbol}"))
    } else {
        Cow::Borrowed(line)
    }
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum DeclarationKind {
    TypeGroup,
    LetGroup,
    Module,
    Exception,
    Directive,
    Value,
    Other,
}

impl Display for DeclarationKind {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        formatter.write_str(match self {
            Self::TypeGroup => "type",
            Self::LetGroup => "let",
            Self::Module => "module",
            Self::Exception => "exception",
            Self::Directive => "directive",
            Self::Value => "value",
            Self::Other => "other",
        })
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum BoundaryReason {
    TopLevel(DeclarationKind),
    NestedModule {
        module_name: String,
        ordinal: usize,
        inner: Box<BoundaryReason>,
    },
    AttachedTrivia {
        lines: usize,
        inner: Box<BoundaryReason>,
    },
    Guarded {
        directive_depth: usize,
        inner: Box<BoundaryReason>,
    },
}

impl BoundaryReason {
    #[must_use]
    pub fn kind(&self) -> DeclarationKind {
        match self {
            Self::TopLevel(kind) => *kind,
            Self::NestedModule { inner, .. }
            | Self::AttachedTrivia { inner, .. }
            | Self::Guarded { inner, .. } => inner.kind(),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct SourceText {
    pub path: PathBuf,
    pub lines: Vec<String>,
    pub module_line: usize,
    pub module_name: String,
    pub profile: CompilerProfile,
    pub fingerprint: u64,
    pub bytes: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum DeclarationScope {
    Root,
    ModuleFragment {
        module_name: String,
        ordinal: usize,
        prefix_lines: usize,
        dedent_spaces: usize,
    },
}

impl DeclarationScope {
    #[must_use]
    pub fn module_name(&self) -> Option<&str> {
        match self {
            Self::Root => None,
            Self::ModuleFragment { module_name, .. } => Some(module_name),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct DependencyWitness {
    pub symbol: String,
    pub provider: DeclarationId,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct Declaration<S> {
    pub id: DeclarationId,
    pub span: LineSpan,
    pub heading: String,
    pub text: String,
    pub boundary: BoundaryReason,
    pub scope: DeclarationScope,
    pub ambient_opens: Vec<String>,
    pub definitions: BTreeSet<String>,
    pub references: BTreeSet<String>,
    pub direct_dependencies: BTreeSet<DeclarationId>,
    pub closure_dependencies: BTreeSet<DeclarationId>,
    pub witnesses: Vec<DependencyWitness>,
    pub fingerprint: u64,
    stage: PhantomData<fn() -> S>,
}

impl<S> Declaration<S> {
    #[must_use]
    pub fn new(
        id: DeclarationId,
        span: LineSpan,
        heading: String,
        text: String,
        boundary: BoundaryReason,
        ambient_opens: Vec<String>,
        fingerprint: u64,
    ) -> Self {
        Self {
            id,
            span,
            heading,
            text,
            boundary,
            scope: DeclarationScope::Root,
            ambient_opens,
            definitions: BTreeSet::new(),
            references: BTreeSet::new(),
            direct_dependencies: BTreeSet::new(),
            closure_dependencies: BTreeSet::new(),
            witnesses: Vec::new(),
            fingerprint,
            stage: PhantomData,
        }
    }

    #[must_use]
    pub fn with_scope(mut self, scope: DeclarationScope) -> Self {
        self.scope = scope;
        self
    }

    #[must_use]
    pub fn line_count(&self) -> usize {
        self.span.line_count()
    }

    /// The declaration's weight for shard and gear planning, see [`planning_lines`].
    #[must_use]
    pub fn planning_line_count(&self) -> usize {
        planning_lines(self.line_count())
    }

    #[must_use]
    pub fn restage<T>(self) -> Declaration<T> {
        Declaration {
            id: self.id,
            span: self.span,
            heading: self.heading,
            text: self.text,
            boundary: self.boundary,
            scope: self.scope,
            ambient_opens: self.ambient_opens,
            definitions: self.definitions,
            references: self.references,
            direct_dependencies: self.direct_dependencies,
            closure_dependencies: self.closure_dependencies,
            witnesses: self.witnesses,
            fingerprint: self.fingerprint,
            stage: PhantomData,
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct Program<S> {
    pub source: SourceText,
    pub declarations: Vec<Declaration<S>>,
    stage: PhantomData<fn() -> S>,
}

impl<S> Program<S> {
    #[must_use]
    pub fn new(source: SourceText, declarations: Vec<Declaration<S>>) -> Self {
        Self {
            source,
            declarations,
            stage: PhantomData,
        }
    }

    #[must_use]
    pub fn restage<T>(self) -> Program<T> {
        Program {
            source: self.source,
            declarations: self
                .declarations
                .into_iter()
                .map(Declaration::restage)
                .collect(),
            stage: PhantomData,
        }
    }
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum SplitPolicy {
    Declaration,
    BoundedLines { max_lines: usize },
    DependencyLayer { max_lines: usize },
    ModuleAware { max_lines: usize },
}

impl SplitPolicy {
    #[must_use]
    pub fn max_lines(self) -> usize {
        match self {
            Self::Declaration => 900,
            Self::BoundedLines { max_lines }
            | Self::DependencyLayer { max_lines }
            | Self::ModuleAware { max_lines } => max_lines,
        }
    }
}

impl Display for SplitPolicy {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::Declaration => formatter.write_str("declaration"),
            Self::BoundedLines { max_lines } => write!(formatter, "bounded:{max_lines}"),
            Self::DependencyLayer { max_lines } => write!(formatter, "layered:{max_lines}"),
            Self::ModuleAware { max_lines } => write!(formatter, "module-aware:{max_lines}"),
        }
    }
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum ReferenceMode {
    Direct,
    Closure,
}

impl Display for ReferenceMode {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        formatter.write_str(match self {
            Self::Direct => "direct",
            Self::Closure => "closure",
        })
    }
}

/// Planning weight of a declaration with `lines` lines: rounded up to a multiple of 64 up to 1,024 lines,
/// then to geometric buckets 12.5% apart. The shard planner simulates its line-weighted critical path of
/// the whole program with these weights (capacity limits stay exact): with exact counts, a few lines added
/// to one body moved groups far downstream and renumbered thousands of parts (a 6-line edit in the
/// replay worklist regrouped `BigStack`). A small edit now changes a weight only when it crosses a
/// bucket boundary.
#[must_use]
pub fn planning_lines(lines: usize) -> usize {
    const STEP: usize = 64;
    const LINEAR_UNTIL: usize = 1_024;
    let lines = lines.max(1);
    if lines <= LINEAR_UNTIL {
        return lines.div_ceil(STEP) * STEP;
    }
    let mut bucket = LINEAR_UNTIL;
    while bucket < lines {
        bucket = (bucket + bucket / 8).div_ceil(STEP) * STEP;
    }
    bucket
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct Shard {
    pub id: usize,
    pub declarations: Vec<DeclarationId>,
    pub direct_dependencies: BTreeSet<usize>,
    pub compile_dependencies: BTreeSet<usize>,
    pub ambient_opens: Vec<String>,
    pub line_count: usize,
    pub bytes: usize,
    pub layer: usize,
    pub oversize: bool,
    pub fingerprint: u64,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct SplitPlan {
    pub source: SourceText,
    pub policy: SplitPolicy,
    pub reference_mode: ReferenceMode,
    pub declarations: Vec<Declaration<Linked>>,
    pub shards: Vec<Shard>,
}

#[derive(Clone, Debug, PartialEq)]
pub struct SplitMetrics {
    pub source_bytes: usize,
    pub source_lines: usize,
    pub declarations: usize,
    pub shards: usize,
    pub direct_edges: usize,
    pub compile_edges: usize,
    pub dense_baseline_edges: usize,
    pub layers: usize,
    pub widest_layer: usize,
    pub max_shard_lines: usize,
    pub p50_shard_lines: usize,
    pub p95_shard_lines: usize,
    pub oversize_shards: usize,
    /// Shards divided by layers; counts a 3-line shard like a 21k-line one. Kept for continuity.
    pub estimated_parallelism: f64,
    pub edge_reduction_ratio: f64,
    /// Line-weighted longest path through the shard compile graph.
    pub critical_path_lines: usize,
    /// Line-weighted longest path through the declaration graph: the floor that no packing can beat.
    pub declaration_critical_path_lines: usize,
    /// Total build work over critical-path work, each project costing its lines plus a fixed overhead
    /// (`PROJECT_OVERHEAD_LINES`): the speedup an unbounded worker pool could reach.
    pub work_parallelism: f64,
}

/// Fixed cost of one F# project build in line-equivalents: ~3 s of dotnet/fsc start-up at ~1.25 ms per
/// line (the 175k-line hopac core compiles in ~220 s as one project).
pub const PROJECT_OVERHEAD_LINES: usize = 2400;

#[must_use]
pub fn fnv1a64(bytes: &[u8]) -> u64 {
    bytes
        .iter()
        .fold(14_695_981_039_346_656_037u64, |hash, byte| {
            (hash ^ u64::from(*byte)).wrapping_mul(1_099_511_628_211)
        })
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn planning_lines_absorb_small_edits() {
        assert_eq!(planning_lines(0), 64);
        assert_eq!(planning_lines(64), 64);
        assert_eq!(planning_lines(65), 128);
        assert_eq!(planning_lines(1_024), 1_024);
        // Geometric buckets: 1,152, 1,344, ... never below the exact count, at most 1/8 plus a step above.
        let mut previous = 0;
        for lines in [1_025, 1_200, 4_366, 21_244] {
            let weight = planning_lines(lines);
            assert!(weight >= lines && weight <= lines + lines / 8 + 64, "{lines} -> {weight}");
            assert!(weight > previous);
            previous = weight;
        }
        // The replay worklist step (4,366 lines) keeps its weight when a 6-line fix lands in it.
        assert_eq!(planning_lines(4_360), planning_lines(4_366));
    }

    #[test]
    fn recursive_boundary_keeps_kind() {
        let reason = BoundaryReason::AttachedTrivia {
            lines: 2,
            inner: Box::new(BoundaryReason::Guarded {
                directive_depth: 1,
                inner: Box::new(BoundaryReason::TopLevel(DeclarationKind::LetGroup)),
            }),
        };
        assert_eq!(reason.kind(), DeclarationKind::LetGroup);
    }

    #[test]
    fn fingerprint_is_stable() {
        assert_eq!(fnv1a64(b"spiral"), fnv1a64(b"spiral"));
        assert_ne!(fnv1a64(b"spiral"), fnv1a64(b"Spiral"));
    }

    #[test]
    fn ambient_type_open_rewrites_only_for_a_compiled_provider() {
        let dependencies = BTreeSet::from([7]);
        let line = "    open type EvalWorklist.SemanticStatusId";
        assert_eq!(
            ambient_type_target(line),
            Some("EvalWorklist.SemanticStatusId")
        );
        assert_eq!(
            rewrite_ambient_type_open(line, |_| Some(7), &dependencies),
            "    open type SemanticStatusId"
        );
        assert_eq!(
            rewrite_ambient_type_open(line, |_| Some(8), &dependencies),
            line
        );
    }
}
