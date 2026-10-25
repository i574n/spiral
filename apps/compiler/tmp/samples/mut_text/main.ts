type Mut0 = { l0: string };
export function main(): number {
    let v0: string = "no";
    let v1: Mut0 = { l0: v0 };
    let v2: string = "hi";
    v1.l0 = v2;
    let v3: string = v1.l0;
    let v4: boolean = v3 === "hi";
    if (v4) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
