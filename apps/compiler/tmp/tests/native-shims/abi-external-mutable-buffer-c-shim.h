#ifndef SPIRAL_ABI_EXTERNAL_MUTABLE_BUFFER_C_SHIM_H
#define SPIRAL_ABI_EXTERNAL_MUTABLE_BUFFER_C_SHIM_H
#define spiral_abi_libc_memset(array, byte_value, count) \
    (((count) < 0 || (uint32_t)(count) > (array)->len) \
        ? (abort(), 0) \
        : (memset((array)->ptr, (byte_value), (size_t)(count)), (count)))
#endif