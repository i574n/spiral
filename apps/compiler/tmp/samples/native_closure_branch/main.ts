function a_c0(): ((a0: number) => number) {
    return (v0: number): number => {
        let v1: number = (v0 + 2) | 0;
        return v1;
    };
}
function b_c1(): ((a0: number) => number) {
    return (v0: number): number => {
        let v1: number = (v0 + 3) | 0;
        return v1;
    };
}
function method0(v0: ((a0: number) => number)): number {
    return v0(40);
}
export function main(): number {
    let v0: boolean = true;
    let v3: ((a0: number) => number);
    if (v0) {
        v3 = a_c0();
    } else {
        v3 = b_c1();
    }
    return method0(v3);
}
process.exitCode = main();
