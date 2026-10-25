function method0(v0: number): string {
    let v1: boolean = v0 === 0;
    if (v1) {
        let v2: string = "no";
        return v2;
    } else {
        let v3: string = "hi";
        return v3;
    }
}
export function main(): number {
    let v0: number = 7;
    let v1: string = method0(v0);
    let v2: boolean = v1 === "hi";
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
