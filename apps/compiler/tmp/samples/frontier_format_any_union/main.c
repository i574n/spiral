#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
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
String * format_real0(US0 v0){
    
    USDecref0(&(v0));
    String * v53;
    v53 = backend_switch_has_no_C_arm_in_lib_spiral;
    v53->refc++;
    
    Mut0 * v54;
    v54 = MutCreate0(v53);
    
    StringDecref(v53);
    String * v67;
    v67 = backend_switch_has_no_C_arm_in_lib_spiral;
    
    StringDecref(v67);
    String * v74;
    v74 = backend_switch_has_no_C_arm_in_lib_spiral;
    
    StringDecref(v74);
    
    (void)0;
    
    
    String * v101;
    v101 = v54->v0;
    v101->refc++;
    MutDecref0(v54);
    return v101;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1l;
    
    
    US0 v1;
    v1 = US0_0(v0);
    USIncref0(&(v1));
    
    String * v2;
    v2 = format_real0(v1);
    
    USDecref0(&(v1)); StringDecref(v2);
    String * v23;
    v23 = backend_switch_has_no_C_arm_in_lib_spiral;
    
    
    bool v24;
    v24 = strcmp(v23->ptr->ptr, ""->ptr) == 0;
    
    StringDecref(v23);
    if (v24){
        
        
        return 1l;
    } else {
        
        
        return 0l;
    }
}
