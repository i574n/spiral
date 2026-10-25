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
    Heap0 * v2;
} Heap1;
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
    HeapDecref0(x->v0); HeapDecref0(x->v1); HeapDecref0(x->v2);
}
void HeapDecref1(Heap1 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody1(x); free(x); }
}
Heap1 * HeapCreate1(Heap0 * v0, Heap0 * v1, Heap0 * v2){
    Heap1 * x = malloc(sizeof(Heap1));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1; x->v2 = v2;
    return x;
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
    
    StringDecref(v4);
    int32_t v6;
    v6 = 9l;
    
    
    String * v7;
    v7 = StringLit(3, "ok");
    (v7)->refc++;
    
    Heap0 * v8;
    v8 = HeapCreate0(v6, v7);
    (v2)->refc++; (v5)->refc++; (v8)->refc++;
    StringDecref(v7);
    Heap1 * v9;
    v9 = HeapCreate1(v2, v5, v8);
    
    HeapDecref0(v2); HeapDecref0(v5); HeapDecref0(v8);
    Heap0 * v10; Heap0 * v11; Heap0 * v12;
    v10 = v9->v0; v11 = v9->v1; v12 = v9->v2;
    (v10)->refc++; (v11)->refc++; (v12)->refc++;
    HeapDecref1(v9);
    int32_t v13; String * v14;
    v13 = v10->v0; v14 = v10->v1;
    (v14)->refc++;
    HeapDecref0(v10);
    int32_t v15; String * v16;
    v15 = v11->v0; v16 = v11->v1;
    (v16)->refc++;
    HeapDecref0(v11);
    int32_t v17; String * v18;
    v17 = v12->v0; v18 = v12->v1;
    (v18)->refc++;
    HeapDecref0(v12);
    bool v19;
    v19 = v13 == 7l;
    
    
    bool v21;
    if (v19){
        
        
        bool v20;
        v20 = strcmp(v14->ptr, "hi") == 0;
        
        
        v21 = v20;
    } else {
        
        
        v21 = false;
    }
    
    StringDecref(v14);
    bool v23;
    if (v21){
        
        
        bool v22;
        v22 = v15 == 4l;
        
        
        v23 = v22;
    } else {
        
        
        v23 = false;
    }
    
    
    bool v25;
    if (v23){
        
        
        bool v24;
        v24 = strcmp(v16->ptr, "yo") == 0;
        
        
        v25 = v24;
    } else {
        
        
        v25 = false;
    }
    
    StringDecref(v16);
    bool v27;
    if (v25){
        
        
        bool v26;
        v26 = v17 == 9l;
        
        
        v27 = v26;
    } else {
        
        
        v27 = false;
    }
    
    
    bool v29;
    if (v27){
        
        
        bool v28;
        v28 = strcmp(v18->ptr, "ok") == 0;
        
        
        v29 = v28;
    } else {
        
        
        v29 = false;
    }
    
    StringDecref(v18);
    if (v29){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
