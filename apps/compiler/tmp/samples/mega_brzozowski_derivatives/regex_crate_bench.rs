// The workloads of runtime_workload.spi through Rust's regex crate (bench.ps1 -RegexCrate builds it --offline): the same LCG and
// bit order (the first symbol drawn is the last symbol of the input), anchored patterns. Prints the three accept counts.
// usage: regexbench <count> <length> <max_zero_run>
use regex::bytes::Regex;
use std::time::Instant;

fn lcg_next(seed: u64) -> u64 { (seed * 1103515245 + 12345) & 2147483647 }

fn random_matches(re: &Regex, count: i32, length: usize) -> i32 {
    let mut seed = 1u64;
    let mut accepted = 0;
    let mut buf = vec![0u8; length];
    for _ in 0..count {
        for i in (0..length).rev() {
            seed = lcg_next(seed);
            buf[i] = if (seed >> 16) & 1 == 0 { b'0' } else { b'1' };
        }
        if re.is_match(&buf) { accepted += 1; }
    }
    accepted
}

fn zero_runs(re: &Regex, max: usize) -> i32 {
    let mut accepted = 0;
    for n in 1..=max {
        let mut s = vec![b'0'; n];
        if re.is_match(&s) { accepted += 1; }
        s.push(b'1');
        if re.is_match(&s) { accepted += 1; }
    }
    accepted
}

fn main() {
    let args: Vec<String> = std::env::args().collect();
    let count: i32 = args[1].parse().unwrap();
    let length: usize = args[2].parse().unwrap();
    let max: usize = args[3].parse().unwrap();
    let ends_zero = Regex::new(r"^(?:0|1)*0$").unwrap();
    let fourth_one = Regex::new(r"^(?:0|1)*1(?:0|1)(?:0|1)(?:0|1)$").unwrap();
    let zero_run = Regex::new(r"^(?:0|00)*1$").unwrap();
    let t = Instant::now();
    let a = random_matches(&ends_zero, count, length);
    let b = random_matches(&fourth_one, count, length);
    let c = zero_runs(&zero_run, max);
    let ms = t.elapsed().as_secs_f64() * 1000.0;
    println!("{a} {b} {c} {ms:.1}ms");
}