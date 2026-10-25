function method0(v0: string): boolean {
    return true;
}
export function main(): number {
    let v0: string = "spiral";
    let v1: boolean = method0(v0);
    if (v1) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
