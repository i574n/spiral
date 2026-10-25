function is_answer_1(v0: number): boolean {
    let v1: boolean = v0 === 42;
    return v1;
}
function method0(v0: number): boolean {
    return is_answer_1(v0);
}
export function main(): number {
    let v0: number = 42;
    let v1: boolean = method0(v0);
    if (v1) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
