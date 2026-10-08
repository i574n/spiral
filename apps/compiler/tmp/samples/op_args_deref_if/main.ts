type Mut0 = { l0: string };
export function main(): number {
    let v0: string = "deref";
    let v1: Mut0 = { l0: v0 };
    let v2: number = 3;
    let v3: string = "deref!";
    v1.l0 = v3;
    let v4: string = v1.l0;
    let v5: boolean = v2 === 3;
    let v7: number;
    if (v5) {
        let v6: number = (v2 + 1) | 0;
        v7 = v6;
    } else {
        v7 = 0;
    }
    process.stdout.write(v4 + " " + String(v7) + "\n");
    let v8: number = Math.imul(v2, 2);
    let v9: boolean = v2 > 0;
    let v10: number;
    if (v9) {
        v10 = 6;
    } else {
        v10 = 0;
    }
    let v11: boolean = v8 === v10;
    if (v11) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
