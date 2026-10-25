function method1(v0: number, v1: number): [number, number] {
    return [v0, v1];
}
function method0(v0: number, v1: number): number {
    let [v2, v3]: [number, number] = method1(v0, v1);
    let v4: number = (v2 + v3) | 0;
    return v4;
}
function method3(v0: number, v1: number, v2: number): [number, number, number] {
    return [v0, v1, v2];
}
function method2(v0: number, v1: number, v2: number): number {
    let [v3, v4, v5]: [number, number, number] = method3(v0, v1, v2);
    let v6: number = (v3 + v4) | 0;
    let v7: number = (v6 + v5) | 0;
    return v7;
}
export function main(): number {
    let v0: number = 1;
    let v1: number = 2;
    let v2: number = 3;
    let v3: number = method0(v0, v1);
    let v4: number = method2(v0, v1, v2);
    let v5: number = (v3 + v4) | 0;
    let v6: number = (v5 - 9) | 0;
    return v6;
}
process.exitCode = main();
