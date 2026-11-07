function f_c0(v0: boolean): ((a0: number) => [boolean, boolean]) {
    return (v1: number): [boolean, boolean] => {
        const v2: boolean = v1 === 0;
        if (v2) {
            return [false, false];
        } else {
            return [v0, true];
        }
    };
}
export function main(): number {
    const v0: boolean = true;
    const v1: ((a0: number) => [boolean, boolean]) = f_c0(v0);
    let [v2, v3]: [boolean, boolean] = v1(1);
    const v4: boolean = v2 && v3;
    if (v4) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
