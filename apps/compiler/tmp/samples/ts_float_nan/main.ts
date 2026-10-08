export function main(): number {
    let v4: number = NaN;
    let v11: number = NaN;
    let v14: number = 1;
    let v15: number = 1;
    let v16: boolean = Number.isNaN(v4);
    let v18: boolean;
    if (v16) {
        let v17: boolean = Number.isNaN(v11);
        v18 = v17;
    } else {
        v18 = false;
    }
    if (v18) {
        let v19: boolean = Number.isNaN(v14);
        let v21: boolean;
        if (v19) {
            v21 = true;
        } else {
            let v20: boolean = Number.isNaN(v15);
            v21 = v20;
        }
        if (v21) {
            return 2;
        } else {
            return 0;
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
