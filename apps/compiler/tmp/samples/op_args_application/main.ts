function f_0(v0: number): number {
    let v1: boolean = v0 === 1;
    if (v1) {
        return 0;
    } else {
        return 1;
    }
}
export function main(): number {
    let v0: number = 1;
    return f_0(v0);
}
process.exitCode = main();
