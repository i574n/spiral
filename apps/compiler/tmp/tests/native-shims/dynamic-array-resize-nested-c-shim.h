#ifndef SPIRAL_DYNAMIC_ARRAY_RESIZE_NESTED_C_SHIM_V27
#define SPIRAL_DYNAMIC_ARRAY_RESIZE_NESTED_C_SHIM_V27
#include <stdint.h>
#include <stdlib.h>

#define DynamicArrayResize0(raw, new_len) do { \
    int32_t spiral_len0_v27 = (int32_t)(new_len); \
    if ((raw) == NULL || spiral_len0_v27 < 0 || spiral_len0_v27 > 1) abort(); \
    if ((uint32_t)spiral_len0_v27 < (raw)->len) (raw)->ptr[0] = NULL; \
    (raw)->len = (uint32_t)spiral_len0_v27; \
} while (0)

#define DynamicArrayResize1(raw, new_len) do { \
    int32_t spiral_len1_v27 = (int32_t)(new_len); \
    if ((raw) == NULL || spiral_len1_v27 < 0 || spiral_len1_v27 > 1) abort(); \
    if ((uint32_t)spiral_len1_v27 < (raw)->len) (raw)->ptr[0] = 0; \
    (raw)->len = (uint32_t)spiral_len1_v27; \
} while (0)

#define DynamicArrayCapacity0(raw) ((void)(raw), 1)
#define DynamicArrayCapacity1(raw) ((void)(raw), 1)
#endif