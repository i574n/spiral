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
    
    
    String * v1;
    v1 = StringSlice(v0, 0l, -1l);
    
    StringDecref(v0);
    return v1;
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
    StringDecref(v1);
    String * v2;
    v2 = empty_middle0(v0);
    v0->refc++;
    StringDecref(v2);
    String * v3;
    v3 = empty_middle0(v0);
    v0->refc++;
    StringDecref(v3);
    String * v4;
    v4 = empty_middle0(v0);
    v0->refc++;
    
    String * v5;
    v5 = empty_end1(v0);
    
    StringDecref(v0);
    String * v6;
    v6 = StringLit(1, "");
    v6->refc++;
    
    String * v7;
    v7 = empty_source2(v6);
    
    StringDecref(v6);
    String * v8;
    v8 = StringConcat(v4, v5);
    
    
    String * v9;
    v9 = StringConcat(v7, StringLit(3, "ok"));
    
    
    String * v10;
    v10 = StringConcat(v8, v9);
    
    StringDecref(v8); StringDecref(v9);
    int32_t v11;
    v11 = v4->len-1;
    
    StringDecref(v4);
    bool v12;
    v12 = v11 == 0l;
    
    
    if (v12){
        
        
        int32_t v13;
        v13 = v5->len-1;
        
        StringDecref(v5);
        bool v14;
        v14 = v13 == 0l;
        
        
        if (v14){
            
            
            int32_t v15;
            v15 = v7->len-1;
            
            StringDecref(v7);
            bool v16;
            v16 = v15 == 0l;
            
            
            if (v16){
                
                
                int32_t v17;
                v17 = v10->len-1;
                
                
                bool v18;
                v18 = v17 == 2l;
                
                
                if (v18){
                    
                    
                    char v19;
                    v19 = v10->ptr[0l];
                    
                    
                    bool v20;
                    v20 = v19 == 'o';
                    
                    
                    if (v20){
                        
                        
                        char v21;
                        v21 = v10->ptr[1l];
                        
                        StringDecref(v10);
                        bool v22;
                        v22 = v21 == 'k';
                        
                        
                        if (v22){
                            
                            
                            return 0l;
                        } else {
                            
                            
                            return 1l;
                        }
                    } else {
                        
                        StringDecref(v10);
                        return 2l;
                    }
                } else {
                    
                    StringDecref(v10);
                    return 3l;
                }
            } else {
                
                StringDecref(v10);
                return 4l;
            }
        } else {
            
            StringDecref(v7); StringDecref(v10);
            return 5l;
        }
    } else {
        
        StringDecref(v5); StringDecref(v7); StringDecref(v10);
        return 6l;
    }
}
