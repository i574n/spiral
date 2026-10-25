type Mut0 = { l0: number };
function method0(v0: Mut0): void {
    let v1: number = v0.l0;
    let v2: number = (v1 + 5) | 0;
    v0.l0 = v2;
}
function method1(v0: Mut0): void {
}
function method2(v0: Mut0): void {
    let v1: number = v0.l0;
    let v2: number = (v1 + 7) | 0;
    v0.l0 = v2;
}
export function main(): number {
    let v0: Mut0 = { l0: 0 };
    method0(v0);
    method1(v0);
    method2(v0);
    let v1: number = v0.l0;
    let v2: number = (v1 - 12) | 0;
    return v2;
}
process.exitCode = main();
