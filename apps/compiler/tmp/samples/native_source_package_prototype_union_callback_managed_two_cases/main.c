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
            String * v0;
        } case1; // Text
        struct {
            String * v0;
        } case2; // Note
    };
} US0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    US0 (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    US0 (*fptr)(Closure0 *, int32_t);
};
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
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            x->case1.v0->refc++;
            break;
        }
        case 2: {
            x->case2.v0->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            StringDecref(x->case1.v0);
            break;
        }
        case 2: {
            StringDecref(x->case2.v0);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_0() { // Idle
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(String * v0) { // Text
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
US0 US0_2(String * v0) { // Note
    US0 x;
    x.tag = 2;
    x.case2.v0 = v0;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
US0 ClosureMethod0(Closure0 * x, int32_t v0){
    
    ClosureDecref0(x);
    
    
    bool v1;
    v1 = v0 == 1l ;
    
    
    if (v1){
        
        
        String * v2;
        v2 = StringLit(6, "alpha");
        
        
        return US0_1(v2);
    } else {
        
        
        String * v4;
        v4 = StringLit(5, "beta");
        
        
        return US0_2(v4);
    }
}
Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    
    return (Fun0 *) x;
}
US0 method0(Fun0 * v0){
    
    
    return v0->fptr(v0, 1l);
}
US0 method1(Fun0 * v0){
    
    
    return v0->fptr(v0, 2l);
}
int32_t main(){
    
    
    Fun0 * v0;
    v0 = ClosureCreate0();
    v0->refc++;
    
    US0 v1;
    v1 = method0(v0);
    
    
    int32_t v6;
    switch (v1.tag) {
        case 0: { // Idle
            
            
            
            v6 = 3l;
            break;
        }
        case 2: { // Note
            
            
            
            v6 = 6l;
            break;
        }
        case 1: { // Text
            
            
            
            v6 = 5l;
            break;
        }
    }
    v0->refc++;
    USDecref0(&(v1));
    US0 v7;
    v7 = method1(v0);
    
    v0->decref_fptr(v0);
    int32_t v12;
    switch (v7.tag) {
        case 0: { // Idle
            
            
            
            v12 = 3l;
            break;
        }
        case 2: { // Note
            
            
            
            v12 = 6l;
            break;
        }
        case 1: { // Text
            
            
            
            v12 = 5l;
            break;
        }
    }
    
    USDecref0(&(v7));
    int32_t v13;
    v13 = v6 + v12 ;
    
    
    int32_t v14;
    v14 = v13 + 31l ;
    
    
    return v14;
}
