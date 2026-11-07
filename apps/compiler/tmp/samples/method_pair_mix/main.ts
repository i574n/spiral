function method0(v0: number, v1: string): [number, string] {
    const v2: boolean = v0 === 0;
    if (v2) {
        const v3: string = "no";
        return [0, v3];
    } else {
        return [v0, v1];
    }
}
export function main(): number {
    const v0: number = 7;
    const v1: string = "hi";
    let [v2, v3]: [number, string] = method0(v0, v1);
    const v4: boolean = v2 === 7;
    let v6: boolean;
    if (v4) {
        const v5: boolean = v3 === "hi";
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
