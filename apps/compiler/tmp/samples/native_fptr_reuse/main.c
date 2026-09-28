#include <stdint.h>
typedef int32_t (*SpiralFptr0)(int32_t);
static int32_t f(int32_t value){
    return value + 2;
}
int32_t main(void){
    SpiralFptr0 p = f;
    int32_t a = p(19);
    int32_t b = p(19);
    return a + b;
}
