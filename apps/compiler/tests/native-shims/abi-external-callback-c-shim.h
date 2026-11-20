#ifndef SPIRAL_ABI_EXTERNAL_CALLBACK_C_SHIM_H
#define SPIRAL_ABI_EXTERNAL_CALLBACK_C_SHIM_H

#include <stdint.h>
#include <stdlib.h>

static int spiral_libc_compare_i32_c(const void *left_value, const void *right_value) {
    const int32_t left = *(const int32_t *)left_value;
    const int32_t right = *(const int32_t *)right_value;
    return (left > right) - (left < right);
}

static int32_t spiral_abi_libc_qsort3_pack(int32_t first, int32_t second, int32_t third) {
    int32_t values[3] = {first, second, third};
    qsort(values, 3, sizeof(int32_t), spiral_libc_compare_i32_c);
    return values[0] * 100 + values[1] * 10 + values[2];
}

#endif
