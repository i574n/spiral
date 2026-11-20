function method0(v0: boolean): number {
    if (v0) {
        return 1;
    } else {
        return 3;
    }
}
function method1(v0: boolean, v1: boolean): number {
    const v2: boolean = v0 && v1;
    if (v2) {
        return 1;
    } else {
        const v3: boolean = v0 || v1;
        if (v3) {
            return 2;
        } else {
            return 3;
        }
    }
}
function method2(v0: boolean): number {
    if (v0) {
        return 1;
    } else {
        return 3;
    }
}
export function main(): number {
    const v0: boolean = true;
    const v1: boolean = false;
    const v2: number = method0(v0);
    const v3: number = method1(v0, v1);
    const v4: number = method2(v1);
    const v5: boolean = v0 === v1;
    const v6: boolean = v5 === false;
    const v7: boolean = v2 === 1;
    let v9: boolean;
    if (v7) {
        const v8: boolean = v3 === 2;
        v9 = v8;
    } else {
        v9 = false;
    }
    let v11: boolean;
    if (v9) {
        const v10: boolean = v4 === 3;
        v11 = v10;
    } else {
        v11 = false;
    }
    const v12: boolean = v11 && v6;
    if (v12) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
