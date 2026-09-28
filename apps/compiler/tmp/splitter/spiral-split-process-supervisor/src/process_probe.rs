use spiral_split_process_supervisor::run_bounded_process;
use std::env;
use std::path::Path;
use std::process::Command;
use std::time::Duration;

fn main() {
    let args = env::args().skip(1).collect::<Vec<_>>();
    if args.len() < 4 {
        eprintln!("usage: spiral-split-process-probe <cwd> <timeout-seconds> <program> <arg>...");
        std::process::exit(2);
    }
    let cwd = &args[0];
    let timeout = args[1].parse::<u64>().expect("timeout seconds");
    let program = &args[2];
    let cwd = cwd.clone();
    let program = program.clone();
    let command_args = args[3..].to_vec();
    let capture = std::thread::spawn(move || {
        let mut command = Command::new(program);
        command.current_dir(Path::new(&cwd)).args(command_args);
        run_bounded_process(command, Duration::from_secs(timeout), "process-probe")
    })
    .join()
    .expect("probe worker panicked")
    .unwrap_or_else(|error| {
        eprintln!("probe-error\t{error}");
        std::process::exit(1);
    });
    println!("success\t{}", capture.success());
    println!("timed_out\t{}", capture.timed_out());
    println!("elapsed_ms\t{:.3}", capture.elapsed.as_secs_f64() * 1000.0);
    println!("status\t{:?}", capture.status());
    if !capture.stdout.is_empty() {
        println!("stdout\n{}", String::from_utf8_lossy(&capture.stdout));
    }
    if !capture.stderr.is_empty() {
        eprintln!("stderr\n{}", String::from_utf8_lossy(&capture.stderr));
    }
    if !capture.success() {
        std::process::exit(1);
    }
}
