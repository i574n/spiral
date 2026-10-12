mod public_surface;

use public_surface::make_public_top_level;
use rayon::prelude::*;
use spiral_split_call_contract::{
    CallerParameterType, HigherOrderArrayReturnShape, analyze_caller_contracts,
    analyze_higher_order_array_returns, apply_caller_parameter_types,
    apply_higher_order_array_returns,
};
use spiral_split_caller_projection::analyze_caller_projection_contracts;
use spiral_split_forwarded_type::analyze_forwarded_binding_contracts;
use spiral_split_lexical_open::LexicalOpenIndex;
use spiral_split_metrics::{PhaseReceipt, measure, render_oversize_tsv, render_tsv};
use spiral_split_model::{DeclarationId, DeclarationScope, Shard, SplitPlan};
use spiral_split_open_order::{
    AmbientTypeOpen, LateTypeOpenIndex, generator_fingerprint, provider_open_insertion,
    resolve_ambient_type_open, transform_fingerprint, typed_use_type_providers_by_shard,
    unique_type_providers,
};
use spiral_split_pattern_owner::{
    LocalRecordOwnerWitness, PatternOwnerWitness, analyze_local_record_owners,
    analyze_pattern_record_owners, apply_local_record_owner_witnesses,
    apply_pattern_owner_witnesses, render_local_record_owner_witnesses,
    render_pattern_owner_witnesses,
};
use spiral_split_record_owner::analyze_mutable_record_owner_contracts;
use spiral_split_record_return_owner::{
    RecordReturnOwnerWitness, analyze_record_return_owners, apply_record_return_owner_witnesses,
    render_record_return_owner_witnesses,
};
use spiral_split_text_rewrite::OrderedReplacementIndex;
use spiral_split_union_context::{
    UnionContextIndex, analyze_union_context, qualify_ambiguous_union_branches_scoped,
    qualify_duplicate_union_type_annotations_scoped, qualify_typed_union_comparisons,
};
use std::collections::{BTreeMap, BTreeSet};
use std::fmt::Write as _;
use std::fs;
use std::path::{Path, PathBuf};

