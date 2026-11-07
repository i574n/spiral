export function main(): number {
    const v0: number = 2147483647;
    const v1: number = 2;
    const v2: number = 1;
    const v3: number = (v0 + v1) >>> 0;
    const v4: number = (v0 + v2) >>> 0;
    const v5: boolean = v3 === 2147483649;
    let v7: boolean;
    if (v5) {
        const v6: boolean = v4 === 2147483648;
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
