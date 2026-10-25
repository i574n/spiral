function method0(v0: number): [boolean, number, number] {
    let v1: boolean = v0 >= 3.5;
    return [v1, v0, 7];
}
function method1(v0: boolean, v1: number, v2: number): number {
    if (v0) {
        let v3: boolean = v1 >= 3.5;
        if (v3) {
            let v4: number = (v2 - 7) | 0;
            return v4;
        } else {
            return 1;
        }
    } else {
        return 2;
    }
}
export function main(): number {
    let v0: number = 4;
    let [v1, v2, v3]: [boolean, number, number] = method0(v0);
    return method1(v1, v2, v3);
}
process.exitCode = main();
