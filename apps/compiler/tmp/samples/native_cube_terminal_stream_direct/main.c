#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
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
bool method_while0(int32_t v0){
    
    
    bool v1;
    v1 = v0 < 3l;
    
    
    return v1;
}
bool method_while1(int32_t v0){
    
    
    bool v1;
    v1 = v0 < 7040l;
    
    
    return v1;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    
    
    *a = b;
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
int32_t method0(Array0 * v0, double v1, double v2, double v3){
    
    
    double v4;
    v4 = sin(v1);
    
    
    double v5;
    v5 = 20.0 * v4;
    
    
    double v6;
    v6 = sin(v2);
    
    
    double v7;
    v7 = v5 * v6;
    
    
    double v8;
    v8 = cos(v3);
    
    
    double v9;
    v9 = v7 * v8;
    
    
    double v10;
    v10 = cos(v1);
    
    
    double v11;
    v11 = -20.0 * v10;
    
    
    double v12;
    v12 = v11 * v6;
    
    
    double v13;
    v13 = v12 * v8;
    
    
    double v14;
    v14 = v9 - v13;
    
    
    double v15;
    v15 = 20.0 * v10;
    
    
    double v16;
    v16 = sin(v3);
    
    
    double v17;
    v17 = v15 * v16;
    
    
    double v18;
    v18 = v14 + v17;
    
    
    double v19;
    v19 = -20.0 * v4;
    
    
    double v20;
    v20 = v19 * v16;
    
    
    double v21;
    v21 = v18 + v20;
    
    
    double v22;
    v22 = cos(v2);
    
    
    double v23;
    v23 = 20.0 * v22;
    
    
    double v24;
    v24 = v23 * v8;
    
    
    double v25;
    v25 = v21 + v24;
    
    
    double v26;
    v26 = v15 * v8;
    
    
    double v27;
    v27 = v19 * v8;
    
    
    double v28;
    v28 = v26 + v27;
    
    
    double v29;
    v29 = v7 * v16;
    
    
    double v30;
    v30 = v28 - v29;
    
    
    double v31;
    v31 = v12 * v16;
    
    
    double v32;
    v32 = v30 + v31;
    
    
    double v33;
    v33 = v23 * v16;
    
    
    double v34;
    v34 = v32 - v33;
    
    
    double v35;
    v35 = v11 * v22;
    
    
    double v36;
    v36 = v5 * v22;
    
    
    double v37;
    v37 = v35 - v36;
    
    
    double v38;
    v38 = 20.0 * v6;
    
    
    double v39;
    v39 = v37 + v38;
    
    
    double v40;
    v40 = v39 + 100.0;
    
    
    double v41;
    v41 = 1.0 / v40;
    
    
    double v42;
    v42 = 40.0 * v41;
    
    
    double v43;
    v43 = v42 * v25;
    
    
    double v44;
    v44 = v43 * 2.0;
    
    
    double v45;
    v45 = 40.0 + v44;
    
    
    double v46;
    v46 = v42 * v34;
    
    
    double v47;
    v47 = 22.0 + v46;
    
    
    bool v48;
    v48 = v45 >= 0.0;
    
    
    bool v50;
    if (v48){
        
        
        bool v49;
        v49 = v45 < 160.0;
        
        
        v50 = v49;
    } else {
        
        
        v50 = false;
    }
    
    
    bool v52;
    if (v50){
        
        
        bool v51;
        v51 = v47 >= 0.0;
        
        
        v52 = v51;
    } else {
        
        
        v52 = false;
    }
    
    
    bool v54;
    if (v52){
        
        
        bool v53;
        v53 = v47 < 44.0;
        
        
        v54 = v53;
    } else {
        
        
        v54 = false;
    }
    
    
    US0 v57;
    if (v54){
        
        
        v57 = US0_1(v45, v47, v41);
    } else {
        
        
        v57 = US0_0();
    }
    
    
    switch (v57.tag) {
        case 1: { // Visible
            double v58 = v57.case1.v0; double v59 = v57.case1.v1; double v60 = v57.case1.v2;
            
            USDecref0(&(v57));
            bool v61;
            v61 = v58 >= 0.0;
            
            
            bool v63;
            if (v61){
                
                
                bool v62;
                v62 = v59 >= 0.0;
                
                
                v63 = v62;
            } else {
                
                
                v63 = false;
            }
            
            
            bool v65;
            if (v63){
                
                
                bool v64;
                v64 = v60 > 0.0;
                
                
                v65 = v64;
            } else {
                
                
                v65 = false;
            }
            
            
            if (v65){
                
                
                int32_t v66;
                v66 = (int32_t)v58;
                
                
                int32_t v67;
                v67 = (int32_t)v59;
                
                
                int32_t v68;
                v68 = v67 * 160l;
                
                
                int32_t v69;
                v69 = v66 + v68;
                
                
                
                AssignArray0(&(v0->ptr[v69]), 35l);
                
                ArrayDecref0(v0);
                return v69;
            } else {
                
                ArrayDecref0(v0);
                return 0l;
            }
            break;
        }
        default: {
            
            ArrayDecref0(v0); USDecref0(&(v57));
            return 0l;
        }
    }
}
int32_t method1(Array0 * v0, double v1, double v2, double v3){
    
    
    double v4;
    v4 = sin(v1);
    
    
    double v5;
    v5 = 10.0 * v4;
    
    
    double v6;
    v6 = sin(v2);
    
    
    double v7;
    v7 = v5 * v6;
    
    
    double v8;
    v8 = cos(v3);
    
    
    double v9;
    v9 = v7 * v8;
    
    
    double v10;
    v10 = cos(v1);
    
    
    double v11;
    v11 = -10.0 * v10;
    
    
    double v12;
    v12 = v11 * v6;
    
    
    double v13;
    v13 = v12 * v8;
    
    
    double v14;
    v14 = v9 - v13;
    
    
    double v15;
    v15 = 10.0 * v10;
    
    
    double v16;
    v16 = sin(v3);
    
    
    double v17;
    v17 = v15 * v16;
    
    
    double v18;
    v18 = v14 + v17;
    
    
    double v19;
    v19 = -10.0 * v4;
    
    
    double v20;
    v20 = v19 * v16;
    
    
    double v21;
    v21 = v18 + v20;
    
    
    double v22;
    v22 = cos(v2);
    
    
    double v23;
    v23 = 10.0 * v22;
    
    
    double v24;
    v24 = v23 * v8;
    
    
    double v25;
    v25 = v21 + v24;
    
    
    double v26;
    v26 = v15 * v8;
    
    
    double v27;
    v27 = v19 * v8;
    
    
    double v28;
    v28 = v26 + v27;
    
    
    double v29;
    v29 = v7 * v16;
    
    
    double v30;
    v30 = v28 - v29;
    
    
    double v31;
    v31 = v12 * v16;
    
    
    double v32;
    v32 = v30 + v31;
    
    
    double v33;
    v33 = v23 * v16;
    
    
    double v34;
    v34 = v32 - v33;
    
    
    double v35;
    v35 = v11 * v22;
    
    
    double v36;
    v36 = v5 * v22;
    
    
    double v37;
    v37 = v35 - v36;
    
    
    double v38;
    v38 = 10.0 * v6;
    
    
    double v39;
    v39 = v37 + v38;
    
    
    double v40;
    v40 = v39 + 100.0;
    
    
    double v41;
    v41 = 1.0 / v40;
    
    
    double v42;
    v42 = 40.0 * v41;
    
    
    double v43;
    v43 = v42 * v25;
    
    
    double v44;
    v44 = v43 * 2.0;
    
    
    double v45;
    v45 = 90.0 + v44;
    
    
    double v46;
    v46 = v42 * v34;
    
    
    double v47;
    v47 = 22.0 + v46;
    
    
    bool v48;
    v48 = v45 >= 0.0;
    
    
    bool v50;
    if (v48){
        
        
        bool v49;
        v49 = v45 < 160.0;
        
        
        v50 = v49;
    } else {
        
        
        v50 = false;
    }
    
    
    bool v52;
    if (v50){
        
        
        bool v51;
        v51 = v47 >= 0.0;
        
        
        v52 = v51;
    } else {
        
        
        v52 = false;
    }
    
    
    bool v54;
    if (v52){
        
        
        bool v53;
        v53 = v47 < 44.0;
        
        
        v54 = v53;
    } else {
        
        
        v54 = false;
    }
    
    
    US0 v57;
    if (v54){
        
        
        v57 = US0_1(v45, v47, v41);
    } else {
        
        
        v57 = US0_0();
    }
    
    
    switch (v57.tag) {
        case 1: { // Visible
            double v58 = v57.case1.v0; double v59 = v57.case1.v1; double v60 = v57.case1.v2;
            
            USDecref0(&(v57));
            bool v61;
            v61 = v58 >= 0.0;
            
            
            bool v63;
            if (v61){
                
                
                bool v62;
                v62 = v59 >= 0.0;
                
                
                v63 = v62;
            } else {
                
                
                v63 = false;
            }
            
            
            bool v65;
            if (v63){
                
                
                bool v64;
                v64 = v60 > 0.0;
                
                
                v65 = v64;
            } else {
                
                
                v65 = false;
            }
            
            
            if (v65){
                
                
                int32_t v66;
                v66 = (int32_t)v58;
                
                
                int32_t v67;
                v67 = (int32_t)v59;
                
                
                int32_t v68;
                v68 = v67 * 160l;
                
                
                int32_t v69;
                v69 = v66 + v68;
                
                
                
                AssignArray0(&(v0->ptr[v69]), 64l);
                
                ArrayDecref0(v0);
                return v69;
            } else {
                
                ArrayDecref0(v0);
                return 0l;
            }
            break;
        }
        default: {
            
            ArrayDecref0(v0); USDecref0(&(v57));
            return 0l;
        }
    }
}
int32_t method2(Array0 * v0, double v1, double v2, double v3){
    
    
    double v4;
    v4 = sin(v1);
    
    
    double v5;
    v5 = 5.0 * v4;
    
    
    double v6;
    v6 = sin(v2);
    
    
    double v7;
    v7 = v5 * v6;
    
    
    double v8;
    v8 = cos(v3);
    
    
    double v9;
    v9 = v7 * v8;
    
    
    double v10;
    v10 = cos(v1);
    
    
    double v11;
    v11 = -5.0 * v10;
    
    
    double v12;
    v12 = v11 * v6;
    
    
    double v13;
    v13 = v12 * v8;
    
    
    double v14;
    v14 = v9 - v13;
    
    
    double v15;
    v15 = 5.0 * v10;
    
    
    double v16;
    v16 = sin(v3);
    
    
    double v17;
    v17 = v15 * v16;
    
    
    double v18;
    v18 = v14 + v17;
    
    
    double v19;
    v19 = -5.0 * v4;
    
    
    double v20;
    v20 = v19 * v16;
    
    
    double v21;
    v21 = v18 + v20;
    
    
    double v22;
    v22 = cos(v2);
    
    
    double v23;
    v23 = 5.0 * v22;
    
    
    double v24;
    v24 = v23 * v8;
    
    
    double v25;
    v25 = v21 + v24;
    
    
    double v26;
    v26 = v15 * v8;
    
    
    double v27;
    v27 = v19 * v8;
    
    
    double v28;
    v28 = v26 + v27;
    
    
    double v29;
    v29 = v7 * v16;
    
    
    double v30;
    v30 = v28 - v29;
    
    
    double v31;
    v31 = v12 * v16;
    
    
    double v32;
    v32 = v30 + v31;
    
    
    double v33;
    v33 = v23 * v16;
    
    
    double v34;
    v34 = v32 - v33;
    
    
    double v35;
    v35 = v11 * v22;
    
    
    double v36;
    v36 = v5 * v22;
    
    
    double v37;
    v37 = v35 - v36;
    
    
    double v38;
    v38 = 5.0 * v6;
    
    
    double v39;
    v39 = v37 + v38;
    
    
    double v40;
    v40 = v39 + 100.0;
    
    
    double v41;
    v41 = 1.0 / v40;
    
    
    double v42;
    v42 = 40.0 * v41;
    
    
    double v43;
    v43 = v42 * v25;
    
    
    double v44;
    v44 = v43 * 2.0;
    
    
    double v45;
    v45 = 120.0 + v44;
    
    
    double v46;
    v46 = v42 * v34;
    
    
    double v47;
    v47 = 22.0 + v46;
    
    
    bool v48;
    v48 = v45 >= 0.0;
    
    
    bool v50;
    if (v48){
        
        
        bool v49;
        v49 = v45 < 160.0;
        
        
        v50 = v49;
    } else {
        
        
        v50 = false;
    }
    
    
    bool v52;
    if (v50){
        
        
        bool v51;
        v51 = v47 >= 0.0;
        
        
        v52 = v51;
    } else {
        
        
        v52 = false;
    }
    
    
    bool v54;
    if (v52){
        
        
        bool v53;
        v53 = v47 < 44.0;
        
        
        v54 = v53;
    } else {
        
        
        v54 = false;
    }
    
    
    US0 v57;
    if (v54){
        
        
        v57 = US0_1(v45, v47, v41);
    } else {
        
        
        v57 = US0_0();
    }
    
    
    switch (v57.tag) {
        case 1: { // Visible
            double v58 = v57.case1.v0; double v59 = v57.case1.v1; double v60 = v57.case1.v2;
            
            USDecref0(&(v57));
            bool v61;
            v61 = v58 >= 0.0;
            
            
            bool v63;
            if (v61){
                
                
                bool v62;
                v62 = v59 >= 0.0;
                
                
                v63 = v62;
            } else {
                
                
                v63 = false;
            }
            
            
            bool v65;
            if (v63){
                
                
                bool v64;
                v64 = v60 > 0.0;
                
                
                v65 = v64;
            } else {
                
                
                v65 = false;
            }
            
            
            if (v65){
                
                
                int32_t v66;
                v66 = (int32_t)v58;
                
                
                int32_t v67;
                v67 = (int32_t)v59;
                
                
                int32_t v68;
                v68 = v67 * 160l;
                
                
                int32_t v69;
                v69 = v66 + v68;
                
                
                
                AssignArray0(&(v0->ptr[v69]), 43l);
                
                ArrayDecref0(v0);
                return v69;
            } else {
                
                ArrayDecref0(v0);
                return 0l;
            }
            break;
        }
        default: {
            
            ArrayDecref0(v0); USDecref0(&(v57));
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
String * frame_text_loop3(Array0 * v0, int32_t v1, int32_t v2, int32_t v3, String * v4){
    
    
    bool v5;
    v5 = v3 == v2;
    
    
    if (v5){
        
        ArrayDecref0(v0);
        return v4;
    } else {
        
        
        int32_t v6;
        v6 = v0->ptr[v3];
        
        
        bool v7;
        v7 = v6 == 35l;
        
        
        String * v16;
        if (v7){
            
            
            String * v8;
            v8 = StringLit(2, "#");
            
            
            v16 = v8;
        } else {
            
            
            bool v9;
            v9 = v6 == 43l;
            
            
            if (v9){
                
                
                String * v10;
                v10 = StringLit(2, "+");
                
                
                v16 = v10;
            } else {
                
                
                bool v11;
                v11 = v6 == 64l;
                
                
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
        v18 = v3 + 1l;
        
        
        int32_t v19;
        v19 = v3 % v1;
        
        
        int32_t v20;
        v20 = v1 - 1l;
        
        
        bool v21;
        v21 = v19 == v20;
        
        
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
            return frame_text_loop3(v0, v1, v2, v18, v24);
        } else {
            
            
            return frame_text_loop3(v0, v1, v2, v18, v17);
        }
    }
}
char runtime_byte6(String * v0, int32_t v1){
    
    
    char v2;
    v2 = v0->ptr[v1];
    
    StringDecref(v0);
    return v2;
}
int32_t utf8_scalar_at_byte_offset5(String * v0, int32_t v1){
    
    
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
            v7 = runtime_byte6(v0, v1);
            
            
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
                        v13 = v1 + 1l;
                        
                        
                        bool v14;
                        v14 = v13 >= v2;
                        
                        
                        if (v14){
                            
                            StringDecref(v0);
                            fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                            exit(EXIT_FAILURE);
                        } else {
                            v0->refc++;
                            
                            char v16;
                            v16 = runtime_byte6(v0, v13);
                            
                            StringDecref(v0);
                            int32_t v17;
                            v17 = ((uint8_t)v16);
                            
                            
                            bool v18;
                            v18 = v17 < 128l;
                            
                            
                            bool v20;
                            if (v18){
                                
                                
                                v20 = false;
                            } else {
                                
                                
                                bool v19;
                                v19 = v17 < 192l;
                                
                                
                                v20 = v19;
                            }
                            
                            
                            if (v20){
                                
                                
                                int32_t v21;
                                v21 = v8 - 192l;
                                
                                
                                int32_t v22;
                                v22 = v21 * 64l;
                                
                                
                                int32_t v23;
                                v23 = v17 - 128l;
                                
                                
                                int32_t v24;
                                v24 = v22 + v23;
                                
                                
                                return v24;
                            } else {
                                
                                
                                fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                exit(EXIT_FAILURE);
                            }
                        }
                    } else {
                        
                        
                        bool v28;
                        v28 = v8 < 240l;
                        
                        
                        if (v28){
                            
                            
                            int32_t v29;
                            v29 = v1 + 2l;
                            
                            
                            bool v30;
                            v30 = v29 >= v2;
                            
                            
                            if (v30){
                                
                                StringDecref(v0);
                                fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                exit(EXIT_FAILURE);
                            } else {
                                
                                
                                int32_t v32;
                                v32 = v1 + 1l;
                                v0->refc++;
                                
                                char v33;
                                v33 = runtime_byte6(v0, v32);
                                
                                
                                int32_t v34;
                                v34 = ((uint8_t)v33);
                                v0->refc++;
                                
                                char v35;
                                v35 = runtime_byte6(v0, v29);
                                
                                StringDecref(v0);
                                int32_t v36;
                                v36 = ((uint8_t)v35);
                                
                                
                                bool v37;
                                v37 = v34 < 128l;
                                
                                
                                bool v39;
                                if (v37){
                                    
                                    
                                    v39 = false;
                                } else {
                                    
                                    
                                    bool v38;
                                    v38 = v34 < 192l;
                                    
                                    
                                    v39 = v38;
                                }
                                
                                
                                if (v39){
                                    
                                    
                                    bool v40;
                                    v40 = v36 < 128l;
                                    
                                    
                                    bool v42;
                                    if (v40){
                                        
                                        
                                        v42 = false;
                                    } else {
                                        
                                        
                                        bool v41;
                                        v41 = v36 < 192l;
                                        
                                        
                                        v42 = v41;
                                    }
                                    
                                    
                                    if (v42){
                                        
                                        
                                        int32_t v43;
                                        v43 = v8 - 224l;
                                        
                                        
                                        int32_t v44;
                                        v44 = v43 * 4096l;
                                        
                                        
                                        int32_t v45;
                                        v45 = v34 - 128l;
                                        
                                        
                                        int32_t v46;
                                        v46 = v45 * 64l;
                                        
                                        
                                        int32_t v47;
                                        v47 = v44 + v46;
                                        
                                        
                                        int32_t v48;
                                        v48 = v36 - 128l;
                                        
                                        
                                        int32_t v49;
                                        v49 = v47 + v48;
                                        
                                        
                                        bool v50;
                                        v50 = v49 < 2048l;
                                        
                                        
                                        if (v50){
                                            
                                            
                                            fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                            exit(EXIT_FAILURE);
                                        } else {
                                            
                                            
                                            bool v52;
                                            v52 = v49 >= 55296l;
                                            
                                            
                                            if (v52){
                                                
                                                
                                                bool v53;
                                                v53 = v49 <= 57343l;
                                                
                                                
                                                if (v53){
                                                    
                                                    
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence encodes a surrogate.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    
                                                    
                                                    return v49;
                                                }
                                            } else {
                                                
                                                
                                                return v49;
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
                            
                            
                            bool v63;
                            v63 = v8 < 245l;
                            
                            
                            if (v63){
                                
                                
                                int32_t v64;
                                v64 = v1 + 3l;
                                
                                
                                bool v65;
                                v65 = v64 >= v2;
                                
                                
                                if (v65){
                                    
                                    StringDecref(v0);
                                    fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                    exit(EXIT_FAILURE);
                                } else {
                                    
                                    
                                    int32_t v67;
                                    v67 = v1 + 1l;
                                    v0->refc++;
                                    
                                    char v68;
                                    v68 = runtime_byte6(v0, v67);
                                    
                                    
                                    int32_t v69;
                                    v69 = ((uint8_t)v68);
                                    
                                    
                                    int32_t v70;
                                    v70 = v1 + 2l;
                                    v0->refc++;
                                    
                                    char v71;
                                    v71 = runtime_byte6(v0, v70);
                                    
                                    
                                    int32_t v72;
                                    v72 = ((uint8_t)v71);
                                    v0->refc++;
                                    
                                    char v73;
                                    v73 = runtime_byte6(v0, v64);
                                    
                                    StringDecref(v0);
                                    int32_t v74;
                                    v74 = ((uint8_t)v73);
                                    
                                    
                                    bool v75;
                                    v75 = v69 < 128l;
                                    
                                    
                                    bool v77;
                                    if (v75){
                                        
                                        
                                        v77 = false;
                                    } else {
                                        
                                        
                                        bool v76;
                                        v76 = v69 < 192l;
                                        
                                        
                                        v77 = v76;
                                    }
                                    
                                    
                                    if (v77){
                                        
                                        
                                        bool v78;
                                        v78 = v72 < 128l;
                                        
                                        
                                        bool v80;
                                        if (v78){
                                            
                                            
                                            v80 = false;
                                        } else {
                                            
                                            
                                            bool v79;
                                            v79 = v72 < 192l;
                                            
                                            
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
                                                
                                                
                                                int32_t v84;
                                                v84 = v8 - 240l;
                                                
                                                
                                                int32_t v85;
                                                v85 = v84 * 262144l;
                                                
                                                
                                                int32_t v86;
                                                v86 = v69 - 128l;
                                                
                                                
                                                int32_t v87;
                                                v87 = v86 * 4096l;
                                                
                                                
                                                int32_t v88;
                                                v88 = v85 + v87;
                                                
                                                
                                                int32_t v89;
                                                v89 = v72 - 128l;
                                                
                                                
                                                int32_t v90;
                                                v90 = v89 * 64l;
                                                
                                                
                                                int32_t v91;
                                                v91 = v88 + v90;
                                                
                                                
                                                int32_t v92;
                                                v92 = v74 - 128l;
                                                
                                                
                                                int32_t v93;
                                                v93 = v91 + v92;
                                                
                                                
                                                bool v94;
                                                v94 = v93 < 65536l;
                                                
                                                
                                                if (v94){
                                                    
                                                    
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    
                                                    
                                                    bool v96;
                                                    v96 = v93 > 1114111l;
                                                    
                                                    
                                                    if (v96){
                                                        
                                                        
                                                        fprintf(stderr, "%s\n", "UTF-8 scalar is above U+10FFFF.");
                                                        exit(EXIT_FAILURE);
                                                    } else {
                                                        
                                                        
                                                        return v93;
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
int32_t loop4(String * v0, int32_t v1, int32_t v2, int32_t v3){
    
    
    bool v4;
    v4 = v2 == v1;
    
    
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
            v7 = utf8_scalar_at_byte_offset5(v0, v2);
            
            
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
            v14 = v2 + v13;
            
            
            int32_t v15;
            v15 = v3 + v7;
            
            
            return loop4(v0, v1, v14, v15);
        }
    }
}
int32_t main(){
    
    
    Array0 * v0;
    v0 = ArrayCreate0(7040l, false);
    
    
    Array0 * v1;
    v1 = ArrayCreate0(3l, false);
    
    
    int32_t v2;
    v2 = 0l;
    
    
    
    while (method_while0(v2)){
        
        
        bool v4;
        v4 = v2 == 0l;
        
        
        double v9; double v10; double v11;
        if (v4){
            
            
            v9 = 0.0; v10 = 0.0; v11 = 0.0;
        } else {
            
            
            bool v5;
            v5 = v2 == 1l;
            
            
            if (v5){
                
                
                v9 = 0.1; v10 = 0.05; v11 = 0.02;
            } else {
                
                
                v9 = 0.2; v10 = 0.1; v11 = 0.04;
            }
        }
        
        
        int32_t v12;
        v12 = 0l;
        
        
        
        while (method_while1(v12)){
            
            
            
            AssignArray0(&(v0->ptr[v12]), 46l);
            
            
            int32_t v14;
            v14 = v12 + 1l;
            
            
            
            v12 = v14;
            
            
            
        }
        v0->refc++;
        
        int32_t v15;
        v15 = method0(v0, v9, v10, v11);
        v0->refc++;
        
        int32_t v16;
        v16 = method1(v0, v9, v10, v11);
        v0->refc++;
        
        int32_t v17;
        v17 = method2(v0, v9, v10, v11);
        
        
        int32_t v18;
        v18 = 160l;
        
        
        int32_t v19;
        v19 = 7040l;
        
        
        int32_t v20;
        v20 = 0l;
        
        
        String * v21;
        v21 = StringLit(1, "");
        v0->refc++; v21->refc++;
        
        String * v22;
        v22 = frame_text_loop3(v0, v18, v19, v20, v21);
        
        StringDecref(v21);
        int32_t v23;
        v23 = v22->len-1;
        
        
        int32_t v24;
        v24 = 0l;
        
        
        int32_t v25;
        v25 = 0l;
        v22->refc++;
        
        int32_t v26;
        v26 = loop4(v22, v23, v24, v25);
        
        
        String * v27;
        v27 = StringConcat(StringLit(4, "[H"), v22);
        
        StringDecref(v22);
        
        printf("%s", v27->ptr);
        
        StringDecref(v27);
        int32_t v28;
        v28 = v16 * 3l;
        
        
        int32_t v29;
        v29 = v15 + v28;
        
        
        int32_t v30;
        v30 = v17 * 7l;
        
        
        int32_t v31;
        v31 = v29 + v30;
        
        
        bool v32;
        v32 = v23 == 7083l;
        
        
        bool v34;
        if (v32){
            
            
            bool v33;
            v33 = v26 == 324274l;
            
            
            v34 = v33;
        } else {
            
            
            v34 = false;
        }
        
        
        int32_t v35;
        if (v34){
            
            
            v35 = v31;
        } else {
            
            
            v35 = 0l;
        }
        
        
        
        AssignArray0(&(v1->ptr[v2]), v35);
        
        
        int32_t v36;
        v36 = v2 + 1l;
        
        
        
        v2 = v36;
        
        
        
    }
    
    ArrayDecref0(v0);
    int32_t v37;
    v37 = v1->ptr[0l];
    
    
    int32_t v38;
    v38 = v1->ptr[1l];
    
    
    int32_t v39;
    v39 = v1->ptr[2l];
    
    ArrayDecref0(v1);
    bool v40;
    v40 = v37 == 45702l;
    
    
    bool v42;
    if (v40){
        
        
        bool v41;
        v41 = v38 == 43786l;
        
        
        v42 = v41;
    } else {
        
        
        v42 = false;
    }
    
    
    bool v44;
    if (v42){
        
        
        bool v43;
        v43 = v39 == 43631l;
        
        
        v44 = v43;
    } else {
        
        
        v44 = false;
    }
    
    
    if (v44){
        
        
        return 42l;
    } else {
        
        
        return 1l;
    }
}
