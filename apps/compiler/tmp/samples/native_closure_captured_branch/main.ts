function a_c0(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: number = (v1 + v0) | 0;
        return v2;
    };
}
function b_c1(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: number = (v1 + v0) | 0;
        return v2;
    };
}
function method0(v0: ((a0: number) => number)): number {
    return v0(40);
}
export function main(): number {
    const v0: number = 2;
    const v1: number = 3;
    const v2: boolean = true;
    let v5: ((a0: number) => number);
    if (v2) {
        v5 = a_c0(v0);
    } else {
        v5 = b_c1(v1);
    }
    return method0(v5);
}
process.exitCode = main();
