#include <stdint.h>

RustGlobal(StringLit(0, "#[inline]\nfn spiral_global_value() -> i32 {\n    47\n}\n\n#[cfg(test)]\nmod spiral_generated_tests {\n    #[test]\n    fn rust_global_payload_runs() {\n        assert_eq!(super::spiral_global_value(), 47);\n    }\n}\n"));

int32_t main() {
    return spiral_global_value();
}
