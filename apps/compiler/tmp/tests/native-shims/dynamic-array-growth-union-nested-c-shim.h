#ifndef SPIRAL_DYNAMIC_ARRAY_GROWTH_UNION_NESTED_C_SHIM_V30
#define SPIRAL_DYNAMIC_ARRAY_GROWTH_UNION_NESTED_C_SHIM_V30
#include <stdint.h>
#include <stdlib.h>

static void * spiral_growth_inner_v30 = NULL;
static int32_t spiral_growth_capacity_v30 = 0;

#define DynamicArrayReserve1(raw, requested_capacity) do { \
    int32_t spiral_requested_v30 = (int32_t)(requested_capacity); \
    if ((raw) == NULL || spiral_requested_v30 < 0) abort(); \
    if (spiral_growth_inner_v30 != (void *)(raw)) { \
        spiral_growth_inner_v30 = (void *)(raw); \
        spiral_growth_capacity_v30 = (int32_t)((raw)->len); \
    } \
    if (spiral_requested_v30 > spiral_growth_capacity_v30) { \
        int32_t spiral_target_v30 = spiral_growth_capacity_v30; \
        if (spiral_target_v30 < 1) spiral_target_v30 = 1; \
        while (spiral_target_v30 < spiral_requested_v30) { \
            if (spiral_target_v30 > INT32_MAX / 2) { \
                spiral_target_v30 = spiral_requested_v30; \
                break; \
            } \
            spiral_target_v30 *= 2; \
        } \
        spiral_growth_capacity_v30 = spiral_target_v30; \
    } \
} while (0)

#define DynamicArrayCapacity1(raw) \
    ((spiral_growth_inner_v30 == (void *)(raw)) ? spiral_growth_capacity_v30 : (int32_t)((raw)->len))
#define DynamicArrayRefCount1(raw) ((raw) == NULL ? 0 : (raw)->refc)

#define DynamicArrayResize0(raw, new_length) do { \
    int32_t spiral_outer_len_v30 = (int32_t)(new_length); \
    if ((raw) == NULL || spiral_outer_len_v30 < 0 || spiral_outer_len_v30 > 1) abort(); \
    if ((uint32_t)spiral_outer_len_v30 < (raw)->len) { \
        if ((raw)->ptr[0] != NULL) ArrayDecref0((raw)->ptr[0]); \
        (raw)->ptr[0] = NULL; \
    } else if ((uint32_t)spiral_outer_len_v30 > (raw)->len) { \
        (raw)->ptr[0] = NULL; \
    } \
    (raw)->len = (uint32_t)spiral_outer_len_v30; \
} while (0)

#endif
