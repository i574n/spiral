export function main(): number {
    let v0: number = 7;
    let v1: number = 2;
    let v2: number = 4294967295;
    let v3: number = (-v0) | 0;
    let v4: number = (-3);
    let v5: number = (-12);
    let v6: number = (-4);
    let v7: number = (-1);
    let v8: number = (v3 / v1) | 0;
    let v9: boolean = v8 === v4;
    if (v9) {
        let v10: number = (v3 % v1) | 0;
        let v11: boolean = v10 === v7;
        if (v11) {
            let v12: number = v3 >> 1;
            let v13: boolean = v12 === v6;
            if (v13) {
                let v14: number = v4 << 2;
                let v15: boolean = v14 === v5;
                if (v15) {
                    let v16: number = (v2 + 1) >>> 0;
                    let v17: boolean = v16 === 0;
                    if (v17) {
                        let v18: number = Math.imul(v2, v2) >>> 0;
                        let v19: boolean = v18 === 1;
                        if (v19) {
                            let v20: number = v2 >>> 28;
                            let v21: boolean = v20 === 15;
                            if (v21) {
                                return 0;
                            } else {
                                return 7;
                            }
                        } else {
                            return 6;
                        }
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