#[derive(Clone, Debug)]
pub struct EmitOptions {
    pub output_root: PathBuf,
    pub cache_root: PathBuf,
    pub assembly_root: PathBuf,
    pub assembly_overlay_root: Option<PathBuf>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct EmitReceipt {
    pub shards: usize,
    pub files: usize,
    pub source_fingerprint: u64,
    pub output_root: PathBuf,
}

fn part_name(index: usize) -> String {
    format!("Part{index:04}")
}

fn module_name(index: usize) -> String {
    format!("spiral_compiler_{}", part_name(index))
}

fn atomic_write(path: &Path, text: &str) -> Result<(), String> {
    if path.is_file()
        && fs::read_to_string(path)
            .map(|existing| existing == text)
            .unwrap_or(false)
    {
        return Ok(());
    }
    let parent = path
        .parent()
        .ok_or_else(|| format!("path has no parent: {}", path.display()))?;
    fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?;
    let temporary = path.with_extension(format!("tmp-{}", std::process::id()));
    fs::write(&temporary, text)
        .map_err(|error| format!("write {}: {error}", temporary.display()))?;
    if path.exists() {
        fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?;
    }
    fs::rename(&temporary, path).map_err(|error| format!("commit {}: {error}", path.display()))
}

fn declaration_shards(plan: &SplitPlan) -> Vec<usize> {
    let mut result = vec![0usize; plan.declarations.len()];
    for shard in &plan.shards {
        for declaration in &shard.declarations {
            result[declaration.0] = shard.id;
        }
    }
    result
}

fn identifier_suffix(value: &str) -> bool {
    let mut chars = value.chars();
    let Some(first) = chars.next() else {
        return false;
    };
    (first == '_' || first.is_alphabetic())
        && chars
            .all(|character| character == '_' || character == '\'' || character.is_alphanumeric())
}

fn declares_symbol(text: &str, keyword: &str, symbol: &str) -> bool {
    let prefix = format!("{keyword} {symbol}");
    text.lines().map(str::trim_start).any(|line| {
        line.strip_prefix(&prefix).is_some_and(|rest| {
            rest.is_empty()
                || rest.starts_with(char::is_whitespace)
                || rest.starts_with(['=', '<', '('])
        })
    })
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct CompanionRewrite {
    provider: usize,
    suffix: String,
    alias: String,
    target: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct QualifiedRewritePlan {
    replacements: Vec<(String, String)>,
    qualified_members: Vec<(String, String)>,
    replacement_index: OrderedReplacementIndex,
    qualified_member_index: OrderedReplacementIndex,
    companions: Vec<CompanionRewrite>,
}

fn companion_alias_name(provider: usize, suffix: &str) -> String {
    format!("split_companion_{provider:04}_{suffix}")
}

fn qualified_replacements(plan: &SplitPlan) -> QualifiedRewritePlan {
    let declaration_shards = declaration_shards(plan);
    let resolved_companions =
        spiral_split_companion_resolve::resolve_module_abbreviations(plan, &declaration_shards);
    let mut shapes = BTreeMap::<String, (usize, BTreeSet<usize>, BTreeSet<usize>)>::new();
    for declaration in &plan.declarations {
        let shard = declaration_shards[declaration.id.0];
        for definition in &declaration.definitions {
            if let Some((_, suffix)) = definition.rsplit_once('.')
                && identifier_suffix(suffix)
            {
                let shape = shapes
                    .entry(definition.clone())
                    .or_insert_with(|| (shard, BTreeSet::new(), BTreeSet::new()));
                if declares_symbol(&declaration.text, "type", suffix) {
                    shape.1.insert(shard);
                }
                if declares_symbol(&declaration.text, "module", suffix) {
                    shape.2.insert(shard);
                }
            }
        }
    }
    let mut companion_names = BTreeMap::<String, usize>::new();
    for (definition, (_, type_providers, module_providers)) in &shapes {
        if type_providers.len() == 1
            && module_providers.len() == 1
            && let Some((_, suffix)) = definition.rsplit_once('.')
        {
            *companion_names.entry(suffix.to_owned()).or_default() += 1;
        }
    }
    let mut companions = Vec::new();
    let mut replacements = Vec::new();
    let mut qualified_members = Vec::new();
    for (definition, (first_provider, type_providers, module_providers)) in shapes {
        let suffix = definition.rsplit_once('.').map_or("", |(_, suffix)| suffix);
        let type_provider = type_providers
            .iter()
            .next()
            .copied()
            .unwrap_or(first_provider);
        let module_provider = module_providers
            .iter()
            .next()
            .copied()
            .unwrap_or(first_provider);
        let unique_companion = type_providers.len() == 1
            && module_providers.len() == 1
            && companion_names.get(suffix).copied() == Some(1);
        let generated = if unique_companion {
            let alias = companion_alias_name(module_provider, suffix);
            qualified_members.push((format!("{definition}."), format!("{alias}.")));
            companions.push(CompanionRewrite {
                provider: module_provider,
                suffix: suffix.to_owned(),
                alias,
                target: resolved_companions
                    .get(&(module_provider, suffix.to_owned()))
                    .cloned()
                    .unwrap_or_else(|| format!("{}.{}", module_name(module_provider), suffix)),
            });
            if type_provider == module_provider {
                suffix.to_owned()
            } else {
                format!("{}.{}", module_name(type_provider), suffix)
            }
        } else {
            format!("{}.{}", module_name(first_provider), suffix)
        };
        replacements.push((definition, generated));
    }
    replacements.sort_by(|left, right| right.0.len().cmp(&left.0.len()).then(left.0.cmp(&right.0)));
    qualified_members
        .sort_by(|left, right| right.0.len().cmp(&left.0.len()).then(left.0.cmp(&right.0)));
    companions.sort_by(|left, right| {
        left.provider
            .cmp(&right.provider)
            .then(left.suffix.cmp(&right.suffix))
    });
    let replacement_index = OrderedReplacementIndex::new(&replacements);
    let qualified_member_index = OrderedReplacementIndex::new(&qualified_members);
    QualifiedRewritePlan {
        replacements,
        qualified_members,
        replacement_index,
        qualified_member_index,
        companions,
    }
}

fn companion_identifier_character(character: char) -> bool {
    character == '_' || character == '\'' || character.is_alphanumeric()
}

fn replace_companion_member_access(text: &str, suffix: &str, alias: &str) -> String {
    let needle = format!("{suffix}.");
    let replacement = format!("{alias}.");
    let mut output = String::with_capacity(text.len());
    let mut remaining = text;
    while let Some(index) = remaining.find(&needle) {
        let (before, matched) = remaining.split_at(index);
        output.push_str(before);
        let at_identifier_boundary = output
            .chars()
            .next_back()
            .is_none_or(|character| character != '.' && !companion_identifier_character(character));
        output.push_str(if at_identifier_boundary {
            &replacement
        } else {
            &needle
        });
        remaining = &matched[needle.len()..];
    }
    output.push_str(remaining);
    output
}

fn promote_internal_binding(line: &str) -> String {
    let trimmed = line.trim_start();
    let leading = &line[..line.len() - trimmed.len()];
    const REPLACEMENTS: [(&str, &str); 7] = [
        ("let rec internal ", "let rec "),
        ("let inline internal ", "let inline "),
        ("let internal inline ", "let inline "),
        ("let mutable internal ", "let mutable "),
        ("let internal mutable ", "let mutable "),
        ("let internal ", "let "),
        ("and internal ", "and "),
    ];
    for (from, to) in REPLACEMENTS {
        if let Some(rest) = trimmed.strip_prefix(from) {
            return format!("{leading}{to}{rest}");
        }
    }
    line.to_owned()
}

fn promote_companion_internal_members(
    text: &str,
    rewrite_plan: &QualifiedRewritePlan,
    current_shard: usize,
) -> String {
    let module_headers = rewrite_plan
        .companions
        .iter()
        .filter(|companion| companion.provider == current_shard)
        .map(|companion| format!("module {} =", companion.suffix))
        .collect::<BTreeSet<_>>();
    if module_headers.is_empty() {
        return text.to_owned();
    }
    let mut active_module_indent = None;
    let mut output = Vec::new();
    for line in text.lines() {
        let trimmed = line.trim_start();
        let indent = line.len() - trimmed.len();
        if let Some(module_indent) = active_module_indent
            && !trimmed.is_empty()
            && indent <= module_indent
        {
            active_module_indent = None;
        }
        if module_headers.contains(trimmed) {
            active_module_indent = Some(indent);
            output.push(line.to_owned());
            continue;
        }
        if active_module_indent.is_some_and(|module_indent| indent == module_indent + 4) {
            output.push(promote_internal_binding(line));
        } else {
            output.push(line.to_owned());
        }
    }
    let mut result = output.join(&char::from(10).to_string());
    if text.as_bytes().last() == Some(&10) {
        result.push(char::from(10));
    }
    result
}

fn annotate_string_overload_parameters(text: &str) -> String {
    let lines = text.lines().collect::<Vec<_>>();
    let mut output = Vec::with_capacity(lines.len());
    for (index, line) in lines.iter().enumerate() {
        let trimmed = line.trim_start();
        let indent = line.len() - trimmed.len();
        let mut rewritten = (*line).to_owned();
        if let Some(binding) = trimmed.strip_prefix("let ")
            && let Some((head, _)) = binding.split_once('=')
        {
            let mut tokens = head.split_whitespace();
            if let (Some(name), Some(parameter), None) =
                (tokens.next(), tokens.next(), tokens.next())
                && !parameter.starts_with('(')
            {
                let mut end = index + 1;
                while end < lines.len() {
                    let candidate = lines[end];
                    if !candidate.trim().is_empty()
                        && candidate.len() - candidate.trim_start().len() <= indent
                    {
                        break;
                    }
                    end += 1;
                }
                let body = lines[index..end].join(&char::from(10).to_string());
                let starts_with = format!(".StartsWith({parameter},");
                let ends_with = format!(".EndsWith({parameter},");
                if body.contains(&starts_with) || body.contains(&ends_with) {
                    let needle = format!("let {name} {parameter} =");
                    let replacement = format!("let {name} ({parameter}: string) =");
                    rewritten = line.replacen(&needle, &replacement, 1);
                }
            }
        }
        output.push(rewritten);
    }
    let mut result = output.join(&char::from(10).to_string());
    if text.as_bytes().last() == Some(&10) {
        result.push(char::from(10));
    }
    result
}

struct RenderDeclarationContext<'a> {
    plan: &'a SplitPlan,
    current_shard: usize,
    rewrite_plan: &'a QualifiedRewritePlan,
    caller_parameter_types: &'a BTreeMap<DeclarationId, Vec<CallerParameterType>>,
    type_providers: &'a BTreeMap<String, usize>,
    higher_order_array_returns: &'a BTreeMap<DeclarationId, Vec<HigherOrderArrayReturnShape>>,
    pattern_owner_witnesses: &'a BTreeMap<DeclarationId, Vec<PatternOwnerWitness>>,
    local_record_owner_witnesses: &'a BTreeMap<DeclarationId, Vec<LocalRecordOwnerWitness>>,
    record_return_owner_witnesses: &'a BTreeMap<DeclarationId, Vec<RecordReturnOwnerWitness>>,
    numeric_conversion_helpers: &'a BTreeSet<String>,
}

fn render_declaration(declaration_id: usize, context: &RenderDeclarationContext<'_>) -> String {
    let declaration = &context.plan.declarations[declaration_id];
    let return_typed = context
        .record_return_owner_witnesses
        .get(&declaration.id)
        .map_or_else(
            || declaration.text.clone(),
            |witnesses| apply_record_return_owner_witnesses(&declaration.text, witnesses),
        );
    let local_typed = context
        .local_record_owner_witnesses
        .get(&declaration.id)
        .map_or_else(
            || return_typed.clone(),
            |witnesses| apply_local_record_owner_witnesses(&return_typed, witnesses),
        );
    let pattern_typed = context
        .pattern_owner_witnesses
        .get(&declaration.id)
        .map_or_else(
            || local_typed.clone(),
            |witnesses| apply_pattern_owner_witnesses(&local_typed, witnesses),
        );
    let caller_typed = context
        .caller_parameter_types
        .get(&declaration.id)
        .map_or_else(
            || pattern_typed.clone(),
            |witnesses| {
                let qualified = witnesses
                    .iter()
                    .cloned()
                    .map(|mut witness| {
                        match context.type_providers.get(&witness.type_symbol).copied() {
                            Some(provider) if provider != context.current_shard => {
                                witness.type_symbol =
                                    format!("{}.{}", module_name(provider), witness.type_symbol);
                            }
                            _ => {}
                        }
                        witness
                    })
                    .collect::<Vec<_>>();
                apply_caller_parameter_types(&pattern_typed, &qualified)
            },
        );
    let higher_order_typed = context
        .higher_order_array_returns
        .get(&declaration.id)
        .map_or_else(
            || caller_typed.clone(),
            |witnesses| apply_higher_order_array_returns(&caller_typed, witnesses),
        );
    let qualified = rewrite_qualified(
        &higher_order_typed,
        context.rewrite_plan,
        context.current_shard,
    );
    let accessible =
        promote_companion_internal_members(&qualified, context.rewrite_plan, context.current_shard);
    let rewritten = annotate_string_overload_parameters(&accessible);
    let (prefix_lines, dedent_spaces) = match &declaration.scope {
        DeclarationScope::Root => (0, 0),
        DeclarationScope::ModuleFragment {
            prefix_lines,
            dedent_spaces,
            ..
        } => (*prefix_lines, *dedent_spaces),
    };
    let prefix = " ".repeat(dedent_spaces);
    let mut body = rewritten
        .lines()
        .skip(prefix_lines)
        .map(|line| {
            if dedent_spaces == 0 {
                line
            } else {
                line.strip_prefix(&prefix).unwrap_or(line)
            }
        })
        .collect::<Vec<_>>()
        .join("\n");
    if rewritten.as_bytes().last() == Some(&b'\n') {
        body.push('\n');
    }
    let phantom_safe = spiral_split_visibility::stabilize_operational_work_factories(&body);
    let format_inference_safe =
        spiral_split_visibility::preserve_private_numeric_format_inference(&phantom_safe);
    let conversion_inference_safe =
        spiral_split_visibility::preserve_numeric_conversion_inference_with_helpers(
            &format_inference_safe,
            context.numeric_conversion_helpers,
        );
    let inline_safe =
        spiral_split_visibility::promote_inline_private_dependencies(&conversion_inference_safe);
    let representation_safe =
        spiral_split_visibility::promote_single_line_private_representations(&inline_safe);
    let multiline_safe =
        spiral_split_visibility::promote_multiline_private_representations(&representation_safe);
    let mut output = String::new();
    for line in multiline_safe.lines() {
        output.push_str(&make_public_top_level(line));
        output.push('\n');
    }
    output
}

fn source_open_dependencies(shard: &Shard) -> &BTreeSet<usize> {
    &shard.direct_dependencies
}

fn source_open_buckets(shards: &[Shard], shard: &Shard) -> Vec<Vec<usize>> {
    let mut buckets = vec![Vec::new(); shard.ambient_opens.len() + 1];
    for dependency in source_open_dependencies(shard) {
        let provider = &shards[*dependency];
        let insertion = provider_open_insertion(&provider.ambient_opens, &shard.ambient_opens);
        buckets[insertion].push(*dependency);
    }
    buckets
}

fn is_split_source_module_open(open_line: &str, split_source_modules: &BTreeSet<&str>) -> bool {
    open_line
        .trim()
        .strip_prefix("open ")
        .is_some_and(|module| split_source_modules.contains(module))
}

fn remove_split_source_module_opens(text: &str, split_source_modules: &BTreeSet<&str>) -> String {
    let mut result = text
        .lines()
        .filter(|line| !is_split_source_module_open(line, split_source_modules))
        .collect::<Vec<_>>()
        .join(&char::from(10).to_string());
    if text.as_bytes().last() == Some(&10) {
        result.push(char::from(10));
    }
    result
}

fn render_open_prelude(
    shards: &[Shard],
    shard: &Shard,
    split_source_modules: &BTreeSet<&str>,
    type_providers: &BTreeMap<String, usize>,
) -> String {
    let mut output = String::new();
    let buckets = source_open_buckets(shards, shard);
    for dependency in &buckets[0] {
        let _ = writeln!(output, "    open {}", module_name(*dependency));
    }
    for (index, open_line) in shard.ambient_opens.iter().enumerate() {
        let open_line = match resolve_ambient_type_open(
            open_line,
            |symbol| type_providers.get(symbol).copied(),
            &shard.compile_dependencies,
        ) {
            AmbientTypeOpen::Preserve(line) => line.to_owned(),
            AmbientTypeOpen::Split {
                indent,
                provider,
                symbol,
            } => format!("{indent}open type {}.{symbol}", module_name(provider)),
        };
        if !is_split_source_module_open(&open_line, split_source_modules) {
            output.push_str(&open_line);
        }
        output.push('\n');
        for dependency in &buckets[index + 1] {
            let _ = writeln!(output, "    open {}", module_name(*dependency));
        }
    }
    if shard
        .ambient_opens
        .iter()
        .any(|open_line| open_line.trim() == "open FParsec")
    {
        output.push_str("    open Microsoft.FSharp.Core\n");
    }
    if !shard.ambient_opens.is_empty() || !shard.direct_dependencies.is_empty() {
        output.push('\n');
    }
    output
}

fn type_symbol_after_attributes(mut text: &str) -> &str {
    text = text.trim_start();
    while let Some(rest) = text.strip_prefix("[<") {
        let Some(end) = rest.find(">]") else {
            break;
        };
        text = rest[end + 2..].trim_start();
    }
    text
}

fn declares_type_symbol(text: &str, symbol: &str) -> bool {
    text.lines().map(str::trim_start).any(|line| {
        ["type ", "and "].into_iter().any(|keyword| {
            let Some(rest) = line.strip_prefix(keyword) else {
                return false;
            };
            let rest = type_symbol_after_attributes(rest);
            rest.strip_prefix(symbol).is_some_and(|tail| {
                tail.is_empty()
                    || tail.starts_with(char::is_whitespace)
                    || tail.starts_with(['=', '<', '('])
            })
        })
    })
}

fn render_missing_provider_opens(
    candidates: impl IntoIterator<Item = usize>,
    already_opened: &BTreeSet<usize>,
) -> String {
    let mut output = String::new();
    for provider in candidates {
        if already_opened.contains(&provider) {
            continue;
        }
        let _ = writeln!(output, "    open {}", module_name(provider));
    }
    if !output.is_empty() {
        output.push('\n');
    }
    output
}

fn render_late_type_opens(
    plan: &SplitPlan,
    shard: &Shard,
    late_type_open_index: &LateTypeOpenIndex,
    providers: &BTreeMap<String, usize>,
    typed_providers: Option<&BTreeSet<usize>>,
    caller_contract_providers: Option<&[usize]>,
    already_opened: &BTreeSet<usize>,
) -> String {
    render_missing_provider_opens(
        late_type_open_index.candidates(
            plan,
            shard,
            providers,
            typed_providers,
            caller_contract_providers,
        ),
        already_opened,
    )
}

fn qualify_ambient_cases(text: String, ambient_opens: &[String]) -> String {
    if ambient_opens
        .iter()
        .any(|open_line| open_line.trim() == "open FParsec")
    {
        text.replace("| Success(", "| FParsec.CharParsers.Success(")
            .replace("| Failure(", "| FParsec.CharParsers.Failure(")
    } else {
        text
    }
}

fn render_companion_aliases(shard: &Shard, rewrite_plan: &QualifiedRewritePlan) -> String {
    let mut output = String::new();
    for companion in rewrite_plan.companions.iter().filter(|companion| {
        companion.provider != shard.id && shard.direct_dependencies.contains(&companion.provider)
    }) {
        let _ = writeln!(
            output,
            "    module {} = {}",
            companion.alias, companion.target
        );
    }
    if !output.is_empty() {
        output.push('\n');
    }
    output
}

fn provider_open_order(text: &str) -> Vec<usize> {
    text.lines()
        .filter_map(|line| {
            line.trim()
                .strip_prefix("open spiral_compiler_Part")
                .and_then(|tail| {
                    let digits = tail
                        .chars()
                        .take_while(char::is_ascii_digit)
                        .collect::<String>();
                    (!digits.is_empty())
                        .then(|| digits.parse::<usize>().ok())
                        .flatten()
                })
        })
        .collect()
}

fn collect_numeric_conversion_helpers(plan: &SplitPlan) -> BTreeSet<String> {
    plan.declarations
        .iter()
        .flat_map(|declaration| {
            let (prefix_lines, dedent_spaces) = match &declaration.scope {
                DeclarationScope::Root => (0, 0),
                DeclarationScope::ModuleFragment {
                    prefix_lines,
                    dedent_spaces,
                    ..
                } => (*prefix_lines, *dedent_spaces),
            };
            let prefix = " ".repeat(dedent_spaces);
            let body = declaration
                .text
                .lines()
                .skip(prefix_lines)
                .map(|line| {
                    if dedent_spaces == 0 {
                        line
                    } else {
                        line.strip_prefix(&prefix).unwrap_or(line)
                    }
                })
                .collect::<Vec<_>>()
                .join("\n");
            spiral_split_visibility::numeric_conversion_helper_names(&body)
        })
        .collect()
}

struct RenderSourceContext<'a> {
    rewrite_plan: &'a QualifiedRewritePlan,
    split_source_modules: &'a BTreeSet<&'a str>,
    type_providers: &'a BTreeMap<String, usize>,
    late_type_open_index: &'a LateTypeOpenIndex,
    typed_use_providers: &'a BTreeMap<usize, BTreeSet<usize>>,
    caller_contract_providers: &'a BTreeMap<usize, Vec<usize>>,
    caller_parameter_types: &'a BTreeMap<DeclarationId, Vec<CallerParameterType>>,
    higher_order_array_returns: &'a BTreeMap<DeclarationId, Vec<HigherOrderArrayReturnShape>>,
    pattern_owner_witnesses: &'a BTreeMap<DeclarationId, Vec<PatternOwnerWitness>>,
    local_record_owner_witnesses: &'a BTreeMap<DeclarationId, Vec<LocalRecordOwnerWitness>>,
    record_return_owner_witnesses: &'a BTreeMap<DeclarationId, Vec<RecordReturnOwnerWitness>>,
    numeric_conversion_helpers: &'a BTreeSet<String>,
    union_context: &'a UnionContextIndex,
    lexical_open_index: &'a LexicalOpenIndex,
    declaration_shards: &'a [usize],
}

/// The name bound by a single-line module abbreviation (`module X = A.B`), if the declaration is one.
fn module_abbreviation_name(text: &str) -> Option<&str> {
    let line = text
        .lines()
        .map(str::trim)
        .find(|line| !line.is_empty() && !line.starts_with("//"))?;
    let rest = line.strip_prefix("module ")?;
    let (name, target) = rest.split_once('=')?;
    let name = name.trim();
    let target = target.trim();
    (!target.is_empty() && identifier_suffix(name) && target.split('.').all(identifier_suffix)).then_some(name)
}

fn render_source(plan: &SplitPlan, shard: &Shard, context: &RenderSourceContext<'_>) -> String {
    let mut output = format!("namespace Polyglot\n\nmodule {} =\n", module_name(shard.id));
    let open_prelude = render_open_prelude(
        &plan.shards,
        shard,
        context.split_source_modules,
        context.type_providers,
    );
    let already_opened = provider_open_order(&open_prelude)
        .into_iter()
        .collect::<BTreeSet<_>>();
    let late_type_opens = render_late_type_opens(
        plan,
        shard,
        context.late_type_open_index,
        context.type_providers,
        context.typed_use_providers.get(&shard.id),
        context
            .caller_contract_providers
            .get(&shard.id)
            .map(Vec::as_slice),
        &already_opened,
    );
    let mut union_provider_order = provider_open_order(&open_prelude);
    union_provider_order.extend(provider_open_order(&late_type_opens));
    output.push_str(&open_prelude);
    output.push_str(&late_type_opens);
    output.push_str(&render_companion_aliases(shard, context.rewrite_plan));
    let mut declaration_ids = shard.declarations.clone();
    declaration_ids.sort_by_key(|id| id.0);
    let declaration_context = RenderDeclarationContext {
        plan,
        current_shard: shard.id,
        rewrite_plan: context.rewrite_plan,
        caller_parameter_types: context.caller_parameter_types,
        type_providers: context.type_providers,
        higher_order_array_returns: context.higher_order_array_returns,
        pattern_owner_witnesses: context.pattern_owner_witnesses,
        local_record_owner_witnesses: context.local_record_owner_witnesses,
        record_return_owner_witnesses: context.record_return_owner_witnesses,
        numeric_conversion_helpers: context.numeric_conversion_helpers,
    };
    // Shards of the consumer's own original module are reopened at the end of the prelude: inside module
    // M the monolith resolves a name to M's own binding before anything opened from other modules, and
    // after private bindings are widened another module's same-named binding (e.g. `gate`, `esc`) is
    // visible too, so opening M's shards last makes last-open-wins reproduce that. Only before the first
    // declaration: reopening after local declarations would let an older shard shadow a newer local
    // definition (record-label inference picked `TerminalFlowDispatchRequestIdentity` over a local
    // `TerminalFlowExitRequestIdentity`).
    let shard_module = |id: usize| {
        plan.shards[id]
            .declarations
            .first()
            .and_then(|declaration| plan.declarations[declaration.0].scope.module_name())
    };
    let own_module_reopens = |source_module: Option<&str>| {
        let mut lines = String::new();
        if source_module.is_some() {
            for provider in &shard.direct_dependencies {
                if shard_module(*provider) == source_module {
                    let _ = writeln!(lines, "    open {}", module_name(*provider));
                }
            }
        }
        lines
    };
    // Module abbreviations (`module X = A.B`) are local to the file that declares them and cannot be
    // reached through an open, so a shard that uses one declared in another shard re-declares it,
    // rendered in this shard's context (its target qualified relative to this shard).
    let own_definitions = shard
        .declarations
        .iter()
        .flat_map(|id| plan.declarations[id.0].definitions.iter().map(String::as_str))
        .collect::<BTreeSet<_>>();
    let mut redeclared = BTreeSet::<String>::new();
    for declaration_id in &declaration_ids {
        for witness in &plan.declarations[declaration_id.0].witnesses {
            let provider = witness.provider.0;
            if context.declaration_shards[provider] == shard.id {
                continue;
            }
            let Some(name) = module_abbreviation_name(&plan.declarations[provider].text) else {
                continue;
            };
            if own_definitions.contains(name) || !redeclared.insert(name.to_owned()) {
                continue;
            }
            // The target's head module is resolved by the provider's own opens, which this shard may
            // lack, so it is qualified with the shard that defines it.
            let target = plan.declarations[provider]
                .text
                .split_once('=')
                .map(|(_, target)| target.trim())
                .unwrap_or_default();
            let head = target.split('.').next().unwrap_or_default();
            let head_shard = plan.declarations[provider]
                .witnesses
                .iter()
                .map(|witness| witness.provider.0)
                .find(|owner| plan.declarations[*owner].definitions.iter().any(|name| name == head))
                .map(|owner| context.declaration_shards[owner]);
            match head_shard {
                Some(owner) if owner != shard.id => {
                    let _ = writeln!(output, "    module {name} = {}.{target}", module_name(owner));
                }
                _ => {
                    let rendered = render_declaration(provider, &declaration_context);
                    for line in rendered.lines().filter(|line| line.trim_start().starts_with("module ")) {
                        output.push_str(line);
                        output.push('\n');
                    }
                }
            }
        }
    }
    let mut first_declaration = true;
    for declaration_id in declaration_ids {
        let declaration = remove_split_source_module_opens(
            &render_declaration(declaration_id.0, &declaration_context),
            context.split_source_modules,
        );
        let source_module = plan.declarations[declaration_id.0].scope.module_name();
        let lexical_providers = context
            .lexical_open_index
            .plan(
                shard.id,
                &shard.compile_dependencies,
                source_module,
                declaration_id.0,
            )
            .providers();
        if first_declaration {
            output.push_str(&own_module_reopens(source_module));
            first_declaration = false;
        }
        for provider in lexical_providers {
            let _ = writeln!(output, "    open {}", module_name(provider));
        }
        let declaration = qualify_duplicate_union_type_annotations_scoped(
            &declaration,
            context.union_context,
            shard.id,
            &shard.compile_dependencies,
            source_module,
            module_name,
        );
        let declaration = qualify_ambiguous_union_branches_scoped(
            &declaration,
            context.union_context,
            shard.id,
            &shard.compile_dependencies,
            &union_provider_order,
            source_module,
            module_name,
        );
        let declaration = qualify_typed_union_comparisons(
            &declaration,
            context.union_context,
            &shard.compile_dependencies,
            module_name,
        );
        let declaration = qualify_ambient_cases(declaration, &shard.ambient_opens);
        output.push_str(&declaration);
        output.push('\n');
    }
    output
}

fn xml_escape(value: &str) -> String {
    value
        .replace('&', "&amp;")
        .replace('<', "&lt;")
        .replace('>', "&gt;")
        .replace('"', "&quot;")
        .replace('\'', "&apos;")
}

fn external_references(options: &EmitOptions) -> Vec<(String, PathBuf)> {
    spiral_split_assembly_refs::discover_assembly_references_with_overlay(
        &options.assembly_root,
        options.assembly_overlay_root.as_deref(),
    )
    .unwrap_or_default()
}

fn render_project(
    options: &EmitOptions,
    shard: &Shard,
    references: &[(String, PathBuf)],
) -> String {
    let name = part_name(shard.id);
    let mut output = String::new();
    let _ = writeln!(output, "<Project Sdk=\"Microsoft.NET.Sdk\">");
    output.push_str("  <PropertyGroup>\n");
    output.push_str("    <TargetFramework>net11.0</TargetFramework>\n");
    output.push_str("    <LangVersion>preview</LangVersion>\n");
    output.push_str("    <OutputType>Library</OutputType>\n");
    let _ = writeln!(
        output,
        "    <AssemblyName>SpiralCompiler{name}</AssemblyName>"
    );
    output.push_str("    <RootNamespace>Polyglot</RootNamespace>\n");
    output.push_str("    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>\n");
    output.push_str("    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>\n");
    output.push_str("    <RestoreIgnoreFailedSources>true</RestoreIgnoreFailedSources>\n");
    output.push_str("    <DefineConstants>_LINUX</DefineConstants>\n");
    output.push_str("    <OtherFlags>--nooptimizationdata --tailcalls- --crossoptimize- --compressmetadata-</OtherFlags>\n");
    output.push_str("  </PropertyGroup>\n");
    let _ = writeln!(
        output,
        "  <ItemGroup><Compile Include=\"{name}.fs\" /></ItemGroup>"
    );
    if !shard.compile_dependencies.is_empty() {
        output.push_str("  <ItemGroup>\n");
        for dependency in &shard.compile_dependencies {
            let dependency_name = part_name(*dependency);
            let _ = writeln!(
                output,
                "    <ProjectReference Include=\"{dependency_name}.fsproj\" ReferenceOutputAssembly=\"true\" />"
            );
        }
        output.push_str("  </ItemGroup>\n");
    }
    if !references.is_empty() {
        output.push_str("  <ItemGroup>\n");
        for (reference, path) in references {
            let _ = writeln!(
                output,
                "    <Reference Include=\"{}\"><HintPath>{}</HintPath><Private>true</Private></Reference>",
                xml_escape(reference),
                xml_escape(&path.display().to_string())
            );
        }
        output.push_str("  </ItemGroup>\n");
    }
    output.push_str(
        "  <ItemGroup><FrameworkReference Include=\"Microsoft.AspNetCore.App\" /></ItemGroup>\n",
    );
    output.push_str("</Project>\n");
    let _ = &options.cache_root;
    output
}

fn cache_namespace_fingerprint(plan: &SplitPlan, options: &EmitOptions) -> u64 {
    const OFFSET: u64 = 0xcbf29ce484222325;
    const PRIME: u64 = 0x100000001b3;
    let mut hash = OFFSET;
    let mut mix = |bytes: &[u8]| {
        for byte in bytes {
            hash ^= u64::from(*byte);
            hash = hash.wrapping_mul(PRIME);
        }
    };
    mix(b"spiral-split-cache-namespace\0");
    mix(&plan.source.fingerprint.to_le_bytes());
    mix(plan.policy.to_string().as_bytes());
    mix(plan.reference_mode.to_string().as_bytes());
    mix(&generator_fingerprint().to_le_bytes());
    mix(&transform_fingerprint().to_le_bytes());
    mix(options.assembly_root.to_string_lossy().as_bytes());
    if let Some(root) = &options.assembly_overlay_root {
        mix(b"\0overlay\0");
        mix(root.to_string_lossy().as_bytes());
    }
    hash
}

fn render_directory_props_with_identity(options: &EmitOptions, cache_identity: u64) -> String {
    let cache_root = options.cache_root.join(format!("{cache_identity:016x}"));
    format!(
        "<Project>\n  <PropertyGroup>\n    <BaseOutputPath>{}/bin/$(MSBuildProjectName)/</BaseOutputPath>\n    <BaseIntermediateOutputPath>{}/obj/$(MSBuildProjectName)/</BaseIntermediateOutputPath>\n    <Optimize>false</Optimize>\n    <DebugSymbols>false</DebugSymbols>\n    <DebugType>None</DebugType>\n    <UseSharedCompilation>false</UseSharedCompilation>\n    <Deterministic>true</Deterministic>\n  </PropertyGroup>\n</Project>\n",
        xml_escape(&cache_root.display().to_string()),
        xml_escape(&cache_root.display().to_string())
    )
}

fn render_nuget_config() -> &'static str {
    "<?xml version=\"1.0\" encoding=\"utf-8\"?>
<configuration>
  <packageSources>
    <clear />
  </packageSources>
</configuration>
"
}

