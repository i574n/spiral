#ifndef SPIRAL_ABI_EXTERNAL_STRING_C_SHIM_H
#define SPIRAL_ABI_EXTERNAL_STRING_C_SHIM_H
#include <stdint.h>
#include <string.h>
#define spiral_abi_libc_strlen(value) ((int32_t)strlen((value)->ptr))
#endif
