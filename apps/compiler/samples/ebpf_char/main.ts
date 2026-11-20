export function main(): number {
    const v0: number = 65;
    const v1: number = 66;
    const v2: boolean = v0 === 65;
    if (v2) {
        const v3: boolean = v1 === 66;
        if (v3) {
            const v4: boolean = v0 === v1;
            if (v4) {
                return 2;
            } else {
                return 0;
            }
        } else {
            return 3;
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
