function method0(v0: number): [string, string] {
    let v1: boolean = v0 === 0;
    if (v1) {
        let v2: string = "no";
        return [v2, v2];
    } else {
        let v3: string = "hi";
        let v4: string = "yo";
        return [v3, v4];
    }
}
export function main(): number {
    let v0: number = 7;
    let [v1, v2]: [string, string] = method0(v0);
    let v3: boolean = v1 === "hi";
    let v5: boolean;
    if (v3) {
        let v4: boolean = v2 === "yo";
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
