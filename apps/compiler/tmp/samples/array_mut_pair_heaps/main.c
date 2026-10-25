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
    Heap0 * v1;
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
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref0(x->v0); HeapDecref0(x->v1);
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(Heap0 * v0, Heap0 * v1){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
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
static inline void AssignMut0(Heap0 * * a0, Heap0 * b0, Heap0 * * a1, Heap0 * b1){
    (b0)->refc++; (b1)->refc++;
    HeapDecref0(*a0); HeapDecref0(*a1);
    *a0 = b0; *a1 = b1;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1l;
    
    
    String * v1;
    v1 = StringLit(3, "no");
    (v1)->refc++;
    
    Heap0 * v2;
    v2 = HeapCreate0(v0, v1);
    
    StringDecref(v1);
    int32_t v3;
    v3 = 2l;
    
    
    String * v4;
    v4 = StringLit(3, "zz");
    (v4)->refc++;
    
    Heap0 * v5;
    v5 = HeapCreate0(v3, v4);
    (v2)->refc++; (v5)->refc++;
    StringDecref(v4);
    Mut0 * v6;
    v6 = MutCreate0(v2, v5);
    
    HeapDecref0(v2); HeapDecref0(v5);
    Array1 * v7;
    v7 = ArrayCreate1(1l, true);
    
    
    
    AssignArray0(&(v7->ptr[0l]), v6);
    
    MutDecref0(v6);
    int32_t v8;
    v8 = 7l;
    
    
    String * v9;
    v9 = StringLit(3, "hi");
    (v9)->refc++;
    
    Heap0 * v10;
    v10 = HeapCreate0(v8, v9);
    
    StringDecref(v9);
    int32_t v11;
    v11 = 4l;
    
    
    String * v12;
    v12 = StringLit(3, "yo");
    (v12)->refc++;
    
    Heap0 * v13;
    v13 = HeapCreate0(v11, v12);
    
    StringDecref(v12);
    Mut0 * v14;
    v14 = v7->ptr[0l];
    (v14)->refc++;
    ArrayDecref1(v7);
    
    AssignMut0(&(v14->v0), v10, &(v14->v1), v13);
    
    HeapDecref0(v10); HeapDecref0(v13);
    Heap0 * v15; Heap0 * v16;
    v15 = v14->v0; v16 = v14->v1;
    (v15)->refc++; (v16)->refc++;
    MutDecref0(v14);
    int32_t v17; String * v18;
    v17 = v15->v0; v18 = v15->v1;
    (v18)->refc++;
    HeapDecref0(v15);
    int32_t v19; String * v20;
    v19 = v16->v0; v20 = v16->v1;
    (v20)->refc++;
    HeapDecref0(v16);
    bool v21;
    v21 = v17 == 7l;
    
    
    bool v23;
    if (v21){
        
        
        bool v22;
        v22 = strcmp(v18->ptr, "hi") == 0;
        
        
        v23 = v22;
    } else {
        
        
        v23 = false;
    }
    
    StringDecref(v18);
    bool v25;
    if (v23){
        
        
        bool v24;
        v24 = v19 == 4l;
        
        
        v25 = v24;
    } else {
        
        
        v25 = false;
    }
    
    
    bool v27;
    if (v25){
        
        
        bool v26;
        v26 = strcmp(v20->ptr, "yo") == 0;
        
        
        v27 = v26;
    } else {
        
        
        v27 = false;
    }
    
    StringDecref(v20);
    if (v27){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
