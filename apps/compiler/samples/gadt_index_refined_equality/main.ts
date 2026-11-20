type US0_Vowel = { readonly tag: 1, readonly f0: number };
type US0 = US0_Vowel;
function US0_Vowel(f0: number): US0 { return { tag: 1, f0: f0 }; }
type UH0_Nil = { readonly tag: 0 };
type UH0_Cons = { readonly tag: 1, readonly f0: US0, readonly f1: UH0 };
type UH0 = UH0_Nil | UH0_Cons;
const UH0_Nil_shared: UH0 = { tag: 0 }; function UH0_Nil(): UH0 { return UH0_Nil_shared; }
function UH0_Cons(f0: US0, f1: UH0): UH0 { return { tag: 1, f0: f0, f1: f1 }; }
function method0(v0: UH0, v1: UH0): boolean {
    tail: while (true) {
        switch (v1.tag === v0.tag ? v1.tag : -1) {
            case 1: {
                const v2: US0 = (v1 as UH0_Cons).f0;
                const v3: UH0 = (v1 as UH0_Cons).f1;
                const v4: US0 = (v0 as UH0_Cons).f0;
                const v5: UH0 = (v0 as UH0_Cons).f1;
                let v9: boolean;
                switch (v2.tag === v4.tag ? v2.tag : -1) {
                    case 1: {
                        const v6: number = (v2 as US0_Vowel).f0;
                        const v7: number = (v4 as US0_Vowel).f0;
                        const v8: boolean = v6 === v7;
                        v9 = v8;
                        break;
                    }
                    default: {
                        v9 = false;
                    }
                }
                if (v9) {
                    v0 = v5;
                    v1 = v3;
                    continue tail;
                } else {
                    return false;
                }
                break;
            }
            case 0: {
                return true;
            }
            default: {
                return false;
            }
        }
    }
}
export function main(): number {
    let v0: number = 1;
    let v1: US0 = US0_Vowel(v0);
    const v2: number = 1;
    const v3: US0 = US0_Vowel(v2);
    const v4: number = 2;
    const v5: US0 = US0_Vowel(v4);
    const v6: UH0 = UH0_Nil();
    const v7: UH0 = UH0_Cons(v5, v6);
    const v8: UH0 = UH0_Cons(v1, v7);
    let v9: UH0 = UH0_Nil();
    const v10: UH0 = UH0_Cons(v5, v9);
    const v11: UH0 = UH0_Cons(v3, v10);
    const v12: UH0 = UH0_Nil();
    const v13: UH0 = UH0_Cons(v1, v12);
    let v17: boolean;
    switch (v1.tag === v3.tag ? v1.tag : -1) {
        case 1: {
            const v14: number = (v1 as US0_Vowel).f0;
            const v15: number = (v3 as US0_Vowel).f0;
            const v16: boolean = v14 === v15;
            v17 = v16;
            break;
        }
        default: {
            v17 = false;
        }
    }
    let v23: boolean;
    if (v17) {
        let v21: boolean;
        switch (v1.tag === v5.tag ? v1.tag : -1) {
            case 1: {
                const v18: number = (v1 as US0_Vowel).f0;
                const v19: number = (v5 as US0_Vowel).f0;
                const v20: boolean = v18 === v19;
                v21 = v20;
                break;
            }
            default: {
                v21 = false;
            }
        }
        const v22: boolean = v21 === false;
        v23 = v22;
    } else {
        v23 = false;
    }
    let v30: boolean;
    if (v23) {
        let v27: boolean;
        switch (v1.tag === v3.tag ? v1.tag : -1) {
            case 1: {
                const v24: number = (v1 as US0_Vowel).f0;
                const v25: number = (v3 as US0_Vowel).f0;
                const v26: boolean = v24 === v25;
                v27 = v26;
                break;
            }
            default: {
                v27 = false;
            }
        }
        if (v27) {
            v30 = method0(v11, v8);
        } else {
            v30 = false;
        }
    } else {
        v30 = false;
    }
    let v38: boolean;
    if (v30) {
        let v34: boolean;
        switch (v1.tag === v5.tag ? v1.tag : -1) {
            case 1: {
                const v31: number = (v1 as US0_Vowel).f0;
                const v32: number = (v5 as US0_Vowel).f0;
                const v33: boolean = v31 === v32;
                v34 = v33;
                break;
            }
            default: {
                v34 = false;
            }
        }
        let v36: boolean;
        if (v34) {
            v36 = method0(v13, v8);
        } else {
            v36 = false;
        }
        const v37: boolean = v36 === false;
        v38 = v37;
    } else {
        v38 = false;
    }
    if (v38) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
