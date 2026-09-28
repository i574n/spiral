/// Keywords that may precede a top-level binding's name, in any order and with any spacing.
const DECLARATION_MODIFIERS: [&str; 6] = ["rec", "mutable", "inline", "private", "internal", "static"];

/// Makes a shard's top-level declaration public. A module is split across shards, so privacy relative
/// to the original module would hide a binding from its own module's other shards. The leading
/// keywords are parsed rather than matched as fixed strings: the hopac core also spells them with
/// extra spaces (`let  private capConcurrency`), which a fixed prefix list missed.
pub(super) fn make_public_top_level(line: &str) -> String {
    if !line.starts_with("    ") || line.starts_with("        ") {
        return line.to_owned();
    }
    let body = &line[4..];
    let mut words = body.split_whitespace();
    let Some(head) = words.next() else {
        return line.to_owned();
    };
    if matches!(head, "let" | "type" | "module") {
        // Consume the modifier words that follow the head keyword and drop `private`/`internal`.
        let mut rest = body[head.len()..].trim_start();
        let mut kept = Vec::new();
        let mut changed = false;
        loop {
            let word_end = rest.find(char::is_whitespace).unwrap_or(rest.len());
            let word = &rest[..word_end];
            if !DECLARATION_MODIFIERS.contains(&word) || word_end == rest.len() {
                break;
            }
            if word == "private" || word == "internal" {
                changed = true;
            } else {
                kept.push(word);
            }
            rest = rest[word_end..].trim_start();
        }
        if changed {
            let mut output = format!("    {head} ");
            for word in kept {
                output.push_str(word);
                output.push(' ');
            }
            output.push_str(rest);
            return output;
        }
    }
    if line.starts_with("    type ") || line.starts_with("    and ") {
        return line.replacen(" = private ", " = ", 1);
    }
    line.to_owned()
}

#[cfg(test)]
mod tests {
    use super::make_public_top_level;

    #[test]
    fn widens_private_bindings_with_any_spacing() {
        assert_eq!(make_public_top_level("    let private f x = x"), "    let f x = x");
        assert_eq!(
            make_public_top_level("    let  private capConcurrency (requested: int) : int ="),
            "    let capConcurrency (requested: int) : int ="
        );
        assert_eq!(make_public_top_level("    let inline private g = 1"), "    let inline g = 1");
        assert_eq!(make_public_top_level("    let private inline g = 1"), "    let inline g = 1");
        assert_eq!(make_public_top_level("    let rec private h () = h ()"), "    let rec h () = h ()");
        assert_eq!(make_public_top_level("    let mutable private m = 0"), "    let mutable m = 0");
        assert_eq!(make_public_top_level("    type private T = int"), "    type T = int");
        assert_eq!(make_public_top_level("    module private M ="), "    module M =");
    }

    #[test]
    fn leaves_public_nested_and_representation_lines_alone() {
        assert_eq!(make_public_top_level("    let f x = x"), "    let f x = x");
        assert_eq!(make_public_top_level("        let private local = 1"), "        let private local = 1");
        assert_eq!(make_public_top_level("    type T = private { x : int }"), "    type T = { x : int }");
    }
}
