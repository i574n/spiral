//! Stdio language server in front of the single-flight Spiral compiler.
//!
//! Zed speaks LSP. SpiralCompiler does not, so this process answers the editor
//! and shells out to `dotnet SpiralCompiler.dll` for check and build.

use serde_json::{json, Value};
use std::collections::HashMap;
use std::io::{BufRead, BufReader, Read, Write};
use std::path::{Path, PathBuf};
use std::process::Command;
use std::sync::Mutex;
use std::time::Duration;

struct Options {
    dotnet: String,
    compiler: String,
    backend: String,
}

enum Launch {
    Serve(Options),
    Probe(Options, PathBuf),
}

struct Doc {
    path: PathBuf,
    text: String,
}

fn main() {
    let launch = match Launch::from_args() {
        Ok(launch) => launch,
        Err(error) => {
            eprintln!("spiral-zed: {error}");
            std::process::exit(2);
        }
    };
    match launch {
        Launch::Serve(options) => serve(options),
        Launch::Probe(options, path) => std::process::exit(probe(&options, &path)),
    }
}

fn serve(options: Options) {
    eprintln!(
        "spiral-zed: ready\n  dotnet: {}\n  compiler: {}\n  backend: {}",
        options.dotnet, options.compiler, options.backend
    );
    let mut server = Server {
        options,
        docs: HashMap::new(),
        notes: HashMap::new(),
        stdout: Mutex::new(std::io::stdout()),
    };
    server.log(3, "spiral-zed is the language server. Compiler output is written here.");
    let stdin = std::io::stdin();
    let mut reader = BufReader::new(stdin.lock());
    loop {
        let Some(message) = read_message(&mut reader) else {
            break;
        };
        if server.handle(message) {
            break;
        }
    }
}

fn usage() -> &'static str {
    "usage: spiral-zed --dotnet DOTNET --compiler DLL [--backend Rust] [--probe FILE.spi]"
}

impl Launch {
    fn from_args() -> Result<Self, String> {
        let mut args = std::env::args().skip(1);
        let mut dotnet = None;
        let mut compiler = None;
        let mut backend = "Rust".to_string();
        let mut probe = None;
        while let Some(arg) = args.next() {
            match arg.as_str() {
                "--dotnet" => dotnet = args.next(),
                "--compiler" => compiler = args.next(),
                "--backend" => {
                    backend = args.next().unwrap_or_else(|| "Rust".to_string());
                }
                "--probe" => probe = Some(PathBuf::from(args.next().ok_or("--probe needs a .spi path")?)),
                "--help" | "-h" => return Err(usage().to_string()),
                other => return Err(format!("unknown argument {other}\n{}", usage())),
            }
        }
        let options = Options {
            dotnet: dotnet.ok_or_else(|| format!("--dotnet is required\n{}", usage()))?,
            compiler: compiler.ok_or_else(|| format!("--compiler is required\n{}", usage()))?,
            backend,
        };
        Ok(match probe {
            Some(path) => Launch::Probe(options, path),
            None => Launch::Serve(options),
        })
    }
}

fn probe(options: &Options, path: &Path) -> i32 {
    eprintln!(
        "spiral-zed: probe\n  dotnet: {}\n  compiler: {}\n  backend: {}\n  file: {}",
        options.dotnet,
        options.compiler,
        options.backend,
        path.display()
    );
    if !path.is_file() {
        eprintln!("spiral-zed: missing {}", path.display());
        return 2;
    }
    let started = std::time::Instant::now();
    let output = run(
        options,
        &[
            &options.compiler,
            "--check",
            &path.to_string_lossy(),
        ],
        Duration::from_secs(90),
    );
    let diagnostics = diagnostics_from(&output.stderr, &output.stdout, output.status);
    eprintln!(
        "check exit {} in {}ms, {} diagnostic(s)",
        output.status,
        started.elapsed().as_millis(),
        diagnostics.len()
    );
    if !output.stdout.trim().is_empty() {
        eprintln!("{}", output.stdout.trim());
    }
    for diagnostic in &diagnostics {
        eprintln!("{}", format_diagnostic(diagnostic));
    }
    if output.status == 0 { 0 } else { 1 }
}

fn format_diagnostic(diagnostic: &Value) -> String {
    let line = diagnostic.pointer("/range/start/line").and_then(Value::as_u64).unwrap_or(0);
    let character = diagnostic.pointer("/range/start/character").and_then(Value::as_u64).unwrap_or(0);
    let message = diagnostic.get("message").and_then(Value::as_str).unwrap_or("");
    format!("diagnostic {line}:{character} {message}")
}

fn toast_diagnostic(diagnostic: &Value) -> String {
    format_diagnostic(diagnostic)
        .lines()
        .next()
        .unwrap_or("")
        .chars()
        .take(180)
        .collect()
}

struct Server {
    options: Options,
    docs: HashMap<String, Doc>,
    notes: HashMap<String, String>,
    stdout: Mutex<std::io::Stdout>,
}

