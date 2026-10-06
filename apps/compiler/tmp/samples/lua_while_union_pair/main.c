#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
typedef struct {
    int refc;
    int32_t v0;
} Mut0;
typedef struct {
    int refc;
    int32_t v0;
} Mut1;
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v1;
            int32_t v0;
        } case1; // Cons
    };
};
typedef struct {
    int refc;
    UH0 * v0;
} Mut2;
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
static inline void MutDecrefBody0(Mut0 * x){
    
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(int32_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
bool method_while0(Mut0 * v0){
    
    
    int32_t v1;
    v1 = v0->v0;
    
    
    bool v2;
    v2 = v1 < 3l;
    
    
    return v2;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    
    
    *a = b;
}
static inline void AssignMut0(int32_t * a0, int32_t b0){
    
    
    *a0 = b0;
}
static inline void MutDecrefBody1(Mut1 * x){
    
}
void MutDecref1(Mut1 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody1(x); free(x); }
}
Mut1 * MutCreate1(int32_t v0){
    Mut1 * x = malloc(sizeof(Mut1));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 1: {
            UHDecref0(x->case1.v1);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH0 * UH0_1(int32_t v0, UH0 * v1) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
static inline void MutDecrefBody2(Mut2 * x){
    UHDecref0(x->v0);
}
void MutDecref2(Mut2 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody2(x); free(x); }
}
Mut2 * MutCreate2(UH0 * v0){
    Mut2 * x = malloc(sizeof(Mut2));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
bool method_while1(Mut1 * v0){
    
    
    int32_t v1;
    v1 = v0->v0;
    
    
    bool v2;
    v2 = v1 < 4l;
    
    
    return v2;
}
static inline void AssignMut1(UH0 * * a0, UH0 * b0){
    b0->refc++;
    UHDecref0(*a0);
    *a0 = b0;
}
int32_t main(){
    
    
    Array0 * v0;
    v0 = ArrayCreate0(3l, false);
    
    
    Mut0 * v1;
    v1 = MutCreate0(0l);
    
    
    
    while (method_while0(v1)){
        
        
        int32_t v3;
        v3 = v1->v0;
        
        
        
        
        
        
        int32_t v4;
        v4 = v3 * 5l;
        
        
        
        AssignArray0(&(v0->ptr[v3]), v4);
        
        
        int32_t v5;
        v5 = v3 + 1l;
        
        
        
        AssignMut0(&(v1->v0), v5);
        
        
        
    }
    
    
    
    
    
    MutDecref0(v1);
    Mut1 * v6;
    v6 = MutCreate1(0l);
    
    
    Mut1 * v7;
    v7 = MutCreate1(0l);
    
    
    UH0 * v8;
    v8 = UH0_0();
    v8->refc++;
    
    Mut2 * v9;
    v9 = MutCreate2(v8);
    
    UHDecref0(v8);
    
    while (method_while1(v6)){
        
        
        int32_t v11;
        v11 = v6->v0;
        
        
        int32_t v12;
        v12 = v11 % 2l;
        
        
        bool v13;
        v13 = v12 == 1l;
        
        
        
        if (v13){
            
            
            int32_t v14;
            v14 = v7->v0;
            
            
            int32_t v15;
            v15 = v14 + 1l;
            
            
            
            AssignMut0(&(v7->v0), v15);
            
            
            
        } else {
            
            
            
        }
        
        
        UH0 * v16;
        v16 = v9->v0;
        v16->refc += 2;
        
        UH0 * v17;
        v17 = UH0_1(v11, v16);
        
        UHDecref0(v16);
        
        AssignMut1(&(v9->v0), v17);
        
        UHDecref0(v17);
        int32_t v18;
        v18 = v11 + 1l;
        
        
        
        AssignMut0(&(v6->v0), v18);
        
        
        
    }
    
    MutDecref1(v6);
    UH0 * v19;
    v19 = v9->v0;
    v19->refc++;
    MutDecref2(v9);
    int32_t v38;
    switch (v19->tag) {
        case 1: { // Cons
            int32_t v20 = v19->case1.v0; UH0 * v21 = v19->case1.v1;
            v21->refc++;
            
            switch (v21->tag) {
                case 1: { // Cons
                    int32_t v22 = v21->case1.v0; UH0 * v23 = v21->case1.v1;
                    v23->refc++;
                    UHDecref0(v21);
                    switch (v23->tag) {
                        case 1: { // Cons
                            int32_t v24 = v23->case1.v0; UH0 * v25 = v23->case1.v1;
                            v25->refc++;
                            UHDecref0(v23);
                            switch (v25->tag) {
                                case 1: { // Cons
                                    int32_t v26 = v25->case1.v0; UH0 * v27 = v25->case1.v1;
                                    v27->refc++;
                                    UHDecref0(v25);
                                    switch (v27->tag) {
                                        case 0: { // Nil
                                            
                                            
                                            UHDecref0(v27);
                                            int32_t v28;
                                            v28 = v20 * 64l;
                                            
                                            
                                            int32_t v29;
                                            v29 = v22 * 16l;
                                            
                                            
                                            int32_t v30;
                                            v30 = v28 + v29;
                                            
                                            
                                            int32_t v31;
                                            v31 = v24 * 4l;
                                            
                                            
                                            int32_t v32;
                                            v32 = v30 + v31;
                                            
                                            
                                            int32_t v33;
                                            v33 = v32 + v26;
                                            
                                            
                                            v38 = v33;
                                            break;
                                        }
                                        default: {
                                            
                                            UHDecref0(v27);
                                            v38 = -1l;
                                        }
                                    }
                                    break;
                                }
                                default: {
                                    
                                    UHDecref0(v25);
                                    v38 = -1l;
                                }
                            }
                            break;
                        }
                        default: {
                            
                            UHDecref0(v23);
                            v38 = -1l;
                        }
                    }
                    break;
                }
                default: {
                    
                    UHDecref0(v21);
                    v38 = -1l;
                }
            }
            break;
        }
        default: {
            
            
            v38 = -1l;
        }
    }
    
    UHDecref0(v19);
    int32_t v39;
    v39 = v7->v0;
    
    MutDecref1(v7);
    int32_t v40;
    v40 = v38 + v39;
    
    
    int32_t v41;
    v41 = v0->ptr[2l];
    
    
    int32_t v42;
    v42 = v40 + v41;
    
    
    int32_t v43;
    v43 = v0->ptr[1l];
    
    ArrayDecref0(v0);
    int32_t v44;
    v44 = v42 - v43;
    
    
    return v44;
}
