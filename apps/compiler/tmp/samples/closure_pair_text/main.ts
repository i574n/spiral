function f_c0(v0: string): ((a0: number) => [string, string]) {
    return (v1: number): [string, string] => {
        let v2: boolean = v1 === 0;
        if (v2) {
            let v3: string = "no";
            return [v3, v3];
        } else {
            let v4: string = "yo";
            return [v0, v4];
        }
    };
}
export function main(): number {
    let v0: string = "hi";
    let v1: ((a0: number) => [string, string]) = f_c0(v0);
    let [v2, v3]: [string, string] = v1(1);
    let v4: boolean = v2 === "hi";
    let v6: boolean;
    if (v4) {
        let v5: boolean = v3 === "yo";
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
