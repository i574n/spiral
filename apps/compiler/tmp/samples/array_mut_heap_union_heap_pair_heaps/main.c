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
    int tag;
    union {
        struct {
            Heap2 * v0;
        } case1; // Held
    };
} US0;
typedef struct {
    int refc;
    US0 v0;
} Heap3;
typedef struct {
    int refc;
    Heap3 * v0;
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
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            HeapDecref2(x->case1.v0);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_None() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Held(Heap2 * v0) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline void HeapDecrefBody3(Heap3 * x){
    USDecref0(&(x->v0));
}
void HeapDecref3(Heap3 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody3(x); free(x); }
}
Heap3 * HeapCreate3(US0 v0){
    Heap3 * x = malloc(sizeof(Heap3));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref3(x->v0);
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(Heap3 * v0){
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
static inline void AssignMut0(Heap3 * * a0, Heap3 * b0){
    (b0)->refc++;
    HeapDecref3(*a0);
    *a0 = b0;
}
int32_t score0(US0 v0){
    
    
    switch (v0.tag) {
        case 1: { // Held
            Heap2 * v1 = v0.case1.v0;
            (v1)->refc++;
            USDecref0(&(v0));
            Heap1 * v2; int32_t v3;
            v2 = v1->v0; v3 = v1->v1;
            (v2)->refc++;
            HeapDecref2(v1);
            Heap0 * v4; Heap0 * v5;
            v4 = v2->v0; v5 = v2->v1;
            (v4)->refc++; (v5)->refc++;
            HeapDecref1(v2);
            int32_t v6; String * v7;
            v6 = v4->v0; v7 = v4->v1;
            (v7)->refc++;
            HeapDecref0(v4);
            int32_t v8; String * v9;
            v8 = v5->v0; v9 = v5->v1;
            (v9)->refc++;
            HeapDecref0(v5);
            bool v10;
            v10 = v6 == 7l;
            
            
            bool v12;
            if (v10){
                
                
                bool v11;
                v11 = strcmp(v7->ptr, "hi") == 0;
                
                
                v12 = v11;
            } else {
                
                
                v12 = false;
            }
            
            StringDecref(v7);
            bool v14;
            if (v12){
                
                
                bool v13;
                v13 = v8 == 4l;
                
                
                v14 = v13;
            } else {
                
                
                v14 = false;
            }
            
            
            bool v16;
            if (v14){
                
                
                bool v15;
                v15 = strcmp(v9->ptr, "yo") == 0;
                
                
                v16 = v15;
            } else {
                
                
                v16 = false;
            }
            
            StringDecref(v9);
            bool v18;
            if (v16){
                
                
                bool v17;
                v17 = v3 == 2l;
                
                
                v18 = v17;
            } else {
                
                
                v18 = false;
            }
            
            
            if (v18){
                
                
                return 0l;
            } else {
                
                
                return 1l;
            }
            break;
        }
        case 0: { // None
            
            
            USDecref0(&(v0));
            return 1l;
            break;
        }
    }
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
    
    HeapDecref1(v6);
    bool v9;
    v9 = true;
    
    
    US0 v12;
    if (v9){
        (v8)->refc++;
        
        v12 = US0_Held(v8);
    } else {
        
        
        v12 = US0_None();
    }
    USIncref0(&(v12));
    HeapDecref2(v8);
    Heap3 * v13;
    v13 = HeapCreate3(v12);
    (v13)->refc++;
    USDecref0(&(v12));
    Mut0 * v14;
    v14 = MutCreate0(v13);
    
    HeapDecref3(v13);
    Array1 * v15;
    v15 = ArrayCreate1(1l, true);
    
    
    
    AssignArray0(&(v15->ptr[0l]), v14);
    
    MutDecref0(v14);
    int32_t v16;
    v16 = 7l;
    
    
    String * v17;
    v17 = StringLit(3, "hi");
    (v17)->refc++;
    
    Heap0 * v18;
    v18 = HeapCreate0(v16, v17);
    
    StringDecref(v17);
    int32_t v19;
    v19 = 4l;
    
    
    String * v20;
    v20 = StringLit(3, "yo");
    (v20)->refc++;
    
    Heap0 * v21;
    v21 = HeapCreate0(v19, v20);
    (v18)->refc++; (v21)->refc++;
    StringDecref(v20);
    Heap1 * v22;
    v22 = HeapCreate1(v18, v21);
    
    HeapDecref0(v18); HeapDecref0(v21);
    int32_t v23;
    v23 = 2l;
    (v22)->refc++;
    
    Heap2 * v24;
    v24 = HeapCreate2(v22, v23);
    
    HeapDecref1(v22);
    bool v25;
    v25 = true;
    
    
    US0 v28;
    if (v25){
        (v24)->refc++;
        
        v28 = US0_Held(v24);
    } else {
        
        
        v28 = US0_None();
    }
    USIncref0(&(v28));
    HeapDecref2(v24);
    Heap3 * v29;
    v29 = HeapCreate3(v28);
    
    USDecref0(&(v28));
    Mut0 * v30;
    v30 = v15->ptr[0l];
    (v30)->refc++;
    ArrayDecref1(v15);
    
    AssignMut0(&(v30->v0), v29);
    
    HeapDecref3(v29);
    Heap3 * v31;
    v31 = v30->v0;
    (v31)->refc++;
    MutDecref0(v30);
    US0 v32;
    v32 = v31->v0;
    USIncref0(&(v32));
    HeapDecref3(v31);
    return score0(v32);
}