pub fn seed_restore_assets(output_root: &Path) -> Result<usize, String> {
    let parts_path = output_root.join("parts.tsv");
    let parts = fs::read_to_string(&parts_path)
        .map_err(|error| format!("read {}: {error}", parts_path.display()))?;
    let shard_count = parts
        .lines()
        .skip(1)
        .filter(|line| !line.is_empty())
        .count();
    if shard_count == 0 {
        return Err("parts.tsv contains no shards".to_owned());
    }
    let seed_path = output_root.join(".build-cache/obj/Part0000/project.assets.json");
    let assets = fs::read_to_string(&seed_path).map_err(|error| {
        format!(
            "read restore seed {}: {error}; restore Part0000.fsproj first",
            seed_path.display()
        )
    })?;
    let mut projects = (0..shard_count).map(part_name).collect::<Vec<_>>();
    projects.push("SplitRoot".to_owned());
    projects.par_iter().try_for_each(|project| {
        let path = output_root
            .join(".build-cache/obj")
            .join(project)
            .join("project.assets.json");
        atomic_write(&path, &assets)
    })?;
    let receipt = format!(
        "seed_project	Part0000
shards	{shard_count}
seeded_projects	{}
",
        projects.len()
    );
    atomic_write(&output_root.join("restore-seed.receipt.tsv"), &receipt)?;
    Ok(projects.len())
}

