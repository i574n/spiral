function method0(v0: number, v1: number): [number, number] {
    return [v0, v1];
}
function method1(v0: number, v1: number): number {
    let v2: number = (v0 + v1) | 0;
    return v2;
}
export function main(): number {
    let v0: number = 20;
    let v1: number = 22;
    let [v2, v3]: [number, number] = method0(v0, v1);
    let v4: number = method1(v2, v3);
    let v5: number = (v4 - 42) | 0;
    return v5;
}
process.exitCode = main();
