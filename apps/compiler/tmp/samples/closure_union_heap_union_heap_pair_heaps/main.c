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
    };
} US1;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    US1 (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    US1 (*fptr)(Closure0 *, int32_t);
    Heap3 * v0;
};
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
static inline void ClosureDecrefBody0(Closure0 * x){
    HeapDecref3(x->v0);
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
US1 f_c0(Closure0 * x, int32_t v1){
    Heap3 * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref0(x);
    
    
    bool v2;
    v2 = v1 == 0l;
    
    
    if (v2){
        
        HeapDecref3(v0);
        return US1_Absent();
    } else {
        
        
        return US1_Box(v0);
    }
}
Fun0 * ClosureCreate0(Heap3 * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = f_c0;
    x->v0 = v0;
    return (Fun0 *) x;
}
int32_t score0(US1 v0){
    
    
    switch (v0.tag) {
        case 0: { // Absent
            
            
            USDecref1(&(v0));
            return 1l;
            break;
        }
        case 1: { // Box
            Heap3 * v1 = v0.case1.v0;
            (v1)->refc++;
            USDecref1(&(v0));
            US0 v2;
            v2 = v1->v0;
            USIncref0(&(v2));
            HeapDecref3(v1);
            switch (v2.tag) {
                case 1: { // Held
                    Heap2 * v3 = v2.case1.v0;
                    (v3)->refc++;
                    USDecref0(&(v2));
                    Heap1 * v4; int32_t v5;
                    v4 = v3->v0; v5 = v3->v1;
                    (v4)->refc++;
                    HeapDecref2(v3);
                    Heap0 * v6; Heap0 * v7;
                    v6 = v4->v0; v7 = v4->v1;
                    (v6)->refc++; (v7)->refc++;
                    HeapDecref1(v4);
                    int32_t v8; String * v9;
                    v8 = v6->v0; v9 = v6->v1;
                    (v9)->refc++;
                    HeapDecref0(v6);
                    int32_t v10; String * v11;
                    v10 = v7->v0; v11 = v7->v1;
                    (v11)->refc++;
                    HeapDecref0(v7);
                    bool v12;
                    v12 = v8 == 7l;
                    
                    
                    bool v14;
                    if (v12){
                        
                        
                        bool v13;
                        v13 = strcmp(v9->ptr, "hi") == 0;
                        
                        
                        v14 = v13;
                    } else {
                        
                        
                        v14 = false;
                    }
                    
                    StringDecref(v9);
                    bool v16;
                    if (v14){
                        
                        
                        bool v15;
                        v15 = v10 == 4l;
                        
                        
                        v16 = v15;
                    } else {
                        
                        
                        v16 = false;
                    }
                    
                    
                    bool v18;
                    if (v16){
                        
                        
                        bool v17;
                        v17 = strcmp(v11->ptr, "yo") == 0;
                        
                        
                        v18 = v17;
                    } else {
                        
                        
                        v18 = false;
                    }
                    
                    StringDecref(v11);
                    bool v20;
                    if (v18){
                        
                        
                        bool v19;
                        v19 = v5 == 2l;
                        
                        
                        v20 = v19;
                    } else {
                        
                        
                        v20 = false;
                    }
                    
                    
                    if (v20){
                        
                        
                        return 0l;
                    } else {
                        
                        
                        return 1l;
                    }
                    break;
                }
                case 0: { // None
                    
                    
                    USDecref0(&(v2));
                    return 1l;
                    break;
                }
            }
            break;
        }
    }
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
    (v13)->refc++;
    USDecref0(&(v12));
    Fun0 * v14;
    v14 = ClosureCreate0(v13);
    (v14)->refc++;
    HeapDecref3(v13);
    US1 v15;
    v15 = v14->fptr(v14, 1l);
    
    (v14)->decref_fptr(v14);
    return score0(v15);
}
