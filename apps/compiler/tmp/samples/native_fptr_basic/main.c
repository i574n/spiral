#include <stdint.h>
typedef int32_t (*SpiralFptr0)(int32_t);
static int32_t f(int32_t value){
    return value + 2;
}
int32_t main(void){
    int32_t x = 40;
    SpiralFptr0 p = f;
    return p(x);
}
