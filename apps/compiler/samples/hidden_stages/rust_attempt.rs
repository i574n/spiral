trait Policy {
    type State;
    fn start(&self) -> Self::State;
    fn step(&self, state: Self::State, amount: i32) -> (Self::State, i32);
}

struct Cap;
struct Unique;

impl Policy for Cap {
    type State = i32;
    fn start(&self) -> i32 { 0 }
    fn step(&self, spent: i32, amount: i32) -> (i32, i32) { if spent + amount > 120 { (spent, 0) } else { (spent + amount, amount) } }
}

impl Policy for Unique {
    type State = Vec<i32>;
    fn start(&self) -> Vec<i32> { Vec::new() }
    fn step(&self, mut seen: Vec<i32>, amount: i32) -> (Vec<i32>, i32) { if seen.contains(&amount) { (seen, 0) } else { seen.push(amount); (seen, amount) } }
}

fn main() {
    let policies: Vec<Box<dyn Policy>> = vec![Box::new(Cap), Box::new(Unique)];
    std::process::exit(policies.len() as i32);
}
