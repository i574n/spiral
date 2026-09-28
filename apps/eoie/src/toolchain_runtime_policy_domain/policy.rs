#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v1 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = 0i32 < v1;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v0 < 0i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = 5i32 < v0;
                if v5 {
                    -1i32
                } else {
                    let mut v6: bool = v0 == 1i32;
                    if v6 {
                        1i32
                    } else {
                        0i32
                    }
                }
            }
        }
    }
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    -1i32
                } else {
                    let mut v6: bool = v0 == 1i32;
                    if v6 {
                        3i32
                    } else {
                        let mut v7: bool = v1 == 1i32;
                        if v7 {
                            1i32
                        } else {
                            2i32
                        }
                    }
                }
            }
        }
    }
}
fn method2(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from("v1");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        let mut v3: Rc<str> = Rc::<str>::from("action-name:0=cargo-lock\naction-name:1=cargo-fmt-check\naction-name:2=cargo-check\naction-name:3=cargo-test\naction-name:4=cargo-clippy\naction-name:5=cargo-build\naction-name:6=cargo-version\naction-name:7=spiral-version\naction-ctor:0=CargoLockProcess\naction-ctor:1=CargoFmtCheckProcess\naction-ctor:2=CargoCheckProcess\naction-ctor:3=CargoTestProcess\naction-ctor:4=CargoClippyProcess\naction-ctor:5=CargoBuildProcess\naction-ctor:6=CargoVersionProcess\naction-ctor:7=SpiralVersionProcess\ncheckpoint:0=ToolchainNotStarted\ncheckpoint:1=ToolchainSpawnCommitted\ncheckpoint:2=ToolchainRunCommitted\ncheckpoint:3=ToolchainLinkCommitted\ncheckpoint:4=ToolchainTimeoutCommitted\ncheckpoint:5=ToolchainCompletionCommitted\noutcome:0=ToolchainPending\noutcome:1=ToolchainPassed\noutcome:2=ToolchainFailed\noutcome:3=ToolchainTimedOut\noutcome-payload:0=none\noutcome-payload:1=status\noutcome-payload:2=status\noutcome-payload:3=elapsed\nprofile:0=CargoUtilityProcess\nprofile:1=CargoCheckProcessProfile\nprofile:2=CargoTestProcessProfile\nprofile:3=CargoClippyProcessProfile\nprofile:4=CargoReleaseProcessProfile\nprofile:5=SpiralUtilityProcess\nprogram:0=self\nprogram:1=cargo-fmt\nprogram:2=cargo-clippy\nenv-key:0=RUST_LOG\nenv-key:1=CARGO\nenv-key:2=CARGO_TERM_COLOR\nenv-key:3=RUSTC\nenv-key:4=RUSTDOC\nenv-key:5=EOIE_SPIRAL_COMPILE\nenv-key:6=SPIRAL_DOTNET\nenv-key:7=DOTNET_ROOT\nenv-key:8=CARGO_TARGET_DIR\nenv-mode:0=remove\nenv-mode:1=tool\nenv-mode:2=never\nenv-mode:3=sibling-rustc\nenv-mode:4=sibling-rustdoc\nenv-mode:5=require-current\nenv-mode:6=inherit-current\nreceipt-marker=// toolchain-process-receipt|\nreceipt-path=state/toolchain_process_receipt.spi\nbundle-state-marker=state/package.spiproj\nreceipt-stage-prefix=.toolchain-receipt-\nidentity-exclude-dirs=target,vendor,.git\nidentity-file-names=Cargo.toml,Cargo.lock,package.spiproj\nidentity-exts=rs,spi,spir,toml,spiproj\nidentity-root-marker=Cargo.toml\nidentity-root-fallback=src\nidentity-hash-files=Cargo.toml,Cargo.lock,.cargo/config.toml\nidentity-target-fallback=target\n");
        v3.clone()
    } else {
        let mut v4: Rc<str> = Rc::<str>::from("");
        v4.clone()
    }
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method0(v0, v1)
    })
}
fn closure1() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method1(v0, v1)
    })
}
fn closure2() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method2(v0.clone())
    })
}
pub fn eoie_toolchain_execution_gate(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_toolchain_observed_outcome(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_toolchain_receipt_catalog(v0: &str) -> Rc<str> {
    closure2()(Rc::<str>::from(v0))
}
