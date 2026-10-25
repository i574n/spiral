export function main(): number {
    let v0: bigint = 5000000000n;
    let v1: bigint = (-4n);
    let v2: bigint = BigInt.asIntN(64, v0 / v1);
    let v3: bigint = 1000000n;
    let v4: bigint = BigInt.asIntN(64, v3 * v3);
    let v5: bigint = (-8n);
    let v6: bigint = v5 >> BigInt(1 & 63);
    let v7: number = 7;
    let v8: bigint = BigInt.asIntN(64, BigInt(v7));
    let v9: bigint = 9n;
    let v10: number = Number(BigInt.asIntN(32, v9));
    let v11: bigint = 4294967296n;
    let v12: bigint = BigInt.asUintN(64, v11 + 1n);
    let v13: bigint = v11 >> BigInt(1 & 63);
    let v14: bigint = BigInt.asUintN(64, BigInt(v7));
    let v15: boolean = v2 === (-1250000000n);
    let v17: boolean;
    if (v15) {
        let v16: boolean = v4 === 1000000000000n;
        v17 = v16;
    } else {
        v17 = false;
    }
    let v19: boolean;
    if (v17) {
        let v18: boolean = v6 === (-4n);
        v19 = v18;
    } else {
        v19 = false;
    }
    let v21: boolean;
    if (v19) {
        let v20: boolean = v8 === 7n;
        v21 = v20;
    } else {
        v21 = false;
    }
    let v23: boolean;
    if (v21) {
        let v22: boolean = v10 === 9;
        v23 = v22;
    } else {
        v23 = false;
    }
    let v25: boolean;
    if (v23) {
        let v24: boolean = v12 === 4294967297n;
        v25 = v24;
    } else {
        v25 = false;
    }
    let v27: boolean;
    if (v25) {
        let v26: boolean = v13 === 2147483648n;
        v27 = v26;
    } else {
        v27 = false;
    }
    let v29: boolean;
    if (v27) {
        let v28: boolean = v14 === 7n;
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
