function method0(v0: number): [number, number, boolean] {
    let v1: number = (v0 + 2) | 0;
    let v2: boolean = v0 > 0;
    return [v0, v1, v2];
}
function method1(v0: number, v1: number, v2: boolean): number {
    if (v2) {
        let v3: number = (v0 + v1) | 0;
        let v4: number = (v3 - 4) | 0;
        return v4;
    } else {
        return 1;
    }
}
export function main(): number {
    let v0: number = 1;
    let [v1, v2, v3]: [number, number, boolean] = method0(v0);
    return method1(v1, v2, v3);
}
process.exitCode = main();
