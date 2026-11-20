function method0(v0: number, v1: number): [number, number] {
    return [v0, v1];
}
function method1(v0: number, v1: number): number {
    const v2: number = (v0 + v1) | 0;
    return v2;
}
export function main(): number {
    const v0: number = 20;
    const v1: number = 22;
    let [v2, v3]: [number, number] = method0(v0, v1);
    const v4: number = method1(v2, v3);
    const v5: number = (v4 - 42) | 0;
    return v5;
}
process.exitCode = main();
