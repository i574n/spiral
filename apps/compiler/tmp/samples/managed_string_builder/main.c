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
static inline String * StringConcat(String * left, String * right){
    uint32_t left_len = left->len - 1;
    uint32_t right_len = right->len - 1;
    String * result = ArrayCreate0(left_len + right_len + 1, false);
    memcpy(result->ptr, left->ptr, left_len);
    memcpy(result->ptr + left_len, right->ptr, right_len + 1);
    return result;
}
String * method2(int32_t v0, String * v1, String * v2){
    
    
    int32_t v3;
    v3 = v0 - 1l;
    
    
    String * v4;
    v4 = StringConcat(v1, v2);
    
    StringDecref(v1); StringDecref(v2);
    bool v5;
    v5 = v3 == 0l;
    
    
    if (v5){
        
        
        return v4;
    } else {
        
        
        int32_t v6;
        v6 = v3 % 2l;
        
        
        bool v7;
        v7 = v6 == 0l;
        
        
        String * v10;
        if (v7){
            
            
            String * v8;
            v8 = StringLit(3, "ab");
            
            
            v10 = v8;
        } else {
            
            
            String * v9;
            v9 = StringLit(2, "c");
            
            
            v10 = v9;
        }
        
        
        return method2(v3, v4, v10);
    }
}
String * method1(int32_t v0, String * v1){
    
    
    int32_t v2;
    v2 = v0 - 1l;
    
    
    String * v3;
    v3 = StringConcat(StringLit(1, ""), v1);
    
    StringDecref(v1);
    bool v4;
    v4 = v2 == 0l;
    
    
    if (v4){
        
        
        return v3;
    } else {
        
        
        int32_t v5;
        v5 = v2 % 2l;
        
        
        bool v6;
        v6 = v5 == 0l;
        
        
        String * v9;
        if (v6){
            
            
            String * v7;
            v7 = StringLit(3, "ab");
            
            
            v9 = v7;
        } else {
            
            
            String * v8;
            v8 = StringLit(2, "c");
            
            
            v9 = v8;
        }
        
        
        return method2(v2, v3, v9);
    }
}
String * method0(){
    
    
    int32_t v0;
    v0 = 4l;
    
    
    bool v1;
    v1 = v0 == 0l;
    
    
    if (v1){
        
        
        String * v2;
        v2 = StringLit(1, "");
        
        
        return v2;
    } else {
        
        
        int32_t v3;
        v3 = v0 % 2l;
        
        
        bool v4;
        v4 = v3 == 0l;
        
        
        String * v7;
        if (v4){
            
            
            String * v5;
            v5 = StringLit(3, "ab");
            
            
            v7 = v5;
        } else {
            
            
            String * v6;
            v6 = StringLit(2, "c");
            
            
            v7 = v6;
        }
        
        
        return method1(v0, v7);
    }
}
int32_t main(){
    
    
    String * v0;
    v0 = method0();
    
    
    int32_t v1;
    v1 = v0->len-1;
    
    
    bool v2;
    v2 = v1 == 6l;
    
    
    if (v2){
        
        
        char v3;
        v3 = v0->ptr[0l];
        
        
        bool v4;
        v4 = v3 == 'a';
        
        
        if (v4){
            
            
            char v5;
            v5 = v0->ptr[5l];
            
            StringDecref(v0);
            bool v6;
            v6 = v5 == 'c';
            
            
            if (v6){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
        } else {
            
            StringDecref(v0);
            return 2l;
        }
    } else {
        
        StringDecref(v0);
        return 3l;
    }
}
