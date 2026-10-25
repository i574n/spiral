#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    double v0;
    double v1;
} Tuple0;
static inline Tuple0 TupleCreate0(double v0, double v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static Tuple0 method0(int32_t v0){
    bool v1 = v0 == 0l;
    if (v1){
        return TupleCreate0(0.0, 0.0);
    } else {
        return TupleCreate0(1.5, 2.5);
    }
}
int32_t main(){
    int32_t v0 = 7l;
    double v1; double v2;
    Tuple0 tmp0 = method0(v0);
    v1 = tmp0.v0; v2 = tmp0.v1;
    bool v3 = v1 == 1.5;
    bool v5;
    if (v3){
        bool v4 = v2 == 2.5;
        v5 = v4;
    } else {
        v5 = false;
    }
    if (v5){
        return 0l;
    } else {
        return 1l;
    }
}