impl Server {
    fn handle(&mut self, message: Value) -> bool {
        let method = message.get("method").and_then(Value::as_str).unwrap_or("");
        let id = message.get("id").cloned();
        match method {
            "initialize" => {
                self.respond(
                    id,
                    json!({
                        "capabilities": {
                            "textDocumentSync": { "openClose": true, "change": 1, "save": true },
                            "hoverProvider": true,
                            "documentLinkProvider": { "resolveProvider": false },
                            "executeCommandProvider": {
                                "commands": ["spiral.buildFile", "spiral.showStatus", "spiral.createFile", "spiral.deleteFile", "spiral.createDirectory"]
                            },
                            "codeActionProvider": { "codeActionKinds": ["source"] },
                            "semanticTokensProvider": {
                                "legend": {
                                    "tokenTypes": ["variable", "symbol", "string", "number", "operator", "unary_operator", "comment", "keyword", "parenthesis", "type_variable", "escaped_char", "unescaped_char", "number_suffix", "escaped_var", "type"],
                                    "tokenModifiers": []
                                },
                                "full": true
                            }
                        },
                        "serverInfo": { "name": "spiral-zed", "version": "0.1.0" }
                    }),
                );
                false
            }
            "initialized" => {
                let message = format!(
                    "Spiral ready. backend {} compiler {}",
                    self.options.backend,
                    Path::new(&self.options.compiler)
                        .file_name()
                        .and_then(|name| name.to_str())
                        .unwrap_or(&self.options.compiler)
                );
                self.log(
                    3,
                    &format!(
                        "spiral-zed listening. backend {} dotnet {} compiler {}",
                        self.options.backend, self.options.dotnet, self.options.compiler
                    ),
                );
                self.show(3, &message);
                false
            }
            "shutdown" => {
                self.respond(id, Value::Null);
                false
            }
            "exit" => true,
            "textDocument/didOpen" => {
                if let Some((uri, text)) = text_of(&message, "textDocument") {
                    self.open_doc(uri, text);
                }
                false
            }
            "textDocument/didChange" => {
                if let Some(uri) = message
                    .pointer("/params/textDocument/uri")
                    .and_then(Value::as_str)
                {
                    if let Some(text) = message
                        .pointer("/params/contentChanges/0/text")
                        .and_then(Value::as_str)
                    {
                        if let Some(doc) = self.docs.get_mut(uri) {
                            doc.text = text.to_string();
                        }
                    }
                }
                false
            }
            "textDocument/didSave" => {
                if let Some(uri) = message
                    .pointer("/params/textDocument/uri")
                    .and_then(Value::as_str)
                {
                    let uri = uri.to_string();
                    self.check(&uri);
                }
                false
            }
            "textDocument/hover" => {
                let result = self.hover(&message);
                self.respond(id, result);
                false
            }
            "textDocument/semanticTokens/full" => {
                let tokens = message
                    .pointer("/params/textDocument/uri")
                    .and_then(Value::as_str)
                    .and_then(|uri| self.docs.get(uri))
                    .map(|doc| semantic_tokens(&doc.text))
                    .unwrap_or_default();
                self.respond(id, json!({ "data": tokens }));
                false
            }
            "textDocument/documentLink" => {
                let links = message
                    .pointer("/params/textDocument/uri")
                    .and_then(Value::as_str)
                    .and_then(|uri| self.docs.get(uri).map(|doc| (uri.to_string(), doc)))
                    .map(|(uri, doc)| document_links(&uri, &doc.text))
                    .unwrap_or_default();
                self.respond(id, Value::Array(links));
                false
            }
            "textDocument/codeAction" => {
                let actions = self.code_actions(&message);
                self.respond(id, Value::Array(actions));
                false
            }
            "workspace/executeCommand" => {
                let command = message
                    .pointer("/params/command")
                    .and_then(Value::as_str)
                    .unwrap_or("");
                let uri = message
                    .pointer("/params/arguments/0")
                    .and_then(Value::as_str)
                    .unwrap_or("")
                    .to_string();
                match command {
                    "spiral.buildFile" => self.build(&uri),
                    "spiral.showStatus" => self.show_status(),
                    "spiral.createFile" => self.create_file(Path::new(&uri)),
                    "spiral.deleteFile" => self.delete_file(Path::new(&uri)),
                    "spiral.createDirectory" => self.create_directory(Path::new(&uri)),
                    _ => self.log(1, &format!("unknown command {command}")),
                }
                self.respond(id, Value::Null);
                false
            }
            _ => {
                if id.is_some() {
                    self.respond(id, Value::Null);
                }
                false
            }
        }
    }

    fn open_doc(&mut self, uri: String, text: String) {
        let path = uri_to_path(&uri).unwrap_or_else(|| PathBuf::from(&uri));
        let check = is_module(&path);
        self.docs.insert(uri.clone(), Doc { path, text });
        if check {
            self.check(&uri);
        } else {
            self.log(3, "opened a project file; module check runs on .spi and .spir");
            self.publish(&uri, Vec::new());
        }
    }

    fn check(&mut self, uri: &str) {
        let Some(doc) = self.docs.get(uri) else {
            return;
        };
        let path = doc.path.clone();
        if !is_module(&path) {
            return;
        }
        self.log(3, &format!("check {}", path.display()));
        let started = std::time::Instant::now();
        let output = run(
            &self.options,
            &[
                &self.options.compiler,
                "--check",
                &path.to_string_lossy(),
            ],
            Duration::from_secs(90),
        );
        self.note_output(uri, &output);
        let diagnostics = diagnostics_from(&output.stderr, &output.stdout, output.status);
        self.log(
            if diagnostics.is_empty() { 3 } else { 1 },
            &format!(
                "check finished in {}ms, {} diagnostic(s)",
                started.elapsed().as_millis(),
                diagnostics.len()
            ),
        );
        if let Some(first) = diagnostics.first() {
            self.show(1, &toast_diagnostic(first));
        }
        self.publish(uri, diagnostics);
    }

