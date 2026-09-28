use spiral_split_build_budget::{BudgetDecision, BuildBudget};
use spiral_split_matrix_receipt::{
    MatrixReceipt, MatrixStatus, Stage, StageReceipt, StageStatus, parse_resume_rows,
};
use spiral_split_process_supervisor::{ProcessCapture, run_bounded_process};
use std::env;
use std::fs;
use std::path::{Path, PathBuf};
use std::process::Command;
use std::time::{Duration, Instant};

macro_rules! render_receipt {
    ($identity:expr, $status:expr, $lanes:expr, $completed:expr, $lane:expr, $stage:expr, $elapsed:expr, $rows:expr $(,)?) => {{
        MatrixReceipt::new(
            $identity,
            MatrixStatus::parse($status).expect("matrix receipt status"),
            ($lanes.len(), $completed),
            ($lane, $stage),
            $elapsed,
            $rows,
        )
        .render()
    }};
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct Lane {
    name: String,
    source: PathBuf,
    output: PathBuf,
    policy: String,
    max_lines: usize,
    reference: String,
}

#[derive(Clone, Debug)]
struct Options {
    spiral_split: PathBuf,
    manifest: PathBuf,
    receipt: PathBuf,
    cache_root: PathBuf,
    assembly_root: PathBuf,
    dotnet: PathBuf,
    emit_threads: usize,
    build_threads: usize,
    gears_timeout: Duration,
    process_timeout: Duration,
    lane_build_budget: Duration,
    build_reserve: Duration,
    matrix_budget: Duration,
    matrix_reserve: Duration,
}

#[derive(Clone, Debug)]
enum MatrixOutcome {
    Passed,
    Yielded {
        lane: String,
        stage: Stage,
        note: String,
    },
}

fn hash_bytes(mut hash: u64, bytes: &[u8]) -> u64 {
    for byte in bytes {
        hash = (hash ^ u64::from(*byte)).wrapping_mul(1_099_511_628_211);
    }
    hash
}

fn hash_file(hash: u64, path: &Path) -> Result<u64, String> {
    let bytes = fs::read(path)
        .map_err(|error| format!("read identity file {}: {error}", path.display()))?;
    Ok(hash_bytes(
        hash_bytes(hash, path.to_string_lossy().as_bytes()),
        &bytes,
    ))
}

fn collect_files(root: &Path, output: &mut Vec<PathBuf>) -> Result<(), String> {
    let mut entries = fs::read_dir(root)
        .map_err(|error| format!("read identity directory {}: {error}", root.display()))?
        .collect::<Result<Vec<_>, _>>()
        .map_err(|error| format!("read identity directory entry {}: {error}", root.display()))?;
    entries.sort_by_key(|entry| entry.file_name());
    for entry in entries {
        let path = entry.path();
        let kind = entry
            .file_type()
            .map_err(|error| format!("inspect identity path {}: {error}", path.display()))?;
        if kind.is_dir() {
            collect_files(&path, output)?;
        } else if kind.is_file() {
            output.push(path);
        }
    }
    Ok(())
}

fn matrix_identity(options: &Options, lanes: &[Lane]) -> Result<String, String> {
    let mut hash = 14_695_981_039_346_656_037u64;
    let executable = env::current_exe().map_err(|error| format!("matrix executable: {error}"))?;
    hash = hash_file(hash, &executable)?;
    hash = hash_file(hash, &options.spiral_split)?;
    hash = hash_file(hash, &options.dotnet)?;
    hash = hash_file(hash, &options.manifest)?;
    for lane in lanes {
        hash = hash_bytes(hash, lane.name.as_bytes());
        hash = hash_bytes(hash, lane.policy.as_bytes());
        hash = hash_bytes(hash, lane.reference.as_bytes());
        hash = hash_bytes(hash, &lane.max_lines.to_le_bytes());
        hash = hash_file(hash, &lane.source)?;
    }
    let mut assembly_files = Vec::new();
    collect_files(&options.assembly_root, &mut assembly_files)?;
    for path in assembly_files {
        let relative = path.strip_prefix(&options.assembly_root).unwrap_or(&path);
        hash = hash_bytes(hash, relative.to_string_lossy().as_bytes());
        hash = hash_file(hash, &path)?;
    }
    Ok(format!("{hash:016x}"))
}

fn load_resume_rows(path: &Path, identity: &str) -> Vec<StageReceipt> {
    fs::read_to_string(path)
        .map(|text| parse_resume_rows(&text, identity))
        .unwrap_or_default()
}

fn stage_artifact_passed(lane: &Lane, stage: Stage) -> bool {
    match stage {
        Stage::Gears => {
            lane.output.join("source.receipt.tsv").is_file()
                && lane.output.join("gears.tsv").is_file()
        }
        Stage::Build => receipt_status(&lane.output.join("gear-build.receipt.tsv"))
            .is_ok_and(|status| status == "pass"),
    }
}

fn resume_stage_passed(rows: &[StageReceipt], lane: &Lane, stage: Stage) -> bool {
    rows.iter()
        .rev()
        .find(|row| row.lane == lane.name && row.stage == stage)
        .is_some_and(|row| row.status == StageStatus::Passed && stage_artifact_passed(lane, stage))
}

fn invalidate_stage_rows(rows: &mut Vec<StageReceipt>, lane: &Lane, stage: Stage) {
    rows.retain(|row| {
        if row.lane != lane.name {
            return true;
        }
        match stage {
            Stage::Gears => false,
            Stage::Build => row.stage != Stage::Build,
        }
    });
}

fn usage() -> &'static str {
    "spiral-split-matrix: resumable multi-source split/typecheck gate\n\n\
usage:\n\
  spiral-split-matrix --spiral-split PATH --manifest MATRIX.tsv --receipt RECEIPT.tsv \\\n    --cache-root DIR --assembly-root DIR --dotnet PATH [options]\n\n\
manifest columns:\n\
  name\\tsource\\toutput\\tpolicy\\tmax_lines\\treference\n\n\
options:\n\
  --emit-threads N                 Rayon threads for source splitting (default 16)\n\
  --build-threads N                concurrent gear workers (default 1)\n\
  --gears-timeout-seconds N        parent timeout for generation (default 90)\n\
  --process-timeout-seconds N      per-gear/root timeout passed to splitter (default 30)\n\
  --lane-build-budget-seconds N    one gear-build transaction budget (default 30)\n\
  --build-reserve-seconds N        reserve inside gear-build (default 5)\n\
  --matrix-budget-seconds N        whole matrix budget (default 300)\n\
  --matrix-reserve-seconds N       reserve before starting a new stage (default 20)\n"
}

