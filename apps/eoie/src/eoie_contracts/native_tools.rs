// Tiny native test programs replace assumptions about /bin and /usr/bin.
fn native_test_tool(kind: &str) -> &'static str {
    static TOOLS: std::sync::OnceLock<std::collections::HashMap<String, String>> = std::sync::OnceLock::new();
    TOOLS.get_or_init(|| {
        let root = std::env::temp_dir().join(format!("eoie-contract-tools-{}", std::process::id()));
        std::fs::create_dir_all(&root).unwrap();
        let source = root.join("main.rs");
        std::fs::write(&source, r#"
fn main() {
    let program = std::env::current_exe().unwrap();
    match program.file_stem().unwrap().to_str().unwrap() {
        "true" => (),
        "false" => std::process::exit(1),
        "sleep" => std::thread::sleep(std::time::Duration::from_secs(1)),
        "printenv" => println!("{}", std::env::var(std::env::args().nth(1).unwrap()).unwrap()),
        _ => std::process::exit(2),
    }
}
"#).unwrap();
        let executable = root.join(if cfg!(windows) { "tool.exe" } else { "tool" });
        let output = std::process::Command::new(std::env::var_os("RUSTC").unwrap_or_else(|| "rustc".into()))
            .arg(&source).arg("-o").arg(&executable).output().expect("build native test tools");
        assert!(output.status.success(), "{}", String::from_utf8_lossy(&output.stderr));
        ["true", "false", "sleep", "printenv"].into_iter().map(|name| {
            let path = root.join(format!("{name}{}", std::env::consts::EXE_SUFFIX));
            std::fs::copy(&executable, &path).unwrap();
            (name.to_owned(), path.to_str().unwrap().to_owned())
        }).collect()
    }).get(kind).expect("known native test tool").as_str()
}
