export function main(): number {
    const v0: number = 3;
    const v1: number = 4;
    const v2: number = 1;
    const v3: number = 1;
    const v4: number = 1.5;
    const v5: number = -v4;
    const v6: boolean = v0 !== v1;
    if (v6) {
        const v7: boolean = v2 !== v3;
        if (v7) {
            return 2;
        } else {
            const v8: boolean = v5 === (-1.5);
            if (v8) {
                return 0;
            } else {
                return 3;
            }
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
