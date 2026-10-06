#ifndef SPIRAL_DYNAMIC_ARRAY_RESIZE_UNION_MANAGED_C_SHIM
#define SPIRAL_DYNAMIC_ARRAY_RESIZE_UNION_MANAGED_C_SHIM
#include <stdint.h>
#include <stdlib.h>
#include <string.h>
#include <malloc.h>

static uint32_t spiral_capacity_string_or_union = 2;

/* Elements the array's block really holds: Reserve only records a capacity, so a shrink must not clear past the
   allocation (writing there corrupted the heap: exit 0xC0000374 on most runs). */
#if defined(_WIN32)
#define SPIRAL_ALLOCATED_ELEMS(raw) ((uint32_t)((_msize(raw) - sizeof(*(raw))) / sizeof((raw)->ptr[0])))
#else
#define SPIRAL_ALLOCATED_ELEMS(raw) ((uint32_t)((malloc_usable_size(raw) - sizeof(*(raw))) / sizeof((raw)->ptr[0])))
#endif

#define DynamicArrayReserve0(raw, requested_capacity) do { \
    int32_t spiral_requested_capacity = (int32_t)(requested_capacity); \
    if ((raw) == NULL || spiral_requested_capacity < 0) abort(); \
    if ((uint32_t)spiral_requested_capacity > spiral_capacity_string_or_union) \
        spiral_capacity_string_or_union = (uint32_t)spiral_requested_capacity; \
} while (0)

#define DynamicArrayResize0(raw, new_len) do { \
    int32_t spiral_requested_length = (int32_t)(new_len); \
    if ((raw) == NULL || spiral_requested_length < 0 || (uint32_t)spiral_requested_length > spiral_capacity_string_or_union) abort(); \
    uint32_t spiral_clear_end = (raw)->len < SPIRAL_ALLOCATED_ELEMS(raw) ? (raw)->len : SPIRAL_ALLOCATED_ELEMS(raw); \
    if ((uint32_t)spiral_requested_length < spiral_clear_end) \
        memset((raw)->ptr + spiral_requested_length, 0, sizeof((raw)->ptr[0]) * (spiral_clear_end - (uint32_t)spiral_requested_length)); \
    (raw)->len = (uint32_t)spiral_requested_length; \
} while (0)

#define DynamicArrayCapacity0(raw) ((void)(raw), (int32_t)spiral_capacity_string_or_union)
#define DynamicArrayRefCount0(raw) ((raw) == NULL ? 0 : (raw)->refc)
#endif
