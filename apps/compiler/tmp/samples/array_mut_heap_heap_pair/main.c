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
} Heap1;
typedef struct {
    int refc;
    Heap1 * v0;
    int32_t v1;
} Heap2;
typedef struct {
    int refc;
    Heap2 * v0;
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
    HeapDecref0(x->v0); HeapDecref0(x->v1);
}
void HeapDecref1(Heap1 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody1(x); free(x); }
}
Heap1 * HeapCreate1(Heap0 * v0, Heap0 * v1){
    Heap1 * x = malloc(sizeof(Heap1));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void HeapDecrefBody2(Heap2 * x){
    HeapDecref1(x->v0);
}
void HeapDecref2(Heap2 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody2(x); free(x); }
}
Heap2 * HeapCreate2(Heap1 * v0, int32_t v1){
    Heap2 * x = malloc(sizeof(Heap2));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref2(x->v0);
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(Heap2 * v0){
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
static inline void AssignMut0(Heap2 * * a0, Heap2 * b0){
    (b0)->refc++;
    HeapDecref2(*a0);
    *a0 = b0;
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
    Heap1 * v6;
    v6 = HeapCreate1(v2, v5);
    
    HeapDecref0(v2); HeapDecref0(v5);
    int32_t v7;
    v7 = 3l;
    (v6)->refc++;
    
    Heap2 * v8;
    v8 = HeapCreate2(v6, v7);
    (v8)->refc++;
    HeapDecref1(v6);
    Mut0 * v9;
    v9 = MutCreate0(v8);
    
    HeapDecref2(v8);
    Array1 * v10;
    v10 = ArrayCreate1(1l, true);
    
    
    
    AssignArray0(&(v10->ptr[0l]), v9);
    
    MutDecref0(v9);
    int32_t v11;
    v11 = 7l;
    
    
    String * v12;
    v12 = StringLit(3, "hi");
    (v12)->refc++;
    
    Heap0 * v13;
    v13 = HeapCreate0(v11, v12);
    
    StringDecref(v12);
    int32_t v14;
    v14 = 4l;
    
    
    String * v15;
    v15 = StringLit(3, "yo");
    (v15)->refc++;
    
    Heap0 * v16;
    v16 = HeapCreate0(v14, v15);
    (v13)->refc++; (v16)->refc++;
    StringDecref(v15);
    Heap1 * v17;
    v17 = HeapCreate1(v13, v16);
    
    HeapDecref0(v13); HeapDecref0(v16);
    int32_t v18;
    v18 = 2l;
    (v17)->refc++;
    
    Heap2 * v19;
    v19 = HeapCreate2(v17, v18);
    
    HeapDecref1(v17);
    Mut0 * v20;
    v20 = v10->ptr[0l];
    (v20)->refc++;
    ArrayDecref1(v10);
    
    AssignMut0(&(v20->v0), v19);
    
    HeapDecref2(v19);
    Heap2 * v21;
    v21 = v20->v0;
    (v21)->refc++;
    MutDecref0(v20);
    Heap1 * v22; int32_t v23;
    v22 = v21->v0; v23 = v21->v1;
    (v22)->refc++;
    HeapDecref2(v21);
    Heap0 * v24; Heap0 * v25;
    v24 = v22->v0; v25 = v22->v1;
    (v24)->refc++; (v25)->refc++;
    HeapDecref1(v22);
    int32_t v26; String * v27;
    v26 = v24->v0; v27 = v24->v1;
    (v27)->refc++;
    HeapDecref0(v24);
    int32_t v28; String * v29;
    v28 = v25->v0; v29 = v25->v1;
    (v29)->refc++;
    HeapDecref0(v25);
    bool v30;
    v30 = v26 == 7l;
    
    
    bool v32;
    if (v30){
        
        
        bool v31;
        v31 = strcmp(v27->ptr, "hi") == 0;
        
        
        v32 = v31;
    } else {
        
        
        v32 = false;
    }
    
    StringDecref(v27);
    bool v34;
    if (v32){
        
        
        bool v33;
        v33 = v28 == 4l;
        
        
        v34 = v33;
    } else {
        
        
        v34 = false;
    }
    
    
    bool v36;
    if (v34){
        
        
        bool v35;
        v35 = strcmp(v29->ptr, "yo") == 0;
        
        
        v36 = v35;
    } else {
        
        
        v36 = false;
    }
    
    StringDecref(v29);
    bool v38;
    if (v36){
        
        
        bool v37;
        v37 = v23 == 2l;
        
        
        v38 = v37;
    } else {
        
        
        v38 = false;
    }
    
    
    if (v38){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
