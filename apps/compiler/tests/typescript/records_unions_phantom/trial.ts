declare const p: M_main.point;
const px: number = p.x;
// @ts-expect-error
const pz: number = p.z;
const circle: M_main.shape = { tag: "Circle", v0: 1.5 };
const empty: M_main.shape = { tag: "Empty" };
// @ts-expect-error
const wrong_case: M_main.shape = { tag: "Triangle", v0: 1 };
// @ts-expect-error
const wrong_payload: M_main.shape = { tag: "Circle", v0: "big" };
const cell_value: M_main.cell<string> = { value: "x", label: "y" };
// @ts-expect-error
const cell_wrong: M_main.cell<string> = { value: 1, label: "y" };
declare const m: M_main.meters;
const m2: M_main.meters = m;
// @ts-expect-error
const as_feet: M_main.feet = m;
declare const q_m: M_main.quantity<"meters">;
const q_m2: M_main.quantity<"meters"> = q_m;
// @ts-expect-error
const q_f: M_main.quantity<"feet"> = q_m;
const just: M_main.maybe<number> = { tag: "Just", v0: 1 };
// @ts-expect-error
const just_wrong: M_main.maybe<number> = { tag: "Just", v0: "1" };
const both: M_main.pair_of<number, string> = { first: 1, second: "s" };
// @ts-expect-error
const both_swapped: M_main.pair_of<number, string> = { first: "s", second: 1 };
declare const r: M_main.row;
const big: M_main.maybe<bigint> = r.size;
// @ts-expect-error
const not_big: M_main.maybe<number> = r.size;
