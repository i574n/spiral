#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    UH0 * (*fptr)(Fun0 *);
};
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            uint64_t v0;
            Fun0 * v1;
        } case0; // Cons
    };
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    UH0 * (*fptr)(Closure0 *);
    uint64_t v0;
};
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 0: {
            x->case0.v1->decref_fptr(x->case0.v1);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0(uint64_t v0, Fun0 * v1) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0; x->case0.v1 = v1;
    return x;
}
UH0 * UH0_1() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
UH0 * build0(uint64_t v0);
static inline void ClosureDecrefBody0(Closure0 * x){
    
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
UH0 * ClosureMethod0(Closure0 * x){
    uint64_t v0 = x->v0;
    
    ClosureDecref0(x);
    
    
    uint64_t v1;
    v1 = v0 - 1ull;
    
    
    return build0(v1);
}
Fun0 * ClosureCreate0(uint64_t v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    x->v0 = v0;
    return (Fun0 *) x;
}
UH0 * build0(uint64_t v0){
    
    
    bool v1;
    v1 = v0 == 0ull;
    
    
    if (v1){
        
        
        return UH0_1();
    } else {
        
        
        Fun0 * v3;
        v3 = ClosureCreate0(v0);
        
        
        return UH0_0(v0, v3);
    }
}
uint64_t sum1(UH0 * v0, uint64_t v1){
    
    
    switch (v0->tag) {
        case 0: { // Cons
            uint64_t v2 = v0->case0.v0; Fun0 * v3 = v0->case0.v1;
            v3->refc += 2;
            UHDecref0(v0);
            UH0 * v4;
            v4 = v3->fptr(v3);
            
            v3->decref_fptr(v3);
            uint64_t v5;
            v5 = v1 + v2;
            
            
            return sum1(v4, v5);
            break;
        }
        case 1: { // Nil
            
            
            UHDecref0(v0);
            return v1;
            break;
        }
    }
}
int32_t main(){
    
    
    uint64_t v0;
    v0 = 10ull;
    
    
    UH0 * v1;
    v1 = build0(v0);
    
    
    uint64_t v2;
    v2 = 0ull;
    v1->refc++;
    
    uint64_t v3;
    v3 = sum1(v1, v2);
    
    UHDecref0(v1);
    int32_t v4;
    v4 = 5l;
    
    
    int32_t v5;
    v5 = (int32_t)v3;
    
    
    int32_t v6;
    v6 = v4 * 2l;
    
    
    int32_t v7;
    v7 = v4 + v6;
    
    
    int32_t v8;
    v8 = v5 + v7;
    
    
    return v8;
}