fn require_value(args: &[String], index: &mut usize, flag: &str) -> Result<String, String> {
    *index += 1;
    args.get(*index)
        .cloned()
        .ok_or_else(|| format!("missing value for {flag}"))
}

fn parse_seconds(args: &[String], index: &mut usize, flag: &str) -> Result<Duration, String> {
    let value = require_value(args, index, flag)?
        .parse::<u64>()
        .map_err(|error| format!("invalid {flag}: {error}"))?;
    if value == 0 {
        return Err(format!("{flag} must be positive"));
    }
    Ok(Duration::from_secs(value))
}

fn parse_threads(args: &[String], index: &mut usize, flag: &str) -> Result<usize, String> {
    let value = require_value(args, index, flag)?
        .parse::<usize>()
        .map_err(|error| format!("invalid {flag}: {error}"))?;
    Ok(value.clamp(1, 256))
}

fn parse_options(args: &[String]) -> Result<Options, String> {
    let mut spiral_split = None;
    let mut manifest = None;
    let mut receipt = None;
    let mut cache_root = None;
    let mut assembly_root = None;
    let mut dotnet = None;
    let mut emit_threads = 16usize;
    let mut build_threads = 1usize;
    let mut gears_timeout = Duration::from_secs(90);
    let mut process_timeout = Duration::from_secs(30);
    let mut lane_build_budget = Duration::from_secs(30);
    let mut build_reserve = Duration::from_secs(5);
    let mut matrix_budget = Duration::from_secs(300);
    let mut matrix_reserve = Duration::from_secs(20);
    let mut index = 0usize;
    while index < args.len() {
        match args[index].as_str() {
            "--spiral-split" => {
                spiral_split = Some(PathBuf::from(require_value(
                    args,
                    &mut index,
                    "--spiral-split",
                )?))
            }
            "--manifest" => {
                manifest = Some(PathBuf::from(require_value(
                    args,
                    &mut index,
                    "--manifest",
                )?))
            }
            "--receipt" => {
                receipt = Some(PathBuf::from(require_value(args, &mut index, "--receipt")?))
            }
            "--cache-root" => {
                cache_root = Some(PathBuf::from(require_value(
                    args,
                    &mut index,
                    "--cache-root",
                )?))
            }
            "--assembly-root" => {
                assembly_root = Some(PathBuf::from(require_value(
                    args,
                    &mut index,
                    "--assembly-root",
                )?))
            }
            "--dotnet" => {
                dotnet = Some(PathBuf::from(require_value(args, &mut index, "--dotnet")?))
            }
            "--emit-threads" => emit_threads = parse_threads(args, &mut index, "--emit-threads")?,
            "--build-threads" => {
                build_threads = parse_threads(args, &mut index, "--build-threads")?
            }
            "--gears-timeout-seconds" => {
                gears_timeout = parse_seconds(args, &mut index, "--gears-timeout-seconds")?
            }
            "--process-timeout-seconds" => {
                process_timeout = parse_seconds(args, &mut index, "--process-timeout-seconds")?
            }
            "--lane-build-budget-seconds" => {
                lane_build_budget = parse_seconds(args, &mut index, "--lane-build-budget-seconds")?
            }
            "--build-reserve-seconds" => {
                build_reserve = parse_seconds(args, &mut index, "--build-reserve-seconds")?
            }
            "--matrix-budget-seconds" => {
                matrix_budget = parse_seconds(args, &mut index, "--matrix-budget-seconds")?
            }
            "--matrix-reserve-seconds" => {
                matrix_reserve = parse_seconds(args, &mut index, "--matrix-reserve-seconds")?
            }
            "--help" | "-h" => return Err(usage().to_owned()),
            other => return Err(format!("unknown argument: {other}\n\n{}", usage())),
        }
        index += 1;
    }
    Ok(Options {
        spiral_split: spiral_split.ok_or_else(|| "missing --spiral-split".to_owned())?,
        manifest: manifest.ok_or_else(|| "missing --manifest".to_owned())?,
        receipt: receipt.ok_or_else(|| "missing --receipt".to_owned())?,
        cache_root: cache_root.ok_or_else(|| "missing --cache-root".to_owned())?,
        assembly_root: assembly_root.ok_or_else(|| "missing --assembly-root".to_owned())?,
        dotnet: dotnet.ok_or_else(|| "missing --dotnet".to_owned())?,
        emit_threads,
        build_threads,
        gears_timeout,
        process_timeout,
        lane_build_budget,
        build_reserve,
        matrix_budget,
        matrix_reserve,
    })
}

