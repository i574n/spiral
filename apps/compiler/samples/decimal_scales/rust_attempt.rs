use std::marker::PhantomData;

struct Brl;
struct Litre;

struct Amount<C, const S: u32>(i64, PhantomData<C>);
struct Qty<U, const S: u32>(i64, PhantomData<U>);

fn times<U, C, const S1: u32, const S2: u32>(q: Qty<U, S1>, p: Amount<C, S2>) -> Amount<C, { S1 + S2 }> {
    Amount(q.0 * p.0, PhantomData)
}

fn main() {
    let litres: Qty<Litre, 4> = Qty(425000, PhantomData);
    let price: Amount<Brl, 10> = Amount(17350000000, PhantomData);
    let product = times(litres, price);
    std::process::exit((product.0 / 1_000_000_000_000) as i32);
}
