#include <stdlib.h>
static inline int spiral_abi_libc_div_pack(int numerator, int denominator) {
    div_t result = div(numerator, denominator);
    return result.quot * 10 + result.rem;
}
