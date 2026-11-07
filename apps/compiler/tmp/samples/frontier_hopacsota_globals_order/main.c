#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
// m1
// a1
// c1
// a2
// b1
// m2
static int32_t leaf_c1(){
    return 0l;
}
static int32_t slow_a0(){
    int32_t v0 = leaf_c1();
    return v0;
}
static int32_t fast_b2(){
    return 0l;
}
int32_t main(){
    int32_t v0 = slow_a0();
    int32_t v1 = fast_b2();
    int32_t v2 = v0 + v1;
    return v2;
}
