use std::ffi::OsString;
use std::fs::{self, File};
use std::path::{Path, PathBuf};
use std::process::{Command, ExitStatus, Stdio};
use std::sync::atomic::{AtomicU64, Ordering};
use std::sync::{Arc, Mutex, OnceLock};
use std::thread;
use std::time::{Duration, Instant};

#[cfg(unix)]
unsafe extern "C" {
    fn kill(pid: i32, signal: i32) -> i32;
}

#[cfg(unix)]
const SIGKILL: i32 = 9;
#[cfg(unix)]
const SIGTERM: i32 = 15;

static CAPTURE_SEQUENCE: AtomicU64 = AtomicU64::new(0);
static SPAWN_LOCK: Mutex<()> = Mutex::new(());

#[derive(Debug)]
pub enum ProcessTermination {
    Completed(ExitStatus),
    TimedOut {
        status: Option<ExitStatus>,
        term_sent: bool,
        kill_sent: bool,
        reaped: bool,
    },
}

#[derive(Debug)]
pub struct ProcessCapture {
    pub termination: ProcessTermination,
    pub stdout: Vec<u8>,
    pub stderr: Vec<u8>,
    pub elapsed: Duration,
}

impl ProcessCapture {
    pub fn success(&self) -> bool {
        matches!(
            self.termination,
            ProcessTermination::Completed(status) if status.success()
        )
    }

    pub fn timed_out(&self) -> bool {
        matches!(self.termination, ProcessTermination::TimedOut { .. })
    }

    pub fn status(&self) -> Option<ExitStatus> {
        match self.termination {
            ProcessTermination::Completed(status) => Some(status),
            ProcessTermination::TimedOut { status, .. } => status,
        }
    }
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum ProcessLifecyclePhase {
    CaptureReady,
    SpawnLockWait,
    SpawnEnter,
    SpawnReturn,
    WaitEnter,
    WaitHeartbeat,
    TimeoutTerm,
    TimeoutKill,
    ReapExpired,
    ChildWaitReturn,
    WaitReturn,
    CollectEnter,
    CollectReturn,
}

impl ProcessLifecyclePhase {
    pub const fn trace_name(self) -> &'static str {
        match self {
            Self::CaptureReady => "process_capture_ready",
            Self::SpawnLockWait => "process_spawn_lock_wait",
            Self::SpawnEnter => "process_spawn_enter",
            Self::SpawnReturn => "process_spawn_return",
            Self::WaitEnter => "process_wait_enter",
            Self::WaitHeartbeat => "process_wait_heartbeat",
            Self::TimeoutTerm => "process_timeout_term",
            Self::TimeoutKill => "process_timeout_kill",
            Self::ReapExpired => "process_reap_expired",
            Self::ChildWaitReturn => "process_child_wait_return",
            Self::WaitReturn => "process_wait_return",
            Self::CollectEnter => "process_collect_enter",
            Self::CollectReturn => "process_collect_return",
        }
    }
}

struct CaptureFiles {
    stdout: PathBuf,
    stderr: PathBuf,
}

impl CaptureFiles {
    fn create(label: &str) -> Result<(Self, File, File), String> {
        let sequence = CAPTURE_SEQUENCE.fetch_add(1, Ordering::Relaxed);
        let token = label
            .chars()
            .map(|character| {
                if character.is_ascii_alphanumeric() {
                    character
                } else {
                    '_'
                }
            })
            .collect::<String>();
        let stem = format!(
            "spiral-split-process-{}-{sequence}-{token}",
            std::process::id()
        );
        let root = std::env::temp_dir();
        let stdout = root.join(format!("{stem}.stdout"));
        let stderr = root.join(format!("{stem}.stderr"));
        let stdout_file = File::create(&stdout)
            .map_err(|error| format!("create capture {}: {error}", stdout.display()))?;
        let stderr_file = File::create(&stderr)
            .map_err(|error| format!("create capture {}: {error}", stderr.display()))?;
        Ok((Self { stdout, stderr }, stdout_file, stderr_file))
    }

