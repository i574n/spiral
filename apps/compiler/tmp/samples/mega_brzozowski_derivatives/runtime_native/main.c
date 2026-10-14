#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
typedef struct UH1 UH1;
void UHDecref1(UH1 * x);
typedef struct UH2 UH2;
void UHDecref2(UH2 * x);
typedef struct UH3 UH3;
void UHDecref3(UH3 * x);
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
        } case1; // InputCons
    };
};
typedef struct {
    int tag;
    union {
    };
} US1;
struct UH1 {
    int refc;
    int tag;
    union {
        struct {
            US1 v0;
            UH1 * v1;
        } case1; // InputCons
    };
};
struct UH2 {
    int refc;
    int tag;
    union {
        struct {
            US0 v0;
        } case2; // RegexChar
        struct {
            UH2 * v0;
            UH2 * v1;
        } case3; // RegexAlt
        struct {
            UH2 * v0;
            UH2 * v1;
        } case4; // RegexCat
        struct {
            UH2 * v0;
        } case5; // RegexStar
    };
};
typedef struct {
    int tag;
    union {
    };
} US2;
typedef struct {
    int tag;
    union {
    };
} US3;
struct UH3 {
    int refc;
    int tag;
    union {
        struct {
            US1 v0;
        } case2; // RegexChar
        struct {
            UH3 * v0;
            UH3 * v1;
        } case3; // RegexAlt
        struct {
            UH3 * v0;
            UH3 * v1;
        } case4; // RegexCat
        struct {
            UH3 * v0;
        } case5; // RegexStar
    };
};
typedef struct {
    int tag;
    union {
        struct {
            UH2 * v0;
            UH0 * v1;
        } case0; // BitMatcherRaw
    };
} US4;
typedef struct {
    int tag;
    union {
        struct {
            UH2 * v0;
            UH0 * v1;
            bool v2;
        } case1; // BitMatcherDecided
    };
} US5;
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
US0 US0_BitZero() { // BitZero
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_BitOne() { // BitOne
    US0 x;
    x.tag = 1;
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
UH0 * UH0_InputEmpty() { // InputEmpty
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH0 * UH0_InputCons(US0 v0, UH0 * v1) { // InputCons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
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
US1 US1_TriA() { // TriA
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_TriB() { // TriB
    US1 x;
    x.tag = 1;
    return x;
}
US1 US1_TriC() { // TriC
    US1 x;
    x.tag = 2;
    return x;
}
static inline void UHDecrefBody1(UH1 * x){
    switch (x->tag) {
        case 1: {
            UHDecref1(x->case1.v1);
            break;
        }
    }
}
void UHDecref1(UH1 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH1 * next = NULL;
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
UH1 * UH1_InputEmpty() { // InputEmpty
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH1 * UH1_InputCons(US1 v0, UH1 * v1) { // InputCons
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
static inline void UHDecrefBody2(UH2 * x){
    switch (x->tag) {
        case 3: {
            UHDecref2(x->case3.v0); UHDecref2(x->case3.v1);
            break;
        }
        case 4: {
            UHDecref2(x->case4.v0); UHDecref2(x->case4.v1);
            break;
        }
        case 5: {
            UHDecref2(x->case5.v0);
            break;
        }
    }
}
void UHDecref2(UH2 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH2 * next = NULL;
        switch (x->tag) {
            case 3: {
                UHDecref2(x->case3.v0);
                next = x->case3.v1;
                break;
            }
            case 4: {
                UHDecref2(x->case4.v0);
                next = x->case4.v1;
                break;
            }
            case 5: {
                
                next = x->case5.v0;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH2 * UH2_RegexEmpty() { // RegexEmpty
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH2 * UH2_RegexEpsilon() { // RegexEpsilon
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 1;
    x->refc = 1;
    return x;
}
UH2 * UH2_RegexChar(US0 v0) { // RegexChar
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0;
    return x;
}
UH2 * UH2_RegexAlt(UH2 * v0, UH2 * v1) { // RegexAlt
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 3;
    x->refc = 1;
    x->case3.v0 = v0; x->case3.v1 = v1;
    return x;
}
UH2 * UH2_RegexCat(UH2 * v0, UH2 * v1) { // RegexCat
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 4;
    x->refc = 1;
    x->case4.v0 = v0; x->case4.v1 = v1;
    return x;
}
UH2 * UH2_RegexStar(UH2 * v0) { // RegexStar
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 5;
    x->refc = 1;
    x->case5.v0 = v0;
    return x;
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
US2 US2_SymbolLess() { // SymbolLess
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_SymbolSame() { // SymbolSame
    US2 x;
    x.tag = 1;
    return x;
}
US2 US2_SymbolGreater() { // SymbolGreater
    US2 x;
    x.tag = 2;
    return x;
}
US2 regex_compare5(UH2 * v0, UH2 * v1){
    while (1) {
        
        
        switch (v0->tag) {
            case 3: { // RegexAlt
                UH2 * v53 = v0->case3.v0; UH2 * v54 = v0->case3.v1;
                (v53)->refc++; (v54)->refc++;
                UHDecref2(v0);
                switch (v1->tag) {
                    case 3: { // RegexAlt
                        UH2 * v55 = v1->case3.v0; UH2 * v56 = v1->case3.v1;
                        (v53)->refc++; (v55)->refc += 2; (v56)->refc++;
                        UHDecref2(v1);
                        US2 v57;
                        v57 = regex_compare5(v53, v55);
                        
                        UHDecref2(v53); UHDecref2(v55);
                        switch (v57.tag) {
                            case 1: { // SymbolSame
                                
                                
                                
                                {
                                    UH2 * tmp0 = v54;
                                    UH2 * tmp1 = v56;
                                    v0 = tmp0;
                                    v1 = tmp1;
                                }
                                continue;
                                break;
                            }
                            default: {
                                
                                UHDecref2(v54); UHDecref2(v56);
                                return v57;
                            }
                        }
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1); UHDecref2(v53); UHDecref2(v54);
                        return US2_SymbolGreater();
                    }
                }
                break;
            }
            case 4: { // RegexCat
                UH2 * v28 = v0->case4.v0; UH2 * v29 = v0->case4.v1;
                (v28)->refc++; (v29)->refc++;
                UHDecref2(v0);
                switch (v1->tag) {
                    case 4: { // RegexCat
                        UH2 * v34 = v1->case4.v0; UH2 * v35 = v1->case4.v1;
                        (v28)->refc++; (v34)->refc += 2; (v35)->refc++;
                        UHDecref2(v1);
                        US2 v36;
                        v36 = regex_compare5(v28, v34);
                        
                        UHDecref2(v28); UHDecref2(v34);
                        switch (v36.tag) {
                            case 1: { // SymbolSame
                                
                                
                                
                                {
                                    UH2 * tmp2 = v29;
                                    UH2 * tmp3 = v35;
                                    v0 = tmp2;
                                    v1 = tmp3;
                                }
                                continue;
                                break;
                            }
                            default: {
                                
                                UHDecref2(v29); UHDecref2(v35);
                                return v36;
                            }
                        }
                        break;
                    }
                    case 2: { // RegexChar
                        
                        
                        UHDecref2(v1); UHDecref2(v28); UHDecref2(v29);
                        return US2_SymbolGreater();
                        break;
                    }
                    case 0: { // RegexEmpty
                        
                        
                        UHDecref2(v1); UHDecref2(v28); UHDecref2(v29);
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: { // RegexEpsilon
                        
                        
                        UHDecref2(v1); UHDecref2(v28); UHDecref2(v29);
                        return US2_SymbolGreater();
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1); UHDecref2(v28); UHDecref2(v29);
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 2: { // RegexChar
                US0 v10 = v0->case2.v0;
                
                UHDecref2(v0);
                switch (v1->tag) {
                    case 2: { // RegexChar
                        US0 v13 = v1->case2.v0;
                        
                        UHDecref2(v1);
                        switch (v10.tag) {
                            case 1: { // BitOne
                                
                                
                                
                                switch (v13.tag) {
                                    case 1: { // BitOne
                                        
                                        
                                        
                                        return US2_SymbolSame();
                                        break;
                                    }
                                    default: { // BitZero
                                        
                                        
                                        
                                        return US2_SymbolGreater();
                                        break;
                                    }
                                }
                                break;
                            }
                            default: { // BitZero
                                
                                
                                
                                switch (v13.tag) {
                                    case 1: { // BitOne
                                        
                                        
                                        
                                        return US2_SymbolLess();
                                        break;
                                    }
                                    default: { // BitZero
                                        
                                        
                                        
                                        return US2_SymbolSame();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                    case 0: { // RegexEmpty
                        
                        
                        UHDecref2(v1);
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: { // RegexEpsilon
                        
                        
                        UHDecref2(v1);
                        return US2_SymbolGreater();
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1);
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 0: { // RegexEmpty
                
                
                UHDecref2(v0);
                switch (v1->tag) {
                    case 0: { // RegexEmpty
                        
                        
                        UHDecref2(v1);
                        return US2_SymbolSame();
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1);
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 1: { // RegexEpsilon
                
                
                UHDecref2(v0);
                switch (v1->tag) {
                    case 0: { // RegexEmpty
                        
                        
                        UHDecref2(v1);
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: { // RegexEpsilon
                        
                        
                        UHDecref2(v1);
                        return US2_SymbolSame();
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1);
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            default: { // RegexStar
                UH2 * v44 = v0->case5.v0;
                (v44)->refc++;
                UHDecref2(v0);
                switch (v1->tag) {
                    case 3: { // RegexAlt
                        
                        
                        UHDecref2(v1); UHDecref2(v44);
                        return US2_SymbolLess();
                        break;
                    }
                    case 5: { // RegexStar
                        UH2 * v48 = v1->case5.v0;
                        (v48)->refc++;
                        UHDecref2(v1);
                        {
                            UH2 * tmp4 = v44;
                            UH2 * tmp5 = v48;
                            v0 = tmp4;
                            v1 = tmp5;
                        }
                        continue;
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1); UHDecref2(v44);
                        return US2_SymbolGreater();
                    }
                }
                break;
            }
        }
    }
}
UH2 * alt_insert_sorted4(UH2 * v0, UH2 * v1){
    
    
    switch (v1->tag) {
        case 3: { // RegexAlt
            UH2 * v2 = v1->case3.v0; UH2 * v3 = v1->case3.v1;
            (v0)->refc++; (v2)->refc += 2; (v3)->refc++;
            
            US2 v4;
            v4 = regex_compare5(v0, v2);
            
            
            switch (v4.tag) {
                case 2: { // SymbolGreater
                    
                    (v0)->refc++; (v3)->refc++;
                    UHDecref2(v1);
                    UH2 * v6;
                    v6 = alt_insert_sorted4(v0, v3);
                    
                    UHDecref2(v0); UHDecref2(v3);
                    return UH2_RegexAlt(v2, v6);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    UHDecref2(v2); UHDecref2(v3);
                    return UH2_RegexAlt(v0, v1);
                    break;
                }
                default: { // SymbolSame
                    
                    
                    UHDecref2(v0); UHDecref2(v2); UHDecref2(v3);
                    return v1;
                    break;
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref2(v1);
            return v0;
            break;
        }
        default: {
            (v0)->refc++; (v1)->refc++;
            
            US2 v11;
            v11 = regex_compare5(v0, v1);
            
            
            switch (v11.tag) {
                case 2: { // SymbolGreater
                    
                    
                    
                    return UH2_RegexAlt(v1, v0);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    
                    return UH2_RegexAlt(v0, v1);
                    break;
                }
                default: { // SymbolSame
                    
                    
                    UHDecref2(v0);
                    return v1;
                    break;
                }
            }
        }
    }
}
UH2 * make_alt3(UH2 * v0, UH2 * v1){
    while (1) {
        
        
        switch (v0->tag) {
            case 3: { // RegexAlt
                UH2 * v2 = v0->case3.v0; UH2 * v3 = v0->case3.v1;
                (v1)->refc++; (v2)->refc += 2; (v3)->refc++;
                UHDecref2(v0);
                UH2 * v4;
                v4 = alt_insert_sorted4(v2, v1);
                
                UHDecref2(v1); UHDecref2(v2);
                {
                    UH2 * tmp6 = v3;
                    UH2 * tmp7 = v4;
                    v0 = tmp6;
                    v1 = tmp7;
                }
                continue;
                break;
            }
            case 0: { // RegexEmpty
                
                
                UHDecref2(v0);
                return v1;
                break;
            }
            default: {
                
                
                return alt_insert_sorted4(v0, v1);
            }
        }
    }
}
bool regex_equal7(UH2 * v0, UH2 * v1){
    while (1) {
        
        
        switch (v0->tag) {
            case 3: { // RegexAlt
                UH2 * v18 = v0->case3.v0; UH2 * v19 = v0->case3.v1;
                (v18)->refc++; (v19)->refc++;
                UHDecref2(v0);
                switch (v1->tag) {
                    case 3: { // RegexAlt
                        UH2 * v20 = v1->case3.v0; UH2 * v21 = v1->case3.v1;
                        (v18)->refc++; (v20)->refc += 2; (v21)->refc++;
                        UHDecref2(v1);
                        bool v22;
                        v22 = regex_equal7(v18, v20);
                        
                        UHDecref2(v18); UHDecref2(v20);
                        if (v22){
                            
                            
                            {
                                UH2 * tmp8 = v19;
                                UH2 * tmp9 = v21;
                                v0 = tmp8;
                                v1 = tmp9;
                            }
                            continue;
                        } else {
                            
                            UHDecref2(v19); UHDecref2(v21);
                            return false;
                        }
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1); UHDecref2(v18); UHDecref2(v19);
                        return false;
                    }
                }
                break;
            }
            case 4: { // RegexCat
                UH2 * v26 = v0->case4.v0; UH2 * v27 = v0->case4.v1;
                (v26)->refc++; (v27)->refc++;
                UHDecref2(v0);
                switch (v1->tag) {
                    case 4: { // RegexCat
                        UH2 * v28 = v1->case4.v0; UH2 * v29 = v1->case4.v1;
                        (v26)->refc++; (v28)->refc += 2; (v29)->refc++;
                        UHDecref2(v1);
                        bool v30;
                        v30 = regex_equal7(v26, v28);
                        
                        UHDecref2(v26); UHDecref2(v28);
                        if (v30){
                            
                            
                            {
                                UH2 * tmp10 = v27;
                                UH2 * tmp11 = v29;
                                v0 = tmp10;
                                v1 = tmp11;
                            }
                            continue;
                        } else {
                            
                            UHDecref2(v27); UHDecref2(v29);
                            return false;
                        }
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1); UHDecref2(v26); UHDecref2(v27);
                        return false;
                    }
                }
                break;
            }
            case 2: { // RegexChar
                US0 v4 = v0->case2.v0;
                
                UHDecref2(v0);
                switch (v1->tag) {
                    case 2: { // RegexChar
                        US0 v5 = v1->case2.v0;
                        
                        UHDecref2(v1);
                        US2 v15;
                        switch (v4.tag) {
                            case 1: { // BitOne
                                
                                
                                
                                switch (v5.tag) {
                                    case 1: { // BitOne
                                        
                                        
                                        
                                        v15 = US2_SymbolSame();
                                        break;
                                    }
                                    default: { // BitZero
                                        
                                        
                                        
                                        v15 = US2_SymbolGreater();
                                        break;
                                    }
                                }
                                break;
                            }
                            default: { // BitZero
                                
                                
                                
                                switch (v5.tag) {
                                    case 1: { // BitOne
                                        
                                        
                                        
                                        v15 = US2_SymbolLess();
                                        break;
                                    }
                                    default: { // BitZero
                                        
                                        
                                        
                                        v15 = US2_SymbolSame();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        
                        
                        switch (v15.tag) {
                            case 1: { // SymbolSame
                                
                                
                                
                                return true;
                                break;
                            }
                            default: {
                                
                                
                                return false;
                            }
                        }
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1);
                        return false;
                    }
                }
                break;
            }
            case 0: { // RegexEmpty
                
                
                UHDecref2(v0);
                switch (v1->tag) {
                    case 0: { // RegexEmpty
                        
                        
                        UHDecref2(v1);
                        return true;
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1);
                        return false;
                    }
                }
                break;
            }
            case 1: { // RegexEpsilon
                
                
                UHDecref2(v0);
                switch (v1->tag) {
                    case 1: { // RegexEpsilon
                        
                        
                        UHDecref2(v1);
                        return true;
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1);
                        return false;
                    }
                }
                break;
            }
            default: { // RegexStar
                UH2 * v34 = v0->case5.v0;
                (v34)->refc++;
                UHDecref2(v0);
                switch (v1->tag) {
                    case 5: { // RegexStar
                        UH2 * v35 = v1->case5.v0;
                        (v35)->refc++;
                        UHDecref2(v1);
                        {
                            UH2 * tmp12 = v34;
                            UH2 * tmp13 = v35;
                            v0 = tmp12;
                            v1 = tmp13;
                        }
                        continue;
                        break;
                    }
                    default: {
                        
                        UHDecref2(v1); UHDecref2(v34);
                        return false;
                    }
                }
                break;
            }
        }
    }
}
UH2 * make_cat6(UH2 * v0, UH2 * v1){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0); UHDecref2(v1);
            return UH2_RegexEmpty();
            break;
        }
        default: {
            
            
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref2(v0); UHDecref2(v1);
                    return UH2_RegexEmpty();
                    break;
                }
                default: {
                    
                    
                    switch (v0->tag) {
                        case 1: { // RegexEpsilon
                            
                            
                            UHDecref2(v0);
                            return v1;
                            break;
                        }
                        default: {
                            
                            
                            switch (v1->tag) {
                                case 1: { // RegexEpsilon
                                    
                                    
                                    UHDecref2(v1);
                                    return v0;
                                    break;
                                }
                                default: {
                                    
                                    
                                    switch (v0->tag) {
                                        case 4: { // RegexCat
                                            UH2 * v12 = v0->case4.v0; UH2 * v13 = v0->case4.v1;
                                            (v1)->refc++; (v12)->refc++; (v13)->refc += 2;
                                            UHDecref2(v0);
                                            UH2 * v14;
                                            v14 = make_cat6(v13, v1);
                                            
                                            UHDecref2(v1); UHDecref2(v13);
                                            return UH2_RegexCat(v12, v14);
                                            break;
                                        }
                                        case 5: { // RegexStar
                                            UH2 * v4 = v0->case5.v0;
                                            (v4)->refc++;
                                            
                                            switch (v1->tag) {
                                                case 5: { // RegexStar
                                                    UH2 * v5 = v1->case5.v0;
                                                    (v4)->refc++; (v5)->refc += 2;
                                                    
                                                    bool v6;
                                                    v6 = regex_equal7(v4, v5);
                                                    
                                                    UHDecref2(v5);
                                                    if (v6){
                                                        
                                                        UHDecref2(v0); UHDecref2(v1);
                                                        return UH2_RegexStar(v4);
                                                    } else {
                                                        
                                                        UHDecref2(v4);
                                                        return UH2_RegexCat(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    
                                                    UHDecref2(v4);
                                                    return UH2_RegexCat(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            
                                            
                                            return UH2_RegexCat(v0, v1);
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
UH2 * make_star8(UH2 * v0){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0);
            return UH2_RegexEpsilon();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref2(v0);
            return UH2_RegexEpsilon();
            break;
        }
        case 5: { // RegexStar
            UH2 * v3 = v0->case5.v0;
            (v3)->refc++;
            UHDecref2(v0);
            return UH2_RegexStar(v3);
            break;
        }
        default: {
            
            
            return UH2_RegexStar(v0);
        }
    }
}
UH2 * normalize2(UH2 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH2 * v5 = v0->case3.v0; UH2 * v6 = v0->case3.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref2(v0);
            UH2 * v7;
            v7 = normalize2(v5);
            (v6)->refc++;
            UHDecref2(v5);
            UH2 * v8;
            v8 = normalize2(v6);
            
            UHDecref2(v6);
            return make_alt3(v7, v8);
            break;
        }
        case 4: { // RegexCat
            UH2 * v10 = v0->case4.v0; UH2 * v11 = v0->case4.v1;
            (v10)->refc += 2; (v11)->refc++;
            UHDecref2(v0);
            UH2 * v12;
            v12 = normalize2(v10);
            (v11)->refc++;
            UHDecref2(v10);
            UH2 * v13;
            v13 = normalize2(v11);
            
            UHDecref2(v11);
            return make_cat6(v12, v13);
            break;
        }
        case 2: { // RegexChar
            US0 v3 = v0->case2.v0;
            
            UHDecref2(v0);
            return UH2_RegexChar(v3);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0);
            return UH2_RegexEmpty();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref2(v0);
            return UH2_RegexEpsilon();
            break;
        }
        default: { // RegexStar
            UH2 * v15 = v0->case5.v0;
            (v15)->refc += 2;
            UHDecref2(v0);
            UH2 * v16;
            v16 = normalize2(v15);
            
            UHDecref2(v15);
            return make_star8(v16);
            break;
        }
    }
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
US3 US3_Nullable() { // Nullable
    US3 x;
    x.tag = 0;
    return x;
}
US3 US3_NonNullable() { // NonNullable
    US3 x;
    x.tag = 1;
    return x;
}
US3 nullable10(UH2 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH2 * v5 = v0->case3.v0; UH2 * v6 = v0->case3.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref2(v0);
            US3 v7;
            v7 = nullable10(v5);
            (v6)->refc++;
            UHDecref2(v5);
            US3 v8;
            v8 = nullable10(v6);
            
            UHDecref2(v6);
            switch (v7.tag) {
                case 0: { // Nullable
                    
                    
                    
                    return US3_Nullable();
                    break;
                }
                default: {
                    
                    
                    switch (v8.tag) {
                        case 0: { // Nullable
                            
                            
                            
                            return US3_Nullable();
                            break;
                        }
                        default: {
                            
                            
                            switch (v7.tag) {
                                default: { // NonNullable
                                    
                                    
                                    
                                    switch (v8.tag) {
                                        default: { // NonNullable
                                            
                                            
                                            
                                            return US3_NonNullable();
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
            UH2 * v16 = v0->case4.v0; UH2 * v17 = v0->case4.v1;
            (v16)->refc += 2; (v17)->refc++;
            UHDecref2(v0);
            US3 v18;
            v18 = nullable10(v16);
            (v17)->refc++;
            UHDecref2(v16);
            US3 v19;
            v19 = nullable10(v17);
            
            UHDecref2(v17);
            switch (v18.tag) {
                case 0: { // Nullable
                    
                    
                    
                    switch (v19.tag) {
                        case 0: { // Nullable
                            
                            
                            
                            return US3_Nullable();
                            break;
                        }
                        default: {
                            
                            
                            return US3_NonNullable();
                        }
                    }
                    break;
                }
                default: {
                    
                    
                    return US3_NonNullable();
                }
            }
            break;
        }
        case 2: { // RegexChar
            
            
            UHDecref2(v0);
            return US3_NonNullable();
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0);
            return US3_NonNullable();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref2(v0);
            return US3_Nullable();
            break;
        }
        default: { // RegexStar
            
            
            UHDecref2(v0);
            return US3_Nullable();
            break;
        }
    }
}
UH2 * derivative9(UH2 * v0, US0 v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH2 * v19 = v0->case3.v0; UH2 * v20 = v0->case3.v1;
            (v19)->refc += 2; (v20)->refc++;
            UHDecref2(v0);
            UH2 * v21;
            v21 = derivative9(v19, v1);
            (v20)->refc++;
            UHDecref2(v19);
            UH2 * v22;
            v22 = derivative9(v20, v1);
            
            UHDecref2(v20);
            return make_alt3(v21, v22);
            break;
        }
        case 4: { // RegexCat
            UH2 * v24 = v0->case4.v0; UH2 * v25 = v0->case4.v1;
            (v24)->refc += 2; (v25)->refc++;
            UHDecref2(v0);
            US3 v26;
            v26 = nullable10(v24);
            
            
            switch (v26.tag) {
                case 1: { // NonNullable
                    
                    (v24)->refc++;
                    
                    UH2 * v31;
                    v31 = derivative9(v24, v1);
                    
                    UHDecref2(v24);
                    return make_cat6(v31, v25);
                    break;
                }
                default: { // Nullable
                    
                    (v24)->refc++;
                    
                    UH2 * v27;
                    v27 = derivative9(v24, v1);
                    (v25)->refc++; (v27)->refc++;
                    UHDecref2(v24);
                    UH2 * v28;
                    v28 = make_cat6(v27, v25);
                    (v25)->refc++;
                    UHDecref2(v27);
                    UH2 * v29;
                    v29 = derivative9(v25, v1);
                    
                    UHDecref2(v25);
                    return make_alt3(v28, v29);
                    break;
                }
            }
            break;
        }
        case 2: { // RegexChar
            US0 v4 = v0->case2.v0;
            
            UHDecref2(v0);
            US2 v14;
            switch (v4.tag) {
                case 1: { // BitOne
                    
                    
                    
                    switch (v1.tag) {
                        case 1: { // BitOne
                            
                            
                            
                            v14 = US2_SymbolSame();
                            break;
                        }
                        default: { // BitZero
                            
                            
                            
                            v14 = US2_SymbolGreater();
                            break;
                        }
                    }
                    break;
                }
                default: { // BitZero
                    
                    
                    
                    switch (v1.tag) {
                        case 1: { // BitOne
                            
                            
                            
                            v14 = US2_SymbolLess();
                            break;
                        }
                        default: { // BitZero
                            
                            
                            
                            v14 = US2_SymbolSame();
                            break;
                        }
                    }
                    break;
                }
            }
            
            
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
            
            
            if (v15){
                
                
                return UH2_RegexEpsilon();
            } else {
                
                
                return UH2_RegexEmpty();
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0);
            return UH2_RegexEmpty();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref2(v0);
            return UH2_RegexEmpty();
            break;
        }
        default: { // RegexStar
            UH2 * v35 = v0->case5.v0;
            (v35)->refc += 2;
            UHDecref2(v0);
            UH2 * v36;
            v36 = derivative9(v35, v1);
            (v35)->refc++;
            
            UH2 * v37;
            v37 = make_star8(v35);
            
            UHDecref2(v35);
            return make_cat6(v36, v37);
            break;
        }
    }
}
UH2 * canonical_derivative1(UH2 * v0, US0 v1){
    (v0)->refc++;
    
    UH2 * v2;
    v2 = normalize2(v0);
    (v2)->refc++;
    UHDecref2(v0);
    UH2 * v3;
    v3 = derivative9(v2, v1);
    
    UHDecref2(v2);
    return normalize2(v3);
}
bool accepts0(UH2 * v0, UH0 * v1){
    while (1) {
        
        
        switch (v1->tag) {
            case 1: { // InputCons
                US0 v6 = v1->case1.v0; UH0 * v7 = v1->case1.v1;
                (v0)->refc++; (v7)->refc++;
                UHDecref0(v1);
                UH2 * v8;
                v8 = canonical_derivative1(v0, v6);
                
                UHDecref2(v0);
                {
                    UH2 * tmp14 = v8;
                    UH0 * tmp15 = v7;
                    v0 = tmp14;
                    v1 = tmp15;
                }
                continue;
                break;
            }
            default: { // InputEmpty
                
                (v0)->refc++;
                UHDecref0(v1);
                UH2 * v2;
                v2 = normalize2(v0);
                (v2)->refc++;
                UHDecref2(v0);
                US3 v3;
                v3 = nullable10(v2);
                
                UHDecref2(v2);
                switch (v3.tag) {
                    case 1: { // NonNullable
                        
                        
                        
                        return false;
                        break;
                    }
                    default: { // Nullable
                        
                        
                        
                        return true;
                        break;
                    }
                }
                break;
            }
        }
    }
}
static inline void UHDecrefBody3(UH3 * x){
    switch (x->tag) {
        case 3: {
            UHDecref3(x->case3.v0); UHDecref3(x->case3.v1);
            break;
        }
        case 4: {
            UHDecref3(x->case4.v0); UHDecref3(x->case4.v1);
            break;
        }
        case 5: {
            UHDecref3(x->case5.v0);
            break;
        }
    }
}
void UHDecref3(UH3 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH3 * next = NULL;
        switch (x->tag) {
            case 3: {
                UHDecref3(x->case3.v0);
                next = x->case3.v1;
                break;
            }
            case 4: {
                UHDecref3(x->case4.v0);
                next = x->case4.v1;
                break;
            }
            case 5: {
                
                next = x->case5.v0;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH3 * UH3_RegexEmpty() { // RegexEmpty
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH3 * UH3_RegexEpsilon() { // RegexEpsilon
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 1;
    x->refc = 1;
    return x;
}
UH3 * UH3_RegexChar(US1 v0) { // RegexChar
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0;
    return x;
}
UH3 * UH3_RegexAlt(UH3 * v0, UH3 * v1) { // RegexAlt
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 3;
    x->refc = 1;
    x->case3.v0 = v0; x->case3.v1 = v1;
    return x;
}
UH3 * UH3_RegexCat(UH3 * v0, UH3 * v1) { // RegexCat
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 4;
    x->refc = 1;
    x->case4.v0 = v0; x->case4.v1 = v1;
    return x;
}
UH3 * UH3_RegexStar(UH3 * v0) { // RegexStar
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 5;
    x->refc = 1;
    x->case5.v0 = v0;
    return x;
}
US2 regex_compare16(UH3 * v0, UH3 * v1){
    while (1) {
        
        
        switch (v0->tag) {
            case 3: { // RegexAlt
                UH3 * v59 = v0->case3.v0; UH3 * v60 = v0->case3.v1;
                (v59)->refc++; (v60)->refc++;
                UHDecref3(v0);
                switch (v1->tag) {
                    case 3: { // RegexAlt
                        UH3 * v61 = v1->case3.v0; UH3 * v62 = v1->case3.v1;
                        (v59)->refc++; (v61)->refc += 2; (v62)->refc++;
                        UHDecref3(v1);
                        US2 v63;
                        v63 = regex_compare16(v59, v61);
                        
                        UHDecref3(v59); UHDecref3(v61);
                        switch (v63.tag) {
                            case 1: { // SymbolSame
                                
                                
                                
                                {
                                    UH3 * tmp16 = v60;
                                    UH3 * tmp17 = v62;
                                    v0 = tmp16;
                                    v1 = tmp17;
                                }
                                continue;
                                break;
                            }
                            default: {
                                
                                UHDecref3(v60); UHDecref3(v62);
                                return v63;
                            }
                        }
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1); UHDecref3(v59); UHDecref3(v60);
                        return US2_SymbolGreater();
                    }
                }
                break;
            }
            case 4: { // RegexCat
                UH3 * v34 = v0->case4.v0; UH3 * v35 = v0->case4.v1;
                (v34)->refc++; (v35)->refc++;
                UHDecref3(v0);
                switch (v1->tag) {
                    case 4: { // RegexCat
                        UH3 * v40 = v1->case4.v0; UH3 * v41 = v1->case4.v1;
                        (v34)->refc++; (v40)->refc += 2; (v41)->refc++;
                        UHDecref3(v1);
                        US2 v42;
                        v42 = regex_compare16(v34, v40);
                        
                        UHDecref3(v34); UHDecref3(v40);
                        switch (v42.tag) {
                            case 1: { // SymbolSame
                                
                                
                                
                                {
                                    UH3 * tmp18 = v35;
                                    UH3 * tmp19 = v41;
                                    v0 = tmp18;
                                    v1 = tmp19;
                                }
                                continue;
                                break;
                            }
                            default: {
                                
                                UHDecref3(v35); UHDecref3(v41);
                                return v42;
                            }
                        }
                        break;
                    }
                    case 2: { // RegexChar
                        
                        
                        UHDecref3(v1); UHDecref3(v34); UHDecref3(v35);
                        return US2_SymbolGreater();
                        break;
                    }
                    case 0: { // RegexEmpty
                        
                        
                        UHDecref3(v1); UHDecref3(v34); UHDecref3(v35);
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: { // RegexEpsilon
                        
                        
                        UHDecref3(v1); UHDecref3(v34); UHDecref3(v35);
                        return US2_SymbolGreater();
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1); UHDecref3(v34); UHDecref3(v35);
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 2: { // RegexChar
                US1 v10 = v0->case2.v0;
                
                UHDecref3(v0);
                switch (v1->tag) {
                    case 2: { // RegexChar
                        US1 v13 = v1->case2.v0;
                        
                        UHDecref3(v1);
                        switch (v10.tag) {
                            case 0: { // TriA
                                
                                
                                
                                switch (v13.tag) {
                                    case 0: { // TriA
                                        
                                        
                                        
                                        return US2_SymbolSame();
                                        break;
                                    }
                                    default: {
                                        
                                        
                                        return US2_SymbolLess();
                                    }
                                }
                                break;
                            }
                            default: {
                                
                                
                                switch (v13.tag) {
                                    case 0: { // TriA
                                        
                                        
                                        
                                        return US2_SymbolGreater();
                                        break;
                                    }
                                    default: {
                                        
                                        
                                        switch (v10.tag) {
                                            case 1: { // TriB
                                                
                                                
                                                
                                                switch (v13.tag) {
                                                    case 1: { // TriB
                                                        
                                                        
                                                        
                                                        return US2_SymbolSame();
                                                        break;
                                                    }
                                                    default: { // TriC
                                                        
                                                        
                                                        
                                                        return US2_SymbolLess();
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                            default: { // TriC
                                                
                                                
                                                
                                                switch (v13.tag) {
                                                    case 1: { // TriB
                                                        
                                                        
                                                        
                                                        return US2_SymbolGreater();
                                                        break;
                                                    }
                                                    default: { // TriC
                                                        
                                                        
                                                        
                                                        return US2_SymbolSame();
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
                        
                        
                        UHDecref3(v1);
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: { // RegexEpsilon
                        
                        
                        UHDecref3(v1);
                        return US2_SymbolGreater();
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1);
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 0: { // RegexEmpty
                
                
                UHDecref3(v0);
                switch (v1->tag) {
                    case 0: { // RegexEmpty
                        
                        
                        UHDecref3(v1);
                        return US2_SymbolSame();
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1);
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 1: { // RegexEpsilon
                
                
                UHDecref3(v0);
                switch (v1->tag) {
                    case 0: { // RegexEmpty
                        
                        
                        UHDecref3(v1);
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: { // RegexEpsilon
                        
                        
                        UHDecref3(v1);
                        return US2_SymbolSame();
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1);
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            default: { // RegexStar
                UH3 * v50 = v0->case5.v0;
                (v50)->refc++;
                UHDecref3(v0);
                switch (v1->tag) {
                    case 3: { // RegexAlt
                        
                        
                        UHDecref3(v1); UHDecref3(v50);
                        return US2_SymbolLess();
                        break;
                    }
                    case 5: { // RegexStar
                        UH3 * v54 = v1->case5.v0;
                        (v54)->refc++;
                        UHDecref3(v1);
                        {
                            UH3 * tmp20 = v50;
                            UH3 * tmp21 = v54;
                            v0 = tmp20;
                            v1 = tmp21;
                        }
                        continue;
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1); UHDecref3(v50);
                        return US2_SymbolGreater();
                    }
                }
                break;
            }
        }
    }
}
UH3 * alt_insert_sorted15(UH3 * v0, UH3 * v1){
    
    
    switch (v1->tag) {
        case 3: { // RegexAlt
            UH3 * v2 = v1->case3.v0; UH3 * v3 = v1->case3.v1;
            (v0)->refc++; (v2)->refc += 2; (v3)->refc++;
            
            US2 v4;
            v4 = regex_compare16(v0, v2);
            
            
            switch (v4.tag) {
                case 2: { // SymbolGreater
                    
                    (v0)->refc++; (v3)->refc++;
                    UHDecref3(v1);
                    UH3 * v6;
                    v6 = alt_insert_sorted15(v0, v3);
                    
                    UHDecref3(v0); UHDecref3(v3);
                    return UH3_RegexAlt(v2, v6);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    UHDecref3(v2); UHDecref3(v3);
                    return UH3_RegexAlt(v0, v1);
                    break;
                }
                default: { // SymbolSame
                    
                    
                    UHDecref3(v0); UHDecref3(v2); UHDecref3(v3);
                    return v1;
                    break;
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref3(v1);
            return v0;
            break;
        }
        default: {
            (v0)->refc++; (v1)->refc++;
            
            US2 v11;
            v11 = regex_compare16(v0, v1);
            
            
            switch (v11.tag) {
                case 2: { // SymbolGreater
                    
                    
                    
                    return UH3_RegexAlt(v1, v0);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    
                    return UH3_RegexAlt(v0, v1);
                    break;
                }
                default: { // SymbolSame
                    
                    
                    UHDecref3(v0);
                    return v1;
                    break;
                }
            }
        }
    }
}
UH3 * make_alt14(UH3 * v0, UH3 * v1){
    while (1) {
        
        
        switch (v0->tag) {
            case 3: { // RegexAlt
                UH3 * v2 = v0->case3.v0; UH3 * v3 = v0->case3.v1;
                (v1)->refc++; (v2)->refc += 2; (v3)->refc++;
                UHDecref3(v0);
                UH3 * v4;
                v4 = alt_insert_sorted15(v2, v1);
                
                UHDecref3(v1); UHDecref3(v2);
                {
                    UH3 * tmp22 = v3;
                    UH3 * tmp23 = v4;
                    v0 = tmp22;
                    v1 = tmp23;
                }
                continue;
                break;
            }
            case 0: { // RegexEmpty
                
                
                UHDecref3(v0);
                return v1;
                break;
            }
            default: {
                
                
                return alt_insert_sorted15(v0, v1);
            }
        }
    }
}
bool regex_equal18(UH3 * v0, UH3 * v1){
    while (1) {
        
        
        switch (v0->tag) {
            case 3: { // RegexAlt
                UH3 * v24 = v0->case3.v0; UH3 * v25 = v0->case3.v1;
                (v24)->refc++; (v25)->refc++;
                UHDecref3(v0);
                switch (v1->tag) {
                    case 3: { // RegexAlt
                        UH3 * v26 = v1->case3.v0; UH3 * v27 = v1->case3.v1;
                        (v24)->refc++; (v26)->refc += 2; (v27)->refc++;
                        UHDecref3(v1);
                        bool v28;
                        v28 = regex_equal18(v24, v26);
                        
                        UHDecref3(v24); UHDecref3(v26);
                        if (v28){
                            
                            
                            {
                                UH3 * tmp24 = v25;
                                UH3 * tmp25 = v27;
                                v0 = tmp24;
                                v1 = tmp25;
                            }
                            continue;
                        } else {
                            
                            UHDecref3(v25); UHDecref3(v27);
                            return false;
                        }
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1); UHDecref3(v24); UHDecref3(v25);
                        return false;
                    }
                }
                break;
            }
            case 4: { // RegexCat
                UH3 * v32 = v0->case4.v0; UH3 * v33 = v0->case4.v1;
                (v32)->refc++; (v33)->refc++;
                UHDecref3(v0);
                switch (v1->tag) {
                    case 4: { // RegexCat
                        UH3 * v34 = v1->case4.v0; UH3 * v35 = v1->case4.v1;
                        (v32)->refc++; (v34)->refc += 2; (v35)->refc++;
                        UHDecref3(v1);
                        bool v36;
                        v36 = regex_equal18(v32, v34);
                        
                        UHDecref3(v32); UHDecref3(v34);
                        if (v36){
                            
                            
                            {
                                UH3 * tmp26 = v33;
                                UH3 * tmp27 = v35;
                                v0 = tmp26;
                                v1 = tmp27;
                            }
                            continue;
                        } else {
                            
                            UHDecref3(v33); UHDecref3(v35);
                            return false;
                        }
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1); UHDecref3(v32); UHDecref3(v33);
                        return false;
                    }
                }
                break;
            }
            case 2: { // RegexChar
                US1 v4 = v0->case2.v0;
                
                UHDecref3(v0);
                switch (v1->tag) {
                    case 2: { // RegexChar
                        US1 v5 = v1->case2.v0;
                        
                        UHDecref3(v1);
                        US2 v21;
                        switch (v4.tag) {
                            case 0: { // TriA
                                
                                
                                
                                switch (v5.tag) {
                                    case 0: { // TriA
                                        
                                        
                                        
                                        v21 = US2_SymbolSame();
                                        break;
                                    }
                                    default: {
                                        
                                        
                                        v21 = US2_SymbolLess();
                                    }
                                }
                                break;
                            }
                            default: {
                                
                                
                                switch (v5.tag) {
                                    case 0: { // TriA
                                        
                                        
                                        
                                        v21 = US2_SymbolGreater();
                                        break;
                                    }
                                    default: {
                                        
                                        
                                        switch (v4.tag) {
                                            case 1: { // TriB
                                                
                                                
                                                
                                                switch (v5.tag) {
                                                    case 1: { // TriB
                                                        
                                                        
                                                        
                                                        v21 = US2_SymbolSame();
                                                        break;
                                                    }
                                                    default: { // TriC
                                                        
                                                        
                                                        
                                                        v21 = US2_SymbolLess();
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                            default: { // TriC
                                                
                                                
                                                
                                                switch (v5.tag) {
                                                    case 1: { // TriB
                                                        
                                                        
                                                        
                                                        v21 = US2_SymbolGreater();
                                                        break;
                                                    }
                                                    default: { // TriC
                                                        
                                                        
                                                        
                                                        v21 = US2_SymbolSame();
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
                        
                        
                        switch (v21.tag) {
                            case 1: { // SymbolSame
                                
                                
                                
                                return true;
                                break;
                            }
                            default: {
                                
                                
                                return false;
                            }
                        }
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1);
                        return false;
                    }
                }
                break;
            }
            case 0: { // RegexEmpty
                
                
                UHDecref3(v0);
                switch (v1->tag) {
                    case 0: { // RegexEmpty
                        
                        
                        UHDecref3(v1);
                        return true;
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1);
                        return false;
                    }
                }
                break;
            }
            case 1: { // RegexEpsilon
                
                
                UHDecref3(v0);
                switch (v1->tag) {
                    case 1: { // RegexEpsilon
                        
                        
                        UHDecref3(v1);
                        return true;
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1);
                        return false;
                    }
                }
                break;
            }
            default: { // RegexStar
                UH3 * v40 = v0->case5.v0;
                (v40)->refc++;
                UHDecref3(v0);
                switch (v1->tag) {
                    case 5: { // RegexStar
                        UH3 * v41 = v1->case5.v0;
                        (v41)->refc++;
                        UHDecref3(v1);
                        {
                            UH3 * tmp28 = v40;
                            UH3 * tmp29 = v41;
                            v0 = tmp28;
                            v1 = tmp29;
                        }
                        continue;
                        break;
                    }
                    default: {
                        
                        UHDecref3(v1); UHDecref3(v40);
                        return false;
                    }
                }
                break;
            }
        }
    }
}
UH3 * make_cat17(UH3 * v0, UH3 * v1){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref3(v0); UHDecref3(v1);
            return UH3_RegexEmpty();
            break;
        }
        default: {
            
            
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref3(v0); UHDecref3(v1);
                    return UH3_RegexEmpty();
                    break;
                }
                default: {
                    
                    
                    switch (v0->tag) {
                        case 1: { // RegexEpsilon
                            
                            
                            UHDecref3(v0);
                            return v1;
                            break;
                        }
                        default: {
                            
                            
                            switch (v1->tag) {
                                case 1: { // RegexEpsilon
                                    
                                    
                                    UHDecref3(v1);
                                    return v0;
                                    break;
                                }
                                default: {
                                    
                                    
                                    switch (v0->tag) {
                                        case 4: { // RegexCat
                                            UH3 * v12 = v0->case4.v0; UH3 * v13 = v0->case4.v1;
                                            (v1)->refc++; (v12)->refc++; (v13)->refc += 2;
                                            UHDecref3(v0);
                                            UH3 * v14;
                                            v14 = make_cat17(v13, v1);
                                            
                                            UHDecref3(v1); UHDecref3(v13);
                                            return UH3_RegexCat(v12, v14);
                                            break;
                                        }
                                        case 5: { // RegexStar
                                            UH3 * v4 = v0->case5.v0;
                                            (v4)->refc++;
                                            
                                            switch (v1->tag) {
                                                case 5: { // RegexStar
                                                    UH3 * v5 = v1->case5.v0;
                                                    (v4)->refc++; (v5)->refc += 2;
                                                    
                                                    bool v6;
                                                    v6 = regex_equal18(v4, v5);
                                                    
                                                    UHDecref3(v5);
                                                    if (v6){
                                                        
                                                        UHDecref3(v0); UHDecref3(v1);
                                                        return UH3_RegexStar(v4);
                                                    } else {
                                                        
                                                        UHDecref3(v4);
                                                        return UH3_RegexCat(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    
                                                    UHDecref3(v4);
                                                    return UH3_RegexCat(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            
                                            
                                            return UH3_RegexCat(v0, v1);
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
UH3 * make_star19(UH3 * v0){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref3(v0);
            return UH3_RegexEpsilon();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref3(v0);
            return UH3_RegexEpsilon();
            break;
        }
        case 5: { // RegexStar
            UH3 * v3 = v0->case5.v0;
            (v3)->refc++;
            UHDecref3(v0);
            return UH3_RegexStar(v3);
            break;
        }
        default: {
            
            
            return UH3_RegexStar(v0);
        }
    }
}
UH3 * normalize13(UH3 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH3 * v5 = v0->case3.v0; UH3 * v6 = v0->case3.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref3(v0);
            UH3 * v7;
            v7 = normalize13(v5);
            (v6)->refc++;
            UHDecref3(v5);
            UH3 * v8;
            v8 = normalize13(v6);
            
            UHDecref3(v6);
            return make_alt14(v7, v8);
            break;
        }
        case 4: { // RegexCat
            UH3 * v10 = v0->case4.v0; UH3 * v11 = v0->case4.v1;
            (v10)->refc += 2; (v11)->refc++;
            UHDecref3(v0);
            UH3 * v12;
            v12 = normalize13(v10);
            (v11)->refc++;
            UHDecref3(v10);
            UH3 * v13;
            v13 = normalize13(v11);
            
            UHDecref3(v11);
            return make_cat17(v12, v13);
            break;
        }
        case 2: { // RegexChar
            US1 v3 = v0->case2.v0;
            
            UHDecref3(v0);
            return UH3_RegexChar(v3);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref3(v0);
            return UH3_RegexEmpty();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref3(v0);
            return UH3_RegexEpsilon();
            break;
        }
        default: { // RegexStar
            UH3 * v15 = v0->case5.v0;
            (v15)->refc += 2;
            UHDecref3(v0);
            UH3 * v16;
            v16 = normalize13(v15);
            
            UHDecref3(v15);
            return make_star19(v16);
            break;
        }
    }
}
US3 nullable21(UH3 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH3 * v5 = v0->case3.v0; UH3 * v6 = v0->case3.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref3(v0);
            US3 v7;
            v7 = nullable21(v5);
            (v6)->refc++;
            UHDecref3(v5);
            US3 v8;
            v8 = nullable21(v6);
            
            UHDecref3(v6);
            switch (v7.tag) {
                case 0: { // Nullable
                    
                    
                    
                    return US3_Nullable();
                    break;
                }
                default: {
                    
                    
                    switch (v8.tag) {
                        case 0: { // Nullable
                            
                            
                            
                            return US3_Nullable();
                            break;
                        }
                        default: {
                            
                            
                            switch (v7.tag) {
                                default: { // NonNullable
                                    
                                    
                                    
                                    switch (v8.tag) {
                                        default: { // NonNullable
                                            
                                            
                                            
                                            return US3_NonNullable();
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
            UH3 * v16 = v0->case4.v0; UH3 * v17 = v0->case4.v1;
            (v16)->refc += 2; (v17)->refc++;
            UHDecref3(v0);
            US3 v18;
            v18 = nullable21(v16);
            (v17)->refc++;
            UHDecref3(v16);
            US3 v19;
            v19 = nullable21(v17);
            
            UHDecref3(v17);
            switch (v18.tag) {
                case 0: { // Nullable
                    
                    
                    
                    switch (v19.tag) {
                        case 0: { // Nullable
                            
                            
                            
                            return US3_Nullable();
                            break;
                        }
                        default: {
                            
                            
                            return US3_NonNullable();
                        }
                    }
                    break;
                }
                default: {
                    
                    
                    return US3_NonNullable();
                }
            }
            break;
        }
        case 2: { // RegexChar
            
            
            UHDecref3(v0);
            return US3_NonNullable();
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref3(v0);
            return US3_NonNullable();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref3(v0);
            return US3_Nullable();
            break;
        }
        default: { // RegexStar
            
            
            UHDecref3(v0);
            return US3_Nullable();
            break;
        }
    }
}
UH3 * derivative20(UH3 * v0, US1 v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH3 * v25 = v0->case3.v0; UH3 * v26 = v0->case3.v1;
            (v25)->refc += 2; (v26)->refc++;
            UHDecref3(v0);
            UH3 * v27;
            v27 = derivative20(v25, v1);
            (v26)->refc++;
            UHDecref3(v25);
            UH3 * v28;
            v28 = derivative20(v26, v1);
            
            UHDecref3(v26);
            return make_alt14(v27, v28);
            break;
        }
        case 4: { // RegexCat
            UH3 * v30 = v0->case4.v0; UH3 * v31 = v0->case4.v1;
            (v30)->refc += 2; (v31)->refc++;
            UHDecref3(v0);
            US3 v32;
            v32 = nullable21(v30);
            
            
            switch (v32.tag) {
                case 1: { // NonNullable
                    
                    (v30)->refc++;
                    
                    UH3 * v37;
                    v37 = derivative20(v30, v1);
                    
                    UHDecref3(v30);
                    return make_cat17(v37, v31);
                    break;
                }
                default: { // Nullable
                    
                    (v30)->refc++;
                    
                    UH3 * v33;
                    v33 = derivative20(v30, v1);
                    (v31)->refc++; (v33)->refc++;
                    UHDecref3(v30);
                    UH3 * v34;
                    v34 = make_cat17(v33, v31);
                    (v31)->refc++;
                    UHDecref3(v33);
                    UH3 * v35;
                    v35 = derivative20(v31, v1);
                    
                    UHDecref3(v31);
                    return make_alt14(v34, v35);
                    break;
                }
            }
            break;
        }
        case 2: { // RegexChar
            US1 v4 = v0->case2.v0;
            
            UHDecref3(v0);
            US2 v20;
            switch (v4.tag) {
                case 0: { // TriA
                    
                    
                    
                    switch (v1.tag) {
                        case 0: { // TriA
                            
                            
                            
                            v20 = US2_SymbolSame();
                            break;
                        }
                        default: {
                            
                            
                            v20 = US2_SymbolLess();
                        }
                    }
                    break;
                }
                default: {
                    
                    
                    switch (v1.tag) {
                        case 0: { // TriA
                            
                            
                            
                            v20 = US2_SymbolGreater();
                            break;
                        }
                        default: {
                            
                            
                            switch (v4.tag) {
                                case 1: { // TriB
                                    
                                    
                                    
                                    switch (v1.tag) {
                                        case 1: { // TriB
                                            
                                            
                                            
                                            v20 = US2_SymbolSame();
                                            break;
                                        }
                                        default: { // TriC
                                            
                                            
                                            
                                            v20 = US2_SymbolLess();
                                            break;
                                        }
                                    }
                                    break;
                                }
                                default: { // TriC
                                    
                                    
                                    
                                    switch (v1.tag) {
                                        case 1: { // TriB
                                            
                                            
                                            
                                            v20 = US2_SymbolGreater();
                                            break;
                                        }
                                        default: { // TriC
                                            
                                            
                                            
                                            v20 = US2_SymbolSame();
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
            
            
            if (v21){
                
                
                return UH3_RegexEpsilon();
            } else {
                
                
                return UH3_RegexEmpty();
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref3(v0);
            return UH3_RegexEmpty();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref3(v0);
            return UH3_RegexEmpty();
            break;
        }
        default: { // RegexStar
            UH3 * v41 = v0->case5.v0;
            (v41)->refc += 2;
            UHDecref3(v0);
            UH3 * v42;
            v42 = derivative20(v41, v1);
            (v41)->refc++;
            
            UH3 * v43;
            v43 = make_star19(v41);
            
            UHDecref3(v41);
            return make_cat17(v42, v43);
            break;
        }
    }
}
UH3 * canonical_derivative12(UH3 * v0, US1 v1){
    (v0)->refc++;
    
    UH3 * v2;
    v2 = normalize13(v0);
    (v2)->refc++;
    UHDecref3(v0);
    UH3 * v3;
    v3 = derivative20(v2, v1);
    
    UHDecref3(v2);
    return normalize13(v3);
}
bool accepts11(UH3 * v0, UH1 * v1){
    while (1) {
        
        
        switch (v1->tag) {
            case 1: { // InputCons
                US1 v6 = v1->case1.v0; UH1 * v7 = v1->case1.v1;
                (v0)->refc++; (v7)->refc++;
                UHDecref1(v1);
                UH3 * v8;
                v8 = canonical_derivative12(v0, v6);
                
                UHDecref3(v0);
                {
                    UH3 * tmp30 = v8;
                    UH1 * tmp31 = v7;
                    v0 = tmp30;
                    v1 = tmp31;
                }
                continue;
                break;
            }
            default: { // InputEmpty
                
                (v0)->refc++;
                UHDecref1(v1);
                UH3 * v2;
                v2 = normalize13(v0);
                (v2)->refc++;
                UHDecref3(v0);
                US3 v3;
                v3 = nullable21(v2);
                
                UHDecref3(v2);
                switch (v3.tag) {
                    case 1: { // NonNullable
                        
                        
                        
                        return false;
                        break;
                    }
                    default: { // Nullable
                        
                        
                        
                        return true;
                        break;
                    }
                }
                break;
            }
        }
    }
}
static inline void USIncrefBody4(US4 * x){
    switch (x->tag) {
        case 0: {
            (x->case0.v0)->refc++; (x->case0.v1)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody4(US4 * x){
    switch (x->tag) {
        case 0: {
            UHDecref2(x->case0.v0); UHDecref0(x->case0.v1);
            break;
        }
    }
}
void USIncref4(US4 * x){ USIncrefBody4(x); }
void USDecref4(US4 * x){ USDecrefBody4(x); }
US4 US4_BitMatcherRaw(UH2 * v0, UH0 * v1) { // BitMatcherRaw
    US4 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1;
    return x;
}
static inline void USIncrefBody5(US5 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++; (x->case1.v1)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody5(US5 * x){
    switch (x->tag) {
        case 1: {
            UHDecref2(x->case1.v0); UHDecref0(x->case1.v1);
            break;
        }
    }
}
void USIncref5(US5 * x){ USIncrefBody5(x); }
void USDecref5(US5 * x){ USDecrefBody5(x); }
US5 US5_BitMatcherDecided(UH2 * v0, UH0 * v1, bool v2) { // BitMatcherDecided
    US5 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1; x.case1.v2 = v2;
    return x;
}
US5 decide_bit_match22(US4 v0){
    
    
    switch (v0.tag) {
        default: { // BitMatcherRaw
            UH2 * v1 = v0.case0.v0; UH0 * v2 = v0.case0.v1;
            (v1)->refc += 2; (v2)->refc += 2;
            USDecref4(&(v0));
            bool v3;
            v3 = accepts0(v1, v2);
            
            
            return US5_BitMatcherDecided(v1, v2, v3);
            break;
        }
    }
}
bool bit_match_value23(US5 v0){
    
    
    switch (v0.tag) {
        default: { // BitMatcherDecided
            bool v3 = v0.case1.v2;
            
            USDecref5(&(v0));
            return v3;
            break;
        }
    }
}
int32_t main(){
    
    
    US0 v0;
    v0 = US0_BitOne();
    
    
    US0 v1;
    v1 = US0_BitOne();
    
    
    US0 v2;
    v2 = US0_BitZero();
    
    
    UH0 * v3;
    v3 = UH0_InputEmpty();
    (v3)->refc++;
    
    UH0 * v4;
    v4 = UH0_InputCons(v2, v3);
    (v4)->refc++;
    UHDecref0(v3);
    UH0 * v5;
    v5 = UH0_InputCons(v1, v4);
    (v5)->refc++;
    UHDecref0(v4);
    UH0 * v6;
    v6 = UH0_InputCons(v0, v5);
    
    UHDecref0(v5);
    US0 v7;
    v7 = US0_BitOne();
    
    
    US0 v8;
    v8 = US0_BitOne();
    
    
    US0 v9;
    v9 = US0_BitOne();
    
    
    UH0 * v10;
    v10 = UH0_InputEmpty();
    (v10)->refc++;
    
    UH0 * v11;
    v11 = UH0_InputCons(v9, v10);
    (v11)->refc++;
    UHDecref0(v10);
    UH0 * v12;
    v12 = UH0_InputCons(v8, v11);
    (v12)->refc++;
    UHDecref0(v11);
    UH0 * v13;
    v13 = UH0_InputCons(v7, v12);
    
    UHDecref0(v12);
    US1 v14;
    v14 = US1_TriA();
    
    
    US1 v15;
    v15 = US1_TriA();
    
    
    US1 v16;
    v16 = US1_TriA();
    
    
    UH1 * v17;
    v17 = UH1_InputEmpty();
    (v17)->refc++;
    
    UH1 * v18;
    v18 = UH1_InputCons(v16, v17);
    (v18)->refc++;
    UHDecref1(v17);
    UH1 * v19;
    v19 = UH1_InputCons(v15, v18);
    (v19)->refc++;
    UHDecref1(v18);
    UH1 * v20;
    v20 = UH1_InputCons(v14, v19);
    
    UHDecref1(v19);
    US1 v21;
    v21 = US1_TriA();
    
    
    US1 v22;
    v22 = US1_TriA();
    
    
    US1 v23;
    v23 = US1_TriB();
    
    
    UH1 * v24;
    v24 = UH1_InputEmpty();
    (v24)->refc++;
    
    UH1 * v25;
    v25 = UH1_InputCons(v23, v24);
    (v25)->refc++;
    UHDecref1(v24);
    UH1 * v26;
    v26 = UH1_InputCons(v22, v25);
    (v26)->refc++;
    UHDecref1(v25);
    UH1 * v27;
    v27 = UH1_InputCons(v21, v26);
    
    UHDecref1(v26);
    US0 v28;
    v28 = US0_BitZero();
    
    
    UH2 * v29;
    v29 = UH2_RegexChar(v28);
    
    
    US0 v30;
    v30 = US0_BitOne();
    
    
    UH2 * v31;
    v31 = UH2_RegexChar(v30);
    (v29)->refc++; (v31)->refc++;
    
    UH2 * v32;
    v32 = UH2_RegexAlt(v29, v31);
    (v32)->refc++;
    UHDecref2(v29); UHDecref2(v31);
    UH2 * v33;
    v33 = UH2_RegexStar(v32);
    
    UHDecref2(v32);
    US0 v34;
    v34 = US0_BitZero();
    
    
    UH2 * v35;
    v35 = UH2_RegexChar(v34);
    (v33)->refc++; (v35)->refc++;
    
    UH2 * v36;
    v36 = UH2_RegexCat(v33, v35);
    (v6)->refc++; (v36)->refc++;
    UHDecref2(v33); UHDecref2(v35);
    bool v37;
    v37 = accepts0(v36, v6);
    
    UHDecref2(v36);
    
    if (v37){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-expected-true");
        exit(EXIT_FAILURE);
    }
    
    
    US0 v38;
    v38 = US0_BitZero();
    
    
    UH2 * v39;
    v39 = UH2_RegexChar(v38);
    
    
    US0 v40;
    v40 = US0_BitOne();
    
    
    UH2 * v41;
    v41 = UH2_RegexChar(v40);
    (v39)->refc++; (v41)->refc++;
    
    UH2 * v42;
    v42 = UH2_RegexAlt(v39, v41);
    (v42)->refc++;
    UHDecref2(v39); UHDecref2(v41);
    UH2 * v43;
    v43 = UH2_RegexStar(v42);
    
    UHDecref2(v42);
    US0 v44;
    v44 = US0_BitZero();
    
    
    UH2 * v45;
    v45 = UH2_RegexChar(v44);
    (v43)->refc++; (v45)->refc++;
    
    UH2 * v46;
    v46 = UH2_RegexCat(v43, v45);
    (v13)->refc++; (v46)->refc++;
    UHDecref2(v43); UHDecref2(v45);
    bool v47;
    v47 = accepts0(v46, v13);
    
    UHDecref2(v46);
    
    if (v47){
        
        
        fprintf(stderr, "%s\n", "brzozowski-expected-false");
        exit(EXIT_FAILURE);
    } else {
        
        
        
    }
    
    
    US1 v48;
    v48 = US1_TriA();
    
    
    UH3 * v49;
    v49 = UH3_RegexChar(v48);
    (v49)->refc++;
    
    UH3 * v50;
    v50 = UH3_RegexStar(v49);
    (v20)->refc++; (v50)->refc++;
    UHDecref3(v49);
    bool v51;
    v51 = accepts11(v50, v20);
    
    UHDecref1(v20); UHDecref3(v50);
    
    if (v51){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-expected-true");
        exit(EXIT_FAILURE);
    }
    
    
    US1 v52;
    v52 = US1_TriA();
    
    
    UH3 * v53;
    v53 = UH3_RegexChar(v52);
    (v53)->refc++;
    
    UH3 * v54;
    v54 = UH3_RegexStar(v53);
    (v27)->refc++; (v54)->refc++;
    UHDecref3(v53);
    bool v55;
    v55 = accepts11(v54, v27);
    
    UHDecref1(v27); UHDecref3(v54);
    
    if (v55){
        
        
        fprintf(stderr, "%s\n", "brzozowski-expected-false");
        exit(EXIT_FAILURE);
    } else {
        
        
        
    }
    
    
    US0 v56;
    v56 = US0_BitZero();
    
    
    UH2 * v57;
    v57 = UH2_RegexChar(v56);
    
    
    US0 v58;
    v58 = US0_BitOne();
    
    
    UH2 * v59;
    v59 = UH2_RegexChar(v58);
    (v57)->refc++; (v59)->refc++;
    
    UH2 * v60;
    v60 = UH2_RegexAlt(v57, v59);
    (v60)->refc++;
    UHDecref2(v57); UHDecref2(v59);
    UH2 * v61;
    v61 = UH2_RegexStar(v60);
    
    UHDecref2(v60);
    US0 v62;
    v62 = US0_BitZero();
    
    
    UH2 * v63;
    v63 = UH2_RegexChar(v62);
    (v61)->refc++; (v63)->refc++;
    
    UH2 * v64;
    v64 = UH2_RegexCat(v61, v63);
    (v6)->refc++; (v64)->refc++;
    UHDecref2(v61); UHDecref2(v63);
    US4 v65;
    v65 = US4_BitMatcherRaw(v64, v6);
    USIncref4(&(v65));
    UHDecref0(v6); UHDecref2(v64);
    US5 v66;
    v66 = decide_bit_match22(v65);
    
    USDecref4(&(v65));
    US0 v67;
    v67 = US0_BitZero();
    
    
    UH2 * v68;
    v68 = UH2_RegexChar(v67);
    
    
    US0 v69;
    v69 = US0_BitOne();
    
    
    UH2 * v70;
    v70 = UH2_RegexChar(v69);
    (v68)->refc++; (v70)->refc++;
    
    UH2 * v71;
    v71 = UH2_RegexAlt(v68, v70);
    (v71)->refc++;
    UHDecref2(v68); UHDecref2(v70);
    UH2 * v72;
    v72 = UH2_RegexStar(v71);
    
    UHDecref2(v71);
    US0 v73;
    v73 = US0_BitZero();
    
    
    UH2 * v74;
    v74 = UH2_RegexChar(v73);
    (v72)->refc++; (v74)->refc++;
    
    UH2 * v75;
    v75 = UH2_RegexCat(v72, v74);
    (v13)->refc++; (v75)->refc++;
    UHDecref2(v72); UHDecref2(v74);
    US4 v76;
    v76 = US4_BitMatcherRaw(v75, v13);
    USIncref4(&(v76));
    UHDecref0(v13); UHDecref2(v75);
    US5 v77;
    v77 = decide_bit_match22(v76);
    USIncref5(&(v66));
    USDecref4(&(v76));
    bool v78;
    v78 = bit_match_value23(v66);
    
    USDecref5(&(v66));
    
    if (v78){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-expected-true");
        exit(EXIT_FAILURE);
    }
    USIncref5(&(v77));
    
    bool v79;
    v79 = bit_match_value23(v77);
    
    USDecref5(&(v77));
    
    if (v79){
        
        
        fprintf(stderr, "%s\n", "brzozowski-expected-false");
        exit(EXIT_FAILURE);
    } else {
        
        
        
    }
    
    
    return 0l;
}
