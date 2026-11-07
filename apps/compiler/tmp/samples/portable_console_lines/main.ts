export function main(): number {
    const v0: string = "hello";
    process.stdout.write(String(v0) + "\n");
    const v1: number = 42;
    process.stdout.write(String(v1) + "\n");
    const v2: string = "a";
    process.stdout.write(String(v2));
    const v3: string = "b";
    process.stdout.write(String(v3));
    const v4: string = "";
    process.stdout.write(String(v4) + "\n");
    const v5: bigint = (-7n);
    process.stdout.write(String(v5) + "\n");
    return 0;
}
process.exitCode = main();