    fn build(&mut self, uri: &str) {
        let Some(doc) = self.docs.get(uri) else {
            self.log(1, "build requested before the file was opened");
            return;
        };
        let path = doc.path.clone();
        if !is_module(&path) {
            self.log(2, "build file applies to .spi and .spir modules");
            self.show(2, "Spiral build applies to .spi and .spir modules.");
            return;
        }
        let mut output_path = path.clone();
        output_path.set_extension("rs");
        self.log(
            3,
            &format!(
                "build {} --backend {} -> {}",
                path.display(),
                self.options.backend,
                output_path.display()
            ),
        );
        let output = run(
            &self.options,
            &[
                &self.options.compiler,
                "--backend",
                &self.options.backend,
                &path.to_string_lossy(),
                &output_path.to_string_lossy(),
            ],
            Duration::from_secs(180),
        );
        self.note_output(uri, &output);
        self.log(
            if output.status == 0 { 3 } else { 1 },
            &format!(
                "build exit {}\n{}\n{}",
                output.status,
                clip(output.stdout.trim(), 500),
                clip(output.stderr.trim(), 2000)
            ),
        );
        let diagnostics = diagnostics_from(&output.stderr, &output.stdout, output.status);
        if output.status == 0 {
            self.show(3, &format!("Spiral build wrote {}", output_path.display()));
        } else if let Some(first) = diagnostics.first() {
            self.show(1, &toast_diagnostic(first));
        }
        self.publish(uri, diagnostics);
    }

    fn show_status(&self) {
        let message = format!(
            "Spiral backend {} compiler {}",
            self.options.backend,
            Path::new(&self.options.compiler)
                .file_name()
                .and_then(|name| name.to_str())
                .unwrap_or(&self.options.compiler)
        );
        self.log(
            3,
            &format!(
                "{message}\ndotnet {}\ncompiler {}",
                self.options.dotnet, self.options.compiler
            ),
        );
        self.show(3, &message);
    }

    fn hover(&self, message: &Value) -> Value {
        let uri = message
            .pointer("/params/textDocument/uri")
            .and_then(Value::as_str)
            .unwrap_or("");
        let line = message
            .pointer("/params/position/line")
            .and_then(Value::as_u64)
            .unwrap_or(0) as usize;
        let character = message
            .pointer("/params/position/character")
            .and_then(Value::as_u64)
            .unwrap_or(0) as usize;
        let Some(doc) = self.docs.get(uri) else {
            return Value::Null;
        };
        let source_line = doc.text.lines().nth(line).unwrap_or("");
        let (start, word) = word_at(source_line, character);
        let kind = token_kind(&word);
        let mut body = format!("{word}\n{kind}\nbackend {}", self.options.backend);
        if let Some(note) = self.notes.get(uri) {
            if !note.is_empty() {
                body.push_str("\n\n");
                body.push_str(note);
            }
        }
        json!({
            "contents": { "kind": "plaintext", "value": body },
            "range": {
                "start": { "line": line, "character": start },
                "end": { "line": line, "character": start + word.chars().count() }
            }
        })
    }

    fn code_actions(&self, message: &Value) -> Vec<Value> {
        let uri = message
            .pointer("/params/textDocument/uri")
            .and_then(Value::as_str)
            .unwrap_or("");
        let Some(doc) = self.docs.get(uri) else {
            return Vec::new();
        };
        let mut actions = vec![json!({
            "title": "Spiral: Show compiler",
            "kind": "source",
            "command": {
                "title": "Spiral: Show compiler",
                "command": "spiral.showStatus",
                "arguments": [uri]
            }
        })];
        if is_module(&doc.path) {
            actions.insert(0, json!({
                "title": "Spiral: Build file",
                "kind": "source",
                "command": {
                    "title": "Spiral: Build file",
                    "command": "spiral.buildFile",
                    "arguments": [uri]
                }
            }));
        }
        if uri.ends_with("package.spiproj") {
            actions.extend(project_actions(uri, &doc.text, &doc.path));
        }
        actions
    }

    fn create_file(&self, path: &Path) {
        match create_module_file(path) {
            Ok(()) => self.show(3, &format!("Created {}", path.display())),
            Err(error) => {
                self.log(1, &error);
                self.show(1, &error);
            }
        }
    }

    fn delete_file(&self, path: &Path) {
        match std::fs::remove_file(path) {
            Ok(()) => self.show(3, &format!("Deleted {}", path.display())),
            Err(error) => {
                let error = format!("Delete file failed: {error}");
                self.log(1, &error);
                self.show(1, &error);
            }
        }
    }

    fn create_directory(&self, path: &Path) {
        match std::fs::create_dir_all(path) {
            Ok(()) => self.show(3, &format!("Created {}", path.display())),
            Err(error) => {
                let error = format!("Create directory failed: {error}");
                self.log(1, &error);
                self.show(1, &error);
            }
        }
    }

    fn note_output(&mut self, uri: &str, output: &RunOutput) {
        let mut text = String::new();
        if !output.stdout.trim().is_empty() {
            text.push_str(output.stdout.trim());
        }
        if !output.stderr.trim().is_empty() {
            if !text.is_empty() {
                text.push('\n');
            }
            text.push_str(output.stderr.trim());
        }
        self.notes.insert(uri.to_string(), clip(&text, 8000));
    }

