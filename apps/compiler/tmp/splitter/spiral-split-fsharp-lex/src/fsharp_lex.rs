use std::fmt::{Display, Formatter};

#[derive(Clone, Copy, Debug, Default, Eq, Ord, PartialEq, PartialOrd)]
pub enum LexicalState {
    #[default]
    Code,
    LineComment,
    BlockComment {
        depth: usize,
    },
    StringLiteral,
    VerbatimString,
    InterpolatedString {
        brace_depth: usize,
    },
    CharacterLiteral,
}

impl Display for LexicalState {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::Code => formatter.write_str("code"),
            Self::LineComment => formatter.write_str("line-comment"),
            Self::BlockComment { depth } => write!(formatter, "block-comment:{depth}"),
            Self::StringLiteral => formatter.write_str("string"),
            Self::VerbatimString => formatter.write_str("verbatim-string"),
            Self::InterpolatedString { brace_depth } => {
                write!(formatter, "interpolated-string:{brace_depth}")
            }
            Self::CharacterLiteral => formatter.write_str("character"),
        }
    }
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum LexicalBlocker {
    TripleQuotedString,
}

impl Display for LexicalBlocker {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::TripleQuotedString => formatter.write_str("triple-quoted-string"),
        }
    }
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub struct LexicalTransition {
    pub state: LexicalState,
    pub consumed: usize,
}

fn scalar_width(byte: u8) -> usize {
    match byte {
        0x00..=0x7f => 1,
        0xc0..=0xdf => 2,
        0xe0..=0xef => 3,
        _ => 4,
    }
}

fn verbatim_string_prefix_len(bytes: &[u8], index: usize) -> Option<usize> {
    if bytes.get(index..index + 2) == Some(b"@\"") {
        Some(2)
    } else if bytes.get(index..index + 3) == Some(b"$@\"")
        || bytes.get(index..index + 3) == Some(b"@$\"")
    {
        Some(3)
    } else {
        None
    }
}

#[must_use]
pub fn identifier_continue(byte: u8) -> bool {
    byte == b'_' || byte.is_ascii_alphanumeric() || byte == b'\''
}

#[must_use]
pub fn character_literal_starts(bytes: &[u8], index: usize) -> bool {
    if bytes.get(index) != Some(&b'\'') {
        return false;
    }
    if bytes.get(index + 1) == Some(&b'\\') {
        return bytes.get(index + 3) == Some(&b'\'');
    }
    let Some(first) = bytes.get(index + 1).copied() else {
        return false;
    };
    bytes.get(index + 1 + scalar_width(first)) == Some(&b'\'')
}

