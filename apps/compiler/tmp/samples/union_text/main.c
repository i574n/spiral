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
        } case1; // Code
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
            (x->case0.v0)->refc++;
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
US0 US0_Code(int32_t v0) { // Code
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // Code
            int32_t v4 = v0.case1.v0;
            
            USDecref0(&(v0));
            return v4;
            break;
        }
        default: { // Text
            String * v1 = v0.case0.v0;
            (v1)->refc++;
            USDecref0(&(v0));
            bool v2;
            v2 = strcmp(v1->ptr, "hi") == 0;
            
            StringDecref(v1);
            if (v2){
                
                
                return 2l;
            } else {
                
                
                return 3l;
            }
            break;
        }
    }
}
int32_t main(){
    
    
    bool v0;
    v0 = true;
    
    
    String * v1;
    v1 = StringLit(3, "hi");
    
    
    US0 v4;
    if (v0){
        (v1)->refc++;
        
        v4 = US0_Text(v1);
    } else {
        
        
        v4 = US0_Code(1l);
    }
    
    
    US0 v7;
    if (v0){
        
        
        v7 = US0_Code(5l);
    } else {
        (v1)->refc++;
        
        v7 = US0_Text(v1);
    }
    USIncref0(&(v4));
    StringDecref(v1);
    int32_t v8;
    v8 = score0(v4);
    
    USDecref0(&(v4));
    bool v9;
    v9 = v8 == 2l;
    
    
    bool v12;
    if (v9){
        USIncref0(&(v7));
        
        int32_t v10;
        v10 = score0(v7);
        
        
        bool v11;
        v11 = v10 == 5l;
        
        
        v12 = v11;
    } else {
        
        
        v12 = false;
    }
    
    USDecref0(&(v7));
    if (v12){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
