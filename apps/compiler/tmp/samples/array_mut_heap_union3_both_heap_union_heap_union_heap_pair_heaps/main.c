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
    int tag;
    union {
        struct {
            Heap3 * v0;
        } case1; // Box
        struct {
            int32_t v0;
        } case2; // Mark
    };
} US1;
typedef struct {
    int refc;
    US1 v0;
} Heap4;
typedef struct {
    int refc;
    Heap4 * v0;
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
static inline void USIncrefBody1(US1 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody1(US1 * x){
    switch (x->tag) {
        case 1: {
            HeapDecref3(x->case1.v0);
            break;
        }
    }
}
void USIncref1(US1 * x){ USIncrefBody1(x); }
void USDecref1(US1 * x){ USDecrefBody1(x); }
US1 US1_Absent() { // Absent
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_Box(Heap3 * v0) { // Box
    US1 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
US1 US1_Mark(int32_t v0) { // Mark
    US1 x;
    x.tag = 2;
    x.case2.v0 = v0;
    return x;
}
static inline void HeapDecrefBody4(Heap4 * x){
    USDecref1(&(x->v0));
}
void HeapDecref4(Heap4 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody4(x); free(x); }
}
Heap4 * HeapCreate4(US1 v0){
    Heap4 * x = malloc(sizeof(Heap4));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref4(x->v0);
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(Heap4 * v0){
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
int32_t score0(US1 v0){
    
    
    switch (v0.tag) {
        case 0: { // Absent
            
            
            USDecref1(&(v0));
            return 1l;
            break;
        }
        case 1: { // Box
            Heap3 * v3 = v0.case1.v0;
            (v3)->refc++;
            USDecref1(&(v0));
            US0 v4;
            v4 = v3->v0;
            USIncref0(&(v4));
            HeapDecref3(v3);
            switch (v4.tag) {
                case 1: { // Held
                    Heap2 * v5 = v4.case1.v0;
                    (v5)->refc++;
                    USDecref0(&(v4));
                    Heap1 * v6; int32_t v7;
                    v6 = v5->v0; v7 = v5->v1;
                    (v6)->refc++;
                    HeapDecref2(v5);
                    Heap0 * v8; Heap0 * v9;
                    v8 = v6->v0; v9 = v6->v1;
                    (v8)->refc++; (v9)->refc++;
                    HeapDecref1(v6);
                    int32_t v10; String * v11;
                    v10 = v8->v0; v11 = v8->v1;
                    (v11)->refc++;
                    HeapDecref0(v8);
                    int32_t v12; String * v13;
                    v12 = v9->v0; v13 = v9->v1;
                    (v13)->refc++;
                    HeapDecref0(v9);
                    bool v14;
                    v14 = v10 == 7l;
                    
                    
                    bool v16;
                    if (v14){
                        
                        
                        bool v15;
                        v15 = strcmp(v11->ptr, "hi") == 0;
                        
                        
                        v16 = v15;
                    } else {
                        
                        
                        v16 = false;
                    }
                    
                    StringDecref(v11);
                    bool v18;
                    if (v16){
                        
                        
                        bool v17;
                        v17 = v12 == 4l;
                        
                        
                        v18 = v17;
                    } else {
                        
                        
                        v18 = false;
                    }
                    
                    
                    bool v20;
                    if (v18){
                        
                        
                        bool v19;
                        v19 = strcmp(v13->ptr, "yo") == 0;
                        
                        
                        v20 = v19;
                    } else {
                        
                        
                        v20 = false;
                    }
                    
                    StringDecref(v13);
                    bool v22;
                    if (v20){
                        
                        
                        bool v21;
                        v21 = v7 == 2l;
                        
                        
                        v22 = v21;
                    } else {
                        
                        
                        v22 = false;
                    }
                    
                    
                    if (v22){
                        
                        
                        return 0l;
                    } else {
                        
                        
                        return 1l;
                    }
                    break;
                }
                case 0: { // None
                    
                    
                    USDecref0(&(v4));
                    return 1l;
                    break;
                }
            }
            break;
        }
        case 2: { // Mark
            int32_t v1 = v0.case2.v0;
            
            USDecref1(&(v0));
            bool v2;
            v2 = v1 == 0l;
            
            
            return 1l;
            break;
        }
    }
}
static inline void AssignMut0(Heap4 * * a0, Heap4 * b0){
    (b0)->refc++;
    HeapDecref4(*a0);
    *a0 = b0;
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
    int32_t v7;
    v7 = 2l;
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
    
    USDecref0(&(v12));
    bool v14;
    v14 = true;
    
    
    US1 v17;
    if (v14){
        (v13)->refc++;
        
        v17 = US1_Box(v13);
    } else {
        
        
        v17 = US1_Mark(1l);
    }
    
    HeapDecref3(v13);
    int32_t v18;
    v18 = 3l;
    USIncref1(&(v17));
    
    Heap4 * v19;
    v19 = HeapCreate4(v17);
    
    USDecref1(&(v17));
    US1 v20;
    v20 = US1_Mark(v18);
    USIncref1(&(v20));
    
    Heap4 * v21;
    v21 = HeapCreate4(v20);
    (v19)->refc++;
    USDecref1(&(v20));
    Mut0 * v22;
    v22 = MutCreate0(v19);
    
    HeapDecref4(v19);
    Array1 * v23;
    v23 = ArrayCreate1(1l, true);
    
    
    
    AssignArray0(&(v23->ptr[0l]), v22);
    
    MutDecref0(v22);
    Mut0 * v24;
    v24 = v23->ptr[0l];
    (v24)->refc++;
    ArrayDecref1(v23);
    Heap4 * v25;
    v25 = v24->v0;
    (v25)->refc++;
    
    US1 v26;
    v26 = v25->v0;
    USIncref1(&(v26));USIncref1(&(v26));
    HeapDecref4(v25);
    int32_t v27;
    v27 = score0(v26);
    
    USDecref1(&(v26));
    
    AssignMut0(&(v24->v0), v21);
    
    HeapDecref4(v21);
    Heap4 * v28;
    v28 = v24->v0;
    (v28)->refc++;
    MutDecref0(v24);
    US1 v29;
    v29 = v28->v0;
    USIncref1(&(v29));USIncref1(&(v29));
    HeapDecref4(v28);
    int32_t v30;
    v30 = score0(v29);
    
    USDecref1(&(v29));
    bool v31;
    v31 = v27 == 0l;
    
    
    bool v33;
    if (v31){
        
        
        bool v32;
        v32 = v30 == 1l;
        
        
        v33 = v32;
    } else {
        
        
        v33 = false;
    }
    
    
    if (v33){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
