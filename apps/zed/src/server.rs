use std::path::{Path, PathBuf};
use zed_extension_api::{
    self as zed, settings::LspSettings, Command, LanguageServerId, Result, Worktree,
};

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
        let configured_path = binary_settings.as_ref().and_then(|binary| binary.path.as_ref());

        let mut command = if let Some(path) = configured_path {
            let compiler = host_path(path, zed::current_platform().0);
            if is_dll(&compiler) {
                command_for_compiler(worktree, &compiler, &settings)?
            } else {
                Command {
                    command: path.clone(),
                    args: Vec::new(),
                    env: Vec::new(),
                }
            }
        } else if let Some(command) = self.cached_command.as_ref() {
            clone_command(command)
        } else {
            let command = discover_compiler(worktree, &settings)?;
            self.cached_command = Some(clone_command(&command));
            command
        };

        if let Some(binary) = binary_settings {
            // Keep the helper's required compiler flags when a DLL is configured.
            command.args.extend(binary.arguments.unwrap_or_default());
            command.env.extend(binary.env.unwrap_or_default());
        }
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
        return command_for_compiler(worktree, &host_path(&path, zed::current_platform().0), settings);
    }

    // DLLs are not executables: neither WASI filesystem probes nor `which`
    // can validate them. Let the host helper report a missing compiler.
    if let Some(cache) = spiral_cache_dir(worktree) {
        let dll = cache.join("bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll");
        return command_for_compiler(worktree, &dll, settings);
    }

    Err("Cannot determine the single-flight SpiralCompiler.dll path. Set SPIRAL_COMPILER to that DLL or SPIRAL_BIN_CACHE_DIR to the compiler cache.".to_string())
}

