#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct {
    int refc;
    String * v1;
    int32_t v0;
} Heap0;
typedef struct {
    int tag;
    union {
        struct {
            Heap0 * v0;
            Heap0 * v1;
        } case1; // Held
    };
} US0;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
static inline void HeapDecrefBody0(Heap0 * x){
    StringDecref(x->v1);
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(int32_t v0, String * v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++; (x->case1.v1)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            HeapDecref0(x->case1.v0); HeapDecref0(x->case1.v1);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_None() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Held(Heap0 * v0, Heap0 * v1) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // Held
            Heap0 * v1 = v0.case1.v0; Heap0 * v2 = v0.case1.v1;
            (v1)->refc++; (v2)->refc++;
            USDecref0(&(v0));
            int32_t v3; String * v4;
            v3 = v1->v0; v4 = v1->v1;
            (v4)->refc++;
            HeapDecref0(v1);
            int32_t v5; String * v6;
            v5 = v2->v0; v6 = v2->v1;
            (v6)->refc++;
            HeapDecref0(v2);
            bool v7;
            v7 = v3 == 7l;
            
            
            bool v9;
            if (v7){
                
                
                bool v8;
                v8 = strcmp(v4->ptr, "hi") == 0;
                
                
                v9 = v8;
            } else {
                
                
                v9 = false;
            }
            
            StringDecref(v4);
            bool v11;
            if (v9){
                
                
                bool v10;
                v10 = v5 == 4l;
                
                
                v11 = v10;
            } else {
                
                
                v11 = false;
            }
            
            
            bool v13;
            if (v11){
                
                
                bool v12;
                v12 = strcmp(v6->ptr, "yo") == 0;
                
                
                v13 = v12;
            } else {
                
                
                v13 = false;
            }
            
            StringDecref(v6);
            if (v13){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
        default: { // None
            
            
            USDecref0(&(v0));
            return 1l;
            break;
        }
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    String * v1;
    v1 = StringLit(3, "hi");
    (v1)->refc++;
    
    Heap0 * v2;
    v2 = HeapCreate0(v0, v1);
    
    StringDecref(v1);
    int32_t v3;
    v3 = 4l;
    
    
    String * v4;
    v4 = StringLit(3, "yo");
    (v4)->refc++;
    
    Heap0 * v5;
    v5 = HeapCreate0(v3, v4);
    
    StringDecref(v4);
    bool v6;
    v6 = true;
    
    
    US0 v9;
    if (v6){
        (v2)->refc++; (v5)->refc++;
        
        v9 = US0_Held(v2, v5);
    } else {
        
        
        v9 = US0_None();
    }
    
    HeapDecref0(v2); HeapDecref0(v5);
    return score0(v9);
}
