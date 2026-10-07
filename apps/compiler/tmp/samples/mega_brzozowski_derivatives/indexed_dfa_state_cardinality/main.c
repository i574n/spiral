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
typedef struct {
    int tag;
    union {
    };
} US3;
struct UH2 {
    int refc;
    int tag;
    union {
        struct {
            US3 v0;
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
struct UH3 {
    int refc;
    int tag;
    union {
        struct {
            US3 v0;
            UH3 * v1;
        } case1; // InputCons
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
UH0 * UH0_0() { // RegexEmpty
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH0 * UH0_1() { // RegexEpsilon
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
UH0 * UH0_2(US0 v0) { // RegexChar
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0;
    return x;
}
UH0 * UH0_3(UH0 * v0, UH0 * v1) { // RegexAlt
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 3;
    x->refc = 1;
    x->case3.v0 = v0; x->case3.v1 = v1;
    return x;
}
UH0 * UH0_4(UH0 * v0, UH0 * v1) { // RegexCat
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 4;
    x->refc = 1;
    x->case4.v0 = v0; x->case4.v1 = v1;
    return x;
}
UH0 * UH0_5(UH0 * v0) { // RegexStar
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
UH1 * UH1_0() { // InputEmpty
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH1 * UH1_1(US0 v0, UH1 * v1) { // InputCons
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
            v11 = US0_0();
            
            
            v13 = v11;
        } else {
            
            
            US0 v12;
            v12 = US0_1();
            
            
            v13 = v12;
        }
        v2->refc++; USIncref0(&(v13));
        
        UH1 * v14;
        v14 = UH1_1(v13, v2);
        
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
US1 US1_0() { // SymbolLess
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_1() { // SymbolSame
    US1 x;
    x.tag = 1;
    return x;
}
US1 US1_2() { // SymbolGreater
    US1 x;
    x.tag = 2;
    return x;
}
bool run2(int32_t v0, UH1 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US0 v4 = v1->case1.v0; UH1 * v5 = v1->case1.v1;
            USIncref0(&(v4)); v5->refc++;
            UHDecref1(v1);
            bool v6;
            v6 = v0 == 0l;
            
            
            int32_t v19;
            if (v6){
                
                
                US1 v10;
                switch (v4.tag) {
                    case 1: { // BitOne
                        
                        
                        
                        v10 = US1_2();
                        break;
                    }
                    case 0: { // BitZero
                        
                        
                        
                        v10 = US1_1();
                        break;
                    }
                }
                
                
                bool v11;
                switch (v10.tag) {
                    case 1: { // SymbolSame
                        
                        
                        
                        v11 = true;
                        break;
                    }
                    default: {
                        
                        
                        v11 = false;
                    }
                }
                
                USDecref1(&(v10));
                if (v11){
                    
                    
                    v19 = 1l;
                } else {
                    
                    
                    v19 = 0l;
                }
            } else {
                
                
                US1 v16;
                switch (v4.tag) {
                    case 1: { // BitOne
                        
                        
                        
                        v16 = US1_2();
                        break;
                    }
                    case 0: { // BitZero
                        
                        
                        
                        v16 = US1_1();
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
                
                USDecref1(&(v16));
                if (v17){
                    
                    
                    v19 = 1l;
                } else {
                    
                    
                    v19 = 0l;
                }
            }
            
            USDecref0(&(v4));
            return run2(v19, v5);
            break;
        }
        case 0: { // InputEmpty
            
            
            UHDecref1(v1);
            bool v2;
            v2 = v0 == 0l;
            
            
            bool v3;
            v3 = v2 == false;
            
            
            return v3;
            break;
        }
    }
}
US1 regex_compare8(UH0 * v0, UH0 * v1){
    
    
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
                    v57 = regex_compare8(v53, v55);
                    
                    UHDecref0(v53); UHDecref0(v55);
                    switch (v57.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref1(&(v57));
                            return regex_compare8(v54, v56);
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
                    return US1_2();
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
                    v36 = regex_compare8(v28, v34);
                    
                    UHDecref0(v28); UHDecref0(v34);
                    switch (v36.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref1(&(v36));
                            return regex_compare8(v29, v35);
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
                    return US1_2();
                    break;
                }
                case 0: { // RegexEmpty
                    
                    
                    UHDecref0(v1); UHDecref0(v28); UHDecref0(v29);
                    return US1_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref0(v1); UHDecref0(v28); UHDecref0(v29);
                    return US1_2();
                    break;
                }
                default: {
                    
                    UHDecref0(v1); UHDecref0(v28); UHDecref0(v29);
                    return US1_0();
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
                                    return US1_1();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    USDecref0(&(v13));
                                    return US1_2();
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
                                    return US1_0();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    USDecref0(&(v13));
                                    return US1_1();
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
                    return US1_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref0(v1); USDecref0(&(v10));
                    return US1_2();
                    break;
                }
                default: {
                    
                    UHDecref0(v1); USDecref0(&(v10));
                    return US1_0();
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref0(v1);
                    return US1_1();
                    break;
                }
                default: {
                    
                    UHDecref0(v1);
                    return US1_0();
                }
            }
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref0(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref0(v1);
                    return US1_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref0(v1);
                    return US1_1();
                    break;
                }
                default: {
                    
                    UHDecref0(v1);
                    return US1_0();
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
                    return US1_0();
                    break;
                }
                case 5: { // RegexStar
                    UH0 * v48 = v1->case5.v0;
                    v48->refc++;
                    UHDecref0(v1);
                    return regex_compare8(v44, v48);
                    break;
                }
                default: {
                    
                    UHDecref0(v1); UHDecref0(v44);
                    return US1_2();
                }
            }
            break;
        }
    }
}
UH0 * alt_insert_sorted7(UH0 * v0, UH0 * v1){
    
    
    switch (v1->tag) {
        case 3: { // RegexAlt
            UH0 * v2 = v1->case3.v0; UH0 * v3 = v1->case3.v1;
            v0->refc++; v2->refc += 2; v3->refc++;
            
            US1 v4;
            v4 = regex_compare8(v0, v2);
            
            
            switch (v4.tag) {
                case 2: { // SymbolGreater
                    
                    v0->refc++; v3->refc++;
                    UHDecref0(v1); USDecref1(&(v4));
                    UH0 * v6;
                    v6 = alt_insert_sorted7(v0, v3);
                    
                    UHDecref0(v0); UHDecref0(v3);
                    return UH0_3(v2, v6);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    UHDecref0(v2); UHDecref0(v3); USDecref1(&(v4));
                    return UH0_3(v0, v1);
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
            v11 = regex_compare8(v0, v1);
            
            
            switch (v11.tag) {
                case 2: { // SymbolGreater
                    
                    
                    USDecref1(&(v11));
                    return UH0_3(v1, v0);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    USDecref1(&(v11));
                    return UH0_3(v0, v1);
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
UH0 * make_alt6(UH0 * v0, UH0 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH0 * v2 = v0->case3.v0; UH0 * v3 = v0->case3.v1;
            v1->refc++; v2->refc += 2; v3->refc++;
            UHDecref0(v0);
            UH0 * v4;
            v4 = alt_insert_sorted7(v2, v1);
            
            UHDecref0(v1); UHDecref0(v2);
            return make_alt6(v3, v4);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0);
            return v1;
            break;
        }
        default: {
            
            
            return alt_insert_sorted7(v0, v1);
        }
    }
}
bool regex_equal10(UH0 * v0, UH0 * v1){
    
    
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
                    v22 = regex_equal10(v18, v20);
                    
                    UHDecref0(v18); UHDecref0(v20);
                    if (v22){
                        
                        
                        return regex_equal10(v19, v21);
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
                    v30 = regex_equal10(v26, v28);
                    
                    UHDecref0(v26); UHDecref0(v28);
                    if (v30){
                        
                        
                        return regex_equal10(v27, v29);
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
                                    
                                    
                                    
                                    v15 = US1_1();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    
                                    v15 = US1_2();
                                    break;
                                }
                            }
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            
                            switch (v5.tag) {
                                case 1: { // BitOne
                                    
                                    
                                    
                                    v15 = US1_0();
                                    break;
                                }
                                case 0: { // BitZero
                                    
                                    
                                    
                                    v15 = US1_1();
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
                    return regex_equal10(v34, v35);
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
UH0 * make_cat9(UH0 * v0, UH0 * v1){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0); UHDecref0(v1);
            return UH0_0();
            break;
        }
        default: {
            
            
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref0(v0); UHDecref0(v1);
                    return UH0_0();
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
                                            v14 = make_cat9(v13, v1);
                                            
                                            UHDecref0(v1); UHDecref0(v13);
                                            return UH0_4(v12, v14);
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
                                                    v6 = regex_equal10(v4, v5);
                                                    
                                                    UHDecref0(v5);
                                                    if (v6){
                                                        
                                                        UHDecref0(v0); UHDecref0(v1);
                                                        return UH0_5(v4);
                                                    } else {
                                                        
                                                        UHDecref0(v4);
                                                        return UH0_4(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    
                                                    UHDecref0(v4);
                                                    return UH0_4(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            
                                            
                                            return UH0_4(v0, v1);
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
UH0 * make_star11(UH0 * v0){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0);
            return UH0_1();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref0(v0);
            return UH0_1();
            break;
        }
        case 5: { // RegexStar
            UH0 * v3 = v0->case5.v0;
            v3->refc++;
            UHDecref0(v0);
            return UH0_5(v3);
            break;
        }
        default: {
            
            
            return UH0_5(v0);
        }
    }
}
UH0 * normalize5(UH0 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH0 * v5 = v0->case3.v0; UH0 * v6 = v0->case3.v1;
            v5->refc += 2; v6->refc++;
            UHDecref0(v0);
            UH0 * v7;
            v7 = normalize5(v5);
            v6->refc++;
            UHDecref0(v5);
            UH0 * v8;
            v8 = normalize5(v6);
            
            UHDecref0(v6);
            return make_alt6(v7, v8);
            break;
        }
        case 4: { // RegexCat
            UH0 * v10 = v0->case4.v0; UH0 * v11 = v0->case4.v1;
            v10->refc += 2; v11->refc++;
            UHDecref0(v0);
            UH0 * v12;
            v12 = normalize5(v10);
            v11->refc++;
            UHDecref0(v10);
            UH0 * v13;
            v13 = normalize5(v11);
            
            UHDecref0(v11);
            return make_cat9(v12, v13);
            break;
        }
        case 2: { // RegexChar
            US0 v3 = v0->case2.v0;
            USIncref0(&(v3));
            UHDecref0(v0);
            return UH0_2(v3);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0);
            return UH0_0();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref0(v0);
            return UH0_1();
            break;
        }
        case 5: { // RegexStar
            UH0 * v15 = v0->case5.v0;
            v15->refc += 2;
            UHDecref0(v0);
            UH0 * v16;
            v16 = normalize5(v15);
            
            UHDecref0(v15);
            return make_star11(v16);
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
US2 US2_0() { // Nullable
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_1() { // NonNullable
    US2 x;
    x.tag = 1;
    return x;
}
US2 nullable13(UH0 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH0 * v5 = v0->case3.v0; UH0 * v6 = v0->case3.v1;
            v5->refc += 2; v6->refc++;
            UHDecref0(v0);
            US2 v7;
            v7 = nullable13(v5);
            v6->refc++;
            UHDecref0(v5);
            US2 v8;
            v8 = nullable13(v6);
            
            UHDecref0(v6);
            switch (v7.tag) {
                case 0: { // Nullable
                    
                    
                    USDecref2(&(v7)); USDecref2(&(v8));
                    return US2_0();
                    break;
                }
                default: {
                    
                    
                    switch (v8.tag) {
                        case 0: { // Nullable
                            
                            
                            USDecref2(&(v7)); USDecref2(&(v8));
                            return US2_0();
                            break;
                        }
                        default: {
                            
                            
                            switch (v7.tag) {
                                case 1: { // NonNullable
                                    
                                    
                                    USDecref2(&(v7));
                                    switch (v8.tag) {
                                        case 1: { // NonNullable
                                            
                                            
                                            USDecref2(&(v8));
                                            return US2_1();
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
            v18 = nullable13(v16);
            v17->refc++;
            UHDecref0(v16);
            US2 v19;
            v19 = nullable13(v17);
            
            UHDecref0(v17);
            switch (v18.tag) {
                case 0: { // Nullable
                    
                    
                    USDecref2(&(v18));
                    switch (v19.tag) {
                        case 0: { // Nullable
                            
                            
                            USDecref2(&(v19));
                            return US2_0();
                            break;
                        }
                        default: {
                            
                            USDecref2(&(v19));
                            return US2_1();
                        }
                    }
                    break;
                }
                default: {
                    
                    USDecref2(&(v18)); USDecref2(&(v19));
                    return US2_1();
                }
            }
            break;
        }
        case 2: { // RegexChar
            
            
            UHDecref0(v0);
            return US2_1();
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0);
            return US2_1();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref0(v0);
            return US2_0();
            break;
        }
        case 5: { // RegexStar
            
            
            UHDecref0(v0);
            return US2_0();
            break;
        }
    }
}
UH0 * derivative12(UH0 * v0, US0 v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH0 * v19 = v0->case3.v0; UH0 * v20 = v0->case3.v1;
            USIncref0(&(v1)); v19->refc += 2; v20->refc++;
            UHDecref0(v0);
            UH0 * v21;
            v21 = derivative12(v19, v1);
            USIncref0(&(v1)); v20->refc++;
            UHDecref0(v19);
            UH0 * v22;
            v22 = derivative12(v20, v1);
            
            USDecref0(&(v1)); UHDecref0(v20);
            return make_alt6(v21, v22);
            break;
        }
        case 4: { // RegexCat
            UH0 * v24 = v0->case4.v0; UH0 * v25 = v0->case4.v1;
            v24->refc += 2; v25->refc++;
            UHDecref0(v0);
            US2 v26;
            v26 = nullable13(v24);
            
            
            switch (v26.tag) {
                case 1: { // NonNullable
                    
                    USIncref0(&(v1)); v24->refc++;
                    USDecref2(&(v26));
                    UH0 * v31;
                    v31 = derivative12(v24, v1);
                    
                    USDecref0(&(v1)); UHDecref0(v24);
                    return make_cat9(v31, v25);
                    break;
                }
                case 0: { // Nullable
                    
                    USIncref0(&(v1)); v24->refc++;
                    USDecref2(&(v26));
                    UH0 * v27;
                    v27 = derivative12(v24, v1);
                    v25->refc++; v27->refc++;
                    UHDecref0(v24);
                    UH0 * v28;
                    v28 = make_cat9(v27, v25);
                    USIncref0(&(v1)); v25->refc++;
                    UHDecref0(v27);
                    UH0 * v29;
                    v29 = derivative12(v25, v1);
                    
                    USDecref0(&(v1)); UHDecref0(v25);
                    return make_alt6(v28, v29);
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
                            
                            
                            
                            v14 = US1_1();
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            
                            v14 = US1_2();
                            break;
                        }
                    }
                    break;
                }
                case 0: { // BitZero
                    
                    
                    
                    switch (v1.tag) {
                        case 1: { // BitOne
                            
                            
                            
                            v14 = US1_0();
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            
                            v14 = US1_1();
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
                
                
                return UH0_1();
            } else {
                
                
                return UH0_0();
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref0(v0); USDecref0(&(v1));
            return UH0_0();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref0(v0); USDecref0(&(v1));
            return UH0_0();
            break;
        }
        case 5: { // RegexStar
            UH0 * v35 = v0->case5.v0;
            USIncref0(&(v1)); v35->refc += 2;
            UHDecref0(v0);
            UH0 * v36;
            v36 = derivative12(v35, v1);
            v35->refc++;
            USDecref0(&(v1));
            UH0 * v37;
            v37 = make_star11(v35);
            
            UHDecref0(v35);
            return make_cat9(v36, v37);
            break;
        }
    }
}
UH0 * canonical_derivative4(UH0 * v0, US0 v1){
    v0->refc++;
    
    UH0 * v2;
    v2 = normalize5(v0);
    USIncref0(&(v1)); v2->refc++;
    UHDecref0(v0);
    UH0 * v3;
    v3 = derivative12(v2, v1);
    
    USDecref0(&(v1)); UHDecref0(v2);
    return normalize5(v3);
}
bool accepts3(UH0 * v0, UH1 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US0 v6 = v1->case1.v0; UH1 * v7 = v1->case1.v1;
            v0->refc++; USIncref0(&(v6));USIncref0(&(v6)); v7->refc++;
            UHDecref1(v1);
            UH0 * v8;
            v8 = canonical_derivative4(v0, v6);
            
            UHDecref0(v0); USDecref0(&(v6));
            return accepts3(v8, v7);
            break;
        }
        case 0: { // InputEmpty
            
            v0->refc++;
            UHDecref1(v1);
            UH0 * v2;
            v2 = normalize5(v0);
            v2->refc++;
            UHDecref0(v0);
            US2 v3;
            v3 = nullable13(v2);
            
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
int32_t loop0(int32_t v0, UH0 * v1, int32_t v2, uint64_t v3, int32_t v4){
    
    
    bool v5;
    v5 = 0l < v2;
    
    
    if (v5){
        
        
        UH1 * v6;
        v6 = UH1_0();
        v6->refc++;
        
        UH1 * v7; uint64_t v8;
        Tuple0 tmp0 = random_bit_input1(v3, v0, v6);
        v7 = tmp0.v0; v8 = tmp0.v1;
        
        UHDecref1(v6);
        int32_t v9;
        v9 = 0l;
        v7->refc++;
        
        bool v10;
        v10 = run2(v9, v7);
        v1->refc++; v7->refc++;
        
        bool v11;
        v11 = accepts3(v1, v7);
        
        UHDecref1(v7);
        bool v13;
        if (v10){
            
            
            v13 = v11;
        } else {
            
            
            bool v12;
            v12 = false == v11;
            
            
            v13 = v12;
        }
        
        
        if (v13){
            
            
            int32_t v14;
            v14 = v2 - 1l;
            
            
            int32_t v16;
            if (v10){
                
                
                int32_t v15;
                v15 = v4 + 1l;
                
                
                v16 = v15;
            } else {
                
                
                v16 = v4;
            }
            
            
            return loop0(v0, v1, v14, v8, v16);
        } else {
            
            UHDecref0(v1);
            fprintf(stderr, "%s\n", "brzozowski-compiled-core-disagrees-on-random-input");
            exit(EXIT_FAILURE);
        }
    } else {
        
        UHDecref0(v1);
        return v4;
    }
}
UH1 * zeros_input15(int32_t v0, UH1 * v1){
    
    
    bool v2;
    v2 = 0l < v0;
    
    
    if (v2){
        
        
        int32_t v3;
        v3 = v0 - 1l;
        
        
        US0 v4;
        v4 = US0_0();
        v1->refc++; USIncref0(&(v4));
        
        UH1 * v5;
        v5 = UH1_1(v4, v1);
        
        UHDecref1(v1); USDecref0(&(v4));
        return zeros_input15(v3, v5);
    } else {
        
        
        return v1;
    }
}
bool run16(int32_t v0, UH1 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US0 v5 = v1->case1.v0; UH1 * v6 = v1->case1.v1;
            USIncref0(&(v5)); v6->refc++;
            UHDecref1(v1);
            bool v7;
            v7 = v0 == 0l;
            
            
            int32_t v26;
            if (v7){
                
                
                US1 v11;
                switch (v5.tag) {
                    case 1: { // BitOne
                        
                        
                        
                        v11 = US1_2();
                        break;
                    }
                    case 0: { // BitZero
                        
                        
                        
                        v11 = US1_1();
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
                
                USDecref1(&(v11));
                v26 = 1l;
            } else {
                
                
                bool v13;
                v13 = v0 == 1l;
                
                
                if (v13){
                    
                    
                    US1 v17;
                    switch (v5.tag) {
                        case 1: { // BitOne
                            
                            
                            
                            v17 = US1_2();
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            
                            v17 = US1_1();
                            break;
                        }
                    }
                    
                    
                    bool v18;
                    switch (v17.tag) {
                        case 1: { // SymbolSame
                            
                            
                            
                            v18 = true;
                            break;
                        }
                        default: {
                            
                            
                            v18 = false;
                        }
                    }
                    
                    USDecref1(&(v17));
                    v26 = 1l;
                } else {
                    
                    
                    US1 v22;
                    switch (v5.tag) {
                        case 1: { // BitOne
                            
                            
                            
                            v22 = US1_2();
                            break;
                        }
                        case 0: { // BitZero
                            
                            
                            
                            v22 = US1_1();
                            break;
                        }
                    }
                    
                    
                    bool v23;
                    switch (v22.tag) {
                        case 1: { // SymbolSame
                            
                            
                            
                            v23 = true;
                            break;
                        }
                        default: {
                            
                            
                            v23 = false;
                        }
                    }
                    
                    USDecref1(&(v22));
                    if (v23){
                        
                        
                        v26 = 2l;
                    } else {
                        
                        
                        v26 = 0l;
                    }
                }
            }
            
            USDecref0(&(v5));
            return run16(v26, v6);
            break;
        }
        case 0: { // InputEmpty
            
            
            UHDecref1(v1);
            bool v2;
            v2 = v0 == 0l;
            
            
            if (v2){
                
                
                return true;
            } else {
                
                
                bool v3;
                v3 = v0 == 1l;
                
                
                return false;
            }
            break;
        }
    }
}
int32_t loop14(int32_t v0, UH0 * v1, int32_t v2, int32_t v3){
    
    
    bool v4;
    v4 = v0 < v2;
    
    
    if (v4){
        
        UHDecref0(v1);
        return v3;
    } else {
        
        
        UH1 * v5;
        v5 = UH1_0();
        v5->refc++;
        
        UH1 * v6;
        v6 = zeros_input15(v2, v5);
        
        UHDecref1(v5);
        int32_t v7;
        v7 = 2l;
        v6->refc++;
        
        bool v8;
        v8 = run16(v7, v6);
        v1->refc++; v6->refc++;
        
        bool v9;
        v9 = accepts3(v1, v6);
        
        UHDecref1(v6);
        bool v11;
        if (v8){
            
            
            v11 = v9;
        } else {
            
            
            bool v10;
            v10 = false == v9;
            
            
            v11 = v10;
        }
        
        
        int32_t v15;
        if (v11){
            
            
            if (v8){
                
                
                int32_t v12;
                v12 = v3 + 1l;
                
                
                v15 = v12;
            } else {
                
                
                v15 = v3;
            }
        } else {
            
            
            fprintf(stderr, "%s\n", "brzozowski-compiled-core-disagrees-on-zero-run");
            exit(EXIT_FAILURE);
        }
        
        
        US0 v16;
        v16 = US0_1();
        
        
        UH1 * v17;
        v17 = UH1_0();
        USIncref0(&(v16)); v17->refc++;
        
        UH1 * v18;
        v18 = UH1_1(v16, v17);
        v18->refc++;
        USDecref0(&(v16)); UHDecref1(v17);
        UH1 * v19;
        v19 = zeros_input15(v2, v18);
        
        UHDecref1(v18);
        int32_t v20;
        v20 = 2l;
        v19->refc++;
        
        bool v21;
        v21 = run16(v20, v19);
        v1->refc++; v19->refc++;
        
        bool v22;
        v22 = accepts3(v1, v19);
        
        UHDecref1(v19);
        bool v24;
        if (v21){
            
            
            v24 = v22;
        } else {
            
            
            bool v23;
            v23 = false == v22;
            
            
            v24 = v23;
        }
        
        
        int32_t v28;
        if (v24){
            
            
            if (v21){
                
                
                int32_t v25;
                v25 = v15 + 1l;
                
                
                v28 = v25;
            } else {
                
                
                v28 = v15;
            }
        } else {
            
            
            fprintf(stderr, "%s\n", "brzozowski-compiled-core-disagrees-on-zero-run");
            exit(EXIT_FAILURE);
        }
        
        
        int32_t v29;
        v29 = v2 + 1l;
        
        
        return loop14(v0, v1, v29, v28);
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
US3 US3_0() { // TriA
    US3 x;
    x.tag = 0;
    return x;
}
US3 US3_1() { // TriB
    US3 x;
    x.tag = 1;
    return x;
}
US3 US3_2() { // TriC
    US3 x;
    x.tag = 2;
    return x;
}
static inline void UHDecrefBody2(UH2 * x){
    switch (x->tag) {
        case 2: {
            USDecref3(&(x->case2.v0));
            break;
        }
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
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody2(x); free(x); }
}
UH2 * UH2_0() { // RegexEmpty
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH2 * UH2_1() { // RegexEpsilon
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 1;
    x->refc = 1;
    return x;
}
UH2 * UH2_2(US3 v0) { // RegexChar
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0;
    return x;
}
UH2 * UH2_3(UH2 * v0, UH2 * v1) { // RegexAlt
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 3;
    x->refc = 1;
    x->case3.v0 = v0; x->case3.v1 = v1;
    return x;
}
UH2 * UH2_4(UH2 * v0, UH2 * v1) { // RegexCat
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 4;
    x->refc = 1;
    x->case4.v0 = v0; x->case4.v1 = v1;
    return x;
}
UH2 * UH2_5(UH2 * v0) { // RegexStar
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 5;
    x->refc = 1;
    x->case5.v0 = v0;
    return x;
}
static inline void UHDecrefBody3(UH3 * x){
    switch (x->tag) {
        case 1: {
            USDecref3(&(x->case1.v0)); UHDecref3(x->case1.v1);
            break;
        }
    }
}
void UHDecref3(UH3 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody3(x); free(x); }
}
UH3 * UH3_0() { // InputEmpty
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH3 * UH3_1(US3 v0, UH3 * v1) { // InputCons
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
bool run17(int32_t v0, UH3 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US3 v5 = v1->case1.v0; UH3 * v6 = v1->case1.v1;
            USIncref3(&(v5)); v6->refc++;
            UHDecref3(v1);
            bool v7;
            v7 = v0 == 0l;
            
            
            int32_t v47;
            if (v7){
                
                
                US1 v10;
                switch (v5.tag) {
                    case 0: { // TriA
                        
                        
                        
                        v10 = US1_1();
                        break;
                    }
                    default: {
                        
                        
                        v10 = US1_2();
                    }
                }
                
                
                bool v11;
                switch (v10.tag) {
                    case 1: { // SymbolSame
                        
                        
                        
                        v11 = true;
                        break;
                    }
                    default: {
                        
                        
                        v11 = false;
                    }
                }
                
                USDecref1(&(v10));
                if (v11){
                    
                    
                    v47 = 0l;
                } else {
                    
                    
                    US1 v17;
                    switch (v5.tag) {
                        case 0: { // TriA
                            
                            
                            
                            v17 = US1_0();
                            break;
                        }
                        case 1: { // TriB
                            
                            
                            
                            v17 = US1_1();
                            break;
                        }
                        case 2: { // TriC
                            
                            
                            
                            v17 = US1_2();
                            break;
                        }
                    }
                    
                    
                    bool v18;
                    switch (v17.tag) {
                        case 1: { // SymbolSame
                            
                            
                            
                            v18 = true;
                            break;
                        }
                        default: {
                            
                            
                            v18 = false;
                        }
                    }
                    
                    USDecref1(&(v17));
                    if (v18){
                        
                        
                        v47 = 0l;
                    } else {
                        
                        
                        v47 = 1l;
                    }
                }
            } else {
                
                
                bool v21;
                v21 = v0 == 1l;
                
                
                if (v21){
                    
                    
                    US1 v24;
                    switch (v5.tag) {
                        case 0: { // TriA
                            
                            
                            
                            v24 = US1_1();
                            break;
                        }
                        default: {
                            
                            
                            v24 = US1_2();
                        }
                    }
                    
                    
                    bool v25;
                    switch (v24.tag) {
                        case 1: { // SymbolSame
                            
                            
                            
                            v25 = true;
                            break;
                        }
                        default: {
                            
                            
                            v25 = false;
                        }
                    }
                    
                    USDecref1(&(v24));
                    if (v25){
                        
                        
                        v47 = 2l;
                    } else {
                        
                        
                        US1 v31;
                        switch (v5.tag) {
                            case 0: { // TriA
                                
                                
                                
                                v31 = US1_0();
                                break;
                            }
                            case 1: { // TriB
                                
                                
                                
                                v31 = US1_1();
                                break;
                            }
                            case 2: { // TriC
                                
                                
                                
                                v31 = US1_2();
                                break;
                            }
                        }
                        
                        
                        bool v32;
                        switch (v31.tag) {
                            case 1: { // SymbolSame
                                
                                
                                
                                v32 = true;
                                break;
                            }
                            default: {
                                
                                
                                v32 = false;
                            }
                        }
                        
                        USDecref1(&(v31));
                        v47 = 2l;
                    }
                } else {
                    
                    
                    US1 v36;
                    switch (v5.tag) {
                        case 0: { // TriA
                            
                            
                            
                            v36 = US1_1();
                            break;
                        }
                        default: {
                            
                            
                            v36 = US1_2();
                        }
                    }
                    
                    
                    bool v37;
                    switch (v36.tag) {
                        case 1: { // SymbolSame
                            
                            
                            
                            v37 = true;
                            break;
                        }
                        default: {
                            
                            
                            v37 = false;
                        }
                    }
                    
                    USDecref1(&(v36));
                    if (v37){
                        
                        
                        v47 = 2l;
                    } else {
                        
                        
                        US1 v43;
                        switch (v5.tag) {
                            case 0: { // TriA
                                
                                
                                
                                v43 = US1_0();
                                break;
                            }
                            case 1: { // TriB
                                
                                
                                
                                v43 = US1_1();
                                break;
                            }
                            case 2: { // TriC
                                
                                
                                
                                v43 = US1_2();
                                break;
                            }
                        }
                        
                        
                        bool v44;
                        switch (v43.tag) {
                            case 1: { // SymbolSame
                                
                                
                                
                                v44 = true;
                                break;
                            }
                            default: {
                                
                                
                                v44 = false;
                            }
                        }
                        
                        USDecref1(&(v43));
                        v47 = 2l;
                    }
                }
            }
            
            USDecref3(&(v5));
            return run17(v47, v6);
            break;
        }
        case 0: { // InputEmpty
            
            
            UHDecref3(v1);
            bool v2;
            v2 = v0 == 0l;
            
            
            if (v2){
                
                
                return false;
            } else {
                
                
                bool v3;
                v3 = v0 == 1l;
                
                
                return v3;
            }
            break;
        }
    }
}
US1 regex_compare23(UH2 * v0, UH2 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH2 * v59 = v0->case3.v0; UH2 * v60 = v0->case3.v1;
            v59->refc++; v60->refc++;
            UHDecref2(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    UH2 * v61 = v1->case3.v0; UH2 * v62 = v1->case3.v1;
                    v59->refc++; v61->refc += 2; v62->refc++;
                    UHDecref2(v1);
                    US1 v63;
                    v63 = regex_compare23(v59, v61);
                    
                    UHDecref2(v59); UHDecref2(v61);
                    switch (v63.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref1(&(v63));
                            return regex_compare23(v60, v62);
                            break;
                        }
                        default: {
                            
                            UHDecref2(v60); UHDecref2(v62);
                            return v63;
                        }
                    }
                    break;
                }
                default: {
                    
                    UHDecref2(v1); UHDecref2(v59); UHDecref2(v60);
                    return US1_2();
                }
            }
            break;
        }
        case 4: { // RegexCat
            UH2 * v34 = v0->case4.v0; UH2 * v35 = v0->case4.v1;
            v34->refc++; v35->refc++;
            UHDecref2(v0);
            switch (v1->tag) {
                case 4: { // RegexCat
                    UH2 * v40 = v1->case4.v0; UH2 * v41 = v1->case4.v1;
                    v34->refc++; v40->refc += 2; v41->refc++;
                    UHDecref2(v1);
                    US1 v42;
                    v42 = regex_compare23(v34, v40);
                    
                    UHDecref2(v34); UHDecref2(v40);
                    switch (v42.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref1(&(v42));
                            return regex_compare23(v35, v41);
                            break;
                        }
                        default: {
                            
                            UHDecref2(v35); UHDecref2(v41);
                            return v42;
                        }
                    }
                    break;
                }
                case 2: { // RegexChar
                    
                    
                    UHDecref2(v1); UHDecref2(v34); UHDecref2(v35);
                    return US1_2();
                    break;
                }
                case 0: { // RegexEmpty
                    
                    
                    UHDecref2(v1); UHDecref2(v34); UHDecref2(v35);
                    return US1_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref2(v1); UHDecref2(v34); UHDecref2(v35);
                    return US1_2();
                    break;
                }
                default: {
                    
                    UHDecref2(v1); UHDecref2(v34); UHDecref2(v35);
                    return US1_0();
                }
            }
            break;
        }
        case 2: { // RegexChar
            US3 v10 = v0->case2.v0;
            USIncref3(&(v10));
            UHDecref2(v0);
            switch (v1->tag) {
                case 2: { // RegexChar
                    US3 v13 = v1->case2.v0;
                    USIncref3(&(v13));
                    UHDecref2(v1);
                    switch (v10.tag) {
                        case 0: { // TriA
                            
                            
                            USDecref3(&(v10));
                            switch (v13.tag) {
                                case 0: { // TriA
                                    
                                    
                                    USDecref3(&(v13));
                                    return US1_1();
                                    break;
                                }
                                default: {
                                    
                                    USDecref3(&(v13));
                                    return US1_0();
                                }
                            }
                            break;
                        }
                        default: {
                            
                            
                            switch (v13.tag) {
                                case 0: { // TriA
                                    
                                    
                                    USDecref3(&(v10)); USDecref3(&(v13));
                                    return US1_2();
                                    break;
                                }
                                default: {
                                    
                                    
                                    switch (v10.tag) {
                                        case 1: { // TriB
                                            
                                            
                                            USDecref3(&(v10));
                                            switch (v13.tag) {
                                                case 1: { // TriB
                                                    
                                                    
                                                    USDecref3(&(v13));
                                                    return US1_1();
                                                    break;
                                                }
                                                case 2: { // TriC
                                                    
                                                    
                                                    USDecref3(&(v13));
                                                    return US1_0();
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                        case 2: { // TriC
                                            
                                            
                                            USDecref3(&(v10));
                                            switch (v13.tag) {
                                                case 1: { // TriB
                                                    
                                                    
                                                    USDecref3(&(v13));
                                                    return US1_2();
                                                    break;
                                                }
                                                case 2: { // TriC
                                                    
                                                    
                                                    USDecref3(&(v13));
                                                    return US1_1();
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
                    
                    
                    UHDecref2(v1); USDecref3(&(v10));
                    return US1_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref2(v1); USDecref3(&(v10));
                    return US1_2();
                    break;
                }
                default: {
                    
                    UHDecref2(v1); USDecref3(&(v10));
                    return US1_0();
                }
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref2(v1);
                    return US1_1();
                    break;
                }
                default: {
                    
                    UHDecref2(v1);
                    return US1_0();
                }
            }
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref2(v0);
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref2(v1);
                    return US1_2();
                    break;
                }
                case 1: { // RegexEpsilon
                    
                    
                    UHDecref2(v1);
                    return US1_1();
                    break;
                }
                default: {
                    
                    UHDecref2(v1);
                    return US1_0();
                }
            }
            break;
        }
        case 5: { // RegexStar
            UH2 * v50 = v0->case5.v0;
            v50->refc++;
            UHDecref2(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    
                    
                    UHDecref2(v1); UHDecref2(v50);
                    return US1_0();
                    break;
                }
                case 5: { // RegexStar
                    UH2 * v54 = v1->case5.v0;
                    v54->refc++;
                    UHDecref2(v1);
                    return regex_compare23(v50, v54);
                    break;
                }
                default: {
                    
                    UHDecref2(v1); UHDecref2(v50);
                    return US1_2();
                }
            }
            break;
        }
    }
}
UH2 * alt_insert_sorted22(UH2 * v0, UH2 * v1){
    
    
    switch (v1->tag) {
        case 3: { // RegexAlt
            UH2 * v2 = v1->case3.v0; UH2 * v3 = v1->case3.v1;
            v0->refc++; v2->refc += 2; v3->refc++;
            
            US1 v4;
            v4 = regex_compare23(v0, v2);
            
            
            switch (v4.tag) {
                case 2: { // SymbolGreater
                    
                    v0->refc++; v3->refc++;
                    UHDecref2(v1); USDecref1(&(v4));
                    UH2 * v6;
                    v6 = alt_insert_sorted22(v0, v3);
                    
                    UHDecref2(v0); UHDecref2(v3);
                    return UH2_3(v2, v6);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    UHDecref2(v2); UHDecref2(v3); USDecref1(&(v4));
                    return UH2_3(v0, v1);
                    break;
                }
                case 1: { // SymbolSame
                    
                    
                    UHDecref2(v0); UHDecref2(v2); UHDecref2(v3); USDecref1(&(v4));
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
            v0->refc++; v1->refc++;
            
            US1 v11;
            v11 = regex_compare23(v0, v1);
            
            
            switch (v11.tag) {
                case 2: { // SymbolGreater
                    
                    
                    USDecref1(&(v11));
                    return UH2_3(v1, v0);
                    break;
                }
                case 0: { // SymbolLess
                    
                    
                    USDecref1(&(v11));
                    return UH2_3(v0, v1);
                    break;
                }
                case 1: { // SymbolSame
                    
                    
                    UHDecref2(v0); USDecref1(&(v11));
                    return v1;
                    break;
                }
            }
        }
    }
}
UH2 * make_alt21(UH2 * v0, UH2 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH2 * v2 = v0->case3.v0; UH2 * v3 = v0->case3.v1;
            v1->refc++; v2->refc += 2; v3->refc++;
            UHDecref2(v0);
            UH2 * v4;
            v4 = alt_insert_sorted22(v2, v1);
            
            UHDecref2(v1); UHDecref2(v2);
            return make_alt21(v3, v4);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0);
            return v1;
            break;
        }
        default: {
            
            
            return alt_insert_sorted22(v0, v1);
        }
    }
}
bool regex_equal25(UH2 * v0, UH2 * v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH2 * v24 = v0->case3.v0; UH2 * v25 = v0->case3.v1;
            v24->refc++; v25->refc++;
            UHDecref2(v0);
            switch (v1->tag) {
                case 3: { // RegexAlt
                    UH2 * v26 = v1->case3.v0; UH2 * v27 = v1->case3.v1;
                    v24->refc++; v26->refc += 2; v27->refc++;
                    UHDecref2(v1);
                    bool v28;
                    v28 = regex_equal25(v24, v26);
                    
                    UHDecref2(v24); UHDecref2(v26);
                    if (v28){
                        
                        
                        return regex_equal25(v25, v27);
                    } else {
                        
                        UHDecref2(v25); UHDecref2(v27);
                        return false;
                    }
                    break;
                }
                default: {
                    
                    UHDecref2(v1); UHDecref2(v24); UHDecref2(v25);
                    return false;
                }
            }
            break;
        }
        case 4: { // RegexCat
            UH2 * v32 = v0->case4.v0; UH2 * v33 = v0->case4.v1;
            v32->refc++; v33->refc++;
            UHDecref2(v0);
            switch (v1->tag) {
                case 4: { // RegexCat
                    UH2 * v34 = v1->case4.v0; UH2 * v35 = v1->case4.v1;
                    v32->refc++; v34->refc += 2; v35->refc++;
                    UHDecref2(v1);
                    bool v36;
                    v36 = regex_equal25(v32, v34);
                    
                    UHDecref2(v32); UHDecref2(v34);
                    if (v36){
                        
                        
                        return regex_equal25(v33, v35);
                    } else {
                        
                        UHDecref2(v33); UHDecref2(v35);
                        return false;
                    }
                    break;
                }
                default: {
                    
                    UHDecref2(v1); UHDecref2(v32); UHDecref2(v33);
                    return false;
                }
            }
            break;
        }
        case 2: { // RegexChar
            US3 v4 = v0->case2.v0;
            USIncref3(&(v4));
            UHDecref2(v0);
            switch (v1->tag) {
                case 2: { // RegexChar
                    US3 v5 = v1->case2.v0;
                    USIncref3(&(v5));
                    UHDecref2(v1);
                    US1 v21;
                    switch (v4.tag) {
                        case 0: { // TriA
                            
                            
                            
                            switch (v5.tag) {
                                case 0: { // TriA
                                    
                                    
                                    
                                    v21 = US1_1();
                                    break;
                                }
                                default: {
                                    
                                    
                                    v21 = US1_0();
                                }
                            }
                            break;
                        }
                        default: {
                            
                            
                            switch (v5.tag) {
                                case 0: { // TriA
                                    
                                    
                                    
                                    v21 = US1_2();
                                    break;
                                }
                                default: {
                                    
                                    
                                    switch (v4.tag) {
                                        case 1: { // TriB
                                            
                                            
                                            
                                            switch (v5.tag) {
                                                case 1: { // TriB
                                                    
                                                    
                                                    
                                                    v21 = US1_1();
                                                    break;
                                                }
                                                case 2: { // TriC
                                                    
                                                    
                                                    
                                                    v21 = US1_0();
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                        case 2: { // TriC
                                            
                                            
                                            
                                            switch (v5.tag) {
                                                case 1: { // TriB
                                                    
                                                    
                                                    
                                                    v21 = US1_2();
                                                    break;
                                                }
                                                case 2: { // TriC
                                                    
                                                    
                                                    
                                                    v21 = US1_1();
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
                    
                    USDecref3(&(v4)); USDecref3(&(v5));
                    switch (v21.tag) {
                        case 1: { // SymbolSame
                            
                            
                            USDecref1(&(v21));
                            return true;
                            break;
                        }
                        default: {
                            
                            USDecref1(&(v21));
                            return false;
                        }
                    }
                    break;
                }
                default: {
                    
                    UHDecref2(v1); USDecref3(&(v4));
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
        case 5: { // RegexStar
            UH2 * v40 = v0->case5.v0;
            v40->refc++;
            UHDecref2(v0);
            switch (v1->tag) {
                case 5: { // RegexStar
                    UH2 * v41 = v1->case5.v0;
                    v41->refc++;
                    UHDecref2(v1);
                    return regex_equal25(v40, v41);
                    break;
                }
                default: {
                    
                    UHDecref2(v1); UHDecref2(v40);
                    return false;
                }
            }
            break;
        }
    }
}
UH2 * make_cat24(UH2 * v0, UH2 * v1){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0); UHDecref2(v1);
            return UH2_0();
            break;
        }
        default: {
            
            
            switch (v1->tag) {
                case 0: { // RegexEmpty
                    
                    
                    UHDecref2(v0); UHDecref2(v1);
                    return UH2_0();
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
                                            v1->refc++; v12->refc++; v13->refc += 2;
                                            UHDecref2(v0);
                                            UH2 * v14;
                                            v14 = make_cat24(v13, v1);
                                            
                                            UHDecref2(v1); UHDecref2(v13);
                                            return UH2_4(v12, v14);
                                            break;
                                        }
                                        case 5: { // RegexStar
                                            UH2 * v4 = v0->case5.v0;
                                            v4->refc++;
                                            
                                            switch (v1->tag) {
                                                case 5: { // RegexStar
                                                    UH2 * v5 = v1->case5.v0;
                                                    v4->refc++; v5->refc += 2;
                                                    
                                                    bool v6;
                                                    v6 = regex_equal25(v4, v5);
                                                    
                                                    UHDecref2(v5);
                                                    if (v6){
                                                        
                                                        UHDecref2(v0); UHDecref2(v1);
                                                        return UH2_5(v4);
                                                    } else {
                                                        
                                                        UHDecref2(v4);
                                                        return UH2_4(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    
                                                    UHDecref2(v4);
                                                    return UH2_4(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            
                                            
                                            return UH2_4(v0, v1);
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
UH2 * make_star26(UH2 * v0){
    
    
    switch (v0->tag) {
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0);
            return UH2_1();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref2(v0);
            return UH2_1();
            break;
        }
        case 5: { // RegexStar
            UH2 * v3 = v0->case5.v0;
            v3->refc++;
            UHDecref2(v0);
            return UH2_5(v3);
            break;
        }
        default: {
            
            
            return UH2_5(v0);
        }
    }
}
UH2 * normalize20(UH2 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH2 * v5 = v0->case3.v0; UH2 * v6 = v0->case3.v1;
            v5->refc += 2; v6->refc++;
            UHDecref2(v0);
            UH2 * v7;
            v7 = normalize20(v5);
            v6->refc++;
            UHDecref2(v5);
            UH2 * v8;
            v8 = normalize20(v6);
            
            UHDecref2(v6);
            return make_alt21(v7, v8);
            break;
        }
        case 4: { // RegexCat
            UH2 * v10 = v0->case4.v0; UH2 * v11 = v0->case4.v1;
            v10->refc += 2; v11->refc++;
            UHDecref2(v0);
            UH2 * v12;
            v12 = normalize20(v10);
            v11->refc++;
            UHDecref2(v10);
            UH2 * v13;
            v13 = normalize20(v11);
            
            UHDecref2(v11);
            return make_cat24(v12, v13);
            break;
        }
        case 2: { // RegexChar
            US3 v3 = v0->case2.v0;
            USIncref3(&(v3));
            UHDecref2(v0);
            return UH2_2(v3);
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0);
            return UH2_0();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref2(v0);
            return UH2_1();
            break;
        }
        case 5: { // RegexStar
            UH2 * v15 = v0->case5.v0;
            v15->refc += 2;
            UHDecref2(v0);
            UH2 * v16;
            v16 = normalize20(v15);
            
            UHDecref2(v15);
            return make_star26(v16);
            break;
        }
    }
}
US2 nullable28(UH2 * v0){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH2 * v5 = v0->case3.v0; UH2 * v6 = v0->case3.v1;
            v5->refc += 2; v6->refc++;
            UHDecref2(v0);
            US2 v7;
            v7 = nullable28(v5);
            v6->refc++;
            UHDecref2(v5);
            US2 v8;
            v8 = nullable28(v6);
            
            UHDecref2(v6);
            switch (v7.tag) {
                case 0: { // Nullable
                    
                    
                    USDecref2(&(v7)); USDecref2(&(v8));
                    return US2_0();
                    break;
                }
                default: {
                    
                    
                    switch (v8.tag) {
                        case 0: { // Nullable
                            
                            
                            USDecref2(&(v7)); USDecref2(&(v8));
                            return US2_0();
                            break;
                        }
                        default: {
                            
                            
                            switch (v7.tag) {
                                case 1: { // NonNullable
                                    
                                    
                                    USDecref2(&(v7));
                                    switch (v8.tag) {
                                        case 1: { // NonNullable
                                            
                                            
                                            USDecref2(&(v8));
                                            return US2_1();
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
            v16->refc += 2; v17->refc++;
            UHDecref2(v0);
            US2 v18;
            v18 = nullable28(v16);
            v17->refc++;
            UHDecref2(v16);
            US2 v19;
            v19 = nullable28(v17);
            
            UHDecref2(v17);
            switch (v18.tag) {
                case 0: { // Nullable
                    
                    
                    USDecref2(&(v18));
                    switch (v19.tag) {
                        case 0: { // Nullable
                            
                            
                            USDecref2(&(v19));
                            return US2_0();
                            break;
                        }
                        default: {
                            
                            USDecref2(&(v19));
                            return US2_1();
                        }
                    }
                    break;
                }
                default: {
                    
                    USDecref2(&(v18)); USDecref2(&(v19));
                    return US2_1();
                }
            }
            break;
        }
        case 2: { // RegexChar
            
            
            UHDecref2(v0);
            return US2_1();
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0);
            return US2_1();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref2(v0);
            return US2_0();
            break;
        }
        case 5: { // RegexStar
            
            
            UHDecref2(v0);
            return US2_0();
            break;
        }
    }
}
UH2 * derivative27(UH2 * v0, US3 v1){
    
    
    switch (v0->tag) {
        case 3: { // RegexAlt
            UH2 * v25 = v0->case3.v0; UH2 * v26 = v0->case3.v1;
            USIncref3(&(v1)); v25->refc += 2; v26->refc++;
            UHDecref2(v0);
            UH2 * v27;
            v27 = derivative27(v25, v1);
            USIncref3(&(v1)); v26->refc++;
            UHDecref2(v25);
            UH2 * v28;
            v28 = derivative27(v26, v1);
            
            USDecref3(&(v1)); UHDecref2(v26);
            return make_alt21(v27, v28);
            break;
        }
        case 4: { // RegexCat
            UH2 * v30 = v0->case4.v0; UH2 * v31 = v0->case4.v1;
            v30->refc += 2; v31->refc++;
            UHDecref2(v0);
            US2 v32;
            v32 = nullable28(v30);
            
            
            switch (v32.tag) {
                case 1: { // NonNullable
                    
                    USIncref3(&(v1)); v30->refc++;
                    USDecref2(&(v32));
                    UH2 * v37;
                    v37 = derivative27(v30, v1);
                    
                    USDecref3(&(v1)); UHDecref2(v30);
                    return make_cat24(v37, v31);
                    break;
                }
                case 0: { // Nullable
                    
                    USIncref3(&(v1)); v30->refc++;
                    USDecref2(&(v32));
                    UH2 * v33;
                    v33 = derivative27(v30, v1);
                    v31->refc++; v33->refc++;
                    UHDecref2(v30);
                    UH2 * v34;
                    v34 = make_cat24(v33, v31);
                    USIncref3(&(v1)); v31->refc++;
                    UHDecref2(v33);
                    UH2 * v35;
                    v35 = derivative27(v31, v1);
                    
                    USDecref3(&(v1)); UHDecref2(v31);
                    return make_alt21(v34, v35);
                    break;
                }
            }
            break;
        }
        case 2: { // RegexChar
            US3 v4 = v0->case2.v0;
            USIncref3(&(v4));
            UHDecref2(v0);
            US1 v20;
            switch (v4.tag) {
                case 0: { // TriA
                    
                    
                    
                    switch (v1.tag) {
                        case 0: { // TriA
                            
                            
                            
                            v20 = US1_1();
                            break;
                        }
                        default: {
                            
                            
                            v20 = US1_0();
                        }
                    }
                    break;
                }
                default: {
                    
                    
                    switch (v1.tag) {
                        case 0: { // TriA
                            
                            
                            
                            v20 = US1_2();
                            break;
                        }
                        default: {
                            
                            
                            switch (v4.tag) {
                                case 1: { // TriB
                                    
                                    
                                    
                                    switch (v1.tag) {
                                        case 1: { // TriB
                                            
                                            
                                            
                                            v20 = US1_1();
                                            break;
                                        }
                                        case 2: { // TriC
                                            
                                            
                                            
                                            v20 = US1_0();
                                            break;
                                        }
                                    }
                                    break;
                                }
                                case 2: { // TriC
                                    
                                    
                                    
                                    switch (v1.tag) {
                                        case 1: { // TriB
                                            
                                            
                                            
                                            v20 = US1_2();
                                            break;
                                        }
                                        case 2: { // TriC
                                            
                                            
                                            
                                            v20 = US1_1();
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
            
            USDecref3(&(v1)); USDecref3(&(v4));
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
            
            USDecref1(&(v20));
            if (v21){
                
                
                return UH2_1();
            } else {
                
                
                return UH2_0();
            }
            break;
        }
        case 0: { // RegexEmpty
            
            
            UHDecref2(v0); USDecref3(&(v1));
            return UH2_0();
            break;
        }
        case 1: { // RegexEpsilon
            
            
            UHDecref2(v0); USDecref3(&(v1));
            return UH2_0();
            break;
        }
        case 5: { // RegexStar
            UH2 * v41 = v0->case5.v0;
            USIncref3(&(v1)); v41->refc += 2;
            UHDecref2(v0);
            UH2 * v42;
            v42 = derivative27(v41, v1);
            v41->refc++;
            USDecref3(&(v1));
            UH2 * v43;
            v43 = make_star26(v41);
            
            UHDecref2(v41);
            return make_cat24(v42, v43);
            break;
        }
    }
}
UH2 * canonical_derivative19(UH2 * v0, US3 v1){
    v0->refc++;
    
    UH2 * v2;
    v2 = normalize20(v0);
    USIncref3(&(v1)); v2->refc++;
    UHDecref2(v0);
    UH2 * v3;
    v3 = derivative27(v2, v1);
    
    USDecref3(&(v1)); UHDecref2(v2);
    return normalize20(v3);
}
bool accepts18(UH2 * v0, UH3 * v1){
    
    
    switch (v1->tag) {
        case 1: { // InputCons
            US3 v6 = v1->case1.v0; UH3 * v7 = v1->case1.v1;
            v0->refc++; USIncref3(&(v6));USIncref3(&(v6)); v7->refc++;
            UHDecref3(v1);
            UH2 * v8;
            v8 = canonical_derivative19(v0, v6);
            
            UHDecref2(v0); USDecref3(&(v6));
            return accepts18(v8, v7);
            break;
        }
        case 0: { // InputEmpty
            
            v0->refc++;
            UHDecref3(v1);
            UH2 * v2;
            v2 = normalize20(v0);
            v2->refc++;
            UHDecref2(v0);
            US2 v3;
            v3 = nullable28(v2);
            
            UHDecref2(v2);
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
int32_t main(){
    
    
    int32_t v0;
    v0 = 200l;
    
    
    int32_t v1;
    v1 = 32l;
    
    
    int32_t v2;
    v2 = 16l;
    
    
    US0 v3;
    v3 = US0_0();
    USIncref0(&(v3));
    
    UH0 * v4;
    v4 = UH0_2(v3);
    
    USDecref0(&(v3));
    US0 v5;
    v5 = US0_1();
    USIncref0(&(v5));
    
    UH0 * v6;
    v6 = UH0_2(v5);
    v4->refc++; v6->refc++;
    USDecref0(&(v5));
    UH0 * v7;
    v7 = UH0_3(v4, v6);
    v7->refc++;
    UHDecref0(v4); UHDecref0(v6);
    UH0 * v8;
    v8 = UH0_5(v7);
    
    UHDecref0(v7);
    US0 v9;
    v9 = US0_0();
    USIncref0(&(v9));
    
    UH0 * v10;
    v10 = UH0_2(v9);
    v8->refc++; v10->refc++;
    USDecref0(&(v9));
    UH0 * v11;
    v11 = UH0_4(v8, v10);
    
    UHDecref0(v8); UHDecref0(v10);
    uint64_t v12;
    v12 = 1ull;
    
    
    int32_t v13;
    v13 = 0l;
    v11->refc++;
    
    int32_t v14;
    v14 = loop0(v1, v11, v0, v12, v13);
    
    UHDecref0(v11);
    bool v15;
    v15 = v14 == 93l;
    
    
    
    if (v15){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-compiled-ends-with-zero-count");
        exit(EXIT_FAILURE);
    }
    
    
    US0 v16;
    v16 = US0_0();
    USIncref0(&(v16));
    
    UH0 * v17;
    v17 = UH0_2(v16);
    
    USDecref0(&(v16));
    US0 v18;
    v18 = US0_0();
    USIncref0(&(v18));
    
    UH0 * v19;
    v19 = UH0_2(v18);
    
    USDecref0(&(v18));
    US0 v20;
    v20 = US0_0();
    USIncref0(&(v20));
    
    UH0 * v21;
    v21 = UH0_2(v20);
    v19->refc++; v21->refc++;
    USDecref0(&(v20));
    UH0 * v22;
    v22 = UH0_4(v19, v21);
    v17->refc++; v22->refc++;
    UHDecref0(v19); UHDecref0(v21);
    UH0 * v23;
    v23 = UH0_3(v17, v22);
    v23->refc++;
    UHDecref0(v17); UHDecref0(v22);
    UH0 * v24;
    v24 = UH0_5(v23);
    
    UHDecref0(v23);
    US0 v25;
    v25 = US0_1();
    USIncref0(&(v25));
    
    UH0 * v26;
    v26 = UH0_2(v25);
    v24->refc++; v26->refc++;
    USDecref0(&(v25));
    UH0 * v27;
    v27 = UH0_4(v24, v26);
    
    UHDecref0(v24); UHDecref0(v26);
    int32_t v28;
    v28 = 1l;
    
    
    int32_t v29;
    v29 = 0l;
    v27->refc++;
    
    int32_t v30;
    v30 = loop14(v2, v27, v28, v29);
    
    UHDecref0(v27);
    bool v31;
    v31 = v30 == 16l;
    
    
    
    if (v31){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-compiled-zero-runs-count");
        exit(EXIT_FAILURE);
    }
    
    
    US3 v32;
    v32 = US3_0();
    USIncref3(&(v32));
    
    UH2 * v33;
    v33 = UH2_2(v32);
    
    USDecref3(&(v32));
    US3 v34;
    v34 = US3_1();
    USIncref3(&(v34));
    
    UH2 * v35;
    v35 = UH2_2(v34);
    v33->refc++; v35->refc++;
    USDecref3(&(v34));
    UH2 * v36;
    v36 = UH2_3(v33, v35);
    v36->refc++;
    UHDecref2(v33); UHDecref2(v35);
    UH2 * v37;
    v37 = UH2_5(v36);
    
    UHDecref2(v36);
    US3 v38;
    v38 = US3_2();
    USIncref3(&(v38));
    
    UH2 * v39;
    v39 = UH2_2(v38);
    v37->refc++; v39->refc++;
    USDecref3(&(v38));
    UH2 * v40;
    v40 = UH2_4(v37, v39);
    
    UHDecref2(v37); UHDecref2(v39);
    US3 v41;
    v41 = US3_0();
    
    
    US3 v42;
    v42 = US3_1();
    
    
    US3 v43;
    v43 = US3_0();
    
    
    US3 v44;
    v44 = US3_2();
    
    
    UH3 * v45;
    v45 = UH3_0();
    USIncref3(&(v44)); v45->refc++;
    
    UH3 * v46;
    v46 = UH3_1(v44, v45);
    USIncref3(&(v43)); v46->refc++;
    USDecref3(&(v44)); UHDecref3(v45);
    UH3 * v47;
    v47 = UH3_1(v43, v46);
    USIncref3(&(v42)); v47->refc++;
    USDecref3(&(v43)); UHDecref3(v46);
    UH3 * v48;
    v48 = UH3_1(v42, v47);
    USIncref3(&(v41)); v48->refc++;
    USDecref3(&(v42)); UHDecref3(v47);
    UH3 * v49;
    v49 = UH3_1(v41, v48);
    
    USDecref3(&(v41)); UHDecref3(v48);
    US3 v50;
    v50 = US3_0();
    
    
    US3 v51;
    v51 = US3_1();
    
    
    US3 v52;
    v52 = US3_0();
    
    
    US3 v53;
    v53 = US3_1();
    
    
    UH3 * v54;
    v54 = UH3_0();
    USIncref3(&(v53)); v54->refc++;
    
    UH3 * v55;
    v55 = UH3_1(v53, v54);
    USIncref3(&(v52)); v55->refc++;
    USDecref3(&(v53)); UHDecref3(v54);
    UH3 * v56;
    v56 = UH3_1(v52, v55);
    USIncref3(&(v51)); v56->refc++;
    USDecref3(&(v52)); UHDecref3(v55);
    UH3 * v57;
    v57 = UH3_1(v51, v56);
    USIncref3(&(v50)); v57->refc++;
    USDecref3(&(v51)); UHDecref3(v56);
    UH3 * v58;
    v58 = UH3_1(v50, v57);
    
    USDecref3(&(v50)); UHDecref3(v57);
    int32_t v59;
    v59 = 0l;
    v49->refc++;
    
    bool v60;
    v60 = run17(v59, v49);
    
    
    bool v62;
    if (v60){
        v40->refc++; v49->refc++;
        
        v62 = accepts18(v40, v49);
    } else {
        
        
        v62 = false;
    }
    
    UHDecref3(v49);
    bool v68;
    if (v62){
        
        
        int32_t v63;
        v63 = 0l;
        v58->refc++;
        
        bool v64;
        v64 = run17(v63, v58);
        
        
        if (v64){
            
            
            v68 = false;
        } else {
            v40->refc++; v58->refc++;
            
            bool v65;
            v65 = accepts18(v40, v58);
            
            
            bool v66;
            v66 = v65 == false;
            
            
            v68 = v66;
        }
    } else {
        
        
        v68 = false;
    }
    
    UHDecref2(v40); UHDecref3(v58);
    if (v68){
        
        
        return 0l;
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-compiled-ternary-disagrees");
        exit(EXIT_FAILURE);
    }
}
