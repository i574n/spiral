type Mut0 = { l0: number };
function method0(v0: Mut0): Mut0 {
    return v0;
}
export function main(): number {
    const v0: Mut0 = { l0: 1 };
    let v1: Mut0 = method0(v0);
    v1.l0 = 7;
    const v2: number = v1.l0;
    const v3: boolean = v2 === 7;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
