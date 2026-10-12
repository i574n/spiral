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
        } case1; // Some
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
US0 US0_None() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Some(int32_t v0) { // Some
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline void ArrayDecrefBody0(Array0 * x){
    uint32_t len = x->len;
    US0 * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        US0 v = ptr[i];
        USDecref0(&(v));
    }
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
        for (uint32_t i=0; i < len; i++){
            US0 v = ptr[i];
            USIncref0(&(v));
        }
    return x;
}
static inline void AssignArray0(US0 * a, US0 b){
    USIncref0(&(b));
    USDecref0(&(*a));
    *a = b;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 2l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    
    
    int32_t v2;
    v2 = 7l;
    
    
    US0 v3;
    v3 = US0_Some(v2);
    
    
    
    AssignArray0(&(v1->ptr[0l]), v3);
    
    USDecref0(&(v3));
    US0 v4;
    v4 = US0_None();
    
    
    
    AssignArray0(&(v1->ptr[1l]), v4);
    
    USDecref0(&(v4));
    US0 v5;
    v5 = v1->ptr[0l];
    USIncref0(&(v5));
    
    switch (v5.tag) {
        case 0: { // None
            
            
            ArrayDecref0(v1); USDecref0(&(v5));
            return 1l;
            break;
        }
        case 1: { // Some
            int32_t v6 = v5.case1.v0;
            
            USDecref0(&(v5));
            US0 v7;
            v7 = v1->ptr[1l];
            USIncref0(&(v7));
            ArrayDecref0(v1);
            switch (v7.tag) {
                case 0: { // None
                    
                    
                    USDecref0(&(v7));
                    bool v8;
                    v8 = v6 == 7l;
                    
                    
                    if (v8){
                        
                        
                        return 0l;
                    } else {
                        
                        
                        return 1l;
                    }
                    break;
                }
                case 1: { // Some
                    
                    
                    USDecref0(&(v7));
                    return 1l;
                    break;
                }
            }
            break;
        }
    }
}
