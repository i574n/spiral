type US0_Living = { readonly tag: 0, readonly f0: number, readonly f1: number };
type US0 = US0_Living;
function US0_Living(f0: number, f1: number): US0 { return { tag: 0, f0: f0, f1: f1 }; }
export function main(): number {
    let v0: number = 3;
    let v1: Array<US0> = new Array<US0>(v0).fill(undefined as unknown as US0);
    return 0;
}
process.exitCode = main();
