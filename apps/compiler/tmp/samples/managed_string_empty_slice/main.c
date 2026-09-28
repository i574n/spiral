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
String * empty_middle0(String * v0){
    
    
    String * v1;
    v1 = StringSlice(v0, 2l, 1l);
    
    StringDecref(v0);
    return v1;
}
String * empty_end1(String * v0){
    
    
    String * v1;
    v1 = StringSlice(v0, 5l, 4l);
    
    StringDecref(v0);
    return v1;
}
String * empty_source2(String * v0){
    
    
    int32_t v1;
    v1 = 0l - 1l ;
    
    
    String * v2;
    v2 = StringSlice(v0, 0l, v1);
    
    StringDecref(v0);
    return v2;
}
static inline String * StringConcat(String * left, String * right){
    uint32_t left_len = left->len - 1;
    uint32_t right_len = right->len - 1;
    String * result = ArrayCreate0(left_len + right_len + 1, false);
    memcpy(result->ptr, left->ptr, left_len);
    memcpy(result->ptr + left_len, right->ptr, right_len + 1);
    return result;
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(6, "alpha");
    v0->refc++;
    
    String * v1;
    v1 = empty_middle0(v0);
    v0->refc++;
    
    String * v2;
    v2 = empty_end1(v0);
    
    StringDecref(v0);
    String * v3;
    v3 = StringLit(1, "");
    v3->refc++;
    
    String * v4;
    v4 = empty_source2(v3);
    
    StringDecref(v3);
    String * v5;
    v5 = StringConcat(v1, v2);
    
    
    String * v6;
    v6 = StringConcat(v4, StringLit(3, "ok"));
    
    
    String * v7;
    v7 = StringConcat(v5, v6);
    
    StringDecref(v5); StringDecref(v6);
    int32_t v8;
    v8 = v1->len-1;
    
    StringDecref(v1);
    bool v9;
    v9 = v8 == 0l ;
    
    
    if (v9){
        
        
        int32_t v10;
        v10 = v2->len-1;
        
        StringDecref(v2);
        bool v11;
        v11 = v10 == 0l ;
        
        
        if (v11){
            
            
            int32_t v12;
            v12 = v4->len-1;
            
            StringDecref(v4);
            bool v13;
            v13 = v12 == 0l ;
            
            
            if (v13){
                
                
                int32_t v14;
                v14 = v7->len-1;
                
                
                bool v15;
                v15 = v14 == 2l ;
                
                
                if (v15){
                    
                    
                    char v16;
                    v16 = v7->ptr[0l];
                    
                    
                    bool v17;
                    v17 = v16 == 'o' ;
                    
                    
                    if (v17){
                        
                        
                        char v18;
                        v18 = v7->ptr[1l];
                        
                        StringDecref(v7);
                        bool v19;
                        v19 = v18 == 'k' ;
                        
                        
                        if (v19){
                            
                            
                            return 0l;
                        } else {
                            
                            
                            return 1l;
                        }
                    } else {
                        
                        StringDecref(v7);
                        return 2l;
                    }
                } else {
                    
                    StringDecref(v7);
                    return 3l;
                }
            } else {
                
                StringDecref(v7);
                return 4l;
            }
        } else {
            
            StringDecref(v4); StringDecref(v7);
            return 5l;
        }
    } else {
        
        StringDecref(v2); StringDecref(v4); StringDecref(v7);
        return 6l;
    }
}
