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
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // One
        struct {
            String * v1;
            int32_t v0;
            bool v2;
        } case1; // All
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
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v1)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            StringDecref(x->case1.v1);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_One(int32_t v0) { // One
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_All(int32_t v0, String * v1, bool v2) { // All
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1; x.case1.v2 = v2;
    return x;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // All
            int32_t v2 = v0.case1.v0; String * v3 = v0.case1.v1; bool v4 = v0.case1.v2;
            (v3)->refc++;
            USDecref0(&(v0));
            bool v5;
            v5 = v2 == 7l;
            
            
            bool v7;
            if (v5){
                
                
                bool v6;
                v6 = strcmp(v3->ptr, "hi") == 0;
                
                
                v7 = v6;
            } else {
                
                
                v7 = false;
            }
            
            StringDecref(v3);
            bool v8;
            v8 = v7 && v4;
            
            
            if (v8){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
        default: { // One
            int32_t v1 = v0.case0.v0;
            
            USDecref0(&(v0));
            return v1;
            break;
        }
    }
}
int32_t main(){
    
    
    bool v0;
    v0 = true;
    
    
    int32_t v1;
    v1 = 7l;
    
    
    String * v2;
    v2 = StringLit(3, "hi");
    
    
    bool v3;
    v3 = true;
    
    
    US0 v6;
    if (v0){
        (v2)->refc++;
        
        v6 = US0_All(v1, v2, v3);
    } else {
        
        
        v6 = US0_One(1l);
    }
    
    StringDecref(v2);
    return score0(v6);
}
