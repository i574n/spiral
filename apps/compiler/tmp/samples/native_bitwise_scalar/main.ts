export function main(): number {
    const v0: number = 43;
    const v1: number = 15;
    const v2: number = 2;
    const v3: number = 5;
    const v4: number = v0 & v1;
    const v5: number = v0 | v1;
    const v6: number = v0 ^ v1;
    const v7: number = ~v0;
    const v8: number = v7 & 255;
    const v9: number = 1 << v3;
    const v10: number = 168 >> v2;
    const v11: number = (v4 - 11) | 0;
    const v12: number = (v10 + v11) | 0;
    const v13: number = (v5 - 47) | 0;
    const v14: number = (v12 + v13) | 0;
    const v15: number = (v6 - 36) | 0;
    const v16: number = (v14 + v15) | 0;
    const v17: number = (v8 - 212) | 0;
    const v18: number = (v16 + v17) | 0;
    const v19: number = (v9 - 32) | 0;
    const v20: number = (v18 + v19) | 0;
    return v20;
}
process.exitCode = main();
