#[derive(Clone)]
struct Invoice {
    number: i32,
    customer: String,
    total_cents: i64,
    paid: bool,
}

fn changes<T>(before: &T, after: &T) -> Vec<String> {
    before.fields().zip(after.fields()).filter(|(a, b)| a.value != b.value).map(|(a, b)| format!("{}: {} -> {}", a.name, a.value, b.value)).collect()
}

fn main() {
    let before = Invoice { number: 7, customer: "Ana".to_string(), total_cents: 1990, paid: false };
    let after = Invoice { total_cents: 2490, paid: true, ..before.clone() };
    std::process::exit(changes(&before, &after).iter().map(|line| line.len() as i32).sum());
}
