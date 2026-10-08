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
void target_global0(String * v0){
    
    
    int32_t v1;
    v1 = v0->len-1;
    
    StringDecref(v0);
    return ;
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(48, "SPIRAL_TARGET_GLOBAL_RUST_PRELUDE_same_B64:Ly9Q");
    v0->refc++;
    
    
    target_global0(v0);
    
    StringDecref(v0);
    String * v1;
    v1 = StringLit(52, "SPIRAL_TARGET_GLOBAL_RUST_BEFORE_MAIN_same_B64:Ly9C");
    v1->refc++;
    
    
    target_global0(v1);
    
    StringDecref(v1);
    String * v2;
    v2 = StringLit(50, "SPIRAL_TARGET_GLOBAL_DELPHI_PRELUDE_same_B64:Ly9Q");
    v2->refc++;
    
    
    target_global0(v2);
    
    StringDecref(v2);
    String * v3;
    v3 = StringLit(54, "SPIRAL_TARGET_GLOBAL_DELPHI_BEFORE_MAIN_same_B64:Ly9C");
    v3->refc++;
    
    
    target_global0(v3);
    
    StringDecref(v3);
    return 0l;
}
