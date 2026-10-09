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
            String * v0;
        } case0; // Text
        struct {
            int32_t v0;
        } case1; // Number
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
        case 0: {
            x->case0.v0->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            StringDecref(x->case0.v0);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_Text(String * v0) { // Text
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Number(int32_t v0) { // Number
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // Number
            int32_t v3 = v0.case1.v0;
            
            USDecref0(&(v0));
            return v3;
            break;
        }
        case 0: { // Text
            String * v1 = v0.case0.v0;
            v1->refc++;
            USDecref0(&(v0));
            int32_t v2;
            v2 = v1->len-1;
            
            StringDecref(v1);
            return v2;
            break;
        }
    }
}
int32_t main(){
    
    
    bool v0;
    v0 = false;
    
    
    US0 v4;
    if (v0){
        
        
        v4 = US0_Number(7l);
    } else {
        
        
        String * v2;
        v2 = StringLit(4, "qwe");
        
        
        v4 = US0_Text(v2);
    }
    USIncref0(&(v4));
    
    int32_t v5;
    v5 = score0(v4);
    USIncref0(&(v4));
    
    int32_t v6;
    v6 = score0(v4);
    
    USDecref0(&(v4));
    int32_t v7;
    v7 = v5 + v6;
    
    
    int32_t v8;
    v8 = v7 - 6l;
    
    
    return v8;
}
