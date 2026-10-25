function loop_0(v0: number, v1: number, v2: number, v3: number): [number, number] {
    let v4: boolean = v1 >= v0;
    let v9: number;
    let v10: number;
    if (v4) {
        v9 = v2;
        v10 = v3;
    } else {
        let v5: number = (v1 + 1) | 0;
        let v6: number = (v2 + 1) | 0;
        let [v7, v8]: [number, number] = loop_0(v0, v5, v6, v3);
        v9 = v7;
        v10 = v8;
    }
    return [v9, v10];
}
export function main(): number {
    let v0: number = 5;
    let v1: number = 0;
    let v2: number = 1;
    let v3: number = 2;
    let [v4, v5]: [number, number] = loop_0(v0, v1, v2, v3);
    let v6: number = (v4 + v5) | 0;
    return v6;
}
process.exitCode = main();
