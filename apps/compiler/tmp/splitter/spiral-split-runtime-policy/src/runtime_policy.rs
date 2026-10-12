use rayon::ThreadPoolBuilder;

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum ParallelRuntimePolicy {
    GlobalRayon { threads: usize },
    LocalOnly,
}

impl ParallelRuntimePolicy {
    pub fn for_command(command: &str, threads: usize) -> Self {
        match command {
            "gear-build" => Self::LocalOnly,
            _ => Self::GlobalRayon {
                threads: threads.clamp(1, 256),
            },
        }
    }

    pub fn configure(self) -> Result<(), String> {
        match self {
            Self::LocalOnly => Ok(()),
            Self::GlobalRayon { threads } => ThreadPoolBuilder::new()
                .num_threads(threads)
                .thread_name(|index| format!("spiral-split-{index:02}"))
                .build_global()
                .map_err(|error| format!("configure Rayon: {error}")),
        }
    }
}

pub fn configure_parallel_runtime(command: &str, threads: usize) -> Result<(), String> {
    ParallelRuntimePolicy::for_command(command, threads).configure()
}

pub fn bounded_process_jobs(requested: usize) -> usize {
    requested.clamp(1, 4)
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn gear_build_keeps_process_parent_free_of_global_rayon_workers() {
        assert_eq!(
            ParallelRuntimePolicy::for_command("gear-build", 56),
            ParallelRuntimePolicy::LocalOnly
        );
    }

    #[test]
    fn generation_commands_keep_parallel_rayon_runtime() {
        assert_eq!(
            ParallelRuntimePolicy::for_command("gears", 56),
            ParallelRuntimePolicy::GlobalRayon { threads: 56 }
        );
    }

    #[test]
    fn global_runtime_clamps_thread_count() {
        assert_eq!(
            ParallelRuntimePolicy::for_command("bench", 0),
            ParallelRuntimePolicy::GlobalRayon { threads: 1 }
        );
    }

    #[test]
    fn dotnet_process_jobs_are_bounded_independently_of_rayon_threads() {
        assert_eq!(bounded_process_jobs(56), 4);
        assert_eq!(bounded_process_jobs(4), 4);
        assert_eq!(bounded_process_jobs(0), 1);
    }
}
