#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
#include <poll.h>
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
            
            
            bool v18;
            v18 = v8 < 128l;
            
            
            if (v18){
                
                StringDecref(v0);
                return v8;
            } else {
                
                
                bool v19;
                v19 = v8 < 194l;
                
                
                if (v19){
                    
                    StringDecref(v0);
                    fprintf(stderr, "%s\n", "UTF-8 scalar starts with an invalid lead byte.");
                    exit(EXIT_FAILURE);
                } else {
                    
                    
                    bool v21;
                    v21 = v8 < 224l;
                    
                    
                    if (v21){
                        
                        
                        int32_t v22;
                        v22 = v1 + 1l;
                        
                        
                        bool v23;
                        v23 = v22 >= v2;
                        
                        
                        if (v23){
                            
                            StringDecref(v0);
                            fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                            exit(EXIT_FAILURE);
                        } else {
                            v0->refc++;
                            
                            char v25;
                            v25 = runtime_byte6(v0, v22);
                            
                            StringDecref(v0);
                            int32_t v26;
                            v26 = ((uint8_t)v25);
                            
                            
                            bool v27;
                            v27 = v26 < 128l;
                            
                            
                            bool v29;
                            if (v27){
                                
                                
                                v29 = false;
                            } else {
                                
                                
                                bool v28;
                                v28 = v26 < 192l;
                                
                                
                                v29 = v28;
                            }
                            
                            
                            if (v29){
                                
                                
                                int32_t v30;
                                v30 = v8 - 192l;
                                
                                
                                int32_t v31;
                                v31 = v30 * 64l;
                                
                                
                                int32_t v32;
                                v32 = v26 - 128l;
                                
                                
                                int32_t v33;
                                v33 = v31 + v32;
                                
                                
                                return v33;
                            } else {
                                
                                
                                fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                exit(EXIT_FAILURE);
                            }
                        }
                    } else {
                        
                        
                        bool v37;
                        v37 = v8 < 240l;
                        
                        
                        if (v37){
                            
                            
                            int32_t v38;
                            v38 = v1 + 2l;
                            
                            
                            bool v39;
                            v39 = v38 >= v2;
                            
                            
                            if (v39){
                                
                                StringDecref(v0);
                                fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                exit(EXIT_FAILURE);
                            } else {
                                
                                
                                int32_t v41;
                                v41 = v1 + 1l;
                                v0->refc++;
                                
                                char v42;
                                v42 = runtime_byte6(v0, v41);
                                
                                
                                int32_t v43;
                                v43 = ((uint8_t)v42);
                                v0->refc++;
                                
                                char v44;
                                v44 = runtime_byte6(v0, v38);
                                
                                StringDecref(v0);
                                int32_t v45;
                                v45 = ((uint8_t)v44);
                                
                                
                                bool v46;
                                v46 = v43 < 128l;
                                
                                
                                bool v48;
                                if (v46){
                                    
                                    
                                    v48 = false;
                                } else {
                                    
                                    
                                    bool v47;
                                    v47 = v43 < 192l;
                                    
                                    
                                    v48 = v47;
                                }
                                
                                
                                if (v48){
                                    
                                    
                                    bool v49;
                                    v49 = v45 < 128l;
                                    
                                    
                                    bool v51;
                                    if (v49){
                                        
                                        
                                        v51 = false;
                                    } else {
                                        
                                        
                                        bool v50;
                                        v50 = v45 < 192l;
                                        
                                        
                                        v51 = v50;
                                    }
                                    
                                    
                                    if (v51){
                                        
                                        
                                        int32_t v52;
                                        v52 = v8 - 224l;
                                        
                                        
                                        int32_t v53;
                                        v53 = v52 * 4096l;
                                        
                                        
                                        int32_t v54;
                                        v54 = v43 - 128l;
                                        
                                        
                                        int32_t v55;
                                        v55 = v54 * 64l;
                                        
                                        
                                        int32_t v56;
                                        v56 = v53 + v55;
                                        
                                        
                                        int32_t v57;
                                        v57 = v45 - 128l;
                                        
                                        
                                        int32_t v58;
                                        v58 = v56 + v57;
                                        
                                        
                                        bool v59;
                                        v59 = v58 < 2048l;
                                        
                                        
                                        if (v59){
                                            
                                            
                                            fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                            exit(EXIT_FAILURE);
                                        } else {
                                            
                                            
                                            bool v61;
                                            v61 = v58 >= 55296l;
                                            
                                            
                                            if (v61){
                                                
                                                
                                                bool v62;
                                                v62 = v58 <= 57343l;
                                                
                                                
                                                if (v62){
                                                    
                                                    
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence encodes a surrogate.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    
                                                    
                                                    return v58;
                                                }
                                            } else {
                                                
                                                
                                                return v58;
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
                            
                            
                            bool v72;
                            v72 = v8 < 245l;
                            
                            
                            if (v72){
                                
                                
                                int32_t v73;
                                v73 = v1 + 3l;
                                
                                
                                bool v74;
                                v74 = v73 >= v2;
                                
                                
                                if (v74){
                                    
                                    StringDecref(v0);
                                    fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                    exit(EXIT_FAILURE);
                                } else {
                                    
                                    
                                    int32_t v76;
                                    v76 = v1 + 1l;
                                    v0->refc++;
                                    
                                    char v77;
                                    v77 = runtime_byte6(v0, v76);
                                    
                                    
                                    int32_t v78;
                                    v78 = ((uint8_t)v77);
                                    
                                    
                                    int32_t v79;
                                    v79 = v1 + 2l;
                                    v0->refc++;
                                    
                                    char v80;
                                    v80 = runtime_byte6(v0, v79);
                                    
                                    
                                    int32_t v81;
                                    v81 = ((uint8_t)v80);
                                    v0->refc++;
                                    
                                    char v82;
                                    v82 = runtime_byte6(v0, v73);
                                    
                                    StringDecref(v0);
                                    int32_t v83;
                                    v83 = ((uint8_t)v82);
                                    
                                    
                                    bool v84;
                                    v84 = v78 < 128l;
                                    
                                    
                                    bool v86;
                                    if (v84){
                                        
                                        
                                        v86 = false;
                                    } else {
                                        
                                        
                                        bool v85;
                                        v85 = v78 < 192l;
                                        
                                        
                                        v86 = v85;
                                    }
                                    
                                    
                                    if (v86){
                                        
                                        
                                        bool v87;
                                        v87 = v81 < 128l;
                                        
                                        
                                        bool v89;
                                        if (v87){
                                            
                                            
                                            v89 = false;
                                        } else {
                                            
                                            
                                            bool v88;
                                            v88 = v81 < 192l;
                                            
                                            
                                            v89 = v88;
                                        }
                                        
                                        
                                        if (v89){
                                            
                                            
                                            bool v90;
                                            v90 = v83 < 128l;
                                            
                                            
                                            bool v92;
                                            if (v90){
                                                
                                                
                                                v92 = false;
                                            } else {
                                                
                                                
                                                bool v91;
                                                v91 = v83 < 192l;
                                                
                                                
                                                v92 = v91;
                                            }
                                            
                                            
                                            if (v92){
                                                
                                                
                                                int32_t v93;
                                                v93 = v8 - 240l;
                                                
                                                
                                                int32_t v94;
                                                v94 = v93 * 262144l;
                                                
                                                
                                                int32_t v95;
                                                v95 = v78 - 128l;
                                                
                                                
                                                int32_t v96;
                                                v96 = v95 * 4096l;
                                                
                                                
                                                int32_t v97;
                                                v97 = v94 + v96;
                                                
                                                
                                                int32_t v98;
                                                v98 = v81 - 128l;
                                                
                                                
                                                int32_t v99;
                                                v99 = v98 * 64l;
                                                
                                                
                                                int32_t v100;
                                                v100 = v97 + v99;
                                                
                                                
                                                int32_t v101;
                                                v101 = v83 - 128l;
                                                
                                                
                                                int32_t v102;
                                                v102 = v100 + v101;
                                                
                                                
                                                bool v103;
                                                v103 = v102 < 65536l;
                                                
                                                
                                                if (v103){
                                                    
                                                    
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    
                                                    
                                                    bool v105;
                                                    v105 = v102 > 1114111l;
                                                    
                                                    
                                                    if (v105){
                                                        
                                                        
                                                        fprintf(stderr, "%s\n", "UTF-8 scalar is above U+10FFFF.");
                                                        exit(EXIT_FAILURE);
                                                    } else {
                                                        
                                                        
                                                        return v102;
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
bool method_while2(int32_t v0){
    
    
    bool v1;
    v1 = v0 < 4096l;
    
    
    return v1;
}
int32_t main(){
    
    
    Array0 * v0;
    v0 = ArrayCreate0(7040l, false);
    
    
    Array0 * v1;
    v1 = ArrayCreate0(3l, false);
    
    
    int32_t v2;
    v2 = 0l;
    
    
    int32_t v3;
    v3 = 0l;
    
    
    
    while (method_while0(v3)){
        
        
        bool v5;
        v5 = v3 == 0l;
        
        
        double v10; double v11; double v12;
        if (v5){
            
            
            v10 = 0.0; v11 = 0.0; v12 = 0.0;
        } else {
            
            
            bool v6;
            v6 = v3 == 1l;
            
            
            if (v6){
                
                
                v10 = 0.1; v11 = 0.05; v12 = 0.02;
            } else {
                
                
                v10 = 0.2; v11 = 0.1; v12 = 0.04;
            }
        }
        
        
        int32_t v13;
        v13 = 0l;
        
        
        
        while (method_while1(v13)){
            
            
            
            AssignArray0(&(v0->ptr[v13]), 46l);
            
            
            int32_t v15;
            v15 = v13 + 1l;
            
            
            
            v13 = v15;
            
            
            
        }
        v0->refc++;
        
        int32_t v16;
        v16 = method0(v0, v10, v11, v12);
        v0->refc++;
        
        int32_t v17;
        v17 = method1(v0, v10, v11, v12);
        v0->refc++;
        
        int32_t v18;
        v18 = method2(v0, v10, v11, v12);
        
        
        int32_t v19;
        v19 = 160l;
        
        
        int32_t v20;
        v20 = 7040l;
        
        
        int32_t v21;
        v21 = 0l;
        
        
        String * v22;
        v22 = StringLit(1, "");
        v0->refc++; v22->refc++;
        
        String * v23;
        v23 = frame_text_loop3(v0, v19, v20, v21, v22);
        
        StringDecref(v22);
        int32_t v24;
        v24 = v23->len-1;
        
        
        int32_t v25;
        v25 = 0l;
        
        
        int32_t v26;
        v26 = 0l;
        v23->refc++;
        
        int32_t v27;
        v27 = loop4(v23, v24, v25, v26);
        
        
        String * v28;
        v28 = StringConcat(StringLit(4, "[H"), v23);
        
        StringDecref(v23);
        
        printf("%s", v28->ptr);
        
        StringDecref(v28);
        int32_t v29;
        v29 = v17 * 3l;
        
        
        int32_t v30;
        v30 = v16 + v29;
        
        
        int32_t v31;
        v31 = v18 * 7l;
        
        
        int32_t v32;
        v32 = v30 + v31;
        
        
        bool v33;
        v33 = v24 == 7083l;
        
        
        bool v35;
        if (v33){
            
            
            bool v34;
            v34 = v27 == 324274l;
            
            
            v35 = v34;
        } else {
            
            
            v35 = false;
        }
        
        
        int32_t v36;
        if (v35){
            
            
            v36 = v32;
        } else {
            
            
            v36 = 0l;
        }
        
        
        
        AssignArray0(&(v1->ptr[v3]), v36);
        
        
        bool v37;
        v37 = v3 < 2l;
        
        
        
        if (v37){
            
            
            int32_t v38;
            v38 = 0l;
            
            
            int32_t v39;
            v39 = v3 + 1l;
            
            
            
            while (method_while2(v38)){
                
                
                int32_t v41;
                v41 = v38 % 17l;
                
                
                int32_t v42;
                v42 = v39 + v41;
                
                
                int32_t v43;
                v43 = v42 + 1l;
                
                
                int32_t v44;
                v44 = v43 % 997l;
                
                
                
                v39 = v44;
                
                
                int32_t v45;
                v45 = v38 + 1l;
                
                
                
                v38 = v45;
                
                
                
            }
            
            
            int32_t v46;
            v46 = v2 + v39;
            
            
            
            v2 = v46;
            
            
            
            poll(0, 0, 25l);
            
            
            
        } else {
            
            
            
        }
        
        
        int32_t v47;
        v47 = v3 + 1l;
        
        
        
        v3 = v47;
        
        
        
    }
    
    ArrayDecref0(v0);
    int32_t v48;
    v48 = v1->ptr[0l];
    
    
    int32_t v49;
    v49 = v1->ptr[1l];
    
    
    int32_t v50;
    v50 = v1->ptr[2l];
    
    ArrayDecref0(v1);
    bool v51;
    v51 = v48 == 45702l;
    
    
    bool v53;
    if (v51){
        
        
        bool v52;
        v52 = v49 == 43786l;
        
        
        v53 = v52;
    } else {
        
        
        v53 = false;
    }
    
    
    bool v55;
    if (v53){
        
        
        bool v54;
        v54 = v50 == 43631l;
        
        
        v55 = v54;
    } else {
        
        
        v55 = false;
    }
    
    
    bool v57;
    if (v55){
        
        
        bool v56;
        v56 = v2 == 1931l;
        
        
        v57 = v56;
    } else {
        
        
        v57 = false;
    }
    
    
    if (v57){
        
        
        return 42l;
    } else {
        
        
        return 1l;
    }
}
