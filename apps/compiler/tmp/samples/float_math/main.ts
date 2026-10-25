function method0(v0: number, v1: number): number {
    let v2: number = Math.fround(v0 * v1);
    let v3: number = Math.fround(v2 + 0.5);
    return v3;
}
export function main(): number {
    let v0: number = 1.5;
    let v1: number = 2;
    let v2: number = method0(v0, v1);
    let v3: boolean = v2 >= 3.5;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
