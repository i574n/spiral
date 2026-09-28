#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
typedef struct {
    int tag;
    union {
        struct {
            double v0;
            double v1;
            double v2;
        } case1; // Visible
    };
} US0;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array1;
typedef Array1 String;
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
bool method_while0(int32_t v0, int32_t v1){
    
    
    bool v2;
    v2 = v1 < v0;
    
    
    return v2;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    
    
    *a = b;
}
Array0 * method0(int32_t v0){
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    
    
    int32_t v2;
    v2 = 0l;
    
    
    
    while (method_while0(v0, v2)){
        
        
        
        AssignArray0(&(v1->ptr[v2]), 46l);
        
        
        int32_t v4;
        v4 = v2 + 1l ;
        
        
        
        v2 = v4;
        
        
        
    }
    
    
    return v1;
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
US0 US0_0() { // Hidden
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(double v0, double v1, double v2) { // Visible
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1; x.case1.v2 = v2;
    return x;
}
int32_t method1(Array0 * v0){
    
    
    double v1;
    v1 = 0.0 - 40.0 ;
    
    
    double v2;
    v2 = 0.0 - 20.0 ;
    
    
    double v3;
    v3 = 20.0 * 0.0 ;
    
    
    double v4;
    v4 = v3 * 0.0 ;
    
    
    double v5;
    v5 = v4 * 1.0 ;
    
    
    double v6;
    v6 = v2 * 1.0 ;
    
    
    double v7;
    v7 = v6 * 0.0 ;
    
    
    double v8;
    v8 = v7 * 1.0 ;
    
    
    double v9;
    v9 = v5 - v8 ;
    
    
    double v10;
    v10 = 20.0 * 1.0 ;
    
    
    double v11;
    v11 = v10 * 0.0 ;
    
    
    double v12;
    v12 = v9 + v11 ;
    
    
    double v13;
    v13 = v2 * 0.0 ;
    
    
    double v14;
    v14 = v13 * 0.0 ;
    
    
    double v15;
    v15 = v12 + v14 ;
    
    
    double v16;
    v16 = 20.0 * 1.0 ;
    
    
    double v17;
    v17 = v16 * 1.0 ;
    
    
    double v18;
    v18 = v15 + v17 ;
    
    
    double v19;
    v19 = 20.0 * 1.0 ;
    
    
    double v20;
    v20 = v19 * 1.0 ;
    
    
    double v21;
    v21 = v2 * 0.0 ;
    
    
    double v22;
    v22 = v21 * 1.0 ;
    
    
    double v23;
    v23 = v20 + v22 ;
    
    
    double v24;
    v24 = 20.0 * 0.0 ;
    
    
    double v25;
    v25 = v24 * 0.0 ;
    
    
    double v26;
    v26 = v25 * 0.0 ;
    
    
    double v27;
    v27 = v23 - v26 ;
    
    
    double v28;
    v28 = v2 * 1.0 ;
    
    
    double v29;
    v29 = v28 * 0.0 ;
    
    
    double v30;
    v30 = v29 * 0.0 ;
    
    
    double v31;
    v31 = v27 + v30 ;
    
    
    double v32;
    v32 = 20.0 * 1.0 ;
    
    
    double v33;
    v33 = v32 * 0.0 ;
    
    
    double v34;
    v34 = v31 - v33 ;
    
    
    double v35;
    v35 = v2 * 1.0 ;
    
    
    double v36;
    v36 = v35 * 1.0 ;
    
    
    double v37;
    v37 = 20.0 * 0.0 ;
    
    
    double v38;
    v38 = v37 * 1.0 ;
    
    
    double v39;
    v39 = v36 - v38 ;
    
    
    double v40;
    v40 = 20.0 * 0.0 ;
    
    
    double v41;
    v41 = v39 + v40 ;
    
    
    double v42;
    v42 = v41 + 100.0 ;
    
    
    double v43;
    v43 = 1.0 / v42 ;
    
    
    double v44;
    v44 = 80.0 + v1 ;
    
    
    double v45;
    v45 = 40.0 * v43 ;
    
    
    double v46;
    v46 = v45 * v18 ;
    
    
    double v47;
    v47 = v46 * 2.0 ;
    
    
    double v48;
    v48 = v44 + v47 ;
    
    
    double v49;
    v49 = 40.0 * v43 ;
    
    
    double v50;
    v50 = v49 * v34 ;
    
    
    double v51;
    v51 = 22.0 + v50 ;
    
    
    bool v52;
    v52 = v48 >= 0.0;
    
    
    bool v54;
    if (v52){
        
        
        bool v53;
        v53 = v48 < 160.0;
        
        
        v54 = v53;
    } else {
        
        
        v54 = false;
    }
    
    
    bool v56;
    if (v54){
        
        
        bool v55;
        v55 = v51 >= 0.0;
        
        
        v56 = v55;
    } else {
        
        
        v56 = false;
    }
    
    
    bool v58;
    if (v56){
        
        
        bool v57;
        v57 = v51 < 44.0;
        
        
        v58 = v57;
    } else {
        
        
        v58 = false;
    }
    
    
    US0 v61;
    if (v58){
        
        
        v61 = US0_1(v48, v51, v43);
    } else {
        
        
        v61 = US0_0();
    }
    
    
    switch (v61.tag) {
        case 1: { // Visible
            double v62 = v61.case1.v0; double v63 = v61.case1.v1; double v64 = v61.case1.v2;
            
            USDecref0(&(v61));
            bool v65;
            v65 = v62 >= 0.0;
            
            
            bool v67;
            if (v65){
                
                
                bool v66;
                v66 = v63 >= 0.0;
                
                
                v67 = v66;
            } else {
                
                
                v67 = false;
            }
            
            
            bool v69;
            if (v67){
                
                
                bool v68;
                v68 = v64 > 0.0;
                
                
                v69 = v68;
            } else {
                
                
                v69 = false;
            }
            
            
            if (v69){
                
                
                int32_t v70;
                v70 = (int32_t)v62;
                
                
                int32_t v71;
                v71 = (int32_t)v63;
                
                
                int32_t v72;
                v72 = v71 * 160l ;
                
                
                int32_t v73;
                v73 = v70 + v72 ;
                
                
                
                AssignArray0(&(v0->ptr[v73]), 35l);
                
                ArrayDecref0(v0);
                return v73;
            } else {
                
                ArrayDecref0(v0);
                return 0l;
            }
            break;
        }
        default: {
            
            ArrayDecref0(v0); USDecref0(&(v61));
            return 0l;
        }
    }
}
int32_t method2(Array0 * v0){
    
    
    double v1;
    v1 = 0.0 - 10.0 ;
    
    
    double v2;
    v2 = 10.0 * 0.0 ;
    
    
    double v3;
    v3 = v2 * 0.0 ;
    
    
    double v4;
    v4 = v3 * 1.0 ;
    
    
    double v5;
    v5 = v1 * 1.0 ;
    
    
    double v6;
    v6 = v5 * 0.0 ;
    
    
    double v7;
    v7 = v6 * 1.0 ;
    
    
    double v8;
    v8 = v4 - v7 ;
    
    
    double v9;
    v9 = 10.0 * 1.0 ;
    
    
    double v10;
    v10 = v9 * 0.0 ;
    
    
    double v11;
    v11 = v8 + v10 ;
    
    
    double v12;
    v12 = v1 * 0.0 ;
    
    
    double v13;
    v13 = v12 * 0.0 ;
    
    
    double v14;
    v14 = v11 + v13 ;
    
    
    double v15;
    v15 = 10.0 * 1.0 ;
    
    
    double v16;
    v16 = v15 * 1.0 ;
    
    
    double v17;
    v17 = v14 + v16 ;
    
    
    double v18;
    v18 = 10.0 * 1.0 ;
    
    
    double v19;
    v19 = v18 * 1.0 ;
    
    
    double v20;
    v20 = v1 * 0.0 ;
    
    
    double v21;
    v21 = v20 * 1.0 ;
    
    
    double v22;
    v22 = v19 + v21 ;
    
    
    double v23;
    v23 = 10.0 * 0.0 ;
    
    
    double v24;
    v24 = v23 * 0.0 ;
    
    
    double v25;
    v25 = v24 * 0.0 ;
    
    
    double v26;
    v26 = v22 - v25 ;
    
    
    double v27;
    v27 = v1 * 1.0 ;
    
    
    double v28;
    v28 = v27 * 0.0 ;
    
    
    double v29;
    v29 = v28 * 0.0 ;
    
    
    double v30;
    v30 = v26 + v29 ;
    
    
    double v31;
    v31 = 10.0 * 1.0 ;
    
    
    double v32;
    v32 = v31 * 0.0 ;
    
    
    double v33;
    v33 = v30 - v32 ;
    
    
    double v34;
    v34 = v1 * 1.0 ;
    
    
    double v35;
    v35 = v34 * 1.0 ;
    
    
    double v36;
    v36 = 10.0 * 0.0 ;
    
    
    double v37;
    v37 = v36 * 1.0 ;
    
    
    double v38;
    v38 = v35 - v37 ;
    
    
    double v39;
    v39 = 10.0 * 0.0 ;
    
    
    double v40;
    v40 = v38 + v39 ;
    
    
    double v41;
    v41 = v40 + 100.0 ;
    
    
    double v42;
    v42 = 1.0 / v41 ;
    
    
    double v43;
    v43 = 80.0 + 10.0 ;
    
    
    double v44;
    v44 = 40.0 * v42 ;
    
    
    double v45;
    v45 = v44 * v17 ;
    
    
    double v46;
    v46 = v45 * 2.0 ;
    
    
    double v47;
    v47 = v43 + v46 ;
    
    
    double v48;
    v48 = 40.0 * v42 ;
    
    
    double v49;
    v49 = v48 * v33 ;
    
    
    double v50;
    v50 = 22.0 + v49 ;
    
    
    bool v51;
    v51 = v47 >= 0.0;
    
    
    bool v53;
    if (v51){
        
        
        bool v52;
        v52 = v47 < 160.0;
        
        
        v53 = v52;
    } else {
        
        
        v53 = false;
    }
    
    
    bool v55;
    if (v53){
        
        
        bool v54;
        v54 = v50 >= 0.0;
        
        
        v55 = v54;
    } else {
        
        
        v55 = false;
    }
    
    
    bool v57;
    if (v55){
        
        
        bool v56;
        v56 = v50 < 44.0;
        
        
        v57 = v56;
    } else {
        
        
        v57 = false;
    }
    
    
    US0 v60;
    if (v57){
        
        
        v60 = US0_1(v47, v50, v42);
    } else {
        
        
        v60 = US0_0();
    }
    
    
    switch (v60.tag) {
        case 1: { // Visible
            double v61 = v60.case1.v0; double v62 = v60.case1.v1; double v63 = v60.case1.v2;
            
            USDecref0(&(v60));
            bool v64;
            v64 = v61 >= 0.0;
            
            
            bool v66;
            if (v64){
                
                
                bool v65;
                v65 = v62 >= 0.0;
                
                
                v66 = v65;
            } else {
                
                
                v66 = false;
            }
            
            
            bool v68;
            if (v66){
                
                
                bool v67;
                v67 = v63 > 0.0;
                
                
                v68 = v67;
            } else {
                
                
                v68 = false;
            }
            
            
            if (v68){
                
                
                int32_t v69;
                v69 = (int32_t)v61;
                
                
                int32_t v70;
                v70 = (int32_t)v62;
                
                
                int32_t v71;
                v71 = v70 * 160l ;
                
                
                int32_t v72;
                v72 = v69 + v71 ;
                
                
                
                AssignArray0(&(v0->ptr[v72]), 64l);
                
                ArrayDecref0(v0);
                return v72;
            } else {
                
                ArrayDecref0(v0);
                return 0l;
            }
            break;
        }
        default: {
            
            ArrayDecref0(v0); USDecref0(&(v60));
            return 0l;
        }
    }
}
int32_t method3(Array0 * v0){
    
    
    double v1;
    v1 = 0.0 - 5.0 ;
    
    
    double v2;
    v2 = 5.0 * 0.0 ;
    
    
    double v3;
    v3 = v2 * 0.0 ;
    
    
    double v4;
    v4 = v3 * 1.0 ;
    
    
    double v5;
    v5 = v1 * 1.0 ;
    
    
    double v6;
    v6 = v5 * 0.0 ;
    
    
    double v7;
    v7 = v6 * 1.0 ;
    
    
    double v8;
    v8 = v4 - v7 ;
    
    
    double v9;
    v9 = 5.0 * 1.0 ;
    
    
    double v10;
    v10 = v9 * 0.0 ;
    
    
    double v11;
    v11 = v8 + v10 ;
    
    
    double v12;
    v12 = v1 * 0.0 ;
    
    
    double v13;
    v13 = v12 * 0.0 ;
    
    
    double v14;
    v14 = v11 + v13 ;
    
    
    double v15;
    v15 = 5.0 * 1.0 ;
    
    
    double v16;
    v16 = v15 * 1.0 ;
    
    
    double v17;
    v17 = v14 + v16 ;
    
    
    double v18;
    v18 = 5.0 * 1.0 ;
    
    
    double v19;
    v19 = v18 * 1.0 ;
    
    
    double v20;
    v20 = v1 * 0.0 ;
    
    
    double v21;
    v21 = v20 * 1.0 ;
    
    
    double v22;
    v22 = v19 + v21 ;
    
    
    double v23;
    v23 = 5.0 * 0.0 ;
    
    
    double v24;
    v24 = v23 * 0.0 ;
    
    
    double v25;
    v25 = v24 * 0.0 ;
    
    
    double v26;
    v26 = v22 - v25 ;
    
    
    double v27;
    v27 = v1 * 1.0 ;
    
    
    double v28;
    v28 = v27 * 0.0 ;
    
    
    double v29;
    v29 = v28 * 0.0 ;
    
    
    double v30;
    v30 = v26 + v29 ;
    
    
    double v31;
    v31 = 5.0 * 1.0 ;
    
    
    double v32;
    v32 = v31 * 0.0 ;
    
    
    double v33;
    v33 = v30 - v32 ;
    
    
    double v34;
    v34 = v1 * 1.0 ;
    
    
    double v35;
    v35 = v34 * 1.0 ;
    
    
    double v36;
    v36 = 5.0 * 0.0 ;
    
    
    double v37;
    v37 = v36 * 1.0 ;
    
    
    double v38;
    v38 = v35 - v37 ;
    
    
    double v39;
    v39 = 5.0 * 0.0 ;
    
    
    double v40;
    v40 = v38 + v39 ;
    
    
    double v41;
    v41 = v40 + 100.0 ;
    
    
    double v42;
    v42 = 1.0 / v41 ;
    
    
    double v43;
    v43 = 80.0 + 40.0 ;
    
    
    double v44;
    v44 = 40.0 * v42 ;
    
    
    double v45;
    v45 = v44 * v17 ;
    
    
    double v46;
    v46 = v45 * 2.0 ;
    
    
    double v47;
    v47 = v43 + v46 ;
    
    
    double v48;
    v48 = 40.0 * v42 ;
    
    
    double v49;
    v49 = v48 * v33 ;
    
    
    double v50;
    v50 = 22.0 + v49 ;
    
    
    bool v51;
    v51 = v47 >= 0.0;
    
    
    bool v53;
    if (v51){
        
        
        bool v52;
        v52 = v47 < 160.0;
        
        
        v53 = v52;
    } else {
        
        
        v53 = false;
    }
    
    
    bool v55;
    if (v53){
        
        
        bool v54;
        v54 = v50 >= 0.0;
        
        
        v55 = v54;
    } else {
        
        
        v55 = false;
    }
    
    
    bool v57;
    if (v55){
        
        
        bool v56;
        v56 = v50 < 44.0;
        
        
        v57 = v56;
    } else {
        
        
        v57 = false;
    }
    
    
    US0 v60;
    if (v57){
        
        
        v60 = US0_1(v47, v50, v42);
    } else {
        
        
        v60 = US0_0();
    }
    
    
    switch (v60.tag) {
        case 1: { // Visible
            double v61 = v60.case1.v0; double v62 = v60.case1.v1; double v63 = v60.case1.v2;
            
            USDecref0(&(v60));
            bool v64;
            v64 = v61 >= 0.0;
            
            
            bool v66;
            if (v64){
                
                
                bool v65;
                v65 = v62 >= 0.0;
                
                
                v66 = v65;
            } else {
                
                
                v66 = false;
            }
            
            
            bool v68;
            if (v66){
                
                
                bool v67;
                v67 = v63 > 0.0;
                
                
                v68 = v67;
            } else {
                
                
                v68 = false;
            }
            
            
            if (v68){
                
                
                int32_t v69;
                v69 = (int32_t)v61;
                
                
                int32_t v70;
                v70 = (int32_t)v62;
                
                
                int32_t v71;
                v71 = v70 * 160l ;
                
                
                int32_t v72;
                v72 = v69 + v71 ;
                
                
                
                AssignArray0(&(v0->ptr[v72]), 43l);
                
                ArrayDecref0(v0);
                return v72;
            } else {
                
                ArrayDecref0(v0);
                return 0l;
            }
            break;
        }
        default: {
            
            ArrayDecref0(v0); USDecref0(&(v60));
            return 0l;
        }
    }
}
static inline void ArrayDecrefBody1(Array1 * x){
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(char) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, char * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref1(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit1(len, ptr);
}
static inline String * StringConcat(String * left, String * right){
    uint32_t left_len = left->len - 1;
    uint32_t right_len = right->len - 1;
    String * result = ArrayCreate1(left_len + right_len + 1, false);
    memcpy(result->ptr, left->ptr, left_len);
    memcpy(result->ptr + left_len, right->ptr, right_len + 1);
    return result;
}
String * frame_text_loop4(Array0 * v0, int32_t v1, int32_t v2, int32_t v3, String * v4){
    
    
    bool v5;
    v5 = v3 == v2 ;
    
    
    if (v5){
        
        ArrayDecref0(v0);
        return v4;
    } else {
        
        
        int32_t v6;
        v6 = v0->ptr[v3];
        
        
        bool v7;
        v7 = v6 == 35l ;
        
        
        String * v16;
        if (v7){
            
            
            String * v8;
            v8 = StringLit(2, "#");
            
            
            v16 = v8;
        } else {
            
            
            bool v9;
            v9 = v6 == 43l ;
            
            
            if (v9){
                
                
                String * v10;
                v10 = StringLit(2, "+");
                
                
                v16 = v10;
            } else {
                
                
                bool v11;
                v11 = v6 == 64l ;
                
                
                if (v11){
                    
                    
                    String * v12;
                    v12 = StringLit(2, "@");
                    
                    
                    v16 = v12;
                } else {
                    
                    
                    String * v13;
                    v13 = StringLit(2, ".");
                    
                    
                    v16 = v13;
                }
            }
        }
        
        
        String * v17;
        v17 = StringConcat(v4, v16);
        
        StringDecref(v4); StringDecref(v16);
        int32_t v18;
        v18 = v3 + 1l ;
        
        
        int32_t v19;
        v19 = v3 % v1 ;
        
        
        int32_t v20;
        v20 = v1 - 1l ;
        
        
        bool v21;
        v21 = v19 == v20 ;
        
        
        bool v23;
        if (v21){
            
            
            bool v22;
            v22 = v18 < v2;
            
            
            v23 = v22;
        } else {
            
            
            v23 = false;
        }
        
        
        if (v23){
            
            
            String * v24;
            v24 = StringConcat(v17, StringLit(2, "\n"));
            
            StringDecref(v17);
            return frame_text_loop4(v0, v1, v2, v18, v24);
        } else {
            
            
            return frame_text_loop4(v0, v1, v2, v18, v17);
        }
    }
}
char runtime_byte7(String * v0, int32_t v1){
    
    
    char v2;
    v2 = v0->ptr[v1];
    
    StringDecref(v0);
    return v2;
}
int32_t utf8_scalar_at_byte_offset6(String * v0, int32_t v1){
    
    
    int32_t v2;
    v2 = v0->len-1;
    
    
    bool v3;
    v3 = v1 < 0l;
    
    
    if (v3){
        
        StringDecref(v0);
        fprintf(stderr, "%s\n", "UTF-8 byte offset is negative.");
        exit(EXIT_FAILURE);
    } else {
        
        
        bool v5;
        v5 = v1 >= v2;
        
        
        if (v5){
            
            StringDecref(v0);
            fprintf(stderr, "%s\n", "UTF-8 byte offset is outside the string.");
            exit(EXIT_FAILURE);
        } else {
            v0->refc++;
            
            char v7;
            v7 = runtime_byte7(v0, v1);
            
            
            int32_t v8;
            v8 = ((uint8_t)v7);
            
            
            bool v9;
            v9 = v8 < 128l;
            
            
            if (v9){
                
                StringDecref(v0);
                return v8;
            } else {
                
                
                bool v10;
                v10 = v8 < 194l;
                
                
                if (v10){
                    
                    StringDecref(v0);
                    fprintf(stderr, "%s\n", "UTF-8 scalar starts with an invalid lead byte.");
                    exit(EXIT_FAILURE);
                } else {
                    
                    
                    bool v12;
                    v12 = v8 < 224l;
                    
                    
                    if (v12){
                        
                        
                        int32_t v13;
                        v13 = v1 + 1l ;
                        
                        
                        bool v14;
                        v14 = v13 >= v2;
                        
                        
                        if (v14){
                            
                            StringDecref(v0);
                            fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                            exit(EXIT_FAILURE);
                        } else {
                            
                            
                            int32_t v16;
                            v16 = v1 + 1l ;
                            v0->refc++;
                            
                            char v17;
                            v17 = runtime_byte7(v0, v16);
                            
                            StringDecref(v0);
                            int32_t v18;
                            v18 = ((uint8_t)v17);
                            
                            
                            bool v19;
                            v19 = v18 < 128l;
                            
                            
                            bool v21;
                            if (v19){
                                
                                
                                v21 = false;
                            } else {
                                
                                
                                bool v20;
                                v20 = v18 < 192l;
                                
                                
                                v21 = v20;
                            }
                            
                            
                            if (v21){
                                
                                
                                int32_t v22;
                                v22 = v8 - 192l ;
                                
                                
                                int32_t v23;
                                v23 = v22 * 64l ;
                                
                                
                                int32_t v24;
                                v24 = v18 - 128l ;
                                
                                
                                int32_t v25;
                                v25 = v23 + v24 ;
                                
                                
                                return v25;
                            } else {
                                
                                
                                fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                exit(EXIT_FAILURE);
                            }
                        }
                    } else {
                        
                        
                        bool v29;
                        v29 = v8 < 240l;
                        
                        
                        if (v29){
                            
                            
                            int32_t v30;
                            v30 = v1 + 2l ;
                            
                            
                            bool v31;
                            v31 = v30 >= v2;
                            
                            
                            if (v31){
                                
                                StringDecref(v0);
                                fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                exit(EXIT_FAILURE);
                            } else {
                                
                                
                                int32_t v33;
                                v33 = v1 + 1l ;
                                v0->refc++;
                                
                                char v34;
                                v34 = runtime_byte7(v0, v33);
                                
                                
                                int32_t v35;
                                v35 = ((uint8_t)v34);
                                
                                
                                int32_t v36;
                                v36 = v1 + 2l ;
                                v0->refc++;
                                
                                char v37;
                                v37 = runtime_byte7(v0, v36);
                                
                                StringDecref(v0);
                                int32_t v38;
                                v38 = ((uint8_t)v37);
                                
                                
                                bool v39;
                                v39 = v35 < 128l;
                                
                                
                                bool v41;
                                if (v39){
                                    
                                    
                                    v41 = false;
                                } else {
                                    
                                    
                                    bool v40;
                                    v40 = v35 < 192l;
                                    
                                    
                                    v41 = v40;
                                }
                                
                                
                                if (v41){
                                    
                                    
                                    bool v42;
                                    v42 = v38 < 128l;
                                    
                                    
                                    bool v44;
                                    if (v42){
                                        
                                        
                                        v44 = false;
                                    } else {
                                        
                                        
                                        bool v43;
                                        v43 = v38 < 192l;
                                        
                                        
                                        v44 = v43;
                                    }
                                    
                                    
                                    if (v44){
                                        
                                        
                                        int32_t v45;
                                        v45 = v8 - 224l ;
                                        
                                        
                                        int32_t v46;
                                        v46 = v45 * 4096l ;
                                        
                                        
                                        int32_t v47;
                                        v47 = v35 - 128l ;
                                        
                                        
                                        int32_t v48;
                                        v48 = v47 * 64l ;
                                        
                                        
                                        int32_t v49;
                                        v49 = v46 + v48 ;
                                        
                                        
                                        int32_t v50;
                                        v50 = v38 - 128l ;
                                        
                                        
                                        int32_t v51;
                                        v51 = v49 + v50 ;
                                        
                                        
                                        bool v52;
                                        v52 = v51 < 2048l;
                                        
                                        
                                        if (v52){
                                            
                                            
                                            fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                            exit(EXIT_FAILURE);
                                        } else {
                                            
                                            
                                            bool v54;
                                            v54 = v51 >= 55296l;
                                            
                                            
                                            if (v54){
                                                
                                                
                                                bool v55;
                                                v55 = v51 <= 57343l;
                                                
                                                
                                                if (v55){
                                                    
                                                    
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence encodes a surrogate.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    
                                                    
                                                    return v51;
                                                }
                                            } else {
                                                
                                                
                                                return v51;
                                            }
                                        }
                                    } else {
                                        
                                        
                                        fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                        exit(EXIT_FAILURE);
                                    }
                                } else {
                                    
                                    
                                    fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                    exit(EXIT_FAILURE);
                                }
                            }
                        } else {
                            
                            
                            bool v65;
                            v65 = v8 < 245l;
                            
                            
                            if (v65){
                                
                                
                                int32_t v66;
                                v66 = v1 + 3l ;
                                
                                
                                bool v67;
                                v67 = v66 >= v2;
                                
                                
                                if (v67){
                                    
                                    StringDecref(v0);
                                    fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                    exit(EXIT_FAILURE);
                                } else {
                                    
                                    
                                    int32_t v69;
                                    v69 = v1 + 1l ;
                                    v0->refc++;
                                    
                                    char v70;
                                    v70 = runtime_byte7(v0, v69);
                                    
                                    
                                    int32_t v71;
                                    v71 = ((uint8_t)v70);
                                    
                                    
                                    int32_t v72;
                                    v72 = v1 + 2l ;
                                    v0->refc++;
                                    
                                    char v73;
                                    v73 = runtime_byte7(v0, v72);
                                    
                                    
                                    int32_t v74;
                                    v74 = ((uint8_t)v73);
                                    
                                    
                                    int32_t v75;
                                    v75 = v1 + 3l ;
                                    v0->refc++;
                                    
                                    char v76;
                                    v76 = runtime_byte7(v0, v75);
                                    
                                    StringDecref(v0);
                                    int32_t v77;
                                    v77 = ((uint8_t)v76);
                                    
                                    
                                    bool v78;
                                    v78 = v71 < 128l;
                                    
                                    
                                    bool v80;
                                    if (v78){
                                        
                                        
                                        v80 = false;
                                    } else {
                                        
                                        
                                        bool v79;
                                        v79 = v71 < 192l;
                                        
                                        
                                        v80 = v79;
                                    }
                                    
                                    
                                    if (v80){
                                        
                                        
                                        bool v81;
                                        v81 = v74 < 128l;
                                        
                                        
                                        bool v83;
                                        if (v81){
                                            
                                            
                                            v83 = false;
                                        } else {
                                            
                                            
                                            bool v82;
                                            v82 = v74 < 192l;
                                            
                                            
                                            v83 = v82;
                                        }
                                        
                                        
                                        if (v83){
                                            
                                            
                                            bool v84;
                                            v84 = v77 < 128l;
                                            
                                            
                                            bool v86;
                                            if (v84){
                                                
                                                
                                                v86 = false;
                                            } else {
                                                
                                                
                                                bool v85;
                                                v85 = v77 < 192l;
                                                
                                                
                                                v86 = v85;
                                            }
                                            
                                            
                                            if (v86){
                                                
                                                
                                                int32_t v87;
                                                v87 = v8 - 240l ;
                                                
                                                
                                                int32_t v88;
                                                v88 = v87 * 262144l ;
                                                
                                                
                                                int32_t v89;
                                                v89 = v71 - 128l ;
                                                
                                                
                                                int32_t v90;
                                                v90 = v89 * 4096l ;
                                                
                                                
                                                int32_t v91;
                                                v91 = v88 + v90 ;
                                                
                                                
                                                int32_t v92;
                                                v92 = v74 - 128l ;
                                                
                                                
                                                int32_t v93;
                                                v93 = v92 * 64l ;
                                                
                                                
                                                int32_t v94;
                                                v94 = v91 + v93 ;
                                                
                                                
                                                int32_t v95;
                                                v95 = v77 - 128l ;
                                                
                                                
                                                int32_t v96;
                                                v96 = v94 + v95 ;
                                                
                                                
                                                bool v97;
                                                v97 = v96 < 65536l;
                                                
                                                
                                                if (v97){
                                                    
                                                    
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    
                                                    
                                                    bool v99;
                                                    v99 = v96 > 1114111l;
                                                    
                                                    
                                                    if (v99){
                                                        
                                                        
                                                        fprintf(stderr, "%s\n", "UTF-8 scalar is above U+10FFFF.");
                                                        exit(EXIT_FAILURE);
                                                    } else {
                                                        
                                                        
                                                        return v96;
                                                    }
                                                }
                                            } else {
                                                
                                                
                                                fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                                exit(EXIT_FAILURE);
                                            }
                                        } else {
                                            
                                            
                                            fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                            exit(EXIT_FAILURE);
                                        }
                                    } else {
                                        
                                        
                                        fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                        exit(EXIT_FAILURE);
                                    }
                                }
                            } else {
                                
                                StringDecref(v0);
                                fprintf(stderr, "%s\n", "UTF-8 scalar starts with an invalid lead byte.");
                                exit(EXIT_FAILURE);
                            }
                        }
                    }
                }
            }
        }
    }
}
int32_t loop5(String * v0, int32_t v1, int32_t v2, int32_t v3){
    
    
    bool v4;
    v4 = v2 == v1 ;
    
    
    if (v4){
        
        StringDecref(v0);
        return v3;
    } else {
        
        
        bool v5;
        v5 = v2 > v1;
        
        
        if (v5){
            
            StringDecref(v0);
            fprintf(stderr, "%s\n", "UTF-8 scalar width exceeds the string.");
            exit(EXIT_FAILURE);
        } else {
            v0->refc++;
            
            int32_t v7;
            v7 = utf8_scalar_at_byte_offset6(v0, v2);
            
            
            bool v8;
            v8 = v7 < 128l;
            
            
            int32_t v13;
            if (v8){
                
                
                v13 = 1l;
            } else {
                
                
                bool v9;
                v9 = v7 < 2048l;
                
                
                if (v9){
                    
                    
                    v13 = 2l;
                } else {
                    
                    
                    bool v10;
                    v10 = v7 < 65536l;
                    
                    
                    if (v10){
                        
                        
                        v13 = 3l;
                    } else {
                        
                        
                        v13 = 4l;
                    }
                }
            }
            
            
            int32_t v14;
            v14 = v2 + v13 ;
            
            
            int32_t v15;
            v15 = v3 + v7 ;
            
            
            return loop5(v0, v1, v14, v15);
        }
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 160l * 44l ;
    
    
    Array0 * v1;
    v1 = method0(v0);
    v1->refc++;
    
    int32_t v2;
    v2 = method1(v1);
    v1->refc++;
    
    int32_t v3;
    v3 = method2(v1);
    v1->refc++;
    
    int32_t v4;
    v4 = method3(v1);
    
    
    int32_t v5;
    v5 = v1->ptr[0l];
    
    
    int32_t v6;
    v6 = v1->ptr[5180l];
    
    
    int32_t v7;
    v7 = v1->ptr[4258l];
    
    
    int32_t v8;
    v8 = v1->ptr[3964l];
    
    
    int32_t v9;
    v9 = 160l;
    
    
    int32_t v10;
    v10 = 160l * 44l ;
    
    
    int32_t v11;
    v11 = 0l;
    
    
    String * v12;
    v12 = StringLit(1, "");
    v1->refc++; v12->refc++;
    
    String * v13;
    v13 = frame_text_loop4(v1, v9, v10, v11, v12);
    
    ArrayDecref0(v1); StringDecref(v12);
    int32_t v14;
    v14 = v13->len-1;
    
    
    int32_t v15;
    v15 = 0l;
    
    
    int32_t v16;
    v16 = 0l;
    v13->refc++;
    
    int32_t v17;
    v17 = loop5(v13, v14, v15, v16);
    
    
    int32_t v18;
    v18 = 0l;
    v13->refc++;
    
    int32_t v19;
    v19 = utf8_scalar_at_byte_offset6(v13, v18);
    
    
    int32_t v20;
    v20 = 160l;
    v13->refc++;
    
    int32_t v21;
    v21 = utf8_scalar_at_byte_offset6(v13, v20);
    
    
    int32_t v22;
    v22 = 3988l;
    v13->refc++;
    
    int32_t v23;
    v23 = utf8_scalar_at_byte_offset6(v13, v22);
    
    
    int32_t v24;
    v24 = 4284l;
    v13->refc++;
    
    int32_t v25;
    v25 = utf8_scalar_at_byte_offset6(v13, v24);
    
    
    int32_t v26;
    v26 = 5212l;
    v13->refc++;
    
    int32_t v27;
    v27 = utf8_scalar_at_byte_offset6(v13, v26);
    
    
    int32_t v28;
    v28 = 7082l;
    v13->refc++;
    
    int32_t v29;
    v29 = utf8_scalar_at_byte_offset6(v13, v28);
    
    StringDecref(v13);
    bool v30;
    v30 = v2 == 5180l ;
    
    
    bool v32;
    if (v30){
        
        
        bool v31;
        v31 = v3 == 4258l ;
        
        
        v32 = v31;
    } else {
        
        
        v32 = false;
    }
    
    
    bool v34;
    if (v32){
        
        
        bool v33;
        v33 = v4 == 3964l ;
        
        
        v34 = v33;
    } else {
        
        
        v34 = false;
    }
    
    
    bool v36;
    if (v34){
        
        
        bool v35;
        v35 = v5 == 46l ;
        
        
        v36 = v35;
    } else {
        
        
        v36 = false;
    }
    
    
    bool v38;
    if (v36){
        
        
        bool v37;
        v37 = v6 == 35l ;
        
        
        v38 = v37;
    } else {
        
        
        v38 = false;
    }
    
    
    bool v40;
    if (v38){
        
        
        bool v39;
        v39 = v7 == 64l ;
        
        
        v40 = v39;
    } else {
        
        
        v40 = false;
    }
    
    
    bool v42;
    if (v40){
        
        
        bool v41;
        v41 = v8 == 43l ;
        
        
        v42 = v41;
    } else {
        
        
        v42 = false;
    }
    
    
    bool v44;
    if (v42){
        
        
        bool v43;
        v43 = v14 == 7083l ;
        
        
        v44 = v43;
    } else {
        
        
        v44 = false;
    }
    
    
    bool v46;
    if (v44){
        
        
        bool v45;
        v45 = v17 == 324274l ;
        
        
        v46 = v45;
    } else {
        
        
        v46 = false;
    }
    
    
    bool v48;
    if (v46){
        
        
        bool v47;
        v47 = v19 == 46l ;
        
        
        v48 = v47;
    } else {
        
        
        v48 = false;
    }
    
    
    bool v50;
    if (v48){
        
        
        bool v49;
        v49 = v21 == 10l ;
        
        
        v50 = v49;
    } else {
        
        
        v50 = false;
    }
    
    
    bool v52;
    if (v50){
        
        
        bool v51;
        v51 = v23 == 43l ;
        
        
        v52 = v51;
    } else {
        
        
        v52 = false;
    }
    
    
    bool v54;
    if (v52){
        
        
        bool v53;
        v53 = v25 == 64l ;
        
        
        v54 = v53;
    } else {
        
        
        v54 = false;
    }
    
    
    bool v56;
    if (v54){
        
        
        bool v55;
        v55 = v27 == 35l ;
        
        
        v56 = v55;
    } else {
        
        
        v56 = false;
    }
    
    
    bool v58;
    if (v56){
        
        
        bool v57;
        v57 = v29 == 46l ;
        
        
        v58 = v57;
    } else {
        
        
        v58 = false;
    }
    
    
    if (v58){
        
        
        return 42l;
    } else {
        
        
        return 1l;
    }
}
