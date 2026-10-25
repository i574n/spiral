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
    HeapDecref0(x->v0); HeapDecref0(x->v1); HeapDecref0(x->v2);
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(Heap0 * v0, Heap0 * v1, Heap0 * v2){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1; x->v2 = v2;
    return x;
}
static inline void AssignMut0(Heap0 * * a0, Heap0 * b0, Heap0 * * a1, Heap0 * b1, Heap0 * * a2, Heap0 * b2){
    (b0)->refc++; (b1)->refc++; (b2)->refc++;
    HeapDecref0(*a0); HeapDecref0(*a1); HeapDecref0(*a2);
    *a0 = b0; *a1 = b1; *a2 = b2;
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
    
    StringDecref(v4);
    int32_t v6;
    v6 = 3l;
    
    
    String * v7;
    v7 = StringLit(3, "aa");
    (v7)->refc++;
    
    Heap0 * v8;
    v8 = HeapCreate0(v6, v7);
    (v2)->refc++; (v5)->refc++; (v8)->refc++;
    StringDecref(v7);
    Mut0 * v9;
    v9 = MutCreate0(v2, v5, v8);
    
    HeapDecref0(v2); HeapDecref0(v5); HeapDecref0(v8);
    int32_t v10;
    v10 = 7l;
    
    
    String * v11;
    v11 = StringLit(3, "hi");
    (v11)->refc++;
    
    Heap0 * v12;
    v12 = HeapCreate0(v10, v11);
    
    StringDecref(v11);
    int32_t v13;
    v13 = 4l;
    
    
    String * v14;
    v14 = StringLit(3, "yo");
    (v14)->refc++;
    
    Heap0 * v15;
    v15 = HeapCreate0(v13, v14);
    
    StringDecref(v14);
    int32_t v16;
    v16 = 9l;
    
    
    String * v17;
    v17 = StringLit(3, "ok");
    (v17)->refc++;
    
    Heap0 * v18;
    v18 = HeapCreate0(v16, v17);
    
    StringDecref(v17);
    
    AssignMut0(&(v9->v0), v12, &(v9->v1), v15, &(v9->v2), v18);
    
    HeapDecref0(v12); HeapDecref0(v15); HeapDecref0(v18);
    Heap0 * v19; Heap0 * v20; Heap0 * v21;
    v19 = v9->v0; v20 = v9->v1; v21 = v9->v2;
    (v19)->refc++; (v20)->refc++; (v21)->refc++;
    MutDecref0(v9);
    int32_t v22; String * v23;
    v22 = v19->v0; v23 = v19->v1;
    (v23)->refc++;
    HeapDecref0(v19);
    int32_t v24; String * v25;
    v24 = v20->v0; v25 = v20->v1;
    (v25)->refc++;
    HeapDecref0(v20);
    int32_t v26; String * v27;
    v26 = v21->v0; v27 = v21->v1;
    (v27)->refc++;
    HeapDecref0(v21);
    bool v28;
    v28 = v22 == 7l;
    
    
    bool v30;
    if (v28){
        
        
        bool v29;
        v29 = strcmp(v23->ptr, "hi") == 0;
        
        
        v30 = v29;
    } else {
        
        
        v30 = false;
    }
    
    StringDecref(v23);
    bool v32;
    if (v30){
        
        
        bool v31;
        v31 = v24 == 4l;
        
        
        v32 = v31;
    } else {
        
        
        v32 = false;
    }
    
    
    bool v34;
    if (v32){
        
        
        bool v33;
        v33 = strcmp(v25->ptr, "yo") == 0;
        
        
        v34 = v33;
    } else {
        
        
        v34 = false;
    }
    
    StringDecref(v25);
    bool v36;
    if (v34){
        
        
        bool v35;
        v35 = v26 == 9l;
        
        
        v36 = v35;
    } else {
        
        
        v36 = false;
    }
    
    
    bool v38;
    if (v36){
        
        
        bool v37;
        v37 = strcmp(v27->ptr, "ok") == 0;
        
        
        v38 = v37;
    } else {
        
        
        v38 = false;
    }
    
    StringDecref(v27);
    if (v38){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
