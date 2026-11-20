#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
static void UHDecref0(UH0 * x);
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case1; // Vowel
    };
} US0;
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            US0 v0;
            UH0 * v1;
        } case1; // Cons
    };
};
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_Vowel(int32_t v0) { // Vowel
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
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
static void UHDecref0(UH0 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH0 * next = NULL;
        switch (x->tag) {
            case 1: {
                next = x->case1.v1;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH0 * UH0_Nil() { // Nil
    static UH0 x = { .refc = 1073741823, .tag = 0 };
    return &x;
}
UH0 * UH0_Cons(US0 v0, UH0 * v1) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
static bool method0(UH0 * v0, UH0 * v1){
    while (1) {
        switch (v1->tag == v0->tag ? v1->tag : -1) {
            case 1: { // Cons
                US0 v2 = v1->case1.v0; UH0 * v3 = v1->case1.v1;
                US0 v4 = v0->case1.v0; UH0 * v5 = v0->case1.v1;
                if ((v3) != NULL) { (v3)->refc++; } if ((v5) != NULL) { (v5)->refc++; }
                UHDecref0(v0); UHDecref0(v1);
                bool v9;
                switch (v2.tag == v4.tag ? v2.tag : -1) {
                    case 1: { // Vowel
                        int32_t v6 = v2.case1.v0;
                        int32_t v7 = v4.case1.v0;
                        bool v8 = v6 == v7;
                        v9 = v8;
                        break;
                    }
                    default: {
                        v9 = false;
                    }
                }
                if (v9){
                    {
                        UH0 * tmp0 = v5;
                        UH0 * tmp1 = v3;
                        v0 = tmp0;
                        v1 = tmp1;
                    }
                    continue;
                } else {
                    UHDecref0(v3); UHDecref0(v5);
                    return false;
                }
                break;
            }
            case 0: { // Nil
                UHDecref0(v0); UHDecref0(v1);
                return true;
                break;
            }
            default: {
                UHDecref0(v0); UHDecref0(v1);
                return false;
            }
        }
    }
}
int32_t main(){
    int32_t v0 = 1l;
    US0 v1 = US0_Vowel(v0);
    int32_t v2 = 1l;
    US0 v3 = US0_Vowel(v2);
    int32_t v4 = 2l;
    US0 v5 = US0_Vowel(v4);
    UH0 * v6 = UH0_Nil();
    if ((v6) != NULL) { (v6)->refc++; }
    UH0 * v7 = UH0_Cons(v5, v6);
    if ((v7) != NULL) { (v7)->refc++; }
    UHDecref0(v6);
    UH0 * v8 = UH0_Cons(v1, v7);
    UHDecref0(v7);
    UH0 * v9 = UH0_Nil();
    if ((v9) != NULL) { (v9)->refc++; }
    UH0 * v10 = UH0_Cons(v5, v9);
    if ((v10) != NULL) { (v10)->refc++; }
    UHDecref0(v9);
    UH0 * v11 = UH0_Cons(v3, v10);
    UHDecref0(v10);
    UH0 * v12 = UH0_Nil();
    if ((v12) != NULL) { (v12)->refc++; }
    UH0 * v13 = UH0_Cons(v1, v12);
    UHDecref0(v12);
    bool v17;
    switch (v1.tag == v3.tag ? v1.tag : -1) {
        case 1: { // Vowel
            int32_t v14 = v1.case1.v0;
            int32_t v15 = v3.case1.v0;
            bool v16 = v14 == v15;
            v17 = v16;
            break;
        }
        default: {
            v17 = false;
        }
    }
    bool v23;
    if (v17){
        bool v21;
        switch (v1.tag == v5.tag ? v1.tag : -1) {
            case 1: { // Vowel
                int32_t v18 = v1.case1.v0;
                int32_t v19 = v5.case1.v0;
                bool v20 = v18 == v19;
                v21 = v20;
                break;
            }
            default: {
                v21 = false;
            }
        }
        bool v22 = v21 == false;
        v23 = v22;
    } else {
        v23 = false;
    }
    bool v30;
    if (v23){
        bool v27;
        switch (v1.tag == v3.tag ? v1.tag : -1) {
            case 1: { // Vowel
                int32_t v24 = v1.case1.v0;
                int32_t v25 = v3.case1.v0;
                bool v26 = v24 == v25;
                v27 = v26;
                break;
            }
            default: {
                v27 = false;
            }
        }
        if (v27){
            if ((v8) != NULL) { (v8)->refc++; } if ((v11) != NULL) { (v11)->refc++; }
            v30 = method0(v11, v8);
        } else {
            v30 = false;
        }
    } else {
        v30 = false;
    }
    UHDecref0(v11);
    bool v38;
    if (v30){
        bool v34;
        switch (v1.tag == v5.tag ? v1.tag : -1) {
            case 1: { // Vowel
                int32_t v31 = v1.case1.v0;
                int32_t v32 = v5.case1.v0;
                bool v33 = v31 == v32;
                v34 = v33;
                break;
            }
            default: {
                v34 = false;
            }
        }
        bool v36;
        if (v34){
            if ((v8) != NULL) { (v8)->refc++; } if ((v13) != NULL) { (v13)->refc++; }
            v36 = method0(v13, v8);
        } else {
            v36 = false;
        }
        bool v37 = v36 == false;
        v38 = v37;
    } else {
        v38 = false;
    }
    UHDecref0(v8); UHDecref0(v13);
    if (v38){
        return 0l;
    } else {
        return 1l;
    }
}