pub fn transition(
    state: LexicalState,
    bytes: &[u8],
    index: usize,
) -> Result<Option<LexicalTransition>, LexicalBlocker> {
    let current = bytes[index];
    let next = bytes.get(index + 1).copied();
    let transition = match state {
        LexicalState::LineComment => Some(LexicalTransition {
            state: if current == b'\n' {
                LexicalState::Code
            } else {
                LexicalState::LineComment
            },
            consumed: scalar_width(current),
        }),
        LexicalState::BlockComment { depth } => {
            if current == b'(' && next == Some(b'*') {
                Some(LexicalTransition {
                    state: LexicalState::BlockComment { depth: depth + 1 },
                    consumed: 2,
                })
            } else if current == b'*' && next == Some(b')') {
                Some(LexicalTransition {
                    state: if depth == 1 {
                        LexicalState::Code
                    } else {
                        LexicalState::BlockComment { depth: depth - 1 }
                    },
                    consumed: 2,
                })
            } else {
                Some(LexicalTransition {
                    state,
                    consumed: scalar_width(current),
                })
            }
        }
        LexicalState::StringLiteral => {
            if current == b'\\' && next.is_some() {
                Some(LexicalTransition { state, consumed: 2 })
            } else {
                Some(LexicalTransition {
                    state: if current == b'"' {
                        LexicalState::Code
                    } else {
                        state
                    },
                    consumed: scalar_width(current),
                })
            }
        }
        LexicalState::VerbatimString => {
            if current == b'"' && next == Some(b'"') {
                Some(LexicalTransition { state, consumed: 2 })
            } else {
                Some(LexicalTransition {
                    state: if current == b'"' {
                        LexicalState::Code
                    } else {
                        state
                    },
                    consumed: scalar_width(current),
                })
            }
        }
        LexicalState::InterpolatedString { brace_depth } => {
            let state_at = |brace_depth| LexicalState::InterpolatedString { brace_depth };
            if (current == b'\\' && next.is_some())
                || (brace_depth == 0
                    && ((current == b'{' && next == Some(b'{'))
                        || (current == b'}' && next == Some(b'}'))))
            {
                Some(LexicalTransition { state, consumed: 2 })
            } else if current == b'{' {
                Some(LexicalTransition {
                    state: state_at(brace_depth + 1),
                    consumed: 1,
                })
            } else if current == b'}' && brace_depth > 0 {
                Some(LexicalTransition {
                    state: state_at(brace_depth - 1),
                    consumed: 1,
                })
            } else if current == b'"' && brace_depth == 0 {
                Some(LexicalTransition {
                    state: LexicalState::Code,
                    consumed: 1,
                })
            } else {
                Some(LexicalTransition {
                    state,
                    consumed: scalar_width(current),
                })
            }
        }
        LexicalState::CharacterLiteral => {
            if current == b'\\' && next.is_some() {
                Some(LexicalTransition { state, consumed: 2 })
            } else {
                Some(LexicalTransition {
                    state: if current == b'\'' {
                        LexicalState::Code
                    } else {
                        state
                    },
                    consumed: scalar_width(current),
                })
            }
        }
        LexicalState::Code => {
            if current == b'/' && next == Some(b'/') {
                Some(LexicalTransition {
                    state: LexicalState::LineComment,
                    consumed: 2,
                })
            } else if current == b'(' && next == Some(b'*') {
                Some(LexicalTransition {
                    state: LexicalState::BlockComment { depth: 1 },
                    consumed: 2,
                })
            } else if bytes.get(index..index + 3) == Some(b"\"\"\"") {
                let tail = &bytes[index + 3..];
                let Some(close_relative) = tail.windows(3).position(|window| window == b"\"\"\"")
                else {
                    return Err(LexicalBlocker::TripleQuotedString);
                };
                Some(LexicalTransition {
                    state: LexicalState::Code,
                    consumed: 6 + close_relative,
                })
            } else if let Some(consumed) = verbatim_string_prefix_len(bytes, index) {
                Some(LexicalTransition {
                    state: LexicalState::VerbatimString,
                    consumed,
                })
            } else if bytes.get(index..index + 2) == Some(b"$\"") {
                Some(LexicalTransition {
                    state: LexicalState::InterpolatedString { brace_depth: 0 },
                    consumed: 2,
                })
            } else if current == b'"' {
                Some(LexicalTransition {
                    state: LexicalState::StringLiteral,
                    consumed: scalar_width(current),
                })
            } else {
                None
            }
        }
    };
    Ok(transition)
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub struct SymbolLexicalProbe {
    pub code: usize,
    pub line_comment: usize,
    pub block_comment: usize,
    pub string_literal: usize,
    pub verbatim_string: usize,
    pub interpolated_string: usize,
    pub character_literal: usize,
    pub final_state: LexicalState,
    pub final_state_entry_offset: usize,
    pub final_state_entry_line: usize,
    pub first_string_newline_line: usize,
    pub first_symbol_line: usize,
    pub first_symbol_state_entry_line: usize,
    pub first_symbol_second_prior_state_entry_line: usize,
    pub first_symbol_last_code_line: usize,
}

impl Default for SymbolLexicalProbe {
    fn default() -> Self {
        Self {
            code: 0,
            line_comment: 0,
            block_comment: 0,
            string_literal: 0,
            verbatim_string: 0,
            interpolated_string: 0,
            character_literal: 0,
            final_state: LexicalState::Code,
            final_state_entry_offset: 0,
            final_state_entry_line: 1,
            first_string_newline_line: 0,
            first_symbol_line: 0,
            first_symbol_state_entry_line: 0,
            first_symbol_second_prior_state_entry_line: 0,
            first_symbol_last_code_line: 0,
        }
    }
}

impl SymbolLexicalProbe {
    fn record(&mut self, state: LexicalState) {
        match state {
            LexicalState::Code => self.code += 1,
            LexicalState::LineComment => self.line_comment += 1,
            LexicalState::BlockComment { .. } => self.block_comment += 1,
            LexicalState::StringLiteral => self.string_literal += 1,
            LexicalState::VerbatimString => self.verbatim_string += 1,
            LexicalState::InterpolatedString { .. } => self.interpolated_string += 1,
            LexicalState::CharacterLiteral => self.character_literal += 1,
        }
    }
}

fn symbol_at(bytes: &[u8], index: usize, symbol: &[u8]) -> bool {
    if bytes.get(index..index + symbol.len()) != Some(symbol) {
        return false;
    }
    let before = index.checked_sub(1).and_then(|at| bytes.get(at)).copied();
    let after = bytes.get(index + symbol.len()).copied();
    before.is_none_or(|byte| !identifier_continue(byte))
        && after.is_none_or(|byte| !identifier_continue(byte))
}

pub fn line_start_states(text: &str) -> Result<Vec<LexicalState>, LexicalBlocker> {
    let bytes = text.as_bytes();
    let mut states = vec![LexicalState::Code];
    let mut state = LexicalState::Code;
    let mut index = 0usize;
    while index < bytes.len() {
        let (next_state, consumed) = if let Some(step) = transition(state, bytes, index)? {
            (step.state, step.consumed)
        } else if state == LexicalState::Code && character_literal_starts(bytes, index) {
            (LexicalState::CharacterLiteral, 1)
        } else {
            (state, 1)
        };
        let newlines = bytes[index..index + consumed]
            .iter()
            .filter(|byte| **byte == b'\n')
            .count();
        state = next_state;
        states.extend(std::iter::repeat_n(state, newlines));
        index += consumed;
    }
    Ok(states)
}

pub fn probe_symbol_states(text: &str, symbol: &str) -> Result<SymbolLexicalProbe, LexicalBlocker> {
    let bytes = text.as_bytes();
    let symbol = symbol.as_bytes();
    let mut probe = SymbolLexicalProbe::default();
    let mut state = LexicalState::Code;
    let mut state_entry_offset = 0usize;
    let mut state_entry_line = 1usize;
    let mut previous_state_entry_line = 1usize;
    let mut second_previous_state_entry_line = 1usize;
    let mut line = 1usize;
    let mut last_code_line = 1usize;
    let mut index = 0usize;
    while index < bytes.len() {
        if (index == 0 || bytes.get(index.wrapping_sub(1)) == Some(&b'\n'))
            && state == LexicalState::Code
            && probe.first_symbol_line == 0
        {
            last_code_line = line;
        }
        if state == LexicalState::StringLiteral
            && bytes[index] == b'\n'
            && probe.first_string_newline_line == 0
        {
            probe.first_string_newline_line = line;
        }
        if !symbol.is_empty() && symbol_at(bytes, index, symbol) {
            if probe.first_symbol_line == 0 {
                probe.first_symbol_line = line;
                probe.first_symbol_state_entry_line = state_entry_line;
                probe.first_symbol_second_prior_state_entry_line = second_previous_state_entry_line;
                probe.first_symbol_last_code_line = last_code_line;
            }
            probe.record(state);
        }
        if let Some(step) = transition(state, bytes, index)? {
            if step.state != state {
                second_previous_state_entry_line = previous_state_entry_line;
                previous_state_entry_line = state_entry_line;
                state_entry_offset = index;
                state_entry_line = line;
            }
            line += bytes[index..index + step.consumed]
                .iter()
                .filter(|byte| **byte == b'\n')
                .count();
            state = step.state;
            index += step.consumed;
        } else if state == LexicalState::Code && character_literal_starts(bytes, index) {
            second_previous_state_entry_line = previous_state_entry_line;
            previous_state_entry_line = state_entry_line;
            state_entry_offset = index;
            state_entry_line = line;
            state = LexicalState::CharacterLiteral;
            index += 1;
        } else {
            if bytes[index] == b'\n' {
                line += 1;
            }
            index += 1;
        }
    }
    probe.final_state = state;
    probe.final_state_entry_offset = state_entry_offset;
    probe.final_state_entry_line = state_entry_line;
    Ok(probe)
}

pub fn code_only_mask(text: &str) -> Result<String, LexicalBlocker> {
    let bytes = text.as_bytes();
    let mut output = vec![b' '; bytes.len()];
    let mut state = LexicalState::Code;
    let mut index = 0usize;
    while index < bytes.len() {
        if let Some(step) = transition(state, bytes, index)? {
            for offset in index..index + step.consumed {
                if bytes[offset] == b'\n' {
                    output[offset] = b'\n';
                }
            }
            state = step.state;
            index += step.consumed;
        } else if state == LexicalState::Code && character_literal_starts(bytes, index) {
            state = LexicalState::CharacterLiteral;
            index += 1;
        } else {
            let consumed = scalar_width(bytes[index]);
            if state == LexicalState::Code {
                output[index..index + consumed].copy_from_slice(&bytes[index..index + consumed]);
            } else if bytes[index] == b'\n' {
                output[index] = b'\n';
            }
            index += consumed;
        }
    }
    Ok(String::from_utf8(output).expect("code mask is valid UTF-8"))
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn trailing_backslash_in_verbatim_string_closes_at_quote() {
        let text = "let x = @\"C:\\\"\nhelper value\n";
        let probe = probe_symbol_states(text, "helper").expect("probe");
        assert_eq!(probe.code, 1);
        assert_eq!(probe.verbatim_string, 0);
        assert_eq!(probe.final_state, LexicalState::Code);
    }

    #[test]
    fn doubled_quotes_stay_inside_verbatim_string() {
        let text = "let x = @\"helper says \"\"helper\"\"\"\nhelper value\n";
        let probe = probe_symbol_states(text, "helper").expect("probe");
        assert_eq!(probe.code, 1);
        assert_eq!(probe.verbatim_string, 2);
        assert_eq!(probe.final_state, LexicalState::Code);
    }

    #[test]
    fn interpolated_string_balances_expression_braces() {
        let text = "$\"value = {value}\"\nhelper value\n";
        let probe = probe_symbol_states(text, "helper").expect("probe");
        assert_eq!(probe.code, 1);
        assert_eq!(probe.final_state, LexicalState::Code);
    }

    #[test]
    fn triple_quotes_are_opaque_in_code() {
        let verbatim = "let x = @\"quoted \"\"helper\"\"\"\n";
        assert!(probe_symbol_states(verbatim, "helper").is_ok());
        let triple = "let x = \"\"\"helper\nhelper\"\"\"\nhelper value\n";
        let probe = probe_symbol_states(triple, "helper").expect("probe");
        assert_eq!(probe.code, 1);
        assert_eq!(probe.final_state, LexicalState::Code);
        let masked = code_only_mask(triple).expect("mask");
        assert!(!masked.contains("helper\nhelper"));
        assert!(masked.contains("helper value"));
    }

    #[test]
    fn unclosed_triple_quote_stays_fail_closed() {
        let triple = "let x = \"\"\"helper\n";
        assert_eq!(
            probe_symbol_states(triple, "helper"),
            Err(LexicalBlocker::TripleQuotedString)
        );
    }

    #[test]
    fn code_mask_removes_string_member_like_text() {
        let text = "let f apply =\n    let message = \"type apply.\\n\"\n    apply value\n";
        let masked = code_only_mask(text).expect("mask");
        assert!(!masked.contains("apply."));
        assert!(masked.contains("apply value"));
        assert_eq!(masked.len(), text.len());
    }
}
