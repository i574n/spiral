function sum_0(v0: number): number {
    const v1: boolean = v0 < 1;
    if (v1) {
        return 0;
    } else {
        const v2: number = (v0 - 1) | 0;
        const v3: number = sum_0(v2);
        const v4: number = (v0 + v3) | 0;
        return v4;
    }
}
export function main(): number {
    const v0: number = 4;
    const v1: number = sum_0(v0);
    const v2: boolean = v1 === 10;
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
