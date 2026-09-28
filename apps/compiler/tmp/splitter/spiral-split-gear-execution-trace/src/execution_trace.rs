use std::fs::{self, OpenOptions};
use std::io::Write;
use std::path::{Path, PathBuf};
use std::time::Instant;

#[derive(Debug)]
pub struct ExecutionPhases {
    path: PathBuf,
    started: Instant,
}

impl ExecutionPhases {
    pub fn new(output_root: &Path) -> Result<Self, String> {
        let path = output_root.join("gear-execution-phases.tsv");
        atomic_write(&path, b"phase\telapsed_ms\n")?;
        let mut phases = Self {
            path,
            started: Instant::now(),
        };
        phases.record("start")?;
        Ok(phases)
    }

    pub fn record(&mut self, phase: &str) -> Result<(), String> {
        let elapsed = self.started.elapsed().as_secs_f64() * 1_000.0;
        append_row(&self.path, &format!("{phase}\t{elapsed:.3}\n"))
    }
}

#[derive(Debug)]
pub struct GearWorkerTrace {
    path: PathBuf,
    started: Instant,
}

impl GearWorkerTrace {
    pub fn new(output_root: &Path, gear: usize) -> Result<Self, String> {
        let path = output_root.join(format!(".gear-build/worker-trace/Gear{gear:04}.tsv"));
        atomic_write(&path, b"phase\telapsed_ms\n")?;
        let mut trace = Self {
            path,
            started: Instant::now(),
        };
        trace.record("start")?;
        Ok(trace)
    }

    pub fn record(&mut self, phase: &str) -> Result<(), String> {
        let elapsed = self.started.elapsed().as_secs_f64() * 1_000.0;
        append_row(&self.path, &format!("{phase}\t{elapsed:.3}\n"))
    }
}

fn append_row(path: &Path, row: &str) -> Result<(), String> {
    let mut file = OpenOptions::new()
        .create(true)
        .append(true)
        .open(path)
        .map_err(|error| format!("open {}: {error}", path.display()))?;
    file.write_all(row.as_bytes())
        .map_err(|error| format!("append {}: {error}", path.display()))
}

fn atomic_write(path: &Path, bytes: &[u8]) -> Result<(), String> {
    let parent = path
        .parent()
        .ok_or_else(|| format!("path has no parent: {}", path.display()))?;
    fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?;
    let temporary = path.with_extension(format!("tmp-{}", std::process::id()));
    fs::write(&temporary, bytes)
        .map_err(|error| format!("write {}: {error}", temporary.display()))?;
    if path.exists() {
        fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?;
    }
    fs::rename(&temporary, path).map_err(|error| format!("commit {}: {error}", path.display()))
}
