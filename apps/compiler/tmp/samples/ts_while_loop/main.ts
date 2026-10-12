function method0(v0: number): boolean {
    let v1: boolean = v0 < 10;
    return v1;
}
export function main(): number {
    let v0: number = 0;
    let v1: number = 0;
    while (method0(v0)) {
        let v3: number = (v1 + v0) | 0;
        v1 = v3;
        let v4: number = (v0 + 1) | 0;
        v0 = v4;
    }
    let v5: number = (v1 - 45) | 0;
    return v5;
}
process.exitCode = main();
