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
    int refc;
    String * v1;
    int32_t v0;
} Heap0;
typedef struct {
    int refc;
    Heap0 * v0;
    int32_t v1;
} Heap1;
typedef struct {
    int refc;
    Heap1 * v0;
} Mut0;
typedef struct {
    int refc;
    uint32_t len;
    Mut0 * ptr[];
} Array1;
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
static inline void HeapDecrefBody0(Heap0 * x){
    StringDecref(x->v1);
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(int32_t v0, String * v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void HeapDecrefBody1(Heap1 * x){
    HeapDecref0(x->v0);
}
void HeapDecref1(Heap1 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody1(x); free(x); }
}
Heap1 * HeapCreate1(Heap0 * v0, int32_t v1){
    Heap1 * x = malloc(sizeof(Heap1));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref1(x->v0);
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(Heap1 * v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void ArrayDecrefBody1(Array1 * x){
    uint32_t len = x->len;
    Mut0 * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Mut0 * v = ptr[i];
        MutDecref0(v);
    }
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(Mut0 *) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, Mut0 * * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(Mut0 *) * len);
        for (uint32_t i=0; i < len; i++){
            Mut0 * v = ptr[i];
            (v)->refc++;
        }
    return x;
}
static inline void AssignArray0(Mut0 * * a, Mut0 * b){
    (b)->refc++;
    MutDecref0(*a);
    *a = b;
}
static inline void AssignMut0(Heap1 * * a0, Heap1 * b0){
    (b0)->refc++;
    HeapDecref1(*a0);
    *a0 = b0;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    String * v1;
    v1 = StringLit(3, "no");
    (v1)->refc++;
    
    Heap0 * v2;
    v2 = HeapCreate0(v0, v1);
    
    StringDecref(v1);
    int32_t v3;
    v3 = 1l;
    (v2)->refc++;
    
    Heap1 * v4;
    v4 = HeapCreate1(v2, v3);
    (v4)->refc++;
    HeapDecref0(v2);
    Mut0 * v5;
    v5 = MutCreate0(v4);
    
    HeapDecref1(v4);
    Array1 * v6;
    v6 = ArrayCreate1(1l, true);
    
    
    
    AssignArray0(&(v6->ptr[0l]), v5);
    
    MutDecref0(v5);
    int32_t v7;
    v7 = 7l;
    
    
    String * v8;
    v8 = StringLit(3, "hi");
    (v8)->refc++;
    
    Heap0 * v9;
    v9 = HeapCreate0(v7, v8);
    
    StringDecref(v8);
    int32_t v10;
    v10 = 4l;
    (v9)->refc++;
    
    Heap1 * v11;
    v11 = HeapCreate1(v9, v10);
    
    HeapDecref0(v9);
    Mut0 * v12;
    v12 = v6->ptr[0l];
    (v12)->refc++;
    ArrayDecref1(v6);
    
    AssignMut0(&(v12->v0), v11);
    
    HeapDecref1(v11);
    Heap1 * v13;
    v13 = v12->v0;
    (v13)->refc++;
    MutDecref0(v12);
    Heap0 * v14; int32_t v15;
    v14 = v13->v0; v15 = v13->v1;
    (v14)->refc++;
    HeapDecref1(v13);
    int32_t v16; String * v17;
    v16 = v14->v0; v17 = v14->v1;
    (v17)->refc++;
    HeapDecref0(v14);
    bool v18;
    v18 = v16 == 7l;
    
    
    bool v20;
    if (v18){
        
        
        bool v19;
        v19 = strcmp(v17->ptr, "hi") == 0;
        
        
        v20 = v19;
    } else {
        
        
        v20 = false;
    }
    
    StringDecref(v17);
    bool v22;
    if (v20){
        
        
        bool v21;
        v21 = v15 == 4l;
        
        
        v22 = v21;
    } else {
        
        
        v22 = false;
    }
    
    
    if (v22){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
