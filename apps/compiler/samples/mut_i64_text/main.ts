type Mut0 = { l0: bigint, l1: string };
export function main(): number {
    const v0: bigint = 3n;
    const v1: string = "no";
    let v2: Mut0 = { l0: v0, l1: v1 };
    const v3: bigint = 5000000000n;
    const v4: string = "hi";
    v2.l0 = v3;
    v2.l1 = v4;
    const v5: bigint = v2.l0;
    const v6: string = v2.l1;
    const v7: boolean = v5 === 5000000000n;
    let v9: boolean;
    if (v7) {
        const v8: boolean = v6 === "hi";
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
