#include <complex.h>
#include <stdint.h>
#include <stdlib.h>

static int32_t spiral_abi_libm_cabs_pack(int32_t real_value, int32_t imaginary_value) {
    double complex value = (double)real_value + (double)imaginary_value * I;
    double magnitude = cabs(value);
    if (!(magnitude >= 0.0) || magnitude > (double)INT32_MAX) abort();
    int32_t result = (int32_t)magnitude;
    if ((double)result != magnitude) abort();
    return result;
}
