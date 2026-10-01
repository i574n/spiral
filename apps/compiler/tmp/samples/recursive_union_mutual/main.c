#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH1 UH1;
void UHDecref1(UH1 * x);
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
struct UH1 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v0;
        } case0; // B
    };
};
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            UH1 * v0;
        } case0; // A
    };
};
static inline void UHDecrefBody1(UH1 * x){
    switch (x->tag) {
        case 0: {
            UHDecref0(x->case0.v0);
            break;
        }
    }
}
void UHDecref1(UH1 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody1(x); free(x); }
}
UH1 * UH1_0(UH0 * v0) { // B
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0;
    return x;
}
UH1 * UH1_1() { // StopB
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 1;
    x->refc = 1;
    return x;
}
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 0: {
            UHDecref1(x->case0.v0);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0(UH1 * v0) { // A
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0;
    return x;
}
UH0 * UH0_1() { // StopA
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
int32_t main(){
    
    
    bool v0;
    v0 = true;
    
    
    UH0 * v5;
    if (v0){
        
        
        UH0 * v1;
        v1 = UH0_1();
        v1->refc++;
        
        UH1 * v2;
        v2 = UH1_0(v1);
        
        UHDecref0(v1);
        v5 = UH0_0(v2);
    } else {
        
        
        v5 = UH0_1();
    }
    
    
    switch (v5->tag) {
        case 1: { // StopA
            
            
            UHDecref0(v5);
            return 0l;
            break;
        }
        case 0: { // A
            
            
            UHDecref0(v5);
            return 0l;
            break;
        }
    }
}
