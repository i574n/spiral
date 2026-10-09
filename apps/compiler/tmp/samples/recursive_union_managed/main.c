#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            Array0 * v0;
            UH0 * v1;
        } case1; // Cons
    };
};
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int32_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, int32_t * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 1: {
            ArrayDecref0(x->case1.v0); UHDecref0(x->case1.v1);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_Nil() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH0 * UH0_Cons(Array0 * v0, UH0 * v1) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
int32_t sum0(UH0 * v0){
    
    
    switch (v0->tag) {
        case 1: { // Cons
            Array0 * v1 = v0->case1.v0; UH0 * v2 = v0->case1.v1;
            v1->refc++; v2->refc++;
            UHDecref0(v0);
            int32_t v3;
            v3 = v1->len;
            v2->refc++;
            ArrayDecref0(v1);
            int32_t v4;
            v4 = sum0(v2);
            
            UHDecref0(v2);
            int32_t v5;
            v5 = v3 + v4;
            
            
            return v5;
            break;
        }
        case 0: { // Nil
            
            
            UHDecref0(v0);
            return 0l;
            break;
        }
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 2l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    
    
    UH0 * v2;
    v2 = UH0_Nil();
    v1->refc++; v2->refc++;
    
    UH0 * v3;
    v3 = UH0_Cons(v1, v2);
    v1->refc++; v3->refc++;
    UHDecref0(v2);
    UH0 * v4;
    v4 = UH0_Cons(v1, v3);
    v4->refc++;
    ArrayDecref0(v1); UHDecref0(v3);
    int32_t v5;
    v5 = sum0(v4);
    
    UHDecref0(v4);
    int32_t v6;
    v6 = v5 - 4l;
    
    
    return v6;
}
