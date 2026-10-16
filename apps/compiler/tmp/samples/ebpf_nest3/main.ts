function method1(v0: number, v1: number, v2: number): [number, number, number] {
    return [v0, v1, v2];
}
function method0(v0: number, v1: number, v2: number): number {
    let [v3, v4, v5]: [number, number, number] = method1(v0, v1, v2);
    let v6: boolean = v3 === 2;
    let v8: boolean;
    if (v6) {
        let v7: boolean = v4 === 3;
        v8 = v7;
    } else {
        v8 = false;
    }
    let v10: boolean;
    if (v8) {
        let v9: boolean = v5 === 1.5;
        v10 = v9;
    } else {
        v10 = false;
    }
    if (v10) {
        return 0;
    } else {
        return 1;
    }
}
export function main(): number {
    let v0: number = 2;
    let v1: number = 3;
    let v2: number = 1.5;
    return method0(v0, v1, v2);
}
process.exitCode = main();
