#ifndef SPIRAL_DYNAMIC_ARRAY_GEOMETRIC_GROWTH_C_SHIM
#define SPIRAL_DYNAMIC_ARRAY_GEOMETRIC_GROWTH_C_SHIM
#include <stdint.h>
#include <stdlib.h>
#include <string.h>

static inline uint32_t spiral_next_capacity(uint32_t current, uint32_t requested) {
    uint32_t target = current > 0 ? current : 1;
    while (target < requested) {
        if (target > UINT32_MAX / 2u) return requested;
        target *= 2u;
    }
    return target;
}

static uint32_t spiral_capacity0 = 0;

#define DynamicArrayReserve0(raw, requested_capacity) do { \
    int32_t spiral_requested = (int32_t)(requested_capacity); \
    if ((raw) == NULL || spiral_requested < 0) abort(); \
    if ((uint32_t)spiral_requested > spiral_capacity0) \
        spiral_capacity0 = spiral_next_capacity(spiral_capacity0, (uint32_t)spiral_requested); \
} while (0)

#define DynamicArrayCapacity0(raw) ((void)(raw), (int32_t)spiral_capacity0)
#define DynamicArrayRefCount0(raw) ((raw) == NULL ? 0 : (raw)->refc)

typedef struct {
    const void *key;
    uint32_t capacity;
} SpiralCapacitySlot1;

static SpiralCapacitySlot1 spiral_capacity_slots1[16];

static inline uint32_t *spiral_capacity_for1(const void *key, uint32_t initial) {
    if (key == NULL) abort();
    for (uint32_t i = 0; i < 16u; ++i) {
        if (spiral_capacity_slots1[i].key == key) return &spiral_capacity_slots1[i].capacity;
    }
    for (uint32_t i = 0; i < 16u; ++i) {
        if (spiral_capacity_slots1[i].key == NULL) {
            spiral_capacity_slots1[i].key = key;
            spiral_capacity_slots1[i].capacity = initial;
            return &spiral_capacity_slots1[i].capacity;
        }
    }
    abort();
}

#define DynamicArrayReserve1(raw, requested_capacity) do { \
    int32_t spiral_requested = (int32_t)(requested_capacity); \
    if ((raw) == NULL || spiral_requested < 0) abort(); \
    uint32_t *spiral_capacity = spiral_capacity_for1((const void *)(raw), (raw)->len); \
    if ((uint32_t)spiral_requested > *spiral_capacity) \
        *spiral_capacity = spiral_next_capacity(*spiral_capacity, (uint32_t)spiral_requested); \
} while (0)

#define DynamicArrayResize1(raw, requested_length) do { \
    int32_t spiral_requested = (int32_t)(requested_length); \
    if ((raw) == NULL || spiral_requested < 0) abort(); \
    uint32_t spiral_old_length = (raw)->len; \
    uint32_t spiral_new_length = (uint32_t)spiral_requested; \
    uint32_t *spiral_capacity = spiral_capacity_for1((const void *)(raw), spiral_old_length); \
    if (spiral_new_length > *spiral_capacity) \
        *spiral_capacity = spiral_next_capacity(*spiral_capacity, spiral_new_length); \
    if (spiral_new_length < spiral_old_length) \
        memset((raw)->ptr + spiral_new_length, 0, sizeof((raw)->ptr[0]) * (spiral_old_length - spiral_new_length)); \
    else if (spiral_new_length > spiral_old_length) \
        memset((raw)->ptr + spiral_old_length, 0, sizeof((raw)->ptr[0]) * (spiral_new_length - spiral_old_length)); \
    (raw)->len = spiral_new_length; \
} while (0)

#define DynamicArrayCapacity1(raw) ((raw) == NULL ? 0 : (int32_t)(*spiral_capacity_for1((const void *)(raw), (raw)->len)))
#define DynamicArrayRefCount1(raw) ((raw) == NULL ? 0 : (raw)->refc)
#endif