    fn publish(&self, uri: &str, diagnostics: Vec<Value>) {
        self.notify(
            "textDocument/publishDiagnostics",
            json!({ "uri": uri, "diagnostics": diagnostics }),
        );
    }

    fn log(&self, typ: u8, message: &str) {
        eprintln!("spiral-zed: {message}");
        self.notify(
            "window/logMessage",
            json!({ "type": typ, "message": message }),
        );
    }

    fn show(&self, typ: u8, message: &str) {
        self.notify(
            "window/showMessage",
            json!({ "type": typ, "message": message }),
        );
    }

    fn respond(&self, id: Option<Value>, result: Value) {
        let Some(id) = id else {
            return;
        };
        self.send(&json!({ "jsonrpc": "2.0", "id": id, "result": result }));
    }

    fn notify(&self, method: &str, params: Value) {
        self.send(&json!({ "jsonrpc": "2.0", "method": method, "params": params }));
    }

    fn send(&self, message: &Value) {
        let body = message.to_string();
        let mut stdout = self.stdout.lock().expect("stdout");
        let _ = write!(stdout, "Content-Length: {}\r\n\r\n{body}", body.len());
        let _ = stdout.flush();
    }
}

struct RunOutput {
    status: i32,
    stdout: String,
    stderr: String,
}

fn run(options: &Options, args: &[&str], timeout: Duration) -> RunOutput {
    let mut command = Command::new(&options.dotnet);
    command
        .args(args)
        .env("DOTNET_NOLOGO", "1")
        .env("DOTNET_CLI_TELEMETRY_OPTOUT", "1")
        .stdout(std::process::Stdio::piped())
        .stderr(std::process::Stdio::piped());
    if let Some(root) = Path::new(&options.dotnet).parent() {
        command.env("DOTNET_ROOT", root);
    }
    let mut child = match command.spawn() {
        Ok(child) => child,
        Err(error) => {
            return RunOutput {
                status: 1,
                stdout: String::new(),
                stderr: format!("failed to start dotnet: {error}"),
            };
        }
    };
    let stdout_pipe = child.stdout.take();
    let stderr_pipe = child.stderr.take();
    let stdout_thread = std::thread::spawn(move || read_pipe(stdout_pipe));
    let stderr_thread = std::thread::spawn(move || read_pipe(stderr_pipe));
    let started = std::time::Instant::now();
    let status = loop {
        if let Some(status) = child.try_wait().ok().flatten() {
            break status.code().unwrap_or(1);
        }
        if started.elapsed() > timeout {
            let _ = child.kill();
            let _ = child.wait();
            break 3;
        }
        std::thread::sleep(Duration::from_millis(50));
    };
    let stdout = stdout_thread.join().unwrap_or_default();
    let mut stderr = stderr_thread.join().unwrap_or_default();
    if status == 3 {
        stderr.push_str(&format!("\ncompiler timed out after {}s", timeout.as_secs()));
    }
    RunOutput {
        status,
        stdout,
        stderr,
    }
}

fn read_pipe(pipe: Option<impl Read>) -> String {
    let mut text = String::new();
    if let Some(mut pipe) = pipe {
        let _ = pipe.read_to_string(&mut text);
    }
    text
}

fn diagnostics_from(stderr: &str, stdout: &str, status: i32) -> Vec<Value> {
    if status == 0 {
        return Vec::new();
    }
    let text = if stderr.trim().is_empty() {
        stdout.trim()
    } else {
        stderr.trim()
    };
    if text.is_empty() {
        return vec![diagnostic(0, 0, 1, "compiler failed")];
    }
    let (line, character) = trace_location(text).unwrap_or((0, 0));
    vec![diagnostic(line, character, character + 1, &clip(text, 4000))]
}

fn trace_location(text: &str) -> Option<(usize, usize)> {
    const MARKER: &str = "Error trace on line: ";
    let rest = text.get(text.find(MARKER)? + MARKER.len()..)?;
    let (line, rest) = leading_usize(rest)?;
    let rest = rest.trim_start().strip_prefix(", column:")?;
    let (column, _) = leading_usize(rest.trim_start())?;
    Some((line.saturating_sub(1), column.saturating_sub(1)))
}

fn leading_usize(text: &str) -> Option<(usize, &str)> {
    let digits = text.chars().take_while(|ch| ch.is_ascii_digit()).count();
    if digits == 0 {
        return None;
    }
    let (head, tail) = text.split_at(digits);
    Some((head.parse().ok()?, tail))
}

fn clip(text: &str, max: usize) -> String {
    if text.len() <= max {
        return text.to_string();
    }
    let mut end = max;
    while !text.is_char_boundary(end) {
        end -= 1;
    }
    format!("{}…", &text[..end])
}

fn is_module(path: &Path) -> bool {
    matches!(
        path.extension().and_then(|ext| ext.to_str()),
        Some("spi" | "spir")
    )
}

fn diagnostic(line: usize, start: usize, end: usize, message: &str) -> Value {
    json!({
        "range": {
            "start": { "line": line, "character": start },
            "end": { "line": line, "character": end }
        },
        "severity": 1,
        "source": "spiral",
        "message": message
    })
}

