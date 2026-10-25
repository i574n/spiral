function method0(v0: number, v1: string): [number, string] {
    let v2: boolean = v0 === 0;
    if (v2) {
        let v3: string = "no";
        return [0, v3];
    } else {
        return [v0, v1];
    }
}
export function main(): number {
    let v0: number = 7;
    let v1: string = "hi";
    let [v2, v3]: [number, string] = method0(v0, v1);
    let v4: boolean = v2 === 7;
    let v6: boolean;
    if (v4) {
        let v5: boolean = v3 === "hi";
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
