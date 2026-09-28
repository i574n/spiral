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

struct Doc {
    path: PathBuf,
    text: String,
}

fn main() {
    let options = match Options::from_args() {
        Ok(options) => options,
        Err(error) => {
            eprintln!("spiral-zed: {error}");
            std::process::exit(2);
        }
    };
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

impl Options {
    fn from_args() -> Result<Self, String> {
        let mut args = std::env::args().skip(1);
        let mut dotnet = None;
        let mut compiler = None;
        let mut backend = "Rust".to_string();
        while let Some(arg) = args.next() {
            match arg.as_str() {
                "--dotnet" => dotnet = args.next(),
                "--compiler" => compiler = args.next(),
                "--backend" => {
                    backend = args.next().unwrap_or_else(|| "Rust".to_string());
                }
                other => return Err(format!("unknown argument {other}")),
            }
        }
        Ok(Self {
            dotnet: dotnet.ok_or("--dotnet is required")?,
            compiler: compiler.ok_or("--compiler is required")?,
            backend,
        })
    }
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
                                "commands": ["spiral.buildFile", "spiral.showStatus"]
                            },
                            "codeActionProvider": { "codeActionKinds": ["source"] },
                            "semanticTokensProvider": {
                                "legend": {
                                    "tokenTypes": ["keyword", "string", "comment", "number", "operator", "variable", "type"],
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
                self.log(
                    3,
                    &format!(
                        "spiral-zed listening. backend {} compiler {}",
                        self.options.backend, self.options.compiler
                    ),
                );
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
        self.docs.insert(uri.clone(), Doc { path, text });
        self.check(&uri);
    }

    fn check(&mut self, uri: &str) {
        let Some(doc) = self.docs.get(uri) else {
            return;
        };
        let path = doc.path.clone();
        self.log(3, &format!("check {}", path.display()));
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
        self.publish(uri, diagnostics);
    }

    fn build(&mut self, uri: &str) {
        let Some(doc) = self.docs.get(uri) else {
            self.log(1, "build requested before the file was opened");
            return;
        };
        let path = doc.path.clone();
        if path.extension().and_then(|ext| ext.to_str()) == Some("spiproj") {
            self.log(2, "build file applies to .spi and .spir modules");
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
                output.stdout.trim(),
                output.stderr.trim()
            ),
        );
        self.publish(uri, diagnostics_from(&output.stderr, &output.stdout, output.status));
    }

    fn show_status(&self) {
        self.log(
            3,
            &format!(
                "backend {}\ndotnet {}\ncompiler {}",
                self.options.backend, self.options.dotnet, self.options.compiler
            ),
        );
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
        let ext = doc.path.extension().and_then(|ext| ext.to_str()).unwrap_or("");
        if ext != "spi" && ext != "spir" {
            return Vec::new();
        }
        vec![json!({
            "title": "Spiral: Build file",
            "kind": "source",
            "command": {
                "title": "Spiral: Build file",
                "command": "spiral.buildFile",
                "arguments": [uri]
            }
        })]
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
        self.notes.insert(uri.to_string(), text);
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
    let mut child = match Command::new(&options.dotnet)
        .args(args)
        .env("DOTNET_NOLOGO", "1")
        .env("DOTNET_CLI_TELEMETRY_OPTOUT", "1")
        .stdout(std::process::Stdio::piped())
        .stderr(std::process::Stdio::piped())
        .spawn()
    {
        Ok(child) => child,
        Err(error) => {
            return RunOutput {
                status: 1,
                stdout: String::new(),
                stderr: format!("failed to start dotnet: {error}"),
            };
        }
    };
    let started = std::time::Instant::now();
    loop {
        if let Some(status) = child.try_wait().ok().flatten() {
            let mut stdout = String::new();
            let mut stderr = String::new();
            if let Some(mut pipe) = child.stdout.take() {
                let _ = pipe.read_to_string(&mut stdout);
            }
            if let Some(mut pipe) = child.stderr.take() {
                let _ = pipe.read_to_string(&mut stderr);
            }
            return RunOutput {
                status: status.code().unwrap_or(1),
                stdout,
                stderr,
            };
        }
        if started.elapsed() > timeout {
            let _ = child.kill();
            return RunOutput {
                status: 3,
                stdout: String::new(),
                stderr: format!("compiler timed out after {}s", timeout.as_secs()),
            };
        }
        std::thread::sleep(Duration::from_millis(50));
    }
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
    text.lines()
        .filter(|line| !line.trim().is_empty())
        .map(|line| diagnostic(0, 0, line.chars().count().min(1).max(1), line.trim()))
        .collect()
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
            push_token(&mut tokens, line, character, (index - start) as u32, 2);
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
            push_token(&mut tokens, line, character, (index - start) as u32, 2);
            character += (index - start) as u32;
            continue;
        }
        if ch == '"' && chars.get(index + 1) == Some(&'"') && chars.get(index + 2) == Some(&'"') {
            let (next, len) = take_triple(&chars, index);
            push_token(&mut tokens, line, character, len, 1);
            advance(&chars, index, next, &mut line, &mut character);
            index = next;
            continue;
        }
        if ch == '"' {
            let (next, len) = take_string(&chars, index);
            push_token(&mut tokens, line, character, len, 1);
            advance(&chars, index, next, &mut line, &mut character);
            index = next;
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
                "keyword" => 0,
                "type" => 6,
                "number" => 3,
                _ => 5,
            };
            push_token(&mut tokens, line, character, (index - start) as u32, kind);
            character += (index - start) as u32;
            continue;
        }
        if ch.is_ascii_digit() {
            let start = index;
            index += 1;
            while index < chars.len() && (chars[index].is_ascii_alphanumeric() || chars[index] == '_') {
                index += 1;
            }
            push_token(&mut tokens, line, character, (index - start) as u32, 3);
            character += (index - start) as u32;
            continue;
        }
        index += 1;
        character += 1;
    }
    tokens
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
        let strings: Vec<_> = tokens.iter().filter(|token| token.kind == 1).collect();
        assert_eq!(strings.len(), 1);
        assert_eq!(strings[0].length, 2);
        assert!(tokens.iter().any(|token| token.line == 1));
    }

    #[test]
    fn escaped_quote_before_closer_stays_one_string() {
        let tokens = scan_tokens("value = \"Include=\\\"\"\nnext\n");
        let strings: Vec<_> = tokens.iter().filter(|token| token.kind == 1).collect();
        assert_eq!(strings.len(), 1);
        assert_eq!(strings[0].line, 0);
    }
}