fn document_links(uri: &str, text: &str) -> Vec<Value> {
    if !uri.ends_with("package.spiproj") {
        return Vec::new();
    }
    let Some(dir) = uri_to_path(uri).and_then(|path| path.parent().map(Path::to_path_buf)) else {
        return Vec::new();
    };
    let mut module_dir = dir.clone();
    let mut in_modules = false;
    let mut links = Vec::new();
    for (line_index, line) in text.lines().enumerate() {
        let trimmed = line.trim();
        if let Some(rest) = trimmed.strip_prefix("moduleDir:") {
            module_dir = dir.join(rest.trim());
            in_modules = false;
            continue;
        }
        if trimmed == "modules:" {
            in_modules = true;
            continue;
        }
        if in_modules && trimmed.ends_with(':') {
            in_modules = false;
            continue;
        }
        if in_modules && !trimmed.is_empty() && !trimmed.starts_with('#') {
            let name = trimmed;
            let column = line.find(name).unwrap_or(0);
            let target = module_dir.join(format!("{name}.spi"));
            links.push(json!({
                "range": {
                    "start": { "line": line_index, "character": column },
                    "end": { "line": line_index, "character": column + name.chars().count() }
                },
                "target": path_to_uri(&target)
            }));
        }
    }
    links
}

fn project_actions(uri: &str, text: &str, project: &Path) -> Vec<Value> {
    let Some(dir) = project.parent() else {
        return Vec::new();
    };
    let mut module_dir = dir.to_path_buf();
    let mut in_modules = false;
    let mut actions = Vec::new();
    for (line_index, line) in text.lines().enumerate() {
        let trimmed = line.trim();
        if let Some(rest) = trimmed.strip_prefix("moduleDir:") {
            module_dir = dir.join(rest.trim());
            if !module_dir.is_dir() {
                actions.push(filesystem_action(uri, line_index, line, "Create directory.", "spiral.createDirectory", &module_dir, false));
            }
            in_modules = false;
            continue;
        }
        if trimmed == "modules:" {
            in_modules = true;
            continue;
        }
        if in_modules && trimmed.ends_with(':') {
            in_modules = false;
            continue;
        }
        if in_modules && !trimmed.is_empty() && !trimmed.starts_with('#') {
            let target = module_dir.join(format!("{trimmed}.spi"));
            if target.is_file() {
                actions.push(filesystem_action(uri, line_index, line, "Delete file.", "spiral.deleteFile", &target, true));
            } else {
                actions.push(filesystem_action(uri, line_index, line, "Create file.", "spiral.createFile", &target, false));
            }
        }
    }
    actions
}

fn filesystem_action(uri: &str, line_index: usize, line: &str, title: &str, command: &str, path: &Path, remove_line: bool) -> Value {
    let mut action = json!({
        "title": title,
        "kind": "refactor",
        "command": {
            "title": title,
            "command": command,
            "arguments": [path.to_string_lossy()]
        }
    });
    if remove_line {
        let end_line = line_index + if line.ends_with('\n') { 0 } else { 1 };
        action["edit"] = json!({
            "changes": {
                uri: [{
                    "range": {
                        "start": { "line": line_index, "character": 0 },
                        "end": { "line": end_line, "character": 0 }
                    },
                    "newText": ""
                }]
            }
        });
    }
    action
}

fn create_module_file(path: &Path) -> Result<(), String> {
    if path.exists() {
        return Err("File already exists.".to_string());
    }
    if let Some(parent) = path.parent() {
        std::fs::create_dir_all(parent).map_err(|error| error.to_string())?;
    }
    std::fs::File::create(path).map_err(|error| error.to_string())?;
    Ok(())
}

fn word_at(line: &str, character: usize) -> (usize, String) {
    let chars: Vec<char> = line.chars().collect();
    if chars.is_empty() {
        return (0, String::new());
    }
    let mut index = character.min(chars.len().saturating_sub(1));
    if !is_word(chars[index]) {
        if index > 0 && is_word(chars[index - 1]) {
            index -= 1;
        } else {
            return (index, chars[index].to_string());
        }
    }
    let mut start = index;
    while start > 0 && is_word(chars[start - 1]) {
        start -= 1;
    }
    let mut end = index + 1;
    while end < chars.len() && is_word(chars[end]) {
        end += 1;
    }
    (start, chars[start..end].iter().collect())
}

fn is_word(ch: char) -> bool {
    ch.is_ascii_alphanumeric() || ch == '_' || ch == '\''
}

fn token_kind(word: &str) -> &'static str {
    const KEYWORDS: &[&str] = &[
        "inl", "inm", "inb", "forall", "union", "nominal", "real", "type", "open", "match",
        "typecase", "function", "with", "without", "as", "when", "let", "rec", "if", "then",
        "elif", "else", "join", "join_backend", "prototype", "instance", "in", "and", "fun",
        "exists",
    ];
    if KEYWORDS.contains(&word) {
        "keyword"
    } else if word.starts_with(|ch: char| ch.is_ascii_uppercase()) {
        "type"
    } else if word.chars().all(|ch| ch.is_ascii_digit()) {
        "number"
    } else {
        "variable"
    }
}

