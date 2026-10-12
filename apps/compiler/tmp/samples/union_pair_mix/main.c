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
        } case1; // Both
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
US0 US0_Both(int32_t v0, String * v1) { // Both
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // Both
            int32_t v2 = v0.case1.v0; String * v3 = v0.case1.v1;
            (v3)->refc++;
            USDecref0(&(v0));
            bool v4;
            v4 = v2 == 3l;
            
            
            bool v6;
            if (v4){
                
                
                bool v5;
                v5 = strcmp(v3->ptr, "hi") == 0;
                
                
                v6 = v5;
            } else {
                
                
                v6 = false;
            }
            
            StringDecref(v3);
            if (v6){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
        case 0: { // One
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
    v1 = 3l;
    
    
    String * v2;
    v2 = StringLit(3, "hi");
    
    
    US0 v5;
    if (v0){
        (v2)->refc++;
        
        v5 = US0_Both(v1, v2);
    } else {
        
        
        v5 = US0_One(1l);
    }
    
    StringDecref(v2);
    return score0(v5);
}