fn render_root_source(plan: &SplitPlan) -> String {
    format!(
        "namespace Polyglot\n\nmodule spiral_compiler_split_root =\n    let sourceFingerprint = {}UL\n    let shardCount = {}\n",
        plan.source.fingerprint,
        plan.shards.len()
    )
}

fn render_root_project(plan: &SplitPlan) -> String {
    let mut output = String::from(
        "<Project Sdk=\"Microsoft.NET.Sdk\">\n  <PropertyGroup>\n    <TargetFramework>net11.0</TargetFramework>\n    <LangVersion>preview</LangVersion>\n    <OutputType>Library</OutputType>\n    <AssemblyName>SpiralCompilerSplitRoot</AssemblyName>\n    <RootNamespace>Polyglot</RootNamespace>\n    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>\n    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>\n  </PropertyGroup>\n  <ItemGroup><Compile Include=\"SplitRoot.fs\" /></ItemGroup>\n  <ItemGroup>\n",
    );
    for shard in &plan.shards {
        let _ = writeln!(
            output,
            "    <ProjectReference Include=\"{}.fsproj\" ReferenceOutputAssembly=\"true\" />",
            part_name(shard.id)
        );
    }
    output.push_str("  </ItemGroup>\n</Project>\n");
    output
}

fn join_numbers(values: impl IntoIterator<Item = usize>) -> String {
    values
        .into_iter()
        .map(|value| value.to_string())
        .collect::<Vec<_>>()
        .join(",")
}

