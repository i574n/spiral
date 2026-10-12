#ifndef SPIRAL_ABI_EXTERNAL_CONST_BUFFER_C_SHIM_H
#define SPIRAL_ABI_EXTERNAL_CONST_BUFFER_C_SHIM_H
#define spiral_abi_libc_memcmp(left, right, count) \
    (((count) < 0 || (uint32_t)(count) > (left)->len || (uint32_t)(count) > (right)->len) \
        ? (abort(), 0) \
        : memcmp((left)->ptr, (right)->ptr, (size_t)(count)))
#endif