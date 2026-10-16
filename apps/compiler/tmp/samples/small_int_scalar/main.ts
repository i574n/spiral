export function main(): number {
    let v0: number = 100;
    let v1: number = (v0 + v0) << 24 >> 24;
    let v2: number = 200;
    let v3: number = 100;
    let v4: number = (v2 + v3) & 0xff;
    let v5: number = (-8);
    let v6: number = v5 >> 1;
    let v7: number = v2 >>> 1;
    let v8: number = 20000;
    let v9: number = (v8 + v8) << 16 >> 16;
    let v10: number = 40000;
    let v11: number = (v10 + v10) & 0xffff;
    let v12: number = 7;
    let v13: number = (v12) << 24 >> 24;
    let v14: number = 9;
    let v15: number = (v14) | 0;
    let v16: boolean = v1 === (-56);
    let v18: boolean;
    if (v16) {
        let v17: boolean = v4 === 44;
        v18 = v17;
    } else {
        v18 = false;
    }
    let v20: boolean;
    if (v18) {
        let v19: boolean = v6 === (-4);
        v20 = v19;
    } else {
        v20 = false;
    }
    let v22: boolean;
    if (v20) {
        let v21: boolean = v7 === 100;
        v22 = v21;
    } else {
        v22 = false;
    }
    let v24: boolean;
    if (v22) {
        let v23: boolean = v9 === (-25536);
        v24 = v23;
    } else {
        v24 = false;
    }
    let v26: boolean;
    if (v24) {
        let v25: boolean = v11 === 14464;
        v26 = v25;
    } else {
        v26 = false;
    }
    let v28: boolean;
    if (v26) {
        let v27: boolean = v13 === 7;
        v28 = v27;
    } else {
        v28 = false;
    }
    let v30: boolean;
    if (v28) {
        let v29: boolean = v15 === 9;
        v30 = v29;
    } else {
        v30 = false;
    }
    if (v30) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
