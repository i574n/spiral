#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("-h|--help");
    let mut v2: bool = v1.split("|").any(|item| item == &*v0);
    if v2 {
        5u64
    } else {
        let mut v3: Rc<str> = Rc::<str>::from("status|patch|agile|bundle|proxy|help");
        let mut v4: u64 = v3.split("|").position(|item| item == &*v0).map(|index| index as u64).unwrap_or(u64::MAX);
        v4
    }
}
fn method1(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("patch|agile|proxy");
    let mut v2: bool = v1.split("|").any(|item| item == &*v0);
    if v2 {
        2u64
    } else {
        let mut v3: Rc<str> = Rc::<str>::from("bundle");
        let mut v4: bool = v0 == v3 ;
        if v4 {
            1u64
        } else {
            0u64
        }
    }
}
fn method2(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("patch:check|agile:list|agile:check|agile:lease|agile:status|proxy:plan-ir-inspect|proxy:plan-ir-check|proxy:legacy-surface|proxy:self-upgrade-check|proxy:fs-list|proxy:fs-read|proxy:fs-slice|proxy:fs-context|proxy:fs-search|proxy:parallel-search|proxy:parallel-manifest|proxy:product-diff|proxy:hash|proxy:hash-tree|proxy:source-stats|proxy:ingest-map|proxy:ingest-trim-check|proxy:ingest-extracted-manifest|proxy:ingest-targets|proxy:ingest-targets-derive|proxy:frontier-map|proxy:spi-map|proxy:spi-diff|proxy:source-recovery-diff|proxy:coverage-assess");
    let mut v2: bool = v1.split("|").any(|item| item == &*v0);
    if v2 {
        0u64
    } else {
        let mut v3: Rc<str> = Rc::<str>::from("agile:record|proxy:release-closeout|proxy:spiral-session-shutdown");
        let mut v4: bool = v3.split("|").any(|item| item == &*v0);
        if v4 {
            1u64
        } else {
            let mut v5: Rc<str> = Rc::<str>::from("agile:begin");
            let mut v6: bool = v0 == v5 ;
            if v6 {
                3u64
            } else {
                let mut v7: Rc<str> = Rc::<str>::from("bundle:retention-apply");
                let mut v8: bool = v0 == v7 ;
                if v8 {
                    2u64
                } else {
                    4u64
                }
            }
        }
    }
}
fn method3(mut v0: Rc<str>) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
    let mut v1: Rc<str> = Rc::<str>::from("0|1|2|3|4|5");
    let mut v2: Rc<str> = Rc::<str>::from("status\npatch\nagile\nbundle\nproxy\nhelp");
    let mut v3: Rc<str> = v1.split("|").zip(v2.split(char::from(10u8))).find_map(|(key,item)| if key == &*v0 { Some(std::rc::Rc::<str>::from(item)) } else { None }).unwrap_or_else(|| std::rc::Rc::<str>::from(""));
    let mut v4: Rc<str> = Rc::<str>::from("");
    let mut v5: bool = v3 == v4 ;
    if v5 {
        let mut v6: Rc<str> = Rc::<str>::from("unknown");
        let mut v7: Rc<str> = Rc::<str>::from("inspect");
        let mut v8: Rc<str> = Rc::<str>::from("unknown public verb");
        (v6.clone(), v7.clone(), v6.clone(), v8.clone(), v6.clone())
    } else {
        let mut v9: Rc<str> = Rc::<str>::from("inspect\nmutate\nmutate\nwrap\nmutate\ninspect");
        let mut v10: Rc<str> = v1.split("|").zip(v9.split(char::from(10u8))).find_map(|(key,item)| if key == &*v0 { Some(std::rc::Rc::<str>::from(item)) } else { None }).unwrap_or_else(|| std::rc::Rc::<str>::from(""));
        let mut v11: Rc<str> = Rc::<str>::from("status [root]\npatch: apply <root> <plan.spi> [--compiler <absolute>] | check <root> <plan.spi> | rehearse <root> <plan.spi> | gated <root> <plan.spi> <gate-program>\nagile: begin <root> <title> | lease <root> | status <root> | handoff <root> | list <root> | check <root> [--compiler <absolute>] | record <root> | set <root> <id> <progress> <Planned|Active|Blocked|Paused|Done>\nbundle: growth-baseline <predecessor.zip> <previous-root> <root> | growth-receipt <root> <reason> <reference> | check <root> [auto|generic|eoie] | create <root> <output.zip> [auto|generic|eoie] | create-flat <root> <output.zip> <max-bytes> | verify <archive.zip> [auto|generic|eoie] | verify-flat <archive.zip> <max-bytes> | rehydrate <archive.zip> <destination> [auto|generic|eoie] | retention-plan <directory> <current.zip> <receipt.spi> | retention-apply <directory> <current.zip> <receipt.spi> <fingerprint>\nproxy: plan-ir-inspect|plan-ir-check|legacy-surface|install-self|self-upgrade-check|restart-baton|fs-chmod|fs-symlink|fs-copy-tree|command-capture|command-capture-env|command-capture-matrix|command-capture-matrix-gate|batch-plan|batch-plan-resume|fs-list|fs-read|fs-slice|fs-context|fs-search|parallel-search|parallel-manifest|product-diff|fs-write|text-replace|fs-copy|fs-remove|fs-remove-tree|run|spiral-session-shutdown|archive-extract|zip-extract|hash|hash-tree|prune-build-cache|prune-compiler-sidecars|incident-recovery|external-payload|differential-compare|coverage-assess|coverage-export|coverage-union|coverage-run|toolchain|portable-toolchain|source-stats|source-topology|ingest-map|ingest-trim-check|ingest-extracted-manifest|ingest-targets|ingest-targets-derive|frontier-map|spi-map|spi-diff|source-recovery-diff|source-author|fs-batch-write|fs-actions|binary-install|release-closeout|shim|prune-uncovered ...\nhelp [verb|--completion|--json|--schema] | proxy <capability>");
        let mut v12: Rc<str> = v1.split("|").zip(v11.split(char::from(10u8))).find_map(|(key,item)| if key == &*v0 { Some(std::rc::Rc::<str>::from(item)) } else { None }).unwrap_or_else(|| std::rc::Rc::<str>::from(""));
        let mut v13: Rc<str> = Rc::<str>::from("inspect migration evidence toolchain and authority state\nrehearse gate and apply typed patch plans\nmanage typed backlog leases and turn receipts\ncheck create verify rehydrate and retain bundles\nexecute bounded filesystem process archive toolchain and evidence capabilities\nrender the public command catalog");
        let mut v14: Rc<str> = v1.split("|").zip(v13.split(char::from(10u8))).find_map(|(key,item)| if key == &*v0 { Some(std::rc::Rc::<str>::from(item)) } else { None }).unwrap_or_else(|| std::rc::Rc::<str>::from(""));
        (v3.clone(), v10.clone(), v12.clone(), v14.clone(), v3.clone())
    }
}
fn method4(mut v0: Rc<str>) -> Rc<str> {
    let (mut v1, mut v2, mut v3, mut v4, mut v5): (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) = method3(v0.clone());
    let mut v6: Rc<str> = Rc::<str>::from("{\"name\":\"");
    let mut v7: Rc<str> = Rc::<str>::from("\",\"effect\":\"");
    let mut v8: Rc<str> = Rc::<str>::from("\"");
    let mut v9: Rc<str> = std::rc::Rc::<str>::from([&*v6, &*v1, &*v7, &*v2, &*v8].concat());
    let mut v10: Rc<str> = Rc::<str>::from(",\"handler\":\"");
    let mut v11: Rc<str> = Rc::<str>::from("\",\"summary\":\"");
    let mut v12: Rc<str> = std::rc::Rc::<str>::from([&*v10, &*v5, &*v11, &*v4, &*v8].concat());
    let mut v13: Rc<str> = Rc::<str>::from(",\"usage\":\"");
    let mut v14: Rc<str> = Rc::<str>::from("\"}");
    let mut v15: Rc<str> = Rc::<str>::from("");
    let mut v16: Rc<str> = std::rc::Rc::<str>::from([&*v13, &*v3, &*v14, &*v15, &*v15].concat());
    let mut v17: Rc<str> = std::rc::Rc::<str>::from([&*v9, &*v12, &*v16, &*v15, &*v15].concat());
    v17.clone()
}
fn method5() -> i32 {
    6i32
}
fn method6() -> i32 {
    let mut v0: i32 = method5();
    let mut v1: bool = 6i32 == v0;
    if v1 {
        1i32
    } else {
        0i32
    }
}
fn method7(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("cargo-lock|cargo-fmt-check|cargo-check|cargo-test|cargo-clippy|cargo-build|cargo-version|spiral-version");
    let mut v2: u64 = v1.split("|").position(|item| item == &*v0).map(|index| index as u64).unwrap_or(u64::MAX);
    v2
}
fn method8(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from("plan-ir-inspect|plan-ir-check|install-self|self-upgrade-check|fs-chmod|fs-symlink|fs-copy-tree|command-capture|command-capture-env|fs-list|fs-read|fs-context|fs-search|parallel-search|hash|hash-tree|fs-write|text-replace|fs-remove|fs-remove-tree|run|archive-extract|zip-extract|toolchain|portable-toolchain");
    let mut v2: Rc<str> = Rc::<str>::from("proxy plan-ir-inspect <index>\nproxy plan-ir-check\nproxy install-self <source-binary> <installed-binary> <canonical-link>\nproxy self-upgrade-check <current-root> <candidate-root>\nproxy fs-chmod <root> <relative-path> <octal-mode>\nproxy fs-symlink <root> <target-relative> <link-relative>\nproxy fs-copy-tree <source> <destination>\nproxy command-capture <root> <receipt-relative> <timeout-ms> <program> [args...]\nproxy command-capture-env <root> <receipt-relative> <timeout-ms> <cwd-relative> <env-cell> <program> [args...]\nproxy fs-list <absolute-directory>\nproxy fs-read <root> <relative>\nproxy fs-context <root> <relative> <needle> <radius-bytes>\nproxy fs-search <root> <relative> <needle>\nproxy parallel-search <root> <relative> <needle> <max-hits>\nproxy hash <root> <relative>\nproxy hash-tree <root> <relative>\nproxy fs-write <root> <relative> [--replace-existing] [--expect-hash <sha256>] [--expect-nonempty] [--] <text>\nproxy text-replace <check|apply> <root> <relative> <old> <new>\nproxy fs-remove <root> <relative>\nproxy fs-remove-tree <root> <relative> [--missing-ok]\nproxy run --cwd <directory> --program <program> [--timeout-ms <ms>] [--env KEY=VALUE]... [--unset KEY]... [-- <args...>]\nproxy archive-extract <archive> <destination>\nproxy zip-extract <archive> <destination>\nproxy toolchain <root> <action> ...\nproxy portable-toolchain <root> ...");
    let mut v3: Rc<str> = v1.split("|").zip(v2.split(char::from(10u8))).find_map(|(key,item)| if key == &*v0 { Some(std::rc::Rc::<str>::from(item)) } else { None }).unwrap_or_else(|| std::rc::Rc::<str>::from(""));
    v3.clone()
}
fn method9(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("plan-ir-inspect|plan-ir-check|prune-compiler-sidecars|incident-recovery|external-payload|coverage-export|coverage-union|legacy-surface|install-self|self-upgrade-check|restart-baton|source-author|fs-batch-write|fs-actions|binary-install|release-closeout|shim|fs-chmod|fs-symlink|fs-copy-tree|command-capture|command-capture-env|command-capture-matrix|command-capture-matrix-gate|batch-plan|batch-plan-resume|portable-toolchain|product-diff|source-recovery-diff");
    let mut v2: bool = v1.split("|").any(|item| item == &*v0);
    if v2 {
        let mut v3: u64 = v1.split("|").position(|item| item == &*v0).map(|index| index as u64).unwrap_or(u64::MAX);
        v3
    } else {
        let mut v4: Rc<str> = Rc::<str>::from("fs-slice|fs-context|fs-search|parallel-search|parallel-manifest|hash|hash-tree|fs-copy");
        let mut v5: bool = v4.split("|").any(|item| item == &*v0);
        if v5 {
            29u64
        } else {
            let mut v6: Rc<str> = Rc::<str>::from("archive-extract");
            let mut v7: bool = v0 == v6 ;
            if v7 {
                30u64
            } else {
                let mut v8: Rc<str> = Rc::<str>::from("zip-extract");
                let mut v9: bool = v0 == v8 ;
                if v9 {
                    31u64
                } else {
                    32u64
                }
            }
        }
    }
}
fn method10() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("plan-ir-inspect");
    let mut v1: u64 = method9(v0.clone());
    let mut v2: Rc<str> = Rc::<str>::from("source-recovery-diff");
    let mut v3: u64 = method9(v2.clone());
    let mut v4: Rc<str> = Rc::<str>::from("hash-tree");
    let mut v5: u64 = method9(v4.clone());
    let mut v6: Rc<str> = Rc::<str>::from("archive-extract");
    let mut v7: u64 = method9(v6.clone());
    let mut v8: Rc<str> = Rc::<str>::from("zip-extract");
    let mut v9: u64 = method9(v8.clone());
    let mut v10: Rc<str> = Rc::<str>::from("fs-write");
    let mut v11: u64 = method9(v10.clone());
    let mut v12: bool = 0u64 == v1;
    if v12 {
        let mut v13: bool = 28u64 == v3;
        if v13 {
            let mut v14: bool = 29u64 == v5;
            if v14 {
                let mut v15: bool = 30u64 == v7;
                if v15 {
                    let mut v16: bool = 31u64 == v9;
                    if v16 {
                        let mut v17: bool = 32u64 == v11;
                        if v17 {
                            1i32
                        } else {
                            0i32
                        }
                    } else {
                        0i32
                    }
                } else {
                    0i32
                }
            } else {
                0i32
            }
        } else {
            0i32
        }
    } else {
        0i32
    }
}
fn method11(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("--completion");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        0u64
    } else {
        let mut v3: Rc<str> = Rc::<str>::from("--json");
        let mut v4: bool = v0 == v3 ;
        if v4 {
            1u64
        } else {
            let mut v5: Rc<str> = Rc::<str>::from("--schema");
            let mut v6: bool = v0 == v5 ;
            if v6 {
                2u64
            } else {
                3u64
            }
        }
    }
}
fn method12() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("--completion");
    let mut v1: u64 = method11(v0.clone());
    let mut v2: Rc<str> = Rc::<str>::from("--json");
    let mut v3: u64 = method11(v2.clone());
    let mut v4: Rc<str> = Rc::<str>::from("--schema");
    let mut v5: u64 = method11(v4.clone());
    let mut v6: Rc<str> = Rc::<str>::from("status");
    let mut v7: u64 = method11(v6.clone());
    let mut v8: bool = 0u64 == v1;
    if v8 {
        let mut v9: bool = 1u64 == v3;
        if v9 {
            let mut v10: bool = 2u64 == v5;
            if v10 {
                let mut v11: bool = 3u64 == v7;
                if v11 {
                    1i32
                } else {
                    0i32
                }
            } else {
                0i32
            }
        } else {
            0i32
        }
    } else {
        0i32
    }
}
fn closure0() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method0(v0.clone())
    })
}
fn closure1() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method1(v0.clone())
    })
}
fn closure2() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method2(v0.clone())
    })
}
fn closure3() -> Rc<dyn Fn(Rc<str>) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>)> {
    Rc::new(move |mut v0: Rc<str>| -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
        method3(v0.clone())
    })
}
fn closure4() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method4(v0.clone())
    })
}
fn closure5() -> Rc<dyn Fn() -> i32> {
    Rc::new(move || -> i32 {
        method5()
    })
}
fn closure6() -> Rc<dyn Fn() -> i32> {
    Rc::new(move || -> i32 {
        method6()
    })
}
fn closure7() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method7(v0.clone())
    })
}
fn closure8() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method8(v0.clone())
    })
}
fn closure9() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method9(v0.clone())
    })
}
fn closure10() -> Rc<dyn Fn() -> i32> {
    Rc::new(move || -> i32 {
        method10()
    })
}
fn closure11() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method11(v0.clone())
    })
}
fn closure12() -> Rc<dyn Fn() -> i32> {
    Rc::new(move || -> i32 {
        method12()
    })
}
pub fn eoie_command_code(v0: &str) -> u64 {
    closure0()(Rc::<str>::from(v0))
}
pub fn eoie_command_effect_code(v0: &str) -> u64 {
    closure1()(Rc::<str>::from(v0))
}
pub fn eoie_command_subcommand_effect_code(v0: &str) -> u64 {
    closure2()(Rc::<str>::from(v0))
}
pub fn eoie_command_descriptor(v0: &str) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
    closure3()(Rc::<str>::from(v0))
}
pub fn eoie_command_descriptor_json(v0: &str) -> Rc<str> {
    closure4()(Rc::<str>::from(v0))
}
pub fn eoie_command_count() -> i32 {
    closure5()()
}
pub fn eoie_command_schema_witness() -> i32 {
    closure6()()
}
pub fn eoie_toolchain_action_name_code(v0: &str) -> u64 {
    closure7()(Rc::<str>::from(v0))
}
pub fn eoie_command_proxy_usage(v0: &str) -> Rc<str> {
    closure8()(Rc::<str>::from(v0))
}
pub fn eoie_proxy_route_code(v0: &str) -> u64 {
    closure9()(Rc::<str>::from(v0))
}
pub fn eoie_proxy_route_witness() -> i32 {
    closure10()()
}
pub fn eoie_help_flag_code(v0: &str) -> u64 {
    closure11()(Rc::<str>::from(v0))
}
pub fn eoie_help_flag_witness() -> i32 {
    closure12()()
}