fn valid_lane_name(value: &str) -> bool {
    !value.is_empty()
        && value
            .chars()
            .all(|character| character.is_ascii_alphanumeric() || matches!(character, '-' | '_'))
}

fn parse_manifest_text(text: &str) -> Result<Vec<Lane>, String> {
    let mut lanes = Vec::new();
    for (line_index, line) in text.lines().enumerate() {
        if line.trim().is_empty() || line.starts_with('#') {
            continue;
        }
        let fields = line.split('\t').collect::<Vec<_>>();
        if line_index == 0 && fields.first() == Some(&"name") {
            continue;
        }
        if fields.len() != 6 {
            return Err(format!(
                "matrix line {} expects 6 TSV columns",
                line_index + 1
            ));
        }
        let max_lines = fields[4]
            .parse::<usize>()
            .map_err(|error| format!("matrix line {} max_lines: {error}", line_index + 1))?;
        if !valid_lane_name(fields[0]) {
            return Err(format!(
                "matrix line {} invalid lane name: {}",
                line_index + 1,
                fields[0]
            ));
        }
        if !(50..=1000).contains(&max_lines) {
            return Err(format!(
                "matrix line {} max_lines must be 50..1000",
                line_index + 1
            ));
        }
        if !matches!(fields[5], "closure" | "direct") {
            return Err(format!(
                "matrix line {} invalid reference mode: {}",
                line_index + 1,
                fields[5]
            ));
        }
        lanes.push(Lane {
            name: fields[0].to_owned(),
            source: PathBuf::from(fields[1]),
            output: PathBuf::from(fields[2]),
            policy: fields[3].to_owned(),
            max_lines,
            reference: fields[5].to_owned(),
        });
    }
    if lanes.is_empty() {
        Err("matrix manifest contains no lanes".to_owned())
    } else {
        Ok(lanes)
    }
}

