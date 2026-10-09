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
        } case2; // RegexChar
        struct {
            UH0 * v0;
            UH0 * v1;
        } case3; // RegexAlt
        struct {
            UH0 * v0;
            UH0 * v1;
        } case4; // RegexCat
        struct {
            UH0 * v0;
        } case5; // RegexStar
    };
};
struct UH1 {
    int refc;
    int tag;
    union {
        struct {
            US0 v0;
            UH1 * v1;
        } case1; // InputCons
    };
};
typedef struct {
    UH1 * v0;
    uint64_t v1;
} Tuple0;
typedef struct {
    int tag;
    union {
    };
} US1;
typedef struct {
    int tag;
    union {
    };
} US2;
struct UH2 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v0;
            UH2 * v1;
        } case1; // RegexListCons
    };
};
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
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
        case 2: {
            USDecref0(&(x->case2.v0));
            break;
        }
        case 3: {
            UHDecref0(x->case3.v0); UHDecref0(x->case3.v1);
            break;
        }
        case 4: {
            UHDecref0(x->case4.v0); UHDecref0(x->case4.v1);
            break;
        }
        case 5: {
            UHDecref0(x->case5.v0);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_RegexEmpty() { // RegexEmpty
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH0 * UH0_RegexEpsilon() { // RegexEpsilon
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
UH0 * UH0_RegexChar(US0 v0) { // RegexChar
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0;
    return x;
}
UH0 * UH0_RegexAlt(UH0 * v0, UH0 * v1) { // RegexAlt
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 3;
    x->refc = 1;
    x->case3.v0 = v0; x->case3.v1 = v1;
    return x;
}
UH0 * UH0_RegexCat(UH0 * v0, UH0 * v1) { // RegexCat
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 4;
    x->refc = 1;
    x->case4.v0 = v0; x->case4.v1 = v1;
    return x;
}
UH0 * UH0_RegexStar(UH0 * v0) { // RegexStar
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 5;
    x->refc = 1;
    x->case5.v0 = v0;
    return x;
}
static inline void UHDecrefBody1(UH1 * x){
    switch (x->tag) {
        case 1: {
            USDecref0(&(x->case1.v0)); UHDecref1(x->case1.v1);
            break;
        }
    }
}
void UHDecref1(UH1 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody1(x); free(x); }
}
UH1 * UH1_InputEmpty() { // InputEmpty
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH1 * UH1_InputCons(US0 v0, UH1 * v1) { // InputCons
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
static inline Tuple0 TupleCreate0(UH1 * v0, uint64_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 random_bit_input1(uint64_t v0, int32_t v1, UH1 * v2){
    
    
    bool v3;
    v3 = 0l < v1;
    
    
    if (v3){
        
        
        uint64_t v4;
        v4 = v0 * 1103515245ull;
        
        
        uint64_t v5;
        v5 = v4 + 12345ull;
        
        
        uint64_t v6;
        v6 = v5 & 2147483647ull;
        
        
        int32_t v7;
        v7 = v1 - 1l;
        
        
        uint64_t v8;
        v8 = v6 >> 16l;
        
        
        uint64_t v9;
        v9 = v8 & 1ull;
        
        
        bool v10;
        v10 = v9 == 0ull;
        
        
        US0 v13;
        if (v10){
            
            
            US0 v11;
            v11 = US0_BitZero();
            
            
            v13 = v11;
        } else {
            
            
            US0 v12;
            v12 = US0_BitOne();
            
            
            v13 = v12;
        }
        v2->refc++; USIncref0(&(v13));
        
        UH1 * v14;
        v14 = UH1_InputCons(v13, v2);
        
        UHDecref1(v2); USDecref0(&(v13));
        return random_bit_input1(v6, v7, v14);
    } else {
        
        
        return TupleCreate0(v2, v0);
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
US1 US1_SymbolLess() { // SymbolLess
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_SymbolSame() { // SymbolSame
    US1 x;
    x.tag = 1;
    return x;
}
US1 US1_SymbolGreater() { // SymbolGreater
    US1 x;
    x.tag = 2;
    return x;
}
US1 regex_compare7(UH0 * v0, UH0 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH0 * v53 = v0->case3.v0; UH0 * v54 = v0->case3.v1;
            v53->refc++; v54->refc++;
            UHDecref0(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    UH0 * v55 = v1->case3.v0; UH0 * v56 = v1->case3.v1;
                    v53->refc++; v55->refc += 2; v56->refc++;
                    UHDecref0(v1);
                    US1 v57;
                    v57 = regex_compare7(v53, v55);
                    
                    UHDecref0(v53); UHDecref0(v55);
                    switch (v57.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref1(&(v57));
                            return regex_compare7(v54, v56);
                            break;
                        }
                        default: {
                            
                            UHDecref0(v54); UHDecref0(v56);
                            return v57;
                        }
                    }
                    break;
                }
                default: {
                    
                    UHDecref0(v1); UHDecref0(v53); UHDecref0(v54);
                    return US1_SymbolGreater();
                }
            }
            break;
        }
        case 4: { // RegexCat
            UH0 * v28 = v0->case4.v0; UH0 * v29 = v0->case4.v1;
            v28->refc++; v29->refc++;
            UHDecref0(v0);
            switch (v1->tag) {
                case 4: { // RegexCat
                    UH0 * v34 = v1->case4.v0; UH0 * v35 = v1->case4.v1;
                    v28->refc++; v34->refc += 2; v35->refc++;
                    UHDecref0(v1);
                    US1 v36;
                    v36 = regex_compare7(v28, v34);
                    
                    UHDecref0(v28); UHDecref0(v34);
                    switch (v36.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref1(&(v36));
                            return regex_compare7(v29, v35);
                            break;
                        }
                        default: {
                            
                            UHDecref0(v29); UHDecref0(v35);
                            return v36;
                        }
                    }
                    break;
                }
                case 2: { // RegexChar
                    
                    
                    UHDecref0(v1); UHDecref0(v28); UHDecref0(v29);
                    return US1_SymbolGreater();
                    break;
                }
                case 0: { // RegexEmpty
                    
                    
                    UHDecref0(v1); UHDecref0(v28); UHDecref0(v29);
                    return US1_SymbolGreater();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref0(v1); UHDecref0(v28); UHDecref0(v29);
                    return US1_SymbolGreater();
                    break;
                }
                default: {
                    
                    UHDecref0(v1); UHDecref0(v28); UHDecref0(v29);
                    return US1_SymbolLess();
                }
            }
            break;
        }
        case 2: { // RegexChar
            US0 v10 = v0->case2.v0;
            USIncref0(&(v10));
            UHDecref0(v0);
            switch (v1->tag) {
                case 2: { // RegexChar
                    US0 v13 = v1->case2.v0;
                    USIncref0(&(v13));
                    UHDecref0(v1);
                    switch (v10.tag) {
                        case 1: { // BitOne
                            
                            
                            USDecref0(&(v10));
                            switch (v13.tag) {
                                case 1: { // BitOne
                                    
                                    
                                    USDecref0(&(v13));
                                    return US1_SymbolSame();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    USDecref0(&(v13));
                                    return US1_SymbolGreater();
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
                                    return US1_SymbolLess();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    USDecref0(&(v13));
                                    return US1_SymbolSame();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
                case 0: { // RegexEmpty
                    
                    
                    UHDecref0(v1); USDecref0(&(v10));
                    return US1_SymbolGreater();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref0(v1); USDecref0(&(v10));
                    return US1_SymbolGreater();
                    break;
                }
                default: {
                    
                    UHDecref0(v1); USDecref0(&(v10));
                    return US1_SymbolLess();
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref0(v1);
                    return US1_SymbolSame();
                    break;
                }
                default: {
                    
                    UHDecref0(v1);
                    return US1_SymbolLess();
                }
            }
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref0(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref0(v1);
                    return US1_SymbolGreater();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref0(v1);
                    return US1_SymbolSame();
                    break;
                }
                default: {
                    
                    UHDecref0(v1);
                    return US1_SymbolLess();
                }
            }
            break;
        }
        case 5: { // RegexStar
            UH0 * v44 = v0->case5.v0;
            v44->refc++;
            UHDecref0(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    
                    
                    UHDecref0(v1); UHDecref0(v44);
                    return US1_SymbolLess();
                    break;
                }
                case 5: { // RegexStar
                    UH0 * v48 = v1->case5.v0;
                    v48->refc++;
                    UHDecref0(v1);
                    return regex_compare7(v44, v48);
                    break;
                }
                default: {
                    
                    UHDecref0(v1); UHDecref0(v44);
                    return US1_SymbolGreater();
                }
            }
            break;
        }
    }
}
UH0 * alt_insert_sorted6(UH0 * v0, UH0 * v1){
    
    
    switch (v1->tag) {
        case 3: { // RegexAlt
            UH0 * v2 = v1->case3.v0; UH0 * v3 = v1->case3.v1;
            v0->refc++; v2->refc += 2; v3->refc++;
            
            US1 v4;
            v4 = regex_compare7(v0, v2);
            
            
            switch (v4.tag) {
                case 2: { // SymbolGreater
                    
                    v0->refc++; v3->refc++;
                    UHDecref0(v1); USDecref1(&(v4));
                    UH0 * v6;
                    v6 = alt_insert_sorted6(v0, v3);
                    
                    UHDecref0(v0); UHDecref0(v3);
                    return UH0_RegexAlt(v2, v6);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    UHDecref0(v2); UHDecref0(v3); USDecref1(&(v4));
                    return UH0_RegexAlt(v0, v1);
                    break;
                }
                case 1: { // SymbolSame
                    
                    
                    UHDecref0(v0); UHDecref0(v2); UHDecref0(v3); USDecref1(&(v4));
                    return v1;
                    break;
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v1);
            return v0;
            break;
        }
        default: {
            v0->refc++; v1->refc++;
            
            US1 v11;
            v11 = regex_compare7(v0, v1);
            
            
            switch (v11.tag) {
                case 2: { // SymbolGreater
                    
                    
                    USDecref1(&(v11));
                    return UH0_RegexAlt(v1, v0);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    USDecref1(&(v11));
                    return UH0_RegexAlt(v0, v1);
                    break;
                }
                case 1: { // SymbolSame
                    
                    
                    UHDecref0(v0); USDecref1(&(v11));
                    return v1;
                    break;
                }
            }
        }
    }
}
UH0 * make_alt5(UH0 * v0, UH0 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH0 * v2 = v0->case3.v0; UH0 * v3 = v0->case3.v1;
            v1->refc++; v2->refc += 2; v3->refc++;
            UHDecref0(v0);
            UH0 * v4;
            v4 = alt_insert_sorted6(v2, v1);
            
            UHDecref0(v1); UHDecref0(v2);
            return make_alt5(v3, v4);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0);
            return v1;
            break;
        }
        default: {
            
            
            return alt_insert_sorted6(v0, v1);
        }
    }
}
bool regex_equal9(UH0 * v0, UH0 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH0 * v18 = v0->case3.v0; UH0 * v19 = v0->case3.v1;
            v18->refc++; v19->refc++;
            UHDecref0(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    UH0 * v20 = v1->case3.v0; UH0 * v21 = v1->case3.v1;
                    v18->refc++; v20->refc += 2; v21->refc++;
                    UHDecref0(v1);
                    bool v22;
                    v22 = regex_equal9(v18, v20);
                    
                    UHDecref0(v18); UHDecref0(v20);
                    if (v22){
                        
                        
                        return regex_equal9(v19, v21);
                    } else {
                        
                        UHDecref0(v19); UHDecref0(v21);
                        return false;
                    }
                    break;
                }
                default: {
                    
                    UHDecref0(v1); UHDecref0(v18); UHDecref0(v19);
                    return false;
                }
            }
            break;
        }
        case 4: { // RegexCat
            UH0 * v26 = v0->case4.v0; UH0 * v27 = v0->case4.v1;
            v26->refc++; v27->refc++;
            UHDecref0(v0);
            switch (v1->tag) {
                case 4: { // RegexCat
                    UH0 * v28 = v1->case4.v0; UH0 * v29 = v1->case4.v1;
                    v26->refc++; v28->refc += 2; v29->refc++;
                    UHDecref0(v1);
                    bool v30;
                    v30 = regex_equal9(v26, v28);
                    
                    UHDecref0(v26); UHDecref0(v28);
                    if (v30){
                        
                        
                        return regex_equal9(v27, v29);
                    } else {
                        
                        UHDecref0(v27); UHDecref0(v29);
                        return false;
                    }
                    break;
                }
                default: {
                    
                    UHDecref0(v1); UHDecref0(v26); UHDecref0(v27);
                    return false;
                }
            }
            break;
        }
        case 2: { // RegexChar
            US0 v4 = v0->case2.v0;
            USIncref0(&(v4));
            UHDecref0(v0);
            switch (v1->tag) {
                case 2: { // RegexChar
                    US0 v5 = v1->case2.v0;
                    USIncref0(&(v5));
                    UHDecref0(v1);
                    US1 v15;
                    switch (v4.tag) {
                        case 1: { // BitOne
                            
                            
                            
                            switch (v5.tag) {
                                case 1: { // BitOne
                                    
                                    
                                    
                                    v15 = US1_SymbolSame();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    
                                    v15 = US1_SymbolGreater();
                                    break;
                                }
                            }
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            
                            switch (v5.tag) {
                                case 1: { // BitOne
                                    
                                    
                                    
                                    v15 = US1_SymbolLess();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    
                                    v15 = US1_SymbolSame();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    
                    USDecref0(&(v4)); USDecref0(&(v5));
                    switch (v15.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref1(&(v15));
                            return true;
                            break;
                        }
                        default: {
                            
                            USDecref1(&(v15));
                            return false;
                        }
                    }
                    break;
                }
                default: {
                    
                    UHDecref0(v1); USDecref0(&(v4));
                    return false;
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref0(v1);
                    return true;
                    break;
                }
                default: {
                    
                    UHDecref0(v1);
                    return false;
                }
            }
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref0(v0);
            switch (v1->tag) {
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref0(v1);
                    return true;
                    break;
                }
                default: {
                    
                    UHDecref0(v1);
                    return false;
                }
            }
            break;
        }
        case 5: { // RegexStar
            UH0 * v34 = v0->case5.v0;
            v34->refc++;
            UHDecref0(v0);
            switch (v1->tag) {
                case 5: { // RegexStar
                    UH0 * v35 = v1->case5.v0;
                    v35->refc++;
                    UHDecref0(v1);
                    return regex_equal9(v34, v35);
                    break;
                }
                default: {
                    
                    UHDecref0(v1); UHDecref0(v34);
                    return false;
                }
            }
            break;
        }
    }
}
UH0 * make_cat8(UH0 * v0, UH0 * v1){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0); UHDecref0(v1);
            return UH0_RegexEmpty();
            break;
        }
        default: {
            
            
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref0(v0); UHDecref0(v1);
                    return UH0_RegexEmpty();
                    break;
                }
                default: {
                    
                    
                    switch (v0->tag) {
                        case 1: { // RegexEpsilon
                            
                            
                            UHDecref0(v0);
                            return v1;
                            break;
                        }
                        default: {
                            
                            
                            switch (v1->tag) {
                                case 1: { // RegexEpsilon
                                    
                                    
                                    UHDecref0(v1);
                                    return v0;
                                    break;
                                }
                                default: {
                                    
                                    
                                    switch (v0->tag) {
                                        case 4: { // RegexCat
                                            UH0 * v12 = v0->case4.v0; UH0 * v13 = v0->case4.v1;
                                            v1->refc++; v12->refc++; v13->refc += 2;
                                            UHDecref0(v0);
                                            UH0 * v14;
                                            v14 = make_cat8(v13, v1);
                                            
                                            UHDecref0(v1); UHDecref0(v13);
                                            return UH0_RegexCat(v12, v14);
                                            break;
                                        }
                                        case 5: { // RegexStar
                                            UH0 * v4 = v0->case5.v0;
                                            v4->refc++;
                                            
                                            switch (v1->tag) {
                                                case 5: { // RegexStar
                                                    UH0 * v5 = v1->case5.v0;
                                                    v4->refc++; v5->refc += 2;
                                                    
                                                    bool v6;
                                                    v6 = regex_equal9(v4, v5);
                                                    
                                                    UHDecref0(v5);
                                                    if (v6){
                                                        
                                                        UHDecref0(v0); UHDecref0(v1);
                                                        return UH0_RegexStar(v4);
                                                    } else {
                                                        
                                                        UHDecref0(v4);
                                                        return UH0_RegexCat(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    
                                                    UHDecref0(v4);
                                                    return UH0_RegexCat(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            
                                            
                                            return UH0_RegexCat(v0, v1);
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
UH0 * make_star10(UH0 * v0){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0);
            return UH0_RegexEpsilon();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref0(v0);
            return UH0_RegexEpsilon();
            break;
        }
        case 5: { // RegexStar
            UH0 * v3 = v0->case5.v0;
            v3->refc++;
            UHDecref0(v0);
            return UH0_RegexStar(v3);
            break;
        }
        default: {
            
            
            return UH0_RegexStar(v0);
        }
    }
}
UH0 * normalize4(UH0 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH0 * v5 = v0->case3.v0; UH0 * v6 = v0->case3.v1;
            v5->refc += 2; v6->refc++;
            UHDecref0(v0);
            UH0 * v7;
            v7 = normalize4(v5);
            v6->refc++;
            UHDecref0(v5);
            UH0 * v8;
            v8 = normalize4(v6);
            
            UHDecref0(v6);
            return make_alt5(v7, v8);
            break;
        }
        case 4: { // RegexCat
            UH0 * v10 = v0->case4.v0; UH0 * v11 = v0->case4.v1;
            v10->refc += 2; v11->refc++;
            UHDecref0(v0);
            UH0 * v12;
            v12 = normalize4(v10);
            v11->refc++;
            UHDecref0(v10);
            UH0 * v13;
            v13 = normalize4(v11);
            
            UHDecref0(v11);
            return make_cat8(v12, v13);
            break;
        }
        case 2: { // RegexChar
            US0 v3 = v0->case2.v0;
            USIncref0(&(v3));
            UHDecref0(v0);
            return UH0_RegexChar(v3);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0);
            return UH0_RegexEmpty();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref0(v0);
            return UH0_RegexEpsilon();
            break;
        }
        case 5: { // RegexStar
            UH0 * v15 = v0->case5.v0;
            v15->refc += 2;
            UHDecref0(v0);
            UH0 * v16;
            v16 = normalize4(v15);
            
            UHDecref0(v15);
            return make_star10(v16);
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
US2 US2_Nullable() { // Nullable
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_NonNullable() { // NonNullable
    US2 x;
    x.tag = 1;
    return x;
}
US2 nullable12(UH0 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH0 * v5 = v0->case3.v0; UH0 * v6 = v0->case3.v1;
            v5->refc += 2; v6->refc++;
            UHDecref0(v0);
            US2 v7;
            v7 = nullable12(v5);
            v6->refc++;
            UHDecref0(v5);
            US2 v8;
            v8 = nullable12(v6);
            
            UHDecref0(v6);
            switch (v7.tag) {
                case 0: { // Nullable
                    
                    
                    USDecref2(&(v7)); USDecref2(&(v8));
                    return US2_Nullable();
                    break;
                }
                default: {
                    
                    
                    switch (v8.tag) {
                        case 0: { // Nullable
                            
                            
                            USDecref2(&(v7)); USDecref2(&(v8));
                            return US2_Nullable();
                            break;
                        }
                        default: {
                            
                            
                            switch (v7.tag) {
                                case 1: { // NonNullable
                                    
                                    
                                    USDecref2(&(v7));
                                    switch (v8.tag) {
                                        case 1: { // NonNullable
                                            
                                            
                                            USDecref2(&(v8));
                                            return US2_NonNullable();
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
            UH0 * v16 = v0->case4.v0; UH0 * v17 = v0->case4.v1;
            v16->refc += 2; v17->refc++;
            UHDecref0(v0);
            US2 v18;
            v18 = nullable12(v16);
            v17->refc++;
            UHDecref0(v16);
            US2 v19;
            v19 = nullable12(v17);
            
            UHDecref0(v17);
            switch (v18.tag) {
                case 0: { // Nullable
                    
                    
                    USDecref2(&(v18));
                    switch (v19.tag) {
                        case 0: { // Nullable
                            
                            
                            USDecref2(&(v19));
                            return US2_Nullable();
                            break;
                        }
                        default: {
                            
                            USDecref2(&(v19));
                            return US2_NonNullable();
                        }
                    }
                    break;
                }
                default: {
                    
                    USDecref2(&(v18)); USDecref2(&(v19));
                    return US2_NonNullable();
                }
            }
            break;
        }
        case 2: { // RegexChar
            
            
            UHDecref0(v0);
            return US2_NonNullable();
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0);
            return US2_NonNullable();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref0(v0);
            return US2_Nullable();
            break;
        }
        case 5: { // RegexStar
            
            
            UHDecref0(v0);
            return US2_Nullable();
            break;
        }
    }
}
UH0 * derivative11(UH0 * v0, US0 v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH0 * v19 = v0->case3.v0; UH0 * v20 = v0->case3.v1;
            USIncref0(&(v1)); v19->refc += 2; v20->refc++;
            UHDecref0(v0);
            UH0 * v21;
            v21 = derivative11(v19, v1);
            USIncref0(&(v1)); v20->refc++;
            UHDecref0(v19);
            UH0 * v22;
            v22 = derivative11(v20, v1);
            
            USDecref0(&(v1)); UHDecref0(v20);
            return make_alt5(v21, v22);
            break;
        }
        case 4: { // RegexCat
            UH0 * v24 = v0->case4.v0; UH0 * v25 = v0->case4.v1;
            v24->refc += 2; v25->refc++;
            UHDecref0(v0);
            US2 v26;
            v26 = nullable12(v24);
            
            
            switch (v26.tag) {
                case 1: { // NonNullable
                    
                    USIncref0(&(v1)); v24->refc++;
                    USDecref2(&(v26));
                    UH0 * v31;
                    v31 = derivative11(v24, v1);
                    
                    USDecref0(&(v1)); UHDecref0(v24);
                    return make_cat8(v31, v25);
                    break;
                }
                case 0: { // Nullable
                    
                    USIncref0(&(v1)); v24->refc++;
                    USDecref2(&(v26));
                    UH0 * v27;
                    v27 = derivative11(v24, v1);
                    v25->refc++; v27->refc++;
                    UHDecref0(v24);
                    UH0 * v28;
                    v28 = make_cat8(v27, v25);
                    USIncref0(&(v1)); v25->refc++;
                    UHDecref0(v27);
                    UH0 * v29;
                    v29 = derivative11(v25, v1);
                    
                    USDecref0(&(v1)); UHDecref0(v25);
                    return make_alt5(v28, v29);
                    break;
                }
            }
            break;
        }
        case 2: { // RegexChar
            US0 v4 = v0->case2.v0;
            USIncref0(&(v4));
            UHDecref0(v0);
            US1 v14;
            switch (v4.tag) {
                case 1: { // BitOne
                    
                    
                    
                    switch (v1.tag) {
                        case 1: { // BitOne
                            
                            
                            
                            v14 = US1_SymbolSame();
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            
                            v14 = US1_SymbolGreater();
                            break;
                        }
                    }
                    break;
                }
                case 0: { // BitZero
                    
                    
                    
                    switch (v1.tag) {
                        case 1: { // BitOne
                            
                            
                            
                            v14 = US1_SymbolLess();
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            
                            v14 = US1_SymbolSame();
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
            
            USDecref1(&(v14));
            if (v15){
                
                
                return UH0_RegexEpsilon();
            } else {
                
                
                return UH0_RegexEmpty();
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0); USDecref0(&(v1));
            return UH0_RegexEmpty();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref0(v0); USDecref0(&(v1));
            return UH0_RegexEmpty();
            break;
        }
        case 5: { // RegexStar
            UH0 * v35 = v0->case5.v0;
            USIncref0(&(v1)); v35->refc += 2;
            UHDecref0(v0);
            UH0 * v36;
            v36 = derivative11(v35, v1);
            v35->refc++;
            USDecref0(&(v1));
            UH0 * v37;
            v37 = make_star10(v35);
            
            UHDecref0(v35);
            return make_cat8(v36, v37);
            break;
        }
    }
}
UH0 * canonical_derivative3(UH0 * v0, US0 v1){
    v0->refc++;
    
    UH0 * v2;
    v2 = normalize4(v0);
    USIncref0(&(v1)); v2->refc++;
    UHDecref0(v0);
    UH0 * v3;
    v3 = derivative11(v2, v1);
    
    USDecref0(&(v1)); UHDecref0(v2);
    return normalize4(v3);
}
bool accepts2(UH0 * v0, UH1 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US0 v6 = v1->case1.v0; UH1 * v7 = v1->case1.v1;
            v0->refc++; USIncref0(&(v6));USIncref0(&(v6)); v7->refc++;
            UHDecref1(v1);
            UH0 * v8;
            v8 = canonical_derivative3(v0, v6);
            
            UHDecref0(v0); USDecref0(&(v6));
            return accepts2(v8, v7);
            break;
        }
        case 0: { // InputEmpty
            
            v0->refc++;
            UHDecref1(v1);
            UH0 * v2;
            v2 = normalize4(v0);
            v2->refc++;
            UHDecref0(v0);
            US2 v3;
            v3 = nullable12(v2);
            
            UHDecref0(v2);
            switch (v3.tag) {
                case 1: { // NonNullable
                    
                    
                    USDecref2(&(v3));
                    return false;
                    break;
                }
                case 0: { // Nullable
                    
                    
                    USDecref2(&(v3));
                    return true;
                    break;
                }
            }
            break;
        }
    }
}
int32_t loop0(UH0 * v0, int32_t v1, int32_t v2, uint64_t v3, int32_t v4){
    
    
    bool v5;
    v5 = 0l < v2;
    
    
    if (v5){
        
        
        UH1 * v6;
        v6 = UH1_InputEmpty();
        v6->refc++;
        
        UH1 * v7; uint64_t v8;
        Tuple0 tmp0 = random_bit_input1(v3, v1, v6);
        v7 = tmp0.v0; v8 = tmp0.v1;
        v0->refc++; v7->refc++;
        UHDecref1(v6);
        bool v9;
        v9 = accepts2(v0, v7);
        
        UHDecref1(v7);
        int32_t v11;
        if (v9){
            
            
            int32_t v10;
            v10 = v4 + 1l;
            
            
            v11 = v10;
        } else {
            
            
            v11 = v4;
        }
        
        
        int32_t v12;
        v12 = v2 - 1l;
        
        
        return loop0(v0, v1, v12, v8, v11);
    } else {
        
        UHDecref0(v0);
        return v4;
    }
}
UH1 * zeros_input14(int32_t v0, UH1 * v1){
    
    
    bool v2;
    v2 = 0l < v0;
    
    
    if (v2){
        
        
        int32_t v3;
        v3 = v0 - 1l;
        
        
        US0 v4;
        v4 = US0_BitZero();
        v1->refc++; USIncref0(&(v4));
        
        UH1 * v5;
        v5 = UH1_InputCons(v4, v1);
        
        UHDecref1(v1); USDecref0(&(v4));
        return zeros_input14(v3, v5);
    } else {
        
        
        return v1;
    }
}
int32_t loop13(UH0 * v0, int32_t v1, int32_t v2, int32_t v3){
    
    
    bool v4;
    v4 = v1 < v2;
    
    
    if (v4){
        
        UHDecref0(v0);
        return v3;
    } else {
        
        
        UH1 * v5;
        v5 = UH1_InputEmpty();
        v5->refc++;
        
        UH1 * v6;
        v6 = zeros_input14(v2, v5);
        v0->refc++; v6->refc++;
        UHDecref1(v5);
        bool v7;
        v7 = accepts2(v0, v6);
        
        UHDecref1(v6);
        int32_t v9;
        if (v7){
            
            
            int32_t v8;
            v8 = v3 + 1l;
            
            
            v9 = v8;
        } else {
            
            
            v9 = v3;
        }
        
        
        US0 v10;
        v10 = US0_BitOne();
        
        
        UH1 * v11;
        v11 = UH1_InputEmpty();
        USIncref0(&(v10)); v11->refc++;
        
        UH1 * v12;
        v12 = UH1_InputCons(v10, v11);
        v12->refc++;
        USDecref0(&(v10)); UHDecref1(v11);
        UH1 * v13;
        v13 = zeros_input14(v2, v12);
        v0->refc++; v13->refc++;
        UHDecref1(v12);
        bool v14;
        v14 = accepts2(v0, v13);
        
        UHDecref1(v13);
        int32_t v16;
        if (v14){
            
            
            int32_t v15;
            v15 = v9 + 1l;
            
            
            v16 = v15;
        } else {
            
            
            v16 = v9;
        }
        
        
        int32_t v17;
        v17 = v2 + 1l;
        
        
        return loop13(v0, v1, v17, v16);
    }
}
static inline void UHDecrefBody2(UH2 * x){
    switch (x->tag) {
        case 1: {
            UHDecref0(x->case1.v0); UHDecref2(x->case1.v1);
            break;
        }
    }
}
void UHDecref2(UH2 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody2(x); free(x); }
}
UH2 * UH2_RegexListNil() { // RegexListNil
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH2 * UH2_RegexListCons(UH0 * v0, UH2 * v1) { // RegexListCons
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
bool backtrack_stack16(UH2 * v0, UH1 * v1){
    
    
    switch (v0->tag) {
        case 1: { // RegexListCons
            UH0 * v6 = v0->case1.v0; UH2 * v7 = v0->case1.v1;
            v6->refc++; v7->refc++;
            
            switch (v6->tag) {
                case 3: { // RegexAlt
                    UH0 * v27 = v6->case3.v0; UH0 * v28 = v6->case3.v1;
                    v7->refc++; v27->refc += 2; v28->refc++;
                    UHDecref2(v0); UHDecref0(v6);
                    UH2 * v29;
                    v29 = UH2_RegexListCons(v27, v7);
                    v1->refc++; v29->refc++;
                    UHDecref0(v27);
                    bool v30;
                    v30 = backtrack_stack16(v29, v1);
                    
                    UHDecref2(v29);
                    if (v30){
                        
                        UHDecref1(v1); UHDecref2(v7); UHDecref0(v28);
                        return true;
                    } else {
                        v7->refc++; v28->refc++;
                        
                        UH2 * v31;
                        v31 = UH2_RegexListCons(v28, v7);
                        
                        UHDecref2(v7); UHDecref0(v28);
                        return backtrack_stack16(v31, v1);
                    }
                    break;
                }
                case 4: { // RegexCat
                    UH0 * v34 = v6->case4.v0; UH0 * v35 = v6->case4.v1;
                    v7->refc++; v34->refc++; v35->refc += 2;
                    UHDecref2(v0); UHDecref0(v6);
                    UH2 * v36;
                    v36 = UH2_RegexListCons(v35, v7);
                    v34->refc++; v36->refc++;
                    UHDecref2(v7); UHDecref0(v35);
                    UH2 * v37;
                    v37 = UH2_RegexListCons(v34, v36);
                    
                    UHDecref0(v34); UHDecref2(v36);
                    return backtrack_stack16(v37, v1);
                    break;
                }
                case 2: { // RegexChar
                    US0 v9 = v6->case2.v0;
                    USIncref0(&(v9));
                    UHDecref2(v0); UHDecref0(v6);
                    switch (v1->tag) {
                        case 1: { // InputCons
                            US0 v10 = v1->case1.v0; UH1 * v11 = v1->case1.v1;
                            USIncref0(&(v10)); v11->refc++;
                            UHDecref1(v1);
                            US1 v21;
                            switch (v9.tag) {
                                case 1: { // BitOne
                                    
                                    
                                    
                                    switch (v10.tag) {
                                        case 1: { // BitOne
                                            
                                            
                                            
                                            v21 = US1_SymbolSame();
                                            break;
                                        }
                                        case 0: { // BitZero
                                            
                                            
                                            
                                            v21 = US1_SymbolGreater();
                                            break;
                                        }
                                    }
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    
                                    switch (v10.tag) {
                                        case 1: { // BitOne
                                            
                                            
                                            
                                            v21 = US1_SymbolLess();
                                            break;
                                        }
                                        case 0: { // BitZero
                                            
                                            
                                            
                                            v21 = US1_SymbolSame();
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            
                            USDecref0(&(v9)); USDecref0(&(v10));
                            bool v22;
                            switch (v21.tag) {
                                case 1: { // SymbolSame
                                    
                                    
                                    
                                    v22 = true;
                                    break;
                                }
                                default: {
                                    
                                    
                                    v22 = false;
                                }
                            }
                            
                            USDecref1(&(v21));
                            if (v22){
                                
                                
                                return backtrack_stack16(v7, v11);
                            } else {
                                
                                UHDecref2(v7); UHDecref1(v11);
                                return false;
                            }
                            break;
                        }
                        case 0: { // InputEmpty
                            
                            
                            UHDecref1(v1); UHDecref2(v7); USDecref0(&(v9));
                            return false;
                            break;
                        }
                    }
                    break;
                }
                case 0: { // RegexEmpty
                    
                    
                    UHDecref2(v0); UHDecref1(v1); UHDecref0(v6); UHDecref2(v7);
                    return false;
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref2(v0); UHDecref0(v6);
                    return backtrack_stack16(v7, v1);
                    break;
                }
                case 5: { // RegexStar
                    UH0 * v39 = v6->case5.v0;
                    v0->refc++; v39->refc += 2;
                    UHDecref0(v6);
                    UH2 * v40;
                    v40 = UH2_RegexListCons(v39, v0);
                    v1->refc++; v40->refc++;
                    UHDecref2(v0); UHDecref0(v39);
                    bool v41;
                    v41 = backtrack_stack16(v40, v1);
                    
                    UHDecref2(v40);
                    if (v41){
                        
                        UHDecref1(v1); UHDecref2(v7);
                        return true;
                    } else {
                        
                        
                        return backtrack_stack16(v7, v1);
                    }
                    break;
                }
            }
            break;
        }
        case 0: { // RegexListNil
            
            
            UHDecref2(v0);
            switch (v1->tag) {
                case 1: { // InputCons
                    
                    
                    UHDecref1(v1);
                    return false;
                    break;
                }
                case 0: { // InputEmpty
                    
                    
                    UHDecref1(v1);
                    return true;
                    break;
                }
            }
            break;
        }
    }
}
int32_t loop15(UH0 * v0, int32_t v1, int32_t v2, uint64_t v3, int32_t v4){
    
    
    bool v5;
    v5 = 0l < v2;
    
    
    if (v5){
        
        
        UH1 * v6;
        v6 = UH1_InputEmpty();
        v6->refc++;
        
        UH1 * v7; uint64_t v8;
        Tuple0 tmp1 = random_bit_input1(v3, v1, v6);
        v7 = tmp1.v0; v8 = tmp1.v1;
        
        UHDecref1(v6);
        UH2 * v9;
        v9 = UH2_RegexListNil();
        v0->refc++; v9->refc++;
        
        UH2 * v10;
        v10 = UH2_RegexListCons(v0, v9);
        v7->refc++; v10->refc++;
        UHDecref2(v9);
        bool v11;
        v11 = backtrack_stack16(v10, v7);
        
        UHDecref1(v7); UHDecref2(v10);
        int32_t v13;
        if (v11){
            
            
            int32_t v12;
            v12 = v4 + 1l;
            
            
            v13 = v12;
        } else {
            
            
            v13 = v4;
        }
        
        
        int32_t v14;
        v14 = v2 - 1l;
        
        
        return loop15(v0, v1, v14, v8, v13);
    } else {
        
        UHDecref0(v0);
        return v4;
    }
}
int32_t loop17(UH0 * v0, int32_t v1, int32_t v2, int32_t v3){
    
    
    bool v4;
    v4 = v1 < v2;
    
    
    if (v4){
        
        UHDecref0(v0);
        return v3;
    } else {
        
        
        UH1 * v5;
        v5 = UH1_InputEmpty();
        v5->refc++;
        
        UH1 * v6;
        v6 = zeros_input14(v2, v5);
        
        UHDecref1(v5);
        UH2 * v7;
        v7 = UH2_RegexListNil();
        v0->refc++; v7->refc++;
        
        UH2 * v8;
        v8 = UH2_RegexListCons(v0, v7);
        v6->refc++; v8->refc++;
        UHDecref2(v7);
        bool v9;
        v9 = backtrack_stack16(v8, v6);
        
        UHDecref1(v6); UHDecref2(v8);
        int32_t v11;
        if (v9){
            
            
            int32_t v10;
            v10 = v3 + 1l;
            
            
            v11 = v10;
        } else {
            
            
            v11 = v3;
        }
        
        
        US0 v12;
        v12 = US0_BitOne();
        
        
        UH1 * v13;
        v13 = UH1_InputEmpty();
        USIncref0(&(v12)); v13->refc++;
        
        UH1 * v14;
        v14 = UH1_InputCons(v12, v13);
        v14->refc++;
        USDecref0(&(v12)); UHDecref1(v13);
        UH1 * v15;
        v15 = zeros_input14(v2, v14);
        
        UHDecref1(v14);
        UH2 * v16;
        v16 = UH2_RegexListNil();
        v0->refc++; v16->refc++;
        
        UH2 * v17;
        v17 = UH2_RegexListCons(v0, v16);
        v15->refc++; v17->refc++;
        UHDecref2(v16);
        bool v18;
        v18 = backtrack_stack16(v17, v15);
        
        UHDecref1(v15); UHDecref2(v17);
        int32_t v20;
        if (v18){
            
            
            int32_t v19;
            v19 = v11 + 1l;
            
            
            v20 = v19;
        } else {
            
            
            v20 = v11;
        }
        
        
        int32_t v21;
        v21 = v2 + 1l;
        
        
        return loop17(v0, v1, v21, v20);
    }
}
bool run19(int32_t v0, UH1 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US0 v3 = v1->case1.v0; UH1 * v4 = v1->case1.v1;
            USIncref0(&(v3)); v4->refc++;
            UHDecref1(v1);
            switch (v3.tag) {
                case 1: { // BitOne
                    
                    
                    USDecref0(&(v3));
                    bool v8;
                    v8 = v0 == 0l;
                    
                    
                    int32_t v9;
                    v9 = 0l;
                    
                    
                    return run19(v9, v4);
                    break;
                }
                case 0: { // BitZero
                    
                    
                    USDecref0(&(v3));
                    bool v5;
                    v5 = v0 == 0l;
                    
                    
                    int32_t v6;
                    v6 = 1l;
                    
                    
                    return run19(v6, v4);
                    break;
                }
            }
            break;
        }
        case 0: { // InputEmpty
            
            
            UHDecref1(v1);
            bool v2;
            v2 = v0 == 1l;
            
            
            return v2;
            break;
        }
    }
}
int32_t loop18(int32_t v0, int32_t v1, uint64_t v2, int32_t v3){
    
    
    bool v4;
    v4 = 0l < v1;
    
    
    if (v4){
        
        
        UH1 * v5;
        v5 = UH1_InputEmpty();
        v5->refc++;
        
        UH1 * v6; uint64_t v7;
        Tuple0 tmp2 = random_bit_input1(v2, v0, v5);
        v6 = tmp2.v0; v7 = tmp2.v1;
        
        UHDecref1(v5);
        int32_t v8;
        v8 = 0l;
        v6->refc++;
        
        bool v9;
        v9 = run19(v8, v6);
        
        UHDecref1(v6);
        int32_t v11;
        if (v9){
            
            
            int32_t v10;
            v10 = v3 + 1l;
            
            
            v11 = v10;
        } else {
            
            
            v11 = v3;
        }
        
        
        int32_t v12;
        v12 = v1 - 1l;
        
        
        return loop18(v0, v12, v7, v11);
    } else {
        
        
        return v3;
    }
}
bool run21(int32_t v0, UH1 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US0 v17 = v1->case1.v0; UH1 * v18 = v1->case1.v1;
            USIncref0(&(v17)); v18->refc++;
            UHDecref1(v1);
            switch (v17.tag) {
                case 1: { // BitOne
                    
                    
                    USDecref0(&(v17));
                    bool v50;
                    v50 = v0 == 0l;
                    
                    
                    int32_t v79;
                    if (v50){
                        
                        
                        v79 = 1l;
                    } else {
                        
                        
                        bool v51;
                        v51 = v0 == 1l;
                        
                        
                        if (v51){
                            
                            
                            v79 = 6l;
                        } else {
                            
                            
                            bool v52;
                            v52 = v0 == 2l;
                            
                            
                            if (v52){
                                
                                
                                v79 = 11l;
                            } else {
                                
                                
                                bool v53;
                                v53 = v0 == 3l;
                                
                                
                                if (v53){
                                    
                                    
                                    v79 = 5l;
                                } else {
                                    
                                    
                                    bool v54;
                                    v54 = v0 == 4l;
                                    
                                    
                                    if (v54){
                                        
                                        
                                        v79 = 1l;
                                    } else {
                                        
                                        
                                        bool v55;
                                        v55 = v0 == 5l;
                                        
                                        
                                        if (v55){
                                            
                                            
                                            v79 = 6l;
                                        } else {
                                            
                                            
                                            bool v56;
                                            v56 = v0 == 6l;
                                            
                                            
                                            if (v56){
                                                
                                                
                                                v79 = 13l;
                                            } else {
                                                
                                                
                                                bool v57;
                                                v57 = v0 == 7l;
                                                
                                                
                                                if (v57){
                                                    
                                                    
                                                    v79 = 9l;
                                                } else {
                                                    
                                                    
                                                    bool v58;
                                                    v58 = v0 == 8l;
                                                    
                                                    
                                                    if (v58){
                                                        
                                                        
                                                        v79 = 5l;
                                                    } else {
                                                        
                                                        
                                                        bool v59;
                                                        v59 = v0 == 9l;
                                                        
                                                        
                                                        if (v59){
                                                            
                                                            
                                                            v79 = 12l;
                                                        } else {
                                                            
                                                            
                                                            bool v60;
                                                            v60 = v0 == 10l;
                                                            
                                                            
                                                            if (v60){
                                                                
                                                                
                                                                v79 = 11l;
                                                            } else {
                                                                
                                                                
                                                                bool v61;
                                                                v61 = v0 == 11l;
                                                                
                                                                
                                                                if (v61){
                                                                    
                                                                    
                                                                    v79 = 12l;
                                                                } else {
                                                                    
                                                                    
                                                                    bool v62;
                                                                    v62 = v0 == 12l;
                                                                    
                                                                    
                                                                    if (v62){
                                                                        
                                                                        
                                                                        v79 = 13l;
                                                                    } else {
                                                                        
                                                                        
                                                                        bool v63;
                                                                        v63 = v0 == 13l;
                                                                        
                                                                        
                                                                        if (v63){
                                                                            
                                                                            
                                                                            v79 = 15l;
                                                                        } else {
                                                                            
                                                                            
                                                                            bool v64;
                                                                            v64 = v0 == 14l;
                                                                            
                                                                            
                                                                            if (v64){
                                                                                
                                                                                
                                                                                v79 = 9l;
                                                                            } else {
                                                                                
                                                                                
                                                                                v79 = 15l;
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
                                }
                            }
                        }
                    }
                    
                    
                    return run21(v79, v18);
                    break;
                }
                case 0: { // BitZero
                    
                    
                    USDecref0(&(v17));
                    bool v19;
                    v19 = v0 == 0l;
                    
                    
                    int32_t v48;
                    if (v19){
                        
                        
                        v48 = 0l;
                    } else {
                        
                        
                        bool v20;
                        v20 = v0 == 1l;
                        
                        
                        if (v20){
                            
                            
                            v48 = 2l;
                        } else {
                            
                            
                            bool v21;
                            v21 = v0 == 2l;
                            
                            
                            if (v21){
                                
                                
                                v48 = 3l;
                            } else {
                                
                                
                                bool v22;
                                v22 = v0 == 3l;
                                
                                
                                if (v22){
                                    
                                    
                                    v48 = 4l;
                                } else {
                                    
                                    
                                    bool v23;
                                    v23 = v0 == 4l;
                                    
                                    
                                    if (v23){
                                        
                                        
                                        v48 = 0l;
                                    } else {
                                        
                                        
                                        bool v24;
                                        v24 = v0 == 5l;
                                        
                                        
                                        if (v24){
                                            
                                            
                                            v48 = 2l;
                                        } else {
                                            
                                            
                                            bool v25;
                                            v25 = v0 == 6l;
                                            
                                            
                                            if (v25){
                                                
                                                
                                                v48 = 7l;
                                            } else {
                                                
                                                
                                                bool v26;
                                                v26 = v0 == 7l;
                                                
                                                
                                                if (v26){
                                                    
                                                    
                                                    v48 = 8l;
                                                } else {
                                                    
                                                    
                                                    bool v27;
                                                    v27 = v0 == 8l;
                                                    
                                                    
                                                    if (v27){
                                                        
                                                        
                                                        v48 = 4l;
                                                    } else {
                                                        
                                                        
                                                        bool v28;
                                                        v28 = v0 == 9l;
                                                        
                                                        
                                                        if (v28){
                                                            
                                                            
                                                            v48 = 10l;
                                                        } else {
                                                            
                                                            
                                                            bool v29;
                                                            v29 = v0 == 10l;
                                                            
                                                            
                                                            if (v29){
                                                                
                                                                
                                                                v48 = 3l;
                                                            } else {
                                                                
                                                                
                                                                bool v30;
                                                                v30 = v0 == 11l;
                                                                
                                                                
                                                                if (v30){
                                                                    
                                                                    
                                                                    v48 = 10l;
                                                                } else {
                                                                    
                                                                    
                                                                    bool v31;
                                                                    v31 = v0 == 12l;
                                                                    
                                                                    
                                                                    if (v31){
                                                                        
                                                                        
                                                                        v48 = 7l;
                                                                    } else {
                                                                        
                                                                        
                                                                        bool v32;
                                                                        v32 = v0 == 13l;
                                                                        
                                                                        
                                                                        if (v32){
                                                                            
                                                                            
                                                                            v48 = 14l;
                                                                        } else {
                                                                            
                                                                            
                                                                            bool v33;
                                                                            v33 = v0 == 14l;
                                                                            
                                                                            
                                                                            if (v33){
                                                                                
                                                                                
                                                                                v48 = 8l;
                                                                            } else {
                                                                                
                                                                                
                                                                                v48 = 14l;
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
                                }
                            }
                        }
                    }
                    
                    
                    return run21(v48, v18);
                    break;
                }
            }
            break;
        }
        case 0: { // InputEmpty
            
            
            UHDecref1(v1);
            bool v2;
            v2 = v0 == 4l;
            
            
            if (v2){
                
                
                return true;
            } else {
                
                
                bool v3;
                v3 = v0 == 5l;
                
                
                if (v3){
                    
                    
                    return true;
                } else {
                    
                    
                    bool v4;
                    v4 = v0 == 8l;
                    
                    
                    if (v4){
                        
                        
                        return true;
                    } else {
                        
                        
                        bool v5;
                        v5 = v0 == 9l;
                        
                        
                        if (v5){
                            
                            
                            return true;
                        } else {
                            
                            
                            bool v6;
                            v6 = v0 == 10l;
                            
                            
                            if (v6){
                                
                                
                                return true;
                            } else {
                                
                                
                                bool v7;
                                v7 = v0 == 12l;
                                
                                
                                if (v7){
                                    
                                    
                                    return true;
                                } else {
                                    
                                    
                                    bool v8;
                                    v8 = v0 == 14l;
                                    
                                    
                                    if (v8){
                                        
                                        
                                        return true;
                                    } else {
                                        
                                        
                                        bool v9;
                                        v9 = v0 == 15l;
                                        
                                        
                                        return v9;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            break;
        }
    }
}
int32_t loop20(int32_t v0, int32_t v1, uint64_t v2, int32_t v3){
    
    
    bool v4;
    v4 = 0l < v1;
    
    
    if (v4){
        
        
        UH1 * v5;
        v5 = UH1_InputEmpty();
        v5->refc++;
        
        UH1 * v6; uint64_t v7;
        Tuple0 tmp3 = random_bit_input1(v2, v0, v5);
        v6 = tmp3.v0; v7 = tmp3.v1;
        
        UHDecref1(v5);
        int32_t v8;
        v8 = 0l;
        v6->refc++;
        
        bool v9;
        v9 = run21(v8, v6);
        
        UHDecref1(v6);
        int32_t v11;
        if (v9){
            
            
            int32_t v10;
            v10 = v3 + 1l;
            
            
            v11 = v10;
        } else {
            
            
            v11 = v3;
        }
        
        
        int32_t v12;
        v12 = v1 - 1l;
        
        
        return loop20(v0, v12, v7, v11);
    } else {
        
        
        return v3;
    }
}
bool run23(int32_t v0, UH1 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US0 v3 = v1->case1.v0; UH1 * v4 = v1->case1.v1;
            USIncref0(&(v3)); v4->refc++;
            UHDecref1(v1);
            switch (v3.tag) {
                case 1: { // BitOne
                    
                    
                    USDecref0(&(v3));
                    bool v13;
                    v13 = v0 == 0l;
                    
                    
                    int32_t v19;
                    if (v13){
                        
                        
                        v19 = 3l;
                    } else {
                        
                        
                        bool v14;
                        v14 = v0 == 1l;
                        
                        
                        if (v14){
                            
                            
                            v19 = 3l;
                        } else {
                            
                            
                            bool v15;
                            v15 = v0 == 2l;
                            
                            
                            if (v15){
                                
                                
                                v19 = 3l;
                            } else {
                                
                                
                                bool v16;
                                v16 = v0 == 3l;
                                
                                
                                v19 = 4l;
                            }
                        }
                    }
                    
                    
                    return run23(v19, v4);
                    break;
                }
                case 0: { // BitZero
                    
                    
                    USDecref0(&(v3));
                    bool v5;
                    v5 = v0 == 0l;
                    
                    
                    int32_t v11;
                    if (v5){
                        
                        
                        v11 = 1l;
                    } else {
                        
                        
                        bool v6;
                        v6 = v0 == 1l;
                        
                        
                        if (v6){
                            
                            
                            v11 = 2l;
                        } else {
                            
                            
                            bool v7;
                            v7 = v0 == 2l;
                            
                            
                            if (v7){
                                
                                
                                v11 = 2l;
                            } else {
                                
                                
                                bool v8;
                                v8 = v0 == 3l;
                                
                                
                                v11 = 4l;
                            }
                        }
                    }
                    
                    
                    return run23(v11, v4);
                    break;
                }
            }
            break;
        }
        case 0: { // InputEmpty
            
            
            UHDecref1(v1);
            bool v2;
            v2 = v0 == 3l;
            
            
            return v2;
            break;
        }
    }
}
int32_t loop22(int32_t v0, int32_t v1, int32_t v2){
    
    
    bool v3;
    v3 = v0 < v1;
    
    
    if (v3){
        
        
        return v2;
    } else {
        
        
        UH1 * v4;
        v4 = UH1_InputEmpty();
        v4->refc++;
        
        UH1 * v5;
        v5 = zeros_input14(v1, v4);
        
        UHDecref1(v4);
        int32_t v6;
        v6 = 0l;
        v5->refc++;
        
        bool v7;
        v7 = run23(v6, v5);
        
        UHDecref1(v5);
        int32_t v9;
        if (v7){
            
            
            int32_t v8;
            v8 = v2 + 1l;
            
            
            v9 = v8;
        } else {
            
            
            v9 = v2;
        }
        
        
        US0 v10;
        v10 = US0_BitOne();
        
        
        UH1 * v11;
        v11 = UH1_InputEmpty();
        USIncref0(&(v10)); v11->refc++;
        
        UH1 * v12;
        v12 = UH1_InputCons(v10, v11);
        v12->refc++;
        USDecref0(&(v10)); UHDecref1(v11);
        UH1 * v13;
        v13 = zeros_input14(v1, v12);
        
        UHDecref1(v12);
        int32_t v14;
        v14 = 0l;
        v13->refc++;
        
        bool v15;
        v15 = run23(v14, v13);
        
        UHDecref1(v13);
        int32_t v17;
        if (v15){
            
            
            int32_t v16;
            v16 = v9 + 1l;
            
            
            v17 = v16;
        } else {
            
            
            v17 = v9;
        }
        
        
        int32_t v18;
        v18 = v1 + 1l;
        
        
        return loop22(v0, v18, v17);
    }
}
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
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
static inline void AssignArray0(int32_t * a, int32_t b){
    
    
    *a = b;
}
void loop24(Array0 * v0, int32_t v1){
    
    
    bool v2;
    v2 = v1 < 8192l;
    
    
    if (v2){
        
        
        
        AssignArray0(&(v0->ptr[v1]), 0l);
        
        
        int32_t v3;
        v3 = v1 + 1l;
        
        
        return loop24(v0, v3);
    } else {
        
        ArrayDecref0(v0);
        return ;
    }
}
void loop25(Array0 * v0, int32_t v1){
    
    
    bool v2;
    v2 = v1 < 1l;
    
    
    if (v2){
        
        
        
        AssignArray0(&(v0->ptr[v1]), 0l);
        
        
        int32_t v3;
        v3 = v1 + 1l;
        
        
        return loop25(v0, v3);
    } else {
        
        ArrayDecref0(v0);
        return ;
    }
}
int32_t probe27(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8, int32_t v9, int32_t v10){
    
    
    int32_t v11;
    v11 = v4->ptr[v10];
    
    
    bool v12;
    v12 = v11 == 0l;
    
    
    if (v12){
        
        ArrayDecref0(v5);
        int32_t v13;
        v13 = v6->ptr[0l];
        
        
        bool v14;
        v14 = v13 < 4096l;
        
        
        if (v14){
            
            
            
            AssignArray0(&(v0->ptr[v13]), v7);
            
            ArrayDecref0(v0);
            
            AssignArray0(&(v1->ptr[v13]), v8);
            
            ArrayDecref0(v1);
            
            AssignArray0(&(v2->ptr[v13]), v9);
            
            ArrayDecref0(v2);
            bool v15;
            v15 = v7 == 1l;
            
            
            bool v32;
            if (v15){
                
                
                v32 = true;
            } else {
                
                
                bool v16;
                v16 = v7 == 5l;
                
                
                if (v16){
                    
                    
                    v32 = true;
                } else {
                    
                    
                    bool v17;
                    v17 = v7 == 3l;
                    
                    
                    if (v17){
                        
                        
                        int32_t v18;
                        v18 = v3->ptr[v8];
                        
                        
                        bool v19;
                        v19 = v18 == 1l;
                        
                        
                        if (v19){
                            
                            
                            v32 = true;
                        } else {
                            
                            
                            int32_t v20;
                            v20 = v3->ptr[v9];
                            
                            
                            bool v21;
                            v21 = v20 == 1l;
                            
                            
                            v32 = v21;
                        }
                    } else {
                        
                        
                        bool v23;
                        v23 = v7 == 4l;
                        
                        
                        if (v23){
                            
                            
                            int32_t v24;
                            v24 = v3->ptr[v8];
                            
                            
                            bool v25;
                            v25 = v24 == 1l;
                            
                            
                            if (v25){
                                
                                
                                int32_t v26;
                                v26 = v3->ptr[v9];
                                
                                
                                bool v27;
                                v27 = v26 == 1l;
                                
                                
                                v32 = v27;
                            } else {
                                
                                
                                v32 = false;
                            }
                        } else {
                            
                            
                            v32 = false;
                        }
                    }
                }
            }
            
            
            int32_t v33;
            if (v32){
                
                
                v33 = 1l;
            } else {
                
                
                v33 = 0l;
            }
            
            
            
            AssignArray0(&(v3->ptr[v13]), v33);
            
            ArrayDecref0(v3);
            int32_t v34;
            v34 = v13 + 1l;
            
            
            
            AssignArray0(&(v4->ptr[v10]), v34);
            
            ArrayDecref0(v4);
            
            AssignArray0(&(v6->ptr[0l]), v34);
            
            ArrayDecref0(v6);
            return v13;
        } else {
            
            ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v6);
            fprintf(stderr, "%s\n", "brzozowski-interned-store-full");
            exit(EXIT_FAILURE);
        }
    } else {
        
        
        int32_t v37;
        v37 = v11 - 1l;
        
        
        int32_t v38;
        v38 = v0->ptr[v37];
        
        
        bool v39;
        v39 = v38 == v7;
        
        
        bool v42;
        if (v39){
            
            
            int32_t v40;
            v40 = v1->ptr[v37];
            
            
            bool v41;
            v41 = v40 == v8;
            
            
            v42 = v41;
        } else {
            
            
            v42 = false;
        }
        
        
        bool v45;
        if (v42){
            
            
            int32_t v43;
            v43 = v2->ptr[v37];
            
            
            bool v44;
            v44 = v43 == v9;
            
            
            v45 = v44;
        } else {
            
            
            v45 = false;
        }
        
        
        if (v45){
            
            ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
            return v37;
        } else {
            
            
            int32_t v46;
            v46 = v10 + 1l;
            
            
            int32_t v47;
            v47 = v46 & 8191l;
            
            
            return probe27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v47);
        }
    }
}
int32_t interned_node26(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8, int32_t v9){
    
    
    int32_t v10;
    v10 = v7 * 1024l;
    
    
    int32_t v11;
    v11 = v10 + v8;
    
    
    int32_t v12;
    v12 = v11 * 4099l;
    
    
    int32_t v13;
    v13 = v12 + v9;
    
    
    int32_t v14;
    v14 = v13 & 8191l;
    
    
    return probe27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14);
}
int32_t interned_alt_insert30(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8){
    
    
    bool v9;
    v9 = v8 == 0l;
    
    
    if (v9){
        
        ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
        return v7;
    } else {
        
        
        int32_t v10;
        v10 = v0->ptr[v8];
        
        
        bool v11;
        v11 = v10 == 3l;
        
        
        if (v11){
            
            
            int32_t v12;
            v12 = v1->ptr[v8];
            
            
            bool v13;
            v13 = v7 < v12;
            
            
            if (v13){
                
                
                int32_t v14;
                v14 = 3l;
                
                
                return interned_node26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8);
            } else {
                
                
                bool v16;
                v16 = v7 == v12;
                
                
                if (v16){
                    
                    ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
                    return v8;
                } else {
                    
                    
                    int32_t v17;
                    v17 = 3l;
                    
                    
                    int32_t v18;
                    v18 = v2->ptr[v8];
                    v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                    
                    int32_t v19;
                    v19 = interned_alt_insert30(v0, v1, v2, v3, v4, v5, v6, v7, v18);
                    
                    
                    return interned_node26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19);
                }
            }
        } else {
            
            
            bool v23;
            v23 = v7 < v8;
            
            
            if (v23){
                
                
                int32_t v24;
                v24 = 3l;
                
                
                return interned_node26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8);
            } else {
                
                
                bool v26;
                v26 = v7 == v8;
                
                
                if (v26){
                    
                    ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
                    return v8;
                } else {
                    
                    
                    int32_t v27;
                    v27 = 3l;
                    
                    
                    return interned_node26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7);
                }
            }
        }
    }
}
int32_t interned_make_alt29(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8){
    
    
    bool v9;
    v9 = v7 == 0l;
    
    
    if (v9){
        
        ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
        return v8;
    } else {
        
        
        int32_t v10;
        v10 = v0->ptr[v7];
        
        
        bool v11;
        v11 = v10 == 3l;
        
        
        if (v11){
            
            
            int32_t v12;
            v12 = v2->ptr[v7];
            
            
            int32_t v13;
            v13 = v1->ptr[v7];
            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
            
            int32_t v14;
            v14 = interned_alt_insert30(v0, v1, v2, v3, v4, v5, v6, v13, v8);
            
            
            return interned_make_alt29(v0, v1, v2, v3, v4, v5, v6, v12, v14);
        } else {
            
            
            return interned_alt_insert30(v0, v1, v2, v3, v4, v5, v6, v7, v8);
        }
    }
}
int32_t interned_make_cat31(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8){
    
    
    bool v9;
    v9 = v7 == 0l;
    
    
    if (v9){
        
        ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
        return 0l;
    } else {
        
        
        bool v10;
        v10 = v8 == 0l;
        
        
        if (v10){
            
            ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
            return 0l;
        } else {
            
            
            bool v11;
            v11 = v7 == 1l;
            
            
            if (v11){
                
                ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
                return v8;
            } else {
                
                
                bool v12;
                v12 = v8 == 1l;
                
                
                if (v12){
                    
                    ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
                    return v7;
                } else {
                    
                    
                    int32_t v13;
                    v13 = v0->ptr[v7];
                    
                    
                    bool v14;
                    v14 = v13 == 5l;
                    
                    
                    bool v17;
                    if (v14){
                        
                        
                        int32_t v15;
                        v15 = v0->ptr[v8];
                        
                        
                        bool v16;
                        v16 = v15 == 5l;
                        
                        
                        v17 = v16;
                    } else {
                        
                        
                        v17 = false;
                    }
                    
                    
                    if (v17){
                        
                        
                        int32_t v18;
                        v18 = v1->ptr[v7];
                        
                        
                        int32_t v19;
                        v19 = v1->ptr[v8];
                        
                        
                        bool v20;
                        v20 = v18 == v19;
                        
                        
                        if (v20){
                            
                            ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
                            return v7;
                        } else {
                            
                            
                            int32_t v21;
                            v21 = 4l;
                            
                            
                            return interned_node26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8);
                        }
                    } else {
                        
                        
                        int32_t v24;
                        v24 = v0->ptr[v7];
                        
                        
                        bool v25;
                        v25 = v24 == 4l;
                        
                        
                        if (v25){
                            
                            
                            int32_t v26;
                            v26 = 4l;
                            
                            
                            int32_t v27;
                            v27 = v1->ptr[v7];
                            
                            
                            int32_t v28;
                            v28 = v2->ptr[v7];
                            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                            
                            int32_t v29;
                            v29 = interned_make_cat31(v0, v1, v2, v3, v4, v5, v6, v28, v8);
                            
                            
                            return interned_node26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29);
                        } else {
                            
                            
                            int32_t v31;
                            v31 = 4l;
                            
                            
                            return interned_node26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8);
                        }
                    }
                }
            }
        }
    }
}
int32_t interned_of_regex_raw28(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, UH0 * v7){
    
    
    switch (v7->tag) {
        case 3: { // RegexAlt
            UH0 * v14 = v7->case3.v0; UH0 * v15 = v7->case3.v1;
            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v14->refc += 2; v15->refc++;
            UHDecref0(v7);
            int32_t v16;
            v16 = interned_of_regex_raw28(v0, v1, v2, v3, v4, v5, v6, v14);
            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v15->refc++;
            UHDecref0(v14);
            int32_t v17;
            v17 = interned_of_regex_raw28(v0, v1, v2, v3, v4, v5, v6, v15);
            
            UHDecref0(v15);
            return interned_make_alt29(v0, v1, v2, v3, v4, v5, v6, v16, v17);
            break;
        }
        case 4: { // RegexCat
            UH0 * v19 = v7->case4.v0; UH0 * v20 = v7->case4.v1;
            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v19->refc += 2; v20->refc++;
            UHDecref0(v7);
            int32_t v21;
            v21 = interned_of_regex_raw28(v0, v1, v2, v3, v4, v5, v6, v19);
            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v20->refc++;
            UHDecref0(v19);
            int32_t v22;
            v22 = interned_of_regex_raw28(v0, v1, v2, v3, v4, v5, v6, v20);
            
            UHDecref0(v20);
            return interned_make_cat31(v0, v1, v2, v3, v4, v5, v6, v21, v22);
            break;
        }
        case 2: { // RegexChar
            US0 v8 = v7->case2.v0;
            USIncref0(&(v8));
            UHDecref0(v7);
            int32_t v9;
            v9 = 2l;
            
            
            int32_t v11;
            switch (v8.tag) {
                case 1: { // BitOne
                    
                    
                    
                    v11 = 1l;
                    break;
                }
                case 0: { // BitZero
                    
                    
                    
                    v11 = 0l;
                    break;
                }
            }
            
            USDecref0(&(v8));
            int32_t v12;
            v12 = 0l;
            
            
            return interned_node26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12);
            break;
        }
        case 0: { // RegexEmpty
            
            
            ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6); UHDecref0(v7);
            return 0l;
            break;
        }
        case 1: { // RegexEpsilon
            
            
            ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6); UHDecref0(v7);
            return 1l;
            break;
        }
        case 5: { // RegexStar
            UH0 * v24 = v7->case5.v0;
            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v24->refc += 2;
            UHDecref0(v7);
            int32_t v25;
            v25 = interned_of_regex_raw28(v0, v1, v2, v3, v4, v5, v6, v24);
            
            UHDecref0(v24);
            int32_t v26;
            v26 = v0->ptr[v25];
            
            
            bool v27;
            v27 = v26 < 2l;
            
            
            if (v27){
                
                ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
                return 1l;
            } else {
                
                
                bool v28;
                v28 = v26 == 5l;
                
                
                if (v28){
                    
                    ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
                    return v25;
                } else {
                    
                    
                    int32_t v29;
                    v29 = 5l;
                    
                    
                    int32_t v30;
                    v30 = 0l;
                    
                    
                    return interned_node26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30);
                }
            }
            break;
        }
    }
}
int32_t interned_derivative_raw35(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8){
    
    
    int32_t v9;
    v9 = v7 * 2l;
    
    
    int32_t v10;
    v10 = v9 + v8;
    
    
    int32_t v11;
    v11 = v5->ptr[v10];
    
    
    bool v12;
    v12 = v11 == 0l;
    
    
    if (v12){
        
        
        int32_t v13;
        v13 = v0->ptr[v7];
        
        
        bool v14;
        v14 = v13 < 2l;
        
        
        int32_t v41;
        if (v14){
            
            
            v41 = 0l;
        } else {
            
            
            bool v15;
            v15 = v13 == 2l;
            
            
            if (v15){
                
                
                int32_t v16;
                v16 = v1->ptr[v7];
                
                
                bool v17;
                v17 = v16 == v8;
                
                
                if (v17){
                    
                    
                    v41 = 1l;
                } else {
                    
                    
                    v41 = 0l;
                }
            } else {
                
                
                bool v19;
                v19 = v13 == 3l;
                
                
                if (v19){
                    
                    
                    int32_t v20;
                    v20 = v1->ptr[v7];
                    v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                    
                    int32_t v21;
                    v21 = interned_derivative_raw35(v0, v1, v2, v3, v4, v5, v6, v20, v8);
                    
                    
                    int32_t v22;
                    v22 = v2->ptr[v7];
                    v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                    
                    int32_t v23;
                    v23 = interned_derivative_raw35(v0, v1, v2, v3, v4, v5, v6, v22, v8);
                    v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                    
                    v41 = interned_make_alt29(v0, v1, v2, v3, v4, v5, v6, v21, v23);
                } else {
                    
                    
                    bool v25;
                    v25 = v13 == 4l;
                    
                    
                    if (v25){
                        
                        
                        int32_t v26;
                        v26 = v1->ptr[v7];
                        
                        
                        int32_t v27;
                        v27 = v2->ptr[v7];
                        v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                        
                        int32_t v28;
                        v28 = interned_derivative_raw35(v0, v1, v2, v3, v4, v5, v6, v26, v8);
                        v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                        
                        int32_t v29;
                        v29 = interned_make_cat31(v0, v1, v2, v3, v4, v5, v6, v28, v27);
                        
                        
                        int32_t v30;
                        v30 = v3->ptr[v26];
                        
                        
                        bool v31;
                        v31 = v30 == 1l;
                        
                        
                        if (v31){
                            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                            
                            int32_t v32;
                            v32 = interned_derivative_raw35(v0, v1, v2, v3, v4, v5, v6, v27, v8);
                            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                            
                            v41 = interned_make_alt29(v0, v1, v2, v3, v4, v5, v6, v29, v32);
                        } else {
                            
                            
                            v41 = v29;
                        }
                    } else {
                        
                        
                        int32_t v35;
                        v35 = v1->ptr[v7];
                        v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                        
                        int32_t v36;
                        v36 = interned_derivative_raw35(v0, v1, v2, v3, v4, v5, v6, v35, v8);
                        v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                        
                        v41 = interned_make_cat31(v0, v1, v2, v3, v4, v5, v6, v36, v7);
                    }
                }
            }
        }
        
        ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v6);
        int32_t v42;
        v42 = v41 + 1l;
        
        
        
        AssignArray0(&(v5->ptr[v10]), v42);
        
        ArrayDecref0(v5);
        return v41;
    } else {
        
        ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
        int32_t v43;
        v43 = v11 - 1l;
        
        
        return v43;
    }
}
bool loop34(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, UH1 * v8){
    
    
    bool v9;
    v9 = v7 == 0l;
    
    
    if (v9){
        
        ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6); UHDecref1(v8);
        return false;
    } else {
        
        
        switch (v8->tag) {
            case 1: { // InputCons
                US0 v12 = v8->case1.v0; UH1 * v13 = v8->case1.v1;
                USIncref0(&(v12)); v13->refc++;
                UHDecref1(v8);
                int32_t v15;
                switch (v12.tag) {
                    case 1: { // BitOne
                        
                        
                        
                        v15 = 1l;
                        break;
                    }
                    case 0: { // BitZero
                        
                        
                        
                        v15 = 0l;
                        break;
                    }
                }
                v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                USDecref0(&(v12));
                int32_t v16;
                v16 = interned_derivative_raw35(v0, v1, v2, v3, v4, v5, v6, v7, v15);
                
                
                return loop34(v0, v1, v2, v3, v4, v5, v6, v16, v13);
                break;
            }
            case 0: { // InputEmpty
                
                
                ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6); UHDecref1(v8);
                int32_t v10;
                v10 = v3->ptr[v7];
                
                ArrayDecref0(v3);
                bool v11;
                v11 = v10 == 1l;
                
                
                return v11;
                break;
            }
        }
    }
}
bool interned_accepts33(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, UH1 * v8){
    
    
    return loop34(v0, v1, v2, v3, v4, v5, v6, v7, v8);
}
int32_t loop32(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8, int32_t v9, uint64_t v10, int32_t v11){
    
    
    bool v12;
    v12 = 0l < v9;
    
    
    if (v12){
        
        
        UH1 * v13;
        v13 = UH1_InputEmpty();
        v13->refc++;
        
        UH1 * v14; uint64_t v15;
        Tuple0 tmp4 = random_bit_input1(v10, v7, v13);
        v14 = tmp4.v0; v15 = tmp4.v1;
        v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v14->refc++;
        UHDecref1(v13);
        bool v16;
        v16 = interned_accepts33(v0, v1, v2, v3, v4, v5, v6, v8, v14);
        
        UHDecref1(v14);
        int32_t v18;
        if (v16){
            
            
            int32_t v17;
            v17 = v11 + 1l;
            
            
            v18 = v17;
        } else {
            
            
            v18 = v11;
        }
        
        
        int32_t v19;
        v19 = v9 - 1l;
        
        
        return loop32(v0, v1, v2, v3, v4, v5, v6, v7, v8, v19, v15, v18);
    } else {
        
        ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
        return v11;
    }
}
int32_t loop36(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8, int32_t v9, int32_t v10){
    
    
    bool v11;
    v11 = v7 < v9;
    
    
    if (v11){
        
        ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
        return v10;
    } else {
        
        
        UH1 * v12;
        v12 = UH1_InputEmpty();
        v12->refc++;
        
        UH1 * v13;
        v13 = zeros_input14(v9, v12);
        v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v13->refc++;
        UHDecref1(v12);
        bool v14;
        v14 = interned_accepts33(v0, v1, v2, v3, v4, v5, v6, v8, v13);
        
        UHDecref1(v13);
        int32_t v16;
        if (v14){
            
            
            int32_t v15;
            v15 = v10 + 1l;
            
            
            v16 = v15;
        } else {
            
            
            v16 = v10;
        }
        
        
        US0 v17;
        v17 = US0_BitOne();
        
        
        UH1 * v18;
        v18 = UH1_InputEmpty();
        USIncref0(&(v17)); v18->refc++;
        
        UH1 * v19;
        v19 = UH1_InputCons(v17, v18);
        v19->refc++;
        USDecref0(&(v17)); UHDecref1(v18);
        UH1 * v20;
        v20 = zeros_input14(v9, v19);
        v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v20->refc++;
        UHDecref1(v19);
        bool v21;
        v21 = interned_accepts33(v0, v1, v2, v3, v4, v5, v6, v8, v20);
        
        UHDecref1(v20);
        int32_t v23;
        if (v21){
            
            
            int32_t v22;
            v22 = v16 + 1l;
            
            
            v23 = v22;
        } else {
            
            
            v23 = v16;
        }
        
        
        int32_t v24;
        v24 = v9 + 1l;
        
        
        return loop36(v0, v1, v2, v3, v4, v5, v6, v7, v8, v24, v23);
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 200l;
    
    
    int32_t v1;
    v1 = 32l;
    
    
    US0 v2;
    v2 = US0_BitZero();
    USIncref0(&(v2));
    
    UH0 * v3;
    v3 = UH0_RegexChar(v2);
    
    USDecref0(&(v2));
    US0 v4;
    v4 = US0_BitOne();
    USIncref0(&(v4));
    
    UH0 * v5;
    v5 = UH0_RegexChar(v4);
    v3->refc++; v5->refc++;
    USDecref0(&(v4));
    UH0 * v6;
    v6 = UH0_RegexAlt(v3, v5);
    v6->refc++;
    UHDecref0(v3); UHDecref0(v5);
    UH0 * v7;
    v7 = UH0_RegexStar(v6);
    
    UHDecref0(v6);
    US0 v8;
    v8 = US0_BitZero();
    USIncref0(&(v8));
    
    UH0 * v9;
    v9 = UH0_RegexChar(v8);
    v7->refc++; v9->refc++;
    USDecref0(&(v8));
    UH0 * v10;
    v10 = UH0_RegexCat(v7, v9);
    
    UHDecref0(v7); UHDecref0(v9);
    US0 v11;
    v11 = US0_BitZero();
    USIncref0(&(v11));
    
    UH0 * v12;
    v12 = UH0_RegexChar(v11);
    
    USDecref0(&(v11));
    US0 v13;
    v13 = US0_BitOne();
    USIncref0(&(v13));
    
    UH0 * v14;
    v14 = UH0_RegexChar(v13);
    v12->refc++; v14->refc++;
    USDecref0(&(v13));
    UH0 * v15;
    v15 = UH0_RegexAlt(v12, v14);
    v15->refc++;
    UHDecref0(v12); UHDecref0(v14);
    UH0 * v16;
    v16 = UH0_RegexStar(v15);
    
    UHDecref0(v15);
    US0 v17;
    v17 = US0_BitOne();
    USIncref0(&(v17));
    
    UH0 * v18;
    v18 = UH0_RegexChar(v17);
    
    USDecref0(&(v17));
    US0 v19;
    v19 = US0_BitZero();
    USIncref0(&(v19));
    
    UH0 * v20;
    v20 = UH0_RegexChar(v19);
    
    USDecref0(&(v19));
    US0 v21;
    v21 = US0_BitOne();
    USIncref0(&(v21));
    
    UH0 * v22;
    v22 = UH0_RegexChar(v21);
    v20->refc++; v22->refc++;
    USDecref0(&(v21));
    UH0 * v23;
    v23 = UH0_RegexAlt(v20, v22);
    
    UHDecref0(v20); UHDecref0(v22);
    US0 v24;
    v24 = US0_BitZero();
    USIncref0(&(v24));
    
    UH0 * v25;
    v25 = UH0_RegexChar(v24);
    
    USDecref0(&(v24));
    US0 v26;
    v26 = US0_BitOne();
    USIncref0(&(v26));
    
    UH0 * v27;
    v27 = UH0_RegexChar(v26);
    v25->refc++; v27->refc++;
    USDecref0(&(v26));
    UH0 * v28;
    v28 = UH0_RegexAlt(v25, v27);
    
    UHDecref0(v25); UHDecref0(v27);
    US0 v29;
    v29 = US0_BitZero();
    USIncref0(&(v29));
    
    UH0 * v30;
    v30 = UH0_RegexChar(v29);
    
    USDecref0(&(v29));
    US0 v31;
    v31 = US0_BitOne();
    USIncref0(&(v31));
    
    UH0 * v32;
    v32 = UH0_RegexChar(v31);
    v30->refc++; v32->refc++;
    USDecref0(&(v31));
    UH0 * v33;
    v33 = UH0_RegexAlt(v30, v32);
    v28->refc++; v33->refc++;
    UHDecref0(v30); UHDecref0(v32);
    UH0 * v34;
    v34 = UH0_RegexCat(v28, v33);
    v23->refc++; v34->refc++;
    UHDecref0(v28); UHDecref0(v33);
    UH0 * v35;
    v35 = UH0_RegexCat(v23, v34);
    v18->refc++; v35->refc++;
    UHDecref0(v23); UHDecref0(v34);
    UH0 * v36;
    v36 = UH0_RegexCat(v18, v35);
    v16->refc++; v36->refc++;
    UHDecref0(v18); UHDecref0(v35);
    UH0 * v37;
    v37 = UH0_RegexCat(v16, v36);
    
    UHDecref0(v16); UHDecref0(v36);
    uint64_t v38;
    v38 = 1ull;
    
    
    int32_t v39;
    v39 = 0l;
    v10->refc++;
    
    int32_t v40;
    v40 = loop0(v10, v1, v0, v38, v39);
    v37->refc++;
    UHDecref0(v10);
    int32_t v41;
    v41 = loop0(v37, v1, v0, v38, v39);
    
    UHDecref0(v37);
    int32_t v42;
    v42 = 16l;
    
    
    US0 v43;
    v43 = US0_BitZero();
    USIncref0(&(v43));
    
    UH0 * v44;
    v44 = UH0_RegexChar(v43);
    
    USDecref0(&(v43));
    US0 v45;
    v45 = US0_BitZero();
    USIncref0(&(v45));
    
    UH0 * v46;
    v46 = UH0_RegexChar(v45);
    
    USDecref0(&(v45));
    US0 v47;
    v47 = US0_BitZero();
    USIncref0(&(v47));
    
    UH0 * v48;
    v48 = UH0_RegexChar(v47);
    v46->refc++; v48->refc++;
    USDecref0(&(v47));
    UH0 * v49;
    v49 = UH0_RegexCat(v46, v48);
    v44->refc++; v49->refc++;
    UHDecref0(v46); UHDecref0(v48);
    UH0 * v50;
    v50 = UH0_RegexAlt(v44, v49);
    v50->refc++;
    UHDecref0(v44); UHDecref0(v49);
    UH0 * v51;
    v51 = UH0_RegexStar(v50);
    
    UHDecref0(v50);
    US0 v52;
    v52 = US0_BitOne();
    USIncref0(&(v52));
    
    UH0 * v53;
    v53 = UH0_RegexChar(v52);
    v51->refc++; v53->refc++;
    USDecref0(&(v52));
    UH0 * v54;
    v54 = UH0_RegexCat(v51, v53);
    
    UHDecref0(v51); UHDecref0(v53);
    int32_t v55;
    v55 = 0l;
    
    
    int32_t v56;
    v56 = 1l;
    v54->refc++;
    
    int32_t v57;
    v57 = loop13(v54, v42, v56, v55);
    
    UHDecref0(v54);
    int32_t v58;
    v58 = 200l;
    
    
    int32_t v59;
    v59 = 32l;
    
    
    US0 v60;
    v60 = US0_BitZero();
    USIncref0(&(v60));
    
    UH0 * v61;
    v61 = UH0_RegexChar(v60);
    
    USDecref0(&(v60));
    US0 v62;
    v62 = US0_BitOne();
    USIncref0(&(v62));
    
    UH0 * v63;
    v63 = UH0_RegexChar(v62);
    v61->refc++; v63->refc++;
    USDecref0(&(v62));
    UH0 * v64;
    v64 = UH0_RegexAlt(v61, v63);
    v64->refc++;
    UHDecref0(v61); UHDecref0(v63);
    UH0 * v65;
    v65 = UH0_RegexStar(v64);
    
    UHDecref0(v64);
    US0 v66;
    v66 = US0_BitZero();
    USIncref0(&(v66));
    
    UH0 * v67;
    v67 = UH0_RegexChar(v66);
    v65->refc++; v67->refc++;
    USDecref0(&(v66));
    UH0 * v68;
    v68 = UH0_RegexCat(v65, v67);
    
    UHDecref0(v65); UHDecref0(v67);
    US0 v69;
    v69 = US0_BitZero();
    USIncref0(&(v69));
    
    UH0 * v70;
    v70 = UH0_RegexChar(v69);
    
    USDecref0(&(v69));
    US0 v71;
    v71 = US0_BitOne();
    USIncref0(&(v71));
    
    UH0 * v72;
    v72 = UH0_RegexChar(v71);
    v70->refc++; v72->refc++;
    USDecref0(&(v71));
    UH0 * v73;
    v73 = UH0_RegexAlt(v70, v72);
    v73->refc++;
    UHDecref0(v70); UHDecref0(v72);
    UH0 * v74;
    v74 = UH0_RegexStar(v73);
    
    UHDecref0(v73);
    US0 v75;
    v75 = US0_BitOne();
    USIncref0(&(v75));
    
    UH0 * v76;
    v76 = UH0_RegexChar(v75);
    
    USDecref0(&(v75));
    US0 v77;
    v77 = US0_BitZero();
    USIncref0(&(v77));
    
    UH0 * v78;
    v78 = UH0_RegexChar(v77);
    
    USDecref0(&(v77));
    US0 v79;
    v79 = US0_BitOne();
    USIncref0(&(v79));
    
    UH0 * v80;
    v80 = UH0_RegexChar(v79);
    v78->refc++; v80->refc++;
    USDecref0(&(v79));
    UH0 * v81;
    v81 = UH0_RegexAlt(v78, v80);
    
    UHDecref0(v78); UHDecref0(v80);
    US0 v82;
    v82 = US0_BitZero();
    USIncref0(&(v82));
    
    UH0 * v83;
    v83 = UH0_RegexChar(v82);
    
    USDecref0(&(v82));
    US0 v84;
    v84 = US0_BitOne();
    USIncref0(&(v84));
    
    UH0 * v85;
    v85 = UH0_RegexChar(v84);
    v83->refc++; v85->refc++;
    USDecref0(&(v84));
    UH0 * v86;
    v86 = UH0_RegexAlt(v83, v85);
    
    UHDecref0(v83); UHDecref0(v85);
    US0 v87;
    v87 = US0_BitZero();
    USIncref0(&(v87));
    
    UH0 * v88;
    v88 = UH0_RegexChar(v87);
    
    USDecref0(&(v87));
    US0 v89;
    v89 = US0_BitOne();
    USIncref0(&(v89));
    
    UH0 * v90;
    v90 = UH0_RegexChar(v89);
    v88->refc++; v90->refc++;
    USDecref0(&(v89));
    UH0 * v91;
    v91 = UH0_RegexAlt(v88, v90);
    v86->refc++; v91->refc++;
    UHDecref0(v88); UHDecref0(v90);
    UH0 * v92;
    v92 = UH0_RegexCat(v86, v91);
    v81->refc++; v92->refc++;
    UHDecref0(v86); UHDecref0(v91);
    UH0 * v93;
    v93 = UH0_RegexCat(v81, v92);
    v76->refc++; v93->refc++;
    UHDecref0(v81); UHDecref0(v92);
    UH0 * v94;
    v94 = UH0_RegexCat(v76, v93);
    v74->refc++; v94->refc++;
    UHDecref0(v76); UHDecref0(v93);
    UH0 * v95;
    v95 = UH0_RegexCat(v74, v94);
    
    UHDecref0(v74); UHDecref0(v94);
    uint64_t v96;
    v96 = 1ull;
    
    
    int32_t v97;
    v97 = 0l;
    v68->refc++;
    
    int32_t v98;
    v98 = loop15(v68, v59, v58, v96, v97);
    v95->refc++;
    UHDecref0(v68);
    int32_t v99;
    v99 = loop15(v95, v59, v58, v96, v97);
    
    UHDecref0(v95);
    int32_t v100;
    v100 = 16l;
    
    
    US0 v101;
    v101 = US0_BitZero();
    USIncref0(&(v101));
    
    UH0 * v102;
    v102 = UH0_RegexChar(v101);
    
    USDecref0(&(v101));
    US0 v103;
    v103 = US0_BitZero();
    USIncref0(&(v103));
    
    UH0 * v104;
    v104 = UH0_RegexChar(v103);
    
    USDecref0(&(v103));
    US0 v105;
    v105 = US0_BitZero();
    USIncref0(&(v105));
    
    UH0 * v106;
    v106 = UH0_RegexChar(v105);
    v104->refc++; v106->refc++;
    USDecref0(&(v105));
    UH0 * v107;
    v107 = UH0_RegexCat(v104, v106);
    v102->refc++; v107->refc++;
    UHDecref0(v104); UHDecref0(v106);
    UH0 * v108;
    v108 = UH0_RegexAlt(v102, v107);
    v108->refc++;
    UHDecref0(v102); UHDecref0(v107);
    UH0 * v109;
    v109 = UH0_RegexStar(v108);
    
    UHDecref0(v108);
    US0 v110;
    v110 = US0_BitOne();
    USIncref0(&(v110));
    
    UH0 * v111;
    v111 = UH0_RegexChar(v110);
    v109->refc++; v111->refc++;
    USDecref0(&(v110));
    UH0 * v112;
    v112 = UH0_RegexCat(v109, v111);
    
    UHDecref0(v109); UHDecref0(v111);
    int32_t v113;
    v113 = 0l;
    
    
    int32_t v114;
    v114 = 1l;
    v112->refc++;
    
    int32_t v115;
    v115 = loop17(v112, v100, v114, v113);
    
    UHDecref0(v112);
    bool v116;
    v116 = v40 == v98;
    
    
    bool v118;
    if (v116){
        
        
        bool v117;
        v117 = v41 == v99;
        
        
        v118 = v117;
    } else {
        
        
        v118 = false;
    }
    
    
    bool v120;
    if (v118){
        
        
        bool v119;
        v119 = v57 == v115;
        
        
        v120 = v119;
    } else {
        
        
        v120 = false;
    }
    
    
    
    if (v120){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-bench-engines-disagree");
        exit(EXIT_FAILURE);
    }
    
    
    int32_t v121;
    v121 = 200l;
    
    
    int32_t v122;
    v122 = 32l;
    
    
    uint64_t v123;
    v123 = 1ull;
    
    
    int32_t v124;
    v124 = 0l;
    
    
    int32_t v125;
    v125 = loop18(v122, v121, v123, v124);
    
    
    int32_t v126;
    v126 = loop20(v122, v121, v123, v124);
    
    
    int32_t v127;
    v127 = 16l;
    
    
    int32_t v128;
    v128 = 0l;
    
    
    int32_t v129;
    v129 = 1l;
    
    
    int32_t v130;
    v130 = loop22(v127, v129, v128);
    
    
    bool v131;
    v131 = v40 == v125;
    
    
    bool v133;
    if (v131){
        
        
        bool v132;
        v132 = v41 == v126;
        
        
        v133 = v132;
    } else {
        
        
        v133 = false;
    }
    
    
    bool v135;
    if (v133){
        
        
        bool v134;
        v134 = v57 == v130;
        
        
        v135 = v134;
    } else {
        
        
        v135 = false;
    }
    
    
    
    if (v135){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-bench-engines-disagree");
        exit(EXIT_FAILURE);
    }
    
    
    int32_t v136;
    v136 = 200l;
    
    
    int32_t v137;
    v137 = 32l;
    
    
    Array0 * v138;
    v138 = ArrayCreate0(4096l, false);
    
    
    Array0 * v139;
    v139 = ArrayCreate0(4096l, false);
    
    
    Array0 * v140;
    v140 = ArrayCreate0(4096l, false);
    
    
    Array0 * v141;
    v141 = ArrayCreate0(4096l, false);
    
    
    Array0 * v142;
    v142 = ArrayCreate0(8192l, false);
    
    
    Array0 * v143;
    v143 = ArrayCreate0(8192l, false);
    
    
    Array0 * v144;
    v144 = ArrayCreate0(1l, false);
    
    
    int32_t v145;
    v145 = 0l;
    v142->refc++;
    
    
    loop24(v142, v145);
    
    
    int32_t v146;
    v146 = 0l;
    v143->refc++;
    
    
    loop24(v143, v146);
    
    
    int32_t v147;
    v147 = 0l;
    v144->refc++;
    
    
    loop25(v144, v147);
    
    
    int32_t v148;
    v148 = 0l;
    
    
    int32_t v149;
    v149 = 0l;
    
    
    int32_t v150;
    v150 = 0l;
    v138->refc++; v139->refc++; v140->refc++; v141->refc++; v142->refc++; v143->refc++; v144->refc++;
    
    int32_t v151;
    v151 = interned_node26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150);
    
    
    int32_t v152;
    v152 = 1l;
    
    
    int32_t v153;
    v153 = 0l;
    
    
    int32_t v154;
    v154 = 0l;
    v138->refc++; v139->refc++; v140->refc++; v141->refc++; v142->refc++; v143->refc++; v144->refc++;
    
    int32_t v155;
    v155 = interned_node26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154);
    
    
    bool v156;
    v156 = v151 == 0l;
    
    
    bool v158;
    if (v156){
        
        
        bool v157;
        v157 = v155 == 1l;
        
        
        v158 = v157;
    } else {
        
        
        v158 = false;
    }
    
    
    Array0 * v166; Array0 * v167; Array0 * v168; Array0 * v169; Array0 * v170; Array0 * v171; Array0 * v172;
    if (v158){
        v138->refc++; v139->refc++; v140->refc++; v141->refc++; v142->refc++; v143->refc++; v144->refc++;
        
        v166 = v138; v167 = v139; v168 = v140; v169 = v141; v170 = v142; v171 = v143; v172 = v144;
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-interned-store-init");
        exit(EXIT_FAILURE);
    }
    
    ArrayDecref0(v138); ArrayDecref0(v139); ArrayDecref0(v140); ArrayDecref0(v141); ArrayDecref0(v142); ArrayDecref0(v143); ArrayDecref0(v144);
    US0 v173;
    v173 = US0_BitZero();
    USIncref0(&(v173));
    
    UH0 * v174;
    v174 = UH0_RegexChar(v173);
    
    USDecref0(&(v173));
    US0 v175;
    v175 = US0_BitOne();
    USIncref0(&(v175));
    
    UH0 * v176;
    v176 = UH0_RegexChar(v175);
    v174->refc++; v176->refc++;
    USDecref0(&(v175));
    UH0 * v177;
    v177 = UH0_RegexAlt(v174, v176);
    v177->refc++;
    UHDecref0(v174); UHDecref0(v176);
    UH0 * v178;
    v178 = UH0_RegexStar(v177);
    
    UHDecref0(v177);
    US0 v179;
    v179 = US0_BitZero();
    USIncref0(&(v179));
    
    UH0 * v180;
    v180 = UH0_RegexChar(v179);
    v178->refc++; v180->refc++;
    USDecref0(&(v179));
    UH0 * v181;
    v181 = UH0_RegexCat(v178, v180);
    v166->refc++; v167->refc++; v168->refc++; v169->refc++; v170->refc++; v171->refc++; v172->refc++; v181->refc++;
    UHDecref0(v178); UHDecref0(v180);
    int32_t v182;
    v182 = interned_of_regex_raw28(v166, v167, v168, v169, v170, v171, v172, v181);
    
    UHDecref0(v181);
    uint64_t v183;
    v183 = 1ull;
    
    
    int32_t v184;
    v184 = 0l;
    v166->refc++; v167->refc++; v168->refc++; v169->refc++; v170->refc++; v171->refc++; v172->refc++;
    
    int32_t v185;
    v185 = loop32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184);
    
    
    US0 v186;
    v186 = US0_BitZero();
    USIncref0(&(v186));
    
    UH0 * v187;
    v187 = UH0_RegexChar(v186);
    
    USDecref0(&(v186));
    US0 v188;
    v188 = US0_BitOne();
    USIncref0(&(v188));
    
    UH0 * v189;
    v189 = UH0_RegexChar(v188);
    v187->refc++; v189->refc++;
    USDecref0(&(v188));
    UH0 * v190;
    v190 = UH0_RegexAlt(v187, v189);
    v190->refc++;
    UHDecref0(v187); UHDecref0(v189);
    UH0 * v191;
    v191 = UH0_RegexStar(v190);
    
    UHDecref0(v190);
    US0 v192;
    v192 = US0_BitOne();
    USIncref0(&(v192));
    
    UH0 * v193;
    v193 = UH0_RegexChar(v192);
    
    USDecref0(&(v192));
    US0 v194;
    v194 = US0_BitZero();
    USIncref0(&(v194));
    
    UH0 * v195;
    v195 = UH0_RegexChar(v194);
    
    USDecref0(&(v194));
    US0 v196;
    v196 = US0_BitOne();
    USIncref0(&(v196));
    
    UH0 * v197;
    v197 = UH0_RegexChar(v196);
    v195->refc++; v197->refc++;
    USDecref0(&(v196));
    UH0 * v198;
    v198 = UH0_RegexAlt(v195, v197);
    
    UHDecref0(v195); UHDecref0(v197);
    US0 v199;
    v199 = US0_BitZero();
    USIncref0(&(v199));
    
    UH0 * v200;
    v200 = UH0_RegexChar(v199);
    
    USDecref0(&(v199));
    US0 v201;
    v201 = US0_BitOne();
    USIncref0(&(v201));
    
    UH0 * v202;
    v202 = UH0_RegexChar(v201);
    v200->refc++; v202->refc++;
    USDecref0(&(v201));
    UH0 * v203;
    v203 = UH0_RegexAlt(v200, v202);
    
    UHDecref0(v200); UHDecref0(v202);
    US0 v204;
    v204 = US0_BitZero();
    USIncref0(&(v204));
    
    UH0 * v205;
    v205 = UH0_RegexChar(v204);
    
    USDecref0(&(v204));
    US0 v206;
    v206 = US0_BitOne();
    USIncref0(&(v206));
    
    UH0 * v207;
    v207 = UH0_RegexChar(v206);
    v205->refc++; v207->refc++;
    USDecref0(&(v206));
    UH0 * v208;
    v208 = UH0_RegexAlt(v205, v207);
    v203->refc++; v208->refc++;
    UHDecref0(v205); UHDecref0(v207);
    UH0 * v209;
    v209 = UH0_RegexCat(v203, v208);
    v198->refc++; v209->refc++;
    UHDecref0(v203); UHDecref0(v208);
    UH0 * v210;
    v210 = UH0_RegexCat(v198, v209);
    v193->refc++; v210->refc++;
    UHDecref0(v198); UHDecref0(v209);
    UH0 * v211;
    v211 = UH0_RegexCat(v193, v210);
    v191->refc++; v211->refc++;
    UHDecref0(v193); UHDecref0(v210);
    UH0 * v212;
    v212 = UH0_RegexCat(v191, v211);
    v166->refc++; v167->refc++; v168->refc++; v169->refc++; v170->refc++; v171->refc++; v172->refc++; v212->refc++;
    UHDecref0(v191); UHDecref0(v211);
    int32_t v213;
    v213 = interned_of_regex_raw28(v166, v167, v168, v169, v170, v171, v172, v212);
    
    UHDecref0(v212);
    uint64_t v214;
    v214 = 1ull;
    
    
    int32_t v215;
    v215 = 0l;
    v166->refc++; v167->refc++; v168->refc++; v169->refc++; v170->refc++; v171->refc++; v172->refc++;
    
    int32_t v216;
    v216 = loop32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215);
    
    ArrayDecref0(v166); ArrayDecref0(v167); ArrayDecref0(v168); ArrayDecref0(v169); ArrayDecref0(v170); ArrayDecref0(v171); ArrayDecref0(v172);
    int32_t v217;
    v217 = 16l;
    
    
    Array0 * v218;
    v218 = ArrayCreate0(4096l, false);
    
    
    Array0 * v219;
    v219 = ArrayCreate0(4096l, false);
    
    
    Array0 * v220;
    v220 = ArrayCreate0(4096l, false);
    
    
    Array0 * v221;
    v221 = ArrayCreate0(4096l, false);
    
    
    Array0 * v222;
    v222 = ArrayCreate0(8192l, false);
    
    
    Array0 * v223;
    v223 = ArrayCreate0(8192l, false);
    
    
    Array0 * v224;
    v224 = ArrayCreate0(1l, false);
    
    
    int32_t v225;
    v225 = 0l;
    v222->refc++;
    
    
    loop24(v222, v225);
    
    
    int32_t v226;
    v226 = 0l;
    v223->refc++;
    
    
    loop24(v223, v226);
    
    
    int32_t v227;
    v227 = 0l;
    v224->refc++;
    
    
    loop25(v224, v227);
    
    
    int32_t v228;
    v228 = 0l;
    
    
    int32_t v229;
    v229 = 0l;
    
    
    int32_t v230;
    v230 = 0l;
    v218->refc++; v219->refc++; v220->refc++; v221->refc++; v222->refc++; v223->refc++; v224->refc++;
    
    int32_t v231;
    v231 = interned_node26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230);
    
    
    int32_t v232;
    v232 = 1l;
    
    
    int32_t v233;
    v233 = 0l;
    
    
    int32_t v234;
    v234 = 0l;
    v218->refc++; v219->refc++; v220->refc++; v221->refc++; v222->refc++; v223->refc++; v224->refc++;
    
    int32_t v235;
    v235 = interned_node26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234);
    
    
    bool v236;
    v236 = v231 == 0l;
    
    
    bool v238;
    if (v236){
        
        
        bool v237;
        v237 = v235 == 1l;
        
        
        v238 = v237;
    } else {
        
        
        v238 = false;
    }
    
    
    Array0 * v246; Array0 * v247; Array0 * v248; Array0 * v249; Array0 * v250; Array0 * v251; Array0 * v252;
    if (v238){
        v218->refc++; v219->refc++; v220->refc++; v221->refc++; v222->refc++; v223->refc++; v224->refc++;
        
        v246 = v218; v247 = v219; v248 = v220; v249 = v221; v250 = v222; v251 = v223; v252 = v224;
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-interned-store-init");
        exit(EXIT_FAILURE);
    }
    
    ArrayDecref0(v218); ArrayDecref0(v219); ArrayDecref0(v220); ArrayDecref0(v221); ArrayDecref0(v222); ArrayDecref0(v223); ArrayDecref0(v224);
    US0 v253;
    v253 = US0_BitZero();
    USIncref0(&(v253));
    
    UH0 * v254;
    v254 = UH0_RegexChar(v253);
    
    USDecref0(&(v253));
    US0 v255;
    v255 = US0_BitZero();
    USIncref0(&(v255));
    
    UH0 * v256;
    v256 = UH0_RegexChar(v255);
    
    USDecref0(&(v255));
    US0 v257;
    v257 = US0_BitZero();
    USIncref0(&(v257));
    
    UH0 * v258;
    v258 = UH0_RegexChar(v257);
    v256->refc++; v258->refc++;
    USDecref0(&(v257));
    UH0 * v259;
    v259 = UH0_RegexCat(v256, v258);
    v254->refc++; v259->refc++;
    UHDecref0(v256); UHDecref0(v258);
    UH0 * v260;
    v260 = UH0_RegexAlt(v254, v259);
    v260->refc++;
    UHDecref0(v254); UHDecref0(v259);
    UH0 * v261;
    v261 = UH0_RegexStar(v260);
    
    UHDecref0(v260);
    US0 v262;
    v262 = US0_BitOne();
    USIncref0(&(v262));
    
    UH0 * v263;
    v263 = UH0_RegexChar(v262);
    v261->refc++; v263->refc++;
    USDecref0(&(v262));
    UH0 * v264;
    v264 = UH0_RegexCat(v261, v263);
    v246->refc++; v247->refc++; v248->refc++; v249->refc++; v250->refc++; v251->refc++; v252->refc++; v264->refc++;
    UHDecref0(v261); UHDecref0(v263);
    int32_t v265;
    v265 = interned_of_regex_raw28(v246, v247, v248, v249, v250, v251, v252, v264);
    
    UHDecref0(v264);
    int32_t v266;
    v266 = 1l;
    
    
    int32_t v267;
    v267 = 0l;
    v246->refc++; v247->refc++; v248->refc++; v249->refc++; v250->refc++; v251->refc++; v252->refc++;
    
    int32_t v268;
    v268 = loop36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267);
    
    ArrayDecref0(v246); ArrayDecref0(v247); ArrayDecref0(v248); ArrayDecref0(v249); ArrayDecref0(v250); ArrayDecref0(v251); ArrayDecref0(v252);
    bool v269;
    v269 = v40 == v185;
    
    
    bool v271;
    if (v269){
        
        
        bool v270;
        v270 = v41 == v216;
        
        
        v271 = v270;
    } else {
        
        
        v271 = false;
    }
    
    
    bool v273;
    if (v271){
        
        
        bool v272;
        v272 = v57 == v268;
        
        
        v273 = v272;
    } else {
        
        
        v273 = false;
    }
    
    
    
    if (v273){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-bench-engines-disagree");
        exit(EXIT_FAILURE);
    }
    
    
    bool v274;
    v274 = v57 == 16l;
    
    
    
    if (v274){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-bench-zero-runs-count");
        exit(EXIT_FAILURE);
    }
    
    
    bool v275;
    v275 = v40 == 93l;
    
    
    
    if (v275){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-bench-ends-with-zero-count");
        exit(EXIT_FAILURE);
    }
    
    
    bool v276;
    v276 = v41 == 97l;
    
    
    
    if (v276){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-bench-fourth-from-end-count");
        exit(EXIT_FAILURE);
    }
    
    
    return 0l;
}
