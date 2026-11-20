type US0_RawA = { readonly tag: 0, readonly f0: number };
type US0 = US0_RawA;
function US0_RawA(f0: number): US0 { return { tag: 0, f0: f0 }; }
type US1_DecidedA = { readonly tag: 1, readonly f0: number, readonly f1: boolean };
type US1 = US1_DecidedA;
function US1_DecidedA(f0: number, f1: boolean): US1 { return { tag: 1, f0: f0, f1: f1 }; }
type US2_RawB = { readonly tag: 1, readonly f0: number };
type US2 = US2_RawB;
function US2_RawB(f0: number): US2 { return { tag: 1, f0: f0 }; }
type US3_DecidedB = { readonly tag: 0, readonly f0: boolean, readonly f1: number };
type US3 = US3_DecidedB;
function US3_DecidedB(f0: boolean, f1: number): US3 { return { tag: 0, f0: f0, f1: f1 }; }
type US4_RawC = { readonly tag: 0, readonly f0: number };
type US4 = US4_RawC;
function US4_RawC(f0: number): US4 { return { tag: 0, f0: f0 }; }
type US5_DecidedC = { readonly tag: 1, readonly f0: number, readonly f1: boolean };
type US5 = US5_DecidedC;
function US5_DecidedC(f0: number, f1: boolean): US5 { return { tag: 1, f0: f0, f1: f1 }; }
type US6_FinalC = { readonly tag: 2, readonly f0: boolean };
type US6 = US6_FinalC;
function US6_FinalC(f0: boolean): US6 { return { tag: 2, f0: f0 }; }
function decide_a_0(v0: US0): US1 {
    switch (v0.tag) {
        case 0: {
            const v1: number = v0.f0;
            return US1_DecidedA(v1, true);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function decide_b_1(v0: US2): US3 {
    switch (v0.tag) {
        case 1: {
            const v1: number = v0.f0;
            return US3_DecidedB(true, v1);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function decide_c_2(v0: US4): US5 {
    switch (v0.tag) {
        case 0: {
            const v1: number = v0.f0;
            return US5_DecidedC(v1, true);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function finalize_c_3(v0: US5): US6 {
    switch (v0.tag) {
        case 1: {
            const v1: number = v0.f0;
            const v2: boolean = v0.f1;
            return US6_FinalC(v2);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: number = 7;
    const v1: US0 = US0_RawA(v0);
    const v2: US1 = decide_a_0(v1);
    const v3: number = 9;
    const v4: US2 = US2_RawB(v3);
    const v5: US3 = decide_b_1(v4);
    const v6: number = 11;
    const v7: US4 = US4_RawC(v6);
    const v8: US5 = decide_c_2(v7);
    const v9: US6 = finalize_c_3(v8);
    let v12: boolean;
    switch (v2.tag) {
        case 1: {
            const v10: number = v2.f0;
            const v11: boolean = v2.f1;
            v12 = v11;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v15: boolean;
    switch (v5.tag) {
        case 0: {
            const v13: boolean = v5.f0;
            const v14: number = v5.f1;
            v15 = v13;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v17: boolean;
    switch (v9.tag) {
        case 2: {
            const v16: boolean = v9.f0;
            v17 = v16;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v18: boolean = v12 && v15;
    const v19: boolean = v18 && v17;
    if (v19) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
