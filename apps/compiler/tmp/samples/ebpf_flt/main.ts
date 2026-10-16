export function main(): number {
    let v0: number = (-2);
    let v1: number = (-1);
    let v2: number = 0;
    let v3: boolean = v0 < v1;
    let v5: boolean;
    if (v3) {
        let v4: boolean = v1 < v2;
        v5 = v4;
    } else {
        v5 = false;
    }
    let v8: boolean;
    if (v5) {
        let v6: boolean = v0 > v1;
        let v7: boolean = v6 === false;
        v8 = v7;
    } else {
        v8 = false;
    }
    let v11: boolean;
    if (v8) {
        let v9: boolean = v0 >= v1;
        let v10: boolean = v9 === false;
        v11 = v10;
    } else {
        v11 = false;
    }
    let v13: boolean;
    if (v11) {
        let v12: boolean = v1 <= v2;
        v13 = v12;
    } else {
        v13 = false;
    }
    if (v13) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
