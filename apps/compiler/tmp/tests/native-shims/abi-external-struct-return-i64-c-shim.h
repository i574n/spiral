#include <stdlib.h>
#include <stdint.h>
static inline int64_t spiral_abi_libc_lldiv_pack(int64_t numerator, int64_t denominator) {
    lldiv_t result = lldiv((long long)numerator, (long long)denominator);
    return (int64_t)(result.quot * (long long)denominator + result.rem);
}
