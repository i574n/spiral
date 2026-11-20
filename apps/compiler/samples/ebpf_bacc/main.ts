function method1(v0: number, v1: boolean): boolean {
    tail: while (true) {
        const v2: number = (v0 - 1) | 0;
        let v4: boolean;
        if (v1) {
            const v3: boolean = v0 > 0;
            v4 = v3;
        } else {
            v4 = false;
        }
        const v5: boolean = v2 === 0;
        if (v5) {
            return v4;
        } else {
            v0 = v2;
            v1 = v4;
            continue tail;
        }
    }
}
function method0(v0: number): boolean {
    let v1: boolean = true;
    const v2: boolean = v0 === 0;
    if (v2) {
        return v1;
    } else {
        return method1(v0, v1);
    }
}
function method2(v0: number): boolean {
    let v1: boolean = false;
    const v2: boolean = v0 === 0;
    if (v2) {
        return v1;
    } else {
        return method1(v0, v1);
    }
}
export function main(): number {
    let v0: number = 3;
    let v1: boolean = method0(v0);
    const v2: boolean = method2(v0);
    if (v1) {
        if (v2) {
            return 1;
        } else {
            return 0;
        }
    } else {
        return 2;
    }
}
process.exitCode = main();
