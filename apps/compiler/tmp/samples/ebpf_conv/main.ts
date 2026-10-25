export function main(): number {
    let v0: number = (-2147483648);
    let v1: number = 4294967295;
    let v2: number = (-1);
    let v3: number = 0;
    let v4: number = 1.899999976158142;
    let v5: number = 2.9000000953674316;
    let v6: number = 4294967294;
    let v7: number = 5;
    let v8: number = 0;
    let v9: number = Math.fround(v3 - v4);
    let v10: number = (v0) >>> 0;
    let v11: number = (v10) | 0;
    let v12: number = (v1) | 0;
    let v13: number = (v2) >>> 0;
    let v14: number = (v9) | 0;
    let v15: number = (v5) | 0;
    let v16: number = (v10 / 2) >>> 0;
    let v17: number = (v6 / 2) >>> 0;
    let v18: number = (v7 % 3) >>> 0;
    let v19: number = ~v8 >>> 0;
    let v20: number = v1 >>> 31;
    let v21: boolean = v0 < (-1);
    let v23: boolean;
    if (v21) {
        let v22: boolean = v0 <= v0;
        v23 = v22;
    } else {
        v23 = false;
    }
    let v26: boolean;
    if (v23) {
        let v24: boolean = v0 > 0;
        let v25: boolean = v24 === false;
        v26 = v25;
    } else {
        v26 = false;
    }
    if (v26) {
        let v27: boolean = v10 > 1;
        let v29: boolean;
        if (v27) {
            let v28: boolean = v11 === v0;
            v29 = v28;
        } else {
            v29 = false;
        }
        let v31: boolean;
        if (v29) {
            let v30: boolean = v12 === v2;
            v31 = v30;
        } else {
            v31 = false;
        }
        let v33: boolean;
        if (v31) {
            let v32: boolean = v13 === v1;
            v33 = v32;
        } else {
            v33 = false;
        }
        if (v33) {
            let v34: boolean = v14 === v2;
            let v36: boolean;
            if (v34) {
                let v35: boolean = v15 === 2;
                v36 = v35;
            } else {
                v36 = false;
            }
            if (v36) {
                let v37: boolean = v16 === 1073741824;
                let v39: boolean;
                if (v37) {
                    let v38: boolean = v17 === 2147483647;
                    v39 = v38;
                } else {
                    v39 = false;
                }
                let v41: boolean;
                if (v39) {
                    let v40: boolean = v18 === 2;
                    v41 = v40;
                } else {
                    v41 = false;
                }
                if (v41) {
                    let v42: boolean = v19 === v1;
                    let v44: boolean;
                    if (v42) {
                        let v43: boolean = v20 === 1;
                        v44 = v43;
                    } else {
                        v44 = false;
                    }
                    if (v44) {
                        return 0;
                    } else {
                        return 5;
                    }
                } else {
                    return 4;
                }
            } else {
                return 3;
            }
        } else {
            return 2;
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
