#[derive(Clone, Debug, Eq, PartialEq)]
pub struct OrderedReplacementIndex {
    buckets: Vec<Vec<usize>>,
    phase_starts: Vec<usize>,
}

fn later_matches(
    buckets: &[Vec<usize>],
    rules: &[(String, String)],
    current_index: usize,
    text: &str,
) -> Vec<usize> {
    let bytes = text.as_bytes();
    let mut matches = Vec::new();
    let mut cursor = 0usize;
    while cursor < bytes.len() {
        let remaining = &text[cursor..];
        for index in buckets[bytes[cursor] as usize].iter().copied() {
            if index > current_index
                && !rules[index].0.is_empty()
                && remaining.starts_with(&rules[index].0)
            {
                matches.push(index);
            }
        }
        let character = remaining.chars().next().expect("cursor is in bounds");
        cursor += character.len_utf8();
    }
    matches.sort_unstable();
    matches.dedup();
    matches
}

impl OrderedReplacementIndex {
    #[must_use]
    pub fn new(rules: &[(String, String)]) -> Self {
        let mut buckets = vec![Vec::new(); 256];
        for (index, (from, _)) in rules.iter().enumerate() {
            if let Some(first) = from.as_bytes().first() {
                buckets[*first as usize].push(index);
            }
        }

        let mut latest_prior_trigger = vec![None::<usize>; rules.len()];
        for (index, (_, replacement)) in rules.iter().enumerate() {
            for later in later_matches(&buckets, rules, index, replacement) {
                latest_prior_trigger[later] =
                    Some(latest_prior_trigger[later].map_or(index, |prior| prior.max(index)));
            }
        }

        let mut phase_starts = vec![0usize];
        let mut phase_start = 0usize;
        for (index, trigger) in latest_prior_trigger.into_iter().enumerate() {
            if index > phase_start && trigger.is_some_and(|prior| prior >= phase_start) {
                phase_starts.push(index);
                phase_start = index;
            }
        }

        Self {
            buckets,
            phase_starts,
        }
    }

    #[must_use]
    pub fn is_cascade_free(&self) -> bool {
        self.phase_starts.len() <= 1
    }

    fn apply_phase(
        &self,
        text: &str,
        rules: &[(String, String)],
        start: usize,
        end: usize,
    ) -> String {
        let bytes = text.as_bytes();
        let mut output = String::with_capacity(text.len());
        let mut cursor = 0usize;
        while cursor < bytes.len() {
            let remaining = &text[cursor..];
            let matched = self.buckets[bytes[cursor] as usize]
                .iter()
                .copied()
                .find(|index| {
                    start <= *index
                        && *index < end
                        && !rules[*index].0.is_empty()
                        && remaining.starts_with(&rules[*index].0)
                });
            if let Some(index) = matched {
                let (from, to) = &rules[index];
                output.push_str(to);
                cursor += from.len();
                continue;
            }
            let character = remaining.chars().next().expect("cursor is in bounds");
            output.push(character);
            cursor += character.len_utf8();
        }
        output
    }

    #[must_use]
    pub fn apply(&self, text: &str, rules: &[(String, String)]) -> String {
        if rules.is_empty() {
            return text.to_owned();
        }
        let mut output = text.to_owned();
        for (phase, start) in self.phase_starts.iter().copied().enumerate() {
            let end = self
                .phase_starts
                .get(phase + 1)
                .copied()
                .unwrap_or(rules.len());
            output = self.apply_phase(&output, rules, start, end);
        }
        output
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn ordered_overlap_uses_first_matching_rule() {
        let rules = vec![
            ("Alpha.Beta".to_owned(), "X".to_owned()),
            ("Alpha".to_owned(), "Y".to_owned()),
        ];
        let index = OrderedReplacementIndex::new(&rules);
        assert!(index.is_cascade_free());
        assert_eq!(index.apply("Alpha.Beta Alpha", &rules), "X Y");
    }

    #[test]
    fn cascade_uses_multiple_phases_with_sequential_semantics() {
        let rules = vec![
            ("a".to_owned(), "b".to_owned()),
            ("b".to_owned(), "c".to_owned()),
            ("c".to_owned(), "d".to_owned()),
        ];
        let index = OrderedReplacementIndex::new(&rules);
        assert!(!index.is_cascade_free());
        assert_eq!(index.apply("a", &rules), "d");
    }

    #[test]
    fn non_cascading_rules_share_a_single_phase() {
        let rules = vec![
            ("a".to_owned(), "x".to_owned()),
            ("b".to_owned(), "y".to_owned()),
            ("c".to_owned(), "z".to_owned()),
        ];
        let index = OrderedReplacementIndex::new(&rules);
        assert!(index.is_cascade_free());
        assert_eq!(index.apply("abc", &rules), "xyz");
    }

    #[test]
    fn unicode_text_keeps_character_boundaries() {
        let rules = vec![("β.gamma".to_owned(), "delta".to_owned())];
        let index = OrderedReplacementIndex::new(&rules);
        assert_eq!(index.apply("α β.gamma ω", &rules), "α delta ω");
    }
}
