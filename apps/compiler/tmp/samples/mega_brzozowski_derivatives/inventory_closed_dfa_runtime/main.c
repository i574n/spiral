#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
typedef struct UH2 UH2;
void UHDecref2(UH2 * x);
typedef struct UH1 UH1;
void UHDecref1(UH1 * x);
typedef struct UH3 UH3;
void UHDecref3(UH3 * x);
typedef struct UH5 UH5;
void UHDecref5(UH5 * x);
typedef struct UH4 UH4;
void UHDecref4(UH4 * x);
typedef struct UH6 UH6;
void UHDecref6(UH6 * x);
typedef struct UH7 UH7;
void UHDecref7(UH7 * x);
typedef struct UH8 UH8;
void UHDecref8(UH8 * x);
typedef struct {
    int tag;
    union {
    };
} US0;
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            US0 v0;
            UH0 * v1;
        } case1; // SymbolListCons
    };
};
struct UH2 {
    int refc;
    int tag;
    union {
        struct {
            US0 v0;
            UH2 * v1;
        } case1; // InputCons
    };
};
struct UH1 {
    int refc;
    int tag;
    union {
        struct {
            UH2 * v0;
            UH1 * v1;
        } case1; // InputListCons
    };
};
typedef struct {
    int tag;
    union {
    };
} US1;
struct UH3 {
    int refc;
    int tag;
    union {
        struct {
            US1 v0;
            UH3 * v1;
        } case1; // SymbolListCons
    };
};
struct UH5 {
    int refc;
    int tag;
    union {
        struct {
            US1 v0;
            UH5 * v1;
        } case1; // InputCons
    };
};
struct UH4 {
    int refc;
    int tag;
    union {
        struct {
            UH5 * v0;
            UH4 * v1;
        } case1; // InputListCons
    };
};
typedef struct {
    int tag;
    union {
    };
} US2;
struct UH6 {
    int refc;
    int tag;
    union {
        struct {
            US2 v0;
            UH6 * v1;
        } case1; // InputCons
    };
};
struct UH7 {
    int refc;
    int tag;
    union {
        struct {
            US0 v0;
        } case2; // RegexChar
        struct {
            UH7 * v0;
            UH7 * v1;
        } case3; // RegexAlt
        struct {
            UH7 * v0;
            UH7 * v1;
        } case4; // RegexCat
        struct {
            UH7 * v0;
        } case5; // RegexStar
    };
};
typedef struct {
    int tag;
    union {
    };
} US3;
typedef struct {
    int tag;
    union {
    };
} US4;
typedef struct {
    int tag;
    union {
    };
} US5;
struct UH8 {
    int refc;
    int tag;
    union {
        struct {
            US1 v0;
        } case2; // RegexChar
        struct {
            UH8 * v0;
            UH8 * v1;
        } case3; // RegexAlt
        struct {
            UH8 * v0;
            UH8 * v1;
        } case4; // RegexCat
        struct {
            UH8 * v0;
        } case5; // RegexStar
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
US0 US0_0() { // BitZero
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1() { // BitOne
    US0 x;
    x.tag = 1;
    return x;
}
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 1: {
            USDecref0(&(x->case1.v0)); UHDecref0(x->case1.v1);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0() { // SymbolListNil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH0 * UH0_1(US0 v0, UH0 * v1) { // SymbolListCons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
static inline void UHDecrefBody2(UH2 * x){
    switch (x->tag) {
        case 1: {
            USDecref0(&(x->case1.v0)); UHDecref2(x->case1.v1);
            break;
        }
    }
}
void UHDecref2(UH2 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody2(x); free(x); }
}
UH2 * UH2_0() { // InputEmpty
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH2 * UH2_1(US0 v0, UH2 * v1) { // InputCons
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
static inline void UHDecrefBody1(UH1 * x){
    switch (x->tag) {
        case 1: {
            UHDecref2(x->case1.v0); UHDecref1(x->case1.v1);
            break;
        }
    }
}
void UHDecref1(UH1 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody1(x); free(x); }
}
UH1 * UH1_0() { // InputListNil
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH1 * UH1_1(UH2 * v0, UH1 * v1) { // InputListCons
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
UH1 * input_singletons_from_symbols0(UH0 * v0){
    
    
    switch (v0->tag) {
        case 1: { // SymbolListCons
            US0 v2 = v0->case1.v0; UH0 * v3 = v0->case1.v1;
            USIncref0(&(v2)); v3->refc += 2;
            UHDecref0(v0);
            UH1 * v4;
            v4 = input_singletons_from_symbols0(v3);
            
            UHDecref0(v3);
            UH2 * v5;
            v5 = UH2_0();
            USIncref0(&(v2)); v5->refc++;
            
            UH2 * v6;
            v6 = UH2_1(v2, v5);
            
            USDecref0(&(v2)); UHDecref2(v5);
            return UH1_1(v6, v4);
            break;
        }
        case 0: { // SymbolListNil
            
            
            UHDecref0(v0);
            return UH1_0();
            break;
        }
    }
}
UH1 * input_prepend_symbol_to_corpus2(US0 v0, UH1 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputListCons
            UH2 * v3 = v1->case1.v0; UH1 * v4 = v1->case1.v1;
            USIncref0(&(v0)); v3->refc++; v4->refc += 2;
            UHDecref1(v1);
            UH1 * v5;
            v5 = input_prepend_symbol_to_corpus2(v0, v4);
            USIncref0(&(v0)); v3->refc++;
            UHDecref1(v4);
            UH2 * v6;
            v6 = UH2_1(v0, v3);
            
            USDecref0(&(v0)); UHDecref2(v3);
            return UH1_1(v6, v5);
            break;
        }
        case 0: { // InputListNil
            
            
            USDecref0(&(v0)); UHDecref1(v1);
            return UH1_0();
            break;
        }
    }
}
UH1 * input_list_append3(UH1 * v0, UH1 * v1){
    
    
    switch (v0->tag) {
        case 1: { // InputListCons
            UH2 * v2 = v0->case1.v0; UH1 * v3 = v0->case1.v1;
            v1->refc++; v2->refc++; v3->refc += 2;
            UHDecref1(v0);
            UH1 * v4;
            v4 = input_list_append3(v3, v1);
            
            UHDecref1(v1); UHDecref1(v3);
            return UH1_1(v2, v4);
            break;
        }
        case 0: { // InputListNil
            
            
            UHDecref1(v0);
            return v1;
            break;
        }
    }
}
UH1 * input_prepend_symbols_to_corpus1(UH0 * v0, UH1 * v1){
    
    
    switch (v0->tag) {
        case 1: { // SymbolListCons
            US0 v3 = v0->case1.v0; UH0 * v4 = v0->case1.v1;
            v1->refc++; USIncref0(&(v3));USIncref0(&(v3)); v4->refc++;
            UHDecref0(v0);
            UH1 * v5;
            v5 = input_prepend_symbol_to_corpus2(v3, v1);
            v1->refc++; v4->refc++;
            USDecref0(&(v3));
            UH1 * v6;
            v6 = input_prepend_symbols_to_corpus1(v4, v1);
            
            UHDecref1(v1); UHDecref0(v4);
            return input_list_append3(v5, v6);
            break;
        }
        case 0: { // SymbolListNil
            
            
            UHDecref0(v0); UHDecref1(v1);
            return UH1_0();
            break;
        }
    }
}
static inline void USIncrefBody1(US1 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody1(US1 * x){
    switch (x->tag) {
    }
}
void USIncref1(US1 * x){ USIncrefBody1(x); }
void USDecref1(US1 * x){ USDecrefBody1(x); }
US1 US1_0() { // TriA
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_1() { // TriB
    US1 x;
    x.tag = 1;
    return x;
}
US1 US1_2() { // TriC
    US1 x;
    x.tag = 2;
    return x;
}
static inline void UHDecrefBody3(UH3 * x){
    switch (x->tag) {
        case 1: {
            USDecref1(&(x->case1.v0)); UHDecref3(x->case1.v1);
            break;
        }
    }
}
void UHDecref3(UH3 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody3(x); free(x); }
}
UH3 * UH3_0() { // SymbolListNil
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH3 * UH3_1(US1 v0, UH3 * v1) { // SymbolListCons
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
static inline void UHDecrefBody5(UH5 * x){
    switch (x->tag) {
        case 1: {
            USDecref1(&(x->case1.v0)); UHDecref5(x->case1.v1);
            break;
        }
    }
}
void UHDecref5(UH5 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody5(x); free(x); }
}
UH5 * UH5_0() { // InputEmpty
    UH5 * x = malloc(sizeof(UH5));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH5 * UH5_1(US1 v0, UH5 * v1) { // InputCons
    UH5 * x = malloc(sizeof(UH5));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
static inline void UHDecrefBody4(UH4 * x){
    switch (x->tag) {
        case 1: {
            UHDecref5(x->case1.v0); UHDecref4(x->case1.v1);
            break;
        }
    }
}
void UHDecref4(UH4 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody4(x); free(x); }
}
UH4 * UH4_0() { // InputListNil
    UH4 * x = malloc(sizeof(UH4));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH4 * UH4_1(UH5 * v0, UH4 * v1) { // InputListCons
    UH4 * x = malloc(sizeof(UH4));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
UH4 * input_singletons_from_symbols4(UH3 * v0){
    
    
    switch (v0->tag) {
        case 1: { // SymbolListCons
            US1 v2 = v0->case1.v0; UH3 * v3 = v0->case1.v1;
            USIncref1(&(v2)); v3->refc += 2;
            UHDecref3(v0);
            UH4 * v4;
            v4 = input_singletons_from_symbols4(v3);
            
            UHDecref3(v3);
            UH5 * v5;
            v5 = UH5_0();
            USIncref1(&(v2)); v5->refc++;
            
            UH5 * v6;
            v6 = UH5_1(v2, v5);
            
            USDecref1(&(v2)); UHDecref5(v5);
            return UH4_1(v6, v4);
            break;
        }
        case 0: { // SymbolListNil
            
            
            UHDecref3(v0);
            return UH4_0();
            break;
        }
    }
}
UH4 * input_prepend_symbol_to_corpus6(US1 v0, UH4 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputListCons
            UH5 * v3 = v1->case1.v0; UH4 * v4 = v1->case1.v1;
            USIncref1(&(v0)); v3->refc++; v4->refc += 2;
            UHDecref4(v1);
            UH4 * v5;
            v5 = input_prepend_symbol_to_corpus6(v0, v4);
            USIncref1(&(v0)); v3->refc++;
            UHDecref4(v4);
            UH5 * v6;
            v6 = UH5_1(v0, v3);
            
            USDecref1(&(v0)); UHDecref5(v3);
            return UH4_1(v6, v5);
            break;
        }
        case 0: { // InputListNil
            
            
            USDecref1(&(v0)); UHDecref4(v1);
            return UH4_0();
            break;
        }
    }
}
UH4 * input_list_append7(UH4 * v0, UH4 * v1){
    
    
    switch (v0->tag) {
        case 1: { // InputListCons
            UH5 * v2 = v0->case1.v0; UH4 * v3 = v0->case1.v1;
            v1->refc++; v2->refc++; v3->refc += 2;
            UHDecref4(v0);
            UH4 * v4;
            v4 = input_list_append7(v3, v1);
            
            UHDecref4(v1); UHDecref4(v3);
            return UH4_1(v2, v4);
            break;
        }
        case 0: { // InputListNil
            
            
            UHDecref4(v0);
            return v1;
            break;
        }
    }
}
UH4 * input_prepend_symbols_to_corpus5(UH3 * v0, UH4 * v1){
    
    
    switch (v0->tag) {
        case 1: { // SymbolListCons
            US1 v3 = v0->case1.v0; UH3 * v4 = v0->case1.v1;
            v1->refc++; USIncref1(&(v3));USIncref1(&(v3)); v4->refc++;
            UHDecref3(v0);
            UH4 * v5;
            v5 = input_prepend_symbol_to_corpus6(v3, v1);
            v1->refc++; v4->refc++;
            USDecref1(&(v3));
            UH4 * v6;
            v6 = input_prepend_symbols_to_corpus5(v4, v1);
            
            UHDecref4(v1); UHDecref3(v4);
            return input_list_append7(v5, v6);
            break;
        }
        case 0: { // SymbolListNil
            
            
            UHDecref3(v0); UHDecref4(v1);
            return UH4_0();
            break;
        }
    }
}
static inline void USIncrefBody2(US2 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody2(US2 * x){
    switch (x->tag) {
    }
}
void USIncref2(US2 * x){ USIncrefBody2(x); }
void USDecref2(US2 * x){ USDecrefBody2(x); }
US2 US2_0() { // ModelA
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_1() { // ModelB
    US2 x;
    x.tag = 1;
    return x;
}
US2 US2_2() { // ModelC
    US2 x;
    x.tag = 2;
    return x;
}
static inline void UHDecrefBody6(UH6 * x){
    switch (x->tag) {
        case 1: {
            USDecref2(&(x->case1.v0)); UHDecref6(x->case1.v1);
            break;
        }
    }
}
void UHDecref6(UH6 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody6(x); free(x); }
}
UH6 * UH6_0() { // InputEmpty
    UH6 * x = malloc(sizeof(UH6));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH6 * UH6_1(US2 v0, UH6 * v1) { // InputCons
    UH6 * x = malloc(sizeof(UH6));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
static inline void UHDecrefBody7(UH7 * x){
    switch (x->tag) {
        case 2: {
            USDecref0(&(x->case2.v0));
            break;
        }
        case 3: {
            UHDecref7(x->case3.v0); UHDecref7(x->case3.v1);
            break;
        }
        case 4: {
            UHDecref7(x->case4.v0); UHDecref7(x->case4.v1);
            break;
        }
        case 5: {
            UHDecref7(x->case5.v0);
            break;
        }
    }
}
void UHDecref7(UH7 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody7(x); free(x); }
}
UH7 * UH7_0() { // RegexEmpty
    UH7 * x = malloc(sizeof(UH7));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH7 * UH7_1() { // RegexEpsilon
    UH7 * x = malloc(sizeof(UH7));
    x->tag = 1;
    x->refc = 1;
    return x;
}
UH7 * UH7_2(US0 v0) { // RegexChar
    UH7 * x = malloc(sizeof(UH7));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0;
    return x;
}
UH7 * UH7_3(UH7 * v0, UH7 * v1) { // RegexAlt
    UH7 * x = malloc(sizeof(UH7));
    x->tag = 3;
    x->refc = 1;
    x->case3.v0 = v0; x->case3.v1 = v1;
    return x;
}
UH7 * UH7_4(UH7 * v0, UH7 * v1) { // RegexCat
    UH7 * x = malloc(sizeof(UH7));
    x->tag = 4;
    x->refc = 1;
    x->case4.v0 = v0; x->case4.v1 = v1;
    return x;
}
UH7 * UH7_5(UH7 * v0) { // RegexStar
    UH7 * x = malloc(sizeof(UH7));
    x->tag = 5;
    x->refc = 1;
    x->case5.v0 = v0;
    return x;
}
static inline void USIncrefBody3(US3 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody3(US3 * x){
    switch (x->tag) {
    }
}
void USIncref3(US3 * x){ USIncrefBody3(x); }
void USDecref3(US3 * x){ USDecrefBody3(x); }
US3 US3_0() { // InventoryDfaAccepted
    US3 x;
    x.tag = 0;
    return x;
}
US3 US3_1() { // InventoryDfaRejected
    US3 x;
    x.tag = 1;
    return x;
}
US3 US3_2() { // InventoryDfaInputOutsideInventory
    US3 x;
    x.tag = 2;
    return x;
}
static inline void USIncrefBody4(US4 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody4(US4 * x){
    switch (x->tag) {
    }
}
void USIncref4(US4 * x){ USIncrefBody4(x); }
void USDecref4(US4 * x){ USDecrefBody4(x); }
US4 US4_0() { // SymbolLess
    US4 x;
    x.tag = 0;
    return x;
}
US4 US4_1() { // SymbolSame
    US4 x;
    x.tag = 1;
    return x;
}
US4 US4_2() { // SymbolGreater
    US4 x;
    x.tag = 2;
    return x;
}
US3 loop9(int32_t v0, UH2 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US0 v6 = v1->case1.v0; UH2 * v7 = v1->case1.v1;
            USIncref0(&(v6)); v7->refc++;
            UHDecref2(v1);
            US4 v11;
            switch (v6.tag) {
                case 1: { // BitOne
                    
                    
                    
                    v11 = US4_2();
                    break;
                }
                case 0: { // BitZero
                    
                    
                    
                    v11 = US4_1();
                    break;
                }
            }
            
            
            bool v12;
            switch (v11.tag) {
                case 1: { // SymbolSame
                    
                    
                    
                    v12 = true;
                    break;
                }
                default: {
                    
                    
                    v12 = false;
                }
            }
            
            USDecref4(&(v11));
            int32_t v19;
            if (v12){
                
                
                v19 = 0l;
            } else {
                
                
                US4 v16;
                switch (v6.tag) {
                    case 1: { // BitOne
                        
                        
                        
                        v16 = US4_1();
                        break;
                    }
                    case 0: { // BitZero
                        
                        
                        
                        v16 = US4_0();
                        break;
                    }
                }
                
                
                bool v17;
                switch (v16.tag) {
                    case 1: { // SymbolSame
                        
                        
                        
                        v17 = true;
                        break;
                    }
                    default: {
                        
                        
                        v17 = false;
                    }
                }
                
                USDecref4(&(v16));
                if (v17){
                    
                    
                    v19 = 1l;
                } else {
                    
                    
                    v19 = -1l;
                }
            }
            
            USDecref0(&(v6));
            bool v20;
            v20 = v19 < 0l;
            
            
            if (v20){
                
                UHDecref2(v7);
                return US3_2();
            } else {
                
                
                bool v22;
                v22 = v0 == 0l;
                
                
                int32_t v27;
                if (v22){
                    
                    
                    bool v23;
                    v23 = v19 == 0l;
                    
                    
                    if (v23){
                        
                        
                        v27 = 0l;
                    } else {
                        
                        
                        v27 = 1l;
                    }
                } else {
                    
                    
                    bool v25;
                    v25 = v19 == 0l;
                    
                    
                    if (v25){
                        
                        
                        v27 = 0l;
                    } else {
                        
                        
                        v27 = 1l;
                    }
                }
                
                
                return loop9(v27, v7);
            }
            break;
        }
        case 0: { // InputEmpty
            
            
            UHDecref2(v1);
            bool v2;
            v2 = v0 == 0l;
            
            
            if (v2){
                
                
                return US3_0();
            } else {
                
                
                return US3_1();
            }
            break;
        }
    }
}
US4 regex_compare15(UH7 * v0, UH7 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH7 * v53 = v0->case3.v0; UH7 * v54 = v0->case3.v1;
            v53->refc++; v54->refc++;
            UHDecref7(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    UH7 * v55 = v1->case3.v0; UH7 * v56 = v1->case3.v1;
                    v53->refc++; v55->refc += 2; v56->refc++;
                    UHDecref7(v1);
                    US4 v57;
                    v57 = regex_compare15(v53, v55);
                    
                    UHDecref7(v53); UHDecref7(v55);
                    switch (v57.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref4(&(v57));
                            return regex_compare15(v54, v56);
                            break;
                        }
                        default: {
                            
                            UHDecref7(v54); UHDecref7(v56);
                            return v57;
                        }
                    }
                    break;
                }
                default: {
                    
                    UHDecref7(v1); UHDecref7(v53); UHDecref7(v54);
                    return US4_2();
                }
            }
            break;
        }
        case 4: { // RegexCat
            UH7 * v28 = v0->case4.v0; UH7 * v29 = v0->case4.v1;
            v28->refc++; v29->refc++;
            UHDecref7(v0);
            switch (v1->tag) {
                case 4: { // RegexCat
                    UH7 * v34 = v1->case4.v0; UH7 * v35 = v1->case4.v1;
                    v28->refc++; v34->refc += 2; v35->refc++;
                    UHDecref7(v1);
                    US4 v36;
                    v36 = regex_compare15(v28, v34);
                    
                    UHDecref7(v28); UHDecref7(v34);
                    switch (v36.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref4(&(v36));
                            return regex_compare15(v29, v35);
                            break;
                        }
                        default: {
                            
                            UHDecref7(v29); UHDecref7(v35);
                            return v36;
                        }
                    }
                    break;
                }
                case 2: { // RegexChar
                    
                    
                    UHDecref7(v1); UHDecref7(v28); UHDecref7(v29);
                    return US4_2();
                    break;
                }
                case 0: { // RegexEmpty
                    
                    
                    UHDecref7(v1); UHDecref7(v28); UHDecref7(v29);
                    return US4_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref7(v1); UHDecref7(v28); UHDecref7(v29);
                    return US4_2();
                    break;
                }
                default: {
                    
                    UHDecref7(v1); UHDecref7(v28); UHDecref7(v29);
                    return US4_0();
                }
            }
            break;
        }
        case 2: { // RegexChar
            US0 v10 = v0->case2.v0;
            USIncref0(&(v10));
            UHDecref7(v0);
            switch (v1->tag) {
                case 2: { // RegexChar
                    US0 v13 = v1->case2.v0;
                    USIncref0(&(v13));
                    UHDecref7(v1);
                    switch (v10.tag) {
                        case 1: { // BitOne
                            
                            
                            USDecref0(&(v10));
                            switch (v13.tag) {
                                case 1: { // BitOne
                                    
                                    
                                    USDecref0(&(v13));
                                    return US4_1();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    USDecref0(&(v13));
                                    return US4_2();
                                    break;
                                }
                            }
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            USDecref0(&(v10));
                            switch (v13.tag) {
                                case 1: { // BitOne
                                    
                                    
                                    USDecref0(&(v13));
                                    return US4_0();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    USDecref0(&(v13));
                                    return US4_1();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
                case 0: { // RegexEmpty
                    
                    
                    UHDecref7(v1); USDecref0(&(v10));
                    return US4_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref7(v1); USDecref0(&(v10));
                    return US4_2();
                    break;
                }
                default: {
                    
                    UHDecref7(v1); USDecref0(&(v10));
                    return US4_0();
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref7(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref7(v1);
                    return US4_1();
                    break;
                }
                default: {
                    
                    UHDecref7(v1);
                    return US4_0();
                }
            }
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref7(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref7(v1);
                    return US4_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref7(v1);
                    return US4_1();
                    break;
                }
                default: {
                    
                    UHDecref7(v1);
                    return US4_0();
                }
            }
            break;
        }
        case 5: { // RegexStar
            UH7 * v44 = v0->case5.v0;
            v44->refc++;
            UHDecref7(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    
                    
                    UHDecref7(v1); UHDecref7(v44);
                    return US4_0();
                    break;
                }
                case 5: { // RegexStar
                    UH7 * v48 = v1->case5.v0;
                    v48->refc++;
                    UHDecref7(v1);
                    return regex_compare15(v44, v48);
                    break;
                }
                default: {
                    
                    UHDecref7(v1); UHDecref7(v44);
                    return US4_2();
                }
            }
            break;
        }
    }
}
UH7 * alt_insert_sorted14(UH7 * v0, UH7 * v1){
    
    
    switch (v1->tag) {
        case 3: { // RegexAlt
            UH7 * v2 = v1->case3.v0; UH7 * v3 = v1->case3.v1;
            v0->refc++; v2->refc += 2; v3->refc++;
            
            US4 v4;
            v4 = regex_compare15(v0, v2);
            
            
            switch (v4.tag) {
                case 2: { // SymbolGreater
                    
                    v0->refc++; v3->refc++;
                    UHDecref7(v1); USDecref4(&(v4));
                    UH7 * v6;
                    v6 = alt_insert_sorted14(v0, v3);
                    
                    UHDecref7(v0); UHDecref7(v3);
                    return UH7_3(v2, v6);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    UHDecref7(v2); UHDecref7(v3); USDecref4(&(v4));
                    return UH7_3(v0, v1);
                    break;
                }
                case 1: { // SymbolSame
                    
                    
                    UHDecref7(v0); UHDecref7(v2); UHDecref7(v3); USDecref4(&(v4));
                    return v1;
                    break;
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref7(v1);
            return v0;
            break;
        }
        default: {
            v0->refc++; v1->refc++;
            
            US4 v11;
            v11 = regex_compare15(v0, v1);
            
            
            switch (v11.tag) {
                case 2: { // SymbolGreater
                    
                    
                    USDecref4(&(v11));
                    return UH7_3(v1, v0);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    USDecref4(&(v11));
                    return UH7_3(v0, v1);
                    break;
                }
                case 1: { // SymbolSame
                    
                    
                    UHDecref7(v0); USDecref4(&(v11));
                    return v1;
                    break;
                }
            }
        }
    }
}
UH7 * make_alt13(UH7 * v0, UH7 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH7 * v2 = v0->case3.v0; UH7 * v3 = v0->case3.v1;
            v1->refc++; v2->refc += 2; v3->refc++;
            UHDecref7(v0);
            UH7 * v4;
            v4 = alt_insert_sorted14(v2, v1);
            
            UHDecref7(v1); UHDecref7(v2);
            return make_alt13(v3, v4);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref7(v0);
            return v1;
            break;
        }
        default: {
            
            
            return alt_insert_sorted14(v0, v1);
        }
    }
}
bool regex_equal17(UH7 * v0, UH7 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH7 * v18 = v0->case3.v0; UH7 * v19 = v0->case3.v1;
            v18->refc++; v19->refc++;
            UHDecref7(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    UH7 * v20 = v1->case3.v0; UH7 * v21 = v1->case3.v1;
                    v18->refc++; v20->refc += 2; v21->refc++;
                    UHDecref7(v1);
                    bool v22;
                    v22 = regex_equal17(v18, v20);
                    
                    UHDecref7(v18); UHDecref7(v20);
                    if (v22){
                        
                        
                        return regex_equal17(v19, v21);
                    } else {
                        
                        UHDecref7(v19); UHDecref7(v21);
                        return false;
                    }
                    break;
                }
                default: {
                    
                    UHDecref7(v1); UHDecref7(v18); UHDecref7(v19);
                    return false;
                }
            }
            break;
        }
        case 4: { // RegexCat
            UH7 * v26 = v0->case4.v0; UH7 * v27 = v0->case4.v1;
            v26->refc++; v27->refc++;
            UHDecref7(v0);
            switch (v1->tag) {
                case 4: { // RegexCat
                    UH7 * v28 = v1->case4.v0; UH7 * v29 = v1->case4.v1;
                    v26->refc++; v28->refc += 2; v29->refc++;
                    UHDecref7(v1);
                    bool v30;
                    v30 = regex_equal17(v26, v28);
                    
                    UHDecref7(v26); UHDecref7(v28);
                    if (v30){
                        
                        
                        return regex_equal17(v27, v29);
                    } else {
                        
                        UHDecref7(v27); UHDecref7(v29);
                        return false;
                    }
                    break;
                }
                default: {
                    
                    UHDecref7(v1); UHDecref7(v26); UHDecref7(v27);
                    return false;
                }
            }
            break;
        }
        case 2: { // RegexChar
            US0 v4 = v0->case2.v0;
            USIncref0(&(v4));
            UHDecref7(v0);
            switch (v1->tag) {
                case 2: { // RegexChar
                    US0 v5 = v1->case2.v0;
                    USIncref0(&(v5));
                    UHDecref7(v1);
                    US4 v15;
                    switch (v4.tag) {
                        case 1: { // BitOne
                            
                            
                            
                            switch (v5.tag) {
                                case 1: { // BitOne
                                    
                                    
                                    
                                    v15 = US4_1();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    
                                    v15 = US4_2();
                                    break;
                                }
                            }
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            
                            switch (v5.tag) {
                                case 1: { // BitOne
                                    
                                    
                                    
                                    v15 = US4_0();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    
                                    v15 = US4_1();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    
                    USDecref0(&(v4)); USDecref0(&(v5));
                    switch (v15.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref4(&(v15));
                            return true;
                            break;
                        }
                        default: {
                            
                            USDecref4(&(v15));
                            return false;
                        }
                    }
                    break;
                }
                default: {
                    
                    UHDecref7(v1); USDecref0(&(v4));
                    return false;
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref7(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref7(v1);
                    return true;
                    break;
                }
                default: {
                    
                    UHDecref7(v1);
                    return false;
                }
            }
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref7(v0);
            switch (v1->tag) {
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref7(v1);
                    return true;
                    break;
                }
                default: {
                    
                    UHDecref7(v1);
                    return false;
                }
            }
            break;
        }
        case 5: { // RegexStar
            UH7 * v34 = v0->case5.v0;
            v34->refc++;
            UHDecref7(v0);
            switch (v1->tag) {
                case 5: { // RegexStar
                    UH7 * v35 = v1->case5.v0;
                    v35->refc++;
                    UHDecref7(v1);
                    return regex_equal17(v34, v35);
                    break;
                }
                default: {
                    
                    UHDecref7(v1); UHDecref7(v34);
                    return false;
                }
            }
            break;
        }
    }
}
UH7 * make_cat16(UH7 * v0, UH7 * v1){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref7(v0); UHDecref7(v1);
            return UH7_0();
            break;
        }
        default: {
            
            
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref7(v0); UHDecref7(v1);
                    return UH7_0();
                    break;
                }
                default: {
                    
                    
                    switch (v0->tag) {
                        case 1: { // RegexEpsilon
                            
                            
                            UHDecref7(v0);
                            return v1;
                            break;
                        }
                        default: {
                            
                            
                            switch (v1->tag) {
                                case 1: { // RegexEpsilon
                                    
                                    
                                    UHDecref7(v1);
                                    return v0;
                                    break;
                                }
                                default: {
                                    
                                    
                                    switch (v0->tag) {
                                        case 4: { // RegexCat
                                            UH7 * v12 = v0->case4.v0; UH7 * v13 = v0->case4.v1;
                                            v1->refc++; v12->refc++; v13->refc += 2;
                                            UHDecref7(v0);
                                            UH7 * v14;
                                            v14 = make_cat16(v13, v1);
                                            
                                            UHDecref7(v1); UHDecref7(v13);
                                            return UH7_4(v12, v14);
                                            break;
                                        }
                                        case 5: { // RegexStar
                                            UH7 * v4 = v0->case5.v0;
                                            v4->refc++;
                                            
                                            switch (v1->tag) {
                                                case 5: { // RegexStar
                                                    UH7 * v5 = v1->case5.v0;
                                                    v4->refc++; v5->refc += 2;
                                                    
                                                    bool v6;
                                                    v6 = regex_equal17(v4, v5);
                                                    
                                                    UHDecref7(v5);
                                                    if (v6){
                                                        
                                                        UHDecref7(v0); UHDecref7(v1);
                                                        return UH7_5(v4);
                                                    } else {
                                                        
                                                        UHDecref7(v4);
                                                        return UH7_4(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    
                                                    UHDecref7(v4);
                                                    return UH7_4(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            
                                            
                                            return UH7_4(v0, v1);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
UH7 * make_star18(UH7 * v0){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref7(v0);
            return UH7_1();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref7(v0);
            return UH7_1();
            break;
        }
        case 5: { // RegexStar
            UH7 * v3 = v0->case5.v0;
            v3->refc++;
            UHDecref7(v0);
            return UH7_5(v3);
            break;
        }
        default: {
            
            
            return UH7_5(v0);
        }
    }
}
UH7 * normalize12(UH7 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH7 * v5 = v0->case3.v0; UH7 * v6 = v0->case3.v1;
            v5->refc += 2; v6->refc++;
            UHDecref7(v0);
            UH7 * v7;
            v7 = normalize12(v5);
            v6->refc++;
            UHDecref7(v5);
            UH7 * v8;
            v8 = normalize12(v6);
            
            UHDecref7(v6);
            return make_alt13(v7, v8);
            break;
        }
        case 4: { // RegexCat
            UH7 * v10 = v0->case4.v0; UH7 * v11 = v0->case4.v1;
            v10->refc += 2; v11->refc++;
            UHDecref7(v0);
            UH7 * v12;
            v12 = normalize12(v10);
            v11->refc++;
            UHDecref7(v10);
            UH7 * v13;
            v13 = normalize12(v11);
            
            UHDecref7(v11);
            return make_cat16(v12, v13);
            break;
        }
        case 2: { // RegexChar
            US0 v3 = v0->case2.v0;
            USIncref0(&(v3));
            UHDecref7(v0);
            return UH7_2(v3);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref7(v0);
            return UH7_0();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref7(v0);
            return UH7_1();
            break;
        }
        case 5: { // RegexStar
            UH7 * v15 = v0->case5.v0;
            v15->refc += 2;
            UHDecref7(v0);
            UH7 * v16;
            v16 = normalize12(v15);
            
            UHDecref7(v15);
            return make_star18(v16);
            break;
        }
    }
}
static inline void USIncrefBody5(US5 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody5(US5 * x){
    switch (x->tag) {
    }
}
void USIncref5(US5 * x){ USIncrefBody5(x); }
void USDecref5(US5 * x){ USDecrefBody5(x); }
US5 US5_0() { // Nullable
    US5 x;
    x.tag = 0;
    return x;
}
US5 US5_1() { // NonNullable
    US5 x;
    x.tag = 1;
    return x;
}
US5 nullable20(UH7 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH7 * v5 = v0->case3.v0; UH7 * v6 = v0->case3.v1;
            v5->refc += 2; v6->refc++;
            UHDecref7(v0);
            US5 v7;
            v7 = nullable20(v5);
            v6->refc++;
            UHDecref7(v5);
            US5 v8;
            v8 = nullable20(v6);
            
            UHDecref7(v6);
            switch (v7.tag) {
                case 0: { // Nullable
                    
                    
                    USDecref5(&(v7)); USDecref5(&(v8));
                    return US5_0();
                    break;
                }
                default: {
                    
                    
                    switch (v8.tag) {
                        case 0: { // Nullable
                            
                            
                            USDecref5(&(v7)); USDecref5(&(v8));
                            return US5_0();
                            break;
                        }
                        default: {
                            
                            
                            switch (v7.tag) {
                                case 1: { // NonNullable
                                    
                                    
                                    USDecref5(&(v7));
                                    switch (v8.tag) {
                                        case 1: { // NonNullable
                                            
                                            
                                            USDecref5(&(v8));
                                            return US5_1();
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            break;
        }
        case 4: { // RegexCat
            UH7 * v16 = v0->case4.v0; UH7 * v17 = v0->case4.v1;
            v16->refc += 2; v17->refc++;
            UHDecref7(v0);
            US5 v18;
            v18 = nullable20(v16);
            v17->refc++;
            UHDecref7(v16);
            US5 v19;
            v19 = nullable20(v17);
            
            UHDecref7(v17);
            switch (v18.tag) {
                case 0: { // Nullable
                    
                    
                    USDecref5(&(v18));
                    switch (v19.tag) {
                        case 0: { // Nullable
                            
                            
                            USDecref5(&(v19));
                            return US5_0();
                            break;
                        }
                        default: {
                            
                            USDecref5(&(v19));
                            return US5_1();
                        }
                    }
                    break;
                }
                default: {
                    
                    USDecref5(&(v18)); USDecref5(&(v19));
                    return US5_1();
                }
            }
            break;
        }
        case 2: { // RegexChar
            
            
            UHDecref7(v0);
            return US5_1();
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref7(v0);
            return US5_1();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref7(v0);
            return US5_0();
            break;
        }
        case 5: { // RegexStar
            
            
            UHDecref7(v0);
            return US5_0();
            break;
        }
    }
}
UH7 * derivative19(UH7 * v0, US0 v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH7 * v19 = v0->case3.v0; UH7 * v20 = v0->case3.v1;
            USIncref0(&(v1)); v19->refc += 2; v20->refc++;
            UHDecref7(v0);
            UH7 * v21;
            v21 = derivative19(v19, v1);
            USIncref0(&(v1)); v20->refc++;
            UHDecref7(v19);
            UH7 * v22;
            v22 = derivative19(v20, v1);
            
            USDecref0(&(v1)); UHDecref7(v20);
            return make_alt13(v21, v22);
            break;
        }
        case 4: { // RegexCat
            UH7 * v24 = v0->case4.v0; UH7 * v25 = v0->case4.v1;
            v24->refc += 2; v25->refc++;
            UHDecref7(v0);
            US5 v26;
            v26 = nullable20(v24);
            
            
            switch (v26.tag) {
                case 1: { // NonNullable
                    
                    USIncref0(&(v1)); v24->refc++;
                    USDecref5(&(v26));
                    UH7 * v31;
                    v31 = derivative19(v24, v1);
                    
                    USDecref0(&(v1)); UHDecref7(v24);
                    return make_cat16(v31, v25);
                    break;
                }
                case 0: { // Nullable
                    
                    USIncref0(&(v1)); v24->refc++;
                    USDecref5(&(v26));
                    UH7 * v27;
                    v27 = derivative19(v24, v1);
                    v25->refc++; v27->refc++;
                    UHDecref7(v24);
                    UH7 * v28;
                    v28 = make_cat16(v27, v25);
                    USIncref0(&(v1)); v25->refc++;
                    UHDecref7(v27);
                    UH7 * v29;
                    v29 = derivative19(v25, v1);
                    
                    USDecref0(&(v1)); UHDecref7(v25);
                    return make_alt13(v28, v29);
                    break;
                }
            }
            break;
        }
        case 2: { // RegexChar
            US0 v4 = v0->case2.v0;
            USIncref0(&(v4));
            UHDecref7(v0);
            US4 v14;
            switch (v4.tag) {
                case 1: { // BitOne
                    
                    
                    
                    switch (v1.tag) {
                        case 1: { // BitOne
                            
                            
                            
                            v14 = US4_1();
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            
                            v14 = US4_2();
                            break;
                        }
                    }
                    break;
                }
                case 0: { // BitZero
                    
                    
                    
                    switch (v1.tag) {
                        case 1: { // BitOne
                            
                            
                            
                            v14 = US4_0();
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            
                            v14 = US4_1();
                            break;
                        }
                    }
                    break;
                }
            }
            
            USDecref0(&(v1)); USDecref0(&(v4));
            bool v15;
            switch (v14.tag) {
                case 1: { // SymbolSame
                    
                    
                    
                    v15 = true;
                    break;
                }
                default: {
                    
                    
                    v15 = false;
                }
            }
            
            USDecref4(&(v14));
            if (v15){
                
                
                return UH7_1();
            } else {
                
                
                return UH7_0();
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref7(v0); USDecref0(&(v1));
            return UH7_0();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref7(v0); USDecref0(&(v1));
            return UH7_0();
            break;
        }
        case 5: { // RegexStar
            UH7 * v35 = v0->case5.v0;
            USIncref0(&(v1)); v35->refc += 2;
            UHDecref7(v0);
            UH7 * v36;
            v36 = derivative19(v35, v1);
            v35->refc++;
            USDecref0(&(v1));
            UH7 * v37;
            v37 = make_star18(v35);
            
            UHDecref7(v35);
            return make_cat16(v36, v37);
            break;
        }
    }
}
UH7 * canonical_derivative11(UH7 * v0, US0 v1){
    v0->refc++;
    
    UH7 * v2;
    v2 = normalize12(v0);
    USIncref0(&(v1)); v2->refc++;
    UHDecref7(v0);
    UH7 * v3;
    v3 = derivative19(v2, v1);
    
    USDecref0(&(v1)); UHDecref7(v2);
    return normalize12(v3);
}
bool accepts10(UH7 * v0, UH2 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US0 v6 = v1->case1.v0; UH2 * v7 = v1->case1.v1;
            v0->refc++; USIncref0(&(v6));USIncref0(&(v6)); v7->refc++;
            UHDecref2(v1);
            UH7 * v8;
            v8 = canonical_derivative11(v0, v6);
            
            UHDecref7(v0); USDecref0(&(v6));
            return accepts10(v8, v7);
            break;
        }
        case 0: { // InputEmpty
            
            v0->refc++;
            UHDecref2(v1);
            UH7 * v2;
            v2 = normalize12(v0);
            v2->refc++;
            UHDecref7(v0);
            US5 v3;
            v3 = nullable20(v2);
            
            UHDecref7(v2);
            switch (v3.tag) {
                case 1: { // NonNullable
                    
                    
                    USDecref5(&(v3));
                    return false;
                    break;
                }
                case 0: { // Nullable
                    
                    
                    USDecref5(&(v3));
                    return true;
                    break;
                }
            }
            break;
        }
    }
}
bool loop8(UH7 * v0, UH1 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputListCons
            UH2 * v2 = v1->case1.v0; UH1 * v3 = v1->case1.v1;
            v2->refc++; v3->refc++;
            UHDecref1(v1);
            int32_t v4;
            v4 = 1l;
            v2->refc++;
            
            US3 v5;
            v5 = loop9(v4, v2);
            
            
            bool v11;
            switch (v5.tag) {
                case 0: { // InventoryDfaAccepted
                    
                    v0->refc++; v2->refc++;
                    
                    v11 = accepts10(v0, v2);
                    break;
                }
                case 2: { // InventoryDfaInputOutsideInventory
                    
                    
                    
                    v11 = false;
                    break;
                }
                case 1: { // InventoryDfaRejected
                    
                    v0->refc++; v2->refc++;
                    
                    bool v7;
                    v7 = accepts10(v0, v2);
                    
                    
                    bool v8;
                    v8 = v7 == false;
                    
                    
                    v11 = v8;
                    break;
                }
            }
            
            UHDecref2(v2); USDecref3(&(v5));
            if (v11){
                
                
                return loop8(v0, v3);
            } else {
                
                UHDecref7(v0); UHDecref1(v3);
                return false;
            }
            break;
        }
        case 0: { // InputListNil
            
            
            UHDecref7(v0); UHDecref1(v1);
            return true;
            break;
        }
    }
}
static inline void UHDecrefBody8(UH8 * x){
    switch (x->tag) {
        case 2: {
            USDecref1(&(x->case2.v0));
            break;
        }
        case 3: {
            UHDecref8(x->case3.v0); UHDecref8(x->case3.v1);
            break;
        }
        case 4: {
            UHDecref8(x->case4.v0); UHDecref8(x->case4.v1);
            break;
        }
        case 5: {
            UHDecref8(x->case5.v0);
            break;
        }
    }
}
void UHDecref8(UH8 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody8(x); free(x); }
}
UH8 * UH8_0() { // RegexEmpty
    UH8 * x = malloc(sizeof(UH8));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH8 * UH8_1() { // RegexEpsilon
    UH8 * x = malloc(sizeof(UH8));
    x->tag = 1;
    x->refc = 1;
    return x;
}
UH8 * UH8_2(US1 v0) { // RegexChar
    UH8 * x = malloc(sizeof(UH8));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0;
    return x;
}
UH8 * UH8_3(UH8 * v0, UH8 * v1) { // RegexAlt
    UH8 * x = malloc(sizeof(UH8));
    x->tag = 3;
    x->refc = 1;
    x->case3.v0 = v0; x->case3.v1 = v1;
    return x;
}
UH8 * UH8_4(UH8 * v0, UH8 * v1) { // RegexCat
    UH8 * x = malloc(sizeof(UH8));
    x->tag = 4;
    x->refc = 1;
    x->case4.v0 = v0; x->case4.v1 = v1;
    return x;
}
UH8 * UH8_5(UH8 * v0) { // RegexStar
    UH8 * x = malloc(sizeof(UH8));
    x->tag = 5;
    x->refc = 1;
    x->case5.v0 = v0;
    return x;
}
US3 loop22(int32_t v0, UH5 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US1 v8 = v1->case1.v0; UH5 * v9 = v1->case1.v1;
            USIncref1(&(v8)); v9->refc++;
            UHDecref5(v1);
            US4 v12;
            switch (v8.tag) {
                case 0: { // TriA
                    
                    
                    
                    v12 = US4_1();
                    break;
                }
                default: {
                    
                    
                    v12 = US4_2();
                }
            }
            
            
            bool v13;
            switch (v12.tag) {
                case 1: { // SymbolSame
                    
                    
                    
                    v13 = true;
                    break;
                }
                default: {
                    
                    
                    v13 = false;
                }
            }
            
            USDecref4(&(v12));
            int32_t v30;
            if (v13){
                
                
                v30 = 0l;
            } else {
                
                
                US4 v19;
                switch (v8.tag) {
                    case 0: { // TriA
                        
                        
                        
                        v19 = US4_0();
                        break;
                    }
                    case 1: { // TriB
                        
                        
                        
                        v19 = US4_1();
                        break;
                    }
                    case 2: { // TriC
                        
                        
                        
                        v19 = US4_2();
                        break;
                    }
                }
                
                
                bool v20;
                switch (v19.tag) {
                    case 1: { // SymbolSame
                        
                        
                        
                        v20 = true;
                        break;
                    }
                    default: {
                        
                        
                        v20 = false;
                    }
                }
                
                USDecref4(&(v19));
                if (v20){
                    
                    
                    v30 = 1l;
                } else {
                    
                    
                    US4 v26;
                    switch (v8.tag) {
                        case 0: { // TriA
                            
                            
                            
                            v26 = US4_0();
                            break;
                        }
                        case 1: { // TriB
                            
                            
                            
                            v26 = US4_0();
                            break;
                        }
                        case 2: { // TriC
                            
                            
                            
                            v26 = US4_1();
                            break;
                        }
                    }
                    
                    
                    bool v27;
                    switch (v26.tag) {
                        case 1: { // SymbolSame
                            
                            
                            
                            v27 = true;
                            break;
                        }
                        default: {
                            
                            
                            v27 = false;
                        }
                    }
                    
                    USDecref4(&(v26));
                    if (v27){
                        
                        
                        v30 = 2l;
                    } else {
                        
                        
                        v30 = -1l;
                    }
                }
            }
            
            USDecref1(&(v8));
            bool v31;
            v31 = v30 < 0l;
            
            
            if (v31){
                
                UHDecref5(v9);
                return US3_2();
            } else {
                
                
                bool v33;
                v33 = v0 == 0l;
                
                
                int32_t v46;
                if (v33){
                    
                    
                    bool v34;
                    v34 = v30 == 0l;
                    
                    
                    if (v34){
                        
                        
                        v46 = 0l;
                    } else {
                        
                        
                        bool v35;
                        v35 = v30 == 1l;
                        
                        
                        v46 = 0l;
                    }
                } else {
                    
                    
                    bool v37;
                    v37 = v0 == 1l;
                    
                    
                    if (v37){
                        
                        
                        bool v38;
                        v38 = v30 == 0l;
                        
                        
                        if (v38){
                            
                            
                            v46 = 0l;
                        } else {
                            
                            
                            bool v39;
                            v39 = v30 == 1l;
                            
                            
                            v46 = 0l;
                        }
                    } else {
                        
                        
                        bool v41;
                        v41 = v30 == 0l;
                        
                        
                        if (v41){
                            
                            
                            v46 = 2l;
                        } else {
                            
                            
                            bool v42;
                            v42 = v30 == 1l;
                            
                            
                            if (v42){
                                
                                
                                v46 = 2l;
                            } else {
                                
                                
                                v46 = 1l;
                            }
                        }
                    }
                }
                
                
                return loop22(v46, v9);
            }
            break;
        }
        case 0: { // InputEmpty
            
            
            UHDecref5(v1);
            bool v2;
            v2 = v0 == 0l;
            
            
            bool v4;
            if (v2){
                
                
                v4 = false;
            } else {
                
                
                bool v3;
                v3 = v0 == 1l;
                
                
                v4 = v3;
            }
            
            
            if (v4){
                
                
                return US3_0();
            } else {
                
                
                return US3_1();
            }
            break;
        }
    }
}
US4 regex_compare28(UH8 * v0, UH8 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH8 * v59 = v0->case3.v0; UH8 * v60 = v0->case3.v1;
            v59->refc++; v60->refc++;
            UHDecref8(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    UH8 * v61 = v1->case3.v0; UH8 * v62 = v1->case3.v1;
                    v59->refc++; v61->refc += 2; v62->refc++;
                    UHDecref8(v1);
                    US4 v63;
                    v63 = regex_compare28(v59, v61);
                    
                    UHDecref8(v59); UHDecref8(v61);
                    switch (v63.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref4(&(v63));
                            return regex_compare28(v60, v62);
                            break;
                        }
                        default: {
                            
                            UHDecref8(v60); UHDecref8(v62);
                            return v63;
                        }
                    }
                    break;
                }
                default: {
                    
                    UHDecref8(v1); UHDecref8(v59); UHDecref8(v60);
                    return US4_2();
                }
            }
            break;
        }
        case 4: { // RegexCat
            UH8 * v34 = v0->case4.v0; UH8 * v35 = v0->case4.v1;
            v34->refc++; v35->refc++;
            UHDecref8(v0);
            switch (v1->tag) {
                case 4: { // RegexCat
                    UH8 * v40 = v1->case4.v0; UH8 * v41 = v1->case4.v1;
                    v34->refc++; v40->refc += 2; v41->refc++;
                    UHDecref8(v1);
                    US4 v42;
                    v42 = regex_compare28(v34, v40);
                    
                    UHDecref8(v34); UHDecref8(v40);
                    switch (v42.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref4(&(v42));
                            return regex_compare28(v35, v41);
                            break;
                        }
                        default: {
                            
                            UHDecref8(v35); UHDecref8(v41);
                            return v42;
                        }
                    }
                    break;
                }
                case 2: { // RegexChar
                    
                    
                    UHDecref8(v1); UHDecref8(v34); UHDecref8(v35);
                    return US4_2();
                    break;
                }
                case 0: { // RegexEmpty
                    
                    
                    UHDecref8(v1); UHDecref8(v34); UHDecref8(v35);
                    return US4_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref8(v1); UHDecref8(v34); UHDecref8(v35);
                    return US4_2();
                    break;
                }
                default: {
                    
                    UHDecref8(v1); UHDecref8(v34); UHDecref8(v35);
                    return US4_0();
                }
            }
            break;
        }
        case 2: { // RegexChar
            US1 v10 = v0->case2.v0;
            USIncref1(&(v10));
            UHDecref8(v0);
            switch (v1->tag) {
                case 2: { // RegexChar
                    US1 v13 = v1->case2.v0;
                    USIncref1(&(v13));
                    UHDecref8(v1);
                    switch (v10.tag) {
                        case 0: { // TriA
                            
                            
                            USDecref1(&(v10));
                            switch (v13.tag) {
                                case 0: { // TriA
                                    
                                    
                                    USDecref1(&(v13));
                                    return US4_1();
                                    break;
                                }
                                default: {
                                    
                                    USDecref1(&(v13));
                                    return US4_0();
                                }
                            }
                            break;
                        }
                        default: {
                            
                            
                            switch (v13.tag) {
                                case 0: { // TriA
                                    
                                    
                                    USDecref1(&(v10)); USDecref1(&(v13));
                                    return US4_2();
                                    break;
                                }
                                default: {
                                    
                                    
                                    switch (v10.tag) {
                                        case 1: { // TriB
                                            
                                            
                                            USDecref1(&(v10));
                                            switch (v13.tag) {
                                                case 1: { // TriB
                                                    
                                                    
                                                    USDecref1(&(v13));
                                                    return US4_1();
                                                    break;
                                                }
                                                case 2: { // TriC
                                                    
                                                    
                                                    USDecref1(&(v13));
                                                    return US4_0();
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                        case 2: { // TriC
                                            
                                            
                                            USDecref1(&(v10));
                                            switch (v13.tag) {
                                                case 1: { // TriB
                                                    
                                                    
                                                    USDecref1(&(v13));
                                                    return US4_2();
                                                    break;
                                                }
                                                case 2: { // TriC
                                                    
                                                    
                                                    USDecref1(&(v13));
                                                    return US4_1();
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                }
                case 0: { // RegexEmpty
                    
                    
                    UHDecref8(v1); USDecref1(&(v10));
                    return US4_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref8(v1); USDecref1(&(v10));
                    return US4_2();
                    break;
                }
                default: {
                    
                    UHDecref8(v1); USDecref1(&(v10));
                    return US4_0();
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref8(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref8(v1);
                    return US4_1();
                    break;
                }
                default: {
                    
                    UHDecref8(v1);
                    return US4_0();
                }
            }
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref8(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref8(v1);
                    return US4_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref8(v1);
                    return US4_1();
                    break;
                }
                default: {
                    
                    UHDecref8(v1);
                    return US4_0();
                }
            }
            break;
        }
        case 5: { // RegexStar
            UH8 * v50 = v0->case5.v0;
            v50->refc++;
            UHDecref8(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    
                    
                    UHDecref8(v1); UHDecref8(v50);
                    return US4_0();
                    break;
                }
                case 5: { // RegexStar
                    UH8 * v54 = v1->case5.v0;
                    v54->refc++;
                    UHDecref8(v1);
                    return regex_compare28(v50, v54);
                    break;
                }
                default: {
                    
                    UHDecref8(v1); UHDecref8(v50);
                    return US4_2();
                }
            }
            break;
        }
    }
}
UH8 * alt_insert_sorted27(UH8 * v0, UH8 * v1){
    
    
    switch (v1->tag) {
        case 3: { // RegexAlt
            UH8 * v2 = v1->case3.v0; UH8 * v3 = v1->case3.v1;
            v0->refc++; v2->refc += 2; v3->refc++;
            
            US4 v4;
            v4 = regex_compare28(v0, v2);
            
            
            switch (v4.tag) {
                case 2: { // SymbolGreater
                    
                    v0->refc++; v3->refc++;
                    UHDecref8(v1); USDecref4(&(v4));
                    UH8 * v6;
                    v6 = alt_insert_sorted27(v0, v3);
                    
                    UHDecref8(v0); UHDecref8(v3);
                    return UH8_3(v2, v6);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    UHDecref8(v2); UHDecref8(v3); USDecref4(&(v4));
                    return UH8_3(v0, v1);
                    break;
                }
                case 1: { // SymbolSame
                    
                    
                    UHDecref8(v0); UHDecref8(v2); UHDecref8(v3); USDecref4(&(v4));
                    return v1;
                    break;
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref8(v1);
            return v0;
            break;
        }
        default: {
            v0->refc++; v1->refc++;
            
            US4 v11;
            v11 = regex_compare28(v0, v1);
            
            
            switch (v11.tag) {
                case 2: { // SymbolGreater
                    
                    
                    USDecref4(&(v11));
                    return UH8_3(v1, v0);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    USDecref4(&(v11));
                    return UH8_3(v0, v1);
                    break;
                }
                case 1: { // SymbolSame
                    
                    
                    UHDecref8(v0); USDecref4(&(v11));
                    return v1;
                    break;
                }
            }
        }
    }
}
UH8 * make_alt26(UH8 * v0, UH8 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH8 * v2 = v0->case3.v0; UH8 * v3 = v0->case3.v1;
            v1->refc++; v2->refc += 2; v3->refc++;
            UHDecref8(v0);
            UH8 * v4;
            v4 = alt_insert_sorted27(v2, v1);
            
            UHDecref8(v1); UHDecref8(v2);
            return make_alt26(v3, v4);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref8(v0);
            return v1;
            break;
        }
        default: {
            
            
            return alt_insert_sorted27(v0, v1);
        }
    }
}
bool regex_equal30(UH8 * v0, UH8 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH8 * v24 = v0->case3.v0; UH8 * v25 = v0->case3.v1;
            v24->refc++; v25->refc++;
            UHDecref8(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    UH8 * v26 = v1->case3.v0; UH8 * v27 = v1->case3.v1;
                    v24->refc++; v26->refc += 2; v27->refc++;
                    UHDecref8(v1);
                    bool v28;
                    v28 = regex_equal30(v24, v26);
                    
                    UHDecref8(v24); UHDecref8(v26);
                    if (v28){
                        
                        
                        return regex_equal30(v25, v27);
                    } else {
                        
                        UHDecref8(v25); UHDecref8(v27);
                        return false;
                    }
                    break;
                }
                default: {
                    
                    UHDecref8(v1); UHDecref8(v24); UHDecref8(v25);
                    return false;
                }
            }
            break;
        }
        case 4: { // RegexCat
            UH8 * v32 = v0->case4.v0; UH8 * v33 = v0->case4.v1;
            v32->refc++; v33->refc++;
            UHDecref8(v0);
            switch (v1->tag) {
                case 4: { // RegexCat
                    UH8 * v34 = v1->case4.v0; UH8 * v35 = v1->case4.v1;
                    v32->refc++; v34->refc += 2; v35->refc++;
                    UHDecref8(v1);
                    bool v36;
                    v36 = regex_equal30(v32, v34);
                    
                    UHDecref8(v32); UHDecref8(v34);
                    if (v36){
                        
                        
                        return regex_equal30(v33, v35);
                    } else {
                        
                        UHDecref8(v33); UHDecref8(v35);
                        return false;
                    }
                    break;
                }
                default: {
                    
                    UHDecref8(v1); UHDecref8(v32); UHDecref8(v33);
                    return false;
                }
            }
            break;
        }
        case 2: { // RegexChar
            US1 v4 = v0->case2.v0;
            USIncref1(&(v4));
            UHDecref8(v0);
            switch (v1->tag) {
                case 2: { // RegexChar
                    US1 v5 = v1->case2.v0;
                    USIncref1(&(v5));
                    UHDecref8(v1);
                    US4 v21;
                    switch (v4.tag) {
                        case 0: { // TriA
                            
                            
                            
                            switch (v5.tag) {
                                case 0: { // TriA
                                    
                                    
                                    
                                    v21 = US4_1();
                                    break;
                                }
                                default: {
                                    
                                    
                                    v21 = US4_0();
                                }
                            }
                            break;
                        }
                        default: {
                            
                            
                            switch (v5.tag) {
                                case 0: { // TriA
                                    
                                    
                                    
                                    v21 = US4_2();
                                    break;
                                }
                                default: {
                                    
                                    
                                    switch (v4.tag) {
                                        case 1: { // TriB
                                            
                                            
                                            
                                            switch (v5.tag) {
                                                case 1: { // TriB
                                                    
                                                    
                                                    
                                                    v21 = US4_1();
                                                    break;
                                                }
                                                case 2: { // TriC
                                                    
                                                    
                                                    
                                                    v21 = US4_0();
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                        case 2: { // TriC
                                            
                                            
                                            
                                            switch (v5.tag) {
                                                case 1: { // TriB
                                                    
                                                    
                                                    
                                                    v21 = US4_2();
                                                    break;
                                                }
                                                case 2: { // TriC
                                                    
                                                    
                                                    
                                                    v21 = US4_1();
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    USDecref1(&(v4)); USDecref1(&(v5));
                    switch (v21.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref4(&(v21));
                            return true;
                            break;
                        }
                        default: {
                            
                            USDecref4(&(v21));
                            return false;
                        }
                    }
                    break;
                }
                default: {
                    
                    UHDecref8(v1); USDecref1(&(v4));
                    return false;
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref8(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref8(v1);
                    return true;
                    break;
                }
                default: {
                    
                    UHDecref8(v1);
                    return false;
                }
            }
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref8(v0);
            switch (v1->tag) {
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref8(v1);
                    return true;
                    break;
                }
                default: {
                    
                    UHDecref8(v1);
                    return false;
                }
            }
            break;
        }
        case 5: { // RegexStar
            UH8 * v40 = v0->case5.v0;
            v40->refc++;
            UHDecref8(v0);
            switch (v1->tag) {
                case 5: { // RegexStar
                    UH8 * v41 = v1->case5.v0;
                    v41->refc++;
                    UHDecref8(v1);
                    return regex_equal30(v40, v41);
                    break;
                }
                default: {
                    
                    UHDecref8(v1); UHDecref8(v40);
                    return false;
                }
            }
            break;
        }
    }
}
UH8 * make_cat29(UH8 * v0, UH8 * v1){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref8(v0); UHDecref8(v1);
            return UH8_0();
            break;
        }
        default: {
            
            
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref8(v0); UHDecref8(v1);
                    return UH8_0();
                    break;
                }
                default: {
                    
                    
                    switch (v0->tag) {
                        case 1: { // RegexEpsilon
                            
                            
                            UHDecref8(v0);
                            return v1;
                            break;
                        }
                        default: {
                            
                            
                            switch (v1->tag) {
                                case 1: { // RegexEpsilon
                                    
                                    
                                    UHDecref8(v1);
                                    return v0;
                                    break;
                                }
                                default: {
                                    
                                    
                                    switch (v0->tag) {
                                        case 4: { // RegexCat
                                            UH8 * v12 = v0->case4.v0; UH8 * v13 = v0->case4.v1;
                                            v1->refc++; v12->refc++; v13->refc += 2;
                                            UHDecref8(v0);
                                            UH8 * v14;
                                            v14 = make_cat29(v13, v1);
                                            
                                            UHDecref8(v1); UHDecref8(v13);
                                            return UH8_4(v12, v14);
                                            break;
                                        }
                                        case 5: { // RegexStar
                                            UH8 * v4 = v0->case5.v0;
                                            v4->refc++;
                                            
                                            switch (v1->tag) {
                                                case 5: { // RegexStar
                                                    UH8 * v5 = v1->case5.v0;
                                                    v4->refc++; v5->refc += 2;
                                                    
                                                    bool v6;
                                                    v6 = regex_equal30(v4, v5);
                                                    
                                                    UHDecref8(v5);
                                                    if (v6){
                                                        
                                                        UHDecref8(v0); UHDecref8(v1);
                                                        return UH8_5(v4);
                                                    } else {
                                                        
                                                        UHDecref8(v4);
                                                        return UH8_4(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    
                                                    UHDecref8(v4);
                                                    return UH8_4(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            
                                            
                                            return UH8_4(v0, v1);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
UH8 * make_star31(UH8 * v0){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref8(v0);
            return UH8_1();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref8(v0);
            return UH8_1();
            break;
        }
        case 5: { // RegexStar
            UH8 * v3 = v0->case5.v0;
            v3->refc++;
            UHDecref8(v0);
            return UH8_5(v3);
            break;
        }
        default: {
            
            
            return UH8_5(v0);
        }
    }
}
UH8 * normalize25(UH8 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH8 * v5 = v0->case3.v0; UH8 * v6 = v0->case3.v1;
            v5->refc += 2; v6->refc++;
            UHDecref8(v0);
            UH8 * v7;
            v7 = normalize25(v5);
            v6->refc++;
            UHDecref8(v5);
            UH8 * v8;
            v8 = normalize25(v6);
            
            UHDecref8(v6);
            return make_alt26(v7, v8);
            break;
        }
        case 4: { // RegexCat
            UH8 * v10 = v0->case4.v0; UH8 * v11 = v0->case4.v1;
            v10->refc += 2; v11->refc++;
            UHDecref8(v0);
            UH8 * v12;
            v12 = normalize25(v10);
            v11->refc++;
            UHDecref8(v10);
            UH8 * v13;
            v13 = normalize25(v11);
            
            UHDecref8(v11);
            return make_cat29(v12, v13);
            break;
        }
        case 2: { // RegexChar
            US1 v3 = v0->case2.v0;
            USIncref1(&(v3));
            UHDecref8(v0);
            return UH8_2(v3);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref8(v0);
            return UH8_0();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref8(v0);
            return UH8_1();
            break;
        }
        case 5: { // RegexStar
            UH8 * v15 = v0->case5.v0;
            v15->refc += 2;
            UHDecref8(v0);
            UH8 * v16;
            v16 = normalize25(v15);
            
            UHDecref8(v15);
            return make_star31(v16);
            break;
        }
    }
}
US5 nullable33(UH8 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH8 * v5 = v0->case3.v0; UH8 * v6 = v0->case3.v1;
            v5->refc += 2; v6->refc++;
            UHDecref8(v0);
            US5 v7;
            v7 = nullable33(v5);
            v6->refc++;
            UHDecref8(v5);
            US5 v8;
            v8 = nullable33(v6);
            
            UHDecref8(v6);
            switch (v7.tag) {
                case 0: { // Nullable
                    
                    
                    USDecref5(&(v7)); USDecref5(&(v8));
                    return US5_0();
                    break;
                }
                default: {
                    
                    
                    switch (v8.tag) {
                        case 0: { // Nullable
                            
                            
                            USDecref5(&(v7)); USDecref5(&(v8));
                            return US5_0();
                            break;
                        }
                        default: {
                            
                            
                            switch (v7.tag) {
                                case 1: { // NonNullable
                                    
                                    
                                    USDecref5(&(v7));
                                    switch (v8.tag) {
                                        case 1: { // NonNullable
                                            
                                            
                                            USDecref5(&(v8));
                                            return US5_1();
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            break;
        }
        case 4: { // RegexCat
            UH8 * v16 = v0->case4.v0; UH8 * v17 = v0->case4.v1;
            v16->refc += 2; v17->refc++;
            UHDecref8(v0);
            US5 v18;
            v18 = nullable33(v16);
            v17->refc++;
            UHDecref8(v16);
            US5 v19;
            v19 = nullable33(v17);
            
            UHDecref8(v17);
            switch (v18.tag) {
                case 0: { // Nullable
                    
                    
                    USDecref5(&(v18));
                    switch (v19.tag) {
                        case 0: { // Nullable
                            
                            
                            USDecref5(&(v19));
                            return US5_0();
                            break;
                        }
                        default: {
                            
                            USDecref5(&(v19));
                            return US5_1();
                        }
                    }
                    break;
                }
                default: {
                    
                    USDecref5(&(v18)); USDecref5(&(v19));
                    return US5_1();
                }
            }
            break;
        }
        case 2: { // RegexChar
            
            
            UHDecref8(v0);
            return US5_1();
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref8(v0);
            return US5_1();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref8(v0);
            return US5_0();
            break;
        }
        case 5: { // RegexStar
            
            
            UHDecref8(v0);
            return US5_0();
            break;
        }
    }
}
UH8 * derivative32(UH8 * v0, US1 v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH8 * v25 = v0->case3.v0; UH8 * v26 = v0->case3.v1;
            USIncref1(&(v1)); v25->refc += 2; v26->refc++;
            UHDecref8(v0);
            UH8 * v27;
            v27 = derivative32(v25, v1);
            USIncref1(&(v1)); v26->refc++;
            UHDecref8(v25);
            UH8 * v28;
            v28 = derivative32(v26, v1);
            
            USDecref1(&(v1)); UHDecref8(v26);
            return make_alt26(v27, v28);
            break;
        }
        case 4: { // RegexCat
            UH8 * v30 = v0->case4.v0; UH8 * v31 = v0->case4.v1;
            v30->refc += 2; v31->refc++;
            UHDecref8(v0);
            US5 v32;
            v32 = nullable33(v30);
            
            
            switch (v32.tag) {
                case 1: { // NonNullable
                    
                    USIncref1(&(v1)); v30->refc++;
                    USDecref5(&(v32));
                    UH8 * v37;
                    v37 = derivative32(v30, v1);
                    
                    USDecref1(&(v1)); UHDecref8(v30);
                    return make_cat29(v37, v31);
                    break;
                }
                case 0: { // Nullable
                    
                    USIncref1(&(v1)); v30->refc++;
                    USDecref5(&(v32));
                    UH8 * v33;
                    v33 = derivative32(v30, v1);
                    v31->refc++; v33->refc++;
                    UHDecref8(v30);
                    UH8 * v34;
                    v34 = make_cat29(v33, v31);
                    USIncref1(&(v1)); v31->refc++;
                    UHDecref8(v33);
                    UH8 * v35;
                    v35 = derivative32(v31, v1);
                    
                    USDecref1(&(v1)); UHDecref8(v31);
                    return make_alt26(v34, v35);
                    break;
                }
            }
            break;
        }
        case 2: { // RegexChar
            US1 v4 = v0->case2.v0;
            USIncref1(&(v4));
            UHDecref8(v0);
            US4 v20;
            switch (v4.tag) {
                case 0: { // TriA
                    
                    
                    
                    switch (v1.tag) {
                        case 0: { // TriA
                            
                            
                            
                            v20 = US4_1();
                            break;
                        }
                        default: {
                            
                            
                            v20 = US4_0();
                        }
                    }
                    break;
                }
                default: {
                    
                    
                    switch (v1.tag) {
                        case 0: { // TriA
                            
                            
                            
                            v20 = US4_2();
                            break;
                        }
                        default: {
                            
                            
                            switch (v4.tag) {
                                case 1: { // TriB
                                    
                                    
                                    
                                    switch (v1.tag) {
                                        case 1: { // TriB
                                            
                                            
                                            
                                            v20 = US4_1();
                                            break;
                                        }
                                        case 2: { // TriC
                                            
                                            
                                            
                                            v20 = US4_0();
                                            break;
                                        }
                                    }
                                    break;
                                }
                                case 2: { // TriC
                                    
                                    
                                    
                                    switch (v1.tag) {
                                        case 1: { // TriB
                                            
                                            
                                            
                                            v20 = US4_2();
                                            break;
                                        }
                                        case 2: { // TriC
                                            
                                            
                                            
                                            v20 = US4_1();
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            
            USDecref1(&(v1)); USDecref1(&(v4));
            bool v21;
            switch (v20.tag) {
                case 1: { // SymbolSame
                    
                    
                    
                    v21 = true;
                    break;
                }
                default: {
                    
                    
                    v21 = false;
                }
            }
            
            USDecref4(&(v20));
            if (v21){
                
                
                return UH8_1();
            } else {
                
                
                return UH8_0();
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref8(v0); USDecref1(&(v1));
            return UH8_0();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref8(v0); USDecref1(&(v1));
            return UH8_0();
            break;
        }
        case 5: { // RegexStar
            UH8 * v41 = v0->case5.v0;
            USIncref1(&(v1)); v41->refc += 2;
            UHDecref8(v0);
            UH8 * v42;
            v42 = derivative32(v41, v1);
            v41->refc++;
            USDecref1(&(v1));
            UH8 * v43;
            v43 = make_star31(v41);
            
            UHDecref8(v41);
            return make_cat29(v42, v43);
            break;
        }
    }
}
UH8 * canonical_derivative24(UH8 * v0, US1 v1){
    v0->refc++;
    
    UH8 * v2;
    v2 = normalize25(v0);
    USIncref1(&(v1)); v2->refc++;
    UHDecref8(v0);
    UH8 * v3;
    v3 = derivative32(v2, v1);
    
    USDecref1(&(v1)); UHDecref8(v2);
    return normalize25(v3);
}
bool accepts23(UH8 * v0, UH5 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US1 v6 = v1->case1.v0; UH5 * v7 = v1->case1.v1;
            v0->refc++; USIncref1(&(v6));USIncref1(&(v6)); v7->refc++;
            UHDecref5(v1);
            UH8 * v8;
            v8 = canonical_derivative24(v0, v6);
            
            UHDecref8(v0); USDecref1(&(v6));
            return accepts23(v8, v7);
            break;
        }
        case 0: { // InputEmpty
            
            v0->refc++;
            UHDecref5(v1);
            UH8 * v2;
            v2 = normalize25(v0);
            v2->refc++;
            UHDecref8(v0);
            US5 v3;
            v3 = nullable33(v2);
            
            UHDecref8(v2);
            switch (v3.tag) {
                case 1: { // NonNullable
                    
                    
                    USDecref5(&(v3));
                    return false;
                    break;
                }
                case 0: { // Nullable
                    
                    
                    USDecref5(&(v3));
                    return true;
                    break;
                }
            }
            break;
        }
    }
}
bool loop21(UH8 * v0, UH4 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputListCons
            UH5 * v2 = v1->case1.v0; UH4 * v3 = v1->case1.v1;
            v2->refc++; v3->refc++;
            UHDecref4(v1);
            int32_t v4;
            v4 = 2l;
            v2->refc++;
            
            US3 v5;
            v5 = loop22(v4, v2);
            
            
            bool v11;
            switch (v5.tag) {
                case 0: { // InventoryDfaAccepted
                    
                    v0->refc++; v2->refc++;
                    
                    v11 = accepts23(v0, v2);
                    break;
                }
                case 2: { // InventoryDfaInputOutsideInventory
                    
                    
                    
                    v11 = false;
                    break;
                }
                case 1: { // InventoryDfaRejected
                    
                    v0->refc++; v2->refc++;
                    
                    bool v7;
                    v7 = accepts23(v0, v2);
                    
                    
                    bool v8;
                    v8 = v7 == false;
                    
                    
                    v11 = v8;
                    break;
                }
            }
            
            UHDecref5(v2); USDecref3(&(v5));
            if (v11){
                
                
                return loop21(v0, v3);
            } else {
                
                UHDecref8(v0); UHDecref4(v3);
                return false;
            }
            break;
        }
        case 0: { // InputListNil
            
            
            UHDecref8(v0); UHDecref4(v1);
            return true;
            break;
        }
    }
}
US3 loop34(int32_t v0, UH6 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US2 v7 = v1->case1.v0; UH6 * v8 = v1->case1.v1;
            USIncref2(&(v7)); v8->refc++;
            UHDecref6(v1);
            US4 v11;
            switch (v7.tag) {
                case 0: { // ModelA
                    
                    
                    
                    v11 = US4_1();
                    break;
                }
                default: {
                    
                    
                    v11 = US4_2();
                }
            }
            
            
            bool v12;
            switch (v11.tag) {
                case 1: { // SymbolSame
                    
                    
                    
                    v12 = true;
                    break;
                }
                default: {
                    
                    
                    v12 = false;
                }
            }
            
            USDecref4(&(v11));
            int32_t v21;
            if (v12){
                
                
                v21 = 0l;
            } else {
                
                
                US4 v18;
                switch (v7.tag) {
                    case 0: { // ModelA
                        
                        
                        
                        v18 = US4_0();
                        break;
                    }
                    case 1: { // ModelB
                        
                        
                        
                        v18 = US4_1();
                        break;
                    }
                    case 2: { // ModelC
                        
                        
                        
                        v18 = US4_2();
                        break;
                    }
                }
                
                
                bool v19;
                switch (v18.tag) {
                    case 1: { // SymbolSame
                        
                        
                        
                        v19 = true;
                        break;
                    }
                    default: {
                        
                        
                        v19 = false;
                    }
                }
                
                USDecref4(&(v18));
                if (v19){
                    
                    
                    v21 = 1l;
                } else {
                    
                    
                    v21 = -1l;
                }
            }
            
            USDecref2(&(v7));
            bool v22;
            v22 = v21 < 0l;
            
            
            if (v22){
                
                UHDecref6(v8);
                return US3_2();
            } else {
                
                
                bool v24;
                v24 = v0 == 0l;
                
                
                int32_t v28;
                if (v24){
                    
                    
                    bool v25;
                    v25 = v21 == 0l;
                    
                    
                    v28 = 0l;
                } else {
                    
                    
                    bool v26;
                    v26 = v21 == 0l;
                    
                    
                    if (v26){
                        
                        
                        v28 = 1l;
                    } else {
                        
                        
                        v28 = 0l;
                    }
                }
                
                
                return loop34(v28, v8);
            }
            break;
        }
        case 0: { // InputEmpty
            
            
            UHDecref6(v1);
            bool v2;
            v2 = v0 == 0l;
            
            
            bool v3;
            v3 = v2 == false;
            
            
            if (v3){
                
                
                return US3_0();
            } else {
                
                
                return US3_1();
            }
            break;
        }
    }
}
int32_t main(){
    
    
    US0 v0;
    v0 = US0_0();
    
    
    US0 v1;
    v1 = US0_1();
    
    
    UH0 * v2;
    v2 = UH0_0();
    USIncref0(&(v1)); v2->refc++;
    
    UH0 * v3;
    v3 = UH0_1(v1, v2);
    USIncref0(&(v0)); v3->refc++;
    USDecref0(&(v1)); UHDecref0(v2);
    UH0 * v4;
    v4 = UH0_1(v0, v3);
    v4->refc++;
    USDecref0(&(v0)); UHDecref0(v3);
    UH1 * v5;
    v5 = input_singletons_from_symbols0(v4);
    
    UHDecref0(v4);
    UH2 * v6;
    v6 = UH2_0();
    v5->refc++; v6->refc++;
    
    UH1 * v7;
    v7 = UH1_1(v6, v5);
    
    UHDecref1(v5); UHDecref2(v6);
    US0 v8;
    v8 = US0_0();
    
    
    US0 v9;
    v9 = US0_1();
    
    
    UH0 * v10;
    v10 = UH0_0();
    USIncref0(&(v9)); v10->refc++;
    
    UH0 * v11;
    v11 = UH0_1(v9, v10);
    USIncref0(&(v8)); v11->refc++;
    USDecref0(&(v9)); UHDecref0(v10);
    UH0 * v12;
    v12 = UH0_1(v8, v11);
    
    USDecref0(&(v8)); UHDecref0(v11);
    US0 v13;
    v13 = US0_0();
    
    
    US0 v14;
    v14 = US0_1();
    
    
    UH0 * v15;
    v15 = UH0_0();
    USIncref0(&(v14)); v15->refc++;
    
    UH0 * v16;
    v16 = UH0_1(v14, v15);
    USIncref0(&(v13)); v16->refc++;
    USDecref0(&(v14)); UHDecref0(v15);
    UH0 * v17;
    v17 = UH0_1(v13, v16);
    v17->refc++;
    USDecref0(&(v13)); UHDecref0(v16);
    UH1 * v18;
    v18 = input_singletons_from_symbols0(v17);
    v12->refc++; v18->refc++;
    UHDecref0(v17);
    UH1 * v19;
    v19 = input_prepend_symbols_to_corpus1(v12, v18);
    v7->refc++; v19->refc++;
    UHDecref0(v12); UHDecref1(v18);
    UH1 * v20;
    v20 = input_list_append3(v7, v19);
    
    UHDecref1(v7); UHDecref1(v19);
    US1 v21;
    v21 = US1_0();
    
    
    US1 v22;
    v22 = US1_1();
    
    
    US1 v23;
    v23 = US1_2();
    
    
    UH3 * v24;
    v24 = UH3_0();
    USIncref1(&(v23)); v24->refc++;
    
    UH3 * v25;
    v25 = UH3_1(v23, v24);
    USIncref1(&(v22)); v25->refc++;
    USDecref1(&(v23)); UHDecref3(v24);
    UH3 * v26;
    v26 = UH3_1(v22, v25);
    USIncref1(&(v21)); v26->refc++;
    USDecref1(&(v22)); UHDecref3(v25);
    UH3 * v27;
    v27 = UH3_1(v21, v26);
    v27->refc++;
    USDecref1(&(v21)); UHDecref3(v26);
    UH4 * v28;
    v28 = input_singletons_from_symbols4(v27);
    
    UHDecref3(v27);
    UH5 * v29;
    v29 = UH5_0();
    v28->refc++; v29->refc++;
    
    UH4 * v30;
    v30 = UH4_1(v29, v28);
    
    UHDecref4(v28); UHDecref5(v29);
    US1 v31;
    v31 = US1_0();
    
    
    US1 v32;
    v32 = US1_1();
    
    
    US1 v33;
    v33 = US1_2();
    
    
    UH3 * v34;
    v34 = UH3_0();
    USIncref1(&(v33)); v34->refc++;
    
    UH3 * v35;
    v35 = UH3_1(v33, v34);
    USIncref1(&(v32)); v35->refc++;
    USDecref1(&(v33)); UHDecref3(v34);
    UH3 * v36;
    v36 = UH3_1(v32, v35);
    USIncref1(&(v31)); v36->refc++;
    USDecref1(&(v32)); UHDecref3(v35);
    UH3 * v37;
    v37 = UH3_1(v31, v36);
    
    USDecref1(&(v31)); UHDecref3(v36);
    US1 v38;
    v38 = US1_0();
    
    
    US1 v39;
    v39 = US1_1();
    
    
    US1 v40;
    v40 = US1_2();
    
    
    UH3 * v41;
    v41 = UH3_0();
    USIncref1(&(v40)); v41->refc++;
    
    UH3 * v42;
    v42 = UH3_1(v40, v41);
    USIncref1(&(v39)); v42->refc++;
    USDecref1(&(v40)); UHDecref3(v41);
    UH3 * v43;
    v43 = UH3_1(v39, v42);
    USIncref1(&(v38)); v43->refc++;
    USDecref1(&(v39)); UHDecref3(v42);
    UH3 * v44;
    v44 = UH3_1(v38, v43);
    v44->refc++;
    USDecref1(&(v38)); UHDecref3(v43);
    UH4 * v45;
    v45 = input_singletons_from_symbols4(v44);
    v37->refc++; v45->refc++;
    UHDecref3(v44);
    UH4 * v46;
    v46 = input_prepend_symbols_to_corpus5(v37, v45);
    v30->refc++; v46->refc++;
    UHDecref3(v37); UHDecref4(v45);
    UH4 * v47;
    v47 = input_list_append7(v30, v46);
    
    UHDecref4(v30); UHDecref4(v46);
    US2 v48;
    v48 = US2_2();
    
    
    UH6 * v49;
    v49 = UH6_0();
    USIncref2(&(v48)); v49->refc++;
    
    UH6 * v50;
    v50 = UH6_1(v48, v49);
    
    USDecref2(&(v48)); UHDecref6(v49);
    US0 v51;
    v51 = US0_0();
    USIncref0(&(v51));
    
    UH7 * v52;
    v52 = UH7_2(v51);
    
    USDecref0(&(v51));
    US0 v53;
    v53 = US0_1();
    USIncref0(&(v53));
    
    UH7 * v54;
    v54 = UH7_2(v53);
    v52->refc++; v54->refc++;
    USDecref0(&(v53));
    UH7 * v55;
    v55 = UH7_3(v52, v54);
    v55->refc++;
    UHDecref7(v52); UHDecref7(v54);
    UH7 * v56;
    v56 = UH7_5(v55);
    
    UHDecref7(v55);
    US0 v57;
    v57 = US0_0();
    USIncref0(&(v57));
    
    UH7 * v58;
    v58 = UH7_2(v57);
    v56->refc++; v58->refc++;
    USDecref0(&(v57));
    UH7 * v59;
    v59 = UH7_4(v56, v58);
    v20->refc++; v59->refc++;
    UHDecref7(v56); UHDecref7(v58);
    bool v60;
    v60 = loop8(v59, v20);
    
    UHDecref1(v20); UHDecref7(v59);
    bool v75;
    if (v60){
        
        
        US1 v61;
        v61 = US1_0();
        USIncref1(&(v61));
        
        UH8 * v62;
        v62 = UH8_2(v61);
        
        USDecref1(&(v61));
        US1 v63;
        v63 = US1_1();
        USIncref1(&(v63));
        
        UH8 * v64;
        v64 = UH8_2(v63);
        v62->refc++; v64->refc++;
        USDecref1(&(v63));
        UH8 * v65;
        v65 = UH8_3(v62, v64);
        v65->refc++;
        UHDecref8(v62); UHDecref8(v64);
        UH8 * v66;
        v66 = UH8_5(v65);
        
        UHDecref8(v65);
        US1 v67;
        v67 = US1_2();
        USIncref1(&(v67));
        
        UH8 * v68;
        v68 = UH8_2(v67);
        v66->refc++; v68->refc++;
        USDecref1(&(v67));
        UH8 * v69;
        v69 = UH8_4(v66, v68);
        v47->refc++; v69->refc++;
        UHDecref8(v66); UHDecref8(v68);
        bool v70;
        v70 = loop21(v69, v47);
        
        UHDecref8(v69);
        if (v70){
            
            
            int32_t v71;
            v71 = 1l;
            v50->refc++;
            
            US3 v72;
            v72 = loop34(v71, v50);
            
            
            switch (v72.tag) {
                case 2: { // InventoryDfaInputOutsideInventory
                    
                    
                    USDecref3(&(v72));
                    v75 = true;
                    break;
                }
                default: {
                    
                    USDecref3(&(v72));
                    v75 = false;
                }
            }
        } else {
            
            
            v75 = false;
        }
    } else {
        
        
        v75 = false;
    }
    
    UHDecref4(v47); UHDecref6(v50);
    if (v75){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
