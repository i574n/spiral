export function main(): number {
    const v0: bigint = 5000000000n;
    const v1: bigint = (-4n);
    const v2: bigint = BigInt.asIntN(64, v0 / v1);
    const v3: bigint = 1000000n;
    const v4: bigint = BigInt.asIntN(64, v3 * v3);
    const v5: bigint = (-8n);
    const v6: bigint = v5 >> BigInt(1 & 63);
    const v7: number = 7;
    const v8: bigint = BigInt.asIntN(64, BigInt(v7));
    const v9: bigint = 9n;
    const v10: number = Number(BigInt.asIntN(32, v9));
    const v11: bigint = 4294967296n;
    const v12: bigint = BigInt.asUintN(64, v11 + 1n);
    const v13: bigint = v11 >> BigInt(1 & 63);
    const v14: bigint = BigInt.asUintN(64, BigInt(v7));
    const v15: boolean = v2 === (-1250000000n);
    let v17: boolean;
    if (v15) {
        const v16: boolean = v4 === 1000000000000n;
        v17 = v16;
    } else {
        v17 = false;
    }
    let v19: boolean;
    if (v17) {
        const v18: boolean = v6 === (-4n);
        v19 = v18;
    } else {
        v19 = false;
    }
    let v21: boolean;
    if (v19) {
        const v20: boolean = v8 === 7n;
        v21 = v20;
    } else {
        v21 = false;
    }
    let v23: boolean;
    if (v21) {
        const v22: boolean = v10 === 9;
        v23 = v22;
    } else {
        v23 = false;
    }
    let v25: boolean;
    if (v23) {
        const v24: boolean = v12 === 4294967297n;
        v25 = v24;
    } else {
        v25 = false;
    }
    let v27: boolean;
    if (v25) {
        const v26: boolean = v13 === 2147483648n;
        v27 = v26;
    } else {
        v27 = false;
    }
    let v29: boolean;
    if (v27) {
        const v28: boolean = v14 === 7n;
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
