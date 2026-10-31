fn main() { let code = match xc::xc_decide(12) { xc::command::command_Add(n) => n, xc::command::command_Rename(_) => 1, xc::command::command_Clear => 2 }; std::process::exit(code); }
