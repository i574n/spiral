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
static inline String * StringSlice(String * value, int32_t from, int32_t to){
    int32_t length = (int32_t)value->len - 1;
    if (from < 0 || from > length || to < from - 1 || to >= length) { abort(); }
    uint32_t slice_len = to < from ? 0u : (uint32_t)(to - from + 1);
    if (slice_len != 0u && ((((uint8_t)value->ptr[from] & 0xC0u) == 0x80u) || (to + 1 < length && (((uint8_t)value->ptr[to + 1] & 0xC0u) == 0x80u)))) { abort(); }
    String * result = ArrayCreate0(slice_len + 1, false);
    if (slice_len != 0u) { memcpy(result->ptr, value->ptr + from, slice_len); }
    result->ptr[slice_len] = '\0';
    return result;
}
String * middle0(String * v0){
    
    
    String * v1;
    v1 = StringSlice(v0, 1l, 3l);
    
    StringDecref(v0);
    return v1;
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(6, "alpha");
    v0->refc++;
    
    String * v1;
    v1 = middle0(v0);
    
    StringDecref(v0);
    int32_t v2;
    v2 = v1->len-1;
    
    
    bool v3;
    v3 = v2 == 3l;
    
    
    if (v3){
        
        
        char v4;
        v4 = v1->ptr[0l];
        
        
        bool v5;
        v5 = v4 == 'l';
        
        
        if (v5){
            
            
            char v6;
            v6 = v1->ptr[2l];
            
            StringDecref(v1);
            bool v7;
            v7 = v6 == 'h';
            
            
            if (v7){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
        } else {
            
            StringDecref(v1);
            return 2l;
        }
    } else {
        
        StringDecref(v1);
        return 3l;
    }
}