fn semantic_tokens(text: &str) -> Vec<u32> {
    let mut data = Vec::new();
    let mut prev_line = 0u32;
    let mut prev_char = 0u32;
    for token in scan_tokens(text) {
        let line = token.line;
        let character = token.character;
        let delta_line = line - prev_line;
        let delta_char = if delta_line == 0 {
            character - prev_char
        } else {
            character
        };
        data.extend([delta_line, delta_char, token.length, token.kind, 0]);
        prev_line = line;
        prev_char = character;
    }
    data
}

const KIND_VARIABLE: u32 = 0;
const KIND_SYMBOL: u32 = 1;
const KIND_STRING: u32 = 2;
const KIND_NUMBER: u32 = 3;
const KIND_OPERATOR: u32 = 4;
const KIND_UNARY: u32 = 5;
const KIND_COMMENT: u32 = 6;
const KIND_KEYWORD: u32 = 7;
const KIND_PAREN: u32 = 8;
const KIND_NUMBER_SUFFIX: u32 = 12;
const KIND_ESCAPED_VAR: u32 = 13;
const KIND_TYPE: u32 = 14;

struct ScanToken {
    line: u32,
    character: u32,
    length: u32,
    kind: u32,
}

fn scan_tokens(text: &str) -> Vec<ScanToken> {
    let chars: Vec<char> = text.chars().collect();
    let mut tokens = Vec::new();
    let mut line = 0u32;
    let mut character = 0u32;
    let mut index = 0;
    while index < chars.len() {
        let ch = chars[index];
        if ch == '\n' {
            line += 1;
            character = 0;
            index += 1;
            continue;
        }
        if ch == '/' && chars.get(index + 1) == Some(&'/') {
            let start = index;
            while index < chars.len() && chars[index] != '\n' {
                index += 1;
            }
            push_token(&mut tokens, line, character, (index - start) as u32, KIND_COMMENT);
            character += (index - start) as u32;
            continue;
        }
        if ch == '(' && chars.get(index + 1) == Some(&'*') && chars.get(index + 2) == Some(&' ') {
            let start = index;
            index += 2;
            while index + 1 < chars.len() && !(chars[index] == '*' && chars[index + 1] == ')') {
                if chars[index] == '\n' {
                    line += 1;
                    character = 0;
                }
                index += 1;
            }
            if index + 1 < chars.len() {
                index += 2;
            }
            push_token(&mut tokens, line, character, (index - start) as u32, KIND_COMMENT);
            character += (index - start) as u32;
            continue;
        }
        if ch == '"' && chars.get(index + 1) == Some(&'"') && chars.get(index + 2) == Some(&'"') {
            let (next, len) = take_triple(&chars, index);
            push_token(&mut tokens, line, character, len, KIND_STRING);
            advance(&chars, index, next, &mut line, &mut character);
            index = next;
            continue;
        }
        if ch == '"' {
            let (next, len) = take_string(&chars, index);
            push_token(&mut tokens, line, character, len, KIND_STRING);
            advance(&chars, index, next, &mut line, &mut character);
            index = next;
            continue;
        }
        if ch == '\'' {
            if let Some(len) = char_literal_len(&chars, index) {
                push_token(&mut tokens, line, character, len as u32, KIND_STRING);
                index += len;
                character += len as u32;
                continue;
            }
        }
        if ch == '~' && chars.get(index + 1).is_some_and(|next| next.is_ascii_alphabetic() || *next == '_') {
            push_token(&mut tokens, line, character, 1, KIND_ESCAPED_VAR);
            index += 1;
            character += 1;
            continue;
        }
        if matches!(ch, '(' | ')' | '[' | ']' | '{' | '}') {
            push_token(&mut tokens, line, character, 1, KIND_PAREN);
            index += 1;
            character += 1;
            continue;
        }
        if ch == '.' && chars.get(index + 1).is_some_and(|next| next.is_ascii_alphabetic() || *next == '_') {
            let start = index;
            index += 2;
            while index < chars.len() && (chars[index].is_ascii_alphanumeric() || chars[index] == '_' || chars[index] == '\'') {
                index += 1;
            }
            push_token(&mut tokens, line, character, (index - start) as u32, KIND_SYMBOL);
            character += (index - start) as u32;
            continue;
        }
        if is_operator_char(ch) {
            let start = index;
            index += 1;
            while index < chars.len() && is_operator_char(chars[index]) {
                index += 1;
            }
            let kind = if unary_operator(&chars, start, index) { KIND_UNARY } else { KIND_OPERATOR };
            push_token(&mut tokens, line, character, (index - start) as u32, kind);
            character += (index - start) as u32;
            continue;
        }
        if ch.is_ascii_alphabetic() || ch == '_' {
            let start = index;
            index += 1;
            while index < chars.len() && (chars[index].is_ascii_alphanumeric() || chars[index] == '_' || chars[index] == '\'') {
                index += 1;
            }
            let word: String = chars[start..index].iter().collect();
            let kind = match token_kind(&word) {
                "keyword" => KIND_KEYWORD,
                "type" => KIND_TYPE,
                "number" => KIND_NUMBER,
                _ => KIND_VARIABLE,
            };
            push_token(&mut tokens, line, character, (index - start) as u32, kind);
            character += (index - start) as u32;
            continue;
        }
        if ch.is_ascii_digit() {
            let start = index;
            index += 1;
            while index < chars.len() && chars[index].is_ascii_digit() {
                index += 1;
            }
            if chars.get(index) == Some(&'.') && chars.get(index + 1).is_some_and(|next| next.is_ascii_digit()) {
                index += 1;
                while index < chars.len() && chars[index].is_ascii_digit() {
                    index += 1;
                }
            }
            push_token(&mut tokens, line, character, (index - start) as u32, KIND_NUMBER);
            character += (index - start) as u32;
            if let Some(suffix) = number_suffix_len(&chars, index) {
                push_token(&mut tokens, line, character, suffix as u32, KIND_NUMBER_SUFFIX);
                index += suffix;
                character += suffix as u32;
            }
            continue;
        }
        index += 1;
        character += 1;
    }
    tokens
}

