const eps: M_main.ev<M_main.yes> = { tag: "Eps" };
const not_no: M_main.ev<M_main.yes> = { tag: "NotNo", v0: { tag: "Never" } };
const never: M_main.ev<M_main.no> = { tag: "Never" };
// @ts-expect-error
const eps_as_no: M_main.ev<M_main.no> = { tag: "Eps" };
// @ts-expect-error
const not_no_bad: M_main.ev<M_main.yes> = { tag: "NotNo", v0: { tag: "Eps" } };
const leaf: M_main.tree<number> = { tag: "Leaf" };
const node: M_main.tree<number> = { tag: "Node", v0: [leaf, leaf] };
// @ts-expect-error
const node_bad: M_main.tree<number> = { tag: "Node", v0: [leaf, { tag: "Nope" }] };
