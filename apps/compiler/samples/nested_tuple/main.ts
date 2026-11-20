function method0(v0: number): [number, number, number, number] {
    const v1: number = (v0 + 1) | 0;
    const v2: number = (v0 + 2) | 0;
    const v3: number = (v0 + 3) | 0;
    return [v0, v1, v2, v3];
}
function method1(v0: number, v1: number, v2: number, v3: number): number {
    const v4: number = (v0 + v1) | 0;
    const v5: number = (v4 + v2) | 0;
    const v6: number = (v5 + v3) | 0;
    const v7: number = (v6 - 10) | 0;
    return v7;
}
export function main(): number {
    const v0: number = 1;
    let [v1, v2, v3, v4]: [number, number, number, number] = method0(v0);
    return method1(v1, v2, v3, v4);
}
process.exitCode = main();
