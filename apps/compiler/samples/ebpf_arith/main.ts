export function main(): number {
    const v0: number = 7;
    const v1: number = 2;
    const v2: number = 4294967295;
    const v3: number = (-v0) | 0;
    const v4: number = (-3);
    const v5: number = (-12);
    const v6: number = (-4);
    const v7: number = (-1);
    const v8: number = (v3 / v1) | 0;
    const v9: boolean = v8 === v4;
    if (v9) {
        const v10: number = (v3 % v1) | 0;
        const v11: boolean = v10 === v7;
        if (v11) {
            const v12: number = v3 >> 1;
            const v13: boolean = v12 === v6;
            if (v13) {
                const v14: number = v4 << 2;
                const v15: boolean = v14 === v5;
                if (v15) {
                    const v16: number = (v2 + 1) >>> 0;
                    const v17: boolean = v16 === 0;
                    if (v17) {
                        const v18: number = Math.imul(v2, v2) >>> 0;
                        const v19: boolean = v18 === 1;
                        if (v19) {
                            const v20: number = v2 >>> 28;
                            const v21: boolean = v20 === 15;
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
