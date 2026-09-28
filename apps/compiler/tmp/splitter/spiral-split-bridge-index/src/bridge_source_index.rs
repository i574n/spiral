use std::collections::BTreeMap;

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct CompactPrefixIndex {
    compact_text: String,
    compact_lengths: BTreeMap<usize, usize>,
}

impl CompactPrefixIndex {
    #[must_use]
    pub fn new(text: &str, offsets: impl IntoIterator<Item = usize>) -> Self {
        let mut requested = offsets.into_iter().collect::<Vec<_>>();
        requested.sort_unstable();
        requested.dedup();
        let mut compact_text = String::with_capacity(text.len());
        let mut compact_lengths = BTreeMap::new();
        let mut next = 0usize;
        for (byte, character) in text.char_indices() {
            while next < requested.len() && requested[next] <= byte {
                compact_lengths.insert(requested[next], compact_text.len());
                next += 1;
            }
            if !character.is_whitespace() {
                compact_text.push(character);
            }
        }
        while next < requested.len() {
            compact_lengths.insert(requested[next], compact_text.len());
            next += 1;
        }
        Self {
            compact_text,
            compact_lengths,
        }
    }

    #[must_use]
    pub fn prefix(&self, offset: usize) -> Option<&str> {
        self.compact_lengths
            .get(&offset)
            .and_then(|length| self.compact_text.get(..*length))
    }
}

#[must_use]
pub fn all_anonymous_record_spans(text: &str) -> Vec<(usize, usize)> {
    let bytes = text.as_bytes();
    let mut starts = Vec::new();
    let mut spans = Vec::new();
    let mut index = 0usize;
    while index + 1 < bytes.len() {
        if bytes[index] == b'{' && bytes[index + 1] == b'|' {
            starts.push(index);
            index += 2;
            continue;
        }
        if bytes[index] == b'|' && bytes[index + 1] == b'}' {
            index += 2;
            if let Some(start) = starts.pop() {
                spans.push((start, index));
            }
            continue;
        }
        index += 1;
    }
    spans
}

#[must_use]
pub fn innermost_anonymous_record_spans(text: &str) -> Vec<(usize, usize)> {
    let bytes = text.as_bytes();
    let mut stack = Vec::<(usize, bool)>::new();
    let mut spans = Vec::new();
    let mut index = 0usize;
    while index + 1 < bytes.len() {
        if bytes[index] == b'{' && bytes[index + 1] == b'|' {
            if let Some((_, has_child)) = stack.last_mut() {
                *has_child = true;
            }
            stack.push((index, false));
            index += 2;
            continue;
        }
        if bytes[index] == b'|' && bytes[index + 1] == b'}' {
            index += 2;
            if let Some((start, has_child)) = stack.pop()
                && !has_child
            {
                spans.push((start, index));
            }
            continue;
        }
        index += 1;
    }
    spans
}

#[must_use]
pub fn anonymous_record_spans(text: &str) -> Vec<(usize, usize)> {
    let bytes = text.as_bytes();
    let mut depth = 0usize;
    let mut start = 0usize;
    let mut spans = Vec::new();
    let mut index = 0usize;
    while index + 1 < bytes.len() {
        if bytes[index] == b'{' && bytes[index + 1] == b'|' {
            if depth == 0 {
                start = index;
            }
            depth += 1;
            index += 2;
            continue;
        }
        if bytes[index] == b'|' && bytes[index + 1] == b'}' && depth > 0 {
            depth -= 1;
            index += 2;
            if depth == 0 {
                spans.push((start, index));
            }
            continue;
        }
        index += 1;
    }
    spans
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn compact_prefix_index_matches_independent_compaction() {
        let text = "let x : Alias =\n    {| a = 1; b = 2 |}\nlet y = {| x with a = 3 |}";
        let offsets = all_anonymous_record_spans(text)
            .into_iter()
            .map(|(start, _)| start)
            .collect::<Vec<_>>();
        let index = CompactPrefixIndex::new(text, offsets.iter().copied());
        for offset in offsets {
            let expected = text[..offset]
                .chars()
                .filter(|character| !character.is_whitespace())
                .collect::<String>();
            assert_eq!(index.prefix(offset), Some(expected.as_str()));
        }
    }

    #[test]
    fn span_views_distinguish_outer_and_inner_records() {
        let text = "{| a = {| b = 1 |}; c = {| d = 2 |} |}";
        assert_eq!(anonymous_record_spans(text), vec![(0, text.len())]);
        assert_eq!(innermost_anonymous_record_spans(text).len(), 2);
        assert_eq!(all_anonymous_record_spans(text).len(), 3);
    }
}
