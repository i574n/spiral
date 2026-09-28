use spiral_split_call_contract::{CallerParameterType, unshadowed_projected_fields};
use spiral_split_model::{DeclarationId, SplitPlan};
use spiral_split_union_context::{UnionContextIndex, analyze_union_context};
use std::collections::{BTreeMap, BTreeSet};

#[derive(Clone, Debug, Eq, PartialEq)]
struct RecordField {
    mutable: bool,
    type_symbol: String,
    type_identity: String,
    type_text: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct RecordType {
    provider: usize,
    declaration: Option<DeclarationId>,
    module_name: Option<String>,
    local_module_name: Option<String>,
    name: String,
    generic_arity: usize,
    fields: BTreeMap<String, RecordField>,
    members: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct Binding {
    symbol: String,
    parameters: Vec<String>,
    body: String,
}

fn identifier_start(character: char) -> bool {
    character == '_' || character.is_alphabetic()
}

fn identifier_continue(character: char) -> bool {
    character == '_' || character == '\'' || character.is_alphanumeric()
}

fn identifier_prefix(text: &str) -> Option<&str> {
    let mut chars = text.char_indices();
    let (_, first) = chars.next()?;
    if !identifier_start(first) {
        return None;
    }
    let mut end = first.len_utf8();
    for (index, character) in chars {
        if !identifier_continue(character) {
            break;
        }
        end = index + character.len_utf8();
    }
    Some(&text[..end])
}

fn type_header(trimmed: &str) -> Option<(String, usize)> {
    let mut tail = trimmed
        .strip_prefix("type ")
        .or_else(|| trimmed.strip_prefix("and "))?
        .trim_start();
    loop {
        let before = tail;
        for modifier in ["private ", "internal ", "public ", "rec "] {
            if let Some(rest) = tail.strip_prefix(modifier) {
                tail = rest.trim_start();
                break;
            }
        }
        if tail == before {
            break;
        }
    }
    let name = identifier_prefix(tail)?.to_owned();
    let after_name = &tail[name.len()..];
    let generic_arity = after_name
        .strip_prefix('<')
        .and_then(|generic| generic.split_once('>'))
        .map_or(0, |(generic, _)| {
            let count = generic
                .split(',')
                .map(str::trim)
                .filter(|piece| !piece.is_empty())
                .count();
            count.max(1)
        });
    Some((name, generic_arity))
}

fn type_symbol(text: &str) -> Option<String> {
    let path = text
        .trim_start()
        .chars()
        .take_while(|character| *character == '.' || identifier_continue(*character))
        .collect::<String>();
    let symbol = path.rsplit('.').next().unwrap_or_default();
    (!symbol.is_empty()).then(|| symbol.to_owned())
}

fn normalize_type_identity(text: &str) -> Option<String> {
    let normalized = text
        .trim()
        .chars()
        .filter(|character| !character.is_whitespace())
        .collect::<String>();
    (!normalized.is_empty()).then_some(normalized)
}

fn module_header(trimmed: &str) -> Option<String> {
    let mut tail = trimmed.strip_prefix("module ")?.trim_start();
    loop {
        let before = tail;
        for modifier in ["rec ", "private ", "internal ", "public "] {
            if let Some(rest) = tail.strip_prefix(modifier) {
                tail = rest.trim_start();
                break;
            }
        }
        if tail == before {
            break;
        }
    }
    let mut path = String::new();
    let mut cursor = 0usize;
    loop {
        let symbol = identifier_prefix(&tail[cursor..])?;
        if !path.is_empty() {
            path.push('.');
        }
        path.push_str(symbol);
        cursor += symbol.len();
        if tail[cursor..].starts_with('.') {
            cursor += 1;
            continue;
        }
        break;
    }
    tail[cursor..].trim_start().starts_with('=').then_some(path)
}

fn parse_record_fields(body: &str) -> BTreeMap<String, RecordField> {
    body.split([';', '\n'])
        .filter_map(|piece| {
            let piece = piece
                .split_once("//")
                .map_or(piece, |(head, _)| head)
                .trim();
            let (left, right) = piece.split_once(':')?;
            let left = left.trim();
            let mutable = left.starts_with("mutable ");
            let field = left
                .strip_prefix("mutable ")
                .unwrap_or(left)
                .split_whitespace()
                .last()?;
            let field = identifier_prefix(field)?.to_owned();
            Some((
                field,
                RecordField {
                    mutable,
                    type_symbol: type_symbol(right)?,
                    type_identity: normalize_type_identity(right)?,
                    type_text: right.trim().to_owned(),
                },
            ))
        })
        .collect()
}

fn record_member_name(trimmed: &str) -> Option<String> {
    let mut tail = trimmed.strip_prefix("member ")?.trim_start();
    loop {
        let before = tail;
        for modifier in ["private ", "internal ", "public ", "inline ", "static "] {
            if let Some(rest) = tail.strip_prefix(modifier) {
                tail = rest.trim_start();
                break;
            }
        }
        if tail == before {
            break;
        }
    }
    let (_, after_receiver) = tail.split_once('.')?;
    identifier_prefix(after_receiver).map(str::to_owned)
}

fn parse_record_members(lines: &[&str], start: usize, type_indent: usize) -> BTreeSet<String> {
    let mut members = BTreeSet::new();
    let mut saw_with = false;
    for line in lines.iter().skip(start) {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        let indent = leading_spaces(line);
        if !saw_with {
            if indent == type_indent && (trimmed == "with" || trimmed.starts_with("with ")) {
                saw_with = true;
                continue;
            }
            if indent <= type_indent {
                break;
            }
            continue;
        }
        if indent <= type_indent {
            break;
        }
        if let Some(member) = record_member_name(trimmed) {
            members.insert(member);
        }
    }
    members
}

fn record_types(
    text: &str,
    provider: usize,
    outer_module_name: Option<&str>,
    declaration: Option<DeclarationId>,
) -> Vec<RecordType> {
    let lines = text.lines().collect::<Vec<_>>();
    let mut result = Vec::new();
    let mut active_modules = Vec::<(usize, String)>::new();
    let mut index = 0usize;
    while index < lines.len() {
        let line = lines[index];
        let indent = leading_spaces(line);
        let trimmed = line.trim_start();
        if !trimmed.is_empty() {
            while active_modules
                .last()
                .is_some_and(|(module_indent, _)| *module_indent >= indent)
            {
                active_modules.pop();
            }
            if let Some(module_name) = module_header(trimmed) {
                active_modules.push((indent, module_name));
                index += 1;
                continue;
            }
        }
        let Some((name, generic_arity)) = type_header(trimmed) else {
            index += 1;
            continue;
        };
        let type_indent = indent;
        let mut tail = String::new();
        let mut cursor = index;
        let mut open = None;
        let mut close = None;
        while cursor < lines.len() {
            let candidate = lines[cursor].trim_start();
            if open.is_none() {
                if candidate.starts_with('|')
                    || (cursor > index
                        && leading_spaces(lines[cursor]) <= type_indent
                        && (type_header(candidate).is_some()
                            || candidate.starts_with("module ")
                            || candidate.starts_with("let ")
                            || candidate.starts_with("exception ")))
                {
                    break;
                }
                if cursor == index
                    && candidate
                        .split_once('=')
                        .is_some_and(|(_, after_equals)| after_equals.trim_start().starts_with('|'))
                {
                    break;
                }
            }
            if !tail.is_empty() {
                tail.push('\n');
            }
            tail.push_str(lines[cursor]);
            if open.is_none() {
                open = tail.find('{');
            }
            if let Some(open_at) = open
                && let Some(relative_close) = tail[open_at + 1..].find('}')
            {
                close = Some(open_at + 1 + relative_close);
                break;
            }
            cursor += 1;
        }
        let (Some(open), Some(close)) = (open, close) else {
            index += 1;
            continue;
        };
        let fields = parse_record_fields(&tail[open + 1..close]);
        let members = parse_record_members(&lines, cursor.saturating_add(1), type_indent);
        if !fields.is_empty() {
            let nested_module_name = (!active_modules.is_empty()).then(|| {
                active_modules
                    .iter()
                    .map(|(_, module_name)| module_name.as_str())
                    .collect::<Vec<_>>()
                    .join(".")
            });
            let local_module_name = nested_module_name.clone();
            let module_name = match (outer_module_name, nested_module_name) {
                (Some(outer), Some(nested)) => Some(format!("{outer}.{nested}")),
                (Some(outer), None) => Some(outer.to_owned()),
                (None, Some(nested)) => Some(nested),
                (None, None) => None,
            };
            result.push(RecordType {
                provider,
                declaration,
                module_name,
                local_module_name,
                name,
                generic_arity,
                fields,
                members,
            });
        }
        index = cursor.saturating_add(1).max(index + 1);
    }
    result
}

fn leading_spaces(line: &str) -> usize {
    line.len() - line.trim_start().len()
}

fn binding_body(mut line: &str) -> Option<&str> {
    line = line.trim_start();
    line = line
        .strip_prefix("let ")
        .or_else(|| line.strip_prefix("and "))?;
    loop {
        let before = line;
        for modifier in [
            "rec ",
            "private ",
            "internal ",
            "public ",
            "inline ",
            "mutable ",
        ] {
            if let Some(rest) = line.strip_prefix(modifier) {
                line = rest;
                break;
            }
        }
        if line == before {
            return Some(line);
        }
    }
}

fn matching_paren(text: &str, open: usize) -> Option<usize> {
    let mut depth = 0usize;
    for (offset, character) in text[open..].char_indices() {
        match character {
            '(' => depth += 1,
            ')' => {
                depth = depth.saturating_sub(1);
                if depth == 0 {
                    return Some(open + offset);
                }
            }
            _ => {}
        }
    }
    None
}

fn inferred_parameters(after_name: &str) -> Vec<String> {
    let bytes = after_name.as_bytes();
    let mut cursor = 0usize;
    let mut result = Vec::new();
    while cursor < bytes.len() {
        while cursor < bytes.len() && bytes[cursor].is_ascii_whitespace() {
            cursor += 1;
        }
        if cursor >= bytes.len() || matches!(bytes[cursor], b'=' | b':') {
            break;
        }
        if bytes[cursor] == b'(' {
            let Some(close) = matching_paren(after_name, cursor) else {
                break;
            };
            cursor = close + 1;
            continue;
        }
        let Some(first) = after_name[cursor..].chars().next() else {
            break;
        };
        if !identifier_start(first) {
            cursor += first.len_utf8();
            continue;
        }
        let start = cursor;
        cursor += first.len_utf8();
        while cursor < bytes.len() {
            let Some(character) = after_name[cursor..].chars().next() else {
                break;
            };
            if !identifier_continue(character) {
                break;
            }
            cursor += character.len_utf8();
        }
        result.push(after_name[start..cursor].to_owned());
    }
    result
}

fn bindings(text: &str) -> Vec<Binding> {
    let lines = text.lines().collect::<Vec<_>>();
    let mut result = Vec::new();
    let mut index = 0usize;
    while index < lines.len() {
        let Some(body) = binding_body(lines[index]) else {
            index += 1;
            continue;
        };
        let Some(symbol) = identifier_prefix(body) else {
            index += 1;
            continue;
        };
        let indent = leading_spaces(lines[index]);
        let mut header = lines[index].trim().to_owned();
        let mut header_end = index + 1;
        while !header.contains('=') && header_end < lines.len() {
            header.push(' ');
            header.push_str(lines[header_end].trim());
            header_end += 1;
        }
        let before_equals = header
            .split_once('=')
            .map_or(header.as_str(), |(left, _)| left);
        let Some(header_body) = binding_body(before_equals) else {
            index += 1;
            continue;
        };
        let Some(after_name) = header_body.strip_prefix(symbol) else {
            index += 1;
            continue;
        };
        let mut end = header_end.max(index + 1);
        while end < lines.len() {
            let candidate = lines[end];
            if !candidate.trim().is_empty() && leading_spaces(candidate) <= indent {
                break;
            }
            end += 1;
        }
        result.push(Binding {
            symbol: symbol.to_owned(),
            parameters: inferred_parameters(after_name),
            body: lines[index..end].join("\n"),
        });
        index = end.max(index + 1);
    }
    result
}

fn has_projected_match_evidence(text: &str, parameter: &str) -> bool {
    unshadowed_projected_fields(text, parameter)
        .iter()
        .any(|field| !matched_cases(text, parameter, field).is_empty())
}

fn whole_projection(text: &str, parameter: &str, field: &str) -> bool {
    let needle = format!("{parameter}.{field}");
    text.match_indices(&needle).any(|(index, matched)| {
        let before = text[..index].chars().next_back();
        let after = text[index + matched.len()..].chars().next();
        before.is_none_or(|character| !identifier_continue(character))
            && after.is_none_or(|character| !identifier_continue(character))
    })
}

fn assigned_fields(text: &str, parameter: &str) -> BTreeSet<String> {
    let prefix = format!("{parameter}.");
    let mut result = BTreeSet::new();
    for (index, _) in text.match_indices(&prefix) {
        let before = text[..index].chars().next_back();
        if before.is_some_and(identifier_continue) {
            continue;
        }
        let field_start = index + prefix.len();
        let Some(field) = identifier_prefix(&text[field_start..]) else {
            continue;
        };
        let tail = text[field_start + field.len()..].trim_start();
        if tail.starts_with("<-") {
            result.insert(field.to_owned());
        }
    }
    result
}

#[cfg(test)]
fn projected_fields(text: &str, parameter: &str) -> BTreeSet<String> {
    let prefix = format!("{parameter}.");
    let mut result = BTreeSet::new();
    for (index, _) in text.match_indices(&prefix) {
        let before = text[..index].chars().next_back();
        if before.is_some_and(identifier_continue) {
            continue;
        }
        let field_start = index + prefix.len();
        if let Some(field) = identifier_prefix(&text[field_start..]) {
            result.insert(field.to_owned());
        }
    }
    result
}

#[cfg(test)]
fn assigns_field(text: &str, parameter: &str, field: &str) -> bool {
    assigned_fields(text, parameter).contains(field)
}

fn matched_cases(text: &str, parameter: &str, field: &str) -> BTreeSet<String> {
    let lines = text.lines().collect::<Vec<_>>();
    let target = format!("match {parameter}.{field} with");
    let mut result = BTreeSet::new();
    for (index, line) in lines.iter().enumerate() {
        if !line.trim_start().starts_with(&target) {
            continue;
        }
        let indent = leading_spaces(line);
        for candidate in &lines[index + 1..] {
            let trimmed = candidate.trim_start();
            if trimmed.is_empty() {
                continue;
            }
            let candidate_indent = leading_spaces(candidate);
            if candidate_indent < indent {
                break;
            }
            let Some(after_bar) = trimmed.strip_prefix('|') else {
                if candidate_indent <= indent {
                    break;
                }
                continue;
            };
            let after_bar = after_bar.trim_start();
            if let Some(case) = identifier_prefix(after_bar)
                && case.chars().next().is_some_and(char::is_uppercase)
            {
                result.insert(case.to_owned());
            }
        }
    }
    result
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum RecordOwner {
    Local,
    External,
}

fn record_owner(record: &RecordType, shard: usize) -> Option<RecordOwner> {
    if record.provider != shard {
        Some(RecordOwner::External)
    } else if record.local_module_name.is_none() {
        Some(RecordOwner::Local)
    } else {
        None
    }
}

fn render_record_type_in(record: &RecordType, module_name: Option<&str>) -> String {
    let name = module_name.map_or_else(
        || record.name.clone(),
        |module_name| format!("{module_name}.{}", record.name),
    );
    if record.generic_arity == 0 {
        name
    } else {
        format!("{}<{}>", name, vec!["_"; record.generic_arity].join(", "))
    }
}

fn render_record_type(record: &RecordType) -> String {
    render_record_type_in(record, record.module_name.as_deref())
}

fn render_record_owner_type(record: &RecordType, owner: RecordOwner) -> String {
    match owner {
        RecordOwner::Local => render_record_type_in(record, record.local_module_name.as_deref()),
        RecordOwner::External => render_record_type(record),
    }
}

fn union_contains_cases(
    index: &UnionContextIndex,
    type_name: &str,
    cases: &BTreeSet<String>,
) -> bool {
    !cases.is_empty()
        && index
            .groups
            .iter()
            .filter(|group| group.type_name == type_name)
            .any(|group| cases.is_subset(&group.cases))
}

fn field_type_identity_is_unique(
    records: &[RecordType],
    candidate: usize,
    competitors: &BTreeSet<usize>,
    field: &str,
) -> bool {
    let Some(candidate_field) = records[candidate].fields.get(field) else {
        return false;
    };
    competitors.iter().copied().all(|record_index| {
        record_index == candidate
            || records[record_index]
                .fields
                .get(field)
                .is_none_or(|contract| contract.type_identity != candidate_field.type_identity)
    })
}

fn latest_source_record_index(
    records: &[RecordType],
    visible: &BTreeSet<usize>,
    source_module: Option<&str>,
    declaration: DeclarationId,
) -> Option<usize> {
    visible
        .iter()
        .copied()
        .filter(|record_index| {
            let record = &records[*record_index];
            record.local_module_name.is_none()
                && record.module_name.as_deref() == source_module
                && record
                    .declaration
                    .is_some_and(|record_declaration| record_declaration.0 < declaration.0)
        })
        .max_by_key(|record_index| {
            records[*record_index]
                .declaration
                .map_or(0, |record_declaration| record_declaration.0)
        })
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

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ProjectedFieldType {
    pub type_symbol: String,
    pub type_identity: String,
    pub type_text: String,
}

#[derive(Clone, Debug)]
pub struct RecordProjectionIndex {
    declaration_shards: Vec<usize>,
    records: Vec<RecordType>,
    records_by_field: BTreeMap<String, Vec<usize>>,
    records_by_projection: BTreeMap<String, Vec<usize>>,
}

impl RecordProjectionIndex {
    #[must_use]
    pub fn new(plan: &SplitPlan) -> Self {
        let declaration_shards = declaration_shards(plan);
        let mut records = Vec::new();
        for declaration in &plan.declarations {
            records.extend(record_types(
                &declaration.text,
                declaration_shards[declaration.id.0],
                declaration.scope.module_name(),
                Some(declaration.id),
            ));
        }
        let mut records_by_field = BTreeMap::<String, Vec<usize>>::new();
        let mut records_by_projection = BTreeMap::<String, Vec<usize>>::new();
        for (record_index, record) in records.iter().enumerate() {
            for field in record.fields.keys() {
                records_by_field
                    .entry(field.clone())
                    .or_default()
                    .push(record_index);
            }
            let projections = record
                .fields
                .keys()
                .chain(record.members.iter())
                .cloned()
                .collect::<BTreeSet<_>>();
            for projection in projections {
                records_by_projection
                    .entry(projection)
                    .or_default()
                    .push(record_index);
            }
        }
        Self {
            declaration_shards,
            records,
            records_by_field,
            records_by_projection,
        }
    }

    fn unique_record_index(
        &self,
        plan: &SplitPlan,
        declaration: DeclarationId,
        fields: &BTreeSet<String>,
    ) -> Option<usize> {
        if fields.len() < 2 {
            return None;
        }
        let shard = self.declaration_shards[declaration.0];
        let mut fields = fields.iter();
        let first = fields.next()?;
        let mut candidates = self
            .records_by_field
            .get(first)?
            .iter()
            .copied()
            .collect::<BTreeSet<_>>();
        for field in fields {
            let available = self
                .records_by_field
                .get(field)?
                .iter()
                .copied()
                .collect::<BTreeSet<_>>();
            candidates = candidates.intersection(&available).copied().collect();
        }
        if candidates
            .iter()
            .any(|record_index| record_owner(&self.records[*record_index], shard).is_none())
        {
            return None;
        }
        candidates.retain(|record_index| {
            let provider = self.records[*record_index].provider;
            provider == shard || plan.shards[shard].compile_dependencies.contains(&provider)
        });
        (candidates.len() == 1).then(|| *candidates.iter().next().expect("one candidate"))
    }

    fn unique_projection_record_index(
        &self,
        plan: &SplitPlan,
        declaration: DeclarationId,
        projections: &BTreeSet<String>,
    ) -> Option<usize> {
        if projections.len() < 2 {
            return None;
        }
        let shard = self.declaration_shards[declaration.0];
        let mut projections = projections.iter();
        let first = projections.next()?;
        let mut candidates = self
            .records_by_projection
            .get(first)?
            .iter()
            .copied()
            .collect::<BTreeSet<_>>();
        for projection in projections {
            let available = self
                .records_by_projection
                .get(projection)?
                .iter()
                .copied()
                .collect::<BTreeSet<_>>();
            candidates = candidates.intersection(&available).copied().collect();
        }
        if candidates
            .iter()
            .any(|record_index| record_owner(&self.records[*record_index], shard).is_none())
        {
            return None;
        }
        candidates.retain(|record_index| {
            let provider = self.records[*record_index].provider;
            provider == shard || plan.shards[shard].compile_dependencies.contains(&provider)
        });
        (candidates.len() == 1).then(|| *candidates.iter().next().expect("one candidate"))
    }

    fn single_field_local_record_index(
        &self,
        plan: &SplitPlan,
        declaration: DeclarationId,
        field: &str,
    ) -> Option<usize> {
        let shard = self.declaration_shards[declaration.0];
        let source_module = plan.declarations[declaration.0].scope.module_name();
        let visible = self
            .records_by_field
            .get(field)?
            .iter()
            .copied()
            .filter(|record_index| {
                let record = &self.records[*record_index];
                (record.provider == shard
                    || plan.shards[shard]
                        .compile_dependencies
                        .contains(&record.provider))
                    && record_owner(record, shard).is_some()
            })
            .collect::<BTreeSet<_>>();
        let candidate =
            latest_source_record_index(&self.records, &visible, source_module, declaration)?;
        field_type_identity_is_unique(&self.records, candidate, &visible, field)
            .then_some(candidate)
    }

    fn unique_binding_record_index(
        &self,
        plan: &SplitPlan,
        declaration: DeclarationId,
        fields: &BTreeSet<String>,
    ) -> Option<usize> {
        if fields.len() == 1 {
            let field = fields.iter().next()?;
            self.single_field_local_record_index(plan, declaration, field)
        } else {
            self.unique_record_index(plan, declaration, fields)
        }
    }

    #[must_use]
    pub fn projected_field_type(
        &self,
        plan: &SplitPlan,
        declaration: DeclarationId,
        parent_type: &str,
        field: &str,
    ) -> Option<ProjectedFieldType> {
        let shard = self.declaration_shards[declaration.0];
        let base = parent_type.split('<').next().unwrap_or(parent_type).trim();
        let leaf = base.rsplit('.').next().unwrap_or(base);
        let candidates = self
            .records_by_field
            .get(field)?
            .iter()
            .copied()
            .filter(|record_index| {
                let record = &self.records[*record_index];
                record.name == leaf
                    && (record.provider == shard
                        || plan.shards[shard]
                            .compile_dependencies
                            .contains(&record.provider))
            })
            .collect::<Vec<_>>();
        if candidates.len() != 1 {
            return None;
        }
        let contract = self.records[candidates[0]].fields.get(field)?;
        Some(ProjectedFieldType {
            type_symbol: contract.type_symbol.clone(),
            type_identity: contract.type_identity.clone(),
            type_text: contract.type_text.clone(),
        })
    }

    #[must_use]
    pub fn field_is_ambiguous(
        &self,
        plan: &SplitPlan,
        declaration: DeclarationId,
        field: &str,
    ) -> bool {
        let shard = self.declaration_shards[declaration.0];
        self.records_by_field.get(field).is_some_and(|records| {
            records
                .iter()
                .filter(|record_index| {
                    let provider = self.records[**record_index].provider;
                    provider == shard || plan.shards[shard].compile_dependencies.contains(&provider)
                })
                .take(2)
                .count()
                > 1
        })
    }

    #[must_use]
    pub fn unique_visible_owner_type_for_leaf(
        &self,
        plan: &SplitPlan,
        declaration: DeclarationId,
        type_symbol: &str,
    ) -> Option<String> {
        let shard = self.declaration_shards[declaration.0];
        let base = type_symbol.split('<').next().unwrap_or(type_symbol).trim();
        let leaf = base.rsplit('.').next().unwrap_or(base);
        let owners = self
            .records
            .iter()
            .filter(|record| {
                record.name == leaf
                    && (record.provider == shard
                        || plan.shards[shard]
                            .compile_dependencies
                            .contains(&record.provider))
            })
            .filter_map(|record| {
                record_owner(record, shard).map(|owner| render_record_owner_type(record, owner))
            })
            .collect::<BTreeSet<_>>();
        (owners.len() == 1).then(|| owners.into_iter().next().expect("one visible owner"))
    }

    #[must_use]
    pub fn unique_owner_type(
        &self,
        plan: &SplitPlan,
        declaration: DeclarationId,
        fields: &BTreeSet<String>,
    ) -> Option<String> {
        let shard = self.declaration_shards[declaration.0];
        self.unique_record_index(plan, declaration, fields)
            .map(|record_index| {
                let record = &self.records[record_index];
                let owner = record_owner(record, shard)
                    .expect("selected record owner must be visible from the declaration");
                render_record_owner_type(record, owner)
            })
    }

    #[must_use]
    pub fn unique_owner_type_for_projections(
        &self,
        plan: &SplitPlan,
        declaration: DeclarationId,
        projections: &BTreeSet<String>,
    ) -> Option<String> {
        let shard = self.declaration_shards[declaration.0];
        self.unique_projection_record_index(plan, declaration, projections)
            .map(|record_index| {
                let record = &self.records[record_index];
                let owner = record_owner(record, shard)
                    .expect("selected projected record owner must be visible from the declaration");
                render_record_owner_type(record, owner)
            })
    }
}

#[must_use]
pub fn analyze_mutable_record_owner_contracts(
    plan: &SplitPlan,
) -> BTreeMap<DeclarationId, Vec<CallerParameterType>> {
    let projection_index = RecordProjectionIndex::new(plan);
    let declaration_shards = &projection_index.declaration_shards;
    let records = &projection_index.records;
    let union_index = analyze_union_context(plan);
    let mut mutable_records_by_field = BTreeMap::<String, Vec<usize>>::new();
    for (record_index, record) in records.iter().enumerate() {
        for (field, contract) in &record.fields {
            if contract.mutable {
                mutable_records_by_field
                    .entry(field.clone())
                    .or_default()
                    .push(record_index);
            }
        }
    }

    let mut output = BTreeMap::<DeclarationId, Vec<CallerParameterType>>::new();
    for declaration in &plan.declarations {
        let shard = declaration_shards[declaration.id.0];
        let binding_list = bindings(&declaration.text);
        let mut strong = BTreeMap::<(String, String), BTreeSet<usize>>::new();
        for binding in &binding_list {
            for parameter in &binding.parameters {
                for field_name in assigned_fields(&binding.body, parameter) {
                    let cases = matched_cases(&binding.body, parameter, &field_name);
                    let Some(record_indices) = mutable_records_by_field.get(&field_name) else {
                        continue;
                    };
                    for record_index in record_indices {
                        let record = &records[*record_index];
                        if record.provider == shard
                            || !plan.shards[shard]
                                .compile_dependencies
                                .contains(&record.provider)
                        {
                            continue;
                        }
                        let field = &record.fields[&field_name];
                        if union_contains_cases(&union_index, &field.type_symbol, &cases) {
                            strong
                                .entry((parameter.clone(), field_name.clone()))
                                .or_default()
                                .insert(*record_index);
                        }
                    }
                }
            }
        }

        for binding in &binding_list {
            for (parameter_index, parameter) in binding.parameters.iter().enumerate() {
                let strong_candidates = strong
                    .iter()
                    .filter(|((name, field), _)| {
                        name == parameter && whole_projection(&binding.body, parameter, field)
                    })
                    .flat_map(|(_, record_indices)| record_indices.iter().copied())
                    .collect::<BTreeSet<_>>();
                let record_index = if strong_candidates.len() == 1 {
                    strong_candidates.iter().next().copied()
                } else if has_projected_match_evidence(&binding.body, parameter) {
                    None
                } else {
                    let fields = unshadowed_projected_fields(&binding.body, parameter);
                    projection_index.unique_binding_record_index(plan, declaration.id, &fields)
                };
                let Some(record_index) = record_index else {
                    continue;
                };
                let record = &records[record_index];
                output
                    .entry(declaration.id)
                    .or_default()
                    .push(CallerParameterType {
                        type_arguments: 0,
                        symbol: binding.symbol.clone(),
                        parameter_index,
                        parameter_name: parameter.clone(),
                        type_symbol: render_record_owner_type(
                            record,
                            record_owner(record, shard).expect(
                                "selected record owner must be visible from the declaration",
                            ),
                        ),
                    });
            }
        }
    }
    for rows in output.values_mut() {
        rows.sort();
        rows.dedup();
    }
    output
}

#[cfg(test)]
mod type_identity_tests;

#[cfg(test)]
mod record_owner_tests;
