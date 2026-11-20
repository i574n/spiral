#include <stdint.h>

int32_t main(void) {
    int32_t a = 40;
    int32_t b = 2;
    int32_t c = 1;
    return a | b ^ c & 7 << 1;
}
