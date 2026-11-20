type US0_Some = { readonly tag: 0, readonly f0: number };
type US0_None = { readonly tag: 1 };
type US0 = US0_Some | US0_None;
function US0_Some(f0: number): US0 { return { tag: 0, f0: f0 }; }
const US0_None_shared: US0 = { tag: 1 }; function US0_None(): US0 { return US0_None_shared; }
export function main(): number {
    const v0: string = "ff";
    const v1: number = parseInt(v0, 16);
    process.stdout.write(String(v1) + "\n");
    const v2: string = "1011";
    const v3: number = parseInt(v2, 2);
    process.stdout.write(String(v3) + "\n");
    const v4: string = "-42";
    const v5: number = parseInt(v4, 10);
    process.stdout.write(String(v5) + "\n");
    const v6: string = " 123 ";
    const v7: boolean = /^\s*[+-]?\d+\s*$/.test(v6);
    const v8: bigint = (v7 ? BigInt(v6) : 0n);
    const v9: number = Number(BigInt.asIntN(32, v8));
    let v13: boolean;
    if (v7) {
        const v10: boolean = v8 >= (-2147483648n);
        if (v10) {
            const v11: boolean = v8 <= 2147483647n;
            v13 = v11;
        } else {
            v13 = false;
        }
    } else {
        v13 = false;
    }
    let v16: US0;
    if (v13) {
        v16 = US0_Some(v9);
    } else {
        v16 = US0_None();
    }
    switch (v16.tag) {
        case 1: {
            const v18: string = "none";
            process.stdout.write(String(v18) + "\n");
            break;
        }
        case 0: {
            const v17: number = v16.f0;
            process.stdout.write(String(v17) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v19: string = "12x";
    const v20: boolean = /^\s*[+-]?\d+\s*$/.test(v19);
    const v21: bigint = (v20 ? BigInt(v19) : 0n);
    const v22: number = Number(BigInt.asIntN(32, v21));
    let v26: boolean;
    if (v20) {
        const v23: boolean = v21 >= (-2147483648n);
        if (v23) {
            const v24: boolean = v21 <= 2147483647n;
            v26 = v24;
        } else {
            v26 = false;
        }
    } else {
        v26 = false;
    }
    let v29: US0;
    if (v26) {
        v29 = US0_Some(v22);
    } else {
        v29 = US0_None();
    }
    switch (v29.tag) {
        case 1: {
            const v31: string = "none";
            process.stdout.write(String(v31) + "\n");
            break;
        }
        case 0: {
            const v30: number = v29.f0;
            process.stdout.write(String(v30) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v32: string = "";
    const v33: boolean = /^\s*[+-]?\d+\s*$/.test(v32);
    const v34: bigint = (v33 ? BigInt(v32) : 0n);
    const v35: number = Number(BigInt.asIntN(32, v34));
    let v39: boolean;
    if (v33) {
        const v36: boolean = v34 >= (-2147483648n);
        if (v36) {
            const v37: boolean = v34 <= 2147483647n;
            v39 = v37;
        } else {
            v39 = false;
        }
    } else {
        v39 = false;
    }
    let v42: US0;
    if (v39) {
        v42 = US0_Some(v35);
    } else {
        v42 = US0_None();
    }
    switch (v42.tag) {
        case 1: {
            const v44: string = "none";
            process.stdout.write(String(v44) + "\n");
            break;
        }
        case 0: {
            const v43: number = v42.f0;
            process.stdout.write(String(v43) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v45: string = "+7";
    const v46: boolean = /^\s*[+-]?\d+\s*$/.test(v45);
    const v47: bigint = (v46 ? BigInt(v45) : 0n);
    const v48: number = Number(BigInt.asIntN(32, v47));
    let v52: boolean;
    if (v46) {
        const v49: boolean = v47 >= (-2147483648n);
        if (v49) {
            const v50: boolean = v47 <= 2147483647n;
            v52 = v50;
        } else {
            v52 = false;
        }
    } else {
        v52 = false;
    }
    let v55: US0;
    if (v52) {
        v55 = US0_Some(v48);
    } else {
        v55 = US0_None();
    }
    switch (v55.tag) {
        case 1: {
            const v57: string = "none";
            process.stdout.write(String(v57) + "\n");
            break;
        }
        case 0: {
            const v56: number = v55.f0;
            process.stdout.write(String(v56) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    return 0;
}
process.exitCode = main();
