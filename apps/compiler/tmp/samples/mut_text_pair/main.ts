type Mut0 = { l0: string, l1: string };
export function main(): number {
    let v0: string = "no";
    let v1: string = "nay";
    let v2: Mut0 = { l0: v0, l1: v1 };
    let v3: string = "hi";
    let v4: string = "yo";
    v2.l0 = v3;
    v2.l1 = v4;
    let v5: string = v2.l0;
    let v6: string = v2.l1;
    let v7: boolean = v5 === "hi";
    let v9: boolean;
    if (v7) {
        let v8: boolean = v6 === "yo";
        v9 = v8;
    } else {
        v9 = false;
    }
    if (v9) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