fn render_caller_contract_metrics(
    plan: &SplitPlan,
    parameter_types: &BTreeMap<DeclarationId, Vec<CallerParameterType>>,
) -> String {
    let shards = declaration_shards(plan);
    let mut output = String::from("declaration\tshard\twitnesses\n");
    for (declaration, witnesses) in parameter_types {
        let _ = writeln!(
            output,
            "{}\t{}\t{}",
            declaration.0,
            shards[declaration.0],
            witnesses.len(),
        );
    }
    output
}

fn render_caller_contract_evidence(
    plan: &SplitPlan,
    parameter_types: &BTreeMap<DeclarationId, Vec<CallerParameterType>>,
) -> String {
    let shards = declaration_shards(plan);
    let mut output =
        String::from("declaration\tshard\tsymbol\tparameter_index\tparameter_name\ttype_symbol\n");
    for (declaration, witnesses) in parameter_types {
        for witness in witnesses {
            let _ = writeln!(
                output,
                "{}\t{}\t{}\t{}\t{}\t{}",
                declaration.0,
                shards[declaration.0],
                witness.symbol,
                witness.parameter_index,
                witness.parameter_name,
                witness.type_symbol,
            );
        }
    }
    output
}

fn render_parts(plan: &SplitPlan) -> String {
    let mut output = String::from(
        "shard\tdeclarations\tlines\tbytes\tlayer\tdirect_dependencies\tcompile_dependencies\toversize\tfingerprint\theading\n",
    );
    for shard in &plan.shards {
        let heading = shard
            .declarations
            .first()
            .map(|id| plan.declarations[id.0].heading.replace(['\t', '\n'], " "))
            .unwrap_or_default();
        let _ = writeln!(
            output,
            "{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}",
            shard.id,
            join_numbers(shard.declarations.iter().map(|id| id.0)),
            shard.line_count,
            shard.bytes,
            shard.layer,
            join_numbers(shard.direct_dependencies.iter().copied()),
            join_numbers(shard.compile_dependencies.iter().copied()),
            if shard.oversize { 1 } else { 0 },
            shard.fingerprint,
            heading,
        );
    }
    output
}

