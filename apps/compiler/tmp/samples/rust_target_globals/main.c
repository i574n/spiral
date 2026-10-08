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
    v0 = StringLit(49, "SPIRAL_TARGET_GLOBAL_RUST_PRELUDE_pos-p_B64:Ly9Q");
    v0->refc++;
    
    
    target_global0(v0);
    v0->refc++;
    
    
    target_global0(v0);
    
    StringDecref(v0);
    String * v1;
    v1 = StringLit(53, "SPIRAL_TARGET_GLOBAL_RUST_BEFORE_MAIN_pos-b_B64:Ly9C");
    v1->refc++;
    
    
    target_global0(v1);
    
    StringDecref(v1);
    String * v2;
    v2 = StringLit(132, "SPIRAL_TARGET_GLOBAL_RUST_AFTER_MAIN_test-item_B64:Zm4gc3BpcmFsX2F0dHJpYnV0ZV9zbW9rZSgpIHsKICAgIGFzc2VydF9lcSEoNiAqIDcsIDQyKTsKfQo=");
    v2->refc++;
    
    
    target_global0(v2);
    
    StringDecref(v2);
    String * v3;
    v3 = StringLit(36, "SPIRAL_ITEM_METADATA_TEST_test-item");
    v3->refc++;
    
    
    target_global0(v3);
    
    StringDecref(v3);
    String * v4;
    v4 = StringLit(51, "SPIRAL_TARGET_GLOBAL_DELPHI_PRELUDE_pos-p_B64:Ly9Q");
    v4->refc++;
    
    
    target_global0(v4);
    v4->refc++;
    
    
    target_global0(v4);
    
    StringDecref(v4);
    String * v5;
    v5 = StringLit(55, "SPIRAL_TARGET_GLOBAL_DELPHI_BEFORE_MAIN_pos-b_B64:Ly9C");
    v5->refc++;
    
    
    target_global0(v5);
    
    StringDecref(v5);
    String * v6;
    v6 = StringLit(158, "SPIRAL_TARGET_GLOBAL_DELPHI_AFTER_MAIN_test-item_B64:cHJvY2VkdXJlIFNwaXJhbFRhcmdldEdsb2JhbFNtb2tlOwpiZWdpbgogIGlmIDYgKiA3IDw+IDQyIHRoZW4gSGFsdCgxKTsKZW5kOwo=");
    v6->refc++;
    
    
    target_global0(v6);
    
    StringDecref(v6);
    return 0l;
}
