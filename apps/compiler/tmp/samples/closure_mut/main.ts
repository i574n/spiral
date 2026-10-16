type Mut0 = { l0: number };
function f_c0(v0: Mut0): ((a0: number) => Mut0) {
    return (v1: number): Mut0 => {
        return v0;
    };
}
export function main(): number {
    let v0: Mut0 = { l0: 1 };
    let v1: ((a0: number) => Mut0) = f_c0(v0);
    let v2: Mut0 = v1(1);
    v2.l0 = 7;
    let v3: number = v2.l0;
    let v4: boolean = v3 === 7;
    if (v4) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
