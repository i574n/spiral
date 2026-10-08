export function main(): number {
    let v12: string = "hello";
    process.stdout.write(String(v12) + "\n");
    let v13: number = 42;
    process.stdout.write(String(v13) + "\n");
    let v24: string = "a";
    process.stdout.write(String(v24));
    let v32: string = "b";
    process.stdout.write(String(v32));
    let v41: string = "";
    process.stdout.write(String(v41) + "\n");
    let v42: bigint = (-7n);
    process.stdout.write(String(v42) + "\n");
    return 0;
}
process.exitCode = main();
