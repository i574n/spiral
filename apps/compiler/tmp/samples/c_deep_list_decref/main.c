#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v1;
            int32_t v0;
        } case0; // Link
    };
};
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 0: {
            UHDecref0(x->case0.v1);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH0 * next = NULL;
        switch (x->tag) {
            case 0: {
                
                next = x->case0.v1;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH0 * UH0_Link(int32_t v0, UH0 * v1) { // Link
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0; x->case0.v1 = v1;
    return x;
}
UH0 * UH0_End() { // End
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
UH0 * build0(int32_t v0, UH0 * v1){
    while (1) {
        
        
        bool v2;
        v2 = v0 == 0l;
        
        
        if (v2){
            
            
            return v1;
        } else {
            
            
            int32_t v3;
            v3 = v0 - 1l;
            (v1)->refc++;
            
            UH0 * v4;
            v4 = UH0_Link(v0, v1);
            
            UHDecref0(v1);
            {
                int32_t tmp0 = v3;
                UH0 * tmp1 = v4;
                v0 = tmp0;
                v1 = tmp1;
            }
            continue;
        }
    }
}
int32_t sum1(UH0 * v0, int32_t v1){
    while (1) {
        
        
        switch (v0->tag) {
            case 1: { // End
                
                
                UHDecref0(v0);
                return v1;
                break;
            }
            default: { // Link
                int32_t v2 = v0->case0.v0; UH0 * v3 = v0->case0.v1;
                (v3)->refc++;
                UHDecref0(v0);
                int32_t v4;
                v4 = v1 * 31l;
                
                
                int32_t v5;
                v5 = v4 + v2;
                
                
                int32_t v6;
                v6 = v5 % 9973l;
                
                
                {
                    UH0 * tmp2 = v3;
                    int32_t tmp3 = v6;
                    v0 = tmp2;
                    v1 = tmp3;
                }
                continue;
                break;
            }
        }
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1000000l;
    
    
    UH0 * v1;
    v1 = UH0_End();
    (v1)->refc++;
    
    UH0 * v2;
    v2 = build0(v0, v1);
    
    UHDecref0(v1);
    int32_t v3;
    v3 = 0l;
    (v2)->refc++;
    
    int32_t v4;
    v4 = sum1(v2, v3);
    
    UHDecref0(v2);
    int32_t v5;
    v5 = v4 % 256l;
    
    
    return v5;
}
