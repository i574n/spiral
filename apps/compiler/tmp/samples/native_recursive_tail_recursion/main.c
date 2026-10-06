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
        } case1; // Box
    };
};
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 1: {
            UHDecref0(x->case1.v1);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0() { // Empty
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH0 * UH0_1(int32_t v0, UH0 * v1) { // Box
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
UH0 * method1(int32_t v0);
UH0 * method2(int32_t v0){
    
    
    int32_t v1;
    v1 = v0 - 1l;
    
    
    bool v2;
    v2 = v1 == 0l;
    
    
    if (v2){
        
        
        UH0 * v3;
        v3 = UH0_0();
        
        
        return UH0_1(7l, v3);
    } else {
        
        
        return method1(v1);
    }
}
UH0 * method1(int32_t v0){
    
    
    int32_t v1;
    v1 = v0 - 1l;
    
    
    bool v2;
    v2 = v1 == 0l;
    
    
    if (v2){
        
        
        UH0 * v3;
        v3 = UH0_0();
        
        
        return UH0_1(11l, v3);
    } else {
        
        
        return method2(v1);
    }
}
UH0 * method0(){
    
    
    int32_t v0;
    v0 = 1000000l;
    
    
    bool v1;
    v1 = v0 == 0l;
    
    
    if (v1){
        
        
        UH0 * v2;
        v2 = UH0_0();
        
        
        return UH0_1(7l, v2);
    } else {
        
        
        return method1(v0);
    }
}
int32_t main(){
    
    
    UH0 * v0;
    v0 = method0();
    
    
    switch (v0->tag) {
        case 1: { // Box
            int32_t v1 = v0->case1.v0;
            
            UHDecref0(v0);
            bool v3;
            v3 = v1 == 7l;
            
            
            if (v3){
                
                
                return 0l;
            } else {
                
                
                return 3l;
            }
            break;
        }
        case 0: { // Empty
            
            
            UHDecref0(v0);
            return 1l;
            break;
        }
    }
}
