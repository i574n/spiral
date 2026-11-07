#include <stdint.h>

int32_t main(){
    int32_t v0;
    int32_t v1;
    int32_t v2;
    String * v3;
    v0 = 20l;
    v1 = 2l;
    v3 = "$0.wrapping_mul($1).wrapping_add(3)";
    v2 = Fable.Core.RustInterop.emitRustExpr TupleCreate2(v0, v1) v3;
    return v2;
}
