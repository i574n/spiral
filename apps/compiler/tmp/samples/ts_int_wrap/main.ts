export function main(): number {
    const v0: number = 250;
    const v1: number = 10;
    const v2: number = 4294967295;
    const v3: bigint = 18446744073709551615n;
    const v4: number = 127;
    const v5: number = 1;
    const v6: number = 7;
    const v7: number = 2;
    const v8: bigint = 9223372036854775807n;
    const v9: number = (-v6) | 0;
    const v10: bigint = BigInt.asIntN(64, -v8);
    const v11: number = (v0 + v1) & 0xff;
    const v12: boolean = v11 === 4;
    if (v12) {
        const v13: number = (v2 + 1) >>> 0;
        const v14: boolean = v13 === 0;
        if (v14) {
            const v15: number = Math.imul(v2, v2) >>> 0;
            const v16: boolean = v15 === 1;
            if (v16) {
                const v17: bigint = BigInt.asUintN(64, v3 + 1n);
                const v18: boolean = v17 === 0n;
                if (v18) {
                    const v19: bigint = BigInt.asUintN(64, v3 * v3);
                    const v20: boolean = v19 === 1n;
                    if (v20) {
                        const v21: bigint = BigInt.asUintN(64, v3 / 3n);
                        const v22: boolean = v21 === 6148914691236517205n;
                        if (v22) {
                            const v23: number = (v4 + v5) << 24 >> 24;
                            const v24: boolean = v23 < 0;
                            if (v24) {
                                const v25: number = (v9 / v7) | 0;
                                const v26: boolean = v25 === (-3);
                                if (v26) {
                                    const v27: number = (v9 % v7) | 0;
                                    const v28: boolean = v27 === (-1);
                                    if (v28) {
                                        const v29: bigint = BigInt.asIntN(64, v10 % 10n);
                                        const v30: boolean = v29 === (-7n);
                                        if (v30) {
                                            const v31: number = v2 >>> 28;
                                            const v32: boolean = v31 === 15;
                                            if (v32) {
                                                const v33: number = v9 >> 1;
                                                const v34: boolean = v33 === (-4);
                                                if (v34) {
                                                    return 0;
                                                } else {
                                                    return 12;
                                                }
                                            } else {
                                                return 11;
                                            }
                                        } else {
                                            return 10;
                                        }
                                    } else {
                                        return 9;
                                    }
                                } else {
                                    return 8;
                                }
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
