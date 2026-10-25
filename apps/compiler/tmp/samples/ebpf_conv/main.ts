export function main(): number {
    const v0: number = (-2147483648);
    const v1: number = 4294967295;
    const v2: number = (-1);
    const v3: number = 0;
    const v4: number = 1.899999976158142;
    const v5: number = 2.9000000953674316;
    const v6: number = 4294967294;
    const v7: number = 5;
    const v8: number = 0;
    const v9: number = Math.fround(v3 - v4);
    const v10: number = (v0) >>> 0;
    const v11: number = (v10) | 0;
    const v12: number = (v1) | 0;
    const v13: number = (v2) >>> 0;
    const v14: number = (v9) | 0;
    const v15: number = (v5) | 0;
    const v16: number = (v10 / 2) >>> 0;
    const v17: number = (v6 / 2) >>> 0;
    const v18: number = (v7 % 3) >>> 0;
    const v19: number = ~v8 >>> 0;
    const v20: number = v1 >>> 31;
    const v21: boolean = v0 < (-1);
    let v23: boolean;
    if (v21) {
        const v22: boolean = v0 <= v0;
        v23 = v22;
    } else {
        v23 = false;
    }
    let v26: boolean;
    if (v23) {
        const v24: boolean = v0 > 0;
        const v25: boolean = v24 === false;
        v26 = v25;
    } else {
        v26 = false;
    }
    if (v26) {
        const v27: boolean = v10 > 1;
        let v29: boolean;
        if (v27) {
            const v28: boolean = v11 === v0;
            v29 = v28;
        } else {
            v29 = false;
        }
        let v31: boolean;
        if (v29) {
            const v30: boolean = v12 === v2;
            v31 = v30;
        } else {
            v31 = false;
        }
        let v33: boolean;
        if (v31) {
            const v32: boolean = v13 === v1;
            v33 = v32;
        } else {
            v33 = false;
        }
        if (v33) {
            const v34: boolean = v14 === v2;
            let v36: boolean;
            if (v34) {
                const v35: boolean = v15 === 2;
                v36 = v35;
            } else {
                v36 = false;
            }
            if (v36) {
                const v37: boolean = v16 === 1073741824;
                let v39: boolean;
                if (v37) {
                    const v38: boolean = v17 === 2147483647;
                    v39 = v38;
                } else {
                    v39 = false;
                }
                let v41: boolean;
                if (v39) {
                    const v40: boolean = v18 === 2;
                    v41 = v40;
                } else {
                    v41 = false;
                }
                if (v41) {
                    const v42: boolean = v19 === v1;
                    let v44: boolean;
                    if (v42) {
                        const v43: boolean = v20 === 1;
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
