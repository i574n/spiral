#![cfg(windows)]
use eoie_process_streaming::*;
use std::process::Command;
#[test]
fn captures_output_and_nonzero_exit() {
    let result = run_bounded_capture_with_input(Command::new("cmd.exe").args(["/d", "/c", "echo hello & echo error 1>&2 & exit /b 7"]), 10000, None).unwrap();
    assert_eq!(result.status.code(), Some(7));
    assert!(String::from_utf8_lossy(&result.stdout).contains("hello"));
    assert!(String::from_utf8_lossy(&result.stderr).contains("error"));
}
#[test]
fn timeout_terminates_descendants() {
    let marker = std::env::temp_dir().join(format!("eoie-tree-{}.txt", std::process::id()));
    let script = format!("Start-Process -WindowStyle Hidden powershell.exe -ArgumentList '-NoProfile -Command Start-Sleep -Seconds 3; Set-Content -LiteralPath \"{}\" escaped'; Start-Sleep -Seconds 15", marker.display());
    let result = run_bounded_capture_with_input(Command::new("powershell.exe").args(["-NoProfile", "-Command", &script]), 1500, None).unwrap();
    assert_eq!(result.termination, ProcessTermination::TimedOut);
    std::thread::sleep(std::time::Duration::from_secs(4));
    assert!(!marker.exists(), "grandchild escaped its job");
}
#[test]
fn descendant_pipes_do_not_hang_after_parent_exit() {
    let start = std::time::Instant::now();
    let result = run_bounded_capture_with_input(Command::new("cmd.exe").args(["/d", "/c", "start /b ping -n 30 127.0.0.1 >nul"]), 10000, None).unwrap();
    assert!(result.status.success());
    assert!(start.elapsed() < std::time::Duration::from_secs(10));
}