fn load_manifest(path: &Path) -> Result<Vec<Lane>, String> {
    let text = fs::read_to_string(path)
        .map_err(|error| format!("read matrix manifest {}: {error}", path.display()))?;
    parse_manifest_text(&text)
}

fn write_atomic(path: &Path, text: &str) -> Result<(), String> {
    if let Some(parent) = path.parent() {
        fs::create_dir_all(parent)
            .map_err(|error| format!("create receipt parent {}: {error}", parent.display()))?;
    }
    let temporary = path.with_extension("tmp");
    fs::write(&temporary, text)
        .map_err(|error| format!("write receipt temporary {}: {error}", temporary.display()))?;
    fs::rename(&temporary, path)
        .map_err(|error| format!("commit receipt {}: {error}", path.display()))
}

fn receipt_status(path: &Path) -> Result<String, String> {
    let text = fs::read_to_string(path)
        .map_err(|error| format!("read gear receipt {}: {error}", path.display()))?;
    text.lines()
        .find_map(|line| {
            let mut fields = line.split_whitespace();
            match (fields.next(), fields.next()) {
                (Some("status"), Some(status)) => Some(status.to_owned()),
                _ => None,
            }
        })
        .ok_or_else(|| format!("gear receipt {} has no status", path.display()))
}

fn capture_note(capture: &ProcessCapture) -> String {
    if capture.success() {
        let stdout = String::from_utf8_lossy(&capture.stdout);
        stdout.lines().last().unwrap_or("completed").to_owned()
    } else {
        let stderr = String::from_utf8_lossy(&capture.stderr);
        stderr.lines().last().unwrap_or("child failed").to_owned()
    }
}

fn stage_receipt(
    lane: &Lane,
    stage: Stage,
    capture: &ProcessCapture,
    status: StageStatus,
    note: String,
) -> StageReceipt {
    StageReceipt {
        lane: lane.name.clone(),
        stage,
        status,
        elapsed: capture.elapsed,
        stdout_bytes: capture.stdout.len(),
        stderr_bytes: capture.stderr.len(),
        note,
    }
}

fn common_gears_args(command: &mut Command, lane: &Lane, options: &Options) {
    command
        .arg("--policy")
        .arg(&lane.policy)
        .arg("--max-lines")
        .arg(lane.max_lines.to_string())
        .arg("--reference")
        .arg(&lane.reference)
        .arg("--threads")
        .arg(options.emit_threads.to_string())
        .arg("--cache-root")
        .arg(options.cache_root.join(&lane.name))
        .arg("--assembly-root")
        .arg(&options.assembly_root);
}

fn gears_command(lane: &Lane, options: &Options) -> Command {
    let mut command = Command::new(&options.spiral_split);
    command.arg("gears").arg(&lane.source).arg(&lane.output);
    common_gears_args(&mut command, lane, options);
    command
}

fn build_command(lane: &Lane, options: &Options) -> Command {
    let mut command = Command::new(&options.spiral_split);
    command
        .arg("gear-build")
        .arg(&lane.output)
        .arg("--threads")
        .arg(options.build_threads.to_string())
        .arg("--assembly-root")
        .arg(&options.assembly_root)
        .arg("--dotnet")
        .arg(&options.dotnet)
        .arg("--process-timeout-seconds")
        .arg(options.process_timeout.as_secs().to_string())
        .arg("--build-budget-seconds")
        .arg(options.lane_build_budget.as_secs().to_string())
        .arg("--build-reserve-seconds")
        .arg(options.build_reserve.as_secs().to_string());
    command
}

