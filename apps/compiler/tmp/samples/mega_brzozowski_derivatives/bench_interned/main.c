#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
typedef struct UH1 UH1;
void UHDecref1(UH1 * x);
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
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
static inline void AssignArray0(int32_t * a, int32_t b){
    
    
    *a = b;
}
void loop0(Array0 * v0, int32_t v1){
    
    
    bool v2;
    v2 = v1 < 8192l;
    
    
    if (v2){
        
        
        
        AssignArray0(&(v0->ptr[v1]), 0l);
        
        
        int32_t v3;
        v3 = v1 + 1l;
        
        
        return loop0(v0, v3);
    } else {
        
        ArrayDecref0(v0);
        return ;
    }
}
void loop1(Array0 * v0, int32_t v1){
    
    
    bool v2;
    v2 = v1 < 1l;
    
    
    if (v2){
        
        
        
        AssignArray0(&(v0->ptr[v1]), 0l);
        
        
        int32_t v3;
        v3 = v1 + 1l;
        
        
        return loop1(v0, v3);
    } else {
        
        ArrayDecref0(v0);
        return ;
    }
}
int32_t probe3(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8, int32_t v9, int32_t v10){
    
    
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
            
            
            return probe3(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v47);
        }
    }
}
int32_t interned_node2(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8, int32_t v9){
    
    
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
    
    
    return probe3(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14);
}
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
int32_t interned_alt_insert6(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8){
    
    
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
                
                
                return interned_node2(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8);
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
                    v19 = interned_alt_insert6(v0, v1, v2, v3, v4, v5, v6, v7, v18);
                    
                    
                    return interned_node2(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19);
                }
            }
        } else {
            
            
            bool v23;
            v23 = v7 < v8;
            
            
            if (v23){
                
                
                int32_t v24;
                v24 = 3l;
                
                
                return interned_node2(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8);
            } else {
                
                
                bool v26;
                v26 = v7 == v8;
                
                
                if (v26){
                    
                    ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
                    return v8;
                } else {
                    
                    
                    int32_t v27;
                    v27 = 3l;
                    
                    
                    return interned_node2(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7);
                }
            }
        }
    }
}
int32_t interned_make_alt5(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8){
    
    
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
            v14 = interned_alt_insert6(v0, v1, v2, v3, v4, v5, v6, v13, v8);
            
            
            return interned_make_alt5(v0, v1, v2, v3, v4, v5, v6, v12, v14);
        } else {
            
            
            return interned_alt_insert6(v0, v1, v2, v3, v4, v5, v6, v7, v8);
        }
    }
}
int32_t interned_make_cat7(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8){
    
    
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
                            
                            
                            return interned_node2(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8);
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
                            v29 = interned_make_cat7(v0, v1, v2, v3, v4, v5, v6, v28, v8);
                            
                            
                            return interned_node2(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29);
                        } else {
                            
                            
                            int32_t v31;
                            v31 = 4l;
                            
                            
                            return interned_node2(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8);
                        }
                    }
                }
            }
        }
    }
}
int32_t interned_of_regex_raw4(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, UH0 * v7){
    
    
    switch (v7->tag) {
        case 3: { // RegexAlt
            UH0 * v14 = v7->case3.v0; UH0 * v15 = v7->case3.v1;
            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v14->refc += 2; v15->refc++;
            UHDecref0(v7);
            int32_t v16;
            v16 = interned_of_regex_raw4(v0, v1, v2, v3, v4, v5, v6, v14);
            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v15->refc++;
            UHDecref0(v14);
            int32_t v17;
            v17 = interned_of_regex_raw4(v0, v1, v2, v3, v4, v5, v6, v15);
            
            UHDecref0(v15);
            return interned_make_alt5(v0, v1, v2, v3, v4, v5, v6, v16, v17);
            break;
        }
        case 4: { // RegexCat
            UH0 * v19 = v7->case4.v0; UH0 * v20 = v7->case4.v1;
            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v19->refc += 2; v20->refc++;
            UHDecref0(v7);
            int32_t v21;
            v21 = interned_of_regex_raw4(v0, v1, v2, v3, v4, v5, v6, v19);
            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v20->refc++;
            UHDecref0(v19);
            int32_t v22;
            v22 = interned_of_regex_raw4(v0, v1, v2, v3, v4, v5, v6, v20);
            
            UHDecref0(v20);
            return interned_make_cat7(v0, v1, v2, v3, v4, v5, v6, v21, v22);
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
            
            
            return interned_node2(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12);
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
            v25 = interned_of_regex_raw4(v0, v1, v2, v3, v4, v5, v6, v24);
            
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
                    
                    
                    return interned_node2(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30);
                }
            }
            break;
        }
    }
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
Tuple0 random_bit_input9(uint64_t v0, int32_t v1, UH1 * v2){
    
    
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
        return random_bit_input9(v6, v7, v14);
    } else {
        
        
        return TupleCreate0(v2, v0);
    }
}
int32_t interned_derivative_raw12(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8){
    
    
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
                    v21 = interned_derivative_raw12(v0, v1, v2, v3, v4, v5, v6, v20, v8);
                    
                    
                    int32_t v22;
                    v22 = v2->ptr[v7];
                    v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                    
                    int32_t v23;
                    v23 = interned_derivative_raw12(v0, v1, v2, v3, v4, v5, v6, v22, v8);
                    v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                    
                    v41 = interned_make_alt5(v0, v1, v2, v3, v4, v5, v6, v21, v23);
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
                        v28 = interned_derivative_raw12(v0, v1, v2, v3, v4, v5, v6, v26, v8);
                        v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                        
                        int32_t v29;
                        v29 = interned_make_cat7(v0, v1, v2, v3, v4, v5, v6, v28, v27);
                        
                        
                        int32_t v30;
                        v30 = v3->ptr[v26];
                        
                        
                        bool v31;
                        v31 = v30 == 1l;
                        
                        
                        if (v31){
                            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                            
                            int32_t v32;
                            v32 = interned_derivative_raw12(v0, v1, v2, v3, v4, v5, v6, v27, v8);
                            v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                            
                            v41 = interned_make_alt5(v0, v1, v2, v3, v4, v5, v6, v29, v32);
                        } else {
                            
                            
                            v41 = v29;
                        }
                    } else {
                        
                        
                        int32_t v35;
                        v35 = v1->ptr[v7];
                        v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                        
                        int32_t v36;
                        v36 = interned_derivative_raw12(v0, v1, v2, v3, v4, v5, v6, v35, v8);
                        v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++;
                        
                        v41 = interned_make_cat7(v0, v1, v2, v3, v4, v5, v6, v36, v7);
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
bool loop11(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, UH1 * v8){
    
    
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
                v16 = interned_derivative_raw12(v0, v1, v2, v3, v4, v5, v6, v7, v15);
                
                
                return loop11(v0, v1, v2, v3, v4, v5, v6, v16, v13);
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
bool interned_accepts10(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, UH1 * v8){
    
    
    return loop11(v0, v1, v2, v3, v4, v5, v6, v7, v8);
}
int32_t loop8(Array0 * v0, Array0 * v1, Array0 * v2, Array0 * v3, Array0 * v4, Array0 * v5, Array0 * v6, int32_t v7, int32_t v8, int32_t v9, uint64_t v10, int32_t v11){
    
    
    bool v12;
    v12 = 0l < v9;
    
    
    if (v12){
        
        
        UH1 * v13;
        v13 = UH1_0();
        v13->refc++;
        
        UH1 * v14; uint64_t v15;
        Tuple0 tmp0 = random_bit_input9(v10, v7, v13);
        v14 = tmp0.v0; v15 = tmp0.v1;
        v0->refc++; v1->refc++; v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v14->refc++;
        UHDecref1(v13);
        bool v16;
        v16 = interned_accepts10(v0, v1, v2, v3, v4, v5, v6, v8, v14);
        
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
        
        
        return loop8(v0, v1, v2, v3, v4, v5, v6, v7, v8, v19, v15, v18);
    } else {
        
        ArrayDecref0(v0); ArrayDecref0(v1); ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6);
        return v11;
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 2000l;
    
    
    int32_t v1;
    v1 = 32l;
    
    
    Array0 * v2;
    v2 = ArrayCreate0(4096l, false);
    
    
    Array0 * v3;
    v3 = ArrayCreate0(4096l, false);
    
    
    Array0 * v4;
    v4 = ArrayCreate0(4096l, false);
    
    
    Array0 * v5;
    v5 = ArrayCreate0(4096l, false);
    
    
    Array0 * v6;
    v6 = ArrayCreate0(8192l, false);
    
    
    Array0 * v7;
    v7 = ArrayCreate0(8192l, false);
    
    
    Array0 * v8;
    v8 = ArrayCreate0(1l, false);
    
    
    int32_t v9;
    v9 = 0l;
    v6->refc++;
    
    
    loop0(v6, v9);
    
    
    int32_t v10;
    v10 = 0l;
    v7->refc++;
    
    
    loop0(v7, v10);
    
    
    int32_t v11;
    v11 = 0l;
    v8->refc++;
    
    
    loop1(v8, v11);
    
    
    int32_t v12;
    v12 = 0l;
    
    
    int32_t v13;
    v13 = 0l;
    
    
    int32_t v14;
    v14 = 0l;
    v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v7->refc++; v8->refc++;
    
    int32_t v15;
    v15 = interned_node2(v2, v3, v4, v5, v6, v7, v8, v12, v13, v14);
    
    
    int32_t v16;
    v16 = 1l;
    
    
    int32_t v17;
    v17 = 0l;
    
    
    int32_t v18;
    v18 = 0l;
    v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v7->refc++; v8->refc++;
    
    int32_t v19;
    v19 = interned_node2(v2, v3, v4, v5, v6, v7, v8, v16, v17, v18);
    
    
    bool v20;
    v20 = v15 == 0l;
    
    
    bool v22;
    if (v20){
        
        
        bool v21;
        v21 = v19 == 1l;
        
        
        v22 = v21;
    } else {
        
        
        v22 = false;
    }
    
    
    Array0 * v30; Array0 * v31; Array0 * v32; Array0 * v33; Array0 * v34; Array0 * v35; Array0 * v36;
    if (v22){
        v2->refc++; v3->refc++; v4->refc++; v5->refc++; v6->refc++; v7->refc++; v8->refc++;
        
        v30 = v2; v31 = v3; v32 = v4; v33 = v5; v34 = v6; v35 = v7; v36 = v8;
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-interned-store-init");
        exit(EXIT_FAILURE);
    }
    
    ArrayDecref0(v2); ArrayDecref0(v3); ArrayDecref0(v4); ArrayDecref0(v5); ArrayDecref0(v6); ArrayDecref0(v7); ArrayDecref0(v8);
    US0 v37;
    v37 = US0_0();
    USIncref0(&(v37));
    
    UH0 * v38;
    v38 = UH0_2(v37);
    
    USDecref0(&(v37));
    US0 v39;
    v39 = US0_1();
    USIncref0(&(v39));
    
    UH0 * v40;
    v40 = UH0_2(v39);
    v38->refc++; v40->refc++;
    USDecref0(&(v39));
    UH0 * v41;
    v41 = UH0_3(v38, v40);
    v41->refc++;
    UHDecref0(v38); UHDecref0(v40);
    UH0 * v42;
    v42 = UH0_5(v41);
    
    UHDecref0(v41);
    US0 v43;
    v43 = US0_0();
    USIncref0(&(v43));
    
    UH0 * v44;
    v44 = UH0_2(v43);
    v42->refc++; v44->refc++;
    USDecref0(&(v43));
    UH0 * v45;
    v45 = UH0_4(v42, v44);
    v30->refc++; v31->refc++; v32->refc++; v33->refc++; v34->refc++; v35->refc++; v36->refc++; v45->refc++;
    UHDecref0(v42); UHDecref0(v44);
    int32_t v46;
    v46 = interned_of_regex_raw4(v30, v31, v32, v33, v34, v35, v36, v45);
    
    UHDecref0(v45);
    uint64_t v47;
    v47 = 1ull;
    
    
    int32_t v48;
    v48 = 0l;
    v30->refc++; v31->refc++; v32->refc++; v33->refc++; v34->refc++; v35->refc++; v36->refc++;
    
    int32_t v49;
    v49 = loop8(v30, v31, v32, v33, v34, v35, v36, v1, v46, v0, v47, v48);
    
    
    US0 v50;
    v50 = US0_0();
    USIncref0(&(v50));
    
    UH0 * v51;
    v51 = UH0_2(v50);
    
    USDecref0(&(v50));
    US0 v52;
    v52 = US0_1();
    USIncref0(&(v52));
    
    UH0 * v53;
    v53 = UH0_2(v52);
    v51->refc++; v53->refc++;
    USDecref0(&(v52));
    UH0 * v54;
    v54 = UH0_3(v51, v53);
    v54->refc++;
    UHDecref0(v51); UHDecref0(v53);
    UH0 * v55;
    v55 = UH0_5(v54);
    
    UHDecref0(v54);
    US0 v56;
    v56 = US0_1();
    USIncref0(&(v56));
    
    UH0 * v57;
    v57 = UH0_2(v56);
    
    USDecref0(&(v56));
    US0 v58;
    v58 = US0_0();
    USIncref0(&(v58));
    
    UH0 * v59;
    v59 = UH0_2(v58);
    
    USDecref0(&(v58));
    US0 v60;
    v60 = US0_1();
    USIncref0(&(v60));
    
    UH0 * v61;
    v61 = UH0_2(v60);
    v59->refc++; v61->refc++;
    USDecref0(&(v60));
    UH0 * v62;
    v62 = UH0_3(v59, v61);
    
    UHDecref0(v59); UHDecref0(v61);
    US0 v63;
    v63 = US0_0();
    USIncref0(&(v63));
    
    UH0 * v64;
    v64 = UH0_2(v63);
    
    USDecref0(&(v63));
    US0 v65;
    v65 = US0_1();
    USIncref0(&(v65));
    
    UH0 * v66;
    v66 = UH0_2(v65);
    v64->refc++; v66->refc++;
    USDecref0(&(v65));
    UH0 * v67;
    v67 = UH0_3(v64, v66);
    
    UHDecref0(v64); UHDecref0(v66);
    US0 v68;
    v68 = US0_0();
    USIncref0(&(v68));
    
    UH0 * v69;
    v69 = UH0_2(v68);
    
    USDecref0(&(v68));
    US0 v70;
    v70 = US0_1();
    USIncref0(&(v70));
    
    UH0 * v71;
    v71 = UH0_2(v70);
    v69->refc++; v71->refc++;
    USDecref0(&(v70));
    UH0 * v72;
    v72 = UH0_3(v69, v71);
    v67->refc++; v72->refc++;
    UHDecref0(v69); UHDecref0(v71);
    UH0 * v73;
    v73 = UH0_4(v67, v72);
    v62->refc++; v73->refc++;
    UHDecref0(v67); UHDecref0(v72);
    UH0 * v74;
    v74 = UH0_4(v62, v73);
    v57->refc++; v74->refc++;
    UHDecref0(v62); UHDecref0(v73);
    UH0 * v75;
    v75 = UH0_4(v57, v74);
    v55->refc++; v75->refc++;
    UHDecref0(v57); UHDecref0(v74);
    UH0 * v76;
    v76 = UH0_4(v55, v75);
    v30->refc++; v31->refc++; v32->refc++; v33->refc++; v34->refc++; v35->refc++; v36->refc++; v76->refc++;
    UHDecref0(v55); UHDecref0(v75);
    int32_t v77;
    v77 = interned_of_regex_raw4(v30, v31, v32, v33, v34, v35, v36, v76);
    
    UHDecref0(v76);
    uint64_t v78;
    v78 = 1ull;
    
    
    int32_t v79;
    v79 = 0l;
    v30->refc++; v31->refc++; v32->refc++; v33->refc++; v34->refc++; v35->refc++; v36->refc++;
    
    int32_t v80;
    v80 = loop8(v30, v31, v32, v33, v34, v35, v36, v1, v77, v0, v78, v79);
    
    ArrayDecref0(v30); ArrayDecref0(v31); ArrayDecref0(v32); ArrayDecref0(v33); ArrayDecref0(v34); ArrayDecref0(v35); ArrayDecref0(v36);
    bool v81;
    v81 = v49 == 997l;
    
    
    
    if (v81){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-bench-ends-with-zero-count");
        exit(EXIT_FAILURE);
    }
    
    
    bool v82;
    v82 = v80 == 985l;
    
    
    
    if (v82){
        
        
        
    } else {
        
        
        fprintf(stderr, "%s\n", "brzozowski-bench-fourth-from-end-count");
        exit(EXIT_FAILURE);
    }
    
    
    return 0l;
}
