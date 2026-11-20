function method1(v0: number, v1: number): number {
    tail: while (true) {
        const v2: number = (v0 - 1) | 0;
        const v3: number = (v1 + 3) | 0;
        const v4: boolean = v2 === 0;
        if (v4) {
            return v3;
        } else {
            v0 = v2;
            v1 = v3;
            continue tail;
        }
    }
}
function method0(v0: number): number {
    let v1: number = 0;
    const v2: boolean = v0 === 0;
    if (v2) {
        return v1;
    } else {
        return method1(v0, v1);
    }
}
function method3(v0: number, v1: number): number {
    tail: while (true) {
        const v2: number = (v0 - 1) | 0;
        const v3: number = (v1 - 2) | 0;
        const v4: boolean = v2 === 0;
        if (v4) {
            return v3;
        } else {
            v0 = v2;
            v1 = v3;
            continue tail;
        }
    }
}
function method2(v0: number): number {
    let v1: number = 0;
    const v2: boolean = v0 === 0;
    if (v2) {
        return v1;
    } else {
        return method3(v0, v1);
    }
}
export function main(): number {
    let v0: number = 4;
    let v1: number = method0(v0);
    const v2: number = method2(v0);
    const v3: boolean = v1 === 12;
    let v5: boolean;
    if (v3) {
        const v4: boolean = v2 === (-8);
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
