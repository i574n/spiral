function method0(v0: string, v1: string): [string, string] {
    const v2: boolean = v0 === "";
    if (v2) {
        const v3: string = "no";
        const v4: string = "nay";
        return [v3, v4];
    } else {
        return [v0, v1];
    }
}
export function main(): number {
    const v0: string = "hi";
    const v1: string = "yo";
    let [v2, v3]: [string, string] = method0(v0, v1);
    const v4: boolean = v2 === "hi";
    let v6: boolean;
    if (v4) {
        const v5: boolean = v3 === "yo";
        v6 = v5;
    } else {
        v6 = false;
    }
    if (v6) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
