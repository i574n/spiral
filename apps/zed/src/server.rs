
use std::path::{Path, PathBuf};
use zed_extension_api::{settings::LspSettings, Command, LanguageServerId, Result, Worktree};

pub const LANGUAGE_SERVER_ID: &str = "spiral-lsp";

#[derive(Debug, Clone, serde::Serialize, serde::Deserialize)]
pub struct SpiralSettings {
    #[serde(default = "default_backend")]
    pub backend: String,
    #[serde(default = "default_port")]
    pub port: u16,
    #[serde(default = "default_int")]
    pub default_int: String,
    #[serde(default = "default_float")]
    pub default_float: String,
    #[serde(default = "default_trace_length")]
    pub error_trace_max_length: usize,
}

fn default_backend() -> String {
    "Rust".to_string()
}

fn default_port() -> u16 {
    13805
}

fn default_int() -> String {
    "i32".to_string()
}

fn default_float() -> String {
    "f64".to_string()
}

fn default_trace_length() -> usize {
    5
}

impl Default for SpiralSettings {
    fn default() -> Self {
        Self {
            backend: default_backend(),
            port: default_port(),
            default_int: default_int(),
            default_float: default_float(),
            error_trace_max_length: default_trace_length(),
        }
    }
}

impl SpiralSettings {
    pub fn configuration() -> serde_json::Value {
        serde_json::json!({ "spiral": SpiralSettings::default() })
    }
}

pub struct SpiralServerManager {
    cached_command: Option<Command>,
}

impl SpiralServerManager {
    pub fn new() -> Self {
        Self {
            cached_command: None,
        }
    }

    pub fn resolve_server(
        &mut self,
        _server_id: &LanguageServerId,
        worktree: &Worktree,
    ) -> Result<Command> {
        let settings = load_settings(worktree);
        let binary_settings = LspSettings::for_worktree(LANGUAGE_SERVER_ID, worktree)
            .ok()
            .and_then(|lsp_settings| lsp_settings.binary);
        let configured_path = binary_settings.and_then(|binary| binary.path);

        if let Some(path) = configured_path.filter(|path| is_dll(Path::new(path))) {
            let command = command_for_compiler(worktree, Path::new(&path), &settings)?;
            self.cached_command = Some(clone_command(&command));
            return Ok(command);
        }

        if let Some(command) = self.cached_command.clone() {
            return Ok(command);
        }

        let command = discover_compiler(worktree, &settings)?;
        self.cached_command = Some(clone_command(&command));
        Ok(command)
    }
}

fn load_settings(worktree: &Worktree) -> SpiralSettings {
    LspSettings::for_worktree(LANGUAGE_SERVER_ID, worktree)
        .ok()
        .and_then(|lsp_settings| lsp_settings.settings)
        .and_then(|value| {
            value
                .get("spiral")
                .cloned()
                .or(Some(value))
                .and_then(|value| serde_json::from_value(value).ok())
        })
        .unwrap_or_default()
}

fn discover_compiler(worktree: &Worktree, settings: &SpiralSettings) -> Result<Command> {
    if let Some(path) = shell_value(worktree, "SPIRAL_COMPILER")
        .or_else(|| shell_value(worktree, "EOIE_SPIRAL_COMPILE"))
    {
        let path = PathBuf::from(path);
        if path.is_file() {
            return command_for_compiler(worktree, &path, settings);
        }
    }

    let cache_dll = spiral_cache_dir(worktree).map(|cache| {
        cache.join("bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll")
    });
    if let Some(dll) = cache_dll.as_ref().filter(|dll| dll.is_file()) {
        return command_for_compiler(worktree, dll, settings);
    }

    let root = PathBuf::from(worktree.root_path());
    for relative in [
        "apps/compiler/tmp/compiler/host/SpiralCompiler.dll",
        "spiral/apps/compiler/tmp/compiler/host/SpiralCompiler.dll",
        "apps/compiler/dist/SpiralCompiler.dll",
        "spiral/apps/compiler/dist/SpiralCompiler.dll",
    ] {
        let candidate = root.join(relative);
        if candidate.is_file() {
            return command_for_compiler(worktree, &candidate, settings);
        }
    }

    if let Some(dll) = cache_dll {
        return command_for_compiler(worktree, &dll, settings);
    }

    Err("single-flight SpiralCompiler.dll was not found. Build spiral/apps/compiler (single-flight) or set SPIRAL_COMPILER to that dll.".to_string())
}

