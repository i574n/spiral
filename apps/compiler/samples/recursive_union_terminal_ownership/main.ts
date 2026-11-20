type UH0_Leaf = { readonly tag: 0 };
type UH0_Node = { readonly tag: 1, readonly f0: number, readonly f1: UH0, readonly f2: UH0 };
type UH0 = UH0_Leaf | UH0_Node;
const UH0_Leaf_shared: UH0 = { tag: 0 }; function UH0_Leaf(): UH0 { return UH0_Leaf_shared; }
function UH0_Node(f0: number, f1: UH0, f2: UH0): UH0 { return { tag: 1, f0: f0, f1: f1, f2: f2 }; }
function sum_1(v0: UH0): number {
    switch (v0.tag) {
        case 0: {
            return 0;
        }
        case 1: {
            const v1: number = v0.f0;
            const v2: UH0 = v0.f1;
            const v3: UH0 = v0.f2;
            const v4: number = sum_1(v2);
            const v5: number = sum_1(v3);
            const v6: number = (v4 + v5) | 0;
            const v7: number = (v1 + v6) | 0;
            return v7;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function consume_pair_0(v0: UH0, v1: UH0): number {
    const v2: number = sum_1(v0);
    const v3: number = sum_1(v1);
    const v4: number = (v2 + v3) | 0;
    return v4;
}
export function main(): number {
    const v0: number = 1;
    const v1: number = 2;
    const v2: UH0 = UH0_Leaf();
    const v3: UH0 = UH0_Node(v1, v2, v2);
    const v4: UH0 = UH0_Node(v0, v3, v3);
    const v5: number = 1;
    const v6: number = 2;
    const v7: UH0 = UH0_Leaf();
    const v8: UH0 = UH0_Node(v6, v7, v7);
    const v9: UH0 = UH0_Node(v5, v8, v8);
    const v10: number = consume_pair_0(v4, v9);
    const v11: number = (v10 - 10) | 0;
    return v11;
}
process.exitCode = main();
