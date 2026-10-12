use std::collections::BTreeSet;

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub struct MemberProjectionIndex {
    names: BTreeSet<String>,
}

impl MemberProjectionIndex {
    pub fn from_texts<'a>(texts: impl IntoIterator<Item = &'a str>) -> Self {
        let names = texts
            .into_iter()
            .flat_map(member_projection_names)
            .collect::<BTreeSet<_>>();
        Self { names }
    }

    pub fn contains(&self, name: &str) -> bool {
        self.names.contains(name)
    }

    pub fn shadows_fields(&self, fields: &BTreeSet<String>) -> bool {
        fields.iter().any(|field| self.contains(field))
    }
}

pub fn member_projection_names(text: &str) -> BTreeSet<String> {
    text.lines().filter_map(member_projection_name).collect()
}

fn member_projection_name(line: &str) -> Option<String> {
    let mut rest = line.trim_start().strip_prefix("member ")?.trim_start();
    loop {
        let stripped = ["private ", "internal ", "public "]
            .into_iter()
            .find_map(|modifier| rest.strip_prefix(modifier));
        match stripped {
            Some(next) => rest = next.trim_start(),
            None => break,
        }
    }

    let dot = rest.find('.')?;
    let after_dot = &rest[dot + 1..];
    let mut end = 0usize;
    for (offset, character) in after_dot.char_indices() {
        let allowed = character == '_' || character == '\'' || character.is_alphanumeric();
        if !allowed {
            break;
        }
        end = offset + character.len_utf8();
    }
    (end > 0).then(|| after_dot[..end].to_owned())
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn indexes_instance_members_without_confusing_regular_bindings() {
        let text = r#"
type Receipt = { receipt : Payload }
with
    member this.kind = this.receipt.payload.kind
    member _.context = failwith "not evaluated"
    member private self.receipt = self.receipt
let context = 1
"#;
        let names = member_projection_names(text);
        assert_eq!(
            names,
            ["context", "kind", "receipt"]
                .into_iter()
                .map(str::to_owned)
                .collect()
        );
    }

    #[test]
    fn reports_any_projected_member_shadow() {
        let index = MemberProjectionIndex::from_texts([
            "member this.kind = this.receipt.payload.kind",
            "member this.context = this.receipt.payload.context",
        ]);
        let fields = ["context", "other"]
            .into_iter()
            .map(str::to_owned)
            .collect::<BTreeSet<_>>();
        assert!(index.shadows_fields(&fields));
    }

    #[test]
    fn record_only_fields_remain_unshadowed() {
        let index = MemberProjectionIndex::from_texts(["member this.kind = this.payload.kind"]);
        let fields = ["state", "continuationRef"]
            .into_iter()
            .map(str::to_owned)
            .collect::<BTreeSet<_>>();
        assert!(!index.shadows_fields(&fields));
    }
}
