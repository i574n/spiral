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
static inline String * StringConcat(String * left, String * right){
    uint32_t left_len = left->len - 1;
    uint32_t right_len = right->len - 1;
    String * result = ArrayCreate0(left_len + right_len + 1, false);
    memcpy(result->ptr, left->ptr, left_len);
    memcpy(result->ptr + left_len, right->ptr, right_len + 1);
    return result;
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
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(3, "é");
    
    
    int32_t v1;
    v1 = v0->len-1;
    
    
    char v2;
    v2 = v0->ptr[0l];
    
    
    char v3;
    v3 = v0->ptr[1l];
    
    
    String * v4;
    v4 = StringLit(2, "x");
    
    
    String * v5;
    v5 = StringConcat(v0, v4);
    
    StringDecref(v4);
    int32_t v6;
    v6 = v5->len-1;
    
    StringDecref(v5);
    String * v7;
    v7 = StringLit(3, "ab");
    
    
    char v8;
    v8 = v7->ptr[0l];
    
    
    String * v9;
    v9 = StringSlice(v7, 0l, 0l);
    
    
    int32_t v10;
    v10 = v9->len-1;
    
    StringDecref(v9);
    String * v11;
    v11 = StringSlice(v7, 1l, 0l);
    
    StringDecref(v7);
    int32_t v12;
    v12 = v11->len-1;
    
    StringDecref(v11);
    String * v13;
    v13 = StringSlice(v0, 0l, 1l);
    
    StringDecref(v0);
    int32_t v14;
    v14 = v13->len-1;
    
    StringDecref(v13);
    bool v15;
    v15 = v2 == v3;
    
    
    if (v15){
        
        
        return 1l;
    } else {
        
        
        bool v16;
        v16 = v1 == 2l;
        
        
        bool v18;
        if (v16){
            
            
            bool v17;
            v17 = v8 == 'a';
            
            
            v18 = v17;
        } else {
            
            
            v18 = false;
        }
        
        
        bool v20;
        if (v18){
            
            
            bool v19;
            v19 = v6 == 3l;
            
            
            v20 = v19;
        } else {
            
            
            v20 = false;
        }
        
        
        bool v22;
        if (v20){
            
            
            bool v21;
            v21 = v10 == 1l;
            
            
            v22 = v21;
        } else {
            
            
            v22 = false;
        }
        
        
        bool v24;
        if (v22){
            
            
            bool v23;
            v23 = v12 == 0l;
            
            
            v24 = v23;
        } else {
            
            
            v24 = false;
        }
        
        
        bool v26;
        if (v24){
            
            
            bool v25;
            v25 = v14 == 2l;
            
            
            v26 = v25;
        } else {
            
            
            v26 = false;
        }
        
        
        if (v26){
            
            
            return 0l;
        } else {
            
            
            return 1l;
        }
    }
}
