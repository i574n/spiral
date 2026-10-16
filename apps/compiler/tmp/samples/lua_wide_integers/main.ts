function lcg_0(v0: bigint, v1: bigint, v2: number, v3: bigint): bigint {
    tail: while (true) {
        let v4: boolean = v2 === 0;
        if (v4) {
            return v3;
        } else {
            let v5: number = (v2 - 1) | 0;
            let v6: bigint = BigInt.asUintN(64, v3 * v0);
            let v7: bigint = BigInt.asUintN(64, v6 + v1);
            {
                let t0 = v0;
                let t1 = v1;
                let t2 = v5;
                let t3 = v7;
                v0 = t0;
                v1 = t1;
                v2 = t2;
                v3 = t3;
            }
            continue tail;
        }
    }
}
export function main(): number {
    let v0: bigint = 42n;
    let v1: bigint = 6364136223846793005n;
    let v2: bigint = 1442695040888963407n;
    let v3: number = 1000;
    let v4: bigint = lcg_0(v1, v2, v3, v0);
    process.stdout.write("lcg " + String(v4) + "\n");
    let v5: bigint = 9223372036854775807n;
    let v6: bigint = (-9223372036854775807n);
    let v7: bigint = 18446744073709551615n;
    let v8: bigint = BigInt.asIntN(64, v6 - 1n);
    let v9: bigint = BigInt.asUintN(64, v7 + 2n);
    process.stdout.write("max " + String(v5) + " min " + String(v8) + " wrap " + String(v9) + "\n");
    let v10: bigint = (-9007199254740993n);
    let v11: bigint = 7n;
    let v12: bigint = BigInt.asIntN(64, v10 / v11);
    let v13: bigint = BigInt.asIntN(64, v10 % v11);
    process.stdout.write("div " + String(v12) + " mod " + String(v13) + "\n");
    let v14: bigint = v10 >> BigInt(3 & 63);
    let v15: bigint = v4 >> BigInt(60 & 63);
    process.stdout.write("shl " + String(4611686018427387904n) + " shr " + String(v14) + " ushr " + String(v15) + "\n");
    let v16: bigint = v4 & 18446744069414584320n;
    let v17: bigint = v10 | 255n;
    let v18: bigint = v4 ^ v1;
    process.stdout.write("and " + String(v16) + " or " + String(v17) + " xor " + String(v18) + "\n");
    let v19: number = 1E+18;
    let v20: bigint = BigInt.asIntN(64, BigInt(Math.trunc(v19)));
    let v21: number = Number(BigInt.asUintN(32, v4));
    let v22: number = Number(v10);
    let v23: boolean = v22 < 0;
    let v24: number;
    if (v23) {
        v24 = 1;
    } else {
        v24 = 0;
    }
    process.stdout.write("conv " + String(v20) + " " + String(v21) + " " + String(v24) + "\n");
    let v25: boolean = v4 > v1;
    if (v25) {
        return 1;
    } else {
        return 0;
    }
}
process.exitCode = main();
