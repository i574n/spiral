function fib_0(v0: number): number {
    const v1: boolean = v0 <= 1;
    if (v1) {
        return v0;
    } else {
        const v2: number = (v0 - 1) | 0;
        const v3: number = fib_0(v2);
        const v4: number = (v0 - 2) | 0;
        const v5: number = fib_0(v4);
        const v6: number = (v3 + v5) | 0;
        return v6;
    }
}
export function main(): number {
    const v0: number = 10;
    const v1: number = fib_0(v0);
    const v2: number = (v1 - 55) | 0;
    return v2;
}
process.exitCode = main();
