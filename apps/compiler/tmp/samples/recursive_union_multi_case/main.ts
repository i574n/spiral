type UH0_Leaf = { readonly tag: 0 };
type UH0_Marker = { readonly tag: 1 };
type UH0_Node = { readonly tag: 2, readonly f0: number, readonly f1: UH0, readonly f2: UH0 };
type UH0 = UH0_Leaf | UH0_Marker | UH0_Node;
const UH0_Leaf_shared: UH0 = { tag: 0 }; function UH0_Leaf(): UH0 { return UH0_Leaf_shared; }
const UH0_Marker_shared: UH0 = { tag: 1 }; function UH0_Marker(): UH0 { return UH0_Marker_shared; }
function UH0_Node(f0: number, f1: UH0, f2: UH0): UH0 { return { tag: 2, f0: f0, f1: f1, f2: f2 }; }
function sum_0(v0: UH0): number {
    switch (v0.tag) {
        case 0: {
            return 0;
        }
        case 1: {
            return 0;
        }
        case 2: {
            const v1: number = v0.f0;
            const v2: UH0 = v0.f1;
            const v3: UH0 = v0.f2;
            const v4: number = sum_0(v2);
            const v5: number = sum_0(v3);
            const v6: number = (v4 + v5) | 0;
            const v7: number = (v1 + v6) | 0;
            return v7;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: number = 1;
    const v1: number = 2;
    const v2: UH0 = UH0_Leaf();
    const v3: UH0 = UH0_Marker();
    const v4: UH0 = UH0_Node(v1, v2, v3);
    const v5: UH0 = UH0_Node(v0, v4, v4);
    const v6: number = sum_0(v5);
    const v7: number = (v6 - 5) | 0;
    return v7;
}
process.exitCode = main();
