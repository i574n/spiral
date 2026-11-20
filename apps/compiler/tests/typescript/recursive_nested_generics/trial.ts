const leaf: M_main.tree<number> = { tag: "Leaf", v0: 1 };
const node: M_main.tree<number> = { tag: "Node", v0: [leaf, { tag: "Leaf", v0: 2 }] };
// @ts-expect-error
const bad_payload: M_main.tree<number> = { tag: "Node", v0: [leaf, { tag: "Leaf", v0: "2" }] };
// @ts-expect-error
const bad_arity: M_main.tree<number> = { tag: "Node", v0: [leaf] };
const nested: M_main.labelled<M_main.tree<string>> = { label: "x", item: { tag: "Leaf", v0: "y" } };
// @ts-expect-error
const nested_wrong: M_main.labelled<M_main.tree<string>> = { label: "x", item: { tag: "Leaf", v0: 1 } };
const chain: M_main.chain = { tag: "Link", v0: [1, { tag: "End" }] };
// @ts-expect-error
const chain_bad: M_main.chain = { tag: "Link", v0: [1, { tag: "Stop" }] };