fn render_edges(plan: &SplitPlan) -> String {
    let mut output = String::from("consumer\tprovider\tkind\n");
    for shard in &plan.shards {
        for dependency in &shard.compile_dependencies {
            let _ = writeln!(output, "{}\t{}\tdirect", shard.id, dependency);
        }
        for dependency in shard
            .compile_dependencies
            .difference(&shard.direct_dependencies)
        {
            let _ = writeln!(output, "{}\t{}\tclosure", shard.id, dependency);
        }
    }
    output
}

fn render_module_fragments(plan: &SplitPlan) -> String {
    let declaration_shards = declaration_shards(plan);
    let mut output = String::from(
        "declaration\tshard\tmodule\tordinal\tprefix_lines\tdedent_spaces\tstart_line\tend_line\n",
    );
    for declaration in &plan.declarations {
        if let DeclarationScope::ModuleFragment {
            module_name,
            ordinal,
            prefix_lines,
            dedent_spaces,
        } = &declaration.scope
        {
            let _ = writeln!(
                output,
                "{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}",
                declaration.id.0,
                declaration_shards[declaration.id.0],
                module_name,
                ordinal,
                prefix_lines,
                dedent_spaces,
                declaration.span.start,
                declaration.span.end,
            );
        }
    }
    output
}

