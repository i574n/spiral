#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array1;
typedef Array1 String;
typedef struct {
    int tag;
    union {
        struct {
            String * v0;
            String * v1;
        } case1; // Both
    };
} US0;
typedef struct {
    int refc;
    uint32_t len;
    US0 ptr[];
} Array0;
static inline void ArrayDecrefBody1(Array1 * x){
    (void)x;
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(char) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, char * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref1(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit1(len, ptr);
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
            StringDecref(x->case1.v0); StringDecref(x->case1.v1);
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
US0 US0_Both(String * v0, String * v1) { // Both
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
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
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // Both
            String * v1 = v0.case1.v0; String * v2 = v0.case1.v1;
            (v1)->refc++; (v2)->refc++;
            USDecref0(&(v0));
            bool v3;
            v3 = strcmp(v1->ptr, "hi") == 0;
            
            StringDecref(v1);
            bool v5;
            if (v3){
                
                
                bool v4;
                v4 = strcmp(v2->ptr, "yo") == 0;
                
                
                v5 = v4;
            } else {
                
                
                v5 = false;
            }
            
            StringDecref(v2);
            if (v5){
                
                
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
    
    
    Array0 * v0;
    v0 = ArrayCreate0(1l, true);
    
    
    String * v1;
    v1 = StringLit(3, "hi");
    
    
    String * v2;
    v2 = StringLit(3, "yo");
    
    
    bool v3;
    v3 = true;
    
    
    US0 v6;
    if (v3){
        (v1)->refc++; (v2)->refc++;
        
        v6 = US0_Both(v1, v2);
    } else {
        
        
        v6 = US0_None();
    }
    
    StringDecref(v1); StringDecref(v2);
    
    AssignArray0(&(v0->ptr[0l]), v6);
    
    USDecref0(&(v6));
    US0 v7;
    v7 = v0->ptr[0l];
    USIncref0(&(v7));
    ArrayDecref0(v0);
    return score0(v7);
}