fn command_for_compiler(
    worktree: &Worktree,
    compiler: &Path,
    settings: &SpiralSettings,
) -> Result<Command> {
    let helper = helper_path(worktree).ok_or_else(|| {
        "spiral-zed helper was not found in apps/zed/dist or apps/zed/target/release. Build it with cargo build --release --bin spiral-zed in spiral/apps/zed."
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

fn host_path(path: &str, os: zed::Os) -> PathBuf {
    // WASI's Path treats backslashes as ordinary characters, even on a Windows host.
    if os == zed::Os::Windows {
        PathBuf::from(path.replace('\\', "/"))
    } else {
        PathBuf::from(path)
    }
}

fn binary_names(os: zed::Os) -> (&'static str, &'static str) {
    if os == zed::Os::Windows {
        ("spiral-zed.exe", "dotnet.exe")
    } else {
        ("spiral-zed", "dotnet")
    }
}

fn helper_path(worktree: &Worktree) -> Option<PathBuf> {
    helper_candidates(&worktree.root_path(), zed::current_platform().0)
        .into_iter()
        .find_map(|path| worktree.which(&path.to_string_lossy()).map(PathBuf::from))
}

fn helper_candidates(root: &str, os: zed::Os) -> Vec<PathBuf> {
    let root = host_path(root, os);
    let (name, _) = binary_names(os);
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
    candidates
}

fn is_dll(path: &Path) -> bool {
    path.extension()
        .and_then(|ext| ext.to_str())
        .is_some_and(|ext| ext.eq_ignore_ascii_case("dll"))
}

fn spiral_cache_dir(worktree: &Worktree) -> Option<PathBuf> {
    let os = zed::current_platform().0;
    if let Some(dir) = shell_value(worktree, "SPIRAL_BIN_CACHE_DIR") {
        return Some(host_path(&dir, os));
    }
    if let Some(local) = shell_value(worktree, "LOCALAPPDATA") {
        return Some(host_path(&local, os).join("spiral-bin"));
    }
    let home = shell_value(worktree, "HOME").or_else(|| shell_value(worktree, "USERPROFILE"))?;
    Some(host_path(&home, os).join(".cache").join("spiral-bin"))
}

fn dotnet_command(worktree: &Worktree) -> String {
    if let Some(explicit) =
        shell_value(worktree, "SPIRAL_DOTNET").or_else(|| shell_value(worktree, "EOIE_DOTNET"))
    {
        return explicit;
    }
    let (_, name) = binary_names(zed::current_platform().0);
    if let Some(cache) = spiral_cache_dir(worktree) {
        let toolchain = cache.join("toolchains").join("dotnet").join(name);
        if let Some(path) = worktree.which(&toolchain.to_string_lossy()) {
            return path;
        }
    }
    worktree.which(name).unwrap_or_else(|| name.to_string())
}

fn compiler_env(worktree: &Worktree, dotnet: &str) -> Vec<(String, String)> {
    let mut env = vec![
        ("DOTNET_NOLOGO".to_string(), "1".to_string()),
        ("DOTNET_CLI_TELEMETRY_OPTOUT".to_string(), "1".to_string()),
    ];
    let dotnet = host_path(dotnet, zed::current_platform().0);
    if let Some(root) = dotnet.parent().filter(|root| !root.as_os_str().is_empty()) {
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
    shell_value(worktree, "SPIRAL_WORKSPACE_ROOT")
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

#[cfg(test)]
mod tests {
    use super::*;

    fn candidate_strings(root: &str, os: zed::Os) -> Vec<String> {
        helper_candidates(root, os)
            .iter()
            .map(|path| path.to_string_lossy().replace('\\', "/"))
            .collect()
    }

    #[test]
    fn binary_names_follow_host_os() {
        assert_eq!(binary_names(zed::Os::Windows), ("spiral-zed.exe", "dotnet.exe"));
        assert_eq!(binary_names(zed::Os::Linux), ("spiral-zed", "dotnet"));
        assert_eq!(binary_names(zed::Os::Mac), ("spiral-zed", "dotnet"));
    }

    #[test]
    fn windows_paths_are_normalized_before_wasi_path_operations() {
        let path = host_path(r"C:\home\git\eoie", zed::Os::Windows);
        // Assert the string itself, not Path equality (Windows accepts both separators).
        assert_eq!(path.to_str(), Some("C:/home/git/eoie"));
        assert_eq!(path.parent().unwrap().to_str(), Some("C:/home/git"));
        assert_eq!(
            candidate_strings(r"C:\home\git\eoie", zed::Os::Windows),
            candidate_strings("C:/home/git/eoie", zed::Os::Windows),
        );
    }

    #[test]
    fn windows_helper_candidates_include_sibling_spiral_checkout() {
        assert_eq!(
            candidate_strings(r"C:\home\git\eoie", zed::Os::Windows),
            vec![
                "C:/home/git/eoie/apps/zed/dist/spiral-zed.exe",
                "C:/home/git/eoie/spiral/apps/zed/dist/spiral-zed.exe",
                "C:/home/git/eoie/apps/zed/target/release/spiral-zed.exe",
                "C:/home/git/eoie/spiral/apps/zed/target/release/spiral-zed.exe",
                "C:/home/git/spiral/apps/zed/dist/spiral-zed.exe",
                "C:/home/git/apps/zed/dist/spiral-zed.exe",
            ],
        );
    }

    #[test]
    fn helper_candidates_support_checkout_and_parent_worktrees() {
        for os in [zed::Os::Windows, zed::Os::Linux, zed::Os::Mac] {
            let (name, _) = binary_names(os);
            let expected = format!("/home/git/spiral/apps/zed/dist/{name}");
            assert_eq!(candidate_strings("/home/git/spiral", os)[0], expected);
            assert_eq!(candidate_strings("/home/git", os)[1], expected);
            assert_eq!(candidate_strings("/home/git/spiral/apps", os)[5], expected);
        }
    }

    #[test]
    fn windows_unc_candidates_keep_the_share_prefix() {
        let root = r"\\server\share\git\eoie";
        assert_eq!(
            host_path(root, zed::Os::Windows).to_str(),
            Some("//server/share/git/eoie"),
        );
        assert_eq!(
            candidate_strings(root, zed::Os::Windows)[4],
            "//server/share/git/spiral/apps/zed/dist/spiral-zed.exe",
        );
    }

    #[test]
    fn windows_dotnet_parent_and_dll_extension_work_without_host_fs() {
        let dotnet = host_path(r"C:\Users\A B\spiral-bin\toolchains\dotnet\dotnet.exe", zed::Os::Windows);
        assert_eq!(
            dotnet.parent().unwrap().to_str(),
            Some("C:/Users/A B/spiral-bin/toolchains/dotnet"),
        );
        assert!(is_dll(&host_path(r"C:\compiler\SpiralCompiler.DLL", zed::Os::Windows)));
        assert!(!is_dll(&host_path(r"C:\compiler.dll\spiral-zed.exe", zed::Os::Windows)));
        assert_eq!(host_path("dotnet", zed::Os::Linux).parent(), Some(Path::new("")));
    }

    #[test]
    fn unix_paths_preserve_literal_backslashes() {
        for os in [zed::Os::Linux, zed::Os::Mac] {
            assert_eq!(host_path(r"/home/a\b/spiral", os).to_str(), Some(r"/home/a\b/spiral"));
        }
    }
}
