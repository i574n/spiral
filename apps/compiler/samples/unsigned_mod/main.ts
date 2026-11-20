function method0(v0: number): boolean {
    const v1: number = (v0 + 5) >>> 0;
    const v2: number = (v1 % 4) >>> 0;
    const v3: boolean = v2 === 0;
    return v3;
}
export function main(): number {
    const v0: number = 7;
    const v1: boolean = method0(v0);
    if (v1) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
