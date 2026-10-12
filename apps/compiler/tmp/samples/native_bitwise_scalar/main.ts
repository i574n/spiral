export function main(): number {
    let v0: number = 43;
    let v1: number = 15;
    let v2: number = 2;
    let v3: number = 5;
    let v4: number = v0 & v1;
    let v5: number = v0 | v1;
    let v6: number = v0 ^ v1;
    let v7: number = ~v0;
    let v8: number = v7 & 255;
    let v9: number = 1 << v3;
    let v10: number = 168 >> v2;
    let v11: number = (v4 - 11) | 0;
    let v12: number = (v10 + v11) | 0;
    let v13: number = (v5 - 47) | 0;
    let v14: number = (v12 + v13) | 0;
    let v15: number = (v6 - 36) | 0;
    let v16: number = (v14 + v15) | 0;
    let v17: number = (v8 - 212) | 0;
    let v18: number = (v16 + v17) | 0;
    let v19: number = (v9 - 32) | 0;
    let v20: number = (v18 + v19) | 0;
    return v20;
}
process.exitCode = main();
