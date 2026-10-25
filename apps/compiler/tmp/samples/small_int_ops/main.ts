export function main(): number {
    let v0: number = 100;
    let v1: number = 3;
    let v2: number = (Math.imul(v0, v1)) << 24 >> 24;
    let v3: number = (-8);
    let v4: number = 2;
    let v5: number = (v3 / v4) << 24 >> 24;
    let v6: number = (v3 % v1) << 24 >> 24;
    let v7: number = (-v1) << 24 >> 24;
    let v8: number = (v0 << 1) << 24 >> 24;
    let v9: number = 200;
    let v10: number = 3;
    let v11: number = (v9 / v10) & 0xff;
    let v12: number = (v9 % v10) & 0xff;
    let v13: number = 15;
    let v14: number = v9 & v13;
    let v15: number = v9 | v13;
    let v16: number = v9 ^ v13;
    let v17: number = (~v13) & 0xff;
    let v18: number = 20000;
    let v19: number = 7;
    let v20: number = (v18 / v19) << 16 >> 16;
    let v21: number = (v18 % v19) << 16 >> 16;
    let v22: number = (-v18) << 16 >> 16;
    let v23: number = 40000;
    let v24: number = (v23 << 1) & 0xffff;
    let v25: boolean = v2 === 44;
    let v27: boolean;
    if (v25) {
        let v26: boolean = v5 === (-4);
        v27 = v26;
    } else {
        v27 = false;
    }
    let v29: boolean;
    if (v27) {
        let v28: boolean = v6 === (-2);
        v29 = v28;
    } else {
        v29 = false;
    }
    let v31: boolean;
    if (v29) {
        let v30: boolean = v7 === (-3);
        v31 = v30;
    } else {
        v31 = false;
    }
    let v33: boolean;
    if (v31) {
        let v32: boolean = v8 === (-56);
        v33 = v32;
    } else {
        v33 = false;
    }
    let v35: boolean;
    if (v33) {
        let v34: boolean = v11 === 66;
        v35 = v34;
    } else {
        v35 = false;
    }
    let v37: boolean;
    if (v35) {
        let v36: boolean = v12 === 2;
        v37 = v36;
    } else {
        v37 = false;
    }
    let v39: boolean;
    if (v37) {
        let v38: boolean = v14 === 8;
        v39 = v38;
    } else {
        v39 = false;
    }
    let v41: boolean;
    if (v39) {
        let v40: boolean = v15 === 207;
        v41 = v40;
    } else {
        v41 = false;
    }
    let v43: boolean;
    if (v41) {
        let v42: boolean = v16 === 199;
        v43 = v42;
    } else {
        v43 = false;
    }
    let v45: boolean;
    if (v43) {
        let v44: boolean = v17 === 240;
        v45 = v44;
    } else {
        v45 = false;
    }
    let v47: boolean;
    if (v45) {
        let v46: boolean = v20 === 2857;
        v47 = v46;
    } else {
        v47 = false;
    }
    let v49: boolean;
    if (v47) {
        let v48: boolean = v21 === 1;
        v49 = v48;
    } else {
        v49 = false;
    }
    let v51: boolean;
    if (v49) {
        let v50: boolean = v22 === (-20000);
        v51 = v50;
    } else {
        v51 = false;
    }
    let v53: boolean;
    if (v51) {
        let v52: boolean = v24 === 14464;
        v53 = v52;
    } else {
        v53 = false;
    }
    if (v53) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