fn command_for_compiler(
    worktree: &Worktree,
    compiler: &Path,
    settings: &SpiralSettings,
) -> Result<Command> {
    let helper = helper_path(worktree).ok_or_else(|| {
        "spiral-zed.exe was not found next to apps/zed. Build it with cargo build --release --bin spiral-zed in spiral/apps/zed."
            .to_string()
    })?;
    let dotnet = dotnet_command(worktree);
    Ok(Command {
        command: helper.to_string_lossy().to_string(),
        args: vec![
            "--dotnet".to_string(),
            dotnet.clone(),
            "--compiler".to_string(),
            compiler.to_string_lossy().to_string(),
            "--backend".to_string(),
            settings.backend.clone(),
        ],
        env: compiler_env(worktree, &dotnet),
    })
}

fn helper_path(worktree: &Worktree) -> Option<PathBuf> {
    let root = PathBuf::from(worktree.root_path());
    let name = if cfg!(windows) {
        "spiral-zed.exe"
    } else {
        "spiral-zed"
    };
    let mut candidates = Vec::new();
    for relative in [
        "apps/zed/dist",
        "spiral/apps/zed/dist",
        "apps/zed/target/release",
        "spiral/apps/zed/target/release",
    ] {
        candidates.push(root.join(relative).join(name));
    }
    if let Some(parent) = root.parent() {
        candidates.push(parent.join("spiral").join("apps").join("zed").join("dist").join(name));
        candidates.push(parent.join("apps").join("zed").join("dist").join(name));
    }
    candidates.into_iter().find(|path| path.is_file())
}

fn is_dll(path: &Path) -> bool {
    path.extension()
        .and_then(|ext| ext.to_str())
        .is_some_and(|ext| ext.eq_ignore_ascii_case("dll"))
}

fn spiral_cache_dir(worktree: &Worktree) -> Option<PathBuf> {
    if let Some(dir) = shell_value(worktree, "SPIRAL_BIN_CACHE_DIR") {
        return Some(PathBuf::from(dir));
    }
    if let Some(local) = shell_value(worktree, "LOCALAPPDATA") {
        return Some(PathBuf::from(local).join("spiral-bin"));
    }
    let home = shell_value(worktree, "HOME").or_else(|| shell_value(worktree, "USERPROFILE"))?;
    Some(PathBuf::from(home).join(".cache").join("spiral-bin"))
}

fn dotnet_command(worktree: &Worktree) -> String {
    if let Some(explicit) =
        shell_value(worktree, "SPIRAL_DOTNET").or_else(|| shell_value(worktree, "EOIE_DOTNET"))
    {
        return explicit;
    }
    if let Some(cache) = spiral_cache_dir(worktree) {
        let name = if cfg!(windows) {
            "dotnet.exe"
        } else {
            "dotnet"
        };
        let toolchain = cache.join("toolchains").join("dotnet").join(name);
        if toolchain.is_file() {
            return toolchain.to_string_lossy().to_string();
        }
    }
    worktree.which("dotnet").unwrap_or_else(|| "dotnet".to_string())
}

fn compiler_env(worktree: &Worktree, dotnet: &str) -> Vec<(String, String)> {
    let mut env = vec![
        ("DOTNET_NOLOGO".to_string(), "1".to_string()),
        ("DOTNET_CLI_TELEMETRY_OPTOUT".to_string(), "1".to_string()),
    ];
    if let Some(root) = Path::new(dotnet).parent() {
        env.push((
            "DOTNET_ROOT".to_string(),
            root.to_string_lossy().to_string(),
        ));
    }
    if let Some(workspace) = spiral_workspace_root(worktree) {
        env.push(("SPIRAL_WORKSPACE_ROOT".to_string(), workspace));
    }
    env
}

fn spiral_workspace_root(worktree: &Worktree) -> Option<String> {
    let root = PathBuf::from(worktree.root_path());
    for relative in [
        "apps/compiler/tmp",
        "spiral/apps/compiler/tmp",
        "apps/compiler/Downloads/bundle_spiral-bin_v20260926-alpha418",
        "spiral/apps/compiler/Downloads/bundle_spiral-bin_v20260926-alpha418",
    ] {
        let candidate = root.join(relative);
        if candidate.join("scripts").join("env.ps1").is_file() {
            return Some(candidate.to_string_lossy().to_string());
        }
    }
    None
}

fn shell_value(worktree: &Worktree, key: &str) -> Option<String> {
    worktree
        .shell_env()
        .into_iter()
        .find_map(|(name, value)| {
            if name.eq_ignore_ascii_case(key) && !value.is_empty() {
                Some(value)
            } else {
                None
            }
        })
        .or_else(|| std::env::var(key).ok().filter(|value| !value.is_empty()))
}

fn clone_command(command: &Command) -> Command {
    Command {
        command: command.command.clone(),
        args: command.args.clone(),
        env: command.env.clone(),
    }
}