fn bounded_gears_stage(
    lane: &Lane,
    options: &Options,
    timeout: Duration,
) -> Result<(StageReceipt, StageStatus), String> {
    let capture = run_bounded_process(
        gears_command(lane, options),
        timeout,
        &format!("matrix-{}-gears", lane.name),
    )?;
    if !capture.success() {
        let note = capture_note(&capture);
        return Ok((
            stage_receipt(lane, Stage::Gears, &capture, StageStatus::Failed, note),
            StageStatus::Failed,
        ));
    }
    let source_receipt = lane.output.join("source.receipt.tsv");
    let (status, note) = if source_receipt.is_file() && lane.output.join("gears.tsv").is_file() {
        (StageStatus::Passed, capture_note(&capture))
    } else {
        (
            StageStatus::Failed,
            "generation exited 0 without source/gears receipts".to_owned(),
        )
    };
    Ok((
        stage_receipt(lane, Stage::Gears, &capture, status, note),
        status,
    ))
}

fn budgeted_build_stage(
    lane: &Lane,
    options: &Options,
) -> Result<(StageReceipt, StageStatus), String> {
    let started = Instant::now();
    let process = build_command(lane, options)
        .status()
        .map_err(|error| format!("run matrix lane {} build: {error}", lane.name))?;
    let elapsed = started.elapsed();
    if !process.success() {
        let status = StageStatus::Failed;
        return Ok((
            StageReceipt {
                lane: lane.name.clone(),
                stage: Stage::Build,
                status,
                elapsed,
                stdout_bytes: 0,
                stderr_bytes: 0,
                note: format!("gear-build process exited with {process}"),
            },
            status,
        ));
    }
    let receipt = lane.output.join("gear-build.receipt.tsv");
    let receipt_status = receipt_status(&receipt)?;
    let status = match receipt_status.as_str() {
        "pass" => StageStatus::Passed,
        "yield" => StageStatus::Yielded,
        "fail" => StageStatus::Failed,
        other => {
            return Err(format!(
                "matrix lane {} has unknown gear-build status: {other}",
                lane.name
            ));
        }
    };
    Ok((
        StageReceipt {
            lane: lane.name.clone(),
            stage: Stage::Build,
            status,
            elapsed,
            stdout_bytes: 0,
            stderr_bytes: 0,
            note: format!("gear-build receipt status={receipt_status}"),
        },
        status,
    ))
}

fn child_stage(
    lane: &Lane,
    stage: Stage,
    options: &Options,
    timeout: Duration,
) -> Result<(StageReceipt, StageStatus), String> {
    match stage {
        Stage::Gears => bounded_gears_stage(lane, options, timeout),
        Stage::Build => budgeted_build_stage(lane, options),
    }
}

fn validate_paths(options: &Options, lanes: &[Lane]) -> Result<(), String> {
    for (label, path) in [
        ("spiral-split", &options.spiral_split),
        ("assembly-root", &options.assembly_root),
        ("dotnet", &options.dotnet),
    ] {
        if !path.exists() {
            return Err(format!("{label} does not exist: {}", path.display()));
        }
    }
    for lane in lanes {
        if !lane.source.is_file() {
            return Err(format!(
                "lane {} source does not exist: {}",
                lane.name,
                lane.source.display()
            ));
        }
    }
    Ok(())
}

