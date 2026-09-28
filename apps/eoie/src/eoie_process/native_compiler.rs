// OS command construction lives here; compiler authority and timeout policy live in process.spi.
fn native_spiral_host(path: &std::path::Path) -> bool {
    path.file_stem().and_then(|name| name.to_str()).is_some_and(|name| name.eq_ignore_ascii_case("SpiralCompiler"))
}

fn spiral_compiler_command(path: &std::path::Path) -> std::process::Command {
    let managed = path.extension().and_then(|value| value.to_str()).is_some_and(|value| value.eq_ignore_ascii_case("dll"));
    let mut command = if managed {
        let dotnet = std::env::var_os("EOIE_DOTNET").or_else(|| std::env::var_os("SPIRAL_DOTNET")).unwrap_or_else(|| "dotnet".into());
        let mut command = std::process::Command::new(dotnet);
        command.arg(path);
        command
    } else {
        std::process::Command::new(path)
    };
    if let Some(root) = std::env::var_os("EOIE_SPIRAL_BUNDLE") {
        command.env("SPIRAL_WORKSPACE_ROOT", root);
    }
    command
}

#[cfg(test)]
mod native_compiler_tests {
    use super::*;
    #[test]
    fn native_host_supports_attestation_commands() {
        for name in ["SpiralCompiler.dll", "SpiralCompiler.exe", "SpiralCompiler"] {
            let path = std::path::Path::new(name);
            assert!(native_spiral_host(path));
        }
        assert!(!native_spiral_host(std::path::Path::new("spiral-compile")));
        let command = spiral_compiler_command(std::path::Path::new("SpiralCompiler.dll"));
        assert_eq!(command.get_args().next().unwrap(), "SpiralCompiler.dll");
    }
}
