type US0_Some = { readonly tag: 0, readonly f0: number };
type US0_None = { readonly tag: 1 };
type US0 = US0_Some | US0_None;
function US0_Some(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_None(): US0 { return { tag: 1 }; }
export function main(): number {
    let v0: string = "ff";
    let v1: number = parseInt(v0, 16);
    process.stdout.write(String(v1) + "\n");
    let v2: string = "1011";
    let v3: number = parseInt(v2, 2);
    process.stdout.write(String(v3) + "\n");
    let v4: string = "-42";
    let v5: number = parseInt(v4, 10);
    process.stdout.write(String(v5) + "\n");
    let v6: string = " 123 ";
    let v7: boolean = /^\s*[+-]?\d+\s*$/.test(v6);
    let v8: bigint = (v7 ? BigInt(v6) : 0n);
    let v9: number = Number(BigInt.asIntN(32, v8));
    let v13: boolean;
    if (v7) {
        let v10: boolean = v8 >= (-2147483648n);
        if (v10) {
            let v11: boolean = v8 <= 2147483647n;
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
            let v18: string = "none";
            process.stdout.write(String(v18) + "\n");
            break;
        }
        case 0: {
            let v17: number = v16.f0;
            process.stdout.write(String(v17) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v19: string = "12x";
    let v20: boolean = /^\s*[+-]?\d+\s*$/.test(v19);
    let v21: bigint = (v20 ? BigInt(v19) : 0n);
    let v22: number = Number(BigInt.asIntN(32, v21));
    let v26: boolean;
    if (v20) {
        let v23: boolean = v21 >= (-2147483648n);
        if (v23) {
            let v24: boolean = v21 <= 2147483647n;
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
            let v31: string = "none";
            process.stdout.write(String(v31) + "\n");
            break;
        }
        case 0: {
            let v30: number = v29.f0;
            process.stdout.write(String(v30) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v32: string = "";
    let v33: boolean = /^\s*[+-]?\d+\s*$/.test(v32);
    let v34: bigint = (v33 ? BigInt(v32) : 0n);
    let v35: number = Number(BigInt.asIntN(32, v34));
    let v39: boolean;
    if (v33) {
        let v36: boolean = v34 >= (-2147483648n);
        if (v36) {
            let v37: boolean = v34 <= 2147483647n;
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
            let v44: string = "none";
            process.stdout.write(String(v44) + "\n");
            break;
        }
        case 0: {
            let v43: number = v42.f0;
            process.stdout.write(String(v43) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v45: string = "+7";
    let v46: boolean = /^\s*[+-]?\d+\s*$/.test(v45);
    let v47: bigint = (v46 ? BigInt(v45) : 0n);
    let v48: number = Number(BigInt.asIntN(32, v47));
    let v52: boolean;
    if (v46) {
        let v49: boolean = v47 >= (-2147483648n);
        if (v49) {
            let v50: boolean = v47 <= 2147483647n;
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
            let v57: string = "none";
            process.stdout.write(String(v57) + "\n");
            break;
        }
        case 0: {
            let v56: number = v55.f0;
            process.stdout.write(String(v56) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    return 0;
}
process.exitCode = main();
