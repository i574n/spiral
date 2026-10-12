#ifndef SPIRAL_DYNAMIC_ARRAY_RESERVE_ZERO_C_SHIM_V27
#define SPIRAL_DYNAMIC_ARRAY_RESERVE_ZERO_C_SHIM_V27
#include <stdint.h>
#include <stdlib.h>
#include <string.h>

static uint32_t spiral_capacity0_v27 = 0;

#define DynamicArrayReserve0(raw, requested_capacity) do { \
    int32_t spiral_requested_v27 = (int32_t)(requested_capacity); \
    if ((raw) == NULL || spiral_requested_v27 < 0) abort(); \
    if ((uint32_t)spiral_requested_v27 > spiral_capacity0_v27) { \
        uint32_t spiral_old_len_v27 = (raw)->len; \
        void *spiral_reallocated_v27 = realloc((raw), sizeof(*(raw)) + sizeof((raw)->ptr[0]) * (uint32_t)spiral_requested_v27); \
        if (spiral_reallocated_v27 == NULL) abort(); \
        (raw) = spiral_reallocated_v27; \
        memset((raw)->ptr + spiral_old_len_v27, 0, sizeof((raw)->ptr[0]) * ((uint32_t)spiral_requested_v27 - spiral_old_len_v27)); \
        spiral_capacity0_v27 = (uint32_t)spiral_requested_v27; \
    } \
} while (0)

#define DynamicArrayResize0(raw, new_len) do { \
    int32_t spiral_len_v27 = (int32_t)(new_len); \
    if ((raw) == NULL || spiral_len_v27 < 0 || (uint32_t)spiral_len_v27 > spiral_capacity0_v27) abort(); \
    if ((uint32_t)spiral_len_v27 < (raw)->len) \
        memset((raw)->ptr + spiral_len_v27, 0, sizeof((raw)->ptr[0]) * ((raw)->len - (uint32_t)spiral_len_v27)); \
    (raw)->len = (uint32_t)spiral_len_v27; \
} while (0)

#define DynamicArrayCapacity0(raw) ((void)(raw), (int32_t)spiral_capacity0_v27)
#endif