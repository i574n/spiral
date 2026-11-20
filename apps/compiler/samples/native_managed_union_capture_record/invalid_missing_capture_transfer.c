#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*decref_fptr)(Fun1 *);
    int32_t (*fptr)(Fun1 *, int32_t);
};
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Fun1 * (*fptr)(Fun0 *, int32_t);
};
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array1;
typedef Array1 String;
typedef struct {
    int tag;
    union {
        struct {
            String * v0;
            Array0 * v1;
        } case1; // Item
    };
} US0;
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    int32_t (*fptr)(Closure1 *, int32_t);
    US0 v0;
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Fun1 * (*fptr)(Closure0 *, int32_t);
};
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int32_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, int32_t * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    
    
    *a = b;
}
static inline void ArrayDecrefBody1(Array1 * x){
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(char) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, char * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref1(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit1(len, ptr);
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            x->case1.v0->refc++; x->case1.v1->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            StringDecref(x->case1.v0); ArrayDecref0(x->case1.v1);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_0() { // Empty
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(String * v0, Array0 * v1) { // Item
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody1(Closure1 * x){
    USDecref0(&(x->v0));
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
int32_t ClosureMethod1(Closure1 * x, int32_t v1){
    US0 v0 = x->v0;
    ClosureDecref1(x);
    
    
    int32_t v12;
    switch (v0.tag) {
        case 0: { // Empty
            
            
            
            v12 = 3l;
            break;
        }
        case 1: { // Item
            String * v2 = v0.case1.v0; Array0 * v3 = v0.case1.v1;
            v2->refc++; v3->refc++;
            
            int32_t v4;
            v4 = v2->len-1;
            
            StringDecref(v2);
            int32_t v5;
            v5 = v3->len;
            
            
            int32_t v6;
            v6 = v4 + v5 ;
            
            
            int32_t v7;
            v7 = v3->ptr[0l];
            
            
            int32_t v8;
            v8 = v6 + v7 ;
            
            
            int32_t v9;
            v9 = v3->ptr[1l];
            
            ArrayDecref0(v3);
            int32_t v10;
            v10 = v8 + v9 ;
            
            
            v12 = v10;
            break;
        }
    }
    
    
    int32_t v13;
    v13 = v12 + v1 ;
    
    
    return v13;
}
Fun1 * ClosureCreate1(US0 v0){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = ClosureMethod1;
    return (Fun1 *) x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Fun1 * ClosureMethod0(Closure0 * x, int32_t v0){
    
    ClosureDecref0(x);
    
    
    Array0 * v1;
    v1 = ArrayCreate0(2l, false);
    
    
    
    AssignArray0(&(v1->ptr[0l]), v0);
    
    
    int32_t v2;
    v2 = v0 + 1l ;
    
    
    
    AssignArray0(&(v1->ptr[1l]), v2);
    
    
    bool v3;
    v3 = v0 == 0l ;
    
    
    US0 v7;
    if (v3){
        
        
        v7 = US0_0();
    } else {
        
        
        String * v5;
        v5 = StringLit(3, "hi");
        v1->refc++;
        
        v7 = US0_1(v5, v1);
    }
    
    ArrayDecref0(v1);
    return ClosureCreate1(v7);
}
Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    
    return (Fun0 *) x;
}
Fun1 * method0(Fun0 * v0){
    
    
    return v0->fptr(v0, 0l);
}
Fun1 * method1(Fun0 * v0){
    
    
    return v0->fptr(v0, 4l);
}
int32_t method4(Fun1 * v0){
    v0->refc++;
    
    int32_t v1;
    v1 = v0->fptr(v0, 2l);
    
    v0->decref_fptr(v0);
    int32_t v2;
    v2 = v1 + 5l ;
    
    
    return v2;
}
int32_t method3(Fun1 * v0){
    v0->refc++;
    
    int32_t v1;
    v1 = v0->fptr(v0, 1l);
    v0->refc++;
    
    int32_t v2;
    v2 = method4(v0);
    
    v0->decref_fptr(v0);
    int32_t v3;
    v3 = v1 + v2 ;
    
    
    return v3;
}
int32_t method2(Fun1 * v0, Fun1 * v1){
    v0->refc++;
    
    int32_t v2;
    v2 = v0->fptr(v0, 5l);
    v1->refc++;
    v0->decref_fptr(v0);
    int32_t v3;
    v3 = method3(v1);
    
    v1->decref_fptr(v1);
    int32_t v4;
    v4 = v2 + v3 ;
    
    
    return v4;
}
int32_t main(){
    
    
    Fun0 * v0;
    v0 = ClosureCreate0();
    v0->refc++;
    
    Fun1 * v1;
    v1 = method0(v0);
    v0->refc++;
    
    Fun1 * v2;
    v2 = method1(v0);
    
    v0->decref_fptr(v0);
    return method2(v1, v2);
}
