#![cfg(windows)]
use eoie_process_observation::run_bounded_stdout_receipted;
use std::{
    io::Read,
    process::Command,
    time::{Duration, Instant},
};
#[test]
fn stdout_consumer_timeout_closes_descendant_pipes() {
    let started = Instant::now();
    let (bytes, observation) = run_bounded_stdout_receipted(Command::new("cmd.exe").args(["/d", "/c", "echo data & ping -n 30 127.0.0.1 >nul"]), 4000, "windows-test", |reader| {
        let mut bytes = Vec::new();
        reader.read_to_end(&mut bytes).map_err(|e| e.to_string())?;
        Ok(bytes)
    })
    .unwrap();
    assert!(observation.timed_out);
    assert!(String::from_utf8_lossy(&bytes).contains("data"));
    assert!(started.elapsed() < Duration::from_secs(10));
}
