function method2(v0: number, v1: number, v2: number): [number, number] {
    tail: while (true) {
        const v3: number = (v0 - 1) | 0;
        const v4: number = (v1 + 1) | 0;
        let v5: number = (v2 + 2) | 0;
        const v6: boolean = v3 === 0;
        if (v6) {
            return [v4, v5];
        } else {
            v0 = v3;
            v1 = v4;
            v2 = v5;
            continue tail;
        }
    }
}
function method1(v0: number): [number, number] {
    let v1: number = 0;
    let v2: number = 0;
    const v3: boolean = v0 === 0;
    if (v3) {
        return [v1, v2];
    } else {
        return method2(v0, v1, v2);
    }
}
function method0(v0: number): number {
    let [v1, v2]: [number, number] = method1(v0);
    const v3: boolean = v1 === 4;
    let v5: boolean;
    if (v3) {
        const v4: boolean = v2 === 8;
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
export function main(): number {
    let v0: number = 4;
    return method0(v0);
}
process.exitCode = main();
