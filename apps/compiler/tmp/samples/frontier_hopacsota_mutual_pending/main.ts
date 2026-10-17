function is_odd_1(v0: number): boolean {
    let v1: boolean = v0 === 0;
    if (v1) {
        return false;
    } else {
        let v2: number = (v0 - 1) | 0;
        return is_even_0(v2);
    }
}
function is_even_0(v0: number): boolean {
    let v1: boolean = v0 === 0;
    if (v1) {
        return true;
    } else {
        let v2: number = (v0 - 1) | 0;
        return is_odd_1(v2);
    }
}
export function main(): number {
    let v0: number = 10;
    let v1: boolean = is_even_0(v0);
    if (v1) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