fn render_qualified_rewrites(replacements: &[(String, String)]) -> String {
    let mut output = String::from("source_symbol\tgenerated_symbol\n");
    for (source, generated) in replacements {
        let _ = writeln!(output, "{source}\t{generated}");
    }
    output
}

fn render_receipt(
    plan: &SplitPlan,
    references: &[(String, PathBuf)],
    replacements: &[(String, String)],
) -> String {
    format!(
        "key\tvalue\nsource\t{}\nsource_fingerprint\t{}\nsource_bytes\t{}\nprofile\t{}\npolicy\t{}\nreference_mode\t{}\ngenerator_fingerprint\t{}\ntransform_fingerprint\t{}\nshards\t{}\nmodule_fragments\t{}\nqualified_rewrites\t{}\nexternal_references\t{}\n",
        plan.source.path.display(),
        plan.source.fingerprint,
        plan.source.bytes,
        plan.source.profile,
        plan.policy,
        plan.reference_mode,
        generator_fingerprint(),
        transform_fingerprint(),
        plan.shards.len(),
        plan.declarations
            .iter()
            .filter(|declaration| matches!(
                declaration.scope,
                DeclarationScope::ModuleFragment { .. }
            ))
            .count(),
        replacements.len(),
        references.len(),
    )
}

include!("output_reset.rs");
pub fn emit_plan(plan: &SplitPlan, options: &EmitOptions) -> Result<EmitReceipt, String> {
    if options.output_root == Path::new("/") || options.output_root == Path::new("/mnt/data") {
        return Err("refusing destructive emission into root or /mnt/data".to_owned());
    }
    let resume_parts = prepare_output_root(plan, options)?;
    if resume_parts.complete {
        return Ok(EmitReceipt {
            shards: plan.shards.len(),
            files: plan.shards.len() * 2 + EMISSION_SIDECARS.len(),
            source_fingerprint: plan.source.fingerprint,
            output_root: options.output_root.clone(),
        });
    }
    if resume_parts.prebridge_complete {
        return finalize_prebridge_emission(plan, options);
    }
    let mut phases = PhaseReceipt::new(options.output_root.join("emit-phases.tsv"));
    phases.record("reset")?;
    let references = external_references(options);
    phases.record("external_references")?;
    let rewrite_plan = qualified_replacements(plan);
    phases.record("qualified_replacements")?;
    let split_source_modules = plan
        .declarations
        .iter()
        .filter_map(|declaration| declaration.scope.module_name())
        .collect::<BTreeSet<_>>();
    let type_providers = unique_type_providers(plan);
    phases.record("type_providers")?;
    let typed_use_providers = typed_use_type_providers_by_shard(plan, &type_providers);
    phases.record("typed_use_providers")?;
    let mut caller_contracts = analyze_caller_contracts(plan, &type_providers);
    phases.record("caller_contracts")?;
    atomic_write(
        &options.output_root.join("caller-contract-evidence.tsv"),
        &render_caller_contract_evidence(plan, &caller_contracts.parameter_types),
    )?;
    let caller_projection_contracts = analyze_caller_projection_contracts(plan, &type_providers);
    phases.record("caller_projection_contracts")?;
    atomic_write(
        &options.output_root.join("caller-projection-evidence.tsv"),
        &render_caller_contract_evidence(plan, &caller_projection_contracts.parameter_types),
    )?;
    for (declaration, mut rows) in caller_projection_contracts.parameter_types {
        caller_contracts
            .parameter_types
            .entry(declaration)
            .or_default()
            .append(&mut rows);
    }
    for (shard, providers) in caller_projection_contracts.type_providers_by_shard {
        let target = caller_contracts
            .type_providers_by_shard
            .entry(shard)
            .or_default();
        target.extend(providers);
        target.sort_unstable();
        target.dedup();
    }
    let mutable_record_contracts = analyze_mutable_record_owner_contracts(plan);
    phases.record("mutable_record_contracts")?;
    atomic_write(
        &options
            .output_root
            .join("mutable-record-owner-evidence.tsv"),
        &render_caller_contract_evidence(plan, &mutable_record_contracts),
    )?;
    for (declaration, mut rows) in mutable_record_contracts {
        caller_contracts
            .parameter_types
            .entry(declaration)
            .or_default()
            .append(&mut rows);
    }
    let forwarded_binding_contracts = analyze_forwarded_binding_contracts(
        plan,
        &type_providers,
        &caller_contracts.parameter_types,
    );
    atomic_write(
        &options.output_root.join("forwarded-binding-evidence.tsv"),
        &render_caller_contract_evidence(plan, &forwarded_binding_contracts.parameter_types),
    )?;
    for (declaration, mut rows) in forwarded_binding_contracts.parameter_types {
        caller_contracts
            .parameter_types
            .entry(declaration)
            .or_default()
            .append(&mut rows);
    }
    for (shard, providers) in forwarded_binding_contracts.type_providers_by_shard {
        let target = caller_contracts
            .type_providers_by_shard
            .entry(shard)
            .or_default();
        target.extend(providers);
        target.sort_unstable();
        target.dedup();
    }
    for rows in caller_contracts.parameter_types.values_mut() {
        rows.sort();
        rows.dedup();
    }
    atomic_write(
        &options.output_root.join("caller-contracts.tsv"),
        &render_caller_contract_metrics(plan, &caller_contracts.parameter_types),
    )?;
    phases.record("forwarded_binding_contracts")?;
    let higher_order_array_returns = analyze_higher_order_array_returns(plan);
    phases.record("higher_order_array_returns")?;
    let record_return_owner_witnesses = analyze_record_return_owners(plan);
    phases.record("record_return_owners")?;
    atomic_write(
        &options
            .output_root
            .join("record-return-owner-witnesses.tsv"),
        &render_record_return_owner_witnesses(&record_return_owner_witnesses),
    )?;
    let local_record_owner_witnesses = analyze_local_record_owners(plan);
    phases.record("local_record_owners")?;
    atomic_write(
        &options.output_root.join("local-record-owner-witnesses.tsv"),
        &render_local_record_owner_witnesses(&local_record_owner_witnesses),
    )?;
    let pattern_owner_witnesses = analyze_pattern_record_owners(plan);
    phases.record("pattern_record_owners")?;
    atomic_write(
        &options.output_root.join("pattern-owner-witnesses.tsv"),
        &render_pattern_owner_witnesses(&pattern_owner_witnesses),
    )?;
    let union_context = analyze_union_context(plan);
    phases.record("union_context")?;
    let late_type_open_index = LateTypeOpenIndex::build(plan);
    phases.record("late_type_open_index")?;
    let lexical_open_index = LexicalOpenIndex::build(&union_context);
    phases.record("lexical_open_index")?;
    let numeric_conversion_helpers = collect_numeric_conversion_helpers(plan);
    let declaration_shard_index = declaration_shards(plan);
    let render_context = RenderSourceContext {
        rewrite_plan: &rewrite_plan,
        split_source_modules: &split_source_modules,
        type_providers: &type_providers,
        late_type_open_index: &late_type_open_index,
        typed_use_providers: &typed_use_providers,
        caller_contract_providers: &caller_contracts.type_providers_by_shard,
        caller_parameter_types: &caller_contracts.parameter_types,
        higher_order_array_returns: &higher_order_array_returns,
        pattern_owner_witnesses: &pattern_owner_witnesses,
        local_record_owner_witnesses: &local_record_owner_witnesses,
        record_return_owner_witnesses: &record_return_owner_witnesses,
        numeric_conversion_helpers: &numeric_conversion_helpers,
        union_context: &union_context,
        lexical_open_index: &lexical_open_index,
        declaration_shards: &declaration_shard_index,
    };
    phases.record("emission_indexes")?;
    plan.shards
        .par_iter()
        .map(|shard| {
            let name = part_name(shard.id);
            let source_path = options.output_root.join(format!("{name}.fs"));
            let project_path = options.output_root.join(format!("{name}.fsproj"));
            if !(resume_parts.sources && source_path.is_file()) {
                atomic_write(&source_path, &render_source(plan, shard, &render_context))?;
            }
            if !(resume_parts.projects && project_path.is_file()) {
                atomic_write(&project_path, &render_project(options, shard, &references))?;
            }
            Ok::<(), String>(())
        })
        .collect::<Result<Vec<_>, _>>()?;
    phases.record("shard_files")?;

    let metrics = measure(plan);
    phases.record("metrics")?;
    let sidecars = [
        (
            "Directory.Build.props",
            render_directory_props_with_identity(
                options,
                cache_namespace_fingerprint(plan, options),
            ),
        ),
        ("NuGet.Config", render_nuget_config().to_owned()),
        ("SplitRoot.fs", render_root_source(plan)),
        ("SplitRoot.fsproj", render_root_project(plan)),
        ("parts.tsv", render_parts(plan)),
        ("edges.tsv", render_edges(plan)),
        ("metrics.tsv", render_tsv(plan, &metrics)),
        ("oversize.tsv", render_oversize_tsv(plan)),
        ("module-fragments.tsv", render_module_fragments(plan)),
        (
            "qualified-rewrites.tsv",
            render_qualified_rewrites(&rewrite_plan.replacements),
        ),
        (
            "source.receipt.tsv",
            render_receipt(plan, &references, &rewrite_plan.replacements),
        ),
    ];
    for (name, content) in sidecars {
        atomic_write(&options.output_root.join(name), &content)?;
    }
    phases.record("sidecars")?;
    let expected_files = plan.shards.len() * 2 + EMISSION_SIDECARS.len();
    let actual_files = fs::read_dir(&options.output_root)
        .map_err(|error| format!("list {}: {error}", options.output_root.display()))?
        .filter_map(Result::ok)
        .filter(|entry| {
            entry.path().is_file()
                && entry.file_name() != "gear-preplan-anonymous-record-bridges.tsv"
        })
        .count();
    if actual_files != expected_files {
        return Err(format!(
            "emission file count mismatch: expected {expected_files}, got {actual_files}"
        ));
    }
    Ok(EmitReceipt {
        shards: plan.shards.len(),
        files: actual_files,
        source_fingerprint: plan.source.fingerprint,
        output_root: options.output_root.clone(),
    })
}

include!("fused_shard.rs");
include!("fsharp_emitter_tests.rs");
