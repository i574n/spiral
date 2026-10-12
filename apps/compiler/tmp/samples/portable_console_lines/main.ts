export function main(): number {
    let v0: string = "hello";
    process.stdout.write(String(v0) + "\n");
    let v1: number = 42;
    process.stdout.write(String(v1) + "\n");
    let v2: string = "a";
    process.stdout.write(String(v2));
    let v3: string = "b";
    process.stdout.write(String(v3));
    let v4: string = "";
    process.stdout.write(String(v4) + "\n");
    let v5: bigint = (-7n);
    process.stdout.write(String(v5) + "\n");
    return 0;
}
process.exitCode = main();
