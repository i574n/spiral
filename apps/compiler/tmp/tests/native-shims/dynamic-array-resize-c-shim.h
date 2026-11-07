#ifndef SPIRAL_DYNAMIC_ARRAY_RESIZE_C_SHIM_V26
#define SPIRAL_DYNAMIC_ARRAY_RESIZE_C_SHIM_V26
#include <stdint.h>
#include <stdlib.h>

typedef struct {
    int refc;
    uint32_t len;
} SpiralPortableArrayHeaderV26;

#define DynamicArrayResize0(raw, new_len) do { \
    int32_t spiral_resize_len_v26 = (int32_t)(new_len); \
    if ((raw) == NULL || spiral_resize_len_v26 < 0 || spiral_resize_len_v26 > 4) abort(); \
    ((SpiralPortableArrayHeaderV26 *)(raw))->len = (uint32_t)spiral_resize_len_v26; \
} while (0)

static inline int32_t SpiralDynamicArrayCapacity0V26(void *raw) {
    if (raw == NULL) abort();
    return 4;
}

#define DynamicArrayCapacity0(raw) SpiralDynamicArrayCapacity0V26((void *)(raw))
#endif
