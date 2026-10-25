function fib_0(v0: number): number {
    let v1: boolean = v0 <= 1;
    if (v1) {
        return v0;
    } else {
        let v2: number = (v0 - 1) | 0;
        let v3: number = fib_0(v2);
        let v4: number = (v0 - 2) | 0;
        let v5: number = fib_0(v4);
        let v6: number = (v3 + v5) | 0;
        return v6;
    }
}
export function main(): number {
    let v0: number = 10;
    let v1: number = fib_0(v0);
    let v2: number = (v1 - 55) | 0;
    return v2;
}
process.exitCode = main();
