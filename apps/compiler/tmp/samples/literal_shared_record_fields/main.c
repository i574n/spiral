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
    int32_t v2;
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
static inline Tuple0 TupleCreate0(String * v0, String * v1, int32_t v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple0 run0(int32_t v0, String * v1, String * v2, int32_t v3){
    while (1) {
        
        
        bool v4;
        v4 = v0 <= 0l;
        
        
        String * v11; String * v12; int32_t v13;
        if (v4){
            (v1)->refc++; (v2)->refc++;
            
            v11 = v1; v12 = v2; v13 = v3;
        } else {
            
            
            int32_t v5;
            v5 = v0 - 1l;
            
            
            int32_t v6;
            v6 = v3 + 1l;
            
            
            String * v7;
            v7 = StringLit(2, "y");
            (v2)->refc++; (v7)->refc++;
            
            {
                int32_t tmp0 = v5;
                String * tmp1 = v2;
                String * tmp2 = v7;
                int32_t tmp3 = v6;
                
                StringDecref(v7);
                
                StringDecref(v1); StringDecref(v2);
                v0 = tmp0;
                v1 = tmp1;
                v2 = tmp2;
                v3 = tmp3;
            }
            continue;
        }
        
        StringDecref(v1); StringDecref(v2);
        return TupleCreate0(v11, v12, v13);
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 5l;
    
    
    String * v1;
    v1 = StringLit(1, "");
    
    
    int32_t v2;
    v2 = 0l;
    (v1)->refc += 2;
    
    String * v3; String * v4; int32_t v5;
    Tuple0 tmp4 = run0(v0, v1, v1, v2);
    v3 = tmp4.v0; v4 = tmp4.v1; v5 = tmp4.v2;
    
    StringDecref(v1); StringDecref(v3); StringDecref(v4);
    int32_t v6;
    v6 = v5 - 5l;
    
    
    return v6;
}