fn is_operator_char(ch: char) -> bool {
    ('!'..='~').contains(&ch)
        && !ch.is_ascii_alphanumeric()
        && ch != '_'
        && ch != '"'
        && ch != '\''
        && !matches!(ch, '(' | ')' | '[' | ']' | '{' | '}')
}

fn unary_operator(chars: &[char], start: usize, end: usize) -> bool {
    let before = if start == 0 { '\n' } else { chars[start - 1] };
    let after = chars.get(end).copied().unwrap_or('\n');
    let prefix = before == ' ' || before == '\n' || before == '\t' || matches!(before, '(' | '[' | '{');
    let postfix = after == ' ' || after == '\n' || after == '\t' || matches!(after, ')' | ']' | '}');
    prefix && !postfix
}

fn number_suffix_len(chars: &[char], index: usize) -> Option<usize> {
    const SUFFIXES: &[&str] = &["i64", "i32", "i16", "i8", "u64", "u32", "u16", "u8", "f64", "f32"];
    let rest: String = chars[index..].iter().take(3).collect();
    SUFFIXES.iter().find_map(|suffix| {
        if !rest.starts_with(suffix) {
            return None;
        }
        let after = chars.get(index + suffix.len()).copied().unwrap_or(' ');
        if after.is_ascii_alphanumeric() || after == '_' {
            None
        } else {
            Some(suffix.len())
        }
    })
}

fn char_literal_len(chars: &[char], index: usize) -> Option<usize> {
    let body = *chars.get(index + 1)?;
    if body == '\\' {
        let _escaped = chars.get(index + 2)?;
        if chars.get(index + 3) == Some(&'\'') {
            return Some(4);
        }
        return None;
    }
    if body == '\'' || body == '\n' {
        return None;
    }
    if chars.get(index + 2) == Some(&'\'') {
        Some(3)
    } else {
        None
    }
}

fn push_token(tokens: &mut Vec<ScanToken>, line: u32, character: u32, length: u32, kind: u32) {
    if length == 0 {
        return;
    }
    tokens.push(ScanToken {
        line,
        character,
        length,
        kind,
    });
}

fn take_string(chars: &[char], start: usize) -> (usize, u32) {
    let mut index = start + 1;
    while index < chars.len() && chars[index] != '\n' {
        if chars[index] == '\\' && index + 1 < chars.len() && chars[index + 1] != '\n' {
            index += 2;
            continue;
        }
        if chars[index] == '"' {
            index += 1;
            return (index, (index - start) as u32);
        }
        index += 1;
    }
    (index, (index - start) as u32)
}

fn take_triple(chars: &[char], start: usize) -> (usize, u32) {
    let mut index = start + 3;
    while index + 2 < chars.len() {
        if chars[index] == '"' && chars[index + 1] == '"' && chars[index + 2] == '"' {
            index += 3;
            return (index, (index - start) as u32);
        }
        index += 1;
    }
    (chars.len(), (chars.len() - start) as u32)
}

fn advance(chars: &[char], from: usize, to: usize, line: &mut u32, character: &mut u32) {
    for ch in &chars[from..to] {
        if *ch == '\n' {
            *line += 1;
            *character = 0;
        } else {
            *character += 1;
        }
    }
}

fn text_of(message: &Value, field: &str) -> Option<(String, String)> {
    let uri = message
        .pointer(&format!("/params/{field}/uri"))
        .and_then(Value::as_str)?
        .to_string();
    let text = message
        .pointer(&format!("/params/{field}/text"))
        .and_then(Value::as_str)?
        .to_string();
    Some((uri, text))
}

fn uri_to_path(uri: &str) -> Option<PathBuf> {
    let rest = uri.strip_prefix("file://")?;
    let rest = rest.strip_prefix('/').unwrap_or(rest);
    let decoded = percent_decode(rest);
    #[cfg(windows)]
    let decoded = decoded.replace('/', "\\");
    Some(PathBuf::from(decoded))
}

fn path_to_uri(path: &Path) -> String {
    let text = path.to_string_lossy().replace('\\', "/");
    if text.starts_with('/') {
        format!("file://{text}")
    } else {
        format!("file:///{text}")
    }
}

fn percent_decode(text: &str) -> String {
    let bytes = text.as_bytes();
    let mut out = Vec::new();
    let mut index = 0;
    while index < bytes.len() {
        if bytes[index] == b'%' && index + 2 < bytes.len() {
            if let Ok(value) = u8::from_str_radix(std::str::from_utf8(&bytes[index + 1..index + 3]).unwrap_or(""), 16) {
                out.push(value);
                index += 3;
                continue;
            }
        }
        out.push(bytes[index]);
        index += 1;
    }
    String::from_utf8_lossy(&out).into_owned()
}

