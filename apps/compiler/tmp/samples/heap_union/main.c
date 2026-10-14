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
    US0 v0;
} Heap0;
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
static inline void HeapDecrefBody0(Heap0 * x){
    (void)x;
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(US0 v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    bool v1;
    v1 = true;
    
    
    US0 v4;
    if (v1){
        
        
        v4 = US0_Some(v0);
    } else {
        
        
        v4 = US0_None();
    }
    
    
    Heap0 * v5;
    v5 = HeapCreate0(v4);
    
    
    US0 v6;
    v6 = v5->v0;
    
    HeapDecref0(v5);
    switch (v6.tag) {
        case 0: { // None
            
            
            
            return 1l;
            break;
        }
        default: { // Some
            int32_t v7 = v6.case1.v0;
            
            
            bool v8;
            v8 = v7 == 7l;
            
            
            if (v8){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
    }
}
