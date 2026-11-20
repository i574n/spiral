export function main(): number {
    const v0: number = 65536;
    const v1: number = 65536;
    const v2: number = 4294967295;
    const v3: number = 3;
    const v4: number = Math.imul(v0, v1) >>> 0;
    const v5: number = Math.imul(v2, v3) >>> 0;
    const v6: boolean = v4 === 0;
    let v8: boolean;
    if (v6) {
        const v7: boolean = v5 === 4294967293;
        v8 = v7;
    } else {
        v8 = false;
    }
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
