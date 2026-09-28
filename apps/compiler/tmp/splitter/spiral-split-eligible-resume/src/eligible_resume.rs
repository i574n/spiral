use std::fs;
use std::path::{Path, PathBuf};

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct EligibleResumeState {
    pub source_fingerprint: u64,
    pub owner: usize,
    pub selected: Vec<usize>,
}

pub fn resume_path(output: &Path) -> PathBuf {
    output.with_extension("eligible-resume.tsv")
}

fn atomic_write(path: &Path, text: &str) -> Result<(), String> {
    let parent = path
        .parent()
        .ok_or_else(|| format!("resume path has no parent: {}", path.display()))?;
    fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?;
    let temporary = path.with_extension(format!("tmp-{}", std::process::id()));
    fs::write(&temporary, text)
        .map_err(|error| format!("write {}: {error}", temporary.display()))?;
    if path.exists() {
        fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?;
    }
    fs::rename(&temporary, path).map_err(|error| format!("commit {}: {error}", path.display()))
}

fn parse_selected(value: &str) -> Result<Vec<usize>, String> {
    let selected = value
        .split(',')
        .filter(|part| !part.is_empty())
        .map(|part| {
            part.parse::<usize>()
                .map_err(|error| format!("invalid eligible resume component {part}: {error}"))
        })
        .collect::<Result<Vec<_>, _>>()?;
    if selected.is_empty() {
        Err("eligible resume selected set is empty".to_owned())
    } else {
        Ok(selected)
    }
}

pub fn load_or_initialize(
    path: &Path,
    source_fingerprint: u64,
    owner: usize,
    initial: Vec<usize>,
) -> Result<EligibleResumeState, String> {
    if !path.exists() {
        if initial.is_empty() {
            return Err("eligible resume initial set is empty".to_owned());
        }
        return Ok(EligibleResumeState {
            source_fingerprint,
            owner,
            selected: initial,
        });
    }
    let text =
        fs::read_to_string(path).map_err(|error| format!("read {}: {error}", path.display()))?;
    let mut fingerprint = None;
    let mut parsed_owner = None;
    let mut status = None;
    let mut selected = None;
    for line in text.lines().skip(1) {
        let mut fields = line.splitn(2, '\t');
        let Some(key) = fields.next() else { continue };
        let Some(value) = fields.next() else { continue };
        match key {
            "status" => status = Some(value.to_owned()),
            "source_fingerprint" => {
                fingerprint = Some(value.parse::<u64>().map_err(|error| {
                    format!("invalid eligible resume fingerprint {value}: {error}")
                })?)
            }
            "owner" => {
                parsed_owner =
                    Some(value.parse::<usize>().map_err(|error| {
                        format!("invalid eligible resume owner {value}: {error}")
                    })?)
            }
            "selected" => selected = Some(value.to_owned()),
            _ => {}
        }
    }
    let status = status.ok_or_else(|| "eligible resume status missing".to_owned())?;
    let selected = selected.ok_or_else(|| "eligible resume selected set missing".to_owned())?;
    let selected = if selected.is_empty() && status == "complete" {
        Vec::new()
    } else {
        parse_selected(&selected)?
    };
    let state = EligibleResumeState {
        source_fingerprint: fingerprint
            .ok_or_else(|| "eligible resume fingerprint missing".to_owned())?,
        owner: parsed_owner.ok_or_else(|| "eligible resume owner missing".to_owned())?,
        selected,
    };
    if state.source_fingerprint != source_fingerprint || state.owner != owner {
        return Err(format!(
            "eligible resume identity mismatch: state_fingerprint={} source_fingerprint={} state_owner={} owner={}",
            state.source_fingerprint, source_fingerprint, state.owner, owner
        ));
    }
    Ok(state)
}

pub fn write_state(
    path: &Path,
    state: &EligibleResumeState,
    status: &str,
    blocked_component: Option<usize>,
) -> Result<(), String> {
    let selected = state
        .selected
        .iter()
        .map(usize::to_string)
        .collect::<Vec<_>>()
        .join(",");
    let blocked = blocked_component
        .map(|value| value.to_string())
        .unwrap_or_else(|| "-".to_owned());
    let text = format!(
        "key\tvalue\nstatus\t{status}\nsource_fingerprint\t{}\nowner\t{}\nselected\t{selected}\nblocked_component\t{blocked}\n",
        state.source_fingerprint, state.owner
    );
    atomic_write(path, &text)
}

#[cfg(test)]
mod tests {
    use super::*;
    use std::time::{SystemTime, UNIX_EPOCH};

    fn temp_path(name: &str) -> PathBuf {
        let nonce = SystemTime::now()
            .duration_since(UNIX_EPOCH)
            .expect("clock")
            .as_nanos();
        std::env::temp_dir().join(format!(
            "spiral-eligible-resume-{name}-{}-{nonce}.tsv",
            std::process::id()
        ))
    }

    #[test]
    fn round_trips_yielded_selection() {
        let path = temp_path("roundtrip");
        let state = EligibleResumeState {
            source_fingerprint: 17,
            owner: 9,
            selected: vec![1, 4, 7],
        };
        write_state(&path, &state, "yield", Some(3)).expect("write");
        let loaded = load_or_initialize(&path, 17, 9, vec![99]).expect("load");
        assert_eq!(loaded, state);
        let _ = fs::remove_file(path);
    }

    #[test]
    fn round_trips_completed_empty_selection() {
        let path = temp_path("empty-complete");
        let state = EligibleResumeState {
            source_fingerprint: 17,
            owner: 9,
            selected: Vec::new(),
        };
        write_state(&path, &state, "complete", Some(7)).expect("write");
        let loaded = load_or_initialize(&path, 17, 9, vec![99]).expect("load");
        assert_eq!(loaded, state);
        let _ = fs::remove_file(path);
    }

    #[test]
    fn rejects_stale_identity() {
        let path = temp_path("stale");
        let state = EligibleResumeState {
            source_fingerprint: 17,
            owner: 9,
            selected: vec![1],
        };
        write_state(&path, &state, "yield", None).expect("write");
        assert!(load_or_initialize(&path, 18, 9, vec![1]).is_err());
        let _ = fs::remove_file(path);
    }
}
