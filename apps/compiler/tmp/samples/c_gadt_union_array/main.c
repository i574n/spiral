#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
            int32_t v1;
        } case0; // Living
    };
} US0;
typedef struct {
    int refc;
    uint32_t len;
    US0 ptr[];
} Array0;
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_Living(int32_t v0, int32_t v1) { // Living
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1;
    return x;
}
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(US0) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, US0 * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(US0) * len);
    return x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, true);
    
    ArrayDecref0(v1);
    return 0l;
}