fn run_matrix(options: &Options, lanes: &[Lane]) -> Result<MatrixOutcome, String> {
    validate_paths(options, lanes)?;
    fs::create_dir_all(&options.cache_root).map_err(|error| {
        format!(
            "create matrix cache {}: {error}",
            options.cache_root.display()
        )
    })?;
    let identity = matrix_identity(options, lanes)?;
    let started = Instant::now();
    let budget = BuildBudget::limited(options.matrix_budget, options.matrix_reserve).clock();
    let mut rows = load_resume_rows(&options.receipt, &identity);
    let mut completed_lanes = 0usize;
    write_atomic(
        &options.receipt,
        &render_receipt!(
            &identity,
            "running",
            lanes,
            0,
            "-",
            "-",
            started.elapsed(),
            &rows,
        ),
    )?;
    for lane in lanes {
        let gears_resumed = resume_stage_passed(&rows, lane, Stage::Gears);
        if !gears_resumed {
            let stage = Stage::Gears;
            let child_timeout = options.gears_timeout;
            if let BudgetDecision::Yield { .. } = budget.decision(child_timeout) {
                let note = "matrix budget yielded before starting next bounded stage".to_owned();
                write_atomic(
                    &options.receipt,
                    &render_receipt!(
                        &identity,
                        "yield",
                        lanes,
                        completed_lanes,
                        &lane.name,
                        stage.name(),
                        started.elapsed(),
                        &rows,
                    ),
                )?;
                return Ok(MatrixOutcome::Yielded {
                    lane: lane.name.clone(),
                    stage,
                    note,
                });
            }
            invalidate_stage_rows(&mut rows, lane, stage);
            let (row, status) = child_stage(lane, stage, options, child_timeout)?;
            rows.push(row);
            let matrix_status = match status {
                StageStatus::Passed => "running",
                StageStatus::Yielded => "yield",
                StageStatus::Failed => "fail",
            };
            write_atomic(
                &options.receipt,
                &render_receipt!(
                    &identity,
                    matrix_status,
                    lanes,
                    completed_lanes,
                    &lane.name,
                    stage.name(),
                    started.elapsed(),
                    &rows,
                ),
            )?;
            match status {
                StageStatus::Passed => {}
                StageStatus::Yielded => {
                    return Ok(MatrixOutcome::Yielded {
                        lane: lane.name.clone(),
                        stage,
                        note: "lane yielded resumably".to_owned(),
                    });
                }
                StageStatus::Failed => {
                    return Err(format!(
                        "matrix lane {} stage {} failed",
                        lane.name,
                        stage.name()
                    ));
                }
            }
        }

        let build_resumed = gears_resumed && resume_stage_passed(&rows, lane, Stage::Build);
        if !build_resumed {
            let stage = Stage::Build;
            let child_timeout = options.lane_build_budget + Duration::from_secs(15);
            if let BudgetDecision::Yield { .. } = budget.decision(child_timeout) {
                let note = "matrix budget yielded before starting next bounded stage".to_owned();
                write_atomic(
                    &options.receipt,
                    &render_receipt!(
                        &identity,
                        "yield",
                        lanes,
                        completed_lanes,
                        &lane.name,
                        stage.name(),
                        started.elapsed(),
                        &rows,
                    ),
                )?;
                return Ok(MatrixOutcome::Yielded {
                    lane: lane.name.clone(),
                    stage,
                    note,
                });
            }
            invalidate_stage_rows(&mut rows, lane, stage);
            let (row, status) = child_stage(lane, stage, options, child_timeout)?;
            rows.push(row);
            let matrix_status = match status {
                StageStatus::Passed => "running",
                StageStatus::Yielded => "yield",
                StageStatus::Failed => "fail",
            };
            write_atomic(
                &options.receipt,
                &render_receipt!(
                    &identity,
                    matrix_status,
                    lanes,
                    completed_lanes,
                    &lane.name,
                    stage.name(),
                    started.elapsed(),
                    &rows,
                ),
            )?;
            match status {
                StageStatus::Passed => {}
                StageStatus::Yielded => {
                    return Ok(MatrixOutcome::Yielded {
                        lane: lane.name.clone(),
                        stage,
                        note: "lane yielded resumably".to_owned(),
                    });
                }
                StageStatus::Failed => {
                    return Err(format!(
                        "matrix lane {} stage {} failed",
                        lane.name,
                        stage.name()
                    ));
                }
            }
        }

        completed_lanes += 1;
        write_atomic(
            &options.receipt,
            &render_receipt!(
                &identity,
                "running",
                lanes,
                completed_lanes,
                "-",
                "-",
                started.elapsed(),
                &rows,
            ),
        )?;
    }
    write_atomic(
        &options.receipt,
        &render_receipt!(
            &identity,
            "pass",
            lanes,
            completed_lanes,
            "-",
            "-",
            started.elapsed(),
            &rows,
        ),
    )?;
    Ok(MatrixOutcome::Passed)
}

