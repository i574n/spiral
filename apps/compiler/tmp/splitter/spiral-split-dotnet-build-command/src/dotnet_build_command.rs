use std::path::{Path, PathBuf};
use std::process::Command;

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum DotnetBuildTarget {
    Gear { id: usize },
    Root,
}

impl DotnetBuildTarget {
    fn project(&self) -> PathBuf {
        match self {
            Self::Gear { id } => PathBuf::from(format!("Gear{id:04}.fsproj")),
            Self::Root => PathBuf::from("GearRoot.fsproj"),
        }
    }
}

#[derive(Clone, Debug)]
pub struct DotnetBuildSpec<'a> {
    pub dotnet: &'a Path,
    pub working_dir: &'a Path,
    pub configuration: &'a str,
    pub target: DotnetBuildTarget,
}

pub fn build_command(spec: &DotnetBuildSpec<'_>) -> Command {
    let mut command = Command::new(spec.dotnet);
    command
        .current_dir(spec.working_dir)
        .env("DOTNET_MULTILEVEL_LOOKUP", "0")
        .env("DOTNET_NOLOGO", "1")
        .env("DOTNET_CLI_TELEMETRY_OPTOUT", "1")
        .env("DOTNET_SKIP_FIRST_TIME_EXPERIENCE", "1")
        .env("DOTNET_CLI_USE_MSBUILD_SERVER", "0")
        .env("MSBUILDDISABLENODEREUSE", "1")
        .arg("build")
        .arg(spec.target.project())
        .arg("--no-restore")
        .arg("--no-dependencies")
        .arg("--disable-build-servers")
        .arg("-p:BuildProjectReferences=false")
        .arg("-c")
        .arg(spec.configuration)
        .arg("-m:1")
        .arg("-nr:false")
        .arg("-v:q");
    command
}

#[cfg(test)]
mod tests {
    use super::*;
    use std::ffi::OsStr;

    #[test]
    fn gear_target_isolated_and_node_reuse_disabled() {
        let command = build_command(&DotnetBuildSpec {
            dotnet: Path::new("dotnet"),
            working_dir: Path::new("out"),
            configuration: "Release",
            target: DotnetBuildTarget::Gear { id: 64 },
        });
        let args = command.get_args().collect::<Vec<_>>();
        assert!(args.contains(&OsStr::new("Gear0064.fsproj")));
        assert!(args.contains(&OsStr::new("-nr:false")));
        let env = command
            .get_envs()
            .map(|(key, value)| (key.to_owned(), value.map(ToOwned::to_owned)))
            .collect::<Vec<_>>();
        assert!(env.iter().any(|(key, value)| {
            key == OsStr::new("MSBUILDDISABLENODEREUSE")
                && value.as_deref() == Some(OsStr::new("1"))
        }));
    }

    #[test]
    fn root_target_uses_same_lifecycle_contract() {
        let command = build_command(&DotnetBuildSpec {
            dotnet: Path::new("dotnet"),
            working_dir: Path::new("out"),
            configuration: "Debug",
            target: DotnetBuildTarget::Root,
        });
        let args = command.get_args().collect::<Vec<_>>();
        assert!(args.contains(&OsStr::new("GearRoot.fsproj")));
        assert!(args.contains(&OsStr::new("--disable-build-servers")));
    }
}
