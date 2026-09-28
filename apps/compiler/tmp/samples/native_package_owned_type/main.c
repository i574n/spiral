#include <stdint.h>

typedef struct {
    int32_t v0;
    int32_t v1;
} Tuple0;

static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}

int32_t TupleSum0(Tuple0 v0){
    return v0.v0 + v0.v1;
}

int32_t method0(Tuple0 v0){
    return TupleSum0(v0);
}

int32_t main(){
    Tuple0 v0;
    v0 = TupleCreate0(19l, 23l);
    return method0(v0);
}
