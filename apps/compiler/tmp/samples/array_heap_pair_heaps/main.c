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
    uint32_t len;
    Heap1 * ptr[];
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
static inline void ArrayDecrefBody1(Array1 * x){
    uint32_t len = x->len;
    Heap1 * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Heap1 * v = ptr[i];
        HeapDecref1(v);
    }
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(Heap1 *) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, Heap1 * * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(Heap1 *) * len);
        for (uint32_t i=0; i < len; i++){
            Heap1 * v = ptr[i];
            (v)->refc++;
        }
    return x;
}
static inline void AssignArray0(Heap1 * * a, Heap1 * b){
    (b)->refc++;
    HeapDecref1(*a);
    *a = b;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    String * v1;
    v1 = StringLit(3, "hi");
    (v1)->refc++;
    
    Heap0 * v2;
    v2 = HeapCreate0(v0, v1);
    
    StringDecref(v1);
    int32_t v3;
    v3 = 4l;
    
    
    String * v4;
    v4 = StringLit(3, "yo");
    (v4)->refc++;
    
    Heap0 * v5;
    v5 = HeapCreate0(v3, v4);
    (v2)->refc++; (v5)->refc++;
    StringDecref(v4);
    Heap1 * v6;
    v6 = HeapCreate1(v2, v5);
    
    HeapDecref0(v2); HeapDecref0(v5);
    Array1 * v7;
    v7 = ArrayCreate1(1l, true);
    
    
    
    AssignArray0(&(v7->ptr[0l]), v6);
    
    HeapDecref1(v6);
    Heap1 * v8;
    v8 = v7->ptr[0l];
    (v8)->refc++;
    ArrayDecref1(v7);
    Heap0 * v9; Heap0 * v10;
    v9 = v8->v0; v10 = v8->v1;
    (v9)->refc++; (v10)->refc++;
    HeapDecref1(v8);
    int32_t v11; String * v12;
    v11 = v9->v0; v12 = v9->v1;
    (v12)->refc++;
    HeapDecref0(v9);
    int32_t v13; String * v14;
    v13 = v10->v0; v14 = v10->v1;
    (v14)->refc++;
    HeapDecref0(v10);
    bool v15;
    v15 = v11 == 7l;
    
    
    bool v17;
    if (v15){
        
        
        bool v16;
        v16 = strcmp(v12->ptr, "hi") == 0;
        
        
        v17 = v16;
    } else {
        
        
        v17 = false;
    }
    
    StringDecref(v12);
    bool v19;
    if (v17){
        
        
        bool v18;
        v18 = v13 == 4l;
        
        
        v19 = v18;
    } else {
        
        
        v19 = false;
    }
    
    
    bool v21;
    if (v19){
        
        
        bool v20;
        v20 = strcmp(v14->ptr, "yo") == 0;
        
        
        v21 = v20;
    } else {
        
        
        v21 = false;
    }
    
    StringDecref(v14);
    if (v21){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
