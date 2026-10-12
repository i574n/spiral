#include <stdbool.h>
#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>
#include <string.h>
static char spiral_format_buffer[64];
static inline uint32_t spiral_format_i64(long long x) { return (uint32_t)snprintf(spiral_format_buffer, sizeof spiral_format_buffer, "%lld", x) + 1u; }
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // Some
    };
} US0;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct {
    int refc;
    String * v0;
} Mut0;
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_Some(int32_t v0) { // Some
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_None() { // None
    US0 x;
    x.tag = 1;
    return x;
}
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
static inline void MutDecrefBody0(Mut0 * x){
    StringDecref(x->v0);
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(String * v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline String * StringConcat(String * left, String * right){
    uint32_t left_len = left->len - 1;
    uint32_t right_len = right->len - 1;
    String * result = ArrayCreate0(left_len + right_len + 1, false);
    memcpy(result->ptr, left->ptr, left_len);
    memcpy(result->ptr + left_len, right->ptr, right_len + 1);
    return result;
}
String * method1(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // None
            
            
            USDecref0(&(v0));
            String * v6;
            v6 = StringLit(5, "None");
            
            
            return v6;
            break;
        }
        default: { // Some
            int32_t v1 = v0.case0.v0;
            
            USDecref0(&(v0));
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            String * v2;
            v2 = StringLit(spiral_format_i64((long long)(v1)), spiral_format_buffer);
            
            
            String * v3;
            v3 = StringConcat(v2, StringLit(2, ")"));
            
            StringDecref(v2);
            String * v4;
            v4 = StringConcat(StringLit(2, "("), v3);
            
            StringDecref(v3);
            String * v5;
            v5 = StringConcat(StringLit(5, "Some"), v4);
            
            StringDecref(v4);
            return v5;
            break;
        }
    }
}
static inline void AssignMut0(String * * a0, String * b0){
    (b0)->refc++;
    StringDecref(*a0);
    *a0 = b0;
}
void method2(Mut0 * v0, String * v1){
    
    
    String * v2;
    v2 = v0->v0;
    (v2)->refc++;
    
    String * v3;
    v3 = StringConcat(v2, v1);
    
    StringDecref(v1); StringDecref(v2);
    
    AssignMut0(&(v0->v0), v3);
    
    MutDecref0(v0); StringDecref(v3);
    return ;
}
String * format_real0(US0 v0){
    
    
    String * v1;
    v1 = StringLit(1, "");
    (v1)->refc++;
    
    Mut0 * v2;
    v2 = MutCreate0(v1);
    USIncref0(&(v0));
    StringDecref(v1);
    String * v3;
    v3 = method1(v0);
    (v2)->refc++; (v3)->refc++;
    USDecref0(&(v0));
    
    method2(v2, v3);
    
    StringDecref(v3);
    String * v4;
    v4 = v2->v0;
    (v4)->refc++;
    MutDecref0(v2);
    return v4;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1l;
    
    
    US0 v1;
    v1 = US0_Some(v0);
    USIncref0(&(v1));
    
    String * v2;
    v2 = format_real0(v1);
    
    USDecref0(&(v1));
    String * v3;
    v3 = StringConcat(StringLit(4, "x: "), v2);
    
    StringDecref(v2);
    bool v4;
    v4 = strcmp(v3->ptr, "") == 0;
    
    StringDecref(v3);
    if (v4){
        
        
        return 1l;
    } else {
        
        
        return 0l;
    }
}
