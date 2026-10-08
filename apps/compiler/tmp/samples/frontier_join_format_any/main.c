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
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // Some
    };
} US0;
typedef struct {
    int refc;
    String * v0;
} Mut0;
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
US0 US0_0(int32_t v0) { // Some
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_1() { // None
    US0 x;
    x.tag = 1;
    return x;
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
String * format_real1(US0 v0){
    
    USDecref0(&(v0));
    String * v32;
    v32 = backend_switch_has_no_C_arm_in_lib_spiral;
    v32->refc++;
    
    Mut0 * v44;
    v44 = MutCreate0(v32);
    
    StringDecref(v32);
    String * v57;
    v57 = backend_switch_has_no_C_arm_in_lib_spiral;
    
    StringDecref(v57);
    String * v63;
    v63 = backend_switch_has_no_C_arm_in_lib_spiral;
    
    StringDecref(v63);
    
    ((void)0);
    
    
    String * v86;
    v86 = v44->v0;
    v86->refc++;
    MutDecref0(v44);
    return v86;
}
String * method0(){
    
    
    int32_t v0;
    v0 = 1l;
    
    
    US0 v1;
    v1 = US0_0(v0);
    USIncref0(&(v1));
    
    String * v2;
    v2 = format_real1(v1);
    
    USDecref0(&(v1)); StringDecref(v2);
    String * v23;
    v23 = backend_switch_has_no_C_arm_in_lib_spiral;
    
    
    return v23;
}
int32_t main(){
    
    
    String * v0;
    v0 = method0();
    
    
    bool v1;
    v1 = strcmp(v0->ptr->ptr, ""->ptr) == 0;
    
    StringDecref(v0);
    if (v1){
        
        
        return 1l;
    } else {
        
        
        return 0l;
    }
}