fn read_message(reader: &mut BufReader<impl Read>) -> Option<Value> {
    let mut content_length = 0usize;
    loop {
        let mut line = String::new();
        let read = reader.read_line(&mut line).ok()?;
        if read == 0 {
            return None;
        }
        let trimmed = line.trim();
        if trimmed.is_empty() {
            break;
        }
        if let Some(rest) = trimmed.strip_prefix("Content-Length:") {
            content_length = rest.trim().parse().unwrap_or(0);
        }
    }
    if content_length == 0 {
        return None;
    }
    let mut body = vec![0; content_length];
    reader.read_exact(&mut body).ok()?;
    serde_json::from_slice(&body).ok()
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn empty_string_at_end_of_line_is_closed() {
        let tokens = scan_tokens("if ready then \"\"\nnext\n");
        let strings: Vec<_> = tokens.iter().filter(|token| token.kind == KIND_STRING).collect();
        assert_eq!(strings.len(), 1);
        assert_eq!(strings[0].length, 2);
        assert!(tokens.iter().any(|token| token.line == 1));
    }

    #[test]
    fn escaped_quote_before_closer_stays_one_string() {
        let tokens = scan_tokens("value = \"Include=\\\"\"\nnext\n");
        let strings: Vec<_> = tokens.iter().filter(|token| token.kind == KIND_STRING).collect();
        assert_eq!(strings.len(), 1);
        assert_eq!(strings[0].line, 0);
    }

    #[test]
    fn trace_location_is_zero_based() {
        let text = "Error trace on line: 2, column: 5 in module: main.spi .\n    \"no\"\n    ^\n";
        assert_eq!(trace_location(text), Some((1, 4)));
        let diagnostics = diagnostics_from(text, "", 5);
        assert_eq!(diagnostics.len(), 1);
        assert_eq!(diagnostics[0].pointer("/range/start/line").and_then(Value::as_u64), Some(1));
        assert_eq!(diagnostics[0].pointer("/range/start/character").and_then(Value::as_u64), Some(4));
    }

    #[test]
    fn a_clean_check_publishes_nothing() {
        assert!(diagnostics_from("", "checked package x", 0).is_empty());
    }

    #[test]
    fn a_rejection_without_a_trace_is_one_diagnostic() {
        let diagnostics = diagnostics_from("Package typecheck rejected: pkg\nmore detail\n", "", 5);
        assert_eq!(diagnostics.len(), 1);
        assert_eq!(diagnostics[0].pointer("/range/start/line").and_then(Value::as_u64), Some(0));
    }

    #[test]
    fn hover_includes_the_compiler_note() {
        let mut server = Server {
            options: Options {
                dotnet: "dotnet".into(),
                compiler: "SpiralCompiler.dll".into(),
                backend: "Rust".into(),
            },
            docs: HashMap::new(),
            notes: HashMap::new(),
            stdout: Mutex::new(std::io::stdout()),
        };
        let uri = "file:///C:/fixture/main.spi";
        server.docs.insert(
            uri.into(),
            Doc {
                path: PathBuf::from("main.spi"),
                text: "inl main () : i32 = 0i32\n".into(),
            },
        );
        server.notes.insert(uri.into(), "Package typecheck rejected".into());
        let hover = server.hover(&json!({
            "params": {
                "textDocument": { "uri": uri },
                "position": { "line": 0, "character": 0 }
            }
        }));
        let body = hover.pointer("/contents/value").and_then(Value::as_str).unwrap();
        assert!(body.contains("inl"));
        assert!(body.contains("keyword"));
        assert!(body.contains("Package typecheck rejected"));
    }

    #[test]
    fn vscode_token_kinds_cover_suffix_tilde_symbol_and_char() {
        let tokens = scan_tokens("inl ~x = 6i32\n.name\n'a'\n-y\n");
        assert!(tokens.iter().any(|token| token.kind == KIND_ESCAPED_VAR && token.length == 1));
        assert!(tokens.iter().any(|token| token.kind == KIND_NUMBER && token.length == 1));
        assert!(tokens.iter().any(|token| token.kind == KIND_NUMBER_SUFFIX && token.length == 3));
        assert!(tokens.iter().any(|token| token.kind == KIND_SYMBOL && token.length == 5));
        assert!(tokens.iter().any(|token| token.kind == KIND_STRING && token.length == 3));
        assert!(tokens.iter().any(|token| token.kind == KIND_UNARY));
        let between = scan_tokens("x - y\n");
        assert!(between.iter().any(|token| token.kind == KIND_OPERATOR));
        assert!(!between.iter().any(|token| token.kind == KIND_UNARY));
    }

    #[test]
    fn missing_module_offers_create_file() {
        let dir = std::env::temp_dir().join("spiral-zed-missing-module");
        let _ = std::fs::remove_dir_all(&dir);
        std::fs::create_dir_all(&dir).unwrap();
        let project = dir.join("package.spiproj");
        let actions = project_actions("file:///pkg/package.spiproj", "modules:\n    gone\n", &project);
        assert!(actions.iter().any(|action| action["title"] == "Create file."));
        let created = dir.join("gone.spi");
        create_module_file(&created).unwrap();
        let again = project_actions("file:///pkg/package.spiproj", "modules:\n    gone\n", &project);
        assert!(again.iter().any(|action| action["title"] == "Delete file."));
        assert!(create_module_file(&created).is_err());
        let _ = std::fs::remove_dir_all(&dir);
    }
}
