export function main(): number {
    let v0: number = 0;
    let v1: number = 1;
    let v2: number = 0;
    let v3: number = 1;
    let v4: number = Math.fround(Math.log(v1));
    let v5: boolean = v4 === v0;
    let v8: boolean;
    if (v5) {
        let v6: number = Math.log(v3);
        let v7: boolean = v6 === v2;
        v8 = v7;
    } else {
        v8 = false;
    }
    let v11: boolean;
    if (v8) {
        let v9: number = Math.fround(Math.exp(v0));
        let v10: boolean = v9 === v1;
        v11 = v10;
    } else {
        v11 = false;
    }
    let v14: boolean;
    if (v11) {
        let v12: number = Math.exp(v2);
        let v13: boolean = v12 === v3;
        v14 = v13;
    } else {
        v14 = false;
    }
    let v17: boolean;
    if (v14) {
        let v15: number = Math.fround(Math.tanh(v0));
        let v16: boolean = v15 === v0;
        v17 = v16;
    } else {
        v17 = false;
    }
    let v20: boolean;
    if (v17) {
        let v18: number = Math.tanh(v2);
        let v19: boolean = v18 === v2;
        v20 = v19;
    } else {
        v20 = false;
    }
    let v23: boolean;
    if (v20) {
        let v21: number = Math.fround(Math.sin(v0));
        let v22: boolean = v21 === v0;
        v23 = v22;
    } else {
        v23 = false;
    }
    let v26: boolean;
    if (v23) {
        let v24: number = Math.sin(v2);
        let v25: boolean = v24 === v2;
        v26 = v25;
    } else {
        v26 = false;
    }
    let v29: boolean;
    if (v26) {
        let v27: number = Math.fround(Math.cos(v0));
        let v28: boolean = v27 === v1;
        v29 = v28;
    } else {
        v29 = false;
    }
    let v32: boolean;
    if (v29) {
        let v30: number = Math.cos(v2);
        let v31: boolean = v30 === v3;
        v32 = v31;
    } else {
        v32 = false;
    }
    if (v32) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
