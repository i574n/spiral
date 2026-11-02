export function array_new(size, fill) { return new Array(size).fill(fill); }
export function array_get(store, i) { return store[i]; }
export function array_set(store, i, value) { store[i] = value; }
export function ref_new(value) { return { value }; }
export function ref_get(ref) { return ref.value; }
export function ref_set(ref, value) { ref.value = value; }
