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
        } case0; // Hit
    };
} US0;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*decref_fptr)(Fun1 *);
    US0 (*fptr)(Fun1 *, String *);
};
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Fun1 * (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure1 Closure1;
struct Closure1 {
    Fun1 base;
    int32_t v0;
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
};
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // Good
        struct {
            String * v0;
        } case1; // Bad
    };
} US1;
typedef struct Fun4 Fun4;
struct Fun4{
    int refc;
    void (*decref_fptr)(Fun4 *);
    US1 (*fptr)(Fun4 *, String *);
};
typedef struct Fun3 Fun3;
struct Fun3{
    int refc;
    void (*decref_fptr)(Fun3 *);
    Fun4 * (*fptr)(Fun3 *, String *);
};
typedef struct Fun2 Fun2;
struct Fun2{
    int refc;
    void (*decref_fptr)(Fun2 *);
    Fun3 * (*fptr)(Fun2 *, int32_t);
};
typedef struct Closure4 Closure4;
struct Closure4 {
    Fun4 base;
    String * v1;
    int32_t v0;
};
typedef struct Closure3 Closure3;
struct Closure3 {
    Fun3 base;
    int32_t v0;
};
typedef struct Closure2 Closure2;
struct Closure2 {
    Fun2 base;
};
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            String * v0;
            UH0 * v1;
        } case1; // Word
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
US0 US0_Hit(int32_t v0) { // Hit
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Miss() { // Miss
    US0 x;
    x.tag = 1;
    return x;
}
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, char * ptr){
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
static inline void ClosureDecrefBody1(Closure1 * x){
    (void)x;
}
static void ClosureDecref1(Fun1 * self){
    Closure1 * x = (Closure1 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
static US0 closure1(Fun1 * self, String * v1){
    Closure1 * x = (Closure1 *) self;
    int32_t v0 = x->v0;
    ClosureDecref1(self);
    bool v2 = strcmp(v1->ptr, "frames") == 0;
    StringDecref(v1);
    if (v2){
        int32_t v3 = v0 + 1l;
        return US0_Hit(v3);
    } else {
        return US0_Miss();
    }
}
static Fun1 * ClosureCreate1(int32_t v0){
    Closure1 * x = malloc(sizeof(Closure1));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref1;
    x->base.fptr = closure1;
    x->v0 = v0;
    return &x->base;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static Fun1 * closure0(Fun0 * self, int32_t v0){
    ClosureDecref0(self);
    return ClosureCreate1(v0);
}
static Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = closure0;
    return &x->base;
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
            StringDecref(x->case1.v0);
            break;
        }
    }
}
void USIncref1(US1 * x){ USIncrefBody1(x); }
void USDecref1(US1 * x){ USDecrefBody1(x); }
US1 US1_Good(int32_t v0) { // Good
    US1 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US1 US1_Bad(String * v0) { // Bad
    US1 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline String * StringConcat(String * left, String * right){
    uint32_t left_len = left->len - 1;
    uint32_t right_len = right->len - 1;
    String * result = ArrayCreate0(left_len + right_len + 1, false);
    memcpy(result->ptr, left->ptr, left_len);
    memcpy(result->ptr + left_len, right->ptr, right_len + 1);
    return result;
}
static inline void ClosureDecrefBody4(Closure4 * x){
    StringDecref(x->v1);
}
static void ClosureDecref4(Fun4 * self){
    Closure4 * x = (Closure4 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody4(x); free(x); }
}
static US1 closure4(Fun4 * self, String * v2){
    Closure4 * x = (Closure4 *) self;
    int32_t v0 = x->v0; String * v1 = x->v1;
    (v1)->refc++;
    ClosureDecref4(self);
    bool v3 = strcmp(v1->ptr, "spi") == 0;
    StringDecref(v1);
    if (v3){
        StringDecref(v2);
        int32_t v4 = v0 + 10l;
        return US1_Good(v4);
    } else {
        String * v6 = StringConcat(StringLit(23, "executor is fake, got "), v2);
        StringDecref(v2);
        return US1_Bad(v6);
    }
}
static Fun4 * ClosureCreate4(int32_t v0, String * v1){
    Closure4 * x = malloc(sizeof(Closure4));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref4;
    x->base.fptr = closure4;
    x->v0 = v0; x->v1 = v1;
    return &x->base;
}
static inline void ClosureDecrefBody3(Closure3 * x){
    (void)x;
}
static void ClosureDecref3(Fun3 * self){
    Closure3 * x = (Closure3 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody3(x); free(x); }
}
static Fun4 * closure3(Fun3 * self, String * v1){
    Closure3 * x = (Closure3 *) self;
    int32_t v0 = x->v0;
    ClosureDecref3(self);
    return ClosureCreate4(v0, v1);
}
static Fun3 * ClosureCreate3(int32_t v0){
    Closure3 * x = malloc(sizeof(Closure3));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref3;
    x->base.fptr = closure3;
    x->v0 = v0;
    return &x->base;
}
static inline void ClosureDecrefBody2(Closure2 * x){
    (void)x;
}
static void ClosureDecref2(Fun2 * self){
    Closure2 * x = (Closure2 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody2(x); free(x); }
}
static Fun3 * closure2(Fun2 * self, int32_t v0){
    ClosureDecref2(self);
    return ClosureCreate3(v0);
}
static Fun2 * ClosureCreate2(){
    Closure2 * x = malloc(sizeof(Closure2));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref2;
    x->base.fptr = closure2;
    return &x->base;
}
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 1: {
            StringDecref(x->case1.v0); UHDecref0(x->case1.v1);
            break;
        }
    }
}
static void UHDecref0(UH0 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH0 * next = NULL;
        switch (x->tag) {
            case 1: {
                StringDecref(x->case1.v0);
                next = x->case1.v1;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH0 * UH0_End() { // End
    static UH0 x = { .refc = 1073741823, .tag = 0 };
    return &x;
}
UH0 * UH0_Word(String * v0, UH0 * v1) { // Word
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
static inline String * StringSlice(String * value, int32_t from, int32_t to){
    int32_t length = (int32_t)value->len - 1;
    if (from < 0 || from > length || to < from - 1 || to >= length) { abort(); }
    uint32_t slice_len = to < from ? 0u : (uint32_t)(to - from + 1);
    if (slice_len != 0u && ((((uint8_t)value->ptr[from] & 0xC0u) == 0x80u) || (to + 1 < length && (((uint8_t)value->ptr[to + 1] & 0xC0u) == 0x80u)))) { abort(); }
    String * result = ArrayCreate0(slice_len + 1, false);
    if (slice_len != 0u) { memcpy(result->ptr, value->ptr + from, slice_len); }
    result->ptr[slice_len] = '\0';
    return result;
}
static bool starts1(String * v0, String * v1){
    int32_t v2 = v1->len-1;
    bool v3 = 1l < v2;
    if (v3){
        String * v4 = StringSlice(v1, 0l, 1l);
        StringDecref(v1);
        bool v5 = strcmp(v4->ptr, v0->ptr) == 0;
        StringDecref(v0); StringDecref(v4);
        return v5;
    } else {
        StringDecref(v0); StringDecref(v1);
        return false;
    }
}
static US1 flags_parsed0(Fun0 * v0, Fun2 * v1, int32_t v2, UH0 * v3);
static US1 continued4(Fun0 * v0, Fun2 * v1, US1 v2, UH0 * v3){
    switch (v2.tag) {
        case 1: { // Bad
            String * v6 = v2.case1.v0;
            (v6)->refc++;
            (v0)->decref_fptr(v0); (v1)->decref_fptr(v1); USDecref1(&(v2)); UHDecref0(v3);
            return US1_Bad(v6);
            break;
        }
        default: { // Good
            int32_t v4 = v2.case0.v0;
            USDecref1(&(v2));
            return flags_parsed0(v0, v1, v4, v3);
            break;
        }
    }
}
static US1 valued_then3(Fun0 * v0, Fun2 * v1, int32_t v2, String * v3, UH0 * v4){
    switch (v4->tag) {
        case 0: { // End
            (v0)->decref_fptr(v0); (v1)->decref_fptr(v1); UHDecref0(v4);
            String * v18 = StringLit(3, "--");
            (v3)->refc++; (v18)->refc++;
            bool v19 = starts1(v18, v3);
            StringDecref(v18);
            String * v24;
            if (v19){
                int32_t v20 = v3->len-1;
                int32_t v21 = v20 - 1l;
                String * v22 = StringSlice(v3, 2l, v21);
                v24 = v22;
            } else {
                String * v23 = StringLit(1, "");
                v24 = v23;
            }
            StringDecref(v3);
            String * v25 = StringConcat(v24, StringLit(15, " needs a value"));
            StringDecref(v24);
            return US1_Bad(v25);
            break;
        }
        default: { // Word
            String * v5 = v4->case1.v0; UH0 * v6 = v4->case1.v1;
            (v1)->refc++; (v5)->refc++; (v6)->refc++;
            UHDecref0(v4);
            Fun3 * v7 = v1->fptr(v1, v2);
            String * v8 = StringLit(3, "--");
            (v3)->refc++; (v8)->refc++;
            bool v9 = starts1(v8, v3);
            StringDecref(v8);
            String * v14;
            if (v9){
                int32_t v10 = v3->len-1;
                int32_t v11 = v10 - 1l;
                String * v12 = StringSlice(v3, 2l, v11);
                v14 = v12;
            } else {
                String * v13 = StringLit(1, "");
                v14 = v13;
            }
            (v7)->refc++; (v14)->refc++;
            StringDecref(v3);
            Fun4 * v15 = v7->fptr(v7, v14);
            (v5)->refc++; (v15)->refc++;
            (v7)->decref_fptr(v7); StringDecref(v14);
            US1 v16 = v15->fptr(v15, v5);
            StringDecref(v5); (v15)->decref_fptr(v15);
            return continued4(v0, v1, v16, v6);
            break;
        }
    }
}
static US1 arg_parsed2(Fun0 * v0, Fun2 * v1, int32_t v2, String * v3, UH0 * v4){
    (v0)->refc++;
    Fun1 * v5 = v0->fptr(v0, v2);
    String * v6 = StringLit(3, "--");
    (v3)->refc++; (v6)->refc++;
    bool v7 = starts1(v6, v3);
    StringDecref(v6);
    String * v12;
    if (v7){
        int32_t v8 = v3->len-1;
        int32_t v9 = v8 - 1l;
        String * v10 = StringSlice(v3, 2l, v9);
        v12 = v10;
    } else {
        String * v11 = StringLit(1, "");
        v12 = v11;
    }
    (v5)->refc++; (v12)->refc++;
    US0 v13 = v5->fptr(v5, v12);
    (v5)->decref_fptr(v5); StringDecref(v12);
    switch (v13.tag) {
        case 0: { // Hit
            StringDecref(v3);
            return flags_parsed0(v0, v1, v2, v4);
            break;
        }
        default: { // Miss
            return valued_then3(v0, v1, v2, v3, v4);
            break;
        }
    }
}
static US1 flags_parsed0(Fun0 * v0, Fun2 * v1, int32_t v2, UH0 * v3){
    switch (v3->tag) {
        case 0: { // End
            (v0)->decref_fptr(v0); (v1)->decref_fptr(v1); UHDecref0(v3);
            return US1_Good(v2);
            break;
        }
        default: { // Word
            String * v5 = v3->case1.v0; UH0 * v6 = v3->case1.v1;
            (v5)->refc++; (v6)->refc++;
            UHDecref0(v3);
            String * v7 = StringLit(3, "--");
            (v5)->refc++; (v7)->refc++;
            bool v8 = starts1(v7, v5);
            StringDecref(v7);
            String * v13;
            if (v8){
                int32_t v9 = v5->len-1;
                int32_t v10 = v9 - 1l;
                String * v11 = StringSlice(v5, 2l, v10);
                v13 = v11;
            } else {
                String * v12 = StringLit(1, "");
                v13 = v12;
            }
            bool v14 = strcmp(v13->ptr, "") == 0;
            StringDecref(v13);
            if (v14){
                (v0)->decref_fptr(v0); (v1)->decref_fptr(v1); UHDecref0(v6);
                String * v15 = StringConcat(StringLit(12, "unexpected "), v5);
                StringDecref(v5);
                return US1_Bad(v15);
            } else {
                return arg_parsed2(v0, v1, v2, v5, v6);
            }
            break;
        }
    }
}
int32_t main(){
    Fun0 * v0 = ClosureCreate0();
    Fun2 * v1 = ClosureCreate2();
    int32_t v2 = 0l;
    String * v3 = StringLit(6, "--spi");
    String * v4 = StringLit(6, "a.spi");
    String * v5 = StringLit(11, "--executor");
    String * v6 = StringLit(4, "gpu");
    UH0 * v7 = UH0_End();
    (v6)->refc++; (v7)->refc++;
    UH0 * v8 = UH0_Word(v6, v7);
    (v5)->refc++; (v8)->refc++;
    StringDecref(v6); UHDecref0(v7);
    UH0 * v9 = UH0_Word(v5, v8);
    (v4)->refc++; (v9)->refc++;
    StringDecref(v5); UHDecref0(v8);
    UH0 * v10 = UH0_Word(v4, v9);
    (v3)->refc++; (v10)->refc++;
    StringDecref(v4); UHDecref0(v9);
    UH0 * v11 = UH0_Word(v3, v10);
    (v0)->refc++; (v1)->refc++; (v11)->refc++;
    StringDecref(v3); UHDecref0(v10);
    US1 v12 = flags_parsed0(v0, v1, v2, v11);
    (v0)->decref_fptr(v0); (v1)->decref_fptr(v1); UHDecref0(v11);
    switch (v12.tag) {
        case 1: { // Bad
            String * v13 = v12.case1.v0;
            (v13)->refc++;
            USDecref1(&(v12));
            int32_t v14 = v13->len-1;
            StringDecref(v13);
            bool v15 = v14 == 25l;
            if (v15){
                return 0l;
            } else {
                return 1l;
            }
            break;
        }
        default: { // Good
            USDecref1(&(v12));
            return 2l;
            break;
        }
    }
}
