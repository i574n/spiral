function method0(v0: number): [string, string] {
    const v1: boolean = v0 === 0;
    if (v1) {
        const v2: string = "no";
        return [v2, v2];
    } else {
        const v3: string = "hi";
        const v4: string = "yo";
        return [v3, v4];
    }
}
export function main(): number {
    const v0: number = 7;
    let [v1, v2]: [string, string] = method0(v0);
    const v3: boolean = v1 === "hi";
    let v5: boolean;
    if (v3) {
        const v4: boolean = v2 === "yo";
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
