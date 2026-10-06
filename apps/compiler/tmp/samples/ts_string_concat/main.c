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
String * choose_left0(bool v0){
    
    
    if (v0){
        
        
        String * v1;
        v1 = StringLit(4, "spi");
        
        
        return v1;
    } else {
        
        
        String * v2;
        v2 = StringLit(4, "bad");
        
        
        return v2;
    }
}
String * choose_right1(bool v0){
    
    
    if (v0){
        
        
        String * v1;
        v1 = StringLit(4, "bad");
        
        
        return v1;
    } else {
        
        
        String * v2;
        v2 = StringLit(4, "ral");
        
        
        return v2;
    }
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
    
    
    bool v0;
    v0 = true;
    
    
    String * v1;
    v1 = choose_left0(v0);
    
    
    bool v2;
    v2 = false;
    
    
    String * v3;
    v3 = choose_right1(v2);
    
    
    String * v4;
    v4 = StringConcat(v1, v3);
    
    StringDecref(v1); StringDecref(v3);
    int32_t v5;
    v5 = v4->len-1;
    
    
    bool v6;
    v6 = v5 == 6l;
    
    
    if (v6){
        
        
        char v7;
        v7 = v4->ptr[0l];
        
        
        bool v8;
        v8 = v7 == 's';
        
        
        if (v8){
            
            
            char v9;
            v9 = v4->ptr[5l];
            
            StringDecref(v4);
            bool v10;
            v10 = v9 == 'l';
            
            
            if (v10){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
        } else {
            
            StringDecref(v4);
            return 2l;
        }
    } else {
        
        StringDecref(v4);
        return 3l;
    }
}
