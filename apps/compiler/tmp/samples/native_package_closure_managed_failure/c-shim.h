#ifndef SPIRAL_PACKAGE_ARRAY_FAILURE_C_SHIM_H
#define SPIRAL_PACKAGE_ARRAY_FAILURE_C_SHIM_H
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
static inline int32_t PortableFail(const char * message) {
    fputs(message, stderr);
    fputc('\n', stderr);
    abort();
}
#endif
