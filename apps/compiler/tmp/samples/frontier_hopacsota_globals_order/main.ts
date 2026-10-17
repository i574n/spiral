// m1
// a1
// c1
// a2
// b1
// m2
function leaf_c_1(): number {
    return 0;
}
function slow_a_0(): number {
    let v0: number = leaf_c_1();
    return v0;
}
function fast_b_2(): number {
    return 0;
}
export function main(): number {
    let v0: number = slow_a_0();
    let v1: number = fast_b_2();
    let v2: number = (v0 + v1) | 0;
    return v2;
}
process.exitCode = main();
