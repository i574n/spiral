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
    String * v0;
    String * v1;
} Tuple0;
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
static inline Tuple0 TupleCreate0(String * v0, String * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 method0(int32_t v0){
    
    
    bool v1;
    v1 = v0 == 0l;
    
    
    if (v1){
        
        
        String * v2;
        v2 = StringLit(3, "no");
        (v2)->refc++;
        
        return TupleCreate0(v2, v2);
    } else {
        
        
        String * v3;
        v3 = StringLit(3, "hi");
        
        
        String * v4;
        v4 = StringLit(3, "yo");
        
        
        return TupleCreate0(v3, v4);
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    String * v1; String * v2;
    Tuple0 tmp0 = method0(v0);
    v1 = tmp0.v0; v2 = tmp0.v1;
    
    
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
}