    fn collect(self, label: &str) -> Result<(Vec<u8>, Vec<u8>), String> {
        let stdout = fs::read(&self.stdout)
            .map_err(|error| format!("read stdout capture for {label}: {error}"));
        let stderr = fs::read(&self.stderr)
            .map_err(|error| format!("read stderr capture for {label}: {error}"));
        let _ = fs::remove_file(&self.stdout);
        let _ = fs::remove_file(&self.stderr);
        Ok((stdout?, stderr?))
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct CommandSnapshot {
    program: OsString,
    args: Vec<OsString>,
    current_dir: Option<PathBuf>,
    env: Vec<(OsString, Option<OsString>)>,
}

impl CommandSnapshot {
    fn capture(command: &Command) -> Self {
        Self {
            program: command.get_program().to_owned(),
            args: command.get_args().map(ToOwned::to_owned).collect(),
            current_dir: command.get_current_dir().map(Path::to_path_buf),
            env: command
                .get_envs()
                .map(|(key, value)| (key.to_owned(), value.map(ToOwned::to_owned)))
                .collect(),
        }
    }

    fn bounded(&self, _timeout: Duration, _grace: Duration) -> Command {
        let mut command = Command::new("/usr/bin/setsid");
        command.arg(&self.program).args(&self.args);
        if let Some(current_dir) = &self.current_dir {
            command.current_dir(current_dir);
        }
        for (key, value) in &self.env {
            match value {
                Some(value) => {
                    command.env(key, value);
                }
                None => {
                    command.env_remove(key);
                }
            }
        }
        command
    }
}

#[cfg(unix)]
fn signal_pid(pid: u32, signal: i32) -> bool {
    let Ok(pid) = i32::try_from(pid) else {
        return false;
    };
    let result = unsafe { kill(pid, signal) };
    result == 0 || std::io::Error::last_os_error().raw_os_error() == Some(3)
}

#[cfg(unix)]
fn signal_process_group(pid: u32, signal: i32) -> bool {
    let Ok(pid) = i32::try_from(pid) else {
        return false;
    };
    let result = unsafe { kill(-pid, signal) };
    result == 0 || std::io::Error::last_os_error().raw_os_error() == Some(3)
}

#[cfg(unix)]
fn kill_process_group(pid: u32) -> bool {
    signal_process_group(pid, SIGKILL)
}

#[cfg(unix)]
fn terminate_process_group(pid: u32) -> bool {
    signal_process_group(pid, SIGTERM) || signal_pid(pid, SIGTERM)
}

#[cfg(unix)]
fn force_kill_process_group(pid: u32) -> bool {
    kill_process_group(pid) || signal_pid(pid, SIGKILL)
}

#[cfg(not(unix))]
fn kill_process_group(_pid: u32) -> bool {
    false
}

#[cfg(not(unix))]
fn terminate_process_group(_pid: u32) -> bool {
    false
}

#[cfg(not(unix))]
fn force_kill_process_group(_pid: u32) -> bool {
    false
}

enum ReaperWaitState {
    Running {
        deadline: Instant,
    },
    Terminating {
        deadline: Instant,
        term_sent: bool,
    },
    Killing {
        deadline: Instant,
        term_sent: bool,
        kill_sent: bool,
    },
}

impl ReaperWaitState {
    fn deadline(&self) -> Instant {
        match self {
            Self::Running { deadline }
            | Self::Terminating { deadline, .. }
            | Self::Killing { deadline, .. } => *deadline,
        }
    }

    fn completed(self, status: ExitStatus) -> ProcessTermination {
        match self {
            Self::Running { .. } => ProcessTermination::Completed(status),
            Self::Terminating { term_sent, .. } => ProcessTermination::TimedOut {
                status: Some(status),
                term_sent,
                kill_sent: false,
                reaped: true,
            },
            Self::Killing {
                term_sent,
                kill_sent,
                ..
            } => ProcessTermination::TimedOut {
                status: Some(status),
                term_sent,
                kill_sent,
                reaped: true,
            },
        }
    }
}

fn poll_reaper_with_deadlines<F>(
    reaper_result: &OnceLock<Result<ExitStatus, String>>,
    process_group: u32,
    timeout: Duration,
    grace: Duration,
    label: &str,
    observer: &mut F,
) -> Result<ProcessTermination, String>
where
    F: FnMut(ProcessLifecyclePhase) -> Result<(), String>,
{
    let mut state = ReaperWaitState::Running {
        deadline: Instant::now() + timeout,
    };
    loop {
        if let Some(wait_result) = reaper_result.get() {
            observer(ProcessLifecyclePhase::ChildWaitReturn)?;
            let status = wait_result
                .clone()
                .map_err(|error| format!("wait bounded {label}: {error}"))?;
            return Ok(state.completed(status));
        }

        let now = Instant::now();
        state = match state {
            ReaperWaitState::Running { deadline } if now >= deadline => {
                observer(ProcessLifecyclePhase::TimeoutTerm)?;
                ReaperWaitState::Terminating {
                    deadline: now + grace,
                    term_sent: terminate_process_group(process_group),
                }
            }
            ReaperWaitState::Terminating {
                deadline,
                term_sent,
            } if now >= deadline => {
                observer(ProcessLifecyclePhase::TimeoutKill)?;
                ReaperWaitState::Killing {
                    deadline: now + Duration::from_millis(250),
                    term_sent,
                    kill_sent: force_kill_process_group(process_group),
                }
            }
            ReaperWaitState::Killing {
                deadline,
                term_sent,
                kill_sent,
            } if now >= deadline => {
                observer(ProcessLifecyclePhase::ReapExpired)?;
                return Ok(ProcessTermination::TimedOut {
                    status: None,
                    term_sent,
                    kill_sent,
                    reaped: false,
                });
            }
            state => state,
        };

        let remaining = state
            .deadline()
            .saturating_duration_since(Instant::now())
            .min(Duration::from_millis(10));
        if remaining.is_zero() {
            thread::yield_now();
        } else {
            thread::sleep(remaining);
        }
    }
}

fn run_bounded_process_with_grace<F>(
    command: Command,
    timeout: Duration,
    grace: Duration,
    label: &str,
    mut observer: F,
) -> Result<ProcessCapture, String>
where
    F: FnMut(ProcessLifecyclePhase) -> Result<(), String>,
{
    if timeout.is_zero() {
        return Err("process timeout must be positive".to_owned());
    }
    if grace.is_zero() {
        return Err("process termination grace must be positive".to_owned());
    }
    let snapshot = CommandSnapshot::capture(&command);
    let (captures, stdout, stderr) = CaptureFiles::create(label)?;
    observer(ProcessLifecyclePhase::CaptureReady)?;
    let mut bounded = snapshot.bounded(timeout, grace);
    bounded
        .stdout(Stdio::from(stdout))
        .stderr(Stdio::from(stderr));
    let started = Instant::now();
    observer(ProcessLifecyclePhase::SpawnLockWait)?;
    let child = {
        let _spawn_guard = SPAWN_LOCK
            .lock()
            .map_err(|_| "process spawn lock is poisoned".to_owned())?;
        observer(ProcessLifecyclePhase::SpawnEnter)?;
        let child = bounded
            .spawn()
            .map_err(|error| format!("spawn bounded {label}: {error}"))?;
        observer(ProcessLifecyclePhase::SpawnReturn)?;
        child
    };
    let process_group = child.id();
    let reaper_result = Arc::new(OnceLock::new());
    let reaper_worker = Arc::clone(&reaper_result);
    thread::spawn(move || {
        let mut child = child;
        let outcome = child.wait().map_err(|error| error.to_string());
        let _ = reaper_worker.set(outcome);
    });
    observer(ProcessLifecyclePhase::WaitEnter)?;
    let termination = poll_reaper_with_deadlines(
        reaper_result.as_ref(),
        process_group,
        timeout,
        grace,
        label,
        &mut observer,
    )?;
    observer(ProcessLifecyclePhase::WaitReturn)?;
    let elapsed = started.elapsed();
    let timed_out = matches!(termination, ProcessTermination::TimedOut { .. });
    observer(ProcessLifecyclePhase::CollectEnter)?;
    let (stdout, mut stderr) = captures.collect(label)?;
    observer(ProcessLifecyclePhase::CollectReturn)?;
    if timed_out {
        stderr.extend_from_slice(
            format!(
                "\nspiral-split timeout: {label} exceeded {:.3}s; bounded reaper policy applied and process-group cleanup attempted\n",
                timeout.as_secs_f64()
            )
            .as_bytes(),
        );
    }
    Ok(ProcessCapture {
        termination,
        stdout,
        stderr,
        elapsed,
    })
}

pub fn run_bounded_process_observed<F>(
    command: Command,
    timeout: Duration,
    label: &str,
    observer: F,
) -> Result<ProcessCapture, String>
where
    F: FnMut(ProcessLifecyclePhase) -> Result<(), String>,
{
    run_bounded_process_with_grace(command, timeout, Duration::from_secs(5), label, observer)
}

pub fn run_bounded_process(
    command: Command,
    timeout: Duration,
    label: &str,
) -> Result<ProcessCapture, String> {
    run_bounded_process_observed(command, timeout, label, |_| Ok(()))
}

#[cfg(test)]
mod tests {
    use super::*;
    use std::ffi::OsStr;
    use std::thread;

    #[test]
    fn preserves_success_and_output() {
        let mut command = Command::new("/bin/sh");
        command.arg("-c").arg("printf ok; printf warning >&2");
        let capture = run_bounded_process(command, Duration::from_secs(1), "success").unwrap();
        assert!(capture.success());
        assert!(!capture.timed_out());
        assert_eq!(capture.stdout, b"ok");
        assert_eq!(capture.stderr, b"warning");
    }

    #[test]
    fn preserves_command_context() {
        let mut command = Command::new("/bin/sh");
        command
            .current_dir("/tmp")
            .env("SPIRAL_SPLIT_CAPTURE_TEST", "context-ok")
            .arg("-c")
            .arg("printf '%s:%s' \"$PWD\" \"$SPIRAL_SPLIT_CAPTURE_TEST\"");
        let capture = run_bounded_process(command, Duration::from_secs(1), "context").unwrap();
        assert!(capture.success());
        assert_eq!(capture.stdout, b"/tmp:context-ok");
    }

    #[test]
    fn bounded_wrapper_keeps_one_session_group() {
        let snapshot = CommandSnapshot::capture(&Command::new("/bin/true"));
        let bounded = snapshot.bounded(Duration::from_secs(1), Duration::from_secs(1));
        assert_eq!(bounded.get_program(), OsStr::new("/usr/bin/setsid"));
        let args = bounded.get_args().collect::<Vec<_>>();
        assert_eq!(args[0], OsStr::new("/bin/true"));
        assert!(!args.contains(&OsStr::new("/usr/bin/timeout")));
        assert!(!args.contains(&OsStr::new("--foreground")));
    }

    #[test]
    fn kills_descendant_tree_without_waiting_for_pipe_close() {
        let mut command = Command::new("/bin/sh");
        command.arg("-c").arg("sleep 10 & wait");
        let started = Instant::now();
        let capture = run_bounded_process_with_grace(
            command,
            Duration::from_millis(40),
            Duration::from_millis(40),
            "descendant",
            |_| Ok(()),
        )
        .unwrap();
        assert!(!capture.success());
        assert!(capture.timed_out());
        assert!(started.elapsed() < Duration::from_secs(1));
        assert!(String::from_utf8_lossy(&capture.stderr).contains("process-group cleanup"));
    }

    #[test]
    fn post_term_kill_is_bounded() {
        let mut command = Command::new("/bin/sh");
        command
            .arg("-c")
            .arg("trap '' TERM; while :; do sleep 1; done");
        let started = Instant::now();
        let capture = run_bounded_process_with_grace(
            command,
            Duration::from_millis(40),
            Duration::from_millis(40),
            "post-kill",
            |_| Ok(()),
        )
        .unwrap();
        assert!(capture.timed_out());
        assert!(started.elapsed() < Duration::from_secs(1));
        assert!(matches!(
            capture.termination,
            ProcessTermination::TimedOut { reaped: true, .. }
        ));
    }

    #[test]
    fn concurrent_timeout_paths_are_bounded() {
        let started = Instant::now();
        let workers = (0..8)
            .map(|index| {
                thread::spawn(move || {
                    let mut command = Command::new("/bin/sh");
                    command
                        .arg("-c")
                        .arg("trap '' TERM; while :; do sleep 1; done");
                    run_bounded_process_with_grace(
                        command,
                        Duration::from_millis(40),
                        Duration::from_millis(40),
                        &format!("concurrent-timeout-{index}"),
                        |_| Ok(()),
                    )
                    .unwrap()
                })
            })
            .collect::<Vec<_>>();
        for worker in workers {
            let capture = worker.join().unwrap();
            assert!(capture.timed_out());
        }
        assert!(started.elapsed() < Duration::from_secs(2));
    }

    #[test]
    fn observed_lifecycle_is_ordered() {
        let mut command = Command::new("/bin/sh");
        command.arg("-c").arg("printf ok");
        let mut phases = Vec::new();
        let capture =
            run_bounded_process_observed(command, Duration::from_secs(1), "observed", |phase| {
                phases.push(phase);
                Ok(())
            })
            .unwrap();
        assert!(capture.success());
        assert_eq!(
            phases,
            vec![
                ProcessLifecyclePhase::CaptureReady,
                ProcessLifecyclePhase::SpawnLockWait,
                ProcessLifecyclePhase::SpawnEnter,
                ProcessLifecyclePhase::SpawnReturn,
                ProcessLifecyclePhase::WaitEnter,
                ProcessLifecyclePhase::ChildWaitReturn,
                ProcessLifecyclePhase::WaitReturn,
                ProcessLifecyclePhase::CollectEnter,
                ProcessLifecyclePhase::CollectReturn,
            ]
        );
    }

    #[test]
    fn concurrent_captures_complete_without_polling_children() {
        let started = Instant::now();
        let workers = (0..16)
            .map(|index| {
                thread::spawn(move || {
                    let mut command = Command::new("/bin/sh");
                    command.arg("-c").arg("sleep 0.02; printf ok");
                    run_bounded_process(command, Duration::from_secs(1), &format!("worker-{index}"))
                        .unwrap()
                })
            })
            .collect::<Vec<_>>();
        for worker in workers {
            let capture = worker.join().unwrap();
            assert!(capture.success());
            assert_eq!(capture.stdout, b"ok");
        }
        assert!(started.elapsed() < Duration::from_secs(2));
    }
}
