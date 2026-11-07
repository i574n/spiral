function method2(v0: number, v1: number, v2: number, v3: number): [number, number, number] {
    tail: while (true) {
        const v4: number = (v0 - 1) | 0;
        const v5: number = (v1 + 1) | 0;
        let v6: number = (v2 + 2) | 0;
        const v7: number = (v3 + 3) | 0;
        let v8: boolean = v4 === 0;
        if (v8) {
            return [v5, v6, v7];
        } else {
            v0 = v4;
            v1 = v5;
            v2 = v6;
            v3 = v7;
            continue tail;
        }
    }
}
function method1(v0: number): [number, number, number] {
    let v1: number = 0;
    let v2: number = 0;
    let v3: number = 0;
    const v4: boolean = v0 === 0;
    if (v4) {
        return [v1, v2, v3];
    } else {
        return method2(v0, v1, v2, v3);
    }
}
function method0(v0: number): number {
    let [v1, v2, v3]: [number, number, number] = method1(v0);
    const v4: boolean = v1 === 3;
    let v6: boolean;
    if (v4) {
        const v5: boolean = v2 === 6;
        v6 = v5;
    } else {
        v6 = false;
    }
    let v8: boolean;
    if (v6) {
        const v7: boolean = v3 === 9;
        v8 = v7;
    } else {
        v8 = false;
    }
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
export function main(): number {
    let v0: number = 3;
    return method0(v0);
}
process.exitCode = main();
