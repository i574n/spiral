type Mut0 = { l0: number, l1: number };
export function main(): number {
    let v0: Mut0 = { l0: 1, l1: 2 };
    v0.l0 = 3;
    v0.l1 = 4;
    let v1: number = v0.l0;
    let v2: number = v0.l1;
    let v3: number = (v1 + v2) | 0;
    return v3;
}
process.exitCode = main();