fn run() -> Result<(), String> {
    let args = env::args().skip(1).collect::<Vec<_>>();
    if matches!(
        args.first().map(String::as_str),
        Some("--help" | "-h" | "help")
    ) {
        print!("{}", usage());
        return Ok(());
    }
    let options = parse_options(&args)?;
    let lanes = load_manifest(&options.manifest)?;
    match run_matrix(&options, &lanes)? {
        MatrixOutcome::Passed => {
            println!(
                "matrix=passed lanes={} receipt={}",
                lanes.len(),
                options.receipt.display()
            );
        }
        MatrixOutcome::Yielded { lane, stage, note } => {
            println!(
                "matrix=yielded lane={} stage={} note={} receipt={}",
                lane,
                stage.name(),
                note,
                options.receipt.display()
            );
        }
    }
    Ok(())
}

fn main() {
    if let Err(error) = run() {
        eprintln!("spiral-split-matrix error: {error}");
        std::process::exit(2);
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn parses_generic_manifest() {
        let lanes = parse_manifest_text(
            "name\tsource\toutput\tpolicy\tmax_lines\treference\nbase\t/a.fs\t/out\tmodule-aware\t1000\tclosure\n",
        )
        .unwrap();
        assert_eq!(lanes.len(), 1);
        assert_eq!(lanes[0].name, "base");
        assert_eq!(lanes[0].max_lines, 1000);
    }

    #[test]
    fn rejects_unsafe_lane_names_and_bad_reference_modes() {
        assert!(parse_manifest_text("bad/name\t/a\t/o\tauto\t1000\tclosure\n").is_err());
        assert!(parse_manifest_text("base\t/a\t/o\tauto\t1000\tother\n").is_err());
    }

    #[test]
    fn parses_gear_receipt_status() {
        let root = env::temp_dir().join(format!("spiral-matrix-test-{}", std::process::id()));
        fs::create_dir_all(&root).unwrap();
        let path = root.join("receipt.tsv");
        fs::write(&path, "key\tvalue\nstatus\tyield\ngears\t3\n").unwrap();
        assert_eq!(receipt_status(&path).unwrap(), "yield");
        let _ = fs::remove_dir_all(root);
    }

    #[test]
    fn resume_requires_matching_identity_and_terminal_artifacts() {
        let root =
            env::temp_dir().join(format!("spiral-matrix-resume-test-{}", std::process::id()));
        let output = root.join("out");
        fs::create_dir_all(&output).unwrap();
        fs::write(output.join("source.receipt.tsv"), "key\tvalue\n").unwrap();
        fs::write(output.join("gears.tsv"), "gear\n").unwrap();
        fs::write(
            output.join("gear-build.receipt.tsv"),
            "key\tvalue\nstatus\tpass\n",
        )
        .unwrap();
        let lane = Lane {
            name: "base".to_owned(),
            source: root.join("source.fs"),
            output: output.clone(),
            policy: "module-aware".to_owned(),
            max_lines: 1000,
            reference: "closure".to_owned(),
        };
        let rows = vec![
            StageReceipt {
                lane: lane.name.clone(),
                stage: Stage::Gears,
                status: StageStatus::Passed,
                elapsed: Duration::from_millis(1),
                stdout_bytes: 0,
                stderr_bytes: 0,
                note: "ok".to_owned(),
            },
            StageReceipt {
                lane: lane.name.clone(),
                stage: Stage::Build,
                status: StageStatus::Passed,
                elapsed: Duration::from_millis(1),
                stdout_bytes: 0,
                stderr_bytes: 0,
                note: "ok".to_owned(),
            },
        ];
        let receipt = root.join("matrix.tsv");
        fs::write(
            &receipt,
            render_receipt!(
                "abc",
                "yield",
                std::slice::from_ref(&lane),
                1,
                "-",
                "-",
                Duration::ZERO,
                &rows,
            ),
        )
        .unwrap();
        let loaded = load_resume_rows(&receipt, "abc");
        assert_eq!(loaded.len(), 2);
        assert!(resume_stage_passed(&loaded, &lane, Stage::Gears));
        assert!(resume_stage_passed(&loaded, &lane, Stage::Build));
        assert!(load_resume_rows(&receipt, "other").is_empty());
        fs::remove_file(output.join("gears.tsv")).unwrap();
        assert!(!resume_stage_passed(&loaded, &lane, Stage::Gears));
        let _ = fs::remove_dir_all(root);
    }
}
