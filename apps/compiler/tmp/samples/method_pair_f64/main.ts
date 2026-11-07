function method0(v0: number): [number, number] {
    const v1: boolean = v0 === 0;
    if (v1) {
        return [0, 0];
    } else {
        return [1.5, 2.5];
    }
}
export function main(): number {
    const v0: number = 7;
    let [v1, v2]: [number, number] = method0(v0);
    const v3: boolean = v1 === 1.5;
    let v5: boolean;
    if (v3) {
        const v4: boolean = v2 === 2.5;
        v5 = v4;
    } else {
        v5 = false;
    }
    if (v5) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
