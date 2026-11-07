function method2(): number {
    return 14;
}
function method1(): number {
    const v0: number = method2();
    const v1: number = (14 + v0) | 0;
    return v1;
}
function method0(): number {
    const v0: number = method1();
    const v1: number = (14 + v0) | 0;
    return v1;
}
export function main(): number {
    return method0();
}
process.exitCode = main();